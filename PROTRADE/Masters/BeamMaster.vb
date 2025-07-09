
Imports BL
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class BeamMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean
    Public TEMPBEAMNAME As String
    Public TEMPBEAMID As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub BeamMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub clear()
        Try
            TXTBEAMDESC.Clear()
            CMBHSNCODE.Text = ""
            TXTENDS.Clear()
            TXTTL.Clear()
            CMBQUALITY.Text = ""
            TXTWT.Clear()
            TXTWTTL.Clear()

            TXTSRNO.Clear()
            CMBGRIDQUALITY.Text = ""
            CMBSHADE.Text = ""
            TXTGRIDENDS.Clear()
            TXTGRIDWT.Clear()
            GRIDBEAM.RowCount = 0
            TXTTOTALENDS.Clear()
            TXTTOTALWT.Clear()

            GPQUALITY.Visible = False
            GPGRID.Visible = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        If CMBQUALITY.Text = "" Then fillYARNQUALITY(CMBQUALITY, edit)
        If CMBGRIDQUALITY.Text = "" Then fillYARNQUALITY(CMBGRIDQUALITY, edit)
        If CMBSHADE.Text = "" Then FILLCOLOR(CMBSHADE, "")
        If CMBHSNCODE.Text = "" Then FILLHSNITEMDESC(CMBHSNCODE)
    End Sub

    Private Sub BeamMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'BEAM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            clear()
            fillcmb()
            TXTBEAMDESC.Text = TEMPBEAMNAME

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search(" ISNULL(BEAMMASTER.BEAM_ID, 0) AS BEAMID, ISNULL(BEAMMASTER.BEAM_NAME, '') AS BEAMNAME, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS QUALITY, ISNULL(BEAMMASTER.BEAM_ENDS, 0) AS ENDS, ISNULL(BEAMMASTER.BEAM_TAPLINE, 0) AS TAPLINE, ISNULL(BEAMMASTER.BEAM_WTMTRS, 0) AS WTMTRS, ISNULL(BEAMMASTER.BEAM_WTTL, 0) AS WTTL, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(BEAMMASTER_DESC.BEAM_SRNO, 0) AS GRIDSRNO, ISNULL(GRIDYARNQUALITYMASTER.YARN_NAME, '') AS GRIDQUALITY, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(BEAMMASTER_DESC.BEAM_GRIDENDS, 0) AS GRIDENDS, ISNULL(BEAMMASTER_DESC.BEAM_GRIDWT, 0) AS GRIDWT, ISNULL(BEAMMASTER.BEAM_TOTALENDS, 0) AS TOTALENDS, ISNULL(BEAMMASTER.BEAM_TOTALWT, 0) AS TOTALWT ", "", " YARNQUALITYMASTER AS GRIDYARNQUALITYMASTER RIGHT OUTER JOIN BEAMMASTER_DESC ON GRIDYARNQUALITYMASTER.YARN_ID = BEAMMASTER_DESC.BEAM_GRIDQUALITYID LEFT OUTER JOIN COLORMASTER ON BEAMMASTER_DESC.BEAM_SHADEID = COLORMASTER.COLOR_id RIGHT OUTER JOIN BEAMMASTER ON BEAMMASTER_DESC.BEAM_ID = BEAMMASTER.BEAM_ID LEFT OUTER JOIN YARNQUALITYMASTER ON BEAMMASTER.BEAM_QUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN HSNMASTER ON BEAMMASTER.BEAM_HSNCODEID = HSNMASTER.HSN_ID ", " and BEAMMASTER.BEAM_ID = " & TEMPBEAMID & " and BEAMMASTER.BEAM_yearid = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        TEMPBEAMID = ROW("BEAMID")
                        TEMPBEAMNAME = ROW("BEAMNAME")
                        CMBHSNCODE.Text = ROW("HSNCODE")
                        TXTBEAMDESC.Text = ROW("BEAMNAME").ToString
                        CMBQUALITY.Text = ROW("QUALITY")
                        TXTENDS.Text = ROW("ENDS")
                        TXTTL.Text = ROW("TAPLINE")
                        TXTWT.Text = ROW("WTMTRS")
                        TXTWTTL.Text = ROW("WTTL")

                        If ROW("GRIDQUALITY") <> "" Then GRIDBEAM.Rows.Add(Val(ROW("GRIDSRNO")), ROW("GRIDQUALITY"), ROW("SHADE"), Val(ROW("GRIDENDS")), Val(ROW("GRIDWT")))
                        GETSRNO(GRIDBEAM)
                        TOTAL()

                    Next
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub TOTAL()
        Try
            TXTTOTALENDS.Clear()
            TXTTOTALWT.Clear()

            For Each ROW As DataGridViewRow In GRIDBEAM.Rows
                TXTTOTALENDS.Text = Format(Val(TXTTOTALENDS.Text.Trim) + Val(ROW.Cells(GENDS.Index).Value), "0")
                TXTTOTALWT.Text = Format(Val(TXTTOTALWT.Text.Trim) + Val(ROW.Cells(GWTPER.Index).Value), "0.000")
            Next
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

    Private Sub TXTBEAMDESC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBEAMDESC.Validating
        Try
            If TXTBEAMDESC.Text.Trim <> "" Then
                uppercase(TXTBEAMDESC)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(TXTBEAMDESC.Text) <> LCase(TEMPBEAMNAME)) Then
                    dt = OBJCMN.search("BEAM_NAME", "", "BEAMMASTER", " and BEAM_NAME = '" & TXTBEAMDESC.Text.Trim & "' And BEAM_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Beam Name Already Exists", MsgBoxStyle.Critical, "PROCESS")
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTBEAMDESC.Text.Trim.Length = 0 Then
            EP.SetError(TXTBEAMDESC, "Fill Beam Name")
            bln = False
        End If

        If TXTTL.Text.Trim.Length = 0 Then
            EP.SetError(TXTTL, "Enter Tapline")
            bln = False
        End If

        If GRIDBEAM.RowCount = 0 Then
            EP.SetError(TXTBEAMDESC, "Enter Yarn Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub TXTENDS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTENDS.KeyPress, TXTTL.KeyPress, TXTGRIDENDS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTBEAMDESC.Text.Trim)
            alParaval.Add(CMBHSNCODE.Text.Trim)
            alParaval.Add(CMBQUALITY.Text.Trim)
            alParaval.Add(Val(TXTENDS.Text.Trim))
            alParaval.Add(Val(TXTTL.Text.Trim))
            alParaval.Add(Format(Val(TXTWT.Text.Trim), "0.000"))
            alParaval.Add(Format(Val(TXTWTTL.Text.Trim), "0.000"))

            alParaval.Add(Format(Val(TXTTOTALENDS.Text.Trim), "0"))
            alParaval.Add(Format(Val(TXTTOTALWT.Text.Trim), "0.000"))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim SRNO As String = ""
            Dim GRIDYARNQUALITY As String = ""
            Dim SHADE As String = ""
            Dim GRIDENDS As String = ""
            Dim GRIDWT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBEAM.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = row.Cells(GSRNO.Index).Value.ToString
                        GRIDYARNQUALITY = row.Cells(GYARNQUALITY.Index).Value.ToString
                        SHADE = row.Cells(GSHADE.Index).Value.ToString
                        GRIDENDS = Val(row.Cells(GENDS.Index).Value)
                        GRIDWT = Val(row.Cells(GWTPER.Index).Value)
                    Else
                        SRNO = SRNO & "|" & row.Cells(GSRNO.Index).Value.ToString
                        GRIDYARNQUALITY = GRIDYARNQUALITY & "|" & row.Cells(GYARNQUALITY.Index).Value.ToString
                        SHADE = SHADE & "|" & row.Cells(GSHADE.Index).Value.ToString
                        GRIDENDS = GRIDENDS & "|" & Val(row.Cells(GENDS.Index).Value)
                        GRIDWT = GRIDWT & "|" & Val(row.Cells(GWTPER.Index).Value)

                    End If
                End If
            Next



            alParaval.Add(SRNO)
            alParaval.Add(GRIDYARNQUALITY)
            alParaval.Add(SHADE)
            alParaval.Add(GRIDENDS)
            alParaval.Add(GRIDWT)


            Dim objclsBeamMaster As New ClsBeamMaster
            objclsBeamMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsBeamMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPBEAMID)
                IntResult = objclsBeamMaster.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False


            clear()
            TXTBEAMDESC.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGRIDQUALITY.Enter
        Try
            If CMBGRIDQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBGRIDQUALITY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGRIDQUALITY.Validating
        Try
            If CMBGRIDQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBGRIDQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress, TXTWTTL.KeyPress, TXTGRIDWT.KeyPress
        numdot3(e, sender, Me)
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            edit = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = False Then Exit Sub
            If MsgBox("Delete Beam?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim objclsBeamMaster As New ClsBeamMaster
            objclsBeamMaster.alParaval.Add(TEMPBEAMID)
            objclsBeamMaster.alParaval.Add(YearId)

            Dim DT As DataTable = objclsBeamMaster.DELETE
            If DT.Rows.Count > 0 Then
                MsgBox(DT.Rows(0).Item(0))
                clear()
                edit = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTGRIDWT_Validated(sender As Object, e As EventArgs) Handles TXTGRIDWT.Validated
        Try
            If CMBGRIDQUALITY.Text.Trim <> "" And Val(TXTGRIDENDS.Text.Trim) > 0 And Val(TXTGRIDWT.Text.Trim) > 0 Then
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDBEAM.Rows.Add(Val(TXTSRNO.Text.Trim), CMBGRIDQUALITY.Text.Trim, CMBSHADE.Text.Trim, Val(TXTGRIDENDS.Text.Trim), Val(TXTGRIDWT.Text.Trim))
                GETSRNO(GRIDBEAM)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDBEAM.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDBEAM.Item(GYARNQUALITY.Index, TEMPROW).Value = CMBGRIDQUALITY.Text.Trim
                GRIDBEAM.Item(GSHADE.Index, TEMPROW).Value = CMBSHADE.Text.Trim
                GRIDBEAM.Item(GENDS.Index, TEMPROW).Value = Format(Val(TXTGRIDENDS.Text.Trim), "0")
                GRIDBEAM.Item(GWTPER.Index, TEMPROW).Value = Format(Val(TXTGRIDWT.Text.Trim), "0.000")

                GRIDDOUBLECLICK = False

            End If
            TOTAL()

            GRIDBEAM.FirstDisplayedScrollingRowIndex = GRIDBEAM.RowCount - 1

            TXTSRNO.Text = GRIDBEAM.RowCount + 1
            CMBGRIDQUALITY.Text = ""
            CMBSHADE.Text = ""
            TXTGRIDENDS.Clear()
            TXTGRIDWT.Clear()
            CMBGRIDQUALITY.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBEAM_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBEAM.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And GRIDBEAM.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDBEAM.Item(GSRNO.Index, e.RowIndex).Value)
                CMBGRIDQUALITY.Text = GRIDBEAM.Item(GYARNQUALITY.Index, e.RowIndex).Value
                CMBSHADE.Text = GRIDBEAM.Item(GSHADE.Index, e.RowIndex).Value
                TXTGRIDENDS.Text = Val(GRIDBEAM.Item(GENDS.Index, e.RowIndex).Value)
                TXTGRIDWT.Text = Val(GRIDBEAM.Item(GWTPER.Index, e.RowIndex).Value)

                TEMPROW = e.RowIndex
                CMBGRIDQUALITY.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBEAM_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBEAM.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBEAM.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                GRIDBEAM.Rows.RemoveAt(GRIDBEAM.CurrentRow.Index)
                GETSRNO(GRIDBEAM)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(sender As Object, e As EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORVALIDATE(CMBSHADE, e, Me, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDENDS_Validated(sender As Object, e As EventArgs) Handles TXTGRIDENDS.Validated
        Try
            If Val(TXTGRIDWT.Text.Trim) = 0 And Val(TXTGRIDENDS.Text.Trim) > 0 And Val(TXTTL.Text.Trim) > 0 And CMBGRIDQUALITY.Text.Trim <> "" Then
                'GET DENIER FROM YARNMASTER
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_DENIER,0) AS DENIER", "", "YARNQUALITYMASTER ", " AND YARN_NAME = '" & CMBGRIDQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    '(ENDS * TL* DENIER)/9000000
                    TXTGRIDWT.Text = Format((Val(TXTGRIDENDS.Text.Trim) * Val(TXTTL.Text.Trim) * Val(DT.Rows(0).Item("DENIER"))) / 9000000, "0.000")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Enter(sender As Object, e As EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
                CMBHSNCODE.Text = ""
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_KeyDown(sender As Object, e As KeyEventArgs) Handles CMBHSNCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then TXTHSNCODE.Text = OBJLEDGER.TEMPCODE

                If OBJLEDGER.TEMPCODE <> "" Then CMBHSNCODE.Text = OBJLEDGER.TEMPCODE

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(sender As Object, e As CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

