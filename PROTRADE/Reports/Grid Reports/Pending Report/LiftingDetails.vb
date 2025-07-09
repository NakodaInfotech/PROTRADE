Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class LiftingDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub LiftingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LiftingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If RBUNLIFTED.Checked = True Then WHERECLAUSE = " AND DELIVERYORDER_DESC.DO_LIFTINGDATE IS NULL " Else WHERECLAUSE = " AND DELIVERYORDER_DESC.DO_LIFTINGDATE IS NOT NULL"
            Dim OBJCMN As New ClsCommonMaster

            'OLD CODE WITH LIFTDATE AS VARCHAR
            'Dim dt As DataTable = OBJCMN.search(" DELIVERYORDER.DO_no AS SRNO,DELIVERYORDER_DESC.DO_GRIDSRNO AS GRIDSRNO, DELIVERYORDER.DO_date AS DATE, DELIVERYORDER_DESC.DO_LRNO AS LRNO, MILLLEDGERS.Acc_cmpname AS MILLNAME, ISNULL(QUALITY_NAME,'') AS QUALITYNAME, WAREHOUSE.GODOWN_NAME AS WAREHOUSE, TRANSLEDGERS.Acc_cmpname AS TRANSNAME, ISNULL(GODOWNMASTER.GODOWN_NAME, '') AS OURGODOWN, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, DELIVERYORDER_DESC.DO_BAGS AS BAGS, (CASE WHEN CAST(DELIVERYORDER_DESC.DO_LIFTINGDATE AS DATE) = NULL THEN NULL ELSE CAST(DELIVERYORDER_DESC.DO_LIFTINGDATE AS DATE) END) AS LIFTDATE ", " ", "  GODOWNMASTER RIGHT OUTER JOIN LEDGERS AS MILLLEDGERS INNER JOIN DELIVERYORDER INNER JOIN DELIVERYORDER_DESC ON DELIVERYORDER.DO_no = DELIVERYORDER_DESC.DO_NO AND DELIVERYORDER.DO_yearid = DELIVERYORDER_DESC.DO_YEARID INNER JOIN LEDGERS AS TRANSLEDGERS ON DELIVERYORDER.DO_transledgerid = TRANSLEDGERS.Acc_id INNER JOIN GODOWNMASTER AS WAREHOUSE ON DELIVERYORDER_DESC.DO_GODOWNID = WAREHOUSE.GODOWN_ID ON MILLLEDGERS.Acc_id = DELIVERYORDER_DESC.DO_MILLID LEFT OUTER JOIN LEDGERS AS JOBBERLEDGERS ON DELIVERYORDER.DO_JOBBERID = JOBBERLEDGERS.Acc_id ON GODOWNMASTER.GODOWN_ID = DELIVERYORDER.DO_OURGODOWNID INNER JOIN QUALITYMASTER ON QUALITY_ID =DELIVERYORDER_DESC.DO_QUALITYID", WHERECLAUSE & " AND (DELIVERYORDER.DO_YEARID = '" & YearId & "') ORDER BY DELIVERYORDER.DO_NO, DELIVERYORDER_DESC.DO_GRIDSRNO")
            Dim dt As DataTable = OBJCMN.search(" DELIVERYORDER.DO_no AS SRNO,DELIVERYORDER_DESC.DO_GRIDSRNO AS GRIDSRNO, DELIVERYORDER.DO_date AS DATE, DELIVERYORDER_DESC.DO_LRNO AS LRNO,  ISNULL(MILLLEDGERS.Acc_cmpname,'') AS MILLNAME, ISNULL(QUALITY_NAME,'') AS QUALITYNAME, WAREHOUSE.GODOWN_NAME AS WAREHOUSE, TRANSLEDGERS.Acc_cmpname AS TRANSNAME, ISNULL(GODOWNMASTER.GODOWN_NAME, '') AS OURGODOWN, ISNULL(JOBBERLEDGERS.Acc_cmpname, '') AS JOBBERNAME, DELIVERYORDER_DESC.DO_BAGS AS BAGS, CAST(DELIVERYORDER_DESC.DO_LIFTINGDATE  AS DATE) AS LIFTDATE ", " ", "  LEDGERS AS JOBBERLEDGERS RIGHT OUTER JOIN LEDGERS AS TRANSLEDGERS RIGHT OUTER JOIN DELIVERYORDER INNER JOIN DELIVERYORDER_DESC ON DELIVERYORDER.DO_no = DELIVERYORDER_DESC.DO_NO AND DELIVERYORDER.DO_yearid = DELIVERYORDER_DESC.DO_YEARID INNER JOIN QUALITYMASTER ON DELIVERYORDER_DESC.DO_QUALITYID = QUALITYMASTER.QUALITY_ID LEFT OUTER JOIN GODOWNMASTER AS WAREHOUSE ON DELIVERYORDER_DESC.DO_GODOWNID = WAREHOUSE.GODOWN_ID ON TRANSLEDGERS.Acc_id = DELIVERYORDER.DO_transledgerid LEFT OUTER JOIN LEDGERS AS MILLLEDGERS ON DELIVERYORDER_DESC.DO_MILLID = MILLLEDGERS.Acc_id ON JOBBERLEDGERS.Acc_id = DELIVERYORDER.DO_JOBBERID LEFT OUTER JOIN GODOWNMASTER ON DELIVERYORDER.DO_OURGODOWNID = GODOWNMASTER.GODOWN_ID", WHERECLAUSE & " AND (DELIVERYORDER.DO_YEARID = '" & YearId & "') ORDER BY DELIVERYORDER.DO_NO, DELIVERYORDER_DESC.DO_GRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJDO As New DeliveryOrder
                OBJDO.MdiParent = MDIMain
                OBJDO.EDIT = editval
                OBJDO.TEMPDONO = DONO
                OBJDO.Show()
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

            If IsDBNull(ROW("LIFTDATE")) = False Then DT = OBJCMN.Execute_Any_String("UPDATE DELIVERYORDER_DESC SET DO_LIFTINGDATE = '" & Format(Convert.ToDateTime(ROW("LIFTDATE")).Date, "MM/dd/yyyy") & "' WHERE DO_NO = " & ROW("SRNO") & " AND DO_GRIDSRNO = " & ROW("GRIDSRNO") & " AND DO_YEARID = " & YearId, "", "")
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
            If IsDBNull(gridbill.GetRowCellValue(e.RowHandle, "LIFTDATE")) = False Then
                If gridbill.GetRowCellValue(e.RowHandle, "LIFTDATE") < Convert.ToDateTime(gridbill.GetRowCellValue(e.RowHandle, "DATE")).Date Then
                    e.Valid = False
                    gridbill.SetColumnError(GLIFTDATE, "Date must be After DO Date")
                    Exit Sub
                End If
            End If
            If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If IsDBNull(ROW("LIFTDATE")) = True Then
                MsgBox("No Row To Delete")
                Exit Sub
            End If

            If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            DT = OBJCMN.Execute_Any_String("UPDATE DELIVERYORDER_DESC SET DO_LIFTINGDATE = NULL  WHERE DO_NO = " & ROW("SRNO") & " AND DO_GRIDSRNO = " & ROW("GRIDSRNO") & " AND DO_YEARID = " & YearId, "", "")
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class