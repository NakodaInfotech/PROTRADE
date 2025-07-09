Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class PendingConeDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub PendingConeDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingConeDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim WHERECLAUSE As String = ""
            If RBPENDING.Checked = True Then WHERECLAUSE = " AND ISNULL(GRN_CONES,0) = 0 " Else WHERECLAUSE = " AND ISNULL(GRN_CONES,0) <> 0"
            Dim OBJCMN As New ClsCommonMaster
            Dim dt As DataTable = OBJCMN.search(" GRN.GRN_NO AS SRNO, GRN_GRIDSRNO AS GRIDSRNO, MILLLEDGERS.Acc_cmpname  AS MILLNAME, QUALITY_NAME AS QUALITY, GRN_LRNO AS LRNO, GRN_BAGS AS BAGS, GRN_WT AS WT, GRN_CONES AS CONES ", " ", "  GRN_DESC INNER JOIN GRN ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS AS MILLLEDGERS ON GRN_MILLID = MILLLEDGERS.Acc_id INNER JOIN QUALITYMASTER ON GRN_QUALITYID = QUALITY_ID  ", WHERECLAUSE & " AND (GRN.GRN_YEARID = '" & YearId & "') AND GRN_TYPE = 'YARN' ORDER BY GRN.GRN_NO, GRN_DESC.GRN_GRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal GRNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJGRN As New GRN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.EDIT = editval
                OBJGRN.tempgrnno = GRNNO
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try

            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            If ROW Is Nothing Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If IsDBNull(ROW("CONES")) = False Then DT = OBJCMN.Execute_Any_String("UPDATE GRN_DESC SET GRN_CONES = " & Val(ROW("CONES")) & " WHERE GRN_NO = " & ROW("SRNO") & " AND GRN_GRIDSRNO = " & ROW("GRIDSRNO") & " AND GRN_YEARID = " & YearId, "", "")

            'ALSO UPDATE THIS DETAILS IN DO AS PER JASHOK REQUIREMENT
            If IsDBNull(ROW("CONES")) = False Then DT = OBJCMN.Execute_Any_String("UPDATE DELIVERYORDER_DESC SET DO_CONES = " & Val(ROW("CONES")) & " WHERE DO_GRNNO = " & ROW("SRNO") & " AND DO_GRNSRNO = " & ROW("GRIDSRNO") & " AND DO_GRIDTYPE = 'GRN' AND DO_YEARID = " & YearId, "", "")


            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gridbill.InvalidRowException
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

    Private Sub gridbill_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gridbill.ValidateRow
        Try
            If Val(gridbill.GetRowCellValue(e.RowHandle, "CONES")) > 0 Then
                If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If IsDBNull(ROW("CONES")) = True Then
                MsgBox("No Row To Delete")
                Exit Sub
            End If

            If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            DT = OBJCMN.Execute_Any_String("UPDATE GRN_DESC SET GRN_CONES = 0  WHERE GRN_NO = " & ROW("SRNO") & " AND GRN_GRIDSRNO = " & ROW("GRIDSRNO") & " AND GRN_YEARID = " & YearId, "", "")
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class