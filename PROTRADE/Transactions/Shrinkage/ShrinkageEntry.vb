
Imports BL
Imports System.ComponentModel

Public Class ShrinkageEntry

    Dim IntResult As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public TEMPENTRYNO As String
    Public PARTYNAME As String = ""

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GET_MAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(LOT_NO),0) + 1 ", " LOTCOMPLETED ", " and LOT_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub FILLCMB()
        Try
            If CMBDYEINGNAME.Text.Trim = "" Then fillname(CMBDYEINGNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            Dim alParaval As New ArrayList

            If TXTNO.ReadOnly = False Then
                alParaval.Add(Val(TXTNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(CMBDYEINGNAME.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(SKDATE.Text).Date, "MM/dd/yyyy"))


            alParaval.Add(Val(LBLTOTALPCS.Text.Trim))
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(Val(LBLTOTALRECDPCS.Text.Trim))
            alParaval.Add(Val(LBLTOTALRECDMTRS.Text.Trim))
            alParaval.Add(Val(LBLTOTALBALPCS.Text.Trim))
            alParaval.Add(Val(LBLTOTALBALPCS.Text.Trim))
            alParaval.Add(Val(LBLTOTALSMPMTRS.Text.Trim))
            alParaval.Add(Val(LBLTOTALSHRINKAGE.Text.Trim))
            alParaval.Add(Val(LBLAVGSHRINKAGE.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim srno As String = ""
            Dim LOTNO As String = ""
            Dim GRIDDATE As String = ""
            Dim ITEMNAME As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim RECDPCS As String = ""
            Dim RECDMTRS As String = ""
            Dim BALPCS As String = ""
            Dim BALMTRS As String = ""
            Dim SMPMTRS As String = ""
            Dim SHRINKAGE As String = ""
            Dim SHRINKAGEPER As String = ""
            Dim GRNNO As String = ""
            Dim GRNTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSHRINKAGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If srno = "" Then
                        srno = row.Cells(GSRNO.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        GRIDDATE = row.Cells(GDATE.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        PCS = Val(row.Cells(Gpcs.Index).Value.ToString)
                        MTRS = Val(row.Cells(Gmtrs.Index).Value)
                        RECDPCS = Val(row.Cells(GRECDPCS.Index).Value)
                        RECDMTRS = Val(row.Cells(GRECDMTRS.Index).Value)
                        BALPCS = Val(row.Cells(GBALPCS.Index).Value.ToString)
                        BALMTRS = Val(row.Cells(GBALMTRS.Index).Value)
                        SMPMTRS = Val(row.Cells(GSMPMTRS.Index).Value)
                        SHRINKAGE = Val(row.Cells(GShrinkage.Index).Value)
                        SHRINKAGEPER = Val(row.Cells(GSHRINKAGEPER.Index).Value)
                        GRNNO = row.Cells(GGRNNO.Index).Value.ToString
                        GRNTYPE = row.Cells(GGRNTYPE.Index).Value.ToString

                    Else

                        srno = srno & "|" & row.Cells(GSRNO.Index).Value
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        GRIDDATE = GRIDDATE & "|" & row.Cells(GDATE.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        PCS = PCS & "|" & Val(row.Cells(Gpcs.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(Gmtrs.Index).Value)
                        RECDPCS = RECDPCS & "|" & Val(row.Cells(GRECDPCS.Index).Value)
                        RECDMTRS = RECDMTRS & "|" & Val(row.Cells(GRECDMTRS.Index).Value)
                        BALPCS = BALPCS & "|" & Val(row.Cells(GBALPCS.Index).Value)
                        BALMTRS = BALMTRS & "|" & Val(row.Cells(GBALMTRS.Index).Value)
                        SMPMTRS = SMPMTRS & "|" & Val(row.Cells(GSMPMTRS.Index).Value)
                        SHRINKAGE = SHRINKAGE & "|" & Val(row.Cells(GShrinkage.Index).Value)
                        SHRINKAGEPER = SHRINKAGEPER & "|" & Val(row.Cells(GSHRINKAGEPER.Index).Value)
                        GRNNO = GRNNO & "|" & row.Cells(GGRNNO.Index).Value
                        GRNTYPE = GRNTYPE & "|" & row.Cells(GGRNTYPE.Index).Value

                    End If
                End If



            Next

            alParaval.Add(srno)
            alParaval.Add(LOTNO)
            alParaval.Add(GRIDDATE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(RECDPCS)
            alParaval.Add(RECDMTRS)
            alParaval.Add(BALPCS)
            alParaval.Add(BALMTRS)
            alParaval.Add(SMPMTRS)
            alParaval.Add(SHRINKAGE)
            alParaval.Add(SHRINKAGEPER)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNTYPE)


            Dim OBJCLSPROFORMA As New ClsShrinkageEntry()
            OBJCLSPROFORMA.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJCLSPROFORMA.SAVE()
                TXTNO.Text = DTT.Rows(0).Item(0)
                MsgBox("Details Added")

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPENTRYNO)
                Dim IntResult As Integer = OBJCLSPROFORMA.UPDATE()
                MsgBox("Details Updated")

            End If

            'PRINTREPORT(Val(TXTENTRYNO.Text.Trim))
            EDIT = False
            CLEAR()
            CMBDYEINGNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        'If CMBDYEINGNAME.Text.Trim = "" And CMBNAME.Text.Trim <> "" Then CMBDYEINGNAME.Text = CMBNAME.Text.Trim

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        If Val(TXTNO.Text.Trim) = 0 Then
            EP.SetError(TXTNO, "Enter Invoice No")
            bln = False
        End If

        If CMBDYEINGNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBDYEINGNAME, " Please Fill Dyeing Name ")
            bln = False
        End If

        If GRIDSHRINKAGE.RowCount = 0 Then
            EP.SetError(CMBDYEINGNAME, " Please Select Lot")
            bln = False
        End If

        If SKDATE.Text = "__/__/____" Then
            EP.SetError(SKDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(SKDATE.Text) Then
                EP.SetError(SKDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If
        Return bln

    End Function

    Sub CLEAR()

        EP.Clear()
        TXTNO.Clear()
        SKDATE.Text = Now.Date

        CMBDYEINGNAME.Text = ""
        TXTNO.Clear()

        txtremarks.Clear()

        txtsrno.Text = 1
        TXTGRIDDATE.Text = Now.Date
        TXTLOTNO.Clear()
        CMBITEMNAME.Text = ""
        TXTPCS.Clear()
        TXTMTRS.Clear()
        TXTRECDPCS.Clear()
        TXTRECDMTRS.Clear()
        TXTBALPCS.Clear()
        TXTBALMTRS.Clear()
        TXTSHRINKAGE.Clear()
        GRIDSHRINKAGE.RowCount = 0

        LBLTOTALPCS.Text = 0.0
        LBLTOTALMTRS.Text = 0.0
        LBLTOTALRECDPCS.Text = 0.0
        LBLTOTALRECDMTRS.Text = 0.0
        LBLTOTALBALPCS.Text = 0
        LBLTOTALBALMTRS.Text = 0
        LBLTOTALSMPMTRS.Text = 0.0
        LBLTOTALSHRINKAGE.Text = 0.0
        LBLAVGSHRINKAGE.Text = 0.0
        GET_MAX_NO()
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Wish to Delete Sale Gate Pass?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                'DONE BY GULKIT
                'BEFORE UPDATING REVERSE THE ENTRY IN SCHEDULEMASTER_DESC
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPENTRYNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)


                Dim OBJPRO As New ClsShrinkageEntry
                OBJPRO.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJPRO.DELETE
                MsgBox("Shrinkage Deleted Sucessfully")

                CLEAR()
                EDIT = False
                CMBDYEINGNAME.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDYEINGNAME_Enter(sender As Object, e As EventArgs) Handles CMBDYEINGNAME.Enter
        Try
            If CMBDYEINGNAME.Text.Trim = "" Then fillname(CMBDYEINGNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEINGNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBDYEINGNAME.Validating
        Try
            If CMBDYEINGNAME.Text.Trim <> "" Then namevalidate(CMBDYEINGNAME, CMBCODE, e, Me, TXTADD, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If EDIT = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSPROFORMA As New ClsShrinkageEntry()
                Dim dttable As New DataTable

                dttable = OBJCLSPROFORMA.selectSHRINKAGE(TEMPENTRYNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        TXTNO.Text = TEMPENTRYNO
                        TXTNO.ReadOnly = True
                        SKDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBDYEINGNAME.Text = Convert.ToString(dr("NAME").ToString)
                        txtremarks.Text = Convert.ToString(dr("REMARKS").ToString)
                        GRIDSHRINKAGE.Rows.Add(dr("GRIDSRNO").ToString, dr("LOTNO"), dr("GRIDDATE").ToString, dr("ITEMNAME").ToString, Format(Val(dr("PCS")), "0"), Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RECDPCS")), "0"), Format(Val(dr("RECDMTRS")), "0.00"), Format(Val(dr("BALPCS")), "0.00"), Format(Val(dr("BALMTRS")), "0.00"), Format(Val(dr("SMPMTRS")), "0.00"), Format(Val(dr("SHRINKAGE")), "0.00"), Format(Val(dr("SHRINKAGEPER")), "0.00"), Val(dr("GRNNO")), dr("GRNTYPE"))

                    Next

                    TOTAL()
                    GRIDSHRINKAGE.FirstDisplayedScrollingRowIndex = GRIDSHRINKAGE.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
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

    Sub FILLGRID()

        GRIDSHRINKAGE.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDSHRINKAGE.Rows.Add(Val(TXTNO.Text.Trim), TXTLOTNO.Text.Trim, TXTGRIDDATE.Text.Trim, CMBITEMNAME.Text.Trim, Format(Val(TXTPCS.Text.Trim), "0.00"), Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTRECDPCS.Text.Trim), "0.00"), Format(Val(TXTRECDMTRS.Text.Trim), "0.00"), Format(Val(TXTBALPCS.Text.Trim), "0.00"), Format(Val(TXTBALMTRS.Text.Trim), "0.00"), Format(Val(TXTSHRINKAGE.Text.Trim), "0.00"), "", 0, 0, 0, 0)
            getsrno(GRIDSHRINKAGE)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSHRINKAGE.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDSHRINKAGE.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDSHRINKAGE.Item(GDATE.Index, TEMPROW).Value = TXTGRIDDATE.Text.Trim
            GRIDSHRINKAGE.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDSHRINKAGE.Item(Gpcs.Index, TEMPROW).Value = Format(Val(TXTPCS.Text.Trim), "0.00")
            GRIDSHRINKAGE.Item(Gmtrs.Index, TEMPROW).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            GRIDSHRINKAGE.Item(GRECDPCS.Index, TEMPROW).Value = Format(Val(TXTRECDPCS.Text.Trim), "0.00")
            GRIDSHRINKAGE.Item(GRECDMTRS.Index, TEMPROW).Value = Format(Val(TXTRECDMTRS.Text.Trim), "0.00")
            GRIDSHRINKAGE.Item(GBALPCS.Index, TEMPROW).Value = Format(Val(TXTBALPCS.Text.Trim), "0.00")
            GRIDSHRINKAGE.Item(GBALMTRS.Index, TEMPROW).Value = Format(Val(TXTBALMTRS.Text.Trim), "0.00")
            GRIDSHRINKAGE.Item(GShrinkage.Index, TEMPROW).Value = Format(Val(TXTSHRINKAGE.Text.Trim), "0.00")

            GRIDDOUBLECLICK = False

        End If

        'CALC()
        'total()

        GRIDSHRINKAGE.FirstDisplayedScrollingRowIndex = GRIDSHRINKAGE.RowCount - 1

        If ClientName <> "SKF" And ClientName <> "MANIBHADRA" And ClientName <> "ALENCOT" And ClientName <> "MNARESH" And ClientName <> "SOFTAS" Then
            TXTLOTNO.Text = ""
            TXTGRIDDATE.Text = ""
            CMBITEMNAME.Text = ""
            TXTPCS.Clear()
            TXTMTRS.Clear()
            TXTRECDPCS.Clear()
            TXTRECDMTRS.Clear()
            TXTBALPCS.Clear()
            TXTBALMTRS.Clear()
            TXTSHRINKAGE.Clear()

        Else
            If ClientName <> "SKF" Then TXTMTRS.Clear()
            TXTMTRS.Focus()
        End If
        txtsrno.Text = Val(GRIDSHRINKAGE.RowCount) + 1

    End Sub

    Sub TOTAL()
        Try

            LBLTOTALPCS.Text = 0.0
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALRECDPCS.Text = 0.0
            LBLTOTALRECDMTRS.Text = 0.0
            LBLTOTALBALPCS.Text = 0.0
            LBLTOTALBALMTRS.Text = 0.0
            LBLTOTALSMPMTRS.Text = 0.0
            LBLTOTALSHRINKAGE.Text = 0.0
            LBLAVGSHRINKAGE.Text = 0.0

            If GRIDSHRINKAGE.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDSHRINKAGE.Rows
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(row.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(row.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRECDPCS.Text = Format(Val(LBLTOTALRECDPCS.Text) + Val(row.Cells(GRECDPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALRECDMTRS.Text = Format(Val(LBLTOTALRECDMTRS.Text) + Val(row.Cells(GRECDMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALBALPCS.Text = Format(Val(LBLTOTALBALPCS.Text) + Val(row.Cells(GBALPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALBALMTRS.Text = Format(Val(LBLTOTALBALMTRS.Text) + Val(row.Cells(GBALMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALSMPMTRS.Text = Format(Val(LBLTOTALSMPMTRS.Text) + Val(row.Cells(GSMPMTRS.Index).EditedFormattedValue), "0.00")
                    row.Cells(GShrinkage.Index).Value = Format(Val(row.Cells(GBALMTRS.Index).EditedFormattedValue) - Val(row.Cells(GSMPMTRS.Index).EditedFormattedValue), "0.00")
                    row.Cells(GSHRINKAGEPER.Index).Value = Format((Val(row.Cells(GShrinkage.Index).EditedFormattedValue) / Val(row.Cells(Gmtrs.Index).EditedFormattedValue)) * 100, "0.00")
                    LBLTOTALSHRINKAGE.Text = Format(Val(LBLTOTALSHRINKAGE.Text) + Val(row.Cells(GShrinkage.Index).EditedFormattedValue), "0.00")
                Next
                LBLAVGSHRINKAGE.Text = Format((Val(LBLTOTALSHRINKAGE.Text) / Val(LBLTOTALMTRS.Text)) * 100, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRIVIOUS.Click
        Try
            GRIDSHRINKAGE.RowCount = 0
LINE1:
            TEMPENTRYNO = Val(TXTNO.Text) - 1
            If TEMPENTRYNO > 0 Then
                EDIT = True
                PROFORMA_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSHRINKAGE.RowCount = 0 And TEMPENTRYNO > 1 Then
                TXTNO.Text = TEMPENTRYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PROFORMA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDSHRINKAGE.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
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

            Dim objpodtls As New ShrinkageEntryDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDSHRINKAGE.RowCount = 0
LINE1:
            TEMPENTRYNO = Val(TXTNO.Text) + 1
            GET_MAX_NO()
            Dim MAXNO As Integer = TXTNO.Text.Trim
            CLEAR()
            If Val(TXTNO.Text) - 1 >= TEMPENTRYNO Then
                EDIT = True
                PROFORMA_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSHRINKAGE.RowCount = 0 And TEMPENTRYNO < MAXNO Then
                TXTNO.Text = TEMPENTRYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTLOT_Click(sender As Object, e As EventArgs) Handles CMDSELECTLOT.Click
        Try
            If EDIT = True And UserName <> "Admin" Then
                MsgBox("Not allowed in Edit Mode", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBDYEINGNAME.Text.Trim = "" Then
                MsgBox("Please Select Name First", MsgBoxStyle.Critical)
                CMBDYEINGNAME.Focus()
                Exit Sub
            End If


            Dim OBJLOT As New SelectLotNo
            OBJLOT.JOBBERNAME = CMBDYEINGNAME.Text.Trim
            OBJLOT.ShowDialog()
            Dim DTTABLE As DataTable = OBJLOT.DT
            If DTTABLE.Rows.Count > 0 Then
                For Each DTROW As DataRow In DTTABLE.Rows
                    GRIDSHRINKAGE.Rows.Add(0, DTROW("LOTNO"), Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), DTROW("ITEMNAME"), Format(Val(DTROW("ACCEPTEDPCS")), "0"), Format(Val(DTROW("ACCEPTEDMTRS")), "0.00"), Format(Val(DTROW("RECDPCS")), "0"), Format(Val(DTROW("RECDMTRS")), "0.00"), Format(Val(DTROW("BALPCS")), "0"), Format(Val(DTROW("BALMTRS")), "0.00"), 0, Format(Val(DTROW("SHRINKAGE")), "0.00"), Format((Val(DTROW("SHRINKAGE")) / Val(DTROW("ACCEPTEDMTRS"))) * 100, "0.00"), Val(DTROW("GRNNO")), DTROW("GRNTYPE"))
                Next
                getsrno(GRIDSHRINKAGE)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSHRINKAGE_Validating(sender As Object, e As CancelEventArgs) Handles TXTSHRINKAGE.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then
                FILLGRID()
                TOTAL()
            Else
                MsgBox("Enter Proper Details")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDSHRINKAGE.CurrentRow.Index >= 0 And GRIDSHRINKAGE.Item(GSRNO.Index, GRIDSHRINKAGE.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True

                txtsrno.Text = Val(GRIDSHRINKAGE.Item(GSRNO.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)
                TXTLOTNO.Text = GRIDSHRINKAGE.Item(GLOTNO.Index, GRIDSHRINKAGE.CurrentRow.Index).Value.ToString
                TXTGRIDDATE.Text = GRIDSHRINKAGE.Item(GDATE.Index, GRIDSHRINKAGE.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSHRINKAGE.Item(GITEMNAME.Index, GRIDSHRINKAGE.CurrentRow.Index).Value.ToString
                TXTPCS.Text = Val(GRIDSHRINKAGE.Item(Gpcs.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)
                TXTMTRS.Text = Val(GRIDSHRINKAGE.Item(Gmtrs.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)
                TXTRECDPCS.Text = Val(GRIDSHRINKAGE.Item(GRECDPCS.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)
                TXTRECDMTRS.Text = Val(GRIDSHRINKAGE.Item(GRECDMTRS.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)
                TXTBALPCS.Text = Val(GRIDSHRINKAGE.Item(GBALPCS.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)
                TXTBALMTRS.Text = Val(GRIDSHRINKAGE.Item(GBALMTRS.Index, GRIDSHRINKAGE.CurrentRow.Index).Value)

                TXTSHRINKAGE.Text = GRIDSHRINKAGE.Item(GShrinkage.Index, GRIDSHRINKAGE.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSHRINKAGE.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROFORMA_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSHRINKAGE.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCOSTSHEET_Click(sender As Object, e As EventArgs) Handles CMDCOSTSHEET.Click
        Try
            If EDIT = False Then Exit Sub
            Dim OBJRPT As New clsReportDesigner("Cost Sheet", System.AppDomain.CurrentDomain.BaseDirectory & "Cost Sheet.xlsx", 2)
            OBJRPT.COSTSHEET_EXCEL(CmpId, YearId, Val(TEMPENTRYNO), Val(LBLAVGSHRINKAGE.Text), CMBDYEINGNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
    End Sub

    Private Sub GRIDSHRINKAGE_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDSHRINKAGE.CellValidating
        Try
            ''  CODE FOR NUMERIC CHECK ONLY
            Dim colNum As Integer = GRIDSHRINKAGE.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GSMPMTRS.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSHRINKAGE.CurrentCell.Value = Nothing Then GRIDSHRINKAGE.CurrentCell.Value = "0.00"
                        GRIDSHRINKAGE.CurrentCell.Value = Convert.ToDecimal(GRIDSHRINKAGE.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDSHRINKAGE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSHRINKAGE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSHRINKAGE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDSHRINKAGE.Rows.RemoveAt(GRIDSHRINKAGE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDSHRINKAGE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSHRINKAGE.RowCount = 0
                TEMPENTRYNO = Val(tstxtbillno.Text)
                If TEMPENTRYNO > 0 Then
                    EDIT = True
                    PROFORMA_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class