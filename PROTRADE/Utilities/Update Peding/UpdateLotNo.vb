Imports System.ComponentModel
Imports BL

Public Class UpdateLotNo

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            TXTGRNNO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            TXTGRNNO.Clear()
            TXTNAME.Clear()
            TXTCHALLANNO.Clear()
            TXTITEMNAME.Clear()
            TXTPCS.Clear()
            TXTMTRS.Clear()
            CMBDYEING.Text = ""
            TXTLOTNO.Clear()
            RECDATE.Text = Now.Date
            CMBTYPE.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DTLEDGER As DataTable = OBJCMN.search("ISNULL(ACC_ID,0) AS LEDGERID", "", " LEDGERS", " AND ACC_CMPNAME = '" & CMBDYEING.Text.Trim & "' AND ACC_YEARID = " & YearId)
            Dim DT As New DataTable
            If CMBTYPE.Text = "GRN" Then
                DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN.GRN_PLOTNO = '" & TXTLOTNO.Text.Trim & "', GRN_RECDATE = '" & Format(Convert.ToDateTime(RECDATE.Text).Date, "MM/dd/yyyy") & "', GRN_TOLEDGERID = " & DTLEDGER.Rows(0).Item("LEDGERID") & " WHERE GRN.GRN_NO = " & Val(TXTGRNNO.Text.Trim) & " And GRN.GRN_TYPE = 'Job Work' AND GRN.GRN_YEARID = " & YearId, "", "")
            Else
                DT = OBJCMN.Execute_Any_String(" UPDATE JOBOUT SET JOBOUT.JO_LOTNO = '" & TXTLOTNO.Text.Trim & "', JO_LEDGERID = " & DTLEDGER.Rows(0).Item("LEDGERID") & " WHERE JOBOUT.JO_NO = " & Val(TXTGRNNO.Text.Trim) & " And JOBOUT.JO_YEARID = " & YearId, "", "")
            End If
            MsgBox("Lot No Updated Successfully")
            CLEAR()
            TXTGRNNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If Val(TXTGRNNO.Text.Trim) = 0 Then
            EP.SetError(TXTGRNNO, "Enter GRN No")
            bln = False
        End If

        If Val(TXTGRNNO.Text.Trim) <> 0 And TXTLOTNO.Text.Trim <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable
            If CMBTYPE.Text.Trim = "GRN" Then
                dttable = OBJCMN.search(" ISNULL(GRN.GRN_NO, 0) AS GRNNO, ISNULL(GRN.GRN_PLOTNO, '0') AS LOTNO, ISNULL(GRN.GRN_INHOUSECHECKDONE, 0) AS INHOUSECHECKINGDONE, ISNULL(GRN_DESC.GRN_CHECKDONE, 0) AS CHECKINGDONE, ISNULL(LEDGERS.ACC_CMPNAME,'') AS DYEINGNAME ", "", " GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON ACC_ID = GRN_TOLEDGERID ", " AND GRN_TYPE = 'Job Work' AND GRN.GRN_NO = " & Val(TXTGRNNO.Text.Trim) & " AND GRN.GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 AndAlso (Convert.ToBoolean(dttable.Rows(0).Item("INHOUSECHECKINGDONE")) = True Or Convert.ToBoolean(dttable.Rows(0).Item("CHECKINGDONE")) = True) Then
                    If Val(TXTGRNNO.Text.Trim) <> 0 Then EP.SetError(TXTGRNNO, "GRN Checking Already Done")
                    bln = False
                End If
            Else
                dttable = OBJCMN.search(" ISNULL(JOBOUT.JO_NO, 0) AS GRNNO, ISNULL(JOBOUT.JO_LOTNO, '0') AS LOTNO, ISNULL(JOBOUT.JO_RECDMTRS, 0) AS RECDMTRS, ISNULL(JOBOUT.JO_LOTCOMPLETED, 0) AS LOTCOMPLETED", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_NO = JOBOUT_DESC.JO_NO AND JOBOUT.JO_YEARID = JOBOUT_DESC.JO_YEARID ", " AND JOBOUT.JO_NO = " & Val(TXTGRNNO.Text.Trim) & " AND JOBOUT.JO_YEARID = " & YearId)
                If dttable.Rows.Count > 0 AndAlso (Val(dttable.Rows(0).Item("RECDMTRS")) > 0 Or Convert.ToBoolean(dttable.Rows(0).Item("LOTCOMPLETED")) = True) Then
                    If Val(TXTGRNNO.Text.Trim) <> 0 Then EP.SetError(TXTGRNNO, "Job In Done or Lot Locked")
                    bln = False
                End If
            End If
        End If

        If CMBDYEING.Text.Trim = "" And ClientName <> "AVIS" Then
            EP.SetError(CMBDYEING, "Dyeing Name Cannot be Blank")
            bln = False
        End If

        If TXTLOTNO.Text.Trim = "" And ClientName <> "AVIS" Then
            EP.SetError(TXTLOTNO, "Lot No Cannot be Blank")
            bln = False
        End If


        If RECDATE.Text = "__/__/____" Then
            EP.SetError(RECDATE, " Please Enter Proper Date")
            bln = False
        End If

        Return bln
    End Function

    Private Sub TXTGRNNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGRNNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub UpdateLotNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRNNO_Validated(sender As Object, e As EventArgs) Handles TXTGRNNO.Validated
        Try
            If Val(TXTGRNNO.Text.Trim) > 0 Then

                If CMBTYPE.Text = "GRN" Then

                    'GET DYEING NAME
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(GRN.GRN_CHALLANNO,'') AS CHALLANNO, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME, ISNULL(GRN_DESC.GRN_QTY,0) AS PCS, ISNULL(GRN_DESC.GRN_MTRS,0) AS MTRS, ISNULL(DYEINGLEDGERS.ACC_CMPNAME,'') AS DYEINGNAME, GRN_RECDATE AS RECDATE", "", "GRN INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN LEDGERS AS DYEINGLEDGERS ON GRN.GRN_TOLEDGERID = DYEINGLEDGERS.ACC_ID INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.ITEM_ID", " AND GRN_TYPE = 'Job Work' AND GRN.GRN_NO = " & Val(TXTGRNNO.Text.Trim) & " AND GRN.GRN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        TXTNAME.Text = DT.Rows(0).Item("NAME")
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO")
                        TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                        TXTPCS.Text = Val(DT.Rows(0).Item("PCS"))
                        TXTMTRS.Text = Val(DT.Rows(0).Item("MTRS"))
                        CMBDYEING.Text = DT.Rows(0).Item("DYEINGNAME")
                        RECDATE.Text = Convert.ToDateTime(DT.Rows(0).Item("RECDATE")).Date
                    End If

                Else

                    'GET JOBBER NAME
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(JOBOUT.JO_CHALLANNO,'') AS CHALLANNO, ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME, ISNULL(JOBOUT_DESC.JO_PCS,0) AS PCS, ISNULL(JOBOUT_DESC.JO_MTRS,0) AS MTRS, ISNULL(LEDGERS.ACC_CMPNAME,'') AS DYEINGNAME, JO_DATE AS RECDATE", "", "JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_LEDGERID = LEDGERS.ACC_ID INNER JOIN JOBOUT_DESC ON JOBOUT.JO_NO = JOBOUT_DESC.JO_NO AND JOBOUT.JO_YEARID = JOBOUT_DESC.JO_YEARID LEFT OUTER JOIN ITEMMASTER ON JOBOUT_DESC.JO_ITEMID = ITEMMASTER.ITEM_ID", " AND JOBOUT.JO_NO = " & Val(TXTGRNNO.Text.Trim) & " AND JOBOUT.JO_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        TXTNAME.Text = DT.Rows(0).Item("NAME")
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO")
                        TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                        TXTPCS.Text = Val(DT.Rows(0).Item("PCS"))
                        TXTMTRS.Text = Val(DT.Rows(0).Item("MTRS"))
                        CMBDYEING.Text = DT.Rows(0).Item("DYEINGNAME")
                        RECDATE.Text = Convert.ToDateTime(DT.Rows(0).Item("RECDATE")).Date
                    End If

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateLotNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillname(CMBDYEING, False, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECDATE_Validating(sender As Object, e As CancelEventArgs) Handles RECDATE.Validating
        Try
            If RECDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(RECDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class