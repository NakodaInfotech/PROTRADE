
Imports BL

Public Class BlockUser

    Dim INTRES As Integer
    Dim OBJTRF As New ClsYearTransfer
    Public FRMSTRING As String = ""

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try

            'transfering data from selected cmp
            If GRIDYEAR.SelectedRows.Count = 0 Then
                MsgBox("Select Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'CHEKC WHETHER IT IS ALREADY BLOCKED OR NOT
            If CMBTYPE.Text = "Block" Then
                DT = OBJCMN.search(" USERMASTER.USER_ID ", "", " USERBLOCKED INNER JOIN USERMASTER ON USERBLOCKED.USER_ID =  USERMASTER.USER_ID ", " AND USERMASTER.USER_NAME = '" & CMBUSER.Text.Trim & "' AND USERBLOCKED.USER_YEARID = " & GRIDYEAR.CurrentRow.Cells(GYEARID.Index).Value)
                If DT.Rows.Count > 0 Then
                    MsgBox("User Already Blocked for this Year", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            ElseIf CMBTYPE.Text = "Un-block" Then
                DT = OBJCMN.search(" USERMASTER.USER_ID ", "", " USERBLOCKED INNER JOIN USERMASTER ON USERBLOCKED.USER_ID =  USERMASTER.USER_ID ", " AND USERMASTER.USER_NAME = '" & CMBUSER.Text.Trim & "' AND USERBLOCKED.USER_YEARID = " & GRIDYEAR.CurrentRow.Cells(GYEARID.Index).Value)
                If DT.Rows.Count = 0 Then
                    MsgBox("User Already Un-Blocked for this Year", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            Dim SELECTEDYEARID As Integer = 0
            Dim TEMPMSG As Integer = MsgBox(CMBTYPE.Text.Trim & " User from Selected Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you sure, wish to Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    SELECTEDYEARID = GRIDYEAR.CurrentRow.Cells(GYEARID.Index).Value
                    BLOCKUSER(SELECTEDYEARID)
                    MsgBox("User " & CMBTYPE.Text.Trim & "ed Successfully")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlockUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            CMBTYPE.Text = "Block"
            fillUSER(CMBUSER, "")
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CONVERT(char(11), year_startdate , 6) + ' - ' + CONVERT(char(11), year_enddate , 6) AS YEARNAME, YEAR_ID AS YEARID   ", "", " YEARMASTER", " AND YEAR_ID <> " & YearId & " AND YEAR_CMPID = " & CmpId & " ORDER BY YEAR_ID DESC ")
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDYEAR.Rows.Add(DTROW("YEARNAME"), DTROW("YEARID"))
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BLOCKUSER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(CMBUSER.Text.Trim)
            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)
            If CMBTYPE.Text = "Block" Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.BLOCKUSER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class