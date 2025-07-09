
Imports BL
Imports DevExpress.XtraEditors.Controls

Public Class LockAccYear
    Private Sub LockAccYear_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LockAccYear_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim dt As DataTable = OBJCMN.search(" YEAR_ID AS YEARID, CONVERT(char(11), year_startdate , 6) + '   ---   ' + CONVERT(char(11), year_enddate , 6) AS ACCYEAR, CAST((CASE WHEN ISNULL(LOCKYEAR.YEARID,0) > 0 THEN 'TRUE' ELSE 'FALSE' END) AS BIT) AS LOCKED", "", " YEARMASTER LEFT OUTER JOIN LOCKYEAR ON YEAR_ID = LOCKYEAR.YEARID", " AND YEAR_CMPID = " & CmpId & " ORDER BY YEAR_STARTDATE")
            gridbilldetails.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            If ROW Is Nothing Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If Convert.ToBoolean(ROW("LOCKED")) = True Then
                DT = OBJCMN.Execute_Any_String("DELETE FROM LOCKYEAR WHERE YEARID = " & Val(ROW("YEARID")), "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO LOCKYEAR VALUES (" & Val(ROW("YEARID")) & "," & CmpId & ")", "", "")
            End If
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
            If gridbill.GetRowCellValue(e.RowHandle, "LOCKED") = True Then If MsgBox("Save Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Call CMDOK_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try

            Dim ROW As DataRow = gridbill.GetFocusedDataRow
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If MsgBox("Delete Data?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            DT = OBJCMN.Execute_Any_String("DELETE FROM LOCKYEAR WHERE YEARID = " & Val(ROW("YEARID")), "", "")
            fillgrid()
            gridbill.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class