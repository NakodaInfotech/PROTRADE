
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class ItemMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDPROCESSDOUBLECLICK, GRIDSTORESDOUBLECLICK, GRIDWEFTDOUBLECLICK, GRIDBEAMDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPPROW, TEMPUPLOADROW, TEMPSROW, TEMPWEFTROW As Integer
    Public EDIT As Boolean
    Public TEMPITEMNAME, TEMPITEMCODE, FRMSTRING As String
    Dim TEMPITEMID As Integer
    Dim TEMPBEAMROW As Integer
    Dim DT_WEFTDETAILS As New DataTable


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            'IF WE MAKE ANY CHANGES IN SAVE CODE THEN DO THE SAME CHANGS IN THE FOLLOWING FORMS
            '1) UPLOADSTOCK AND UPLOADITEM ON MDIMAIN
            '2) TXTCHNO_VALIDATED IN GRN
            '3) TXTCCMPSO_VALIDATED IN SALEORDER
            '4) CMDSELECTGDN_CLICK IN PURCHASEINVOICE
            '5) TXTCHNO_VALIDATED IN STOCKRECO
            '6) CMDSELECTCHALLAN_CLICK IN SALEINVOICE


            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbmaterial.Text.Trim)
            alParaval.Add(cmbcategory.Text.Trim)
            alParaval.Add(TXTDISPLAYNAME.Text.Trim)
            alParaval.Add(UCase(cmbitemname.Text.Trim))

            alParaval.Add(CMBDEPARTMENT.Text.Trim)
            alParaval.Add(CMBCODE.Text.Trim)
            alParaval.Add(cmbunit.Text.Trim)
            alParaval.Add(TXTFOLD.Text.Trim)
            alParaval.Add(TXTRATE.Text.Trim)
            alParaval.Add(TXTVALUATIONRATE.Text.Trim)
            alParaval.Add(Val(TXTTRANSPORTRATE.Text.Trim))
            alParaval.Add(Val(TXTCHECKINGRATE.Text.Trim))
            alParaval.Add(Val(TXTPACKINGRATE.Text.Trim))
            alParaval.Add(Val(TXTDESIGNRATE.Text.Trim))
            alParaval.Add(txtreorder.Text.Trim)
            alParaval.Add(txtupper.Text.Trim)
            alParaval.Add(txtlower.Text.Trim)
            alParaval.Add(CMBHSNCODE.Text.Trim)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(CHKHIDEINDESIGN.CheckState)

            alParaval.Add(TXTWIDTH.Text.Trim)
            alParaval.Add(TXTGREYWIDTH.Text.Trim)
            alParaval.Add(TXTSHRINKFROM.Text.Trim)
            alParaval.Add(TXTSHRINKTO.Text.Trim)
            alParaval.Add(TXTSELVEDGE.Text.Trim)

            'FOR GRIDPARAMETER
            Dim RATETYPE As String = ""
            Dim RATE As String = ""

            For Each ROW As DataGridViewRow In GRIDRATE.Rows
                If ROW.Cells(gratetype.Index).Value <> Nothing Then
                    If RATETYPE = "" Then
                        RATETYPE = ROW.Cells(gratetype.Index).Value.ToString
                        RATE = ROW.Cells(grate.Index).Value
                    Else
                        RATETYPE = RATETYPE & "|" & ROW.Cells(gratetype.Index).Value.ToString
                        RATE = RATE & "|" & ROW.Cells(grate.Index).Value
                    End If
                End If
            Next


            alParaval.Add(RATETYPE)
            alParaval.Add(RATE)

            Dim YARNQUALITY As String = ""
            Dim PER As String = ""

            For Each ROW As DataGridViewRow In GRIDCOMP.Rows
                If ROW.Cells(GYARNQUALITY.Index).Value <> Nothing Then
                    If YARNQUALITY = "" Then
                        YARNQUALITY = ROW.Cells(GYARNQUALITY.Index).Value.ToString
                        PER = Val(ROW.Cells(GPER.Index).Value)
                    Else
                        YARNQUALITY = YARNQUALITY & "|" & ROW.Cells(GYARNQUALITY.Index).Value.ToString
                        PER = PER & "|" & Val(ROW.Cells(GPER.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(YARNQUALITY)
            alParaval.Add(PER)



            Dim gridsrno As String = ""
            Dim PROCESS As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPROCESS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(PSRNO.Index).Value.ToString
                        PROCESS = row.Cells(PPROCESS.Index).Value.ToString
                    Else
                        gridsrno = gridsrno & "|" & row.Cells(PSRNO.Index).Value.ToString
                        PROCESS = PROCESS & "|" & row.Cells(PPROCESS.Index).Value.ToString
                    End If
                End If
            Next


            alParaval.Add(gridsrno)
            alParaval.Add(PROCESS)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(FRMSTRING)

            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If
            alParaval.Add(TXTWARP.Text.Trim)
            alParaval.Add(TXTWEFT.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)



            If CMBGREYQUALITY.Text.Trim = "" Then
                alParaval.Add(cmbitemname.Text.Trim)
            Else
                alParaval.Add(CMBGREYQUALITY.Text.Trim)
            End If
            alParaval.Add(CMBBEAMNAME.Text.Trim)
            alParaval.Add(Val(TXTENDS.Text.Trim))
            alParaval.Add(Val(TXTTL.Text.Trim))
            alParaval.Add(Val(TXTBEAMWT.Text.Trim))
            alParaval.Add(Format(Val(TXTMTRS.Text.Trim), "0.00"))
            alParaval.Add(CMBQUALITY.Text.Trim)
            alParaval.Add(Format(Val(TXTWTMTRS.Text.Trim), "0.00"))
            alParaval.Add(Format(Val(TXTREEDSPACE.Text.Trim), "0"))
            alParaval.Add(TXTREED.Text.Trim)
            alParaval.Add(Format(Val(TXTQUALITYWT.Text.Trim), "0.00"))


            Dim WEFTSRNO As String = ""
            Dim WEFTCHANGE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDWEFTCHANGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If WEFTSRNO = "" Then
                        WEFTSRNO = Val(row.Cells(ESRNO.Index).Value)
                        WEFTCHANGE = row.Cells(EWEFTCHANGE.Index).Value.ToString
                    Else
                        WEFTSRNO = WEFTSRNO & "|" & Val(row.Cells(ESRNO.Index).Value)
                        WEFTCHANGE = WEFTCHANGE & "|" & row.Cells(EWEFTCHANGE.Index).Value.ToString
                    End If
                End If
            Next



            alParaval.Add(WEFTSRNO)
            alParaval.Add(WEFTCHANGE)


            Dim SRNO As String = ""
            Dim GRIDYARNQUALITY As String = ""
            Dim SHADE As String = ""
            Dim PICK As String = ""
            Dim GRIDWT As String = ""
            Dim WEFTGRIDNO As String = ""

            For i As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                If DT_WEFTDETAILS.Rows(i).Item(0) <> Nothing Then
                    If SRNO = "" Then
                        SRNO = Val(DT_WEFTDETAILS.Rows(i).Item("SRNO"))
                        GRIDYARNQUALITY = DT_WEFTDETAILS.Rows(i).Item("GRIDQUALITY")
                        SHADE = DT_WEFTDETAILS.Rows(i).Item("SHADE")
                        PICK = Val(DT_WEFTDETAILS.Rows(i).Item("PICK"))
                        GRIDWT = Val(DT_WEFTDETAILS.Rows(i).Item("GRIDWT"))
                        WEFTGRIDNO = Val(DT_WEFTDETAILS.Rows(i).Item("WEFTSRNO"))
                    Else
                        SRNO = SRNO & "|" & Val(DT_WEFTDETAILS.Rows(i).Item("SRNO"))
                        GRIDYARNQUALITY = GRIDYARNQUALITY & "|" & DT_WEFTDETAILS.Rows(i).Item("GRIDQUALITY")
                        SHADE = SHADE & "|" & DT_WEFTDETAILS.Rows(i).Item("SHADE")
                        PICK = PICK & "|" & Val(DT_WEFTDETAILS.Rows(i).Item("PICK"))
                        GRIDWT = GRIDWT & "|" & Val(DT_WEFTDETAILS.Rows(i).Item("GRIDWT"))
                        WEFTGRIDNO = WEFTGRIDNO & "|" & Val(DT_WEFTDETAILS.Rows(i).Item("WEFTSRNO"))
                    End If
                End If
            Next


            alParaval.Add(SRNO)
            alParaval.Add(GRIDYARNQUALITY)
            alParaval.Add(SHADE)
            alParaval.Add(PICK)
            alParaval.Add(GRIDWT)
            alParaval.Add(WEFTGRIDNO)


            alParaval.Add(TXTTOTALGRIDBEAMENDS.Text.Trim)
            alParaval.Add(TXTTOTALGRIDBEAMWT.Text.Trim)

            Dim BEAMSRNO As String = ""
            Dim GRIDBEAMNAME As String = ""
            Dim BEAMENDS As String = ""
            Dim BEAMTL As String = ""
            Dim GRIDBEAMWT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDBEAM.Rows
                If row.Cells(0).Value <> Nothing Then
                    If BEAMSRNO = "" Then
                        BEAMSRNO = Val(row.Cells(BSRNO.Index).Value)
                        GRIDBEAMNAME = row.Cells(BBEAMNAME.Index).Value.ToString
                        BEAMENDS = Val(row.Cells(BENDS.Index).Value)
                        BEAMTL = Val(row.Cells(BTL.Index).Value)
                        GRIDBEAMWT = Val(row.Cells(BBEAMWT.Index).Value)
                    Else
                        BEAMSRNO = BEAMSRNO & "|" & Val(row.Cells(BSRNO.Index).Value)
                        GRIDBEAMNAME = GRIDBEAMNAME & "|" & row.Cells(BBEAMNAME.Index).Value.ToString
                        BEAMENDS = BEAMENDS & "|" & Val(row.Cells(BENDS.Index).Value)
                        BEAMTL = BEAMTL & "|" & Val(row.Cells(BTL.Index).Value)
                        GRIDBEAMWT = GRIDBEAMWT & "|" & Val(row.Cells(BBEAMWT.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(BEAMSRNO)
            alParaval.Add(GRIDBEAMNAME)
            alParaval.Add(BEAMENDS)
            alParaval.Add(BEAMTL)
            alParaval.Add(GRIDBEAMWT)


            alParaval.Add(TXTTOTALPICKS.Text.Trim)
            alParaval.Add(TXTWEFTTL.Text.Trim)


            Dim objclsItemMaster As New clsItemmaster
            objclsItemMaster.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsItemMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPITEMID)
                IntResult = objclsItemMaster.UPDATE()
                MsgBox("Details Updated")

            End If
            EDIT = False

            CLEAR()
            cmbitemname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(cmbitemname.Text) <> LCase(TEMPITEMNAME)) Then
                dt = objclscommon.search("item_name", "", "ItemMaster", " and item_name = '" & cmbitemname.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBHSNCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBHSNCODE, "Fill HSN Code")
            bln = False
        End If

        If cmbitemname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbitemname, "Fill Item Name")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbitemname, "Item Name Already Exists")
            bln = False
        End If

        'If GRIDWEFTCHANGE.RowCount = 0 Then
        '    Ep.SetError(cmbitemname, "Enter Weft Change Details")
        '    bln = False
        'End If
        'If GRIDWEFT.RowCount = 0 Then
        '    Ep.SetError(cmbitemname, "Enter Weft Details")
        '    bln = False
        'End If

        If TXTDISPLAYNAME.Text.Trim.Length = 0 Then TXTDISPLAYNAME.Text = cmbitemname.Text.Trim
        If CMBCODE.Text.Trim.Length = 0 Then CMBCODE.Text = cmbitemname.Text.Trim
        If cmbmaterial.Text.Trim.Length = 0 Then cmbmaterial.Text = "Finished Goods"

        If Val(TXTTOTALPER.Text.Trim) <> 100 And GRIDCOMP.RowCount > 0 Then
            Ep.SetError(TXTTOTALPER, "Check %")
            bln = False
        End If

        Return bln
    End Function

    Sub CLEAR()

        cmbmaterial.Text = ""
        cmbcategory.Text = ""
        TXTDISPLAYNAME.Clear()
        cmbitemname.Text = ""
        CMBDEPARTMENT.Text = ""
        cmbunit.Text = ""
        CMBCODE.Text = ""
        TXTFOLD.Clear()
        TXTRATE.Clear()
        TXTVALUATIONRATE.Clear()
        TXTTRANSPORTRATE.Clear()
        TXTPACKINGRATE.Clear()
        TXTCHECKINGRATE.Clear()
        TXTDESIGNRATE.Clear()
        txtlower.Clear()
        txtreorder.Clear()
        txtupper.Clear()
        CMBHSNCODE.Text = ""
        TXTPHOTOIMGPATH.Clear()
        PBPHOTO.Image = Nothing
        txtremarks.Clear()
        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()
        CHKBLOCKED.CheckState = CheckState.Unchecked
        CHKHIDEINDESIGN.CheckState = CheckState.Unchecked

        TXTWIDTH.Clear()

        TXTGREYWIDTH.Clear()
        TXTSHRINKFROM.Clear()
        TXTSHRINKTO.Clear()
        TXTSELVEDGE.Clear()
        TXTWARP.Clear()
        TXTWEFT.Clear()

        CMBPROCESS.Text = ""
        TXTPSRNO.Clear()


        CMBGREYQUALITY.Text = ""
        CMBBEAMNAME.Text = ""
        TXTENDS.Clear()
        TXTTL.Clear()
        TXTBEAMWT.Clear()
        TXTMTRS.Clear()
        CMBQUALITY.Text = ""
        TXTWTMTRS.Clear()
        TXTREEDSPACE.Clear()
        TXTQUALITYWT.Clear()
        TXTREED.Clear()

        GRIDWEFTCHANGE.RowCount = 0
        GRIDWEFT.RowCount = 0
        TXTWEFTSRNO.Text = GRIDWEFTCHANGE.RowCount + 1
        CMBWEFTCHANGE.Text = ""
        TXTSRNO.Text = GRIDWEFT.RowCount + 1
        CMBGRIDQUALITY.Text = ""
        CMBSHADE.Text = ""
        TXTPICK.Clear()
        TXTGRIDWT.Clear()
        TXTTOTALWT.Clear()
        TXTTOTALPICKS.Clear()
        TXTWEFTTL.Clear()

        DT_WEFTDETAILS.Reset()
        DT_WEFTDETAILS.Columns.Add("SRNO")
        DT_WEFTDETAILS.Columns.Add("GRIDQUALITY")
        DT_WEFTDETAILS.Columns.Add("SHADE")
        DT_WEFTDETAILS.Columns.Add("PICK")
        DT_WEFTDETAILS.Columns.Add("GRIDWT")
        DT_WEFTDETAILS.Columns.Add("WEFTSRNO")


        GRIDRATE.RowCount = 0
        GRIDCOMP.RowCount = 0
        GRIDPROCESS.RowCount = 0

        TXTTOTALPER.Clear()

        GRIDDOUBLECLICK = False
        GRIDPROCESSDOUBLECLICK = False
        GRIDSTORESDOUBLECLICK = False
        GRIDWEFTDOUBLECLICK = False

        TXTBEAMSRNO.Text = GRIDBEAM.RowCount + 1
        CMBGRIDBEAM.Text = ""
        TXTGRIDENDS.Clear()
        TXTGRIDTL.Clear()
        TXTGRIDBEAMWT.Clear()
        TXTTOTALGRIDBEAMENDS.Clear()
        TXTTOTALGRIDBEAMWT.Clear()
        GRIDBEAM.RowCount = 0

    End Sub

    Private Sub CMBGREYQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGREYQUALITY.Enter
        Try
            If CMBGREYQUALITY.Text.Trim = "" Then fillitemname(CMBGREYQUALITY, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGREYQUALITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGREYQUALITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
                If OBJITEM.TEMPNAME <> "" Then CMBGREYQUALITY.Text = OBJITEM.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGREYQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGREYQUALITY.Validating
        Try
            If CMBGREYQUALITY.Text.Trim <> "" Then itemvalidate(CMBGREYQUALITY, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBEAMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBEAMNAME.Enter
        Try
            If CMBBEAMNAME.Text.Trim = "" Then FILLBEAM(CMBBEAMNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBEAMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBEAMNAME.Validating
        Try
            If CMBBEAMNAME.Text.Trim <> "" Then BEAMVALIDATE(CMBBEAMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBEAMNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBEAMNAME.Validated
        Try
            If CMBBEAMNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(BEAM_ENDS, 0) As ENDS, ISNULL(BEAM_TAPLINE, 0) As TAPLINE, ISNULL(BEAM_WTMTRS, 0) As BEAMWT, ISNULL(BEAM_TOTALENDS, 0) As TOTALENDS, ISNULL(BEAM_TOTALWT, 0) AS TOTALWT", "", "BEAMMASTER", "And BEAMMASTER.BEAM_NAME = '" & CMBBEAMNAME.Text.Trim & "' AND BEAM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTTL.Text = DT.Rows(0).Item("TAPLINE")
                    TXTENDS.Text = Val(DT.Rows(0).Item("TOTALENDS"))
                    TXTBEAMWT.Text = Val(DT.Rows(0).Item("TOTALWT"))
                End If
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBWEFTCHANGE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBWEFTCHANGE.Enter
        Try
            If CMBWEFTCHANGE.Text.Trim = "" Then FILLCOLOR(CMBWEFTCHANGE, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBWEFTCHANGE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBWEFTCHANGE.Validating
        Try
            If CMBWEFTCHANGE.Text.Trim <> "" Then COLORVALIDATE(CMBWEFTCHANGE, e, Me, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGRIDQUALITY.Enter
        Try
            If CMBGRIDQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBGRIDQUALITY, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGRIDQUALITY.Validating
        Try
            If CMBGRIDQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBGRIDQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Enter
        Try
            If cmbcategory.Text.Trim = "" Then fillCATEGORY(cmbcategory, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Enter
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        fillCATEGORY(cmbcategory, False)

        dt = objclscommon.search("item_name", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_name"
            cmbitemname.DataSource = dt
            cmbitemname.DisplayMember = "Item_name"
            cmbitemname.Text = ""
        End If


        dt = objclscommon.search("item_CODE", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_CODE"
            CMBCODE.DataSource = dt
            CMBCODE.DisplayMember = "Item_CODE"
            CMBCODE.Text = ""
        End If

        If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)


        If CMBQUALITY.Text = "" Then fillYARNQUALITY(CMBQUALITY, EDIT)
        If CMBGRIDQUALITY.Text = "" Then fillYARNQUALITY(CMBGRIDQUALITY, EDIT)
        If CMBWEFTCHANGE.Text = "" Then FILLCOLOR(CMBWEFTCHANGE, "")
        If CMBSHADE.Text = "" Then FILLCOLOR(CMBSHADE, "")
        If CMBGREYQUALITY.Text = "" Then fillitemname(CMBGREYQUALITY, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        If CMBBEAMNAME.Text = "" Then FILLBEAM(CMBBEAMNAME, EDIT)


    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
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
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            cmbitemname.Text = TEMPITEMNAME
            CMBCODE.Text = TEMPITEMCODE

            If FRMSTRING = "MERCHANT" Then
                cmbmaterial.Visible = False
                lblmaterial.Visible = False
                cmbmaterial.Text = "Finished Goods"
            End If

            If EDIT = True Then

                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search(" ITEMMASTER.item_id AS ITEMID, MATERIALTYPEMASTER.material_name AS MATERIALTYPE, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.ITEM_BLOCKED, 0) AS BLOCKED, ISNULL(ITEMMASTER.ITEM_HIDEINDESIGN, 0) AS HIDEINDESIGN, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ITEMMASTER.item_reorder AS REORDER, ITEMMASTER.ITEM_FOLD AS FOLD, ITEMMASTER.ITEM_RATE AS RATE, ITEMMASTER.ITEM_VALUATIONRATE AS VALUATIONRATE, ITEMMASTER.ITEM_TRANSRATE AS TRANSPORTRATE, ITEMMASTER.ITEM_CHECKRATE AS CHECKINGRATE, ITEMMASTER.ITEM_PACKRATE AS PACKINGRATE, ITEMMASTER.ITEM_DESIGNRATE AS DESIGNRATE, ITEMMASTER.item_upper AS UPPER, ITEMMASTER.item_lower AS LOWER, ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_GREYWIDTH, '') AS GREYWIDTH, ISNULL(ITEMMASTER.ITEM_SHRINKFROM, 0) AS SHRINKFROM, ISNULL(ITEMMASTER.ITEM_SHRINKTO, 0) AS SHRINKTO, ISNULL(ITEMMASTER.ITEM_SELVEDGE, '') AS SELVEDGE, ISNULL(ITEMMASTER.item_remarks, '') AS REMARKS, ITEMMASTER.ITEM_PHOTO AS IMGPATH, ISNULL(ITEMMASTER.ITEM_WARP, '') AS WARP, ISNULL(ITEMMASTER.ITEM_WEFT, '') AS WEFT, ISNULL(ITEMMASTER.ITEM_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(EFFECTITEMMASTER.item_name, '') AS EFFECTIVEQUALITY, ISNULL(BEAMMASTER.BEAM_NAME, '') AS BEAMNAME, ISNULL(BEAMMASTER.BEAM_TOTALENDS, 0) AS TOTALENDS, ISNULL(BEAMMASTER.BEAM_TAPLINE, 0) AS TAPLINE, ISNULL(BEAMMASTER.BEAM_TOTALWT, 0) AS TOTALWT, ISNULL(ITEMMASTER.ITEM_MTRS, 0) AS MTRS, ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS QUALITY, ISNULL(ITEMMASTER.ITEM_WTMTRS, 0) AS WTMTRS, ISNULL(ITEMMASTER.ITEM_REEDSPACE, 0) AS REEDSPACE, ISNULL(ITEMMASTER.ITEM_REED, 0) AS REED, ISNULL(ITEMMASTER.ITEM_QUALITYWT, 0) AS QUALITYWT, ISNULL(ITEMMASTER_WEFTCHANGE.ITEM_SRNO, 0) AS SRNO, ISNULL(COLORMASTER.COLOR_name, '') AS WEFTCHANGE ,  ISNULL(ITEMMASTER.ITEM_TOTALPICKS, 0) AS TOTALPICKS, ISNULL(ITEMMASTER.ITEM_WEFTTL, 0) AS WEFTTL", "", " ITEMMASTER  LEFT OUTER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN ITEMMASTER_WEFTCHANGE ON ITEMMASTER_WEFTCHANGE.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON ITEMMASTER_WEFTCHANGE.ITEM_WEFTCHANGEID = COLORMASTER.COLOR_id LEFT OUTER JOIN YARNQUALITYMASTER ON ITEMMASTER.ITEM_WEFTQUALITYID = YARNQUALITYMASTER.YARN_ID LEFT OUTER JOIN ITEMMASTER AS EFFECTITEMMASTER ON ITEMMASTER.ITEM_EFFECTQUALITYID = EFFECTITEMMASTER.item_id LEFT OUTER JOIN BEAMMASTER ON ITEMMASTER.ITEM_BEAMID = BEAMMASTER.BEAM_ID ", " and ITEMMASTER.Item_Name = '" & TEMPITEMNAME & "' AND ITEMMASTER.ITEM_FRMSTRING = '" & FRMSTRING & "' and ITEMMASTER.Item_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        TEMPITEMID = ROW("ITEMID")
                        cmbmaterial.Text = ROW("MATERIALTYPE").ToString
                        cmbcategory.Text = ROW("CATEGORY").ToString
                        TXTDISPLAYNAME.Text = ROW("DISPLAYNAME").ToString
                        cmbitemname.Text = ROW("ITEMNAME").ToString
                        CMBCODE.Text = ROW("ITEMCODE").ToString
                        TEMPITEMCODE = ROW("ITEMCODE").ToString
                        cmbunit.Text = ROW("UNIT").ToString
                        CMBDEPARTMENT.Text = ROW("DEPARTMENT").ToString
                        txtreorder.Text = Val(ROW("REORDER").ToString)
                        TXTFOLD.Text = ROW("FOLD").ToString
                        TXTRATE.Text = Val(ROW("RATE").ToString)
                        TXTVALUATIONRATE.Text = Val(ROW("VALUATIONRATE").ToString)
                        TXTTRANSPORTRATE.Text = Val(ROW("TRANSPORTRATE").ToString)
                        TXTCHECKINGRATE.Text = Val(ROW("CHECKINGRATE").ToString)
                        TXTPACKINGRATE.Text = Val(ROW("PACKINGRATE").ToString)
                        TXTDESIGNRATE.Text = Val(ROW("DESIGNRATE").ToString)
                        txtupper.Text = Val(ROW("UPPER").ToString)
                        txtlower.Text = Val(ROW("LOWER").ToString)
                        CMBHSNCODE.Text = ROW("HSNCODE").ToString
                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        CHKHIDEINDESIGN.Checked = Convert.ToBoolean(dttable.Rows(0).Item("HIDEINDESIGN"))

                        TXTWIDTH.Text = ROW("WIDTH").ToString
                        TXTGREYWIDTH.Text = ROW("GREYWIDTH").ToString
                        TXTSHRINKFROM.Text = Val(ROW("SHRINKFROM"))
                        TXTSHRINKTO.Text = Val(ROW("SHRINKTO"))
                        TXTSELVEDGE.Text = ROW("SELVEDGE").ToString

                        txtremarks.Text = ROW("REMARKS").ToString
                        If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                            PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                            TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                        Else
                            PBPHOTO.Image = Nothing
                            TXTWARP.Text = ROW("WARP").ToString
                            TXTWEFT.Text = ROW("WEFT").ToString
                        End If

                        CMBGREYQUALITY.Text = ROW("EFFECTIVEQUALITY")
                        CMBBEAMNAME.Text = ROW("BEAMNAME")
                        TXTENDS.Text = ROW("TOTALENDS")
                        TXTTL.Text = ROW("TAPLINE")
                        TXTBEAMWT.Text = ROW("TOTALWT")
                        TXTMTRS.Text = ROW("MTRS")
                        CMBQUALITY.Text = ROW("QUALITY")
                        TXTWTMTRS.Text = ROW("WTMTRS")
                        TXTREEDSPACE.Text = ROW("REEDSPACE")
                        TXTREED.Text = ROW("REED")
                        TXTQUALITYWT.Text = ROW("QUALITYWT")

                        If ROW("WEFTCHANGE") <> "" Then GRIDWEFTCHANGE.Rows.Add(Val(ROW("SRNO")), ROW("WEFTCHANGE"))
                        TXTTOTALPICKS.Text = ROW("TOTALPICKS")
                        TXTWEFTTL.Text = ROW("WEFTTL")
                    Next



                    'CHARGES GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dttable1 As DataTable = OBJCMN.search(" ISNULL(YARNQUALITYMASTER.YARN_NAME, '') AS YARNQUALITY, ISNULL(ITEMMASTER_COMPOSITION.ITEM_PER, 0) AS PER ", "", " YARNQUALITYMASTER INNER JOIN ITEMMASTER_COMPOSITION ON YARNQUALITYMASTER.YARN_ID = ITEMMASTER_COMPOSITION.ITEM_YARNQUALITYID RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_COMPOSITION.ITEM_YEARID = ITEMMASTER.item_yearid AND ITEMMASTER_COMPOSITION.ITEM_ID = ITEMMASTER.item_id ", " AND ITEMMASTER_COMPOSITION.ITEM_ID = " & TEMPITEMID & " AND ITEMMASTER_COMPOSITION.ITEM_YEARID = " & YearId)
                    If dttable1.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable1.Rows
                            GRIDCOMP.Rows.Add(DTR("YARNQUALITY"), DTR("PER"))
                        Next
                        TOTAL()
                    End If


                    'PROCESS GRID
                    Dim dt As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER_PROCESS.ITEM_SRNO, 0) AS GRIDSRNO, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS", "", "  PROCESSMASTER LEFT OUTER JOIN ITEMMASTER_PROCESS ON PROCESSMASTER.PROCESS_ID = ITEMMASTER_PROCESS.ITEM_PROCESSID ", " AND ITEMMASTER_PROCESS.ITEM_ID = " & TEMPITEMID & " AND ITEMMASTER_PROCESS.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In dt.Rows
                            GRIDPROCESS.Rows.Add(DTR1("GRIDSRNO"), DTR1("PROCESS"))
                        Next
                    End If

                    'WEFT QUALITY GRID
                    Dim d As DataTable = OBJCMN.search(" ITEMMASTER_QUALITYDESC.ITEM_SRNO AS SRNO, YARNQUALITYMASTER.YARN_NAME AS GRIDQUALITY, ISNULL(COLORMASTER.COLOR_name,'') AS SHADE, ITEMMASTER_QUALITYDESC.ITEM_PICK AS PICK, ITEMMASTER_QUALITYDESC.ITEM_GRIDWT AS GRIDWT, ITEMMASTER_QUALITYDESC.ITEM_WEFTSRNO AS WEFTSRNO,  ITEMMASTER.item_id ", "", " ITEMMASTER_QUALITYDESC INNER JOIN ITEMMASTER ON ITEMMASTER_QUALITYDESC.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON ITEMMASTER_QUALITYDESC.ITEM_SHADEID = COLORMASTER.COLOR_id LEFT OUTER JOIN YARNQUALITYMASTER ON ITEMMASTER_QUALITYDESC.ITEM_GRIDQUALITYID = YARNQUALITYMASTER.YARN_ID ", " AND ITEMMASTER.item_id=" & TEMPITEMID & " AND ITEMMASTER_QUALITYDESC.ITEM_YEARID=" & YearId & " ORDER BY  ITEMMASTER_QUALITYDESC.ITEM_SRNO ")
                    If d.Rows.Count > 0 Then
                        For Each DR As DataRow In d.Rows
                            DT_WEFTDETAILS.Rows.Add(Val(DR("SRNO")), DR("GRIDQUALITY"), DR("SHADE"), Format(DR("PICK"), "0.00"), Format(DR("GRIDWT"), "0.00"), Val(DR("WEFTSRNO")))
                        Next
                    End If

                    'BEAM DETAIL GRID
                    ' Dim OBJPO As New ClsCommon
                    ' Dim dtt = OBJPO.search("ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_BEAMSRNO, 0) AS BEAMSRNO, ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_BEAMENDS, 0) AS BEAMENDS, ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_BEAMTL, 0) AS BEAMTL, ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_GRIDBEAMWT, 0) AS BEAMWT, ISNULL(BEAMMASTER.BEAM_NAME, '') AS GRIDBEAM ", "", "ITEMMASTER_BEAMDETAILS RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_BEAMDETAILS.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN BEAMMASTER ON ITEMMASTER_BEAMDETAILS.ITEM_GRIDBEAMID = BEAMMASTER.BEAM_ID ", " AND ITEMMASTER_BEAMDETAILS.item_id=" & TEMPITEMID & " AND ITEMMASTER_BEAMDETAILS.ITEM_YEARID=" & YearId & " ORDER BY  ITEMMASTER_BEAMDETAILS.ITEM_BEAMSRNO ")
                    Dim dtt As DataTable = OBJCMN.search("ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_BEAMSRNO, 0) AS BEAMSRNO, ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_BEAMENDS, 0) AS BEAMENDS, ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_BEAMTL, 0) AS BEAMTL, ISNULL(ITEMMASTER_BEAMDETAILS.ITEM_GRIDBEAMWT, 0) AS BEAMWT, ISNULL(BEAMMASTER.BEAM_NAME, '') AS GRIDBEAM ", "", "ITEMMASTER_BEAMDETAILS RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_BEAMDETAILS.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN BEAMMASTER ON ITEMMASTER_BEAMDETAILS.ITEM_GRIDBEAMID = BEAMMASTER.BEAM_ID ", " AND ITEMMASTER_BEAMDETAILS.item_id=" & TEMPITEMID & " AND ITEMMASTER_BEAMDETAILS.ITEM_YEARID=" & YearId & " ORDER BY  ITEMMASTER_BEAMDETAILS.ITEM_BEAMSRNO ")
                    If dtt.Rows.Count > 0 Then
                        For Each DR1 As DataRow In dtt.Rows
                            GRIDBEAM.Rows.Add(Val(DR1("BEAMSRNO")), DR1("GRIDBEAM"), Format(DR1("BEAMENDS"), "0.00"), Format(DR1("BEAMTL"), "0.00"), Format(DR1("BEAMWT"), "0.00"))
                        Next
                        TOTAL()
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_name", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_name"
                    cmbitemname.DataSource = dt
                    cmbitemname.DisplayMember = "Item_name"
                    cmbitemname.Text = ""
                End If
                cmbitemname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Validated
        Try
            If CMBCODE.Text.Trim = "" And cmbitemname.Text.Trim <> "" Then CMBCODE.Text = cmbitemname.Text.Trim
            If TXTDISPLAYNAME.Text.Trim = "" And cmbitemname.Text.Trim <> "" Then TXTDISPLAYNAME.Text = cmbitemname.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        If cmbitemname.Text.Trim <> "" Then
            uppercase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(cmbitemname.Text) <> LCase(TEMPITEMNAME)) Then
                dt = objclscommon.search("item_name", "", "ItemMaster", " and item_name = '" & cmbitemname.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        '**** code for to delete the selected imtem from item master *****
        ' ****Logic 
        ' looking for in SalesOrder_Desc Table if Item master Name is Exists OR Not
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If cmbitemname.Text.Trim = "" Then
            MsgBox("Item Name Can Not Be Blank ")
            Exit Sub
        End If

        If EDIT = False Then
            'since user can delete Master only in edit mode
            MsgBox("Item Name Can Delete only in Edit Mode", MsgBoxStyle.Critical, "PROTRADE")
            Exit Sub
        End If
        If cmbitemname.Text.Trim <> "" Then
            pcase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("item_name", "", " dbo.ITEMMASTER RIGHT OUTER JOIN  dbo.SALEORDER_DESC ON dbo.ITEMMASTER.item_id = dbo.SALEORDER_DESC.so_itemid ", " and item_name = '" & cmbitemname.Text.Trim & "' AND item_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If

            dt = objclscommon.search("ITEMNAME", "", " BARCODESTOCK ", " and ITEMNAME = '" & cmbitemname.Text.Trim & "' AND YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If

            dt = objclscommon.search("ITEMNAME", "", " OUTBARCODESTOCK ", " and ITEMNAME = '" & cmbitemname.Text.Trim & "' AND YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "PROTRADE")
                Exit Sub
            End If

        End If
        'Dim tempMsg As Integer
        ''if above all conditions are false then only user can delete Particular Master
        If MsgBox("Delete Item Name ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim alParaval As New ArrayList
            alParaval.Add(cmbitemname.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(YearId)
            Dim clsitemst As New clsItemmaster
            clsitemst.alParaval = alParaval
            IntResult = clsitemst.Delete()
            MsgBox("Item Deleted")
            CLEAR()
            EDIT = False
        End If

    End Sub

    Private Sub CMBDEPARTMENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_CODE", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "Item_CODE"
                    CMBCODE.Text = ""
                End If
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                uppercase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBCODE.Text) <> LCase(TEMPITEMCODE)) Then
                    dt = objclscommon.search("item_CODE", "", "ItemMaster", " and item_CODE = '" & CMBCODE.Text.Trim & "' And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Item Code Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGRIDRATE.KeyPress, TXTMTRS.KeyPress, TXTWTMTRS.KeyPress, TXTPICK.KeyPress, TXTRATE.KeyPress, TXTGRIDWT.KeyPress, TXTSHRINKFROM.KeyPress, TXTSHRINKTO.KeyPress, TXTPER.KeyPress, TXTVALUATIONRATE.KeyPress, TXTWEFTTL.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBWEFTCHANGE_Validated(sender As Object, e As EventArgs) Handles CMBWEFTCHANGE.Validated
        Try
            If CMBWEFTCHANGE.Text.Trim <> "" Then
                If Not CHECKWEFTCHANGE() Then
                    MsgBox("Matching already Present in Grid below ")
                    Exit Sub
                End If

                FILLWEFTCHANGEGRID()
                CMBWEFTCHANGE.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKWEFTCHANGE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each ROW As DataGridViewRow In GRIDWEFTCHANGE.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> ROW.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBWEFTCHANGE.Text.Trim = ROW.Cells(EWEFTCHANGE.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub FILLWEFTCHANGEGRID()
        If GRIDDOUBLECLICK = False Then
            GRIDWEFTCHANGE.Rows.Add(TXTWEFTSRNO.Text, CMBWEFTCHANGE.Text.Trim)
            getsrno(GRIDWEFTCHANGE)

        ElseIf GRIDDOUBLECLICK = True Then
            GRIDWEFTCHANGE.Item(ESRNO.Index, TEMPROW).Value = TXTSRNO.Text
            GRIDWEFTCHANGE.Item(EWEFTCHANGE.Index, TEMPROW).Value = CMBWEFTCHANGE.Text.Trim
            GRIDDOUBLECLICK = False
        End If
        GRIDWEFTCHANGE.FirstDisplayedScrollingRowIndex = GRIDWEFTCHANGE.RowCount - 1

        GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.RowCount - 1).Selected = True
        GRIDWEFTCHANGE.CurrentCell = GRIDWEFTCHANGE.Item(0, GRIDWEFTCHANGE.RowCount - 1)
        TXTWEFTSRNO.Text = GRIDWEFTCHANGE.RowCount + 1

        GRIDWEFT.RowCount = 0
        TXTSRNO.Text = GRIDWEFT.RowCount + 1

        CMBWEFTCHANGE.Text = ""
        CMBGRIDQUALITY.Focus()

    End Sub

    Sub FILLWEFTGRID()
        If GRIDWEFTDOUBLECLICK = False Then
            GRIDWEFT.Rows.Add(TXTSRNO.Text, CMBGRIDQUALITY.Text.Trim, CMBSHADE.Text.Trim, Val(TXTPICK.Text.Trim), Val(TXTGRIDWT.Text.Trim), GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(GSRNO.Index).Value)
            DT_WEFTDETAILS.Rows.Add(Val(TXTSRNO.Text), CMBGRIDQUALITY.Text.Trim, CMBSHADE.Text.Trim, Val(TXTPICK.Text.Trim), Val(TXTGRIDWT.Text), GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(0).Value)
            getsrno(GRIDWEFT)

        ElseIf GRIDWEFTDOUBLECLICK = True Then
            For I As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                If GRIDWEFT.Item(GSRNO.Index, TEMPWEFTROW).Value = DT_WEFTDETAILS.Rows(I).Item("SRNO") And GRIDWEFT.Item(GWEFTSRNO.Index, TEMPWEFTROW).Value = DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO") Then
                    DT_WEFTDETAILS.Rows(I).Item("GRIDQUALITY") = CMBGRIDQUALITY.Text
                    DT_WEFTDETAILS.Rows(I).Item("SHADE") = CMBSHADE.Text.Trim
                    DT_WEFTDETAILS.Rows(I).Item("PICK") = Val(TXTPICK.Text.Trim)
                    DT_WEFTDETAILS.Rows(I).Item("GRIDWT") = Val(TXTGRIDWT.Text.Trim)
                End If
            Next
LINE1:
            GRIDWEFT.Item(GYARNQUALITY.Index, TEMPWEFTROW).Value = CMBGRIDQUALITY.Text.Trim
            GRIDWEFT.Item(GSHADE.Index, TEMPWEFTROW).Value = CMBSHADE.Text.Trim
            GRIDWEFT.Item(GPICK.Index, TEMPWEFTROW).Value = Val(TXTPICK.Text.Trim)
            GRIDWEFT.Item(GWTPER.Index, TEMPWEFTROW).Value = Val(TXTGRIDWT.Text.Trim)

            GRIDWEFTDOUBLECLICK = False
        End If
        TXTSRNO.Text = GRIDWEFT.RowCount + 1
        CMBGRIDQUALITY.Text = ""
        CMBSHADE.Text = ""
        TXTPICK.Clear()
        TXTGRIDWT.Clear()

        CMBGRIDQUALITY.Focus()
    End Sub

    Private Sub GRIDWEFTCHANGE_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWEFTCHANGE.CellClick
        Try
            If GRIDWEFTCHANGE.Rows.Count > 0 Then
                GRIDWEFT.RowCount = 0
                GRIDWEFTDOUBLECLICK = False
                For i As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                    If DT_WEFTDETAILS.Rows(i).Item("WEFTSRNO") = GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(0).Value Then
                        GRIDWEFT.Rows.Add(DT_WEFTDETAILS.Rows(i).Item("SRNO"), DT_WEFTDETAILS.Rows(i).Item("GRIDQUALITY"), DT_WEFTDETAILS.Rows(i).Item("SHADE"), DT_WEFTDETAILS.Rows(i).Item("PICK"), DT_WEFTDETAILS.Rows(i).Item("GRIDWT"), DT_WEFTDETAILS.Rows(i).Item("WEFTSRNO"))
                    End If
                Next
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFTCHANGE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWEFTCHANGE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDWEFTCHANGE.Item(EWEFTCHANGE.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                TXTSRNO.Text = GRIDWEFTCHANGE.Item(ESRNO.Index, e.RowIndex).Value
                CMBWEFTCHANGE.Text = GRIDWEFTCHANGE.Item(EWEFTCHANGE.Index, e.RowIndex).Value
                CMBWEFTCHANGE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFTCHANGE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDWEFTCHANGE.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
LINE1:
                For I As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                    If GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(ESRNO.Index).Value = Val(DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO")) Then
                        DT_WEFTDETAILS.Rows.RemoveAt(I)
                        GoTo LINE1
                    End If
                Next
                For I As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                    If GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(ESRNO.Index).Value < Val(DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO")) Then
                        DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO") = Val(DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO")) - 1
                    End If
                Next
                GRIDWEFTCHANGE.Rows.RemoveAt(GRIDWEFTCHANGE.CurrentRow.Index)
                GRIDWEFT.RowCount = 0

                getsrno(GRIDWEFTCHANGE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDWT_Validated(sender As Object, e As EventArgs) Handles TXTGRIDWT.Validated
        Try
            If CMBGRIDQUALITY.Text.Trim <> "" And GRIDWEFTCHANGE.RowCount > 0 And Val(TXTGRIDWT.Text.Trim) > 0 Then
                FILLWEFTGRID()
                TOTAL()
                CMBGRIDQUALITY.Text = ""
                CMBSHADE.Text = ""
                TXTGRIDWT.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFT_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWEFT.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDWEFT.Item(GYARNQUALITY.Index, e.RowIndex).Value <> Nothing Then
                GRIDWEFTDOUBLECLICK = True
                TEMPWEFTROW = e.RowIndex
                TXTSRNO.Text = Val(GRIDWEFT.Item(GSRNO.Index, e.RowIndex).Value)
                CMBGRIDQUALITY.Text = GRIDWEFT.Item(GWEFTQUALITY.Index, e.RowIndex).Value
                CMBSHADE.Text = GRIDWEFT.Item(GSHADE.Index, e.RowIndex).Value
                TXTPICK.Text = Val(GRIDWEFT.Item(GPICK.Index, e.RowIndex).Value)
                TXTGRIDWT.Text = Val(GRIDWEFT.Item(GWTPER.Index, e.RowIndex).Value)

                CMBGRIDQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWEFT_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDWEFT.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Dim del As Boolean = False
                If GRIDWEFT.RowCount > 0 Then
                    Dim row As Integer = GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(ESRNO.Index).Value
                    For I As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                        If GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(ESRNO.Index).Value = Val(DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO")) And GRIDWEFT.Rows(GRIDWEFT.CurrentRow.Index).Cells(GSRNO.Index).Value = Val(DT_WEFTDETAILS.Rows(I).Item("SRNO")) Then
                            If del = False Then
                                DT_WEFTDETAILS.Rows.RemoveAt(I)
                                GRIDWEFT.Rows.RemoveAt(GRIDWEFT.CurrentRow.Index)
                                del = True
                                GoTo line1
                            End If
                        End If
                    Next
line1:
                    For I As Integer = 0 To DT_WEFTDETAILS.Rows.Count - 1
                        If GRIDWEFTCHANGE.Rows(GRIDWEFTCHANGE.CurrentRow.Index).Cells(ESRNO.Index).Value = Val(DT_WEFTDETAILS.Rows(I).Item("WEFTSRNO")) And del = True And row < Val(DT_WEFTDETAILS.Rows(I).Item(GSRNO.Index)) Then
                            DT_WEFTDETAILS.Rows(I).Item("SRNO") = Val(DT_WEFTDETAILS.Rows(I).Item("SRNO")) - 1
                        End If
                    Next
                    getsrno(GRIDWEFT)
                    TOTAL()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREEDSPACE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTREEDSPACE.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICK_Validated(sender As Object, e As EventArgs) Handles TXTPICK.Validated, CMBGRIDQUALITY.Validated, TXTREEDSPACE.Validated
        Try
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If GRIDBEAM.RowCount = 0 Then Exit Sub
            If CMBGRIDQUALITY.Text.Trim <> "" And Val(TXTPICK.Text.Trim) > 0 And Val(TXTREEDSPACE.Text.Trim) > 0 And Val(TXTWEFTTL.Text.Trim) > 0 And Val(TXTTOTALGRIDBEAMWT.Text.Trim) > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(YARN_DENIER,0) AS DENIER", "", " YARNQUALITYMASTER ", " AND YARN_NAME = '" & CMBGRIDQUALITY.Text.Trim & "' AND YARN_YEARID = " & YearId)
                TXTGRIDWT.Text = Format((Val(TXTREEDSPACE.Text.Trim) * Val(TXTPICK.Text.Trim) * Val(TXTWEFTTL.Text.Trim) * Val(DT.Rows(0).Item("DENIER"))) / 9000000, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkRATETYPE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDRATE.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If cmbratetype.Text.Trim = row.Cells(gratetype.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDRATE.Rows.Add(cmbratetype.Text.Trim, Val(TXTGRIDRATE.Text.Trim))
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDRATE.Item("GRATETYPE", TEMPROW).Value = cmbratetype.Text.Trim
            GRIDRATE.Item("GRATE", TEMPROW).Value = Val(TXTGRIDRATE.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        GRIDRATE.ClearSelection()

    End Sub

    Private Sub GRIDRATE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRATE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDRATE.Item("GRATETYPE", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                cmbratetype.Text = GRIDRATE.Item("GRATETYPE", e.RowIndex).Value
                TXTGRIDRATE.Text = GRIDRATE.Item("GRATE", e.RowIndex).Value
                cmbratetype.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRATE.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDRATE.Rows.RemoveAt(GRIDRATE.CurrentRow.Index)
        End If
    End Sub

    Private Sub CMDPHOTOUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub CMDPHOTOREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOREMOVE.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOVIEW.Click
        Try
            If TXTPHOTOIMGPATH.Text.Trim <> "" Then
                If Path.GetExtension(TXTPHOTOIMGPATH.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(TXTPHOTOIMGPATH.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBPHOTO.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHSNCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBHSNCODE.Text = OBJLEDGER.TEMPCODE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBYARNQUALITY.Enter
        Try
            If CMBYARNQUALITY.Text.Trim = "" Then fillYARNQUALITY(CMBYARNQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBYARNQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBYARNQUALITY.Validating
        Try
            If CMBYARNQUALITY.Text.Trim <> "" Then YARNQUALITYVALIDATE(CMBYARNQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPER.Validating
        Try
            If Val(TXTPER.Text.Trim) < 0 And Val(TXTPER.Text.Trim) > 100 Then e.Cancel = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPER.Validated
        Try
            If Val(TXTPER.Text.Trim) > 0 And CMBYARNQUALITY.Text.Trim <> "" Then
                If Not checkPERTYPE() Then
                    MsgBox("% already Present in Grid below")
                    Exit Sub
                End If

                fillgridCOMP()
                TOTAL()

                CMBYARNQUALITY.Text = ""
                TXTPER.Clear()
                CMBYARNQUALITY.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridCOMP()

        If GRIDDOUBLECLICK = False Then
            GRIDCOMP.Rows.Add(CMBYARNQUALITY.Text.Trim, Val(TXTPER.Text.Trim))
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDCOMP.Item("GYARNQUALITY", TEMPROW).Value = CMBYARNQUALITY.Text.Trim
            GRIDCOMP.Item("GPER", TEMPROW).Value = Val(TXTPER.Text.Trim)
            GRIDDOUBLECLICK = False
        End If

        TOTAL()
        CMBYARNQUALITY.Text = ""
        TXTPER.Clear()

        GRIDCOMP.ClearSelection()

    End Sub

    Function checkPERTYPE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDCOMP.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBYARNQUALITY.Text.Trim = row.Cells(GYARNQUALITY.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDCOMP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCOMP.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCOMP.Item("GYARNQUALITY", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                CMBYARNQUALITY.Text = GRIDCOMP.Item("GYARNQUALITY", e.RowIndex).Value
                TXTPER.Text = GRIDCOMP.Item("GPER", e.RowIndex).Value
                CMBYARNQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCOMP.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDCOMP.Rows.RemoveAt(GRIDCOMP.CurrentRow.Index)
        End If
    End Sub

    Sub TOTAL()
        Try
            TXTQUALITYWT.Text = 0.0
            TXTTOTALWT.Text = 0.0
            TXTTOTALPER.Text = "0.00"
            TXTTOTALGRIDBEAMWT.Text = 0.0
            TXTTOTALGRIDBEAMENDS.Text = 0.0
            TXTTOTALPICKS.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDCOMP.Rows
                TXTTOTALPER.Text = Format(Val(TXTTOTALPER.Text) + Val(ROW.Cells(GPER.Index).EditedFormattedValue), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDBEAM.Rows
                TXTTOTALGRIDBEAMENDS.Text = Format(Val(TXTTOTALGRIDBEAMENDS.Text.Trim) + Val(ROW.Cells(BENDS.Index).Value), "0.00")
                TXTTOTALGRIDBEAMWT.Text = Format(Val(TXTTOTALGRIDBEAMWT.Text.Trim) + Val(ROW.Cells(BBEAMWT.Index).Value), "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDWEFT.Rows
                TXTTOTALWT.Text = Format(Val(TXTTOTALWT.Text.Trim) + Val(ROW.Cells(GWTPER.Index).Value), "0.00")
                TXTTOTALPICKS.Text = Format(Val(TXTTOTALPICKS.Text.Trim) + Val(ROW.Cells(GPICK.Index).Value), "0.00")
            Next

            TXTQUALITYWT.Text = Format(Val(TXTBEAMWT.Text) + Val(TXTWTMTRS.Text), "0.00")
            TXTQUALITYWT.Text = Format(Val(TXTTOTALGRIDBEAMWT.Text) + Val(TXTWTMTRS.Text), "0.00")
            TXTQUALITYWT.Text = Format(Val(TXTTOTALGRIDBEAMWT.Text) + Val(TXTTOTALWT.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBPROCESS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Enter
        Try
            If CMBPROCESS.Text.Trim = "" Then FILLPROCESS(CMBPROCESS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROCESS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROCESS.Validating
        Try
            If CMBPROCESS.Text.Trim <> "" Then PROCESSVALIDATE(CMBPROCESS, e, Me)
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

    Sub fillPROCESSgrid()

        If GRIDPROCESSDOUBLECLICK = False Then
            GRIDPROCESS.Rows.Add(Val(TXTPSRNO.Text.Trim), CMBPROCESS.Text.Trim)
            getsrno(GRIDPROCESS)
        ElseIf GRIDPROCESSDOUBLECLICK = True Then
            GRIDPROCESS.Item("PSRNO", TEMPPROW).Value = Val(TXTPSRNO.Text.Trim)
            GRIDPROCESS.Item("PPROCESS", TEMPPROW).Value = CMBPROCESS.Text.Trim
            TEMPPROW = GRIDPROCESS.CurrentRow.Index
            TXTPSRNO.Focus()
            GRIDPROCESSDOUBLECLICK = False
        End If
        CMBPROCESS.Text = ""
        GRIDPROCESS.ClearSelection()

    End Sub

    Private Sub CMBPROCESS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPROCESS.Validated
        If CMBPROCESS.Text.Trim <> "" Then
            fillPROCESSgrid()
        Else
            If CMBPROCESS.Text.Trim = "" Then
                MsgBox("Enter Process Name....", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub TXTPSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTPSRNO.GotFocus
        TXTPSRNO.Text = Val(GRIDPROCESS.RowCount + 1)
    End Sub

    Private Sub GRIDPROCESS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPROCESS.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDPROCESS.Item("PPROCESS", e.RowIndex).Value <> Nothing Then
                GRIDPROCESSDOUBLECLICK = True
                TEMPPROW = e.RowIndex
                TXTPSRNO.Text = Val(GRIDPROCESS.Item("PSRNO", e.RowIndex).Value)
                CMBPROCESS.Text = GRIDPROCESS.Item("PPROCESS", e.RowIndex).Value
                CMBPROCESS.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROCESS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPROCESS.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDPROCESS.Rows.RemoveAt(GRIDPROCESS.CurrentRow.Index)
            getsrno(GRIDPROCESS)
        End If
    End Sub

    Private Sub TXTTRANSPORTRATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTRANSPORTRATE.KeyPress, TXTDESIGNRATE.KeyPress, TXTPACKINGRATE.KeyPress, TXTCHECKINGRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTWTMTRS_Validated(sender As Object, e As EventArgs) Handles TXTWTMTRS.Validated, TXTBEAMWT.Validated
        TOTAL()
    End Sub

    Private Sub CMBSHADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORVALIDATE(CMBSHADE, e, Me, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(sender As Object, e As EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBGRIDBEAM_Enter(sender As Object, e As EventArgs) Handles CMBGRIDBEAM.Enter
        Try
            If CMBGRIDBEAM.Text.Trim = "" Then FILLBEAM(CMBGRIDBEAM, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDBEAM_Validated(sender As Object, e As EventArgs) Handles CMBGRIDBEAM.Validated
        Try
            If CMBGRIDBEAM.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(BEAM_ENDS, 0) AS GRIDENDS, ISNULL(BEAM_TAPLINE, 0) AS GRIDTL, ISNULL(BEAM_WTMTRS, 0) AS BEAMWT, ISNULL(BEAM_TOTALENDS, 0) AS TOTALENDS, ISNULL(BEAM_TOTALWT, 0) AS GRIDBEAMWT ", "", "BEAMMASTER", "And BEAMMASTER.BEAM_NAME = '" & CMBGRIDBEAM.Text.Trim & "' AND BEAM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTGRIDTL.Text = DT.Rows(0).Item("GRIDTL")
                    TXTGRIDENDS.Text = Val(DT.Rows(0).Item("TOTALENDS"))
                    TXTGRIDBEAMWT.Text = Val(DT.Rows(0).Item("GRIDBEAMWT"))
                End If
                FILLGRIDBEAM()
                TOTAL()
                CMBGRIDBEAM.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRIDBEAM_Validating(sender As Object, e As CancelEventArgs) Handles CMBGRIDBEAM.Validating
        Try
            If CMBGRIDBEAM.Text.Trim <> "" Then BEAMVALIDATE(CMBGRIDBEAM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDBEAM()
        If GRIDBEAMDOUBLECLICK = False Then
            GRIDBEAM.Rows.Add(TXTBEAMSRNO.Text, CMBGRIDBEAM.Text.Trim, Val(TXTGRIDENDS.Text.Trim), TXTGRIDTL.Text.Trim, Format(Val(TXTGRIDBEAMWT.Text.Trim), "0.00"))
            getsrno(GRIDBEAM)

        ElseIf GRIDBEAMDOUBLECLICK = True Then
            GRIDBEAM.Item(BSRNO.Index, TEMPBEAMROW).Value = Val(TXTBEAMSRNO.Text.Trim)
            GRIDBEAM.Item(BBEAMNAME.Index, TEMPBEAMROW).Value = CMBGRIDBEAM.Text.Trim
            GRIDBEAM.Item(BENDS.Index, TEMPBEAMROW).Value = Format(Val(TXTGRIDENDS.Text.Trim), "0.00")
            GRIDBEAM.Item(BTL.Index, TEMPBEAMROW).Value = Format(Val(TXTGRIDTL.Text.Trim), "0.00")
            GRIDBEAM.Item(BBEAMWT.Index, TEMPBEAMROW).Value = Format(Val(TXTGRIDBEAMWT.Text.Trim), "0.00")

            GRIDBEAMDOUBLECLICK = False

        End If
        TOTAL()
        GRIDBEAM.FirstDisplayedScrollingRowIndex = GRIDBEAM.RowCount - 1


        TXTBEAMSRNO.Text = GRIDBEAM.RowCount + 1
        CMBGRIDBEAM.Text = ""
        TXTGRIDENDS.Clear()
        TXTGRIDTL.Clear()
        TXTGRIDBEAMWT.Clear()
        CMBGRIDBEAM.Focus()
    End Sub

    Private Sub GRIDBEAM_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBEAM.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDBEAM.Item(BSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDBEAMDOUBLECLICK = True
                TEMPBEAMROW = e.RowIndex
                TXTBEAMSRNO.Text = GRIDBEAM.Item(BSRNO.Index, e.RowIndex).Value
                CMBGRIDBEAM.Text = GRIDBEAM.Item(BBEAMNAME.Index, e.RowIndex).Value
                TXTGRIDENDS.Text = GRIDBEAM.Item(BENDS.Index, e.RowIndex).Value
                TXTGRIDTL.Text = GRIDBEAM.Item(BTL.Index, e.RowIndex).Value
                TXTGRIDBEAMWT.Text = GRIDBEAM.Item(BBEAMWT.Index, e.RowIndex).Value
                CMBGRIDBEAM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GRIDBEAM_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBEAM.KeyDown
        If e.KeyCode = Keys.Delete And GRIDBEAM.RowCount > 0 Then GRIDBEAM.Rows.RemoveAt(GRIDBEAM.CurrentRow.Index)
    End Sub

    'Private Sub TXTGRIDBEAMWT_Validated(sender As Object, e As EventArgs) Handles TXTGRIDBEAMWT.Validated
    '    Try
    '        If CMBGRIDBEAM.Text.Trim <> "" And T.RowCount > 0 And Val(TXTGRIDBEAMWT.Text.Trim) > 0 Then
    '            FILLGRIDBEAM()
    '            TOTAL()
    '            CMBGRIDBEAM.Text = ""
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class