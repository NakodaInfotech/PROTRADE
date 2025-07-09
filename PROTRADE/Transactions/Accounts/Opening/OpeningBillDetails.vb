
Imports BL

Public Class OpeningBillDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String = ""

    Private Sub OpeningBillDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub OpeningBillDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If FRMSTRING = "OPENINGBILLS" Then
                lbl.Text = "Opening Bill"
                Me.Text = "Opening Bill"
            Else
                lbl.Text = "Opening Bill (Interest)"
                Me.Text = "Opening Bill (Interest)"
            End If
            fillgridname()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgridname(Optional ByVal whereclause As String = "")
        Try
            Dim objClsCommon As New ClsCommonMaster
            Dim dttable As DataTable
            If FRMSTRING = "OPENINGBILLS" Then
                dttable = objClsCommon.search(" DISTINCT LEDGERS.ACC_CMPNAME as NAME", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL.BILL_LOCATIONID = LEDGERS.Acc_locationid AND OPENINGBILL.BILL_YEARID = LEDGERS.Acc_yearid ", whereclause & " and Acc_cmpid = " & CmpId & " and Acc_locationid = " & Locationid & " and Acc_yearid = " & YearId & " order by Acc_cmpname")
            Else
                dttable = objClsCommon.search(" DISTINCT LEDGERS.ACC_CMPNAME as NAME", "", " OPENINGBILL_INT INNER JOIN LEDGERS ON OPENINGBILL_INT.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL_INT.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL_INT.BILL_LOCATIONID = LEDGERS.Acc_locationid AND OPENINGBILL_INT.BILL_YEARID = LEDGERS.Acc_yearid ", whereclause & " and Acc_cmpid = " & CmpId & " and Acc_locationid = " & Locationid & " and Acc_yearid = " & YearId & " order by Acc_cmpname")
            End If
            griduserdetails.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getdetails(ByRef name As String)
        Dim OBJCMN As New ClsCommon
        Dim dttable As DataTable
        If FRMSTRING = "OPENINGBILLS" Then
            dttable = OBJCMN.search(" LEDGERS.Acc_cmpname AS NAME, OPENINGBILL.BILL_GRIDSRNO AS SRNO, OPENINGBILL.BILL_TYPE AS TYPE, OPENINGBILL.BILL_NO AS BILLNO, OPENINGBILL.BILL_YEAR AS YEAR, OPENINGBILL.BILL_DATE AS DATE, OPENINGBILL.BILL_DUEDATE AS DUEDATE,OPENINGBILL.BILL_AMT AS AMT", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL.BILL_LOCATIONID = LEDGERS.Acc_locationid AND OPENINGBILL.BILL_YEARID = LEDGERS.Acc_yearid", " AND LEDGERS.ACC_CMPNAME = '" & name & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId & " ORDER BY BILL_GRIDSRNO")
        Else
            dttable = OBJCMN.search(" LEDGERS.Acc_cmpname AS NAME, OPENINGBILL_INT.BILL_GRIDSRNO AS SRNO, OPENINGBILL_INT.BILL_TYPE AS TYPE, OPENINGBILL_INT.BILL_NO AS BILLNO, OPENINGBILL_INT.BILL_YEAR AS YEAR, OPENINGBILL_INT.BILL_DATE AS DATE, OPENINGBILL_INT.BILL_DUEDATE AS DUEDATE,OPENINGBILL_INT.BILL_AMT AS AMT", "", " OPENINGBILL_INT INNER JOIN LEDGERS ON OPENINGBILL_INT.BILL_LEDGERID = LEDGERS.Acc_id AND OPENINGBILL_INT.BILL_CMPID = LEDGERS.Acc_cmpid AND OPENINGBILL_INT.BILL_LOCATIONID = LEDGERS.Acc_locationid AND OPENINGBILL_INT.BILL_YEARID = LEDGERS.Acc_yearid", " AND LEDGERS.ACC_CMPNAME = '" & name & "' AND BILL_CMPID = " & CmpId & " AND BILL_LOCATIONID = " & Locationid & " AND BILL_YEARID = " & YearId & " ORDER BY BILL_GRIDSRNO")
        End If
        griddetails.DataSource = dttable
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEDIT.Click
        Try
            showform(True, GRIDUSERNAME.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And GRIDUSERNAME.RowCount > 0) Then
                Dim OBJOP As New OpeningBills
                OBJOP.MdiParent = MDIMain
                OBJOP.FRMSTRING = FRMSTRING
                OBJOP.TEMPNAME = name
                OBJOP.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDUSERNAME.Click
        Try
            getdetails(GRIDUSERNAME.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDUSERNAME.DoubleClick
        Try
            showform(True, GRIDUSERNAME.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GRIDUSERNAME.FocusedRowChanged
        Try
            getdetails(GRIDUSERNAME.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningBillDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class