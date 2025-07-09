
Imports BL

Public Class UserDetails


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, GRIDUSERNAME.GetFocusedRowCellValue("UserName"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal nedit As Boolean, ByVal user As String)
        Try

            If nedit = False And UserName <> "Admin" Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If nedit = True And UserName <> "Admin" And LCase(UserName) <> LCase(user) Then
                MsgBox("You Don't have Permission to change other Users")
                Exit Sub
            End If

            Dim objuser As New UserMaster
            objuser.MdiParent = MDIMain
            objuser.Uname = user
            objuser.edit = nedit
            objuser.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UserDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
                showform(False, "")
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UserDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillnamegrid()
            fillgrid(GRIDUSERNAME.GetFocusedRowCellValue("UserName"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillnamegrid()
        Try
            Dim objcmn As New ClsCommon
            Dim dt As New DataTable
            'dt = objcmn.search("User_Name as [UserName]", "", "USERMASTER", " AND USER_NAME  ='" & UserName & "' and USERMASTER.USER_cmpid= " & CmpId)
            dt = objcmn.search("DISTINCT User_Name as [UserName]", "", "USERMASTER", " and USERMASTER.USER_cmpid= " & CmpId & " ORDER BY USER_NAME ")
            griduserdetails.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal name As String)
        Try
            Dim objcmn As New ClsCommon
            Dim dtuser As New DataTable
            '' dtuser = objcmn.search("DISTINCT User_formName as [FormName], User_add as [Add], User_Edit as [Edit], User_View as [View], User_Delete as [Delete]", "", "USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID", " and USERMASTER.USER_NAME = '" & name & "' and usermaster.user_cmpid = " & CmpId & " order by user_formname")
            dtuser = objcmn.search(" ISNULL(FORM_NAME,'') AS [FormName], ISNULL(T.User_add,0) AS [Add] , ISNULL(T.User_Edit,0) AS [Edit], ISNULL(T.User_View,0) AS [View] ,ISNULL(T.User_Delete,0) AS [Delete] ", "", "FORMMASTER LEFT OUTER JOIN ( SELECT DISTINCT USERMASTER_RIGHTS.User_formName, USERMASTER_RIGHTS.User_add, USERMASTER_RIGHTS.User_Edit, USERMASTER_RIGHTS.User_View, USERMASTER_RIGHTS.User_Delete FROM USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER_RIGHTS.User_id = USERMASTER.User_id WHERE (USERMASTER.USER_NAME = '" & name & "' and usermaster.user_cmpid = " & CmpId & ")) AS T ON FORMMASTER.Form_name = T.User_formName ", " ORDER BY FORM_NAME ")
            griddetails.DataSource = dtuser
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDUSERNAME.Click
        Try
            fillgrid(GRIDUSERNAME.GetFocusedRowCellValue("UserName"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDUSERNAME_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GRIDUSERNAME.FocusedRowChanged
        Try
            fillgrid(GRIDUSERNAME.GetFocusedRowCellValue("UserName"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class