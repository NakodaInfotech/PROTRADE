Imports BL

Public Class MergeParameter
    Public EDIT As Boolean

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        Try
            If cmbtype.Text = "MERCHANT" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillitemname(cmbOldName, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
                If cmbReplace.Text.Trim = "" Then fillitemname(cmbReplace, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            ElseIf cmbtype.Text = "ITEM NAME" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillitemname(cmbOldName, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM NAME'")
                If cmbReplace.Text.Trim = "" Then fillitemname(cmbReplace, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM NAME'")

            ElseIf cmbtype.Text = "YARN MERCHANT" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillYARNQUALITY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillYARNQUALITY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "PIECETYPE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillPIECETYPE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillPIECETYPE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "COLOR" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCOLOR(cmbOldName, "")
                If cmbReplace.Text.Trim = "" Then FILLCOLOR(cmbReplace, "")
            ElseIf cmbtype.Text.Trim = "AREA" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLAREA(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLAREA(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CATEGORY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillCATEGORY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillCATEGORY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillCITY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillCITY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillCOUNTRY(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillCOUNTRY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "DEPARTMENT" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then filldepartment(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then filldepartment(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "DESIGN" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillDESIGN(cmbOldName, "")
                If cmbReplace.Text.Trim = "" Then fillDESIGN(cmbReplace, "")
            ElseIf cmbtype.Text.Trim = "QUALITY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillQUALITY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillQUALITY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillSTATE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillSTATE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "UNIT" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillunit(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillunit(cmbReplace)
            ElseIf cmbtype.Text.Trim = "GODOWN" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillGODOWN(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillGODOWN(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "PROCESS" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLPROCESS(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLPROCESS(cmbReplace)
            ElseIf cmbtype.Text.Trim = "TAX" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then filltax(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then filltax(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "DESIGNATION" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then filldesignation(cmbOldName)
                If cmbReplace.Text.Trim = "" Then filldesignation(cmbReplace)
            ElseIf cmbtype.Text.Trim = "EMPLOYEE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLEMP(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLEMP(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "MILLNAME" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLMILL(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLMILL(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "CONTRACTOR" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLCONTRACT(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLCONTRACT(cmbReplace)
            ElseIf cmbtype.Text.Trim = "PARTYBANK" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLBANK(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLBANK(cmbReplace)
            ElseIf cmbtype.Text.Trim = "GROUP" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLGROUP(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLGROUP(cmbReplace)
            ElseIf cmbtype.Text.Trim = "GROUPOFCOMPANY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLGROUPCOMPANY(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLGROUPCOMPANY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "PACKINGTYPE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLPACKINGTYPE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLPACKINGTYPE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "TERM" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillTERM(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillTERM(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "SALESMAN" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLSALESMAN(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLSALESMAN(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CURRENCY" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then fillCURRENCY(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillCURRENCY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "RACK" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLRACK(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLRACK(cmbReplace)
            ElseIf cmbtype.Text.Trim = "SHELF" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLSHELF(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLSHELF(cmbReplace)
            ElseIf cmbtype.Text.Trim = "MACHINE" Then
                cmbOldName.Text = ""
                cmbReplace.Text = ""
                If cmbOldName.Text.Trim = "" Then FILLMACHINE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLMACHINE(cmbReplace)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True

            If cmbOldName.Text.Trim = cmbReplace.Text.Trim Then
                EP.SetError(cmbReplace, " Please Fill Diff. Value!")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If


            Cursor.Current = Cursors.WaitCursor
            Dim alParaval As New ArrayList
            Dim intresult As Integer

            alParaval.Add(cmbtype.Text)
            alParaval.Add(cmbOldName.Text)
            alParaval.Add(cmbReplace.Text)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)

            Dim OBJMFG As New ClsCommon()
            OBJMFG.alParaval = alParaval
            intresult = OBJMFG.mergeparameter()
            MsgBox("Item Merge Successfully")
            cmbtype.Text = ""
            cmbOldName.Text = ""
            cmbReplace.Text = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class