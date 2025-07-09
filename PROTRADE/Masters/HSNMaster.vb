
Imports BL
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.ComponentModel

Public Class HSNMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public tempItemName As String
    Public TEMPHSNNO, tempHSNCODE As String
    Dim tempId As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBTYPE.Text.Trim.Length = 0 Then
            EP.SetError(CMBTYPE, "Fill Type")
            bln = False
        End If


        If EDIT = False Or (EDIT = True And tempHSNCODE <> TXTHSNCODE.Text.Trim) Then
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search("HSN_CODE", "", "HSNMASTER", " and HSN_CODE = '" & TXTHSNCODE.Text.Trim & "' And HSN_yearid = " & YearId)
            If dttable.Rows.Count > 0 Then
                EP.SetError(TXTHSNCODE, "Code  No Already Exist")
                bln = False
            End If
        End If


        If TXTHSNCODE.Text.Trim = "" Then
            EP.SetError(TXTHSNCODE, "Fill Code")
            bln = False
        End If

        If TXTITEMDESC.Text.Trim = "" Then
            EP.SetError(TXTITEMDESC, "Enter Item Description")
            bln = False
        End If

        If GRIDHSN.RowCount = 0 Then
            EP.SetError(TXTHSNCODE, "Enter GST%")
            bln = False
        End If

        'If Val(TXTCGST.Text.Trim) = 0 Then
        '    EP.SetError(TXTCGST, "Enter CGST")
        '    bln = False
        'End If

        'If Val(TXTSGST.Text.Trim) = 0 Then
        '    EP.SetError(TXTSGST, "Enter SGST")
        '    bln = False
        'End If

        'If Val(TXTIGST.Text.Trim) = 0 Then
        '    EP.SetError(TXTIGST, "Enter IGST")
        '    bln = False
        'End If
        Return bln
    End Function

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(TXTHSNCODE)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(TXTHSNCODE.Text) <> LCase(tempHSNCODE)) Then
                dt = objclscommon.search("HSN_CODE", "", "HSNMASTER", " and HSN_CODE = '" & TXTHSNCODE.Text.Trim & "'  And HSN_cmpid = " & CmpId & " And HSN_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Code Already Exists", MsgBoxStyle.Critical, "PROTRADE")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub clear()
        CMBTYPE.Text = "Goods"
        LBLITEMDESC.Text = "Item Description"
        TXTHSNCODE.Clear()
        TXTITEMDESC.Clear()
        TXTDESC.Clear()
        TXTRATE.Clear()
        TXTCGST.Clear()
        TXTSGST.Clear()
        TXTIGST.Clear()
        TXTRATE1.Clear()
        TXTCGST1.Clear()
        TXTSGST1.Clear()
        TXTIGST1.Clear()
        TXTEXPORTCGST.Clear()
        TXTEXPORTSGST.Clear()
        TXTEXPORTIGST.Clear()

        TXTGRIDRATE.Clear()
        TXTGRIDCGST.Clear()
        TXTGRIDSGST.Clear()
        TXTGRIDIGST.Clear()
        TXTGRIDRATE1.Clear()
        TXTGRIDCGST1.Clear()
        TXTGRIDSGST1.Clear()
        TXTGRIDIGST1.Clear()
        TXTGRIDEXPORTCGST.Clear()
        TXTGRIDEXPORTSGST.Clear()
        TXTGRIDEXPORTIGST.Clear()
        GRIDHSN.RowCount = 0

        getmax_HSN_NO()
    End Sub

    Sub getmax_HSN_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(HSN_ID),0) + 1 ", " HSNMASTER ", " and HSN_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTHSNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            clear()
            EDIT = False
            CMBTYPE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNMaster_KEYDOWN(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub HSNMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            clear()


            If EDIT = True Then
                Dim OBJDEPT As New ClsHSNMaster
                OBJDEPT.alParaval.Add(TEMPHSNNO)
                OBJDEPT.alParaval.Add(YearId)
                Dim DT As DataTable = OBJDEPT.GETHSN()
                If DT.Rows.Count > 0 Then

                    TXTHSNNO.Text = TEMPHSNNO
                    CMBTYPE.Text = DT.Rows(0).Item("TYPE")
                    TXTHSNCODE.Text = DT.Rows(0).Item("CODE")
                    tempHSNCODE = DT.Rows(0).Item("CODE")
                    TXTITEMDESC.Text = DT.Rows(0).Item("ITEMDESC")
                    TXTDESC.Text = DT.Rows(0).Item("DESC")
                    TXTRATE.Text = DT.Rows(0).Item("RATE")
                    TXTCGST.Text = DT.Rows(0).Item("CGST")
                    TXTSGST.Text = DT.Rows(0).Item("SGST")
                    TXTIGST.Text = DT.Rows(0).Item("IGST")

                    TXTRATE1.Text = DT.Rows(0).Item("RATE1")
                    TXTCGST1.Text = DT.Rows(0).Item("CGST1")
                    TXTSGST1.Text = DT.Rows(0).Item("SGST1")
                    TXTIGST1.Text = DT.Rows(0).Item("IGST1")

                    TXTEXPORTCGST.Text = DT.Rows(0).Item("EXPCGST")
                    TXTEXPORTSGST.Text = DT.Rows(0).Item("EXPSGST")
                    TXTEXPORTIGST.Text = DT.Rows(0).Item("EXPIGST")

                    For Each ROW As DataRow In DT.Rows
                        GRIDHSN.Rows.Add(Format(Convert.ToDateTime(ROW("WEFDATE")).Date, "dd/MM/yyyy"), Format(Val(ROW("GRIDRATE")), "0.00"), Format(Val(ROW("GRIDCGST")), "0.00"), Format(Val(ROW("GRIDSGST")), "0.00"), Format(Val(ROW("GRIDIGST")), "0.00"), Format(Val(ROW("GRIDRATE1")), "0.00"), Format(Val(ROW("GRIDCGST1")), "0.00"), Format(Val(ROW("GRIDSGST1")), "0.00"), Format(Val(ROW("GRIDIGST1")), "0.00"), Format(Val(ROW("GRIDEXPCGST")), "0.00"), Format(Val(ROW("GRIDEXPSGST")), "0.00"), Format(Val(ROW("GRIDEXPIGST")), "0.00"))
                    Next

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(CMBTYPE.Text.Trim)
            alParaval.Add(TXTHSNCODE.Text.Trim)
            alParaval.Add(TXTITEMDESC.Text.Trim)
            alParaval.Add(TXTDESC.Text.Trim)

            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(Val(TXTCGST.Text.Trim))
            alParaval.Add(Val(TXTSGST.Text.Trim))
            alParaval.Add(Val(TXTIGST.Text.Trim))

            alParaval.Add(Val(TXTRATE1.Text.Trim))
            alParaval.Add(Val(TXTCGST1.Text.Trim))
            alParaval.Add(Val(TXTSGST1.Text.Trim))
            alParaval.Add(Val(TXTIGST1.Text.Trim))


            alParaval.Add(Val(TXTEXPORTCGST.Text.Trim))
            alParaval.Add(Val(TXTEXPORTSGST.Text.Trim))
            alParaval.Add(Val(TXTEXPORTIGST.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim WEFDATE As String = ""
            Dim GRIDRATE As String = ""
            Dim GRIDCGST As String = ""
            Dim GRIDSGST As String = ""
            Dim GRIDIGST As String = ""
            Dim GRIDRATE1 As String = ""
            Dim GRIDCGST1 As String = ""
            Dim GRIDSGST1 As String = ""
            Dim GRIDIGST1 As String = ""
            Dim GRIDEXPORTCGST As String = ""
            Dim GRIDEXPORTSGST As String = ""
            Dim GRIDEXPORTIGST As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDHSN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDRATE = "" Then
                        WEFDATE = Format(Convert.ToDateTime(row.Cells(GDATE.Index).Value).Date, "MM/dd/yyyy")
                        GRIDRATE = Val(row.Cells(GRATE.Index).Value)
                        GRIDCGST = Val(row.Cells(GCGST.Index).Value)
                        GRIDSGST = Val(row.Cells(GSGST.Index).Value)
                        GRIDIGST = Val(row.Cells(GIGST.Index).Value)
                        GRIDRATE1 = Val(row.Cells(GRATE1.Index).Value)
                        GRIDCGST1 = Val(row.Cells(GCGST1.Index).Value)
                        GRIDSGST1 = Val(row.Cells(GSGST1.Index).Value)
                        GRIDIGST1 = Val(row.Cells(GIGST1.Index).Value)
                        GRIDEXPORTCGST = Val(row.Cells(GEXPCGST.Index).Value)
                        GRIDEXPORTSGST = Val(row.Cells(GEXPSGST.Index).Value)
                        GRIDEXPORTIGST = Val(row.Cells(GEXPIGST.Index).Value)
                    Else
                        WEFDATE = WEFDATE & "|" & Format(Convert.ToDateTime(row.Cells(GDATE.Index).Value).Date, "MM/dd/yyyy")
                        GRIDRATE = GRIDRATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        GRIDCGST = GRIDCGST & "|" & Val(row.Cells(GCGST.Index).Value)
                        GRIDSGST = GRIDSGST & "|" & Val(row.Cells(GSGST.Index).Value)
                        GRIDIGST = GRIDIGST & "|" & Val(row.Cells(GIGST.Index).Value)
                        GRIDRATE1 = GRIDRATE1 & "|" & Val(row.Cells(GRATE1.Index).Value)
                        GRIDCGST1 = GRIDCGST1 & "|" & Val(row.Cells(GCGST1.Index).Value)
                        GRIDSGST1 = GRIDSGST1 & "|" & Val(row.Cells(GSGST1.Index).Value)
                        GRIDIGST1 = GRIDIGST1 & "|" & Val(row.Cells(GIGST1.Index).Value)
                        GRIDEXPORTCGST = GRIDEXPORTCGST & "|" & Val(row.Cells(GEXPCGST.Index).Value)
                        GRIDEXPORTSGST = GRIDEXPORTSGST & "|" & Val(row.Cells(GEXPSGST.Index).Value)
                        GRIDEXPORTIGST = GRIDEXPORTIGST & "|" & Val(row.Cells(GEXPIGST.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(WEFDATE)
            alParaval.Add(GRIDRATE)
            alParaval.Add(GRIDCGST)
            alParaval.Add(GRIDSGST)
            alParaval.Add(GRIDIGST)
            alParaval.Add(GRIDRATE1)
            alParaval.Add(GRIDCGST1)
            alParaval.Add(GRIDSGST1)
            alParaval.Add(GRIDIGST1)
            alParaval.Add(GRIDEXPORTCGST)
            alParaval.Add(GRIDEXPORTSGST)
            alParaval.Add(GRIDEXPORTIGST)

            Dim objclsHSNMaster As New ClsHSNMaster
            objclsHSNMaster.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsHSNMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPHSNNO)
                IntResult = objclsHSNMaster.update()
                MsgBox("Details Updated")

            End If
            EDIT = False

            clear()
            CMBTYPE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then
                Dim OBJHSN As New ClsHSNMaster
                OBJHSN.alParaval.Add(TEMPHSNNO)
                OBJHSN.alParaval.Add(YearId)

                Dim intResult As Integer = OBJHSN.Delete
                MsgBox("HSN Deleted Successfully")
                clear()
                EDIT = False
                CMBTYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGST_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTSGST.KeyPress, TXTIGST.KeyPress, TXTCGST.KeyPress, TXTRATE1.KeyPress, TXTSGST1.KeyPress, TXTIGST1.KeyPress, TXTCGST1.KeyPress, TXTEXPORTCGST.KeyPress, TXTEXPORTSGST.KeyPress, TXTEXPORTIGST.KeyPress, TXTGRIDRATE.KeyPress, TXTGRIDCGST.KeyPress, TXTGRIDSGST.KeyPress, TXTGRIDIGST.KeyPress, TXTGRIDRATE1.KeyPress, TXTGRIDCGST1.KeyPress, TXTGRIDSGST1.KeyPress, TXTGRIDIGST1.KeyPress, TXTGRIDEXPORTCGST.KeyPress, TXTGRIDEXPORTSGST.KeyPress, TXTGRIDEXPORTIGST.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTHSNCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTHSNCODE.Validating
        Try
            If TXTHSNCODE.Text <> "" Then
                If EDIT = False Or (EDIT = True And tempHSNCODE <> TXTHSNCODE.Text.Trim) Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search("HSN_CODE", "", "HSNMASTER", " and HSN_CODE = '" & TXTHSNCODE.Text.Trim & "'  And HSN_cmpid = " & CmpId & " And HSN_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("Code  No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTYPE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTYPE.Validated
        Try
            If CMBTYPE.Text.Trim = "Services" Then LBLITEMDESC.Text = "Service Description" Else LBLITEMDESC.Text = "Item Description"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCGST_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCGST.Validating, TXTSGST.Validating, TXTIGST.Validating, TXTCGST1.Validating, TXTSGST1.Validating, TXTIGST1.Validating, TXTEXPORTCGST.Validating, TXTEXPORTSGST.Validating, TXTEXPORTIGST.Validating, TXTGRIDCGST.Validating, TXTGRIDSGST.Validating, TXTGRIDIGST.Validating, TXTGRIDCGST1.Validating, TXTGRIDSGST1.Validating, TXTGRIDIGST1.Validating, TXTGRIDEXPORTCGST.Validating, TXTGRIDEXPORTSGST.Validating, TXTGRIDEXPORTIGST.Validating
        Try
            If Val(TXTCGST.Text.Trim) > 100 Or Val(TXTSGST.Text.Trim) > 100 Or Val(TXTIGST.Text.Trim) > 100 Or Val(TXTCGST1.Text.Trim) > 100 Or Val(TXTSGST1.Text.Trim) > 100 Or Val(TXTIGST1.Text.Trim) > 100 Or Val(TXTEXPORTCGST.Text.Trim) > 100 Or Val(TXTEXPORTSGST.Text.Trim) > 100 Or Val(TXTEXPORTIGST.Text.Trim) > 100 Or Val(TXTGRIDCGST.Text.Trim) > 100 Or Val(TXTGRIDSGST.Text.Trim) > 100 Or Val(TXTGRIDIGST.Text.Trim) > 100 Or Val(TXTGRIDCGST1.Text.Trim) > 100 Or Val(TXTGRIDSGST1.Text.Trim) > 100 Or Val(TXTGRIDIGST1.Text.Trim) > 100 Or Val(TXTGRIDEXPORTCGST.Text.Trim) > 100 Or Val(TXTGRIDEXPORTSGST.Text.Trim) > 100 Or Val(TXTGRIDEXPORTIGST.Text.Trim) > 100 Then
                e.Cancel = True
                MsgBox("Tax % cannot be greter then 100", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDEXPORTIGST_Validated(sender As Object, e As EventArgs) Handles TXTGRIDEXPORTIGST.Validated
        Try
            If WEFDATE.Text <> "__/__/____" And Val(TXTGRIDCGST.Text.Trim) > 0 And Val(TXTGRIDSGST.Text.Trim) > 0 And Val(TXTGRIDIGST.Text.Trim) > 0 Then
                If Not CHECKWEFDATE() Then
                    MsgBox("W.E.F. Date already Present in Grid below")
                    Exit Sub
                End If
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKWEFDATE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each ROW As DataGridViewRow In GRIDHSN.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> ROW.Index) Or GRIDDOUBLECLICK = False Then
                    If WEFDATE.Text = ROW.Cells(GDATE.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDHSN.Rows.Add(WEFDATE.Text, Format(Val(TXTGRIDRATE.Text.Trim), "0.00"), Format(Val(TXTGRIDCGST.Text.Trim), "0.00"), Format(Val(TXTGRIDSGST.Text.Trim), "0.00"), Format(Val(TXTGRIDIGST.Text.Trim), "0.00"), Format(Val(TXTGRIDRATE1.Text.Trim), "0.00"), Format(Val(TXTGRIDCGST1.Text.Trim), "0.00"), Format(Val(TXTGRIDSGST1.Text.Trim), "0.00"), Format(Val(TXTGRIDIGST1.Text.Trim), "0.00"), Format(Val(TXTGRIDEXPORTCGST.Text.Trim), "0.00"), Format(Val(TXTGRIDEXPORTSGST.Text.Trim), "0.00"), Format(Val(TXTGRIDEXPORTIGST.Text.Trim), "0.00"))
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDHSN.Item(GDATE.Index, TEMPROW).Value = WEFDATE.Text
                GRIDHSN.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTGRIDRATE.Text.Trim), "0.00")
                GRIDHSN.Item(GCGST.Index, TEMPROW).Value = Format(Val(TXTGRIDCGST.Text.Trim), "0.00")
                GRIDHSN.Item(GSGST.Index, TEMPROW).Value = Format(Val(TXTGRIDSGST.Text.Trim), "0.00")
                GRIDHSN.Item(GIGST.Index, TEMPROW).Value = Format(Val(TXTGRIDIGST.Text.Trim), "0.00")
                GRIDHSN.Item(GRATE1.Index, TEMPROW).Value = Format(Val(TXTGRIDRATE1.Text.Trim), "0.00")
                GRIDHSN.Item(GCGST1.Index, TEMPROW).Value = Format(Val(TXTGRIDCGST1.Text.Trim), "0.00")
                GRIDHSN.Item(GSGST1.Index, TEMPROW).Value = Format(Val(TXTGRIDSGST1.Text.Trim), "0.00")
                GRIDHSN.Item(GIGST1.Index, TEMPROW).Value = Format(Val(TXTGRIDIGST1.Text.Trim), "0.00")
                GRIDHSN.Item(GEXPCGST.Index, TEMPROW).Value = Format(Val(TXTGRIDEXPORTCGST.Text.Trim), "0.00")
                GRIDHSN.Item(GEXPSGST.Index, TEMPROW).Value = Format(Val(TXTGRIDEXPORTSGST.Text.Trim), "0.00")
                GRIDHSN.Item(GEXPIGST.Index, TEMPROW).Value = Format(Val(TXTGRIDEXPORTIGST.Text.Trim), "0.00")
                GRIDDOUBLECLICK = False
            End If

            WEFDATE.Clear()
            TXTGRIDRATE.Clear()
            TXTGRIDCGST.Clear()
            TXTGRIDSGST.Clear()
            TXTGRIDIGST.Clear()
            TXTGRIDRATE1.Clear()
            TXTGRIDCGST1.Clear()
            TXTGRIDSGST1.Clear()
            TXTGRIDIGST1.Clear()
            TXTGRIDEXPORTCGST.Clear()
            TXTGRIDEXPORTSGST.Clear()
            TXTGRIDEXPORTIGST.Clear()
            WEFDATE.Focus()

            GRIDHSN.ClearSelection()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHSN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDHSN.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDHSN.Item(GDATE.Index, e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                WEFDATE.Text = GRIDHSN.Item(GDATE.Index, e.RowIndex).Value
                TXTGRIDRATE.Text = Val(GRIDHSN.Item(GRATE.Index, e.RowIndex).Value)
                TXTGRIDCGST.Text = Val(GRIDHSN.Item(GCGST.Index, e.RowIndex).Value)
                TXTGRIDSGST.Text = Val(GRIDHSN.Item(GSGST.Index, e.RowIndex).Value)
                TXTGRIDIGST.Text = Val(GRIDHSN.Item(GIGST.Index, e.RowIndex).Value)
                TXTGRIDRATE1.Text = Val(GRIDHSN.Item(GRATE1.Index, e.RowIndex).Value)
                TXTGRIDCGST1.Text = Val(GRIDHSN.Item(GCGST1.Index, e.RowIndex).Value)
                TXTGRIDSGST1.Text = Val(GRIDHSN.Item(GSGST1.Index, e.RowIndex).Value)
                TXTGRIDIGST1.Text = Val(GRIDHSN.Item(GIGST1.Index, e.RowIndex).Value)
                TXTGRIDEXPORTCGST.Text = Val(GRIDHSN.Item(GEXPCGST.Index, e.RowIndex).Value)
                TXTGRIDEXPORTSGST.Text = Val(GRIDHSN.Item(GEXPSGST.Index, e.RowIndex).Value)
                TXTGRIDEXPORTIGST.Text = Val(GRIDHSN.Item(GEXPIGST.Index, e.RowIndex).Value)

                WEFDATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDHSN_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDHSN.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MsgBox("Unable to Delete, Row is in Edit Mode", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                GRIDHSN.Rows.RemoveAt(GRIDHSN.CurrentRow.Index)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WEFDATE_Validating(sender As Object, e As CancelEventArgs) Handles WEFDATE.Validating
        Try
            If WEFDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(WEFDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class