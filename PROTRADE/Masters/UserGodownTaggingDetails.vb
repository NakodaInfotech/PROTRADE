Imports BL

Public Class UserGodownTaggingDetails
    Private Sub RackDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJDEPT As New ClsUserGodownTagging
            OBJDEPT.alParaval.Add("")
            OBJDEPT.alParaval.Add(CmpId)
            Dim DT As DataTable = OBJDEPT.GETUSER
            GRIDBILLDETAILS.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal USER As String)
        Try
            Dim OBJDEPT As New UserGodownTagging
            OBJDEPT.MdiParent = MDIMain
            OBJDEPT.EDIT = EDITVAL
            OBJDEPT.TEMPUSER = USER
            OBJDEPT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
        Try
            SHOWFORM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("USER"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("USER"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PROFORMADetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                SHOWFORM(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class
