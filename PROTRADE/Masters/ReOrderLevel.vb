
Imports BL

Public Class ReOrderLevel

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

        If CMBITEMNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBITEMNAME, "Enter Item Details")
            bln = False
        End If

        If Val(TXTQTY.Text.Trim.Length) = 0 Then
            EP.SetError(TXTQTY, "Enter Qty")
            bln = False
        End If

        Dim OBJCMN As New ClsCommon
        Dim WHERECLAUSE As String = ""
        If cmbquality.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(QUALITYMASTER.QUALITY_NAME,'') = '" & cmbquality.Text.Trim & "'"
        If CMBDESIGNNO.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(DESIGNMASTER.DESIGN_NO,'') = '" & CMBDESIGNNO.Text.Trim & "'"
        If cmbcolor.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " AND ISNULL(COLORMASTER.COLOR_NAME,'') = '" & cmbcolor.Text.Trim & "'"
        Dim DT As DataTable = OBJCMN.search(" REORDER_NO AS NO ", "", " REORDERLEVEL INNER JOIN ITEMMASTER ON REORDERLEVEL.REORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON REORDERLEVEL.REORDER_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON REORDERLEVEL.REORDER_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON REORDERLEVEL.REORDER_QUALITYID = QUALITYMASTER.QUALITY_id", " AND ITEMMASTER.item_name = '" & CMBITEMNAME.Text.Trim & "'  AND REORDER_YEARID = " & YearId & WHERECLAUSE)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item("NO"))) Then
                EP.SetError(TXTQTY, "ITEM ALREADY PRESENT WITH THIS ORDER LEVEL.....")
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
                CMBITEMNAME.Text = gridbill.GetFocusedRowCellValue("ITEMNAME")
                cmbquality.Text = gridbill.GetFocusedRowCellValue("QUALITY")
                CMBDESIGNNO.Text = gridbill.GetFocusedRowCellValue("DESIGN")
                cmbcolor.Text = gridbill.GetFocusedRowCellValue("SHADE")
                TXTQTY.Text = Val(gridbill.GetFocusedRowCellValue("QTY"))
                TXTSRNO.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        EDITROW()
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
            FILLDESIGN(CMBDESIGNNO, CMBITEMNAME.Text.Trim)
            FILLCOLOR(cmbcolor, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" ISNULL(REORDERLEVEL.REORDER_NO, 0) AS NO, ISNULL(REORDERLEVEL.REORDER_QTY, 0) AS QTY, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME", "", " REORDERLEVEL INNER JOIN ITEMMASTER ON REORDERLEVEL.REORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON REORDERLEVEL.REORDER_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON REORDERLEVEL.REORDER_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON REORDERLEVEL.REORDER_QUALITYID = QUALITYMASTER.QUALITY_id ", " AND REORDER_YEARID = " & YearId & " order by dbo.REORDERLEVEL.REORDER_NO desc ")
        gridbilldetails.DataSource = DT
    End Sub

    Private Sub ReOrderLevel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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
            TXTQTY.Clear()
            TXTSRNO.Clear()
            CMBITEMNAME.Text = ""
            cmbcolor.Text = ""
            cmbquality.Text = ""
            CMBDESIGNNO.Text = ""
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            CLEAR()

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
            Dim OBJSM As New ClsReOrderLevel


            ALPARAVAL.Add(TXTSRNO.Text.Trim)
            ALPARAVAL.Add(CMBITEMNAME.Text.Trim)
            ALPARAVAL.Add(cmbquality.Text.Trim)
            ALPARAVAL.Add(CMBDESIGNNO.Text.Trim)
            ALPARAVAL.Add(cmbcolor.Text.Trim)

            ALPARAVAL.Add(Val(TXTQTY.Text.Trim))

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
            CMBITEMNAME.Focus()
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

            Dim PATH As String = Application.StartupPath & "\Re Order Entry.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Re Order Entry"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Re Order Entry", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Re Order Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
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

    Private Sub TXTRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTQTY.Validating
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
            Dim OBJSM As New ClsReOrderLevel
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

End Class