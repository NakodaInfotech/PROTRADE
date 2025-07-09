
Imports BL

Public Class StockFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Dim edit As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
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
            Dim WHERECLAUSE As String = ""
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            Dim OBJCMN As New ClsCommon
            Dim DTUNIT As DataTable = OBJCMN.search(" CASE WHEN ISNULL(DEFAULTSTOCKUNIT.UNIT_ABBR,'') = '' THEN  CAST (0 AS BIT) ELSE  CAST (1 AS BIT) END AS CHK, UNITMASTER.UNIT_ABBR AS UNIT ", " ", " UNITMASTER LEFT OUTER JOIN DEFAULTSTOCKUNIT ON UNITMASTER.UNIT_ABBR = DEFAULTSTOCKUNIT.UNIT_ABBR ", " AND UNITMASTER.UNIT_YEARID = '" & YearId & "' ORDER BY UNITMASTER.UNIT_ABBR")
            gridbilldetailsunit.DataSource = DTUNIT
            If DTUNIT.Rows.Count > 0 Then
                gridbillunit.FocusedRowHandle = gridbillunit.RowCount - 1
                gridbillunit.TopRowIndex = gridbillunit.RowCount - 15
            End If

            Dim DTREG As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, REGISTER_NAME AS REGNAME ", " ", " REGISTERMASTER", " AND REGISTER_TYPE = 'PURCHASE' AND REGISTER_YEARID = '" & YearId & "' ORDER BY REGISTER_NAME")
            gridbilldetailsregister.DataSource = DTREG

            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            If CHKALLCMP.Checked = False Then WHERECLAUSE = " AND ITEMMASTER.ITEM_YEARID = " & YearId
            Dim DTITEM As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME ", " ", " ITEMMASTER ", WHERECLAUSE & " ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDITEMDETAILS.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDITEM.FocusedRowHandle = GRIDITEM.RowCount - 1
                GRIDITEM.TopRowIndex = GRIDITEM.RowCount - 15
            End If

            If CHKALLCMP.Checked = False Then WHERECLAUSE = " AND DESIGNMASTER.DESIGN_YEARID = " & YearId
            Dim DTDESIGN As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, DESIGNMASTER.DESIGN_NO AS DESIGNNO ", " ", " DESIGNMASTER ", WHERECLAUSE & " ORDER BY DESIGNMASTER.DESIGN_NO")
            GRIDDESIGNDETAILS.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                GRIDDESIGN.FocusedRowHandle = GRIDDESIGN.RowCount - 1
                GRIDDESIGN.TopRowIndex = GRIDDESIGN.RowCount - 15
            End If

            If CHKALLCMP.Checked = False Then WHERECLAUSE = " AND COLORMASTER.COLOR_YEARID = " & YearId
            Dim DTSHADE As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS SHADE", " ", " COLORMASTER ", WHERECLAUSE & " ORDER BY COLORMASTER.COLOR_NAME")
            GRIDSHADEDETAILS.DataSource = DTSHADE
            If DTSHADE.Rows.Count > 0 Then
                GRIDSHADE.FocusedRowHandle = GRIDSHADE.RowCount - 1
                GRIDSHADE.TopRowIndex = GRIDSHADE.RowCount - 15
            End If

            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
            ' If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            'IF PRINTBARCODE IS TRUE THEN OPENGRID STOCK REPORTS OR ELSE OPEN CRYSTAL REPORTS
            Dim UNITCLAUSE As String = ""
            Dim NAMECLAUSE As String = ""
            Dim ITEMCLAUSE As String = ""
            Dim DESIGNCLAUSE As String = ""
            Dim SHADECLAUSE As String = ""


            Dim OBJCMN As New ClsCommon


            If ALLOWBARCODEPRINT = True And (RBITEMWISEBARCODESTOCK.Checked = True Or RBDESIGNSUMM.Checked = True Or RBQUALITYSUMM.Checked = True Or RBSHADESUMM.Checked = True Or RDBBARCODESTOCKSUMM.Checked = True) Then


                'IF CHK IS TRUE THEN GET ALL YEARID UDER THAT COMPANY
                Dim WHERECLAUSE As String = ""
                If CHKALLCMP.Checked = True Then WHERECLAUSE = WHERECLAUSE & " And BARCODESTOCK.YEARID IN (SELECT YEAR_ID FROM YEARMASTER WHERE YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "')" Else WHERECLAUSE = WHERECLAUSE & " AND BARCODESTOCK.YEARID=" & YearId


                'FOR UNIT
                gridbillunit.ClearColumnsFilter()
                For i As Integer = 0 To gridbillunit.RowCount - 1
                    Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If UNITCLAUSE = "" Then
                            UNITCLAUSE = " And (BARCODESTOCK.UNIT = '" & dtrow("UNIT") & "'"
                        Else
                            UNITCLAUSE = UNITCLAUSE & " OR BARCODESTOCK.UNIT = '" & dtrow("UNIT") & "'"
                        End If
                    End If
                Next
                If UNITCLAUSE <> "" Then
                    UNITCLAUSE = UNITCLAUSE & ")"
                    WHERECLAUSE = WHERECLAUSE & UNITCLAUSE
                End If

                'FOR PARTYNAME
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND (NAME = '" & dtrow("NAME") & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " OR NAME = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    WHERECLAUSE = WHERECLAUSE & NAMECLAUSE
                End If


                'FOR ITEMNAME
                GRIDITEM.ClearColumnsFilter()
                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND (ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    WHERECLAUSE = WHERECLAUSE & ITEMCLAUSE
                End If

                'FOR DESIGN
                GRIDDESIGN.ClearColumnsFilter()
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNCLAUSE = "" Then
                            DESIGNCLAUSE = " AND (DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        Else
                            DESIGNCLAUSE = DESIGNCLAUSE & " OR DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        End If
                    End If
                Next
                If DESIGNCLAUSE <> "" Then
                    DESIGNCLAUSE = DESIGNCLAUSE & ")"
                    WHERECLAUSE = WHERECLAUSE & DESIGNCLAUSE
                End If

                'FOR SHADE
                GRIDSHADE.ClearColumnsFilter()
                For i As Integer = 0 To GRIDSHADE.RowCount - 1
                    Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If SHADECLAUSE = "" Then
                            SHADECLAUSE = " AND (COLOR = '" & dtrow("SHADE") & "'"
                        Else
                            SHADECLAUSE = SHADECLAUSE & " OR COLOR = '" & dtrow("SHADE") & "'"
                        End If
                    End If
                Next
                If SHADECLAUSE <> "" Then
                    SHADECLAUSE = SHADECLAUSE & ")"
                    WHERECLAUSE = WHERECLAUSE & SHADECLAUSE
                End If

                If CMBGODOWN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.GODOWN='" & CMBGODOWN.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
                If CMBQUALITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.QUALITY='" & CMBQUALITY.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.DESIGNNO='" & CMBDESIGN.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.COLOR='" & CMBSHADE.Text.Trim & "'"
                If CMBPIECETYPE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.PIECETYPE='" & CMBPIECETYPE.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.CATEGORY='" & CMBCATEGORY.Text.Trim & "'"


                If RBITEMWISEBARCODESTOCK.Checked = True Then
                    Dim OBJITEM As New ItemWiseStock
                    OBJITEM.MdiParent = MDIMain
                    OBJITEM.WHERECLAUSE = WHERECLAUSE
                    OBJITEM.Show()
                ElseIf RBQUALITYSUMM.Checked = True Then
                    Dim OBJQUALITY As New QualityWiseStock
                    OBJQUALITY.MdiParent = MDIMain
                    OBJQUALITY.WHERECLAUSE = WHERECLAUSE
                    OBJQUALITY.Show()
                ElseIf RBDESIGNSUMM.Checked = True Then
                    Dim OBJDESIGN As New DesignwiseStock
                    OBJDESIGN.MdiParent = MDIMain
                    OBJDESIGN.WHERECLAUSE = WHERECLAUSE
                    OBJDESIGN.Show()
                ElseIf RBSHADESUMM.Checked = True Then
                    Dim OBJSHADE As New ColorwiseStock
                    OBJSHADE.MdiParent = MDIMain
                    OBJSHADE.WHERECLAUSE = WHERECLAUSE
                    OBJSHADE.Show()
                ElseIf RDBBARCODESTOCKSUMM.Checked = True Then
                    Dim OBJSHADE As New StockOnHandSummary
                    OBJSHADE.MdiParent = MDIMain
                    OBJSHADE.WHERECLAUSE = WHERECLAUSE
                    OBJSHADE.Show()
                End If

                Exit Sub
            End If


            'ORDER AGAINST STOCK REPORT
            If RBORDERVSSTOCK.Checked = True Or RBSTOCKVSORDER.Checked = True Or RBREORDER.Checked = True Then

                Dim OBJREP As New SaleOrderVsStockGridReport
                OBJREP.MdiParent = MDIMain
                If RBORDERVSSTOCK.Checked = True Then
                    OBJREP.FRMSTRING = "ORDERVSSTOCK"
                ElseIf RBREORDER.Checked = True Then
                    OBJREP.FRMSTRING = "REORDER"
                Else
                    OBJREP.FRMSTRING = "STOCKVSORDER"
                End If

                Dim COLORCLAUSE As String = ""
                Dim BARCODEITEMCLAUSE As String = ""
                Dim BARCODEDESIGNCLAUSE As String = ""
                Dim BARCODECOLORCLAUSE As String = ""


                OBJREP.SOCLAUSE = " AND ALLSALEORDER_DESC.SO_CLOSED = 'FALSE' "

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
                    OBJREP.SOCLAUSE = OBJREP.SOCLAUSE & NAMECLAUSE
                End If


                'FOR ITEMNAME
                GRIDITEM.ClearColumnsFilter()
                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND (ITEMMASTER.ITEM_NAME = '" & dtrow("ITEMNAME") & "'"
                            BARCODEITEMCLAUSE = " AND (J.ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR ITEMMASTER.ITEM_NAME = '" & dtrow("ITEMNAME") & "'"
                            BARCODEITEMCLAUSE = BARCODEITEMCLAUSE & " OR J.ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    BARCODEITEMCLAUSE = BARCODEITEMCLAUSE & ")"
                    OBJREP.SOCLAUSE = OBJREP.SOCLAUSE & ITEMCLAUSE
                    OBJREP.OTHERWHERECLAUSE = OBJREP.OTHERWHERECLAUSE & BARCODEITEMCLAUSE
                End If

                'FOR DESIGN
                GRIDDESIGN.ClearColumnsFilter()
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNCLAUSE = "" Then
                            DESIGNCLAUSE = " AND (DESIGNMASTER.DESIGN_NO = '" & dtrow("DESIGNNO") & "'"
                            BARCODEDESIGNCLAUSE = " AND (J.DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        Else
                            DESIGNCLAUSE = DESIGNCLAUSE & " OR DESIGNMASTER.DESIGN_NO = '" & dtrow("DESIGNNO") & "'"
                            BARCODEDESIGNCLAUSE = BARCODEDESIGNCLAUSE & " OR J.DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        End If
                    End If
                Next
                If DESIGNCLAUSE <> "" Then
                    DESIGNCLAUSE = DESIGNCLAUSE & ")"
                    BARCODEDESIGNCLAUSE = BARCODEDESIGNCLAUSE & ")"
                    OBJREP.SOCLAUSE = OBJREP.SOCLAUSE & DESIGNCLAUSE
                    OBJREP.OTHERWHERECLAUSE = OBJREP.OTHERWHERECLAUSE & BARCODEDESIGNCLAUSE
                End If

                'FOR SHADE
                GRIDSHADE.ClearColumnsFilter()
                For i As Integer = 0 To GRIDSHADE.RowCount - 1
                    Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If COLORCLAUSE = "" Then
                            COLORCLAUSE = " AND (COLORMASTER.COLOR_NAME = '" & dtrow("COLOR") & "'"
                            BARCODECOLORCLAUSE = " AND (J.COLOR = '" & dtrow("COLOR") & "'"
                        Else
                            COLORCLAUSE = COLORCLAUSE & " OR COLORMASTER.COLOR_NAME = '" & dtrow("COLOR") & "'"
                            BARCODECOLORCLAUSE = BARCODECOLORCLAUSE & " OR J.COLOR = '" & dtrow("COLOR") & "'"
                        End If
                    End If
                Next
                If COLORCLAUSE <> "" Then
                    COLORCLAUSE = COLORCLAUSE & ")"
                    BARCODECOLORCLAUSE = BARCODECOLORCLAUSE & ")"
                    OBJREP.SOCLAUSE = OBJREP.SOCLAUSE & COLORCLAUSE
                    OBJREP.OTHERWHERECLAUSE = OBJREP.OTHERWHERECLAUSE & BARCODECOLORCLAUSE
                End If




                'FOR UNIT
                gridbillunit.ClearColumnsFilter()
                For i As Integer = 0 To gridbillunit.RowCount - 1
                    Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If UNITCLAUSE = "" Then
                            UNITCLAUSE = " AND (BARCODESTOCK.UNIT = '" & dtrow("UNIT") & "'"
                        Else
                            UNITCLAUSE = UNITCLAUSE & " OR BARCODESTOCK.UNIT = '" & dtrow("UNIT") & "'"
                        End If
                    End If
                Next
                If UNITCLAUSE <> "" Then
                    UNITCLAUSE = UNITCLAUSE & ")"
                    OBJREP.BARCODECLAUSE = OBJREP.BARCODECLAUSE & UNITCLAUSE
                End If


                OBJREP.Show()
                Exit Sub

            End If




            Dim OBJSTOCK As New StockDesign
            OBJSTOCK.MdiParent = MDIMain

            If chkdate.Checked = True Then
                getFromToDate()
                OBJSTOCK.FROMDATE = dtfrom.Value.Date
                OBJSTOCK.TODATE = dtto.Value.Date
                OBJSTOCK.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
            Else
                OBJSTOCK.FROMDATE = AccFrom.Date
                OBJSTOCK.TODATE = AccTo.Date
                OBJSTOCK.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If RBBARCODESTOCKDTLS.Checked = True Or RBITEMDESIGNSHADESMALLSUMM.Checked = True Or RBITEMDESIGNSHADESMALLNOUNITSUMM.Checked = True Or RBDESIGNNOTSENT.Checked = True Or (ALLOWBARCODEPRINT = True And RBITEMDESIGNSHADESUMM.Checked = True) Or (ALLOWBARCODEPRINT = True And RBGODOWNWISESUMM.Checked = True) Then


                'IF CHK IS TRUE THEN GET ALL YEARID UDER THAT COMPANY
                Dim WHERECLAUSE As String = ""
                If CHKALLCMP.Checked = True Then
                    OBJSTOCK.WHERECLAUSE = " {BARCODESTOCK.YEARID} IN [" & YearId
                    Dim DTYEAR As DataTable = OBJCMN.Execute_Any_String(" SELECT YEAR_ID AS YEARID FROM YEARMASTER WHERE YEAR_STARTDATE = '" & Format(AccFrom.Date, "MM/dd/yyyy") & "' AND YEAR_ID <> " & YearId, "", "")
                    For Each DTROW As DataRow In DTYEAR.Rows
                        OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & "," & DTROW("YEARID")
                    Next
                    OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & "]"
                Else
                    OBJSTOCK.WHERECLAUSE = " {BARCODESTOCK.YEARID}=" & YearId
                End If

                'FOR UNIT
                gridbillunit.ClearColumnsFilter()
                For i As Integer = 0 To gridbillunit.RowCount - 1
                    Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If UNITCLAUSE = "" Then
                            UNITCLAUSE = " AND ({BARCODESTOCK.UNIT} = '" & dtrow("UNIT") & "'"
                        Else
                            UNITCLAUSE = UNITCLAUSE & " OR {BARCODESTOCK.UNIT} = '" & dtrow("UNIT") & "'"
                        End If
                    End If
                Next
                If UNITCLAUSE <> "" Then
                    UNITCLAUSE = UNITCLAUSE & ")"
                    OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & UNITCLAUSE
                End If





                'FOR PARTYNAME
                Dim DESIGNNAMECLAUSE As String = ""     'THIS VARIABLE IS USED FOR WHERECLAUSE IN THE QUERY BELOW
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNNAMECLAUSE = "" Then
                            DESIGNNAMECLAUSE = "'" & dtrow("NAME") & "'"
                        Else
                            DESIGNNAMECLAUSE = DESIGNNAMECLAUSE & ",'" & dtrow("NAME") & "'"
                        End If
                    End If
                Next



                'IF DEDIGNNOTSENT IS CHECKED THEN WE NEED A FILTER WHERE WE WILL SHOW ONLY THOSE DESIGN WHICH ARE PRESENT IN STOCK AND WHOSE INVOICE IS NOT MADE
                If RBDESIGNNOTSENT.Checked = True Then
                    If DESIGNNAMECLAUSE = "" Then
                        MsgBox("Please Select Party Name, Then Open this Report", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    Dim DTDESIGN As DataTable = OBJCMN.Execute_Any_String("SELECT DISTINCT ISNULL(DESIGN_NO,'') AS DESIGNNO FROM INVOICEMASTER INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN DESIGNMASTER ON INVOICEMASTER_DESC.INVOICE_DESIGNID = DESIGN_ID INNER JOIN LEDGERS ON ACC_ID = INVOICEMASTER.INVOICE_LEDGERID WHERE LEDGERS.ACC_CMPNAME IN (" & DESIGNNAMECLAUSE & ") AND INVOICEMASTER.INVOICE_YEARID = " & YearId, "", "")
                    For Each DTDESIGNROW As DataRow In DTDESIGN.Rows
                        OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " AND {BARCODESTOCK.DESIGNNO} <> '" & DTDESIGNROW("DESIGNNO") & "'"
                    Next
                End If


                'FOR ITEMNAME
                GRIDITEM.ClearColumnsFilter()
                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND ({BARCODESTOCK.ITEMNAME} = '" & dtrow("ITEMNAME") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR {BARCODESTOCK.ITEMNAME} = '" & dtrow("ITEMNAME") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & ITEMCLAUSE
                End If

                'FOR DESIGN
                GRIDDESIGN.ClearColumnsFilter()
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNCLAUSE = "" Then
                            DESIGNCLAUSE = " AND ({BARCODESTOCK.DESIGNNO} = '" & dtrow("DESIGNNO") & "'"
                        Else
                            DESIGNCLAUSE = DESIGNCLAUSE & " OR {BARCODESTOCK.DESIGNNO} = '" & dtrow("DESIGNNO") & "'"
                        End If
                    End If
                Next
                If DESIGNCLAUSE <> "" Then
                    DESIGNCLAUSE = DESIGNCLAUSE & ")"
                    OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & DESIGNCLAUSE
                End If

                'FOR SHADE
                GRIDSHADE.ClearColumnsFilter()
                For i As Integer = 0 To GRIDSHADE.RowCount - 1
                    Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If SHADECLAUSE = "" Then
                            SHADECLAUSE = " AND ({BARCODESTOCK.COLOR} = '" & dtrow("SHADE") & "'"
                        Else
                            SHADECLAUSE = SHADECLAUSE & " OR {BARCODESTOCK.COLOR} = '" & dtrow("SHADE") & "'"
                        End If
                    End If
                Next
                If SHADECLAUSE <> "" Then
                    SHADECLAUSE = SHADECLAUSE & ")"
                    OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & SHADECLAUSE
                End If



                If CMBGODOWN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.GODOWN}='" & CMBGODOWN.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.ITEMNAME}='" & CMBITEMNAME.Text.Trim & "'"
                If CMBQUALITY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.QUALITY}='" & CMBQUALITY.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.DESIGNNO}='" & CMBDESIGN.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.COLOR}='" & CMBSHADE.Text.Trim & "'"
                If CMBPIECETYPE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.PIECETYPE}='" & CMBPIECETYPE.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {BARCODESTOCK.CATEGORY}='" & CMBCATEGORY.Text.Trim & "'"

                If RBITEMDESIGNSHADESMALLSUMM.Checked = True Then
                    OBJSTOCK.FRMSTRING = "ITEMDESIGNSHADESTOCKSMALLSUMM"
                ElseIf RBITEMDESIGNSHADESMALLNOUNITSUMM.Checked = True Or RBDESIGNNOTSENT.Checked = True Then
                    OBJSTOCK.FRMSTRING = "ITEMDESIGNSHADESTOCKNOUNITSMALLSUMM"
                ElseIf RBITEMDESIGNSHADESUMM.Checked = True Then
                    OBJSTOCK.FRMSTRING = "BARCODEITEMDESIGNSHADESTOCKSUMM"
                ElseIf RBGODOWNWISESUMM.Checked = True Then
                    OBJSTOCK.FRMSTRING = "BARCODEGODOWNITEMSTOCKSUMM"
                ElseIf RBBARCODESTOCKDTLS.Checked = True Then
                    OBJSTOCK.FRMSTRING = "BARCODESTOCKDETAILS"
                End If
                OBJSTOCK.Show()
                Exit Sub
            End If




            If ClientName = "BRILLANTO" And RBDESIGNSHADESUMM.Checked = True Then
                Dim WHERECLAUSE As String = " AND  BARCODESTOCK.YEARID=" & YearId

                'FOR UNIT
                gridbillunit.ClearColumnsFilter()
                For i As Integer = 0 To gridbillunit.RowCount - 1
                    Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If UNITCLAUSE = "" Then
                            UNITCLAUSE = " AND (BARCODESTOCK.UNIT = '" & dtrow("UNIT") & "'"
                        Else
                            UNITCLAUSE = UNITCLAUSE & " OR BARCODESTOCK.UNIT = '" & dtrow("UNIT") & "'"
                        End If
                    End If
                Next
                If UNITCLAUSE <> "" Then
                    UNITCLAUSE = UNITCLAUSE & ")"
                    WHERECLAUSE = WHERECLAUSE & UNITCLAUSE
                End If

                If CMBGODOWN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.GODOWN='" & CMBGODOWN.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
                If CMBQUALITY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.QUALITY='" & CMBQUALITY.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.DESIGNNO='" & CMBDESIGN.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.COLOR='" & CMBSHADE.Text.Trim & "'"
                If CMBPIECETYPE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.PIECETYPE='" & CMBPIECETYPE.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and BARCODESTOCK.CATEGORY='" & CMBCATEGORY.Text.Trim & "'"

                'WE NEED TO ADD THESE RECORDS IN TEMP TABLE
                Dim NARR As String = ""
                Dim DNO As String = ""
                Dim DT As New DataTable
                DT = OBJCMN.Execute_Any_String("DELETE FROM TEMPSTOCKBRILLANTO WHERE YEARID = " & YearId, "", "")
                DT = OBJCMN.search("DESIGNNO, COLOR, SUM(MTRS) AS MTRS, SUM(PCS) AS PCS", "", " BARCODESTOCK ", WHERECLAUSE & " AND YEARID = " & YearId & " GROUP BY DESIGNNO, COLOR ORDER BY DESIGNNO, COLOR ")
                For Each ROW As DataRow In DT.Rows
                    If DNO = "" Then DNO = ROW("DESIGNNO")
                    If DNO <> ROW("DESIGNNO") Then
                        'INSERT DATA IN TEMPTABLE
                        Dim DTTOTAL As DataTable = OBJCMN.search("SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS", "", "BARCODESTOCK", WHERECLAUSE & " AND YEARID = " & YearId & " AND DESIGNNO ='" & DNO & "' AND YEARID = " & YearId)
                        Dim INS As DataTable = OBJCMN.Execute_Any_String("INSERT INTO TEMPSTOCKBRILLANTO VALUES ('" & DNO & "','" & NARR & "','ROLLS'," & Val(DTTOTAL.Rows(0).Item("TOTALPCS")) & "," & Val(DTTOTAL.Rows(0).Item("TOTALMTRS")) & "," & CmpId & "," & YearId & ")", "", "")
                        NARR = ""
                        DNO = ROW("DESIGNNO")
                    End If

                    If NARR = "" Then
                        NARR = ROW("COLOR") & "=(" & Val(ROW("MTRS")) & " / " & Val(ROW("PCS")) & ")"
                    Else
                        NARR = NARR & ", " & ROW("COLOR") & "=(" & Val(ROW("MTRS")) & " / " & Val(ROW("PCS")) & ")"
                    End If
                Next

                'ON LAST RECORD WE NEED TO ADD NEW 
                If DNO <> "" Then
                    'INSERT DATA IN TEMPTABLE
                    Dim DTTOTAL As DataTable = OBJCMN.search("SUM(PCS) AS TOTALPCS, SUM(MTRS) AS TOTALMTRS", "", "BARCODESTOCK", WHERECLAUSE & " AND YEARID = " & YearId & " AND DESIGNNO ='" & DNO & "' AND YEARID = " & YearId)
                    Dim INS As DataTable = OBJCMN.Execute_Any_String("INSERT INTO TEMPSTOCKBRILLANTO VALUES ('" & DNO & "','" & NARR & "','ROLLS'," & Val(DTTOTAL.Rows(0).Item("TOTALPCS")) & "," & Val(DTTOTAL.Rows(0).Item("TOTALMTRS")) & "," & CmpId & "," & YearId & ")", "", "")
                    NARR = ""
                    DNO = ""
                End If

                OBJSTOCK.FRMSTRING = "DESIGNSHADEBRILLANTO"
                OBJSTOCK.Show()
                Exit Sub
            End If




            If RBPURSALEMTRS.Checked = True Then
                Dim OBJPURSALE As New PurSaleMtrsStock

                'FOR register
                gridbillregister.ClearColumnsFilter()
                Dim REGISTERCLAUSE As String = ""
                For i As Integer = 0 To gridbillregister.RowCount - 1
                    Dim dtrow As DataRow = gridbillregister.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If REGISTERCLAUSE = "" Then
                            REGISTERCLAUSE = " AND (REGISTER_NAME = '" & dtrow("REGNAME") & "'"
                        Else
                            REGISTERCLAUSE = REGISTERCLAUSE & " OR REGISTER_NAME = '" & dtrow("REGNAME") & "'"
                        End If
                    End If
                Next
                If REGISTERCLAUSE <> "" Then
                    REGISTERCLAUSE = REGISTERCLAUSE & ")"
                    OBJPURSALE.PURCLAUSE = OBJPURSALE.PURCLAUSE & REGISTERCLAUSE
                End If
                If chkdate.CheckState = CheckState.Checked Then OBJPURSALE.FROMDATE = dtfrom.Value.Date Else OBJPURSALE.FROMDATE = AccFrom
                If chkdate.CheckState = CheckState.Checked Then OBJPURSALE.TODATE = dtto.Value.Date Else OBJPURSALE.TODATE = AccTo
                OBJPURSALE.MdiParent = MDIMain
                OBJPURSALE.Show()
                Exit Sub
            End If





            If RBGRIDSTOCKDETAILS.Checked = True Or RBDESIGNSTOCKREGISTER.Checked = True Or RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Checked = True Then

                Dim OBJSTKDTLS As New Object
                If RBGRIDSTOCKDETAILS.Checked = True Or RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Checked = True Then
                    OBJSTKDTLS = New StockOnHandSummary
                    OBJSTKDTLS.STOCKPRINTABLE = True
                Else
                    OBJSTKDTLS = New StockDetailsGridReport
                End If

                If RBGRIDSTOCKDETAILS.Checked = True Then
                    OBJSTKDTLS.FRMSTRING = "GRIDSTOCKDETAILS"
                ElseIf RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Checked = True Then
                    OBJSTKDTLS.FRMSTRING = "ITEMDESIGNSHADEGRIDSTOCKDETAILS"
                Else
                    OBJSTKDTLS.FRMSTRING = "DESIGNSTOCKREGISTER"
                End If
                If chkdate.CheckState = CheckState.Checked Then OBJSTKDTLS.FROMDATE = dtfrom.Value.Date Else OBJSTKDTLS.FROMDATE = AccFrom
                If chkdate.CheckState = CheckState.Checked Then OBJSTKDTLS.TODATE = dtto.Value.Date Else OBJSTKDTLS.TODATE = AccTo

                OBJSTKDTLS.WHERECLAUSE = " AND STOCKREGISTER.YEARID=" & YearId
                If CMBGODOWN.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.GODOWN='" & CMBGODOWN.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
                If CMBQUALITY.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.QUALITY='" & CMBQUALITY.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.DESIGNNO='" & CMBDESIGN.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.COLOR='" & CMBSHADE.Text.Trim & "'"
                If CMBPIECETYPE.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.PIECETYPE='" & CMBPIECETYPE.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.CATEGORY='" & CMBCATEGORY.Text.Trim & "'"


                'FOR UNIT
                gridbillunit.ClearColumnsFilter()
                For i As Integer = 0 To gridbillunit.RowCount - 1
                    Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If UNITCLAUSE = "" Then
                            UNITCLAUSE = " And (STOCKREGISTER.UNIT = '" & dtrow("UNIT") & "'"
                        Else
                            UNITCLAUSE = UNITCLAUSE & " OR STOCKREGISTER.UNIT = '" & dtrow("UNIT") & "'"
                        End If
                    End If
                Next
                If UNITCLAUSE <> "" Then
                    UNITCLAUSE = UNITCLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & UNITCLAUSE
                End If




                'FOR PARTYNAME
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND (STOCKREGISTER.NAME = '" & dtrow("NAME") & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " OR STOCKREGISTER.NAME = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & NAMECLAUSE
                End If


                'FOR ITEMNAME
                GRIDITEM.ClearColumnsFilter()
                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND (STOCKREGISTER.ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR STOCKREGISTER.ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & ITEMCLAUSE
                End If

                'FOR DESIGN
                GRIDDESIGN.ClearColumnsFilter()
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNCLAUSE = "" Then
                            DESIGNCLAUSE = " AND (STOCKREGISTER.DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        Else
                            DESIGNCLAUSE = DESIGNCLAUSE & " OR STOCKREGISTER.DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        End If
                    End If
                Next
                If DESIGNCLAUSE <> "" Then
                    DESIGNCLAUSE = DESIGNCLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & DESIGNCLAUSE
                End If

                'FOR SHADE
                GRIDSHADE.ClearColumnsFilter()
                For i As Integer = 0 To GRIDSHADE.RowCount - 1
                    Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If SHADECLAUSE = "" Then
                            SHADECLAUSE = " AND (STOCKREGISTER.COLOR = '" & dtrow("SHADE") & "'"
                        Else
                            SHADECLAUSE = SHADECLAUSE & " OR STOCKREGISTER.COLOR = '" & dtrow("SHADE") & "'"
                        End If
                    End If
                Next
                If SHADECLAUSE <> "" Then
                    SHADECLAUSE = SHADECLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & SHADECLAUSE
                End If


                OBJSTKDTLS.MdiParent = MDIMain
                OBJSTKDTLS.Show()
                Exit Sub
            End If





            If RBBALEWISESUMM.Checked = True Then
                Dim OBJSTKDTLS As New BaleWiseStockDetails
                If chkdate.CheckState = CheckState.Checked Then OBJSTKDTLS.FROMDATE = dtfrom.Value.Date Else OBJSTKDTLS.FROMDATE = AccFrom
                If chkdate.CheckState = CheckState.Checked Then OBJSTKDTLS.TODATE = dtto.Value.Date Else OBJSTKDTLS.TODATE = AccTo

                OBJSTKDTLS.WHERECLAUSE = " AND STOCKREGISTER.YEARID=" & YearId
                If CMBGODOWN.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.GODOWN='" & CMBGODOWN.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
                If CMBQUALITY.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.QUALITY='" & CMBQUALITY.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.DESIGNNO='" & CMBDESIGN.Text.Trim & "'"
                If CMBSHADE.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.COLOR='" & CMBSHADE.Text.Trim & "'"
                If CMBPIECETYPE.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.PIECETYPE='" & CMBPIECETYPE.Text.Trim & "'"
                If CMBCATEGORY.Text.Trim <> "" Then OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & " and STOCKREGISTER.CATEGORY='" & CMBCATEGORY.Text.Trim & "'"

                'FOR UNIT
                gridbillunit.ClearColumnsFilter()
                For i As Integer = 0 To gridbillunit.RowCount - 1
                    Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If UNITCLAUSE = "" Then
                            UNITCLAUSE = " And (STOCKREGISTER.UNIT = '" & dtrow("UNIT") & "'"
                        Else
                            UNITCLAUSE = UNITCLAUSE & " OR STOCKREGISTER.UNIT = '" & dtrow("UNIT") & "'"
                        End If
                    End If
                Next
                If UNITCLAUSE <> "" Then
                    UNITCLAUSE = UNITCLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & UNITCLAUSE
                End If


                'FOR PARTYNAME
                gridbill.ClearColumnsFilter()
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If NAMECLAUSE = "" Then
                            NAMECLAUSE = " AND (STOCKREGISTER.NAME = '" & dtrow("NAME") & "'"
                        Else
                            NAMECLAUSE = NAMECLAUSE & " OR STOCKREGISTER.NAME = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next
                If NAMECLAUSE <> "" Then
                    NAMECLAUSE = NAMECLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & NAMECLAUSE
                End If


                'FOR ITEMNAME
                GRIDITEM.ClearColumnsFilter()
                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND (STOCKREGISTER.ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR STOCKREGISTER.ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & ITEMCLAUSE
                End If

                'FOR DESIGN
                GRIDDESIGN.ClearColumnsFilter()
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNCLAUSE = "" Then
                            DESIGNCLAUSE = " AND (STOCKREGISTER.DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        Else
                            DESIGNCLAUSE = DESIGNCLAUSE & " OR STOCKREGISTER.DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                        End If
                    End If
                Next
                If DESIGNCLAUSE <> "" Then
                    DESIGNCLAUSE = DESIGNCLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & DESIGNCLAUSE
                End If

                'FOR SHADE
                GRIDSHADE.ClearColumnsFilter()
                For i As Integer = 0 To GRIDSHADE.RowCount - 1
                    Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If SHADECLAUSE = "" Then
                            SHADECLAUSE = " AND (STOCKREGISTER.COLOR = '" & dtrow("SHADE") & "'"
                        Else
                            SHADECLAUSE = SHADECLAUSE & " OR STOCKREGISTER.COLOR = '" & dtrow("SHADE") & "'"
                        End If
                    End If
                Next
                If SHADECLAUSE <> "" Then
                    SHADECLAUSE = SHADECLAUSE & ")"
                    OBJSTKDTLS.WHERECLAUSE = OBJSTKDTLS.WHERECLAUSE & SHADECLAUSE
                End If



                OBJSTKDTLS.MdiParent = MDIMain
                OBJSTKDTLS.Show()
                Exit Sub
            End If



            OBJSTOCK.WHERECLAUSE = " {STOCKREGISTER.YEARID}=" & YearId
            If CMBGODOWN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.GODOWN}='" & CMBGODOWN.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.ITEMNAME}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBQUALITY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.QUALITY}='" & CMBQUALITY.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.DESIGNNO}='" & CMBDESIGN.Text.Trim & "'"
            If CMBSHADE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.COLOR}='" & CMBSHADE.Text.Trim & "'"
            If CMBPIECETYPE.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.PIECETYPE}='" & CMBPIECETYPE.Text.Trim & "'"
            If CMBCATEGORY.Text.Trim <> "" Then OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {STOCKREGISTER.CATEGORY}='" & CMBCATEGORY.Text.Trim & "'"


            'FOR UNIT
            gridbillunit.ClearColumnsFilter()
            For i As Integer = 0 To gridbillunit.RowCount - 1
                Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If UNITCLAUSE = "" Then
                        UNITCLAUSE = " And ({STOCKREGISTER.UNIT} = '" & dtrow("UNIT") & "'"
                    Else
                        UNITCLAUSE = UNITCLAUSE & " OR {STOCKREGISTER.UNIT} = '" & dtrow("UNIT") & "'"
                    End If
                End If
            Next
            If UNITCLAUSE <> "" Then
                UNITCLAUSE = UNITCLAUSE & ")"
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & UNITCLAUSE
            End If


            'FOR PARTYNAME
            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then
                        NAMECLAUSE = " AND ({STOCKREGISTER.NAME} = '" & dtrow("NAME") & "'"
                    Else
                        NAMECLAUSE = NAMECLAUSE & " OR {STOCKREGISTER.NAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next
            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & NAMECLAUSE
            End If


            'FOR ITEMNAME
            GRIDITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND ({STOCKREGISTER.ITEMNAME} = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR {STOCKREGISTER.ITEMNAME} = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & ITEMCLAUSE
            End If

            'FOR DESIGN
            GRIDDESIGN.ClearColumnsFilter()
            For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If DESIGNCLAUSE = "" Then
                        DESIGNCLAUSE = " AND ({STOCKREGISTER.DESIGNNO} = '" & dtrow("DESIGNNO") & "'"
                    Else
                        DESIGNCLAUSE = DESIGNCLAUSE & " OR {STOCKREGISTER.DESIGNNO} = '" & dtrow("DESIGNNO") & "'"
                    End If
                End If
            Next
            If DESIGNCLAUSE <> "" Then
                DESIGNCLAUSE = DESIGNCLAUSE & ")"
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & DESIGNCLAUSE
            End If

            'FOR SHADE
            GRIDSHADE.ClearColumnsFilter()
            For i As Integer = 0 To GRIDSHADE.RowCount - 1
                Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If SHADECLAUSE = "" Then
                        SHADECLAUSE = " AND ({STOCKREGISTER.COLOR} = '" & dtrow("SHADE") & "'"
                    Else
                        SHADECLAUSE = SHADECLAUSE & " OR {STOCKREGISTER.COLOR} = '" & dtrow("SHADE") & "'"
                    End If
                End If
            Next
            If SHADECLAUSE <> "" Then
                SHADECLAUSE = SHADECLAUSE & ")"
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & SHADECLAUSE
            End If


            If RBITEMSUMM.Checked = True And ALLOWBARCODEPRINT = False Then
                OBJSTOCK.FRMSTRING = "ITEMSTOCKSUMM"
            ElseIf RBITEMSUMM.Checked = True And ALLOWBARCODEPRINT = True Then
                OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE.Replace("STOCKREGISTER", "BARCODESTOCKREGISTER")
                OBJSTOCK.FRMSTRING = "ITEMSTOCKBARCODESUMM"
            ElseIf RBQUALITYSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "QUALITYSTOCKSUMM"
            ElseIf RBDESIGNSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "DESIGNSTOCKSUMM"
            ElseIf RBSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "SHADESTOCKSUMM"
            ElseIf RBITEMSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "ITEMSHADESTOCKSUMM"
            ElseIf RBITEMSHADEGODOWNSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "ITEMSHADEGODOWNSTOCKSUMM"
            ElseIf RBITEMQUALITYSUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "ITEMQUALITYSTOCKSUMM"
            ElseIf RBITEMDESIGNSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "ITEMDESIGNSHADESTOCKSUMM"
            ElseIf RBDESIGNSHADESUMM.Checked = True Then
                OBJSTOCK.FRMSTRING = "DESIGNSHADESTOCKSUMM"
            End If

            OBJSTOCK.SHOWBALANCESTOCKONLY = CHKNEGATIVESTOCK.Checked
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
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

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNvalidate(CMBDESIGN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
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

    Private Sub CHKSELECTREGISTER_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTREGISTER.CheckedChanged
        Try
            For i As Integer = 0 To gridbillregister.RowCount - 1
                Dim dtrow As DataRow = gridbillregister.GetDataRow(i)
                dtrow("CHK") = CHKSELECTREGISTER.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTDESIGN_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTDESIGN.CheckedChanged
        Try
            For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                dtrow("CHK") = CHKSELECTDESIGN.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTSHADE_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTSHADE.CheckedChanged
        Try
            For i As Integer = 0 To GRIDSHADE.RowCount - 1
                Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                dtrow("CHK") = CHKSELECTSHADE.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTITEM_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTITEM.CheckedChanged
        Try
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                dtrow("CHK") = CHKSELECTITEM.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTPARTY_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTPARTY.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = CHKSELECTPARTY.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTUNIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTUNIT.CheckedChanged
        Try
            For i As Integer = 0 To gridbillunit.RowCount - 1
                Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                dtrow("CHK") = CHKSELECTUNIT.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockFilter_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "AVIS" Then
                LBLFORWARD.Visible = True
                CMBFORWARD.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKALLCMP_CheckedChanged(sender As Object, e As EventArgs) Handles CHKALLCMP.CheckedChanged
        fillcmb()
    End Sub
End Class