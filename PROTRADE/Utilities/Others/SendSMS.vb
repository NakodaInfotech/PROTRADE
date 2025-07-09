Imports BL
Imports System.IO
Imports System.Net

Public Class SendSMS

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            If ALLOWSMS = True Then
                If SENDMSG(txtmailbody.Text.Trim, txtmobileno.Text.Trim) = "1701" Then
                    MsgBox("Message Sent")
                    txtmailbody.Clear()
                    txtmobileno.Clear()
                Else
                    MsgBox("Error Sending Message")
                End If
            End If
            txtmobileno.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If txtmobileno.Text.Trim = "" Then
            gridbill.ClearColumnsFilter()
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If dtrow("MOBILENO").ToString.Trim <> "" Then
                        If txtmobileno.Text.Trim = "" Then
                            txtmobileno.Text = dtrow("MOBILENO")
                        Else
                            txtmobileno.Text = txtmobileno.Text & "," & dtrow("MOBILENO")
                        End If
                    End If
                End If
            Next
        End If


        If txtmobileno.Text.Trim.Length = 0 Then
            EP.SetError(txtmobileno, "Enter Mobile No")
            bln = False
        End If

        If txtmailbody.Text.Trim = "" Then
            EP.SetError(txtmobileno, "Enter Message")
            bln = False
        End If
        Return bln
    End Function

    Sub FILLGRID()
        Try

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS GROUPNAME, ISNULL(LEDGERS.ACC_MOBILE,'') AS MOBILENO, ISNULL(CITY_NAME,'') AS CITY ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND (GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' OR GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors') AND ISNULL(LEDGERS.ACC_MOBILE,'') <> '' AND (LEDGERS.ACC_YEARID = " & YearId & ") ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SendSMS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.OemSemicolon Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendSMS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILLGRID()
    End Sub

End Class