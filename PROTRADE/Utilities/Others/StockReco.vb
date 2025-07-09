
Imports BL

Public Class StockReco

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public TEMPRECONO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public TEMPPROFORMANO As Integer = 0
    Public UNCHECKEDSTOCK As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockReco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then     'grid focus
            GRIDSTOCK.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        End If
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            If cmbitemname.Text = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
            FILLRACK(CMBRACK)
            FILLSHELF(CMBSHELF)

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("CMP_NAME AS CMPNAME", "", "CMPMASTER", " AND CMP_ID <> " & CmpId)
            For Each ROW As DataRow In DT.Rows
                CMBCMPNAME.Items.Add(ROW("CMPNAME"))
            Next
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
                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("DESIGN"), dr("COLOR"), Format(Val(dr("PCS")), "0"), "", Format(Val(dr("MTRS")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))
                Next
                txtremarks.Text = "Proforma No - " & Val(TEMPPROFORMANO)
                TOTAL()
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETUNCHECKEDDATA()
        Try
            Dim OBJCMN As New ClsCommon()
            Dim dttable As DataTable = OBJCMN.search("BARCODESTOCK.*", "", " BARCODESTOCK ", " AND BARCODESTOCK.BARCODE NOT IN (SELECT BARCODE FROM STOCKTAKING_DESC WHERE YEARID = " & YearId & ") AND BARCODESTOCK.YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                For Each dr As DataRow In dttable.Rows
                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), dr("DESIGNNO"), dr("COLOR"), Format(Val(dr("PCS")), "0"), dr("UNIT"), Format(Val(dr("MTRS")), "0.00"), dr("BARCODE"), dr("FROMNO"), dr("FROMSRNO"), dr("TYPE"))
                Next
                TOTAL()
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockReco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()

            If TEMPPROFORMANO > 0 Then GETDATA()
            If UNCHECKEDSTOCK = True Then GETUNCHECKEDDATA()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objSTOCK As New ClsStockAdjustment()
                Dim dttable As DataTable = objSTOCK.SELECTSTOCKADJUSTMENT(TEMPRECONO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        TXTRECONO.Text = TEMPRECONO
                        DTRECODATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbtrans.Text = dr("TRANSNAME")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        If Val(dr("GRIDSRNO")) > 0 Then GRIDSTOCK.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE").ToString, dr("ITEMNAME").ToString, dr("QUALITY").ToString, dr("DESIGNNO").ToString, dr("COLOR").ToString, Format(dr("PCS"), "0.00"), dr("UNIT"), Format(dr("MTRS"), "0.00"), dr("BARCODE").ToString, dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))
                    Next



                    'GET DATA FROM STOCKADJUSTMENT_INDESC
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '')  AS BALENO, ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDDESC, '') AS GRIDDESC, ISNULL(STOCKADJUSTMENT_INDESC.SA_LOTNO, '') AS LOTNO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE, ISNULL(SHELFMASTER.SHELF_NAME, '') AS INSHELF, ISNULL(RACKMASTER.RACK_NAME, '') AS INRACK ", "", " STOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN RACKMASTER ON STOCKADJUSTMENT_INDESC.SA_RACKID = RACKMASTER.RACK_ID LEFT OUTER JOIN SHELFMASTER ON STOCKADJUSTMENT_INDESC.SA_SHELFID = SHELFMASTER.SHELF_ID LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN  ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId & " ORDER BY STOCKADJUSTMENT_INDESC.SA_GRIDSRNO")

                    'Dim DT As DataTable = OBJCMN.search(" ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '') AS BALENO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS,ISNULL(STOCKADJUSTMENT_INDESC.SA_RACKID, 0) AS RACK,ISNULL(STOCKADJUSTMENT_INDESC.SA_SHELFID, 0) AS SHELF, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE ", "", " STOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId)
                    For Each DR As DataRow In DT.Rows
                        'Item Grid
                        GRIDSTOCKIN.Rows.Add(DR("GRIDSRNO").ToString, DR("PIECETYPE"), DR("ITEM").ToString, DR("QUALITY").ToString, DR("BALENO").ToString, DR("GRIDDESC"), DR("LOTNO"), DR("DESIGN").ToString, DR("COLOR"), Format(Val(DR("CUT")), "0.00"), Format(Val(DR("qty")), "0.00"), DR("UNIT").ToString, Format(Val(DR("MTRS")), "0.00"), DR("INRACK").ToString, DR("INSHELF").ToString, DR("BARCODE"), 0, DR("OUTPCS"), DR("OUTMTRS"))

                        If Convert.ToBoolean(DR("GRIDDONE")) = True Or Val(DR("OUTPCS")) > 0 Or Val(DR("OUTMTRS")) > 0 Then
                            GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                        TabControl1.SelectedIndex = 1
                    Next

                Else
                    EDIT = False
                    CLEAR()
                End If

                TOTAL()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub CLEAR()

        EP.Clear()
        LBLCATEGORY.Text = ""

        CMBCMPNAME.Text = ""
        TXTCHNO.Clear()

        DTRECODATE.Value = Now.Date
        tstxtbillno.Clear()
        TXTFROM.Clear()
        TXTTO.Clear()

        txtremarks.Clear()

        CMDSELECTSTOCK.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False

        LBLTOTALOUTMTRS.Text = 0.0
        LBLTOTALOUTPCS.Text = 0.0
        LBLTOTALINMTRS.Text = 0.0
        LBLTOTALINPCS.Text = 0.0
        cmbtrans.Text = ""

        TXTBARCODE.Clear()

        GRIDSTOCK.RowCount = 0


        txtsrno.Text = 1
        CMBPIECETYPE.Text = ""
        cmbitemname.Text = ""
        CMBQUALITY.Text = ""
        TXTBALENO.Clear()
        TXTGRIDDESC.Clear()
        TXTLOTNO.Clear()
        CMBDESIGN.Text = ""
        cmbcolor.Text = ""
        TXTCUT.Clear()
        txtqty.Text = 1
        TXTNOOFENTRIES.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        CMBRACK.Text = ""
        CMBSHELF.Text = ""

        TXTINBARCODE.Clear()
        GRIDSTOCKIN.RowCount = 0


        GRIDDOUBLECLICK = False
        TabControl1.SelectedIndex = 0
        getmaxno()


    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            If ALLOWADJMTRSDIFF = False And Val(LBLTOTALINMTRS.Text.Trim) < Val(LBLTOTALOUTMTRS.Text.Trim) Then
                EP.SetError(LBLTOTALOUTPCS, " In Mtrs Cannot be Less than Out Mtrs")
                MsgBox("In Mtrs Cannot be Less than Out Mtrs")
                bln = False
            End If

            If ClientName = "SOFTAS" And Val(LBLTOTALINMTRS.Text.Trim) <> Val(LBLTOTALOUTMTRS.Text.Trim) Then
                EP.SetError(LBLTOTALOUTMTRS, " In & Out Mtrs Should be same")
                bln = False
            End If

            If ClientName = "SOFTAS" And Val(LBLTOTALINPCS.Text.Trim) <> Val(LBLTOTALOUTPCS.Text.Trim) Then
                EP.SetError(LBLTOTALOUTPCS, " In & Out Pcs Should be same")
                bln = False
            End If

            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If ClientName <> "PARAS" Then
                    If Val(ROW.Cells(GPCS.Index).Value) = 0 Then
                        EP.SetError(LBLTOTALOUTPCS, "Pcs Cannot be 0")
                        bln = False
                    End If
                End If

                If ClientName <> "AXIS" And ClientName <> "GELATO" And ClientName <> "MOMAI" Then
                    If Val(ROW.Cells(GMTRS.Index).Value) = 0 Then
                        EP.SetError(LBLTOTALOUTMTRS, "Mtrs Cannot be 0")
                        bln = False
                    End If
                End If
            Next


            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            If Not CHECKBARCODE() Then
                bln = False
                EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            End If

            If Not datecheck(DTRECODATE.Text) Then
                EP.SetError(DTRECODATE, "Date not in Accounting Year")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Function CHECKBARCODE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(SA_BARCODE,'') AS BARCODE ", "", " STOCKADJUSTMENT_INDESC ", " AND SA_YEARID =  " & YearId)
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    For Each ROW As Windows.Forms.DataGridViewRow In GRIDSTOCKIN.Rows
                        If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(GBARCODE.Index).Value.ToString) Then
                            BLN = False
                            Exit Function
                        End If
                    Next
                Next
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        DTRECODATE.Focus()
        TEMPPROFORMANO = 0
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SA_no),0) + 1 ", " STOCKADJUSTMENT ", " AND SA_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Format(DTRECODATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(Val(LBLTOTALOUTPCS.Text))
            alParaval.Add(Val(LBLTOTALOUTMTRS.Text))
            alParaval.Add(Val(LBLTOTALINPCS.Text))
            alParaval.Add(Val(LBLTOTALINMTRS.Text))

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
            Dim UNIT As String = ""
            Dim MTRS As String = ""

            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSTOCK.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString

                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = row.Cells(GCOLOR.Index).Value.ToString
                        PCS = row.Cells(GPCS.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString

                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString

                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString

                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(GCOLOR.Index).Value.ToString
                        PCS = PCS & "|" & row.Cells(GPCS.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString

                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

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
            alParaval.Add(UNIT)
            alParaval.Add(MTRS)

            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim INGRIDSRNO As String = ""
            Dim INPIECETYPE As String = ""
            Dim INITEMNAME As String = ""
            Dim INQUALITY As String = ""
            Dim INBALENO As String = ""
            Dim INGRIDDESC As String = ""
            Dim INLOTNO As String = ""
            Dim INDESIGN As String = ""
            Dim INCOLOR As String = ""
            Dim INCUT As String = ""
            Dim INPCS As String = ""
            Dim INQTYUNIT As String = ""
            Dim INMTRS As String = ""
            Dim INRACK As String = ""
            Dim INSHELF As String = ""
            Dim INBARCODE As String = ""
            Dim INDONE As String = ""
            Dim INOUTPCS As String = ""
            Dim INOUTMTRS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSTOCKIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If INGRIDSRNO = "" Then
                        INGRIDSRNO = row.Cells(GINSRNO.Index).Value.ToString
                        INPIECETYPE = row.Cells(GINPIECETYPE.Index).Value.ToString
                        INITEMNAME = row.Cells(GINITEMNAME.Index).Value.ToString
                        INQUALITY = row.Cells(GINQUALITY.Index).Value.ToString
                        INBALENO = row.Cells(GINBALENO.Index).Value.ToString
                        INGRIDDESC = row.Cells(GINDESC.Index).Value.ToString
                        INLOTNO = row.Cells(GINLOTNO.Index).Value.ToString
                        INDESIGN = row.Cells(GINDESIGN.Index).Value.ToString
                        INCOLOR = row.Cells(GINCOLOR.Index).Value.ToString
                        INCUT = row.Cells(GINCUT.Index).Value.ToString
                        INPCS = row.Cells(GINPCS.Index).Value.ToString
                        INQTYUNIT = row.Cells(GINUNIT.Index).Value.ToString
                        INMTRS = row.Cells(GINMTRS.Index).Value
                        INRACK = row.Cells(GRACK.Index).Value.ToString
                        INSHELF = row.Cells(GSHELF.Index).Value.ToString
                        INBARCODE = row.Cells(GINBARCODE.Index).Value
                        If row.Cells(GINDONE.Index).Value = True Then
                            INDONE = 1
                        Else
                            INDONE = 0
                        End If
                        INOUTPCS = row.Cells(GINOUTPCS.Index).Value
                        INOUTMTRS = row.Cells(GINOUTMTRS.Index).Value

                    Else

                        INGRIDSRNO = INGRIDSRNO & "|" & row.Cells(GINSRNO.Index).Value
                        INPIECETYPE = INPIECETYPE & "|" & row.Cells(GINPIECETYPE.Index).Value
                        INITEMNAME = INITEMNAME & "|" & row.Cells(GINITEMNAME.Index).Value
                        INQUALITY = INQUALITY & "|" & row.Cells(GINQUALITY.Index).Value.ToString
                        INBALENO = INBALENO & "|" & row.Cells(GINBALENO.Index).Value.ToString
                        INGRIDDESC = INGRIDDESC & "|" & row.Cells(GINDESC.Index).Value.ToString
                        INLOTNO = INLOTNO & "|" & row.Cells(GINLOTNO.Index).Value.ToString
                        INDESIGN = INDESIGN & "|" & row.Cells(GINDESIGN.Index).Value.ToString
                        INCOLOR = INCOLOR & "|" & row.Cells(GINCOLOR.Index).Value.ToString
                        INCUT = INCUT & "|" & row.Cells(GINCUT.Index).Value
                        INPCS = INPCS & "|" & row.Cells(GINPCS.Index).Value
                        INQTYUNIT = INQTYUNIT & "|" & row.Cells(GINUNIT.Index).Value
                        INMTRS = INMTRS & "|" & row.Cells(GINMTRS.Index).Value
                        INRACK = INRACK & "," & row.Cells(GRACK.Index).Value.ToString
                        INSHELF = INSHELF & "," & row.Cells(GSHELF.Index).Value.ToString
                        INBARCODE = INBARCODE & "|" & row.Cells(GINBARCODE.Index).Value
                        If row.Cells(GINDONE.Index).Value = True Then
                            INDONE = INDONE & "|" & "1"
                        Else
                            INDONE = INDONE & "|" & "0"
                        End If
                        INOUTPCS = INOUTPCS & "|" & row.Cells(GINOUTPCS.Index).Value
                        INOUTMTRS = INOUTMTRS & "|" & row.Cells(GINOUTMTRS.Index).Value

                    End If
                End If
            Next

            alParaval.Add(INGRIDSRNO)
            alParaval.Add(INPIECETYPE)
            alParaval.Add(INITEMNAME)
            alParaval.Add(INQUALITY)
            alParaval.Add(INBALENO)
            alParaval.Add(INGRIDDESC)
            alParaval.Add(INLOTNO)
            alParaval.Add(INDESIGN)
            alParaval.Add(INCOLOR)
            alParaval.Add(INCUT)
            alParaval.Add(INPCS)
            alParaval.Add(INQTYUNIT)
            alParaval.Add(INMTRS)
            alParaval.Add(INRACK)
            alParaval.Add(INSHELF)
            alParaval.Add(INBARCODE)
            alParaval.Add(INDONE)
            alParaval.Add(INOUTPCS)
            alParaval.Add(INOUTMTRS)



            Dim objSTOCK As New ClsStockAdjustment()
            objSTOCK.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objSTOCK.SAVE()
                MsgBox("Details Added")
                TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
                TEMPRECONO = DTTABLE.Rows(0).Item(0)
                'PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPRECONO)
                IntResult = objSTOCK.UPDATE()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPRECONO)
                EDIT = False
            End If
            If GRIDSTOCKIN.RowCount > 0 Then PRINTBARCODE()


            TEMPPROFORMANO = 0
            CLEAR()
            DTRECODATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT Then

                'PRINT BARCODE
                Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'GET FRESH DATA FROM DATABASE (ONLY GRID)
                'THIS IS DONE COZ FOR MULTIUSER THE NOS WILL BE SAME
                'SO WE WILL ADD BARCODE IN SP AND THEN FETCH THAT DATA HERE AFTER THAT WE WILL PRINT BARCODES
                GRIDSTOCKIN.RowCount = 0
                Dim OBJCMN1 As New ClsCommon
                Dim DT1 As DataTable = OBJCMN1.search("ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '')  AS BALENO, ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDDESC, '') AS GRIDDESC, ISNULL(STOCKADJUSTMENT_INDESC.SA_LOTNO, '') AS LOTNO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE, ISNULL(SHELFMASTER.SHELF_NAME, '') AS INSHELF, ISNULL(RACKMASTER.RACK_NAME, '') AS INRACK ", "", " STOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN RACKMASTER ON STOCKADJUSTMENT_INDESC.SA_RACKID = RACKMASTER.RACK_ID LEFT OUTER JOIN SHELFMASTER ON STOCKADJUSTMENT_INDESC.SA_SHELFID = SHELFMASTER.SHELF_ID LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN  ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId)
                For Each DR As DataRow In DT1.Rows
                    GRIDSTOCKIN.Rows.Add(DR("GRIDSRNO").ToString, DR("PIECETYPE"), DR("ITEM").ToString, DR("QUALITY").ToString, DR("BALENO").ToString, DR("GRIDDESC"), DR("LOTNO"), DR("DESIGN").ToString, DR("COLOR"), Format(Val(DR("CUT")), "0.00"), Format(Val(DR("qty")), "0.00"), DR("UNIT").ToString, Format(Val(DR("MTRS")), "0.00"), DR("INRACK").ToString, DR("INSHELF").ToString, DR("BARCODE"), 0, DR("OUTPCS"), DR("OUTMTRS"))
                Next


                Dim WHOLESALEBARCODE As Integer = 0
                If ClientName = "CC" Or ClientName = "SHREEDEV" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)

                Dim TEMPHEADER As String = ""
                If ClientName = "YASHVI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (M/N/O/P)")
                    If TEMPHEADER <> "M" And TEMPHEADER <> "N" And TEMPHEADER <> "O" And TEMPHEADER <> "P" And TEMPHEADER <> "Y" Then Exit Sub
                    If TEMPHEADER = "M" Then TEMPHEADER = "MAFATLAL"
                    If TEMPHEADER = "N" Or TEMPHEADER = "P" Then TEMPHEADER = ""
                    If TEMPHEADER = "O" Then TEMPHEADER = "ORGALIN"
                    If TEMPHEADER = "Y" Then TEMPHEADER = "PREPRINTED"
                End If


                If ClientName = "GELATO" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR MRP" & Chr(13) & "3 FOR WSP")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" Then Exit Sub
                End If

                If ClientName = "MANALI" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR PRE PRINTED")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "MANS" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR SALVATROE" & Chr(13) & "2 FOR MANS")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "AXIS" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR PCS" & Chr(13) & "2 FOR MTRS")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                If ClientName = "KRISHNA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR BOX STICKER")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
                End If

                Dim SUPRIYAHEADER As String = ""
                If ClientName = "SUPRIYA" Then
                    TEMPHEADER = InputBox("Enter Sticker Type (1/2/3/4/5/6/7)")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" And TEMPHEADER <> "4" And TEMPHEADER <> "5" And TEMPHEADER <> "6" And TEMPHEADER <> "7" Then Exit Sub
                    If TEMPHEADER = "1" Or TEMPHEADER = "6" Then SUPRIYAHEADER = "ROYAL TEX"
                    If TEMPHEADER = "2" Or TEMPHEADER = "7" Then SUPRIYAHEADER = "DEEP BLUE"
                    If TEMPHEADER = "3" Then SUPRIYAHEADER = ""
                    If TEMPHEADER = "4" Then SUPRIYAHEADER = "KAMDHENU"
                    If TEMPHEADER = "5" Then SUPRIYAHEADER = "5"
                End If

                For Each ROW As DataGridViewRow In GRIDSTOCKIN.Rows
                    'TO PRINT BARCODE FROM SELECTED SRNO
                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
                        If Val(ROW.Cells(GSRNO.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(GSRNO.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
                    End If

                    BARCODEPRINTING(ROW.Cells(GINBARCODE.Index).Value, ROW.Cells(GINPIECETYPE.Index).Value, ROW.Cells(GINITEMNAME.Index).Value, ROW.Cells(GINQUALITY.Index).Value, ROW.Cells(GINDESIGN.Index).Value, ROW.Cells(GINCOLOR.Index).Value, ROW.Cells(GINUNIT.Index).Value, ROW.Cells(GINLOTNO.Index).Value, ROW.Cells(GINBALENO.Index).Value, ROW.Cells(GINDESC.Index).Value, Val(ROW.Cells(GINMTRS.Index).Value), Val(ROW.Cells(GINPCS.Index).Value), Val(ROW.Cells(GINCUT.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE)
NEXTLINE:

                Next
            End If

            '                    Dim dirresults As String = ""
            '                    'Writing in file
            '                    Dim oWrite As System.IO.StreamWriter
            '                    oWrite = File.CreateText("D:\Barcode.txt")

            '                    'TO PRINT BARCODE FROM SELECTED SRNO
            '                    If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
            '                        If Val(ROW.Cells(GSRNO.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(GSRNO.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
            '                    End If



            '                    If ClientName = "SVS" Then
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.0 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q400")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q200,25")
            '                        oWrite.WriteLine("KI80")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.0 mm'></xpml>N")
            '                        oWrite.WriteLine("A376,160,2,2,1,1,N,""QUALITY""")
            '                        oWrite.WriteLine("A376,114,2,2,1,1,N,""D.NO""")
            '                        oWrite.WriteLine("A376,136,2,2,1,1,N,""SHADE""")
            '                        oWrite.WriteLine("B384,91,2,1,2,4,61,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A279,24,2,2,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A197,114,2,2,1,1,N,""QTY""")
            '                        oWrite.WriteLine("A376,183,2,2,1,1,N,""" & CmpName & """")    'cmpname
            '                        oWrite.WriteLine("A277,114,2,2,1,1,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A291,114,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A291,136,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A277,136,2,2,1,1,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("A291,162,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A277,162,2,2,1,1,N,""" & ROW.Cells(GINQUALITY.Index).Value & """")
            '                        oWrite.WriteLine("A157,114,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A143,114,2,2,1,1,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & " " & ROW.Cells(GINUNIT.Index).Value & """")

            '                        'oWrite.WriteLine("A143,114,2,2,1,1,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & " MTR""")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MARKIN" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='75.1 mm'></xpml>SIZE 97.5 mm, 75.1 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='75.1 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 709,566,""0"",180,16,16,""" & CmpName & """")
            '                        oWrite.WriteLine("TEXT 738,421,""0"",180,14,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 738,353,""0"",180,14,14,""COLOR""")
            '                        oWrite.WriteLine("TEXT 738,285,""0"",180,14,14,""LOTNO""")
            '                        oWrite.WriteLine("TEXT 738,488,""0"",180,14,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 738,216,""0"",180,14,14,""MTRS""")
            '                        oWrite.WriteLine("BARCODE 738,160,""128M"",74,0,180,3,6,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 597,79,""0"",180,16,16,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 527,488,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,421,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,353,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,285,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 527,216,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 498,488,""0"",180,14,14,""" & ROW.Cells(GINITEMNAME.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 498,421,""0"",180,14,14,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 498,353,""0"",180,14,14,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 498,285,""0"",180,14,14,""" & ROW.Cells(GINLOTNO.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 498,227,""0"",180,22,22,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BAR 43,505, 695, 3")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MOMAI" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.0 mm'></xpml>SIZE 47.5 mm, 25 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 365,188,""0"",180,14,14,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 365,146,""0"",180,14,14,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 365,102,""0"",180,9,9,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 172,101,""0"",180,8,8,""MRP""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPMRP As Double
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search("ISNULL(PL_RATE,0) AS RATE", "", "PRICELISTMASTER LEFT OUTER JOIN ITEMMASTER ON PL_ITEMID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN DESIGNMASTER ON PL_DESIGNID = DESIGN_ID LEFT OUTER JOIN COLORMASTER ON PL_COLORID = COLORMASTER.COLOR_ID", " AND ITEMMASTER.ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND DESIGNMASTER.DESIGN_NO = '" & ROW.Cells(GINDESIGN.Index).Value & "' AND PL_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPMRP = Val(DT.Rows(0).Item("RATE"))
            '                        End If

            '                        oWrite.WriteLine("TEXT 119,107,""0"",180,13,13, """ & TEMPMRP & """")
            '                        oWrite.WriteLine("TEXT 98,71,""0"",180,4,4,""(Inc. of all Taxes)""")
            '                        oWrite.WriteLine("TEXT 68,138,""0"",180,7,7,""1PCS""")
            '                        oWrite.WriteLine("BARCODE 365,72,""128M"",52,0,180,1,2, """ & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 325,17,""0"",180,6,6, """ & ROW.Cells(GINBARCODE.Index).Value & """")

            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SHALIBHADRA" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='25.4 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q406")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q203,25")
            '                        oWrite.WriteLine("KI80")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='25.4 mm'></xpml>N")
            '                        oWrite.WriteLine("B369,101,2,1,2,4,51,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A295,43,2,4,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A380,179,2,4,1,1,N,""Lot""")
            '                        oWrite.WriteLine("A380,138,2,4,1,1,N,""D.No""")
            '                        oWrite.WriteLine("A309,179,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A292,179,2,4,1,1,N,""""")
            '                        oWrite.WriteLine("A308,138,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A292,138,2,4,1,1,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A124,186,2,4,1,1,N,""Mtrs""")
            '                        oWrite.WriteLine("A176,150,2,3,2,2,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KCRAYON" Then

            '                        oWrite.WriteLine("SIZE 101.6 mm, 50.8 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 783,377,""2"",180,3,3,""" & ROW.Cells(GINDESIGN.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 783,283,""2"",180,2,2,""SHADE""")
            '                        If ROW.Cells(GINBALENO.Index).Value <> "" Then oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""TP""") Else oWrite.WriteLine("TEXT 111,283,""2"",180,2,2,""""")
            '                        oWrite.WriteLine("TEXT 405,216,""2"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 783,216,""2"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("TEXT 265,216,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 672,216,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 631,283,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 603,283,""2"",180,2,2,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 631,216,""2"",180,2,2,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 237,216,""2"",180,2,2,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("BARCODE 783,161,""128M"",95,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 601,55,""2"",180,2,2,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DAKSH" Then

            '                        oWrite.WriteLine("G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C2401560027LINEN VENZO")
            '                        oWrite.WriteLine("1X1100001550005L263001")
            '                        oWrite.WriteLine("1e4203600230043B" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1000060084" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1401280011" & ROW.Cells(GINITEMNAME.Index).Value)
            '                        oWrite.WriteLine("1911C1001090012SHADE")
            '                        oWrite.WriteLine("1911C1000610012QUALITY")
            '                        oWrite.WriteLine("1911C1001090077:")
            '                        oWrite.WriteLine("1911C1000610077:")
            '                        oWrite.WriteLine("1911C1401060086" & ROW.Cells(GINCOLOR.Index).Value)
            '                        oWrite.WriteLine("1911C1000610086" & ROW.Cells(GINQUALITY.Index).Value)
            '                        oWrite.WriteLine("1911C1000840012MTRS")
            '                        oWrite.WriteLine("1911C1000840077:")
            '                        oWrite.WriteLine("1911C1400810086" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911C1001090162D. NO")
            '                        oWrite.WriteLine("1911C1001090204:")
            '                        oWrite.WriteLine("1911C1201080212" & ROW.Cells(GINDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911C1000840162LOT")
            '                        oWrite.WriteLine("1911C1000840204:")
            '                        oWrite.WriteLine("1911C1000840213" & ROW.Cells(GINLOTNO.Index).Value)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "PARAS" Then

            '                        oWrite.WriteLine("SIZE 99.10 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 620,371,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 600,374,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 782,371,""ROMAN.TTF"",180,1,14,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 782,310,""ROMAN.TTF"",180,1,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 600,310,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 620,310,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 360,310,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 237,310,""ROMAN.TTF"",180,1,14,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("TEXT 211,310,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")


            '                        oWrite.WriteLine("TEXT 782,249,""ROMAN.TTF"",180,1,14,""LOTNO""")
            '                        oWrite.WriteLine("TEXT 620,249,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 600,249,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINLOTNO.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 363,249,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 231,249,""ROMAN.TTF"",180,1,14,"": """)
            '                        oWrite.WriteLine("TEXT 211,249,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 782,187,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 620,187,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("BARCODE 776,134,""128M"",83,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 499,47,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 600,192,""ROMAN.TTF"",180,1,18,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "ARIHANT" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("BARCODE 508,154,""128M"",106,0,180,2,4,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 408,42,""0"",180,10,10,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 508,378,""0"",180,16,16,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 508,316,""0"",180,12,12,""D.NO""")
            '                        oWrite.WriteLine("TEXT 508,265,""0"",180,12,12,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 166,316,""0"",180,12,12,""" & ROW.Cells(GINLOTNO.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 508,210,""0"",180,12,12,""MTRS""")
            '                        oWrite.WriteLine("TEXT 405,316,""0"",180,12,12,"":""")
            '                        oWrite.WriteLine("TEXT 405,265,""0"",180,12,12,"":""")
            '                        oWrite.WriteLine("TEXT 405,210,""0"",180,12,12,"":""")
            '                        oWrite.WriteLine("TEXT 377,316,""0"",180,12,12,""" & ROW.Cells(GINDESIGN.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("TEXT 377,265,""0"",180,12,12,""" & TEMPWIDTH & """")

            '                        oWrite.WriteLine("TEXT 377,217,""0"",180,18,18,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KEMLINO" Then

            '                        oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 581,354,""ROMAN.TTF"",180,1,19,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 738,282,""ROMAN.TTF"",180,1,14,""D.NO""")
            '                        oWrite.WriteLine("TEXT 738,228,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 738,172,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 738,119,""ROMAN.TTF"",180,1,14,""UNIT""")
            '                        oWrite.WriteLine("QRCODE 237,280,L,10,A,180,M2,S7,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 237,65,""ROMAN.TTF"",180,1,10,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 609,282,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 609,228,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 609,172,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 609,119,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 581,282,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 581,228,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 581,176,""ROMAN.TTF"",180,1,18,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("TEXT 581,67,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")


            '                        oWrite.WriteLine("TEXT 738,67,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 609,67,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 581,119,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINUNIT.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 738,348,""ROMAN.TTF"",180,1,14,""PROD""")
            '                        oWrite.WriteLine("TEXT 609,348,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("BAR 29,297, 708, 3")
            '                        oWrite.WriteLine("TEXT 410,119,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINLOTNO.Index).Value & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "PURVITEX" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>SIZE 101.6 mm, 50.8 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("BARCODE 790,113,""128M"",68,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 506,40,""ROMAN.TTF"",180,1,10,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 794,384,""ROMAN.TTF"",180,1,16,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 793,313,""ROMAN.TTF"",180,1,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 789,171,""ROMAN.TTF"",180,1,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 794,242,""ROMAN.TTF"",180,1,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 588,384,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 614,384,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 614,313,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 588,313,""ROMAN.TTF"",180,1,16,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 614,171,""ROMAN.TTF"",180,1,16,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 588,171,""ROMAN.TTF"",180,1,16,""" & TEMPWIDTH & """")

            '                        oWrite.WriteLine("TEXT 614,243,""0"",180,16,17,"":""")
            '                        oWrite.WriteLine("TEXT 588,252,""ROMAN.TTF"",180,1,24,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 233,171,""ROMAN.TTF"",180,1,16,"" """)
            '                        oWrite.WriteLine("TEXT 255,171,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 412,171,""ROMAN.TTF"",180,1,16,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 372,242,""ROMAN.TTF"",180,1,16,""DESC""")
            '                        oWrite.WriteLine("TEXT 255,242,""ROMAN.TTF"",180,1,16,"":""")
            '                        oWrite.WriteLine("TEXT 233,242,""ROMAN.TTF"",180,1,16,"" """)
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DJIMPEX" Then

            '                        oWrite.WriteLine("SIZE 99.10 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 768,362,""ROMAN.TTF"",180,1,14,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 768,303,""ROMAN.TTF"",180,1,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 768,244,""ROMAN.TTF"",180,1,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 768,185,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 271,232,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 614,362,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 614,303,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 614,244,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 614,185,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 170,235,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 593,362,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 593,303,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 593,244,""ROMAN.TTF"",180,1,14,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 593,185,""ROMAN.TTF"",180,1,14,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 149,235,""ROMAN.TTF"",180,1,16,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 768,133,""128M"",76,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 768,51,""ROMAN.TTF"",180,1,12,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 253,51,""ROMAN.TTF"",180,1,11,""WWW.DJIMPEX.IN""")
            '                        oWrite.WriteLine("TEXT 270,185,""ROMAN.TTF"",180,1,14,""YDS""")
            '                        oWrite.WriteLine("TEXT 170,185,""ROMAN.TTF"",180,1,14,"":""")
            '                        oWrite.WriteLine("TEXT 149,189,""ROMAN.TTF"",180,1,16,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value) * 1.094, "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "RATAN" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 745,378,""0"",180,11,11,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 745,330,""0"",180,11,11,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 745,282,""0"",180,11,11,""SHADE""")
            '                        oWrite.WriteLine("TEXT 308,186,""0"",180,11,11,""MTRS""")
            '                        oWrite.WriteLine("TEXT 745,186,""0"",180,13,13,""WIDTH""")
            '                        oWrite.WriteLine("BARCODE 745,126,""128M"",70,0,180,3,6,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 567,50,""0"",180,12,12,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 590,378,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 590,330,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 590,282,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 590,186,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 216,186,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 564,382,""0"",180,15,15,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,331,""0"",180,13,13,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,282,""0"",180,11,11,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 564,186,""0"",180,11,11,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 188,193,""0"",180,18,18,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 745,234,""0"",180,11,11,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 590,234,""0"",180,11,11,"":""")
            '                        oWrite.WriteLine("TEXT 564,234,""0"",180,11,11,""""")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KENCOT" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>SIZE 101.6 mm, 50.8 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("SPEED 4")
            '                        oWrite.WriteLine("DENSITY 10")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 506,377,""ROMAN.TTF"",180,1,17,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("BARCODE 780,140,""128M"",85,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 484,50,""ROMAN.TTF"",180,1,9,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 780,298,""ROMAN.TTF"",180,1,14,""DESIGN NO""")
            '                        oWrite.WriteLine("TEXT 321,298,""ROMAN.TTF"",180,1,14,""SHADE NO""")
            '                        oWrite.WriteLine("TEXT 585,302,""ROMAN.TTF"",180,1,17,"":""")
            '                        oWrite.WriteLine("TEXT 125,302,""ROMAN.TTF"",180,1,17,"":""")
            '                        oWrite.WriteLine("TEXT 555,311,""ROMAN.TTF"",180,1,24,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 95,305,""ROMAN.TTF"",180,1,17,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 382,209,""ROMAN.TTF"",180,1,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 266,214,""ROMAN.TTF"",180,1,17,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 243,213,""0"",180,17,17,""" & TEMPWIDTH & """")

            '                        oWrite.WriteLine("TEXT 677,214,""ROMAN.TTF"",180,1,17,"":""")
            '                        oWrite.WriteLine("TEXT 780,209,""ROMAN.TTF"",180,1,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 625,223,""ROMAN.TTF"",180,1,24,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 780,373,""ROMAN.TTF"",180,1,14,""MERCHANT NO :""")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DRDRAPES" Then

            '                        If ROW.Cells(GPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 734,287,""0"",180,13,13,""Quality""")
            '                        oWrite.WriteLine("TEXT 734,242,""0"",180,13,13,""Design""")
            '                        oWrite.WriteLine("TEXT 735,197,""0"",180,13,13,""Shade""")
            '                        oWrite.WriteLine("TEXT 734,151,""0"",180,13,13,""Mtrs""")
            '                        oWrite.WriteLine("TEXT 615,286,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 615,241,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 615,195,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 615,150,""0"",180,13,13,"":""")
            '                        oWrite.WriteLine("TEXT 595,286,""0"",180,13,13,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 595,241,""0"",180,14,14,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 595,196,""0"",180,14,14,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 595,151,""0"",180,14,14,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 726,107,""128M"",55,0,180,3,6,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 537,47,""0"",180,10,10,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SUCCESS" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='100.1 mm'></xpml>SIZE 99.10 mm, 100.1 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='100.1 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 767,429,""0"",180,24,24,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("BARCODE 682,578,""128M"",89,0,180,3,6,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 491,483,""0"",180,10,10,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 767,339,""0"",180,16,16,""D. NO""")
            '                        oWrite.WriteLine("TEXT 610,339,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 583,339,""0"",180,16,16,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 340,339,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 190,339,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 167,339,""0"",180,16,16,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 767,272,""0"",180,16,16,""GRADE""")
            '                        oWrite.WriteLine("TEXT 610,272,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 583,272,""0"",180,16,16,""" & ROW.Cells(GINPIECETYPE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 340,272,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 190,272,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 167,272,""0"",180,16,16,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 750,183,""0"",180,12,12,""FAST TO NORMAL WASHING. BLENDED FABRIC""")
            '                        oWrite.WriteLine("TEXT 652,137,""0"",180,12,12,""POLYSTER - 65%     VISCOSE - 35%""")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "YASHVI" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE
            '                        oWrite.WriteLine("SIZE 72.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 526,255,""ROMAN.TTF"",180,1,11,""QUALITY""")
            '                        oWrite.WriteLine("TEXT 526,220,""ROMAN.TTF"",180,1,11,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 526,185,""ROMAN.TTF"",180,1,11,""SHADE NO""")
            '                        oWrite.WriteLine("TEXT 526,150,""ROMAN.TTF"",180,1,11,""MTRS""")
            '                        oWrite.WriteLine("TEXT 526,115,""ROMAN.TTF"",180,1,11,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 357,255,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,220,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,185,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,150,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 357,115,""ROMAN.TTF"",180,1,11,"":""")
            '                        oWrite.WriteLine("TEXT 337,255,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 337,220,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 337,185,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 337,150,""ROMAN.TTF"",180,1,11,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 218,150,""ROMAN.TTF"",180,1,11,""" & ROW.Cells(GINUNIT.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("TEXT 337,115,""ROMAN.TTF"",180,1,11,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 526,311,""ROMAN.TTF"",180,1,15,""" & TEMPHEADER & """")
            '                        oWrite.WriteLine("TEXT 30,259,""ROMAN.TTF"",270,1,8,""" & TEMPREMARKS & """")
            '                        oWrite.WriteLine("BARCODE 522,82,""128M"",50,0,180,2,4,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 422,27,""ROMAN.TTF"",180,1,10,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "TARUN" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 755,241,""0"",180,14,14,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 299,241,""0"",180,14,14,""SHADE""")
            '                        oWrite.WriteLine("TEXT 755,184,""0"",180,14,14,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 755,352,""0"",180,14,14,""MERCHANT""")
            '                        oWrite.WriteLine("TEXT 755,299,""0"",180,14,14,""QUALITY""")
            '                        oWrite.WriteLine("BARCODE 767,136,""128M"",55,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 502,75,""0"",180,12,12,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 544,352,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 544,299,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 544,241,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 544,184,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 163,241,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 299,184,""0"",180,14,14,""MTRS""")
            '                        oWrite.WriteLine("TEXT 163,184,""0"",180,14,14,"":""")
            '                        oWrite.WriteLine("TEXT 516,352,""0"",180,14,14,""" & ROW.Cells(GINITEMNAME.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("TEXT 516,299,""0"",180,14,14,""" & TEMPCATEGORY & """")
            '                        oWrite.WriteLine("TEXT 516,241,""0"",180,14,14,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 516,184,""0"",180,14,14,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 139,241,""0"",180,14,14,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 139,184,""0"",180,14,14,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "YUMILONE" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 760,375,""0"",180,16,16,""MERCHANT""")
            '                        oWrite.WriteLine("TEXT 760,320,""0"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 760,265,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 760,210,""0"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 311,210,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("BARCODE 767,143,""128M"",88,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 502,49,""0"",180,12,12,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 539,375,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 539,320,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 539,265,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 539,210,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 190,210,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 518,375,""0"",180,16,16,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 518,320,""0"",180,16,16,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 518,265,""0"",180,16,16,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("TEXT 518,210,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 167,215,""0"",180,20,20,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "ALENCOT" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("1911C1401710016" & TEMPREMARKS)
            '                        oWrite.WriteLine("1911C1200750149" & TEMPWIDTH)
            '                        oWrite.WriteLine("1911C1201440070" & TEMPCATEGORY)

            '                        oWrite.WriteLine("1911C1201440007Quality")
            '                        oWrite.WriteLine("1911C1201210007Design")
            '                        oWrite.WriteLine("1911C1001450063:")
            '                        oWrite.WriteLine("1911C1201210070" & ROW.Cells(GINITEMNAME.Index).Value)
            '                        oWrite.WriteLine("1911C1001210063:")
            '                        oWrite.WriteLine("1911C1200750007Mtrs")
            '                        oWrite.WriteLine("1911C1000760063:")
            '                        oWrite.WriteLine("1911C1200750070" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1e4204000300000B" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1200110028" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1X1100101710011P0010001016900110169017701710177")
            '                        oWrite.WriteLine("1911C1200980007Shade")
            '                        oWrite.WriteLine("1911C1000990063:")
            '                        oWrite.WriteLine("1911C1200980070" & ROW.Cells(GINCOLOR.Index).Value)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "AVIS" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0739")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C1402500039Quality")
            '                        oWrite.WriteLine("1911C1402230039D. No")
            '                        oWrite.WriteLine("1911C1401950039Shade")
            '                        oWrite.WriteLine("1911C1401670039Grade")
            '                        oWrite.WriteLine("1911C1401390039Mtrs")
            '                        oWrite.WriteLine("1e6303800410038B" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1200220120" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1402500118:")
            '                        oWrite.WriteLine("1911C1402230118:")
            '                        oWrite.WriteLine("1911C1401950118:")
            '                        oWrite.WriteLine("1911C1401670118:")
            '                        oWrite.WriteLine("1911C1401390118:")
            '                        oWrite.WriteLine("1911C1402500141" & ROW.Cells(GINITEMNAME.Index).Value)
            '                        oWrite.WriteLine("1911C1402230141" & ROW.Cells(GINDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911C1401950141" & ROW.Cells(GINCOLOR.Index).Value)
            '                        oWrite.WriteLine("1911C1401670141" & ROW.Cells(GINUNIT.Index).Value)
            '                        oWrite.WriteLine("1911C1401390141" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00"))
            '                        If ROW.Cells(GINDESC.Index).Value <> "" Then oWrite.WriteLine("1911C1001180141 (" & ROW.Cells(GINDESC.Index).Value & ")")
            '                        oWrite.WriteLine("1911C1400890039Lot No")
            '                        oWrite.WriteLine("1911C1400890118:")
            '                        oWrite.WriteLine("1911C1400890141" & ROW.Cells(GINLOTNO.Index).Value)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SBA" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911A2401590067" & ROW.Cells(GINITEMNAME.Index).Value)
            '                        oWrite.WriteLine("1911A1001430011QUALITY")
            '                        oWrite.WriteLine("1911A1001430079:")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCATEGORY, TEMPREMARKS, TEMPCMPSTAMP As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCATEGORY = DT.Rows(0).Item("CATEGORY")
            '                            TEMPREMARKS = DT.Rows(0).Item("REMARKS")
            '                        End If

            '                        oWrite.WriteLine("1911A1001430090" & TEMPCATEGORY)
            '                        oWrite.WriteLine("1911A1001240090" & TEMPREMARKS)
            '                        oWrite.WriteLine("1911A1001070090" & TEMPWIDTH)

            '                        oWrite.WriteLine("1911A1001070011WIDTH")
            '                        oWrite.WriteLine("1911A1001070079:")

            '                        oWrite.WriteLine("1911A1001070185DESIGN NO")
            '                        oWrite.WriteLine("1911A1001070267:")
            '                        oWrite.WriteLine("1911A1001070276" & ROW.Cells(GINDESIGN.Index).Value)
            '                        oWrite.WriteLine("1e6304700360025B" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A0800220128" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1000880011MTRS")
            '                        oWrite.WriteLine("1911A1000880079:")
            '                        oWrite.WriteLine("1911A1400850090" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911A1000880185SHADE")
            '                        oWrite.WriteLine("1911A1000880267:")
            '                        oWrite.WriteLine("1911A1000880276" & ROW.Cells(GINCOLOR.Index).Value)
            '                        oWrite.WriteLine("1911A1000080140A PRODUCT OF ")
            '                        oWrite.WriteLine("1X1100000010253L117028")
            '                        oWrite.WriteLine("A1")
            '                        DT = OBJCMN.search(" ISNULL(CMPMASTER.CMP_BUSINESSLINE, '') AS CMPSTAMP", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            '                        If DT.Rows.Count > 0 Then TEMPCMPSTAMP = DT.Rows(0).Item("CMPSTAMP")
            '                        oWrite.WriteLine("1911A1800010255" & TEMPCMPSTAMP)

            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1X1100001610007L376003")

            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "POOJA" Then

            '                        oWrite.WriteLine("SIZE 98.5 mm, 37.5 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 754,267,""1"",180,2,2,""ITEM""")
            '                        oWrite.WriteLine("TEXT 637,267,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("BARCODE 762,103,""39"",65,0,180,3,8,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 473,30,""1"",180,1,1,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 754,204,""1"",180,2,2,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 637,204,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 750,141,""1"",180,2,2,""COLOR""")
            '                        oWrite.WriteLine("TEXT 637,141,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 352,141,""1"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("TEXT 263,141,""1"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 243,162,""3"",180,2,2,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("TEXT 609,274,""1"",180,3,3,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 609,204,""1"",180,2,2,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 609,141,""1"",180,2,2,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 372,200,""1"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 263,200,""1"",180,2,2,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 239,200,""1"",180,2,2,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("BAR 37, 219, 719, 3")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DETLINE" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.8 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("q792")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q406,25")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.8 mm'></xpml>N")
            '                        oWrite.WriteLine("A762,304,2,1,3,3,N,""D. NO""")
            '                        oWrite.WriteLine("A595,304,2,1,3,3,N,"":""")

            '                        oWrite.WriteLine("A554,304,2,1,3,3,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A762,237,2,1,3,3,N,""SHADE""")
            '                        oWrite.WriteLine("A595,237,2,1,3,3,N,"":""")
            '                        oWrite.WriteLine("A554,237,2,1,3,3,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("A762,173,2,1,3,3,N,""WIDTH""")
            '                        oWrite.WriteLine("A595,173,2,1,3,3,N,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A554,173,2,1,3,3,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A423,239,2,1,3,3,N,""MTRS""")
            '                        oWrite.WriteLine("A303,237,2,1,3,3,N,"":""")
            '                        oWrite.WriteLine("A266,241,2,2,3,3,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("B762,119,2,1,3,6,65,N,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("A647,50,2,2,2,2,N,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        'oWrite.WriteLine("A521,381,2,2,3,3,N,""")
            '                        oWrite.WriteLine("LO246,326,298,3")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MYCOT" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='100.1 mm'></xpml>SIZE 97.5 mm, 100.1 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='100.1 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 757,509,""2"",180,2,2,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 757,436,""2"",180,2,2,""SHADE""")
            '                        oWrite.WriteLine("TEXT 757,366,""2"",180,2,2,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 366,366,""2"",180,2,2,""MTRS""")
            '                        oWrite.WriteLine("BARCODE 767,294,""128M"",96,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 529,188,""1"",180,2,2,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 588,509,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 588,436,""2"",180,2,2,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 559,366,""2"",180,2,2,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 244,366,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 559,509,""2"",180,2,2,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 559,436,""2"",180,2,2,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 588,366,""2"",180,2,2,"":""")
            '                        oWrite.WriteLine("TEXT 211,372,""3"",180,2,2,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "RMANILAL" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 757,377,""0"",180,16,16,""ITEM NAME""")
            '                        oWrite.WriteLine("TEXT 757,313,""0"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 757,248,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 526,377,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 526,315,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 526,251,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 505,377,""0"",180,16,16,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 504,315,""0"",180,16,16,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 504,251,""0"",180,16,16,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("BARCODE 767,126,""128M"",77,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 502,44,""0"",180,16,16,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 757,184,""0"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 348,184,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 526,184,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 218,184,""0"",180,16,16,"":""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 504,184,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 190,189,""0"",180,20,20,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()


            '                    ElseIf ClientName = "SUNCOTT" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='50.0 mm'></xpml>SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='50.0 mm'></xpml>SET TEAR ON")
            '                        oWrite.WriteLine("ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 754,375,""0"",180,16,16,""ITEM""")
            '                        oWrite.WriteLine("TEXT 754,316,""0"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 754,258,""0"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 754,197,""0"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 338,197,""0"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 592,375,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,316,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,258,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,197,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 210,197,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 564,380,""0"",180,20,20,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,316,""0"",180,16,16,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,258,""0"",180,16,16,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 564,197,""0"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 190,201,""0"",180,20,20,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 767,135,""128M"",74,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 503,55,""0"",180,12,12,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 376,258,""0"",180,16,16,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 210,258,""0"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 187,258,""0"",180,16,16,""" & ROW.Cells(GINLOTNO.Index).Value & """")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MANMANDIR" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("SIZE 97.5 mm, 50 mm")
            '                        oWrite.WriteLine("GAP 3 mm, 0 mm")
            '                        oWrite.WriteLine("DIRECTION 0,0")
            '                        oWrite.WriteLine("REFERENCE 0,0")
            '                        oWrite.WriteLine("OFFSET 0 mm")
            '                        oWrite.WriteLine("SET PEEL OFF")
            '                        oWrite.WriteLine("SET CUTTER OFF")
            '                        oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
            '                        oWrite.WriteLine("SET TEAR ON")
            '                        oWrite.WriteLine("CLS")
            '                        oWrite.WriteLine("CODEPAGE 1252")
            '                        oWrite.WriteLine("TEXT 754,375,""ROMAN.TTF"",180,16,16,""ITEM""")
            '                        oWrite.WriteLine("TEXT 754,318,""ROMAN.TTF"",180,16,16,""DESIGN""")
            '                        oWrite.WriteLine("TEXT 754,258,""ROMAN.TTF"",180,16,16,""SHADE""")
            '                        oWrite.WriteLine("TEXT 754,197,""ROMAN.TTF"",180,16,16,""WIDTH""")
            '                        oWrite.WriteLine("TEXT 338,197,""ROMAN.TTF"",180,16,16,""MTRS""")
            '                        oWrite.WriteLine("TEXT 592,375,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,318,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,258,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 592,197,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 210,197,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 564,380,""ROMAN.TTF"",180,20,20,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,318,""ROMAN.TTF"",180,16,16,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 564,258,""ROMAN.TTF"",180,16,16,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("TEXT 564,197,""ROMAN.TTF"",180,16,16,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("TEXT 190,201,""ROMAN.TTF"",180,20,20,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("BARCODE 767,135,""128M"",74,0,180,4,8,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("TEXT 503,55,""ROMAN.TTF"",180,12,12,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("TEXT 358,318,""ROMAN.TTF"",180,16,16,""LOT NO""")
            '                        oWrite.WriteLine("TEXT 192,318,""ROMAN.TTF"",180,16,16,"":""")
            '                        oWrite.WriteLine("TEXT 160,318,""ROMAN.TTF"",180,16,16,""""")
            '                        oWrite.WriteLine("PRINT 1,1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "CC" Or ClientName = "SHREEDEV" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q418")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q203,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("B397,102,2,1,2,4,65,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A306,30,2,3,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE

            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_PURRATE,0) AS PURRATE, ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE", "", " DESIGNMASTER ", " AND DESIGN_NO = '" & ROW.Cells(GINDESIGN.Index).Value & "' AND DESIGN_YEARID =  " & YearId)

            '                        If DT.Rows.Count > 0 Then
            '                            If WHOLESALEBARCODE = 7 Then oWrite.WriteLine("A147,179,2,4,1,1,N,""" & Val(DT.Rows(0).Item("SALERATE")) & "/-""") Else oWrite.WriteLine("A147,179,2,4,1,1,N,""" & Val(DT.Rows(0).Item("WRATE")) / 10 & """")
            '                        Else
            '                            oWrite.WriteLine("A147,179,2,4,1,1,N,""")    'SALERATE
            '                        End If

            '                        oWrite.WriteLine("A401,175,2,2,1,1,N,""D.No""")
            '                        oWrite.WriteLine("A351,175,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A339,179,2,3,1,1,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A401,134,2,2,1,1,N,""Item""")
            '                        oWrite.WriteLine("A351,134,2,2,1,1,N,"":""")
            '                        oWrite.WriteLine("A339,139,2,3,1,1,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "PURPLE" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q401")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q304,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("B389,114,2,1,2,4,80,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A298,28,2,3,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A380,286,2,4,1,1,N,""Item""")
            '                        oWrite.WriteLine("A311,286,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A283,286,2,4,1,1,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A380,243,2,4,1,1,N,""D.No""")
            '                        oWrite.WriteLine("A311,243,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A283,243,2,4,1,1,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")


            '                        Dim CPCODE As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(DESIGN_PURRATE,0) AS PURRATE, ISNULL(DESIGN_SALERATE,0) AS SALERATE, ISNULL(DESIGN_WRATE,0) AS WRATE, ISNULL(DESIGN_PURRATE,0) AS PRATE", "", " DESIGNMASTER ", " AND DESIGN_NO = '" & ROW.Cells(GINDESIGN.Index).Value & "' AND DESIGN_YEARID =  " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            oWrite.WriteLine("A283,200,2,4,1,1,N,""" & Val(DT.Rows(0).Item("SALERATE")) & "/-""")
            '                            oWrite.WriteLine("A117,200,2,4,1,1,N,""19" & Val(DT.Rows(0).Item("WRATE")) & "67""")

            '                            'CODE FOR PURRATE (LOTUSDAIRY)
            '                            For POS As Integer = 0 To Len(Format(Val(DT.Rows(0).Item("PRATE")), "0")) - 1
            '                                Select Case DT.Rows(0).Item("PRATE").ToString.Substring(POS, 1)
            '                                    Case "1"
            '                                        CPCODE = CPCODE & "L"
            '                                    Case "2"
            '                                        CPCODE = CPCODE & "O"
            '                                    Case "3"
            '                                        CPCODE = CPCODE & "T"
            '                                    Case "4"
            '                                        CPCODE = CPCODE & "U"
            '                                    Case "5"
            '                                        CPCODE = CPCODE & "S"
            '                                    Case "6"
            '                                        CPCODE = CPCODE & "D"
            '                                    Case "7"
            '                                        CPCODE = CPCODE & "A"
            '                                    Case "8"
            '                                        CPCODE = CPCODE & "I"
            '                                    Case "9"
            '                                        CPCODE = CPCODE & "R"
            '                                    Case "0"
            '                                        CPCODE = CPCODE & "Y"
            '                                End Select
            '                            Next

            '                            'HERE PARTYNAME IS NOT PRESENT SO IN CODE WE WILL NOT ADD PARTYCODE
            '                            CPCODE = CPCODE & Format(Val(AccFrom.Date.Day), "00") & Format(Val(AccFrom.Date.Month), "00") & AccFrom.Date.Year.ToString.Substring(2, 2)

            '                            oWrite.WriteLine("A380,157,2,4,1,1,N,""" & CPCODE & """")

            '                        Else
            '                            oWrite.WriteLine("A283,200,2,4,1,1,N,""")    'SALERATE
            '                            oWrite.WriteLine("A117,200,2,4,1,1,N,""")    'WHOLESALERATE
            '                            oWrite.WriteLine("A380,157,2,4,1,1,N,""")    'PURRATE
            '                        End If

            '                        oWrite.WriteLine("A380,200,2,4,1,1,N,""MRP""")
            '                        oWrite.WriteLine("A311,200,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A149,243,2,4,1,1,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MNARESH" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then Exit Sub
            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q799")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("KIZZQ0")
            '                        oWrite.WriteLine("KI9+0.0")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q400,25")
            '                        oWrite.WriteLine("Arglabel 500 31")
            '                        oWrite.WriteLine("exit")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A770,367,2,2,2,2,N,""ITEM""")
            '                        oWrite.WriteLine("B776,132,2,1,4,8,78,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A538,48,2,1,2,2,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A770,200,2,2,2,2,N,""WIDTH""")
            '                        oWrite.WriteLine("A651,367,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A651,200,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A625,367,2,2,2,2,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A625,200,2,2,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A289,214,2,3,3,3,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("A421,200,2,2,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("A318,200,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A770,256,2,2,2,2,N,""SHADE""")
            '                        oWrite.WriteLine("A651,256,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A625,256,2,2,2,2,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("A770,312,2,2,2,2,N,""D.NO""")
            '                        oWrite.WriteLine("A651,312,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A625,312,2,2,2,2,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MANINATH" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q812")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q406,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A772,386,2,4,2,2,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A772,310,2,3,2,2,N,""D.NO""")
            '                        oWrite.WriteLine("A772,243,2,3,2,2,N,""SHADE""")
            '                        oWrite.WriteLine("A772,174,2,3,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("B772,110,2,1,3,6,67,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A592,37,2,4,1,1,N,""" & ROW.Cells(GBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A367,174,2,3,2,2,N,""WIDTH""")
            '                        oWrite.WriteLine("A608,310,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A608,243,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A608,174,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A219,174,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A580,310,2,3,2,2,N,""" & ROW.Cells(GDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A580,243,2,3,2,2,N,""" & ROW.Cells(GCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("A580,174,2,3,2,2,N,""" & Format(Val(ROW.Cells(GMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If
            '                        oWrite.WriteLine("A184,174,2,3,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "DEVEN" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q609")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("KIZZQ0")
            '                        oWrite.WriteLine("KI9+0.0")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q426,25")
            '                        oWrite.WriteLine("Arglabel 533 31")
            '                        oWrite.WriteLine("exit")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A562,385,2,2,3,3,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A563,313,2,1,2,2,N,""LOT""")
            '                        oWrite.WriteLine("A456,313,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A433,313,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A202,313,2,1,2,2,N,""CMS""")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A105,313,2,1,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A133,313,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A563,259,2,1,2,2,N,""D NO""")
            '                        oWrite.WriteLine("A455,259,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A432,259,2,1,2,2,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A223,259,2,1,2,2,N,""S NO""")
            '                        oWrite.WriteLine("A104,259,2,1,2,2,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("A132,259,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A563,206,2,1,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("A455,206,2,1,2,2,N,"":""")
            '                        oWrite.WriteLine("A432,206,2,1,3,3,N,""" & ROW.Cells(GINMTRS.Index).Value & """")
            '                        oWrite.WriteLine("B583,142,2,1,3,6,89,N,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("A411,47,2,4,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "RSONS" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='38.2 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("q629")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("WN")
            '                        oWrite.WriteLine("D9")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q305,25")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='38.2 mm'></xpml>N")
            '                        oWrite.WriteLine("A618,234,2,4,1,1,N,""DESIGN""")
            '                        oWrite.WriteLine("B618,107,2,1,3,6,73,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A433,28,2,3,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A618,271,2,4,1,1,N,""QUALITY""")
            '                        oWrite.WriteLine("A334,234,2,4,1,1,N,""COLOR""")
            '                        oWrite.WriteLine("A618,159,2,4,1,1,N,""WIDTH""")
            '                        oWrite.WriteLine("A507,271,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A507,234,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A246,234,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A506,159,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A478,271,2,4,1,1,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A478,234,2,4,1,1,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A229,234,2,4,1,1,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A478,159,2,4,1,1,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A318,159,2,4,1,1,N,""MTRS""")
            '                        oWrite.WriteLine("A246,159,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A233,167,2,3,2,2,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("A618,197,2,4,1,1,N,""FABRIC""")
            '                        oWrite.WriteLine("A507,197,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A478,197,2,4,1,1,N,""" & ROW.Cells(GINQUALITY.Index).Value & """")
            '                        oWrite.WriteLine("A67,167,2,3,2,2,N,""" & ROW.Cells(GINBALENO.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SANGHVI" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q406")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q305,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A386,197,2,4,1,1,N,""COLOR""")
            '                        oWrite.WriteLine("A386,155,2,4,1,1,N,""MTRS""")
            '                        oWrite.WriteLine("A300,197,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A300,155,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A362,280,2,4,1,1,N,""TINU MINU EMBROIDERY""")
            '                        oWrite.WriteLine("A151,239,2,4,1,1,N,""WIDTH""")
            '                        oWrite.WriteLine("A277,197,2,4,1,1,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")
            '                        oWrite.WriteLine("A277,155,2,4,1,1,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A51,239,2,4,1,1,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A67,239,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("B390,112,2,1,2,4,63,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A313,43,2,4,1,1,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A386,239,2,4,1,1,N,""D.NO""")
            '                        oWrite.WriteLine("A300,239,2,4,1,1,N,"":""")
            '                        oWrite.WriteLine("A278,239,2,4,1,1,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A151,155,2,4,1,1,N,""" & ROW.Cells(GINBALENO.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MJFABRIC" Then

            '                        oWrite.WriteLine("I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q799")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q400,25")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A774,312,2,2,2,2,N,""QUALITY""")
            '                        oWrite.WriteLine("A774,365,2,2,2,2,N,""DESIGN""")
            '                        oWrite.WriteLine("A774,252,2,2,2,2,N,""SHADE""")
            '                        oWrite.WriteLine("A774,193,2,2,2,2,N,""WIDTH""")
            '                        oWrite.WriteLine("A355,193,2,2,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("B782,141,2,1,4,8,90,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A543,45,2,1,2,2,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A598,365,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A598,312,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A598,252,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A598,193,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A247,193,2,2,2,2,N,"":""")
            '                        oWrite.WriteLine("A558,365,2,2,2,2,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A558,314,2,2,2,2,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A558,254,2,2,2,2,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        End If

            '                        oWrite.WriteLine("A558,193,2,2,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A213,205,2,4,2,2,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "KDFAB" Then

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='101.6 mm'></xpml>I8,A")
            '                        oWrite.WriteLine("ZN")
            '                        oWrite.WriteLine("q792")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("KIZZQ0")
            '                        oWrite.WriteLine("KI9+0.0")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("Q812,25")
            '                        oWrite.WriteLine("Arglabel 1016 31")
            '                        oWrite.WriteLine("exit")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='101.6 mm'></xpml>N")
            '                        oWrite.WriteLine("B761,309,2,1,3,6,161,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A717,134,2,4,2,2,N,""" & ROW.Cells(GINBARCODE.Index).Value & """") 'BARCODE
            '                        oWrite.WriteLine("A754,563,2,3,2,2,N,""NAME""")
            '                        oWrite.WriteLine("A754,477,2,3,2,2,N,""D.NO""")
            '                        oWrite.WriteLine("A754,391,2,3,2,2,N,""MTRS""")
            '                        oWrite.WriteLine("A637,563,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A637,477,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A637,391,2,3,2,2,N,"":""")
            '                        oWrite.WriteLine("A606,563,2,3,2,2,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A606,477,2,3,2,2,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A595,400,2,2,4,4,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")

            '                        oWrite.WriteLine("A113,477,2,3,2,2,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A294,391,2,3,2,2,N,""" & ROW.Cells(GINBALENO.Index).Value & """")
            '                        oWrite.WriteLine("P1")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "BRILLANTO" Then

            '                        oWrite.WriteLine("I8,A,001")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("Q384,024")
            '                        oWrite.WriteLine("q863")
            '                        oWrite.WriteLine("rN")
            '                        oWrite.WriteLine("S3")
            '                        oWrite.WriteLine("D14")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("R253,0")
            '                        oWrite.WriteLine("f100")
            '                        oWrite.WriteLine("N")
            '                        oWrite.WriteLine("A341,164,2,3,1,1,N,""Grade""")
            '                        oWrite.WriteLine("A342,202,2,3,1,1,N,""Shade No.""")
            '                        oWrite.WriteLine("A344,238,2,3,1,1,N,""Width""")
            '                        oWrite.WriteLine("A344,274,2,3,1,1,N,""Mtrs""")
            '                        oWrite.WriteLine("A342,309,2,3,1,1,N,""M. Name""")
            '                        oWrite.WriteLine("A213,164,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,202,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,238,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,274,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,309,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A213,345,2,3,1,1,N,"":""")
            '                        oWrite.WriteLine("A198,164,2,3,1,1,N,""" & ROW.Cells(GINPIECETYPE.Index).Value & """")
            '                        oWrite.WriteLine("A198,202,2,3,1,1,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                        oWrite.WriteLine("A198,238,2,3,1,1,N,""" & TEMPWIDTH & """")
            '                        oWrite.WriteLine("A111,273,2,3,1,1,N,""" & ROW.Cells(GINUNIT.Index).Value & """")

            '                        oWrite.WriteLine("A198,274,2,3,1,1,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")
            '                        oWrite.WriteLine("A198,309,2,3,1,1,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")
            '                        oWrite.WriteLine("A198,345,2,3,1,1,N,""" & ROW.Cells(GINDESIGN.Index).Value & """")
            '                        oWrite.WriteLine("A342,345,2,3,1,1,N,""Design No""")
            '                        oWrite.WriteLine("B352,122,2,1,2,6,81,B,""" & ROW.Cells(GINBARCODE.Index).Value & """")

            '                        oWrite.WriteLine("P1")
            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "MIDAS" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("<xpml><page quantity='0' pitch='38.2 mm'></xpml>G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0500")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='38.2 mm'></xpml>L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C1401220034" & ROW.Cells(GINITEMNAME.Index).Value)
            '                        oWrite.WriteLine("1911A1001000012D. NO")
            '                        oWrite.WriteLine("1X1100001190011L226001")
            '                        oWrite.WriteLine("1911A1000800012SHADE")
            '                        oWrite.WriteLine("1911A1000600012MTRS")
            '                        oWrite.WriteLine("1e4203200240011B" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A0800100062" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911A1001000074:")
            '                        oWrite.WriteLine("1911A1000800074:")
            '                        oWrite.WriteLine("1911A1000600074:")
            '                        oWrite.WriteLine("1911A1001000086" & ROW.Cells(GINDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911A1000800086" & ROW.Cells(GINCOLOR.Index).Value)
            '                        oWrite.WriteLine("1911C1200590086" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911A1000600164PCS-" & Format(Val(ROW.Cells(GINQTY.Index).Value), "0"))
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")
            '                        oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "TCOT" Then

            '                        oWrite.WriteLine("G0")
            '                        oWrite.WriteLine("n")
            '                        oWrite.WriteLine("M0690")
            '                        oWrite.WriteLine("O0214")
            '                        oWrite.WriteLine("V0")
            '                        oWrite.WriteLine("t1")
            '                        oWrite.WriteLine("Kf0070")
            '                        oWrite.WriteLine("L")
            '                        oWrite.WriteLine("D11")
            '                        oWrite.WriteLine("ySPM")
            '                        oWrite.WriteLine("A2")
            '                        oWrite.WriteLine("1911C1202480037QLTY")
            '                        oWrite.WriteLine("1911C1202250037DSGN.NO")
            '                        oWrite.WriteLine("1911C1202040037CH.NO.")
            '                        oWrite.WriteLine("1911C1201820037SHD.NO.")
            '                        oWrite.WriteLine("1911C1201600037LOT NO")
            '                        oWrite.WriteLine("1911C1201380037WIDTH")
            '                        oWrite.WriteLine("1911C1201160037MTRS")
            '                        oWrite.WriteLine("1911C1200940037GRADE")
            '                        oWrite.WriteLine("1911C1200710037RACK")
            '                        oWrite.WriteLine("1911C1202480124:")
            '                        oWrite.WriteLine("1911C1202250124:")
            '                        oWrite.WriteLine("1911C1202040124:")
            '                        oWrite.WriteLine("1911C1201820124:")
            '                        oWrite.WriteLine("1911C1201600124:")
            '                        oWrite.WriteLine("1911C1200940124:")
            '                        oWrite.WriteLine("1911C1201160124:")
            '                        oWrite.WriteLine("1911C1201380124:")
            '                        oWrite.WriteLine("1911C1200710124:")
            '                        oWrite.WriteLine("1e6303300310036B" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1200110114" & ROW.Cells(GINBARCODE.Index).Value)
            '                        oWrite.WriteLine("1911C1202480138" & ROW.Cells(GINITEMNAME.Index).Value)
            '                        oWrite.WriteLine("1911C1202250138" & ROW.Cells(GINDESIGN.Index).Value)
            '                        oWrite.WriteLine("1911C1202040138" & ROW.Cells(GINBALENO.Index).Value)
            '                        oWrite.WriteLine("1911C1201820138" & ROW.Cells(GINCOLOR.Index).Value)
            '                        oWrite.WriteLine("1911C1201600138")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH As String = ""
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then TEMPWIDTH = DT.Rows(0).Item("WIDTH")


            '                        oWrite.WriteLine("1911C1201380138" & TEMPWIDTH)
            '                        oWrite.WriteLine("1911C1201160138" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00"))
            '                        oWrite.WriteLine("1911C1200710138" & ROW.Cells(GRACK.Index).Value)
            '                        oWrite.WriteLine("1911C1200940138" & ROW.Cells(GINPIECETYPE.Index).Value)
            '                        oWrite.WriteLine("Q0001")
            '                        oWrite.WriteLine("E")

            '                        oWrite.Dispose()

            '                    ElseIf ClientName = "SAFFRON" Then

            '                        If ROW.Cells(GINPIECETYPE.Index).Value <> "FRESH" Then GoTo NEXTLINE

            '                        oWrite.WriteLine("I8,A,001")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("")
            '                        oWrite.WriteLine("Q400,024")
            '                        oWrite.WriteLine("q831")
            '                        oWrite.WriteLine("rN")
            '                        oWrite.WriteLine("S5")
            '                        oWrite.WriteLine("D2")
            '                        oWrite.WriteLine("ZT")
            '                        oWrite.WriteLine("JF")
            '                        oWrite.WriteLine("O")
            '                        oWrite.WriteLine("R136,0")
            '                        oWrite.WriteLine("f100")
            '                        oWrite.WriteLine("N")

            '                        'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
            '                        Dim TEMPWIDTH, TEMPCONTAIN As String
            '                        Dim OBJCMN As New ClsCommon
            '                        Dim DT As DataTable = OBJCMN.search(" ISNULL(CATEGORYMASTER.category_remarks, '') AS WIDTH, ISNULL(ITEMMASTER.item_remarks, '') AS CONTAIN, ISNULL(ITEMMASTER.item_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(HSN_CODE,'') AS HSNCODE ", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID ", " AND ITEM_NAME = '" & ROW.Cells(GINITEMNAME.Index).Value & "' AND ITEM_YEARID = " & YearId)
            '                        If DT.Rows.Count > 0 Then
            '                            TEMPWIDTH = DT.Rows(0).Item("WIDTH")
            '                            TEMPCONTAIN = DT.Rows(0).Item("CONTAIN")
            '                        End If

            '                        oWrite.WriteLine("A419,146,0,1,3,3,N,""" & DT.Rows(0).Item("HSNCODE") & """")    'HSNCODE
            '                        oWrite.WriteLine("A151,154,0,1,2,2,N,""" & TEMPWIDTH & """")    'GIVE ITEM CATEGORY'S REMARKS
            '                        oWrite.WriteLine("A133,102,0,1,3,3,N,""" & Format(Val(ROW.Cells(GINMTRS.Index).Value), "0.00") & """")    'MTRS
            '                        oWrite.WriteLine("A459,104,0,1,3,3,N,""" & ROW.Cells(GINCOLOR.Index).Value & """")       'COLOR
            '                        oWrite.WriteLine("A8,6,0,1,3,3,N,""" & DT.Rows(0).Item("DISPLAYNAME") & """")       'QUALITY
            '                        oWrite.WriteLine("A171,199,0,1,2,2,N,""" & TEMPCONTAIN & """")        'ITEMREMARKS
            '                        oWrite.WriteLine("A231,57,0,1,3,3,N,""" & ROW.Cells(GINITEMNAME.Index).Value & """")      'ITEMNAME
            '                        oWrite.WriteLine("A11,200,0,1,2,2,N,""Contain:""")
            '                        oWrite.WriteLine("A318,154,0,1,2,2,N,""HSN :""")
            '                        oWrite.WriteLine("A318,111,0,1,2,2,N,""Shade :""")
            '                        oWrite.WriteLine("A11,153,0,1,2,2,N,""Width :""")
            '                        oWrite.WriteLine("A11,60,0,1,2,2,N,""Design No :""")
            '                        oWrite.WriteLine("A11,107,0,1,2,2,N,""Mtrs :""")
            '                        oWrite.WriteLine("B8,257,0,1,2,6,87,B,""" & ROW.Cells(GINBARCODE.Index).Value & """")       'BARCODE
            '                        oWrite.WriteLine("P1")

            '                        oWrite.Dispose()

            '                    End If

            '                    'Printing Barcode
            '                    Dim psi As New ProcessStartInfo()
            '                    psi.FileName = "cmd.exe"
            '                    psi.RedirectStandardInput = False
            '                    psi.RedirectStandardOutput = True
            '                    'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
            '                    psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
            '                    psi.UseShellExecute = False

            '                    Dim proc As Process
            '                    proc = Process.Start(psi)
            '                    dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
            '                    '// do something with result stream
            '                    proc.WaitForExit()
            '                    proc.Dispose()

            'NEXTLINE:
            '                    'THIS LINE IS WRITTEN TO DISPOSE THE BARCODE NOTEPAD OBJECT, WHEN CURSOR COMES DIRECTLY ON NEXTLINE CODE
            '                    oWrite.Dispose()
            '                Next
            '            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALOUTMTRS.Text = 0.0
            LBLTOTALOUTPCS.Text = 0.0
            LBLTOTALINMTRS.Text = 0.0
            LBLTOTALINPCS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALOUTPCS.Text = Format(Val(LBLTOTALOUTPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALOUTMTRS.Text = Format(Val(LBLTOTALOUTMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDSTOCKIN.Rows
                If ROW.Cells(GINSRNO.Index).Value <> Nothing Then
                    If ROW.Cells(GINCUT.Index).EditedFormattedValue > 0 Then ROW.Cells(GINMTRS.Index).Value = Val(ROW.Cells(GINPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GINCUT.Index).EditedFormattedValue)
                    LBLTOTALINPCS.Text = Format(Val(LBLTOTALINPCS.Text) + Val(ROW.Cells(GINPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALINMTRS.Text = Format(Val(LBLTOTALINMTRS.Text) + Val(ROW.Cells(GINMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTJO As New DataTable
            Dim OBJSELECTGDN As New SelectStockGDN
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTJO = OBJSELECTGDN.DT
            If DTJO.Rows.Count > 0 Then


                For Each DTROWPS As DataRow In DTJO.Rows

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    If DTROWPS("BARCODE") <> "" Then
                        For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                            If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
                        Next
                    End If

                    TXTLOTNO.Text = DTROWPS("LOTNO")

                    GRIDSTOCK.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), DTROWPS("COLOR"), Format(Val(DTROWPS("PCS")), "0.00"), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), DTROWPS("BARCODE"), DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("TYPE"))
                    If CHKCOPY.Checked = True Then GRIDSTOCKIN.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), "", "", "", DTROWPS("DESIGNNO"), DTROWPS("COLOR"), 0, Format(Val(DTROWPS("PCS")), "0.00"), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), "", "", "", 0, 0, 0)

LINE1:
                Next
                'CMDSELECTSTOCK.Enabled = False
                GETSRNO(GRIDSTOCK)
                GETSRNO(GRIDSTOCKIN)
                TOTAL()
            End If


            'CHANGES AS PER REQUOREMENT
            If ClientName = "AVIS" And GRIDSTOCK.RowCount > 0 Then
                CMBPIECETYPE.Text = GRIDSTOCK.Rows(0).Cells(GPIECETYPE.Index).Value
                cmbitemname.Text = GRIDSTOCK.Rows(0).Cells(GMERCHANT.Index).Value
                CMBQUALITY.Text = GRIDSTOCK.Rows(0).Cells(GQUALITY.Index).Value
                CMBDESIGN.Text = GRIDSTOCK.Rows(0).Cells(GDESIGN.Index).Value
                cmbcolor.Text = GRIDSTOCK.Rows(0).Cells(GCOLOR.Index).Value

                TXTMTRS.Text = Val(LBLTOTALOUTMTRS.Text.Trim)
                TXTGRIDDESC.Clear()
                For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                    If TXTGRIDDESC.Text = "" Then
                        TXTGRIDDESC.Text = "(" & Val(ROW.Cells(GMTRS.Index).Value)
                    Else
                        TXTGRIDDESC.Text = TXTGRIDDESC.Text & " + " & Val(ROW.Cells(GMTRS.Index).Value)
                    End If
                Next
                If TXTGRIDDESC.Text.Trim <> "" Then TXTGRIDDESC.Text = TXTGRIDDESC.Text & ")"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSTOCK.RowCount = 0
            GRIDSTOCKIN.RowCount = 0
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) - 1
            If TEMPRECONO > 0 Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO > 1 Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTRECONO.Text.Trim
            CLEAR()
            If Val(TXTRECONO.Text) - 1 >= TEMPRECONO Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO < MAXNO Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSTOCK.RowCount = 0
                GRIDSTOCKIN.RowCount = 0
                TEMPRECONO = Val(tstxtbillno.Text)
                If TEMPRECONO > 0 Then
                    EDIT = True
                    StockReco_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            GRIDSTOCKIN.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDSTOCKIN.Rows.Add(Val(txtsrno.Text.Trim), CMBPIECETYPE.Text.Trim, cmbitemname.Text.Trim, CMBQUALITY.Text.Trim, TXTBALENO.Text.Trim, TXTGRIDDESC.Text.Trim, TXTLOTNO.Text.Trim, CMBDESIGN.Text.Trim, cmbcolor.Text.Trim, Format(Val(TXTCUT.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBRACK.Text.Trim, CMBSHELF.Text.Trim, TXTINBARCODE.Text.Trim, 0, 0, 0)
                GETSRNO(GRIDSTOCKIN)

            ElseIf GRIDDOUBLECLICK = True Then

                If ClientName = "REAL" Then
                    Dim TEMPITEM As String = ""
                    Dim TEMPSHADE As String = ""
                    For I As Integer = TEMPROW + 1 To GRIDSTOCKIN.RowCount - 1
                        If I = GRIDSTOCKIN.CurrentRow.Index + 1 Then
                            TEMPITEM = GRIDSTOCKIN.Item(GINITEMNAME.Index, I - 1).Value
                            TEMPSHADE = GRIDSTOCKIN.Item(GINCOLOR.Index, I - 1).Value
                        End If
                        If GRIDSTOCKIN.Item(GINITEMNAME.Index, I).Value = TEMPITEM Then GRIDSTOCKIN.Item(GINITEMNAME.Index, I).Value = cmbitemname.Text.Trim
                        If cmbcolor.Text.Trim <> "" And GRIDSTOCKIN.Item(GINCOLOR.Index, I).Value = TEMPSHADE Then GRIDSTOCKIN.Item(GINCOLOR.Index, I).Value = cmbcolor.Text.Trim
                    Next
                End If


                GRIDSTOCKIN.Item(GINSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDSTOCKIN.Item(GINPIECETYPE.Index, TEMPROW).Value = CMBPIECETYPE.Text.Trim
                GRIDSTOCKIN.Item(GINITEMNAME.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDSTOCKIN.Item(GINQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDSTOCKIN.Item(GINBALENO.Index, TEMPROW).Value = TXTBALENO.Text.Trim
                GRIDSTOCKIN.Item(GINDESC.Index, TEMPROW).Value = TXTGRIDDESC.Text.Trim
                GRIDSTOCKIN.Item(GINLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
                GRIDSTOCKIN.Item(GINDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
                GRIDSTOCKIN.Item(GINCOLOR.Index, TEMPROW).Value = cmbcolor.Text.Trim
                GRIDSTOCKIN.Item(GINCUT.Index, TEMPROW).Value = Format(Val(TXTCUT.Text.Trim), "0.00")
                GRIDSTOCKIN.Item(GINPCS.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
                GRIDSTOCKIN.Item(GINUNIT.Index, TEMPROW).Value = cmbqtyunit.Text.Trim
                GRIDSTOCKIN.Item(GINMTRS.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
                GRIDSTOCKIN.Item(GRACK.Index, TEMPROW).Value = CMBRACK.Text.Trim
                GRIDSTOCKIN.Item(GSHELF.Index, TEMPROW).Value = CMBSHELF.Text.Trim



                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDSTOCKIN.FirstDisplayedScrollingRowIndex = GRIDSTOCKIN.RowCount - 1

            txtsrno.Text = GRIDSTOCKIN.RowCount + 1
            TXTBALENO.Clear()
            TXTGRIDDESC.Clear()
            If ClientName <> "AVIS" Then TXTLOTNO.Clear()
            TXTMTRS.Clear()

            CMBPIECETYPE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCKIN.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If GRIDSTOCKIN.CurrentRow.Index >= 0 And GRIDSTOCKIN.Item(GSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSTOCKIN.Item(GINSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBPIECETYPE.Text = GRIDSTOCKIN.Item(GINPIECETYPE.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDSTOCKIN.Item(GINITEMNAME.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDSTOCKIN.Item(GINQUALITY.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTBALENO.Text = GRIDSTOCKIN.Item(GINBALENO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTGRIDDESC.Text = GRIDSTOCKIN.Item(GINDESC.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDSTOCKIN.Item(GINLOTNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBDESIGN.Text = GRIDSTOCKIN.Item(GINDESIGN.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                cmbcolor.Text = GRIDSTOCKIN.Item(GINCOLOR.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTCUT.Text = GRIDSTOCKIN.Item(GINCUT.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDSTOCKIN.Item(GINPCS.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = GRIDSTOCKIN.Item(GINUNIT.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDSTOCKIN.Item(GINMTRS.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBRACK.Text = GRIDSTOCKIN.Item(GRACK.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDSTOCKIN.Item(GSHELF.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSTOCKIN.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBRACK.Enter
        Try
            If CMBRACK.Text.Trim = "" Then FILLRACK(CMBRACK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBRACK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBRACK.Validating
        Try
            If CMBRACK.Text.Trim <> "" Then RACKVALIDATE(CMBRACK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then FILLSHELF(CMBSHELF)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSHELF.Validated
        Try
            If CMBPIECETYPE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
                If ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" And Val(TXTMTRS.Text.Trim) = 0 Then Exit Sub
                If ClientName = "SBA" Or ClientName = "KARAN" Or (ClientName = "AXIS" And Val(TXTMTRS.Text.Trim) = 0) Then
                    Dim TEMPQTY As Integer = Val(txtqty.Text.Trim)
                    If Val(TXTNOOFENTRIES.Text.Trim) = 0 Then txtqty.Text = 1 Else txtqty.Text = Val(TXTNOOFENTRIES.Text.Trim)
                    If Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Val(TXTCUT.Text.Trim) * Val(txtqty.Text.Trim)
                    For I As Integer = 1 To Val(TEMPQTY)
                        If GRIDDOUBLECLICK = False Then
                            If EDIT = True Then
                                'GET LAST BARCODE SRNO
                                Dim LSRNO As Integer = 0
                                Dim RSRNO As Integer = 0
                                Dim SNO As Integer = 0
                                If GRIDSTOCKIN.RowCount > 0 Then
                                    LSRNO = InStr(GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                    RSRNO = InStr(LSRNO + 1, GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                    SNO = GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)
                                End If

                                TXTINBARCODE.Text = "A-" & Val(TXTRECONO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                            Else
                                TXTINBARCODE.Text = "A-" & Val(TXTRECONO.Text.Trim) & "/" & GRIDSTOCKIN.RowCount + 1 & "/" & YearId
                            End If
                        End If
                        FILLGRID()
                    Next
                Else
                    If GRIDDOUBLECLICK = False Then
                        If EDIT = True Then
                            'GET LAST BARCODE SRNO
                            Dim LSRNO As Integer = 0
                            Dim RSRNO As Integer = 0
                            Dim SNO As Integer = 0
                            If GRIDSTOCKIN.RowCount > 0 Then
                                LSRNO = InStr(GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                RSRNO = InStr(LSRNO + 1, GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value, "/")
                                SNO = GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).Cells(GINBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)
                            End If

                            TXTINBARCODE.Text = "A-" & Val(TXTRECONO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                        Else
                            TXTINBARCODE.Text = "A-" & Val(TXTRECONO.Text.Trim) & "/" & GRIDSTOCKIN.RowCount + 1 & "/" & YearId
                        End If
                    End If
                    FILLGRID()
                End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress, TXTNOOFENTRIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
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

        Private Sub GRIDSTOCK_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSTOCK.CellValidating
        Try
            Dim colNum As Integer = GRIDSTOCK.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GPCS.Index, GMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSTOCK.CurrentCell.Value = Nothing Then GRIDSTOCK.CurrentCell.Value = "0.00"
                        GRIDSTOCK.CurrentCell.Value = Convert.ToDecimal(GRIDSTOCK.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
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

    Private Sub GRIDSTOCK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCK.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                GETSRNO(GRIDSTOCK)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Stock Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                If lbllocked.Visible = True Then
                    MsgBox("Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                Dim ALPARAVAL As New ArrayList
                Dim OBSTOCK As New ClsStockAdjustment

                ALPARAVAL.Add(TEMPRECONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)
                OBSTOCK.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBSTOCK.DELETE()
                MsgBox("Stock Adjustment Deleted Succesfully")
                CLEAR()
                EDIT = False
                DTRECODATE.Focus()
                TEMPPROFORMANO = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.GotFocus
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCKIN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCKIN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSTOCKIN.Rows.RemoveAt(GRIDSTOCKIN.CurrentRow.Index)
                GETSRNO(GRIDSTOCKIN)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then FILLCOLOR(cmbcolor, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCUT.Validated, txtqty.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            If Val(txtqty.Text.Trim) > 0 And Val(TXTCUT.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
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

    Private Sub cmbPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBPIECETYPE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBPIECETYPE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJPieceType As New SelectPieceType
                OBJPieceType.ShowDialog()
                If OBJPieceType.TEMPNAME <> "" Then CMBPIECETYPE.Text = OBJPieceType.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQUALITY As New SelectQuality
                OBJQUALITY.ShowDialog()
                If OBJQUALITY.TEMPNAME <> "" Then CMBQUALITY.Text = OBJQUALITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJstock As New StockRecoDetails
            OBJstock.MdiParent = MDIMain
            OBJstock.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT()
                If GRIDSTOCKIN.RowCount > 0 Then PRINTBARCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJSA As New SaleOrderDesign
            OBJSA.MdiParent = MDIMain
            OBJSA.FORMULA = "{STOCKADJUSTMENT.SA_NO} = " & Val(TXTRECONO.Text.Trim) & " AND {STOCKADJUSTMENT.SA_YEARID} = " & YearId
            OBJSA.FRMSTRING = "STOCKRECO"
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockReco_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtqty.ReadOnly = False
        If ClientName = "MANALI" Then
            LBLCMPNAME.Visible = True
            CMBCMPNAME.Visible = True
            LBLCHNO.Visible = True
            TXTCHNO.Visible = True
        End If
    End Sub

    Private Sub TXTMTRS_Validated(sender As Object, e As EventArgs) Handles TXTMTRS.Validated
        Try
            If ClientName = "AVIS" Then Call CMBSHELF_Validated(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(sender As Object, e As EventArgs) Handles cmbitemname.Validated
        Try
            'GET CATEGORY
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable


                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                DT = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    Dim PCS As Double = 0
                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1

                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
                    If CHKCOPY.Checked = True Then GRIDSTOCKIN.Rows.Add(GRIDSTOCKIN.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), "", "", "", DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), 0, PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), "", "", "", 0, 0, 0)
                    TOTAL()
LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                    'Else
                    '    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
                    '    GoTo LINE1
                    '    Exit Sub


                    'CHANGES AS PER REQUOREMENT
                    If ClientName = "AVIS" Or ClientName = "RMANILAL" And GRIDSTOCK.RowCount > 0 Then
                        CMBPIECETYPE.Text = GRIDSTOCK.Rows(0).Cells(GPIECETYPE.Index).Value
                        cmbitemname.Text = GRIDSTOCK.Rows(0).Cells(GMERCHANT.Index).Value
                        CMBQUALITY.Text = GRIDSTOCK.Rows(0).Cells(GQUALITY.Index).Value
                        CMBDESIGN.Text = GRIDSTOCK.Rows(0).Cells(GDESIGN.Index).Value
                        cmbcolor.Text = GRIDSTOCK.Rows(0).Cells(GCOLOR.Index).Value

                        TXTMTRS.Text = Val(LBLTOTALOUTMTRS.Text.Trim)
                        TXTGRIDDESC.Clear()
                        For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                            If TXTGRIDDESC.Text = "" Then
                                TXTGRIDDESC.Text = "(" & Val(ROW.Cells(GMTRS.Index).Value)
                            Else
                                TXTGRIDDESC.Text = TXTGRIDDESC.Text & " + " & Val(ROW.Cells(GMTRS.Index).Value)
                            End If
                        Next
                        If TXTGRIDDESC.Text.Trim <> "" Then TXTGRIDDESC.Text = TXTGRIDDESC.Text & ")"
                    End If

                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validated(sender As Object, e As EventArgs) Handles CMBDESIGN.Validated
        Try
            'GET ITEMNAME AUTO
            If (ClientName = "AVIS" Or ClientName = "KRISHNA") And CMBDESIGN.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", " DESIGNMASTER LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEM_ID", " AND DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then cmbitemname.Text = DT.Rows(0).Item("ITEMNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCHNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTCHNO_Validated(sender As Object, e As EventArgs) Handles TXTCHNO.Validated
        Try
            If (ClientName = "MANALI") And CMBCMPNAME.Text.Trim <> "" And Val(TXTCHNO.Text.Trim) > 0 And EDIT = False Then
                'GET YEARID FROM SELECTED CMP 
                Dim TEMPYEARID As Integer = 0
                Dim TEMPCMPID As Integer = 0
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("YEAR_ID AS YEARID, YEAR_CMPID AS CMPID", "", "YEARMASTER INNER JOIN CMPMASTER ON YEAR_CMPID = CMP_ID", " AND CMP_NAME = '" & CMBCMPNAME.Text.Trim & "' AND YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "'")
                If DT.Rows.Count > 0 Then
                    TEMPYEARID = DT.Rows(0).Item("YEARID")
                    TEMPCMPID = DT.Rows(0).Item("CMPID")
                End If



                'NOW FETCH CHALLAN DATA
                Dim ALPARAVAL As New ArrayList
                Dim objclsGDN As New ClsStockAdjustment()
                Dim dttable As DataTable = objclsGDN.SELECTSTOCKADJUSTMENT(Val(TXTCHNO.Text.Trim), TEMPCMPID, Locationid, TEMPYEARID)
                If dttable.Rows.Count > 0 Then

                    If MsgBox("Fetch data from Entry No " & TXTCHNO.Text.Trim & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                    For Each dr As DataRow In dttable.Rows

                        'CHECKING WHETHER ITEM IS PRESENT IN CURRENT YEAR OR NOT, IF NOT PRESENT THEN ADD NEW ITEM
                        If dr("ITEMNAME") <> "" Then
                            DT = OBJCMN.search("ITEM_ID AS ITEMID", "", " ITEMMASTER ", " AND ITEM_NAME = '" & dr("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                            If DT.Rows.Count = 0 Then
                                'ADD NEW ITEMNAME 
                                ALPARAVAL.Clear()


                                ALPARAVAL.Add("Finished Goods")
                                ALPARAVAL.Add("")   'CATEGORY
                                ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'DISPLAYNAME
                                ALPARAVAL.Add(UCase(dr("ITEMNAME"))) 'ITEMNAME

                                ALPARAVAL.Add("")   'DEPARTMENT
                                ALPARAVAL.Add(UCase(dr("ITEMNAME")))        'CODE
                                ALPARAVAL.Add(dr("UNIT"))
                                ALPARAVAL.Add("")   'FOLD
                                ALPARAVAL.Add(0)    'RATE
                                ALPARAVAL.Add(0)    'VALUATIONRATE   
                                ALPARAVAL.Add(0)    'TRANSRATE
                                ALPARAVAL.Add(0)    'CHCKINGRATE
                                ALPARAVAL.Add(0)    'PACKINGRATE
                                ALPARAVAL.Add(0)    'DESIGNRATE
                                ALPARAVAL.Add(0)    'REORDER
                                ALPARAVAL.Add(0)    'UPPER
                                ALPARAVAL.Add(0)    'LOWER

                                Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_ID, 0) AS HSNCODEID", "", " HSNMASTER", " AND HSN_CODE = '" & dr("HSNCODE") & "' AND HSN_YEARID = " & YearId)
                                If DTHSN.Rows.Count > 0 Then ALPARAVAL.Add(dr("HSNCODE")) Else ALPARAVAL.Add(0) 'HSNCODEID

                                ALPARAVAL.Add(0)    'BLOCKED
                                ALPARAVAL.Add(0)    'HIDEINDESIGN

                                ALPARAVAL.Add("")    'WIDTH
                                ALPARAVAL.Add("")    'GREYWIDTH
                                ALPARAVAL.Add(0)    'SHRINKFROM
                                ALPARAVAL.Add(0)    'SHRINKTO
                                ALPARAVAL.Add("")   'SELVEDGE

                                ALPARAVAL.Add("")   'RATETYPE
                                ALPARAVAL.Add("")   'RATE

                                ALPARAVAL.Add("")   'YARNQUALITY
                                ALPARAVAL.Add("")   'PER


                                ALPARAVAL.Add("")   'GRIDSRNO
                                ALPARAVAL.Add("")   'PROCESS

                                ALPARAVAL.Add("")   'REMARKS
                                ALPARAVAL.Add("MERCHANT")

                                ALPARAVAL.Add(DBNull.Value)
                                ALPARAVAL.Add("")   'WARP
                                ALPARAVAL.Add("")   'WEFT

                                ALPARAVAL.Add(CmpId)
                                ALPARAVAL.Add(Locationid)
                                ALPARAVAL.Add(Userid)
                                ALPARAVAL.Add(YearId)
                                ALPARAVAL.Add(0)

                                ALPARAVAL.Add("")   'STORESRNO
                                ALPARAVAL.Add("")   'STOREITEMNAME
                                ALPARAVAL.Add("")   'STOREQTY


                                ALPARAVAL.Add("")   'NATCHSRNO
                                ALPARAVAL.Add("")   'NATCHING


                                ALPARAVAL.Add("")   'WARPSRNO
                                ALPARAVAL.Add("")   'WARPQUALITY
                                ALPARAVAL.Add("")   'WARPSHADE
                                ALPARAVAL.Add("")   'WARPENDS
                                ALPARAVAL.Add("")   'WARPWT
                                ALPARAVAL.Add("")   'WARPMATCHGRIDNO


                                ALPARAVAL.Add("")   'WEFTSRNO
                                ALPARAVAL.Add("")   'WEFTQUALITY
                                ALPARAVAL.Add("")   'WEFTSHADE
                                ALPARAVAL.Add("")   'WEFTPICK
                                ALPARAVAL.Add("")   'WEFTWT
                                ALPARAVAL.Add("")   'WEFTMATCHGRIDNO

                                ALPARAVAL.Add(0.00)   'totalbeamends
                                ALPARAVAL.Add(0.00)   'TOTTALBEAMWT

                                ALPARAVAL.Add("")   'BEAMSRNO
                                ALPARAVAL.Add("")   'BEAMNAME
                                ALPARAVAL.Add("")   'BEAMENS
                                ALPARAVAL.Add("")   'BEAMTL
                                ALPARAVAL.Add("")   'BEAMWT

                                ALPARAVAL.Add(0.00)   'TOTALPICKS
                                ALPARAVAL.Add(0.00)   'WEFTTL

                                Dim objclsItemMaster As New clsItemmaster
                                objclsItemMaster.alParaval = ALPARAVAL
                                Dim IntResult As Integer = objclsItemMaster.SAVE()

                            End If
                        End If


                        If dr("DESIGNNO") <> "" Then
                            dttable = OBJCMN.search("DESIGN_ID AS DESIGNID", "", "DESIGNMASTER", " AND DESIGN_NO = '" & dr("DESIGNNO") & "' AND DESIGN_YEARID = " & YearId)
                            If dttable.Rows.Count = 0 Then
                                'ADD NEW DESIGN
                                Dim OBJDESIGN As New ClsDesignMaster
                                OBJDESIGN.alParaval.Add(UCase(dr("DESIGNNO")))
                                OBJDESIGN.alParaval.Add("") 'MILLNAME
                                OBJDESIGN.alParaval.Add("") 'CADNO
                                OBJDESIGN.alParaval.Add(0)  'PURRATE
                                OBJDESIGN.alParaval.Add(0)  'SALERATE
                                OBJDESIGN.alParaval.Add(0)  'WRATE
                                OBJDESIGN.alParaval.Add("") 'REMARKS

                                OBJDESIGN.alParaval.Add(0)  'FABRIC
                                OBJDESIGN.alParaval.Add(0)  'DYEING
                                OBJDESIGN.alParaval.Add(0)  'JOBWORK
                                OBJDESIGN.alParaval.Add(0)  'FINISHING
                                OBJDESIGN.alParaval.Add(0)  'EXTRA
                                OBJDESIGN.alParaval.Add(0)  'TOTAL

                                OBJDESIGN.alParaval.Add("") 'ITEM
                                OBJDESIGN.alParaval.Add(0)  'BLOCKED

                                OBJDESIGN.alParaval.Add(CmpId)
                                OBJDESIGN.alParaval.Add(Locationid)
                                OBJDESIGN.alParaval.Add(Userid)
                                OBJDESIGN.alParaval.Add(YearId)
                                OBJDESIGN.alParaval.Add(0)

                                OBJDESIGN.alParaval.Add(DBNull.Value)

                                OBJDESIGN.alParaval.Add("") 'GRIDSRNO
                                OBJDESIGN.alParaval.Add("") 'BASE
                                OBJDESIGN.alParaval.Add("") 'PRINT
                                OBJDESIGN.alParaval.Add("") 'COLOR

                                Dim INTRESCAT As Integer = OBJDESIGN.SAVE()
                            End If
                        End If



                        'COLOR SAVE
                        If dr("COLOR") <> "" Then
                            dttable = OBJCMN.search("COLOR_ID AS COLORID", "", "COLORMASTER", " AND COLOR_NAME = '" & dr("COLOR") & "' AND COLOR_YEARID = " & YearId)
                            If dttable.Rows.Count = 0 Then
                                'ADD NEW DESIGN
                                Dim OBJCOLOR As New ClsColorMaster
                                OBJCOLOR.alParaval.Add(UCase(dr("COLOR")))
                                OBJCOLOR.alParaval.Add("")
                                OBJCOLOR.alParaval.Add(CmpId)
                                OBJCOLOR.alParaval.Add(Locationid)
                                OBJCOLOR.alParaval.Add(Userid)
                                OBJCOLOR.alParaval.Add(YearId)
                                OBJCOLOR.alParaval.Add(0)

                                Dim INTRESCAT As Integer = OBJCOLOR.save()
                            End If
                        End If



                        'QUALITY SAVE
                        If dr("QUALITY") <> "" Then
                            dttable = OBJCMN.search("QUALITY_ID AS QUALITYID", "", "QUALITYMASTER", " AND QUALITY_NAME = '" & dr("QUALITY") & "' AND QUALITY_YEARID = " & YearId)
                            If dttable.Rows.Count = 0 Then
                                'ADD NEW QUALITY
                                Dim OBJQUALITY As New ClsQualityMaster
                                OBJQUALITY.alParaval.Add(UCase(dr("QUALITY")))
                                OBJQUALITY.alParaval.Add("")  'PROCECSS
                                OBJQUALITY.alParaval.Add("")  'UNIT
                                OBJQUALITY.alParaval.Add("")  'ITEMNAME
                                OBJQUALITY.alParaval.Add(0) 'REED
                                OBJQUALITY.alParaval.Add(0)  'PIK
                                OBJQUALITY.alParaval.Add("")  'COUNT
                                OBJQUALITY.alParaval.Add(0)  'WIDTH
                                OBJQUALITY.alParaval.Add("") 'REMAKS

                                OBJQUALITY.alParaval.Add("") 'WARP
                                OBJQUALITY.alParaval.Add("") 'WEFT
                                OBJQUALITY.alParaval.Add("") 'SELVEDGE


                                OBJQUALITY.alParaval.Add(CmpId)
                                OBJQUALITY.alParaval.Add(Locationid)
                                OBJQUALITY.alParaval.Add(Userid)
                                OBJQUALITY.alParaval.Add(YearId)
                                OBJQUALITY.alParaval.Add(0)
                                Dim INTRESCAT As Integer = OBJQUALITY.save()
                            End If
                        End If

                        GRIDSTOCKIN.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("QUALITY"), "", "", "", dr("DESIGNNO"), dr("COLOR"), 0, Format(Val(dr("PCS")), "0"), dr("UNIT"), Format(Val(dr("MTRS")), "0.00"), "", "", "", 0, 0, 0)
                    Next
                    TOTAL()
                    GRIDSTOCKIN.FirstDisplayedScrollingRowIndex = GRIDSTOCKIN.RowCount - 1
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class