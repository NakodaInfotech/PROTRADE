
Imports BL
Imports System.Windows.Forms

Public Class SelectStockGDN

    Dim tempindex, i As Integer
    Dim SELECTIONFORMULA As String = ""
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public DT As New DataTable
    Public GODOWN As String = ""
    Public FILTER As String = ""
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStockGDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectStockGDN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100

        If ClientName = "INDRANI" Then LBLBALENO.Text = "SO No"


        Dim objclspreq As New ClsCommon()
        DT.Columns.Add("PIECETYPE")
        DT.Columns.Add("ITEMNAME")
        DT.Columns.Add("QUALITY")
        DT.Columns.Add("DESIGNNO")
        DT.Columns.Add("COLOR")
        DT.Columns.Add("GODOWN")
        DT.Columns.Add("JOBBERNAME")
        DT.Columns.Add("UNIT")
        DT.Columns.Add("PCS")
        DT.Columns.Add("CUT")
        DT.Columns.Add("MTRS")
        DT.Columns.Add("BARCODE")
        DT.Columns.Add("LOTNO")
        DT.Columns.Add("FROMNO")
        DT.Columns.Add("FROMSRNO")
        DT.Columns.Add("TYPE")
        DT.Columns.Add("BALENO")
        DT.Columns.Add("GRIDREMARKS")

        'FOR ALL CLIENTS
        FILLBARCODESTOCKPIECETYPE(CMBPIECETYPE)
        FILLLOTNO()
        FILLBALENO()
        FILLUNIT()
        CMBPIECETYPE.SelectedItem = Nothing
        CMBLOTNO.SelectedItem = Nothing

        'If ClientName = "SVS" Then
        '    LBLNEWQUALITY.Visible = True
        '    LBLNEWDESIGN.Visible = True
        '    LBLNEWSHADE.Visible = True

        '    CMBDESIGN.Visible = True
        '    CMBQUALITY.Visible = True
        '    CMBSHADE.Visible = True

        '    LBLQUALITY.Visible = False
        '    LBLDESIGN.Visible = False
        '    LBLSHADE.Visible = False

        '    chkQuality.Visible = False
        '    chkDesign.Visible = False
        '    CHKShade.Visible = False

        '    CLB_Quality.Visible = False
        '    CLB_Design.Visible = False
        '    CLB_Shade.Visible = False

        '    'Fill COMBOBOXES
        '    fillnewquality(CMBQUALITY)
        '    CMBQUALITY.SelectedItem = Nothing
        '    CMBDESIGN.SelectedItem = Nothing
        '    CMBSHADE.SelectedItem = Nothing
        '    CMBQUALITY.Focus()

        '    cmbselect.Visible = False
        '    chkall.Visible = False
        '    txtsearch.Visible = False
        '    CMDSEARCH.Visible = False
        '    lbl.Visible = False
        'Else
        '    fillcheckboxlist()
        '    cmbselect.SelectedIndex = (1)
        '    txtsearch.Focus()
        'End If

        fillcheckboxlist()
        cmbselect.SelectedIndex = (1)
        txtsearch.Focus()

        If ClientName = "AVIS" Then cmbselect.Text = "Design"

        If ClientName <> "SVS" Then
            CLB_Item.Visible = True
            LBLITEM.Visible = True
            CHKItem.Visible = True
        End If
        fillgrid("")
    End Sub

    Sub FILLBARCODESTOCKPIECETYPE(ByRef CMBPIECETYPE As ComboBox)
        Try
            If CMBPIECETYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" DISTINCT PIECETYPE ", "", " BARCODESTOCK ", " AND YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PIECETYPE"
                    CMBPIECETYPE.DataSource = dt
                    CMBPIECETYPE.DisplayMember = "PIECETYPE"
                    CMBPIECETYPE.Text = ""
                End If
                CMBPIECETYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLLOTNO()
        Try
            If CMBLOTNO.Text.Trim = "" Then
                Dim WHERECLAUSE As String = ""
                If GODOWN <> "" Then WHERECLAUSE = " AND GODOWN = '" & GODOWN & "' "
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT LOTNO ", "", " BARCODESTOCK ", WHERECLAUSE & " AND YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "LOTNO"
                    CMBLOTNO.DataSource = dt
                    CMBLOTNO.DisplayMember = "LOTNO"
                    CMBLOTNO.Text = ""
                End If
                CMBLOTNO.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLBALENO()
        Try
            If CMBBALENO.Text.Trim = "" Then
                Dim WHERECLAUSE As String = ""
                If GODOWN <> "" Then WHERECLAUSE = " AND GODOWN = '" & GODOWN & "' "
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT BALENO ", "", " BARCODESTOCK ", WHERECLAUSE & " AND YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "BALENO"
                    CMBBALENO.DataSource = dt
                    CMBBALENO.DisplayMember = "BALENO"
                    CMBBALENO.Text = ""
                End If
                CMBBALENO.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLUNIT()
        Try
            If CMBUNIT.Text.Trim = "" Then
                Dim WHERECLAUSE As String = ""
                If GODOWN <> "" Then WHERECLAUSE = " AND GODOWN = '" & GODOWN & "' "
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT UNIT ", "", " BARCODESTOCK ", WHERECLAUSE & " AND YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "UNIT"
                    CMBUNIT.DataSource = dt
                    CMBUNIT.DisplayMember = "UNIT"
                    CMBUNIT.Text = ""
                End If
                CMBUNIT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            If GODOWN <> "" And ALLOWBARCODEPRINT = True Then WHERE = WHERE & " AND GODOWN = '" & GODOWN & "'"
            If ClientName = "SHUBHI" Then WHERE = WHERE & " AND GODOWN = '" & GODOWN & "'"

            If Val(TXTCUT.Text.Trim) <> 0 Then WHERE = WHERE & " AND CUT = " & Val(TXTCUT.Text.Trim)
            If FILTER <> "" Then WHERE = WHERE & FILTER

            Dim OBJCMN As New ClsCommon()
            Dim DT As New DataTable
            If ClientName <> "SOFTAS" Then
                Dim DTUNIT As DataTable = OBJCMN.search("UNIT_ABBR", "", "DEFAULTSTOCKUNIT", "")
                If DTUNIT.Rows.Count > 0 Then WHERE = WHERE & " AND UNIT IN (SELECT UNIT_ABBR FROM DEFAULTSTOCKUNIT)"
            End If



            If ClientName = "SVS" Or ClientName = "CC" Or ClientName = "SHREEDEV" Then
                DT = OBJCMN.Execute_Any_String("SELECT ITEMNAME, QUALITY, DESIGNNO, COLOR, GODOWN, JOBBERNAME, UNIT, 1 AS PCS, CUT, MTRS, BARCODE, LOTNO, FROMNO, FROMSRNO, TYPE, PIECETYPE, BALENO, GRIDREMARKS FROM BARCODESTOCK WHERE ROUND(MTRS,0) > 0 " & WHERE & SELECTIONFORMULA & " AND YEARID = " & YearId, "", "")
            ElseIf ClientName = "MOHAN" Then
                DT = OBJCMN.Execute_Any_String("SELECT ITEMNAME, QUALITY, DESIGNNO, COLOR, GODOWN, JOBBERNAME, UNIT, 1 AS PCS, CUT, MTRS, BARCODE, LOTNO, FROMNO, FROMSRNO, TYPE, PIECETYPE, BALENO, GRIDREMARKS FROM BARCODESTOCK WHERE 1 = 1 " & WHERE & SELECTIONFORMULA & " AND YEARID = " & YearId, "", "")
                'WE HAVE ADDED FRMSTRING COZ IF WE DO NOT ADD THIS CLAUSE HERE THEN IT WILL NOT SHOW DESIGN AND QUALITY IN PACKINGSLIP AND JOBOUT 
                'WHEN WE CLICK ON SELECT STOCK (AS ALLOWPACKINGSLIP IS TRUE)
                'IN CHALLAN WE WILL PASS FRMSTRING = "" IF ALLOWPACKINGSLIP IS TRUE


            ElseIf ALLOWPACKINGSLIP = True And FRMSTRING = "" And ClientName <> "MARKIN" Then
                DT = OBJCMN.Execute_Any_String("SELECT ITEMNAME, '' AS QUALITY, '' AS DESIGNNO, '' AS COLOR,  GODOWN, JOBBERNAME, UNIT, SUM(PCS) AS PCS, CUT, SUM(MTRS) AS MTRS, BARCODE, LOTNO, FROMNO, FROMSRNO, TYPE, PIECETYPE, BALENO, GRIDREMARKS FROM BARCODESTOCK GROUP BY FROMNO, ITEMNAME, GODOWN, JOBBERNAME, UNIT, CUT, BARCODE, LOTNO, FROMSRNO, TYPE, PIECETYPE, BALENO, GRIDREMARKS, YEARID HAVING ROUND(SUM(MTRS),2) >0 " & WHERE & SELECTIONFORMULA & " AND YEARID = " & YearId, "", "")
            ElseIf ALLOWBARCODEPRINT = False And ClientName <> "DILIP" And ClientName <> "SAKARIA" And ClientName <> "BARKHA" And ClientName <> "SHUBHI" Then
                DT = OBJCMN.Execute_Any_String("SELECT ITEMNAME, QUALITY, DESIGNNO, COLOR, GODOWN, '' AS JOBBERNAME, '' AS UNIT, (SUM(PCS) - SUM(ISSPCS)) AS PCS, 0 AS CUT, (SUM(MTRS) - SUM(ISSMTRS)) AS MTRS, '' AS BARCODE, '' AS LOTNO, 0 AS FROMNO, 0 AS FROMSRNO, '' AS TYPE, PIECETYPE, '' AS BALENO, '' AS GRIDREMARKS FROM STOCKREGISTER WHERE YEARID = " & YearId & WHERE & "  GROUP BY ITEMNAME, QUALITY, DESIGNNO, COLOR, GODOWN, PIECETYPE", "", "")
            Else
                DT = OBJCMN.Execute_Any_String("Select ITEMNAME, QUALITY, DESIGNNO, Color, GODOWN, JOBBERNAME, UNIT, PCS, CUT, MTRS, BARCODE, LOTNO, FROMNO, FROMSRNO, Type, PIECETYPE, BALENO, GRIDREMARKS FROM BARCODESTOCK WHERE 1=1 " & WHERE & SELECTIONFORMULA & " And YEARID = " & YearId, "", "")
            End If
            gridwo.DataSource = DT
            If DT.Rows.Count > 0 Then

                If ADDCOL = False Then
                    gridwo.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                Dim I As Integer = 0
                gridwo.Columns(I).Width = 40 'CHECK BOK
                I = I + 1
                gridwo.Columns(I).Width = 200 'ITEMNAME
                I = I + 1
                gridwo.Columns(I).Width = 150 'QUALITY
                I = I + 1

                If ClientName = "SPCORP" Then gridwo.Columns(I).Width = 200 Else gridwo.Columns(I).Width = 100 'DESIGNNO
                gridwo.Columns(I).DefaultCellStyle.Font = New Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Point)
                I = I + 1
                gridwo.Columns(I).Width = 80 'SHADE
                I = I + 1
                gridwo.Columns(I).Width = 100 'GODOWN
                If ClientName = "KOCHAR" Then gridwo.Columns(I).Visible = False
                I = I + 1


                gridwo.Columns(I).Width = 150 'JOBBERNAME
                gridwo.Columns(I).Visible = False
                I = I + 1
                gridwo.Columns(I).Width = 60 'UNIT
                I = I + 1

                gridwo.Columns(I).Width = 60 'PCS
                gridwo.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridwo.Columns(I).DefaultCellStyle.Format = "N2"
                I = I + 1

                gridwo.Columns(I).Width = 60 'CUT
                gridwo.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridwo.Columns(I).DefaultCellStyle.Format = "N2"
                I = I + 1

                gridwo.Columns(I).Width = 80 'MTRS
                gridwo.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridwo.Columns(I).DefaultCellStyle.Format = "N2"
                gridwo.Columns(I).DefaultCellStyle.Font = New Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Point)
                I = I + 1

                gridwo.Columns(I).Width = 80 'BARCODE
                I = I + 1
                gridwo.Columns(I).Width = 70 'LOTNO
                I = I + 1
                gridwo.Columns(I).Visible = False 'FROMNO
                I = I + 1
                gridwo.Columns(I).Visible = False 'FROMSRNO
                I = I + 1
                gridwo.Columns(I).Width = 60 'TYPE
                I = I + 1
                gridwo.Columns(I).Width = 70 'PIECETYPE
                I = I + 1

                gridwo.Columns(I).Width = 80 'BALENO
                If ClientName = "INDRANI" Then gridwo.Columns(I).HeaderText = "SO No"
                I = I + 1


                gridwo.Columns(I).Width = 80 'GRIDREMARKS
                I = I + 1

                gridwo.FirstDisplayedScrollingRowIndex = gridwo.RowCount - 1
            End If
            chkall.CheckState = CheckState.Unchecked
            LBLTOTALPCS.Text = 0
            LBLTOTALMTRS.Text = 0.00
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        Dim rowno, b As Integer
        Dim obj As New CheckedListBox
        rowno = 0

        If txtsearch.Text.Trim <> "" Then
            If cmbselect.Text = "Quality" Then
                obj = CLB_Quality
            ElseIf cmbselect.Text = "Design" Then
                obj = CLB_Design
            ElseIf cmbselect.Text = "Shade" Then
                obj = CLB_Shade
            ElseIf cmbselect.Text = "Item" Then
                obj = CLB_Item
            End If

            For b = 1 To obj.Items.Count

                txttempname.Text = obj.Items(rowno)
                txttempname.SelectionStart = 0
                txttempname.SelectionLength = txtsearch.TextLength
                If LCase(txtsearch.Text.Trim) = LCase(txttempname.SelectedText.Trim) Then
                    obj.SelectedIndex = rowno
                    obj.Focus()
                Else
                    rowno = rowno + 1
                End If
            Next
        End If
    End Sub

    Private Sub gridWO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridwo.CellClick
        If e.RowIndex >= 0 Then
            With gridwo.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    .Value = True
                End If
                TOTAL()
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            For Each ROW As DataGridViewRow In gridwo.Rows
                If ROW.Cells(0).Value = True Then
                    Dim DTROW() As DataRow = DT.Select("BARCODE='" & ROW.Cells(10).Value & "'")
                    If DTROW.Length = 0 Then
                        DT.Rows.Add(ROW.Cells(16).Value, ROW.Cells(1).Value, ROW.Cells(2).Value, ROW.Cells(3).Value, ROW.Cells(4).Value, ROW.Cells(5).Value, ROW.Cells(6).Value, ROW.Cells(7).Value, ROW.Cells(8).Value, ROW.Cells(9).Value, ROW.Cells(10).Value, ROW.Cells(11).Value, ROW.Cells(12).Value, ROW.Cells(13).Value, ROW.Cells(14).Value, ROW.Cells(15).Value, ROW.Cells(17).Value, ROW.Cells(18).Value)
                    End If
                End If
            Next

            'Dim tempmsg As Integer = MsgBox("Wish To Continue?", MsgBoxStyle.YesNo)
            'If tempmsg = vbYes Then
            '    fillgrid("")
            'Else
            '    Me.Close()
            'End If

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub CMDSEARCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSEARCH.Click
        Dim WHERE As String = ""

        '***************search for QUALITY ****************

        Dim checked_QUALITY As CheckedListBox.CheckedItemCollection = CLB_Quality.CheckedItems
        Dim QUALITY As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_QUALITY
            If QUALITY = "" Then
                QUALITY = "'" & item.ToString() & "'"
            Else
                QUALITY = QUALITY & ",'" & item.ToString() & "'"
            End If
        Next item

        If QUALITY <> "" Then
            WHERE = WHERE & " and QUALITY IN (" & QUALITY & ")"
        End If
        '*********end of current Block ********

        '***************search for ITEM ****************

        Dim checked_ITEM As CheckedListBox.CheckedItemCollection = CLB_Item.CheckedItems
        Dim ITEMNAME As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_ITEM
            If ITEMNAME = "" Then
                ITEMNAME = "'" & item.ToString() & "'"
            Else
                ITEMNAME = ITEMNAME & ",'" & item.ToString() & "'"
            End If
        Next item

        If ITEMNAME <> "" Then
            WHERE = WHERE & " and ITEMNAME IN (" & ITEMNAME & ")"
        End If
        '*********end of current Block ********


        '***************search for DESIGN NO ****************
        Dim checked_DESIGN As CheckedListBox.CheckedItemCollection = CLB_Design.CheckedItems
        Dim DESIGN As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_DESIGN
            If DESIGN = "" Then
                DESIGN = "'" & item.ToString() & "'"
            Else
                DESIGN = DESIGN & ",'" & item.ToString() & "'"
            End If
        Next item
        If DESIGN <> "" Then WHERE = WHERE & " and DESIGNNO IN (" & DESIGN & ")"
        '*********end of current Block ********


        '***************search for SHADE ****************
        Dim checked_SHADE As CheckedListBox.CheckedItemCollection = CLB_Shade.CheckedItems
        Dim SHADE As String = "" '"     Selected Students:" & vbCrLf
        For Each item As Object In checked_SHADE
            If SHADE = "" Then
                SHADE = "'" & item.ToString() & "'"
            Else
                SHADE = SHADE & ",'" & item.ToString() & "'"
            End If
        Next item
        If SHADE <> "" Then WHERE = WHERE & " and COLOR IN (" & SHADE & ")"
        '*********end of current Block ********

        If CMBPIECETYPE.Text.Trim <> "" Then WHERE = WHERE & " and PIECETYPE = '" & CMBPIECETYPE.Text.Trim & "'"
        If CMBLOTNO.Text.Trim <> "" Then WHERE = WHERE & " and LOTNO = '" & CMBLOTNO.Text.Trim & "'"
        If CMBBALENO.Text.Trim <> "" Then WHERE = WHERE & " and BALENO = '" & CMBBALENO.Text.Trim & "'"
        If CMBUNIT.Text.Trim <> "" Then WHERE = WHERE & " and UNIT = '" & CMBUNIT.Text.Trim & "'"
        If TXTBARCODE.Text.Trim <> "" Then WHERE = WHERE & " and BARCODE = '" & TXTBARCODE.Text.Trim & "'"

        fillgrid(WHERE)
        chkall.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEARSEARCH.Click
        If ClientName = "SVS" Then
            CMBQUALITY.SelectedItem = Nothing
            CMBDESIGN.DataSource = Nothing
            CMBSHADE.DataSource = Nothing
            CMBQUALITY.Focus()
        Else
            fillcheckboxlist()
        End If
        chkall.CheckState = CheckState.Unchecked
        LBLTOTALPCS.Text = 0
        LBLTOTALMTRS.Text = 0.00
        CMBBALENO.Text = ""
        CMBLOTNO.Text = ""
        txtsearch.Clear()
        TXTBARCODE.Clear()
        fillgrid("")
    End Sub

    Sub fillcheckboxlist()
        Dim dt As DataTable
        Dim objclscomm As New ClsCommon()

        'Fill QUALITY
        dt = objclscomm.Execute_Any_String("SELECT DISTINCT QUALITY_NAME FROM QUALITYMASTER ", " ", " WHERE QUALITYMASTER.QUALITY_Yearid=" & YearId & " ORDER BY QUALITYMASTER.QUALITY_NAME ")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_Quality.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If

        'Fill ITEMNAME
        dt = objclscomm.Execute_Any_String("SELECT DISTINCT ITEM_NAME FROM ITEMMASTER ", " ", " WHERE ITEMMASTER.ITEM_Yearid=" & YearId & " ORDER BY ITEMMASTER.ITEM_NAME ")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_Item.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If

        'Fill DESIGN
        dt = objclscomm.Execute_Any_String(" SELECT DISTINCT DESIGN_NO FROM DESIGNMASTER ", " ", " WHERE DESIGNMASTER.DESIGN_yearid = " & YearId & " ORDER BY DESIGNMASTER.DESIGN_NO")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_Design.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If

        'Fill COLOR
        dt = objclscomm.Execute_Any_String("SELECT DISTINCT COLOR_NAME FROM COLORMASTER", " ", " WHERE COLORMASTER.COLOR_Yearid=" & YearId & " ORDER BY COLORMASTER.COLOR_NAME")
        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                CLB_Shade.Items.Add(Convert.ToString(dr(0)), False)
            Next
        End If

    End Sub

    Private Sub chkall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkall.CheckedChanged
        Try
            Dim N As String = ""
            Dim M As String = ""

            Dim tempindex As Integer
            Dim i As Integer
            Dim USERROWS As Integer = gridwo.RowCount - 1
            If Val(TXTPCS.Text.Trim) > 0 AndAlso gridwo.RowCount >= Val(TXTPCS.Text.Trim) Then USERROWS = Val(TXTPCS.Text.Trim)


            If gridwo.RowCount > 0 Then
                If chkall.Checked = True Then
                    For i = 0 To USERROWS
                        With gridwo.Rows(i).Cells(0)
                            .Value = True
                        End With
                    Next
                Else
                    For i = 0 To USERROWS
                        With gridwo.Rows(i).Cells(0)
                            .Value = False
                        End With
                    Next
                End If
            End If
            TOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.00
            LBLTOTALPCS.Text = 0
            For Each ROW As DataGridViewRow In gridwo.Rows
                If Convert.ToBoolean(ROW.Cells(0).Value) = True Then
                    LBLTOTALMTRS.Text = Val(LBLTOTALMTRS.Text.Trim) + Val(ROW.Cells("MTRS").Value)
                    LBLTOTALPCS.Text = Val(LBLTOTALPCS.Text.Trim) + Val(ROW.Cells("PCS").Value)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkDesign_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesign.CheckedChanged
        If chkDesign.Checked = True Then
            For i As Integer = 0 To CLB_Design.Items.Count - 1
                CLB_Design.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_Design.Items.Count - 1
                CLB_Design.SetItemChecked(i, False)
            Next
        End If

    End Sub

    Sub FILLCLBCOLOR()
        Try
            Dim checked_DESIGN As CheckedListBox.CheckedItemCollection = CLB_Design.CheckedItems
            Dim DESIGN As String = "" '"     Selected Students:" & vbCrLf
            Dim WHERE As String = ""
            For Each item As Object In checked_DESIGN
                If DESIGN = "" Then
                    DESIGN = "'" & item.ToString() & "'"
                Else
                    DESIGN = DESIGN & ",'" & item.ToString() & "'"
                End If
            Next item
            If DESIGN <> "" Then WHERE = WHERE & " and ISNULL(DESIGNMASTER.DESIGN_NO,'') IN (" & DESIGN & ")"


            'Fill COLOR
            CLB_Shade.Items.Clear()
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT DISTINCT COLOR_NAME FROM DESIGNMASTER INNER JOIN DESIGNMASTER_COLOR ON DESIGNMASTER.DESIGN_id = DESIGNMASTER_COLOR.DESIGN_ID RIGHT OUTER JOIN COLORMASTER ON DESIGNMASTER_COLOR.DESIGN_COLORID = COLORMASTER.COLOR_id WHERE COLOR_yearid = " & YearId & WHERE & " ORDER BY COLORMASTER.COLOR_NAME", "", "")
            If DT.Rows.Count > 0 Then
                For Each dr As DataRow In DT.Rows
                    CLB_Shade.Items.Add(Convert.ToString(dr(0)), False)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkQuality_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQuality.CheckedChanged
        If chkQuality.Checked = True Then
            For i As Integer = 0 To CLB_Quality.Items.Count - 1
                CLB_Quality.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_Quality.Items.Count - 1
                CLB_Quality.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub CHKShade_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKShade.CheckedChanged
        If CHKShade.Checked = True Then
            For i As Integer = 0 To CLB_Shade.Items.Count - 1
                CLB_Shade.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_Shade.Items.Count - 1
                CLB_Shade.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Sub fillnewquality(ByRef CMBQUALITY As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim DT As DataTable = objclscommon.search(" DISTINCT QUALITY ", "", " BARCODESTOCK", " AND ROUND(MTRS,0) > 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "QUALITY"
                CMBQUALITY.DataSource = DT
                CMBQUALITY.DisplayMember = "QUALITY"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLNEWPIECETYPE(ByRef CMBQUALITY As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim DT As DataTable = objclscommon.search(" DISTINCT QUALITY ", "", " BARCODESTOCK", " AND ROUND(MTRS,0) > 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "QUALITY"
                CMBQUALITY.DataSource = DT
                CMBQUALITY.DisplayMember = "QUALITY"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillnewItem(ByRef CMBITEMNAME As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim DT As DataTable = objclscommon.search(" DISTINCT ITEM ", "", " BARCODESTOCK", " AND ROUND(MTRS,0) > 0 AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "ITEM"
                CMBITEMNAME.DataSource = DT
                CMBITEMNAME.DisplayMember = "ITEM"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillnewdesignno(ByRef CMBDESIGN As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim DT As DataTable = objclscommon.search(" DISTINCT DESIGNNO ", "", " BARCODESTOCK", " AND ROUND(MTRS,0) > 0 AND QUALITY = '" & CMBQUALITY.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "DESIGNNO"
                CMBDESIGN.DataSource = DT
                CMBDESIGN.DisplayMember = "DESIGNNO"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillnewCOLOR(ByRef CMBSHADE As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim DT As DataTable = objclscommon.search(" DISTINCT COLOR ", "", " BARCODESTOCK", " AND ROUND(MTRS,0) > 0 AND QUALITY = '" & CMBQUALITY.Text.Trim & "' AND DESIGNNO = '" & CMBDESIGN.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "COLOR"
                CMBSHADE.DataSource = DT
                CMBSHADE.DisplayMember = "COLOR"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try

            If CMBQUALITY.Text.Trim <> "" Then
                fillnewdesignno(CMBDESIGN)
                CMBDESIGN.SelectedItem = Nothing
                CMBDESIGN.Focus()
                fillgrid(" AND QUALITY = '" & CMBQUALITY.Text.Trim & "'")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then
                fillnewCOLOR(CMBSHADE)
                CMBSHADE.SelectedItem = Nothing
                CMBSHADE.Focus()
                fillgrid(" AND QUALITY = '" & CMBQUALITY.Text.Trim & "' AND DESIGNNO = '" & CMBDESIGN.Text.Trim & "'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then fillgrid(" AND QUALITY = '" & CMBQUALITY.Text.Trim & "' AND DESIGNNO = '" & CMBDESIGN.Text.Trim & "' AND COLOR = '" & CMBSHADE.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKItem.CheckedChanged
        If CHKItem.Checked = True Then
            For i As Integer = 0 To CLB_Item.Items.Count - 1
                CLB_Item.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CLB_Item.Items.Count - 1
                CLB_Item.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub CLB_Design_Click(sender As Object, e As EventArgs) Handles CLB_Design.Click
        Try
            If ClientName = "AVIS" Then FILLCLBCOLOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CLB_Design_SelectedValueChanged(sender As Object, e As EventArgs) Handles CLB_Design.SelectedValueChanged
        Try
            If ClientName = "AVIS" Then FILLCLBCOLOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCUT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim <> "" Then CMDSEARCH_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class