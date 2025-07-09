
Imports BL

Public Class LotFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub CMBJOBBER_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Enter
        Try
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBJOBBER.Validating
        Try
            If CMBJOBBER.Text.Trim <> "" Then namevalidate(CMBJOBBER, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub LotFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LotFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim LOTCLAUSE As String = ""
            Dim CHALLANCLAUSE As String = ""
            Dim PARTYCLAUSE As String = ""
            Dim ITEMCLAUSE As String = ""

            If CHKGRIDDETAILS.Checked = True Then
                Dim OBJLOTGRID As New LotGridreport
                OBJLOTGRID.MdiParent = MDIMain
                OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " AND YEARID = " & YearId
                If chkdate.CheckState = CheckState.Checked Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and RECDATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                If CMBJOBBER.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and JOBBERNAME='" & CMBJOBBER.Text.Trim & "'"
                If CMBITEMNAME.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
                If CMBGROUP.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and GROUPNAME='" & CMBGROUP.Text.Trim & "'"
                If CMBQUALITY.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and QUALITY='" & CMBQUALITY.Text.Trim & "'"
                If CMBCATEGORY.Text <> "" Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and CATEGORYNAME='" & CMBCATEGORY.Text.Trim & "'"
                If CHKPENDINGPROG.Checked = True Then OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and PROGRAMDONE='FALSE'"

                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If LOTCLAUSE = "" Then
                            LOTCLAUSE = " AND (LOTNO = '" & dtrow("LOTNO") & "'"
                        Else
                            LOTCLAUSE = LOTCLAUSE & " OR LOTNO = '" & dtrow("LOTNO") & "'"
                        End If
                    End If
                Next
                If LOTCLAUSE <> "" Then
                    LOTCLAUSE = LOTCLAUSE & ")"
                    OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & LOTCLAUSE
                End If



                For i As Integer = 0 To gridbillchallan.RowCount - 1
                    Dim dtrow As DataRow = gridbillchallan.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If CHALLANCLAUSE = "" Then
                            CHALLANCLAUSE = " AND (CHALLANNO = '" & dtrow("CHALLANNO") & "'"
                        Else
                            CHALLANCLAUSE = CHALLANCLAUSE & " OR CHALLANNO = '" & dtrow("CHALLANNO") & "'"
                        End If
                    End If
                Next
                If CHALLANCLAUSE <> "" Then
                    CHALLANCLAUSE = CHALLANCLAUSE & ")"
                    OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & CHALLANCLAUSE
                End If



                For i As Integer = 0 To Gridparty.RowCount - 1
                    Dim dtrow As DataRow = Gridparty.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If PARTYCLAUSE = "" Then
                            PARTYCLAUSE = " AND (JOBBERNAME = '" & dtrow("NAME") & "'"
                        Else
                            PARTYCLAUSE = PARTYCLAUSE & " OR JOBBERNAME = '" & dtrow("NAME") & "'"
                        End If
                    End If
                Next
                If PARTYCLAUSE <> "" Then
                    PARTYCLAUSE = PARTYCLAUSE & ")"
                    OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & PARTYCLAUSE
                End If


                For i As Integer = 0 To GRIDITEM.RowCount - 1
                    Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If ITEMCLAUSE = "" Then
                            ITEMCLAUSE = " AND (ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        Else
                            ITEMCLAUSE = ITEMCLAUSE & " OR ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                        End If
                    End If
                Next
                If ITEMCLAUSE <> "" Then
                    ITEMCLAUSE = ITEMCLAUSE & ")"
                    OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & ITEMCLAUSE
                End If



                If LOTSTATUSONMTRS = False Then
                    If RDBPENDING.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and BALPCS>0 AND LOTCOMPLETED='FALSE'"
                    ElseIf RDBCOMPLETE.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and (BALPCS=0 OR LOTCOMPLETED='TRUE')"
                    End If
                Else
                    If RDBPENDING.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and LOTCOMPLETED='FALSE'"
                    ElseIf RDBCOMPLETE.Checked = True Then
                        OBJLOTGRID.WHERECLAUSE = OBJLOTGRID.WHERECLAUSE & " and LOTCOMPLETED='TRUE'"
                    End If
                End If

                OBJLOTGRID.Show()
                Exit Sub
            End If



            Dim OBJGRN As New GRNDesign
            OBJGRN.MdiParent = MDIMain
            OBJGRN.WHERECLAUSE = " {LOT_VIEW.yearid}=" & YearId
            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@GRNDATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBJOBBER.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.JOBBERNAME}='" & CMBJOBBER.Text.Trim & "'"
            If CMBITEMNAME.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.ITEMNAME}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBGROUP.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.GROUPNAME}='" & CMBGROUP.Text.Trim & "'"
            If CMBQUALITY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.QUALITY}='" & CMBQUALITY.Text.Trim & "'"
            If CMBCATEGORY.Text <> "" Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.CATEGORYNAME}='" & CMBCATEGORY.Text.Trim & "'"
            If CHKPENDINGPROG.Checked = True Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.PROGRAMDONE}=FALSE"

            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If LOTCLAUSE = "" Then
                        LOTCLAUSE = " AND ({LOT_VIEW.LOTNO} = '" & dtrow("LOTNO") & "'"
                    Else
                        LOTCLAUSE = LOTCLAUSE & " OR {LOT_VIEW.LOTNO} = '" & dtrow("LOTNO") & "'"
                    End If
                End If
            Next
            If LOTCLAUSE <> "" Then
                LOTCLAUSE = LOTCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & LOTCLAUSE
            End If



            gridbillchallan.ClearColumnsFilter()
            For i As Integer = 0 To gridbillchallan.RowCount - 1
                Dim dtrow As DataRow = gridbillchallan.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If CHALLANCLAUSE = "" Then
                        CHALLANCLAUSE = " AND ({LOT_VIEW.CHALLANNO} = '" & dtrow("CHALLANNO") & "'"
                    Else
                        CHALLANCLAUSE = CHALLANCLAUSE & " OR {LOT_VIEW.CHALLANNO} = '" & dtrow("CHALLANNO") & "'"
                    End If
                End If
            Next
            If CHALLANCLAUSE <> "" Then
                CHALLANCLAUSE = CHALLANCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & CHALLANCLAUSE
            End If


            Gridparty.ClearColumnsFilter()
            For i As Integer = 0 To Gridparty.RowCount - 1
                Dim dtrow As DataRow = Gridparty.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If PARTYCLAUSE = "" Then
                        PARTYCLAUSE = " AND ({LOT_VIEW.JOBBERNAME} = '" & dtrow("NAME") & "'"
                    Else
                        PARTYCLAUSE = PARTYCLAUSE & " OR {LOT_VIEW.JOBBERNAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next
            If PARTYCLAUSE <> "" Then
                PARTYCLAUSE = PARTYCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & PARTYCLAUSE
            End If


            GRIDITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND ({LOT_VIEW.ITEMNAME} = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR {LOT_VIEW.ITEMNAME} = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & ITEMCLAUSE
            End If



            If CHKSUMMARY.Checked = True Then
                OBJGRN.FRMSTRING = "FULLSUMMARY"
            ElseIf RDBFULL.Checked = True Then
                OBJGRN.FRMSTRING = "FULL"
            ElseIf RDBPENDING.Checked = True Then
                OBJGRN.FRMSTRING = "FULLPENDING"
            ElseIf RDBCOMPLETE.Checked = True Then
                OBJGRN.FRMSTRING = "FULLCOMPLETED"
            End If

            If LOTSTATUSONMTRS = False Then
                If RDBPENDING.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.BALPCS}>0 AND {LOT_VIEW.LOTCOMPLETED}=FALSE"
                ElseIf RDBCOMPLETE.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and ({LOT_VIEW.BALPCS}=0 OR {LOT_VIEW.LOTCOMPLETED}=TRUE)"
                End If
            Else
                If RDBPENDING.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.LOTCOMPLETED}=FALSE"
                ElseIf RDBCOMPLETE.Checked = True Then
                    OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {LOT_VIEW.LOTCOMPLETED}=TRUE"
                End If
            End If

            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Sub fillcmb()
        Try
            Dim WHERECLAUSE As String = ""
            If CMBJOBBER.Text.Trim = "" Then fillname(CMBJOBBER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' ")
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBGROUP.Text.Trim = "" Then FILLGROUP(CMBGROUP)
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id ", " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridpartydetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                Gridparty.FocusedRowHandle = Gridparty.RowCount - 1
                Gridparty.TopRowIndex = Gridparty.RowCount - 15
            End If

            '' If CHKALLCMP.Checked = False Then WHERECLAUSE = " AND ITEMMASTER.ITEM_YEARID = " & YearId
            Dim DTITEM As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME ", " ", " ITEMMASTER ", WHERECLAUSE & " ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDITEMDETAILS.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDITEM.FocusedRowHandle = GRIDITEM.RowCount - 1
                GRIDITEM.TopRowIndex = GRIDITEM.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBER_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBJOBBER.Validated
        Try
            Dim OBJCMN As New ClsCommon
            'Dim dt As DataTable = OBJCMN.search(" DISTINCT  CAST (0 AS BIT) AS CHK, LOTNO ", " ", " (SELECT   DISTINCT  CHECKINGMASTER.CHECK_LOTNO AS LOTNO, CHECKINGMASTER.CHECK_NO AS FROMNO,  CHECKINGMASTER.CHECK_cmpid AS CMPID, CHECKINGMASTER.CHECK_locationid AS LOCATIONID, CHECKINGMASTER.CHECK_yearid AS YEARID FROM CHECKINGMASTER INNER JOIN CHECKINGMASTER_DESC ON CHECKINGMASTER.CHECK_NO = CHECKINGMASTER_DESC.CHECK_NO AND CHECKINGMASTER.CHECK_CMPID = CHECKINGMASTER_DESC.CHECK_CMPID AND CHECKINGMASTER.CHECK_LOCATIONID = CHECKINGMASTER_DESC.CHECK_LOCATIONID AND CHECKINGMASTER.CHECK_YEARID = CHECKINGMASTER_DESC.CHECK_YEARID INNER JOIN LEDGERS ON CHECKINGMASTER.CHECK_LEDGERID = LEDGERS.Acc_id AND CHECKINGMASTER.CHECK_CMPID = LEDGERS.Acc_cmpid AND CHECKINGMASTER.CHECK_LOCATIONID = LEDGERS.Acc_locationid AND CHECKINGMASTER.CHECK_YEARID = LEDGERS.Acc_yearid  WHERE LEDGERS.ACC_CMPNAME = '" & CMBJOBBER.Text.Trim & "' AND (CHECKINGMASTER.CHECK_TYPE = 'JOB WORK') AND CHECKINGMASTER_DESC.CHECK_CHECKINGDONE = 0  UNION ALL SELECT   DISTINCT  STOCKMASTER.SM_LOTNO, SM_NO AS FROMNO, SM_CMPID, SM_LOCATIONID, SM_YEARID  FROM STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERIDTO = LEDGERS.Acc_id AND STOCKMASTER.SM_CMPID = LEDGERS.Acc_cmpid AND STOCKMASTER.SM_LOCATIONID = LEDGERS.Acc_locationid And STOCKMASTER.SM_YEARID = LEDGERS.Acc_yearid WHERE LEDGERS.ACC_CMPNAME = '" & CMBJOBBER.Text.Trim & "' AND SM_TYPE = 'JOBBERSTOCK' AND SM_LOTNO <> ''  ) AS T ", " AND T.YEARID = " & YearId)
            Dim dt As DataTable = OBJCMN.search(" DISTINCT  CAST (0 AS BIT) AS CHK, LOTNO ", " ", " LOT_VIEW ", " AND LOTNO <> '' AND JOBBERNAME ='" & CMBJOBBER.Text.Trim & "' AND YEARID = " & YearId)
            Dim dt1 As DataTable = OBJCMN.search(" DISTINCT  CAST (0 AS BIT) AS CHK, ISNULL(CHALLANNO,'') AS CHALLANNO ", " ", " LOT_VIEW ", " AND ISNULL(CHALLANNO,'') <> '' AND JOBBERNAME ='" & CMBJOBBER.Text.Trim & "' AND YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            gridbilldetailschallan.DataSource = dt1
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
            If dt1.Rows.Count > 0 Then
                gridbillchallan.FocusedRowHandle = gridbillchallan.RowCount - 1
                gridbillchallan.TopRowIndex = gridbillchallan.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTPARTY_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTPARTY.CheckedChanged
        Try
            For i As Integer = 0 To Gridparty.RowCount - 1
                Dim dtrow As DataRow = Gridparty.GetDataRow(i)
                dtrow("CHK") = CHKSELECTPARTY.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTITEM_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTITEM.CheckedChanged
        Try
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                dtrow("CHK") = CHKSELECTITEM.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class