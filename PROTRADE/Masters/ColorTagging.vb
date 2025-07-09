
Imports BL

Public Class ColorTagging

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

        If CMBCOLOR.Text.Trim.Length = 0 Then
            EP.SetError(CMBCOLOR, "Enter Color Details")
            bln = False
        End If

        If Val(TXTPARTYCOLOR.Text.Trim.Length) = 0 Then
            EP.SetError(TXTPARTYCOLOR, "Enter party color")
            bln = False
        End If

        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" TAG_NO AS NO ", "", " COLORTAGGING INNER JOIN COLORMASTER ON COLORTAGGING.TAG_COLORID = COLORMASTER.COLOR_ID INNER JOIN LEDGERS ON COLORTAGGING.TAG_LEDGERID = LEDGERS.ACC_ID", " AND COLORMASTER.COLOR_NAME = '" & CMBCOLOR.Text.Trim & "' AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND TAG_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item("NO"))) Then
                EP.SetError(CMBNAME, "Shade Already Present with same Mill Name.....")
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
                CMBNAME.Text = gridbill.GetFocusedRowCellValue("NAME")
                TXTPARTYCOLOR.Text = gridbill.GetFocusedRowCellValue("PARTYCOLOR")
                CMBCOLOR.Text = gridbill.GetFocusedRowCellValue("COLOR")

                CMBNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        EDITROW()
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Ccreditors' and LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' and LEDGERS.ACC_TYPE = 'ACCOUNTS'")
            FILLCOLOR(CMBCOLOR, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" ISNULL(COLORTAGGING.TAG_NO, 0) AS NO, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(COLORTAGGING.TAG_PCOLOR, 0) AS PARTYCOLOR, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR", "", " COLORTAGGING INNER JOIN   COLORMASTER ON COLORTAGGING.TAG_COLORID = COLORMASTER.COLOR_id INNER JOIN LEDGERS ON COLORTAGGING.TAG_LEDGERID = LEDGERS.ACC_ID", " AND  TAG_YEARID = " & YearId & " order by dbo.COLORTAGGING.TAG_NO desc ")
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
            TXTPARTYCOLOR.Clear()
            CMBCOLOR.Text = ""
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

            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub SAVE()
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJSM As New ClsColorTagging

            ALPARAVAL.Add(txtsrno.Text.Trim)
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(TXTPARTYCOLOR.Text.Trim)
            ALPARAVAL.Add(CMBCOLOR.Text.Trim)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJSM.alParaval = ALPARAVAL
            If GRIDDOUBLECLICK = False Then
                Dim DT As DataTable = OBJSM.SAVE()
            Else
                ALPARAVAL.Add(TXTNO.Text.Trim)
                Dim INTRES As Integer = OBJSM.UPDATE()
            End If
            GRIDDOUBLECLICK = False
            TXTPARTYCOLOR.Focus()
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

    Private Sub CMBPRINT_Click(sender As Object, e As EventArgs) Handles CMBPRINT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Color Tagging.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Color Tagging"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Color Tagging", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Color Tagging Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.FRMSTRING = "COLOR"
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBCOLOR.Text = OBJCOLOR.TEMPNAME
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
            Dim OBJSM As New ClsColorTagging
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

    Private Sub CMBCOLOR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCOLOR_Validated(sender As Object, e As EventArgs) Handles CMBCOLOR.Validated
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If CMBNAME.Text.Trim <> "" And TXTPARTYCOLOR.Text.Trim <> "" And CMBCOLOR.Text.Trim <> "" Then
                SAVE()
                CLEAR()
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
