
Imports System.ComponentModel
Imports BL

Public Class PriceList

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
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

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If (ClientName = "DRDRAPES" Or ClientName = "SONAL" Or ClientName = "KCRAYON" Or ClientName = "KARAN") And cmbname.Text.Trim = "" Then
            EP.SetError(cmbname, "Enter Party Name")
            bln = False
        End If

        If CMBITEMNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBITEMNAME, "Enter Item Details")
            bln = False
        End If

        If Val(TXTRATE.Text.Trim.Length) = 0 Then
            EP.SetError(TXTRATE, "Enter Rate")
            bln = False
        End If

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        Dim WHERECLAUSE As String = ""
        If ClientName = "KCRAYON" Then WHERECLAUSE = " AND DESIGNMASTER.DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "'"
        If ClientName = "DRDRAPES" Or ClientName = "SONAL" Or ClientName = "KCRAYON" Or ClientName = "KARAN" Then
            DT = OBJCMN.search(" PL_NO AS NO ", "", " PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON PRICELISTMASTER.PL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id", " AND ITEMMASTER.item_name = '" & CMBITEMNAME.Text.Trim & "' AND isnull(LEDGERS.ACC_CMPNAME,'') = '" & cmbname.Text.Trim & "' AND PL_YEARID = " & YearId & WHERECLAUSE)
        Else
            DT = OBJCMN.search(" PL_NO AS NO,QUALITYMASTER.QUALITY_name AS QUALITY, COLORMASTER.COLOR_name AS SHADE, DESIGNMASTER.DESIGN_NO AS DESIGN ", "", " PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON PRICELISTMASTER.PL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND ITEMMASTER.item_name = '" & CMBITEMNAME.Text.Trim & "' AND isnull(QUALITYMASTER.QUALITY_name,'') = '" & cmbquality.Text.Trim & "' AND isnull(COLORMASTER.COLOR_name,'') = '" & cmbcolor.Text.Trim & "' AND isnull(DESIGNMASTER.DESIGN_NO,'') = '" & CMBDESIGNNO.Text.Trim & "' AND PL_CMPID = " & CmpId & " AND PL_YEARID = " & YearId)
        End If
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item("NO"))) Then
                EP.SetError(TXTRATE, "ITEM ALREADY PRESENT WITH THIS RATE.....")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub EDITROW()
        Try

            If gridbill.GetFocusedRowCellValue("NO") > 0 Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = Val(gridbill.GetFocusedRowCellValue("NO"))
                cmbname.Text = gridbill.GetFocusedRowCellValue("NAME")
                CMBITEMNAME.Text = gridbill.GetFocusedRowCellValue("ITEMNAME")
                cmbquality.Text = gridbill.GetFocusedRowCellValue("QUALITY")
                CMBDESIGNNO.Text = gridbill.GetFocusedRowCellValue("DESIGN")
                cmbcolor.Text = gridbill.GetFocusedRowCellValue("SHADE")
                TXTRATE.Text = Val(gridbill.GetFocusedRowCellValue("RATE"))
                txtsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        EDITROW()
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS' and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS'", "Sundry DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, "")
            fillQUALITY(cmbquality, EDIT)
            fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS'")
            fillname(CMBCOPYNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS'")
            FILLDESIGN(CMBDESIGNNO, CMBITEMNAME.Text.Trim)
            FILLCOLOR(cmbcolor, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        If ClientName = "DRDRAPES" Or ClientName = "SONAL" Or ClientName = "KCRAYON" Or ClientName = "KARAN" Then
            DT = OBJCMN.search(" ISNULL(PRICELISTMASTER.PL_NO, 0) AS NO, ISNULL(PRICELISTMASTER.PL_RATE, 0) AS RATE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME", "", " PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON PRICELISTMASTER.PL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & cmbname.Text.Trim & "' AND PL_YEARID = " & YearId & " order by dbo.PRICELISTMASTER.PL_NO desc ")
        Else
            DT = OBJCMN.search(" ISNULL(PRICELISTMASTER.PL_NO, 0) AS NO, ISNULL(PRICELISTMASTER.PL_RATE, 0) AS RATE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME", "", " PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON PRICELISTMASTER.PL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND PL_CMPID = " & CmpId & " AND PL_YEARID = " & YearId & " order by dbo.PRICELISTMASTER.PL_NO desc ")
        End If
        gridbilldetails.DataSource = DT
    End Sub

    Private Sub OpeningStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            gridbilldetails.Focus()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub CLEAR()
        Try
            TXTNO.Clear()
            If (ClientName <> "DRDRAPES" And ClientName <> "SONAL" And ClientName <> "KCRAYON" And ClientName <> "KARAN") Then cmbname.Text = ""
            TXTRATE.Clear()
            txtsrno.Clear()
            CMBITEMNAME.Text = ""
            cmbcolor.Text = ""
            cmbquality.Text = ""
            CMBDESIGNNO.Text = ""
            openingdate.Value = Now.Date
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            CLEAR()
            openingdate.Value = AccFrom.Date

            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORVALIDATE(cmbcolor, e, Me, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbquality_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbquality.Enter
        Try
            If cmbquality.Text.Trim = "" Then fillQUALITY(cmbquality, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbquality_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbquality.Validating
        Try
            If cmbquality.Text.Trim <> "" Then QUALITYVALIDATE(cmbquality, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVE()
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJSM As New ClsPriceListMaster

            ALPARAVAL.Add(openingdate.Value.Date)

            ALPARAVAL.Add(txtsrno.Text.Trim)
            ALPARAVAL.Add(cmbname.Text.Trim)
            ALPARAVAL.Add(CMBITEMNAME.Text.Trim)
            ALPARAVAL.Add(cmbquality.Text.Trim)
            ALPARAVAL.Add(CMBDESIGNNO.Text.Trim)
            ALPARAVAL.Add(cmbcolor.Text.Trim)

            ALPARAVAL.Add(Val(TXTRATE.Text.Trim))

            ALPARAVAL.Add(CmpId)

            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJSM.alParaval = ALPARAVAL
            If GRIDDOUBLECLICK = False Then
                Dim DT As DataTable = OBJSM.save()
                If DT.Rows.Count > 0 Then TXTNO.Text = DT.Rows(0).Item(0)

            Else
                ALPARAVAL.Add(TXTNO.Text.Trim)
                Dim INTRES As Integer = OBJSM.UPDATE()

            End If
            GRIDDOUBLECLICK = False
            If ClientName = "SANGHVI" Then
                cmbcolor.Focus()
            ElseIf ClientName = "DRDRAPES" Or ClientName = "SONAL" Or ClientName = "KCRAYON" Or ClientName = "KARAN" Then
                CMBITEMNAME.Focus()
            Else
                cmbname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        EDITROW()
    End Sub

    Private Sub gridbilldetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
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

    Private Sub cmbquality_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbquality.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJQUALITY As New SelectQuality
                OBJQUALITY.ShowDialog()
                If OBJQUALITY.TEMPNAME <> "" Then cmbquality.Text = OBJQUALITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGNNO.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJDESIGN As New SelectDesign
                OBJDESIGN.FRMSTRING = "DESIGN"
                OBJDESIGN.ShowDialog()
                If OBJDESIGN.TEMPNAME <> "" Then CMBDESIGNNO.Text = OBJDESIGN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPRINT_Click(sender As Object, e As EventArgs) Handles CMBPRINT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Price List.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Price List"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Price List", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Price List Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcolor.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.FRMSTRING = "COLOR"
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then cmbcolor.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub


            'DELETE FROM TABLE
            Dim OBJSM As New ClsPriceListMaster
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(gridbill.GetFocusedRowCellValue("NO"))
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(YearId)

            OBJSM.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJSM.DELETE()
            CLEAR()
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PriceList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DRDRAPES" Or ClientName = "SONAL" Or ClientName = "KARAN" Then
                cmbname.BackColor = Color.LemonChiffon
                TXTRATE.BackColor = Color.LemonChiffon
                cmbquality.Visible = False
                CMBDESIGNNO.Visible = False
                cmbcolor.Visible = False
                GQUALITY.Visible = False
                GDESIGN.Visible = False
                GSHADE.Visible = False
                TXTRATE.Left = cmbquality.Left
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(sender As Object, e As EventArgs) Handles cmbname.Validated
        If ClientName = "DRDRAPES" Or ClientName = "SONAL" Or ClientName = "KCRAYON" Or ClientName = "KARAN" Then fillgrid()
    End Sub

    Private Sub CMBCOPYNAME_Enter(sender As Object, e As EventArgs) Handles CMBCOPYNAME.Enter
        Try
            If CMBCOPYNAME.Text.Trim = "" Then fillname(CMBCOPYNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBCOPYNAME.Validating
        Try
            If CMBCOPYNAME.Text.Trim <> "" Then namevalidate(CMBCOPYNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS'", "Sundry DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCOPYNAME_Validated(sender As Object, e As EventArgs) Handles CMBCOPYNAME.Validated
        Try
            If CMBCOPYNAME.Text.Trim <> "" And cmbname.Text.Trim <> "" Then
                If MsgBox("Copy Price List of " & CMBCOPYNAME.Text.Trim & " To " & cmbname.Text.Trim & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(PRICELISTMASTER.PL_RATE, 0) AS RATE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN,  ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME", "", " PRICELISTMASTER INNER JOIN ITEMMASTER ON PRICELISTMASTER.PL_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON PRICELISTMASTER.PL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN DESIGNMASTER ON PRICELISTMASTER.PL_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON PRICELISTMASTER.PL_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PRICELISTMASTER.PL_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND ISNULL(LEDGERS.ACC_CMPNAME,'') = '" & CMBCOPYNAME.Text.Trim & "' AND PL_YEARID = " & YearId & " order by dbo.PRICELISTMASTER.PL_NO desc ")
                For Each DTROW As DataRow In DT.Rows
                    CMBITEMNAME.Text = DTROW("ITEMNAME")
                    cmbquality.Text = DTROW("QUALITY")
                    CMBDESIGNNO.Text = DTROW("DESIGN")
                    cmbcolor.Text = DTROW("SHADE")
                    TXTRATE.Text = Val(DTROW("RATE"))

                    TXTRATE_Validated(sender, e)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If CMBITEMNAME.Text.Trim <> "" Then
                SAVE()
                If ClientName <> "SANGHVI" Then CLEAR()
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class