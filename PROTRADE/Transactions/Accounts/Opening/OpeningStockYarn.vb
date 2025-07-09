
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics

Public Class OpeningStockYarn
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Dim CLEAR As Boolean = False
    Public EDIT As Boolean
    Public tempMsg As Integer
    Public FRMSTRING As String

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

        If gridstock.RowCount = 0 Then
            EP.SetError(TXTBAGS, "Enter Item Details")
            bln = False
        End If

        'For Each row As DataGridViewRow In gridstock.Rows
        '    If Val(row.Cells(GCONES.Index).Value) = 0 Then
        '        EP.SetError(cmbtype, "Cones Cannot be 0")
        '        bln = False
        '    End If
        '    If Val(row.Cells(GWT.Index).Value) = 0 Then
        '        EP.SetError(cmbtype, "Wt Cannot be 0")
        '        bln = False
        '    End If
        '    If row.Cells(GYARNQUALITY.Index).Value = "" Then
        '        EP.SetError(cmbtype, "Yarn Quality cannot be Blank")
        '        bln = False
        '    End If

        '    If cmbtype.Text = "GODOWNSTOCKYARN" Then
        '        If row.Cells(GGODOWN.Index).Value = "" Then
        '            EP.SetError(cmbtype, "Godown cannot be Blank")
        '            bln = False
        '        End If
        '    ElseIf cmbtype.Text = "JOBBERSTOCKYARN" Then
        '        If row.Cells(GPROCESS.Index).Value = "" Then
        '            EP.SetError(CMBPROCESS, "Process Name cannot be Blank")
        '            bln = False
        '        End If

        '        If row.Cells(gtoname.Index).Value = "" Then
        '            EP.SetError(cmbtype, "Jobber Name cannot be Blank")
        '            bln = False
        '        End If
        '    End If
        'Next
        Return bln
    End Function

    Sub EDITROW()
        Try
            If gridstock.CurrentRow.Index >= 0 And gridstock.Item(gsrno.Index, gridstock.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = gridstock.Item(GNO.Index, gridstock.CurrentRow.Index).Value.ToString
                txtsrno.Text = gridstock.Item(gsrno.Index, gridstock.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = gridstock.Item(GLOTNO.Index, gridstock.CurrentRow.Index).Value.ToString
                CMBYARNQUALITY.Text = gridstock.Item(GYARNQUALITY.Index, gridstock.CurrentRow.Index).Value.ToString
                CMBMILL.Text = gridstock.Item(GMILL.Index, gridstock.CurrentRow.Index).Value.ToString

                CMBDESIGN.Text = gridstock.Item(GDESIGN.Index, gridstock.CurrentRow.Index).Value.ToString
                CMBSHADE.Text = gridstock.Item(GSHADE.Index, gridstock.CurrentRow.Index).Value.ToString
                CMBPROCESS.Text = gridstock.Item(GPROCESS.Index, gridstock.CurrentRow.Index).Value.ToString
                TXTLRNO.Text = gridstock.Item(GLRNO.Index, gridstock.CurrentRow.Index).Value.ToString
                LRDATE.Value = Format(Convert.ToDateTime(gridstock.Item(GLRDATE.Index, gridstock.CurrentRow.Index).Value).Date, "dd/MM/yyyy")

                CMBTONAME.Text = gridstock.Item(gtoname.Index, gridstock.CurrentRow.Index).Value.ToString
                CMBGODOWN.Text = gridstock.Item(GGODOWN.Index, gridstock.CurrentRow.Index).Value.ToString
                TXTBAGS.Text = Val(gridstock.Item(GBAGS.Index, gridstock.CurrentRow.Index).Value)
                TXTWT.Text = Val(gridstock.Item(GWT.Index, gridstock.CurrentRow.Index).Value)
                TXTCONES.Text = Val(gridstock.Item(GCONES.Index, gridstock.CurrentRow.Index).Value)

                TEMPROW = gridstock.CurrentRow.Index
                TXTLOTNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridstock.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub cmbtoname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTONAME.Validating
        Try
            If CMBTONAME.Text.Trim <> "" Then namevalidate(CMBTONAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtoname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTONAME.Enter
        Try
            If CMBTONAME.Text.Trim = "" Then fillname(CMBTONAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try

            fillYARNQUALITY(CMBYARNQUALITY, EDIT)
            fillmill(CMBMILL, EDIT)
            fillname(CMBTONAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'")
            fillGODOWN(CMBGODOWN, EDIT)
            cmbtype.Text = FRMSTRING
            fillDESIGN(CMBDESIGN, "")
            FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
            FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridstock.Enabled = True

        If GRIDDOUBLECLICK = False Then
            gridstock.Rows.Add(Val(txtsrno.Text.Trim), Val(TXTNO.Text.Trim), TXTLOTNO.Text.Trim, CMBYARNQUALITY.Text.Trim, CMBMILL.Text.Trim, CMBDESIGN.Text.Trim, CMBSHADE.Text.Trim, CMBPROCESS.Text.Trim, TXTLRNO.Text.Trim, Format(LRDATE.Value.Date, "dd/MM/yyyy"), CMBTONAME.Text, CMBGODOWN.Text.Trim, Val(TXTBAGS.Text.Trim), Val(TXTWT.Text.Trim), Val(TXTCONES.Text.Trim))
            getsrno(gridstock)
            gridstock.FirstDisplayedScrollingRowIndex = gridstock.RowCount - 1
        ElseIf GRIDDOUBLECLICK = True Then
            gridstock.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            gridstock.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            gridstock.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            gridstock.Item(GMILL.Index, TEMPROW).Value = CMBMILL.Text.Trim
            gridstock.Item(GDESIGN.Index, TEMPROW).Value = CMBDESIGN.Text.Trim
            gridstock.Item(GSHADE.Index, TEMPROW).Value = CMBSHADE.Text.Trim
            gridstock.Item(GPROCESS.Index, TEMPROW).Value = CMBPROCESS.Text.Trim
            gridstock.Item(GLRNO.Index, TEMPROW).Value = TXTLRNO.Text.Trim
            gridstock.Item(GLRDATE.Index, TEMPROW).Value = Format(LRDATE.Value.Date, "dd/MM/yyyy")
            gridstock.Item(gtoname.Index, TEMPROW).Value = CMBTONAME.Text.Trim
            gridstock.Item(GGODOWN.Index, TEMPROW).Value = CMBGODOWN.Text.Trim
            gridstock.Item(GBAGS.Index, TEMPROW).Value = Val(TXTBAGS.Text.Trim)
            gridstock.Item(GWT.Index, TEMPROW).Value = Val(TXTWT.Text.Trim)
            gridstock.Item(GCONES.Index, TEMPROW).Value = Val(TXTCONES.Text.Trim)

            GRIDDOUBLECLICK = False
        End If

        If CLEAR = True Then
            txtsrno.Text = gridstock.RowCount + 1

            TXTLOTNO.Clear()
            If ClientName <> "VAISHALI" Then CMBYARNQUALITY.Text = ""
            CMBMILL.Text = ""
            CMBDESIGN.Text = ""
            CMBSHADE.Text = ""
            CMBPROCESS.Text = ""
            TXTLRNO.Clear()
            LRDATE.Value = Now.Date
            TXTWT.Clear()
            TXTBAGS.Clear()
            TXTNO.Clear()
            TXTCONES.Clear()
            TXTLOTNO.Focus()
        End If

    End Sub

    Private Sub OpeningStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            gridstock.Focus()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            openingdate.Value = AccFrom.Date

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search("   ISNULL(STOCKMASTER_YARN.SM_TYPE, '') AS TYPE, ISNULL(STOCKMASTER_YARN.SM_DATE, GETDATE()) AS DATE, ISNULL(STOCKMASTER_YARN.SM_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(STOCKMASTER_YARN.SM_NO, 0) AS SMNO, ISNULL(STOCKMASTER_YARN.SM_LOTNO, '') AS LOTNO, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(MILLMASTER.MILL_NAME, '') AS MILLNAME, ISNULL(PROCESS_NAME,'') AS PROCESSNAME, ISNULL(TONAME.Acc_cmpname, '') AS TONAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(STOCKMASTER_YARN.SM_BAGS, 0) AS BAGS, ISNULL(STOCKMASTER_YARN.SM_WT, 0) AS WT, ISNULL(STOCKMASTER_YARN.SM_CMPID, 0) AS CMPID, ISNULL(STOCKMASTER_YARN.SM_YEARID, 0) AS YEARID, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKMASTER_YARN.SM_LRNO, '') AS LRNO, ISNULL(STOCKMASTER_YARN.SM_LRDATE, GETDATE()) AS LRDATE, ISNULL(STOCKMASTER_YARN.SM_CONES, 0) AS CONES", "", " DESIGNMASTER RIGHT OUTER JOIN COLORMASTER RIGHT OUTER JOIN YARNQUALITYMASTER INNER JOIN STOCKMASTER_YARN ON YARNQUALITYMASTER.YARN_ID = STOCKMASTER_YARN.SM_YARNQUALITYID ON  COLORMASTER.COLOR_id = STOCKMASTER_YARN.SM_COLORID ON DESIGNMASTER.DESIGN_id = STOCKMASTER_YARN.SM_DESIGNID LEFT OUTER JOIN MILLMASTER ON STOCKMASTER_YARN.SM_MILLID = MILLMASTER.MILL_ID LEFT OUTER JOIN GODOWNMASTER ON STOCKMASTER_YARN.SM_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS TONAME ON STOCKMASTER_YARN.SM_LEDGERIDTO = TONAME.Acc_id LEFT OUTER JOIN PROCESSMASTER ON SM_PROCESSID = PROCESS_ID", " AND STOCKMASTER_YARN.SM_TYPE = '" & FRMSTRING & "' AND STOCKMASTER_YARN.SM_YEARID = " & YearId & " ORDER BY SM_NO")

            If dttable.Rows.Count > 0 Then
                For Each DR As DataRow In dttable.Rows
                    openingdate.Value = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                    CMBPROCESS.Text = Convert.ToString(DR("TYPE").ToString)
                    gridstock.Rows.Add(DR("GRIDSRNO"), DR("SMNO"), DR("LOTNO"), DR("YARNQUALITY"), DR("MILLNAME"), DR("DESIGNNO"), DR("COLOR"), DR("PROCESSNAME"), DR("LRNO"), DR("LRDATE"), DR("TONAME"), DR("GODOWN"), Val(DR("BAGS")), Val(DR("WT")), Val(DR("CONES")))
                Next
                getsrno(gridstock)
                gridstock.FirstDisplayedScrollingRowIndex = gridstock.RowCount - 1
            End If
            txtsrno.Text = Val(gridstock.RowCount) + 1

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMILL.Enter
        Try
            If CMBMILL.Text.Trim = "" Then FILLMILL(CMBMILL, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMILL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMILL.Validating
        Try
            If CMBMILL.Text.Trim <> "" Then MILLVALIDATE(CMBMILL, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbYARNquality_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVE()
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJSM As New ClsOpeningStockYarn

            ALPARAVAL.Add(openingdate.Value.Date)
            ALPARAVAL.Add(cmbtype.Text.Trim)

            ALPARAVAL.Add(txtsrno.Text.Trim)
            ALPARAVAL.Add(TXTLOTNO.Text.Trim)
            ALPARAVAL.Add(CMBYARNQUALITY.Text.Trim)
            ALPARAVAL.Add(CMBMILL.Text.Trim)
            ALPARAVAL.Add(CMBDESIGN.Text.Trim)
            ALPARAVAL.Add(CMBSHADE.Text.Trim)
            ALPARAVAL.Add(CMBPROCESS.Text.Trim)
            ALPARAVAL.Add(TXTLRNO.Text.Trim)
            ALPARAVAL.Add(LRDATE.Value.Date)

            ALPARAVAL.Add(CMBTONAME.Text.Trim)

            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(Val(TXTBAGS.Text.Trim))
            ALPARAVAL.Add(Val(TXTWT.Text.Trim))
            ALPARAVAL.Add(Val(TXTCONES.Text.Trim))


            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)

            OBJSM.alParaval = ALPARAVAL
            If GRIDDOUBLECLICK = False Then
                Dim DT As DataTable = OBJSM.save()
                If DT.Rows.Count > 0 Then TXTNO.Text = DT.Rows(0).Item(0)
            Else
                ALPARAVAL.Add(TXTNO.Text.Trim)
                Dim INTRES As Integer = OBJSM.UPDATE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpcs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBAGS.KeyPress, TXTCONES.KeyPress
        Try
            numkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridstock.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridstock.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DELETE FROM STOCKMASTER
                Dim OBJSM As New ClsOpeningStockYarn
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(Val(gridstock.Rows(gridstock.CurrentRow.Index).Cells(GNO.Index).Value))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.DELETE()

                gridstock.Rows.RemoveAt(gridstock.CurrentRow.Index)
                getsrno(gridstock)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtoname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTONAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTONAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then CMBGODOWN.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningStock_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If FRMSTRING = "GODOWNSTOCKYARN" Then
                Me.Text = "Yarn Stock At Godown"
                CMBGODOWN.BackColor = Color.LemonChiffon
                CMBTONAME.BackColor = Color.White
                CMBPROCESS.BackColor = Color.White
                If ClientName = "VAISHALI" Then GBAGS.HeaderText = "Box/Tubes"
            Else
                Me.Text = "Yarn Stock At Jobber"
                CMBGODOWN.BackColor = Color.White
                CMBPROCESS.BackColor = Color.LemonChiffon
                CMBTONAME.BackColor = Color.LemonChiffon
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCONES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCONES.Validating
        Try
            If ClientName = "VAISHALI" And cmbtype.Text.Trim = "GODOWNSTOCKYARN" Then
                'FETCH CONEWT FROM MILLMASTER
                If Val(TXTWT.Text.Trim) = 0 And Val(TXTCONES.Text.Trim) <> 0 And CMBMILL.Text.Trim <> "" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(MILL_REMARK,0) AS CONEWT", "", "MILLMASTER ", " AND MILL_NAME = '" & CMBMILL.Text.Trim & "' AND MILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then TXTWT.Text = Format(Val(TXTCONES.Text.Trim) * Val(DT.Rows(0).Item("CONEWT")), "0.00")
                End If
            End If


            If CMBYARNQUALITY.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then
                If ClientName <> "VAISHALI" And Val(TXTCONES.Text.Trim) = 0 Then Exit Sub
                If cmbtype.Text.Trim = "GODOWNSTOCKYARN" Then
                    If CMBGODOWN.Text.Trim <> "" Then
                        CMBPROCESS.Text = ""
                        SAVE()
                        CLEAR = True
                        fillgrid()
                    Else
                        MsgBox("Enter Proper Details")
                        Exit Sub
                    End If
                ElseIf cmbtype.Text = "JOBBERSTOCKYARN" Then
                    If CMBTONAME.Text.Trim <> "" And CMBPROCESS.Text.Trim <> "" Then
                        CMBGODOWN.Text = ""
                        SAVE()
                        CLEAR = True
                        fillgrid()
                    Else
                        MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, "")
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
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORvalidate(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class