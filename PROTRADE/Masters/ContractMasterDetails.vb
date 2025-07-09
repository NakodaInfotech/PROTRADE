
Imports BL

Public Class ContractMasterDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub RackDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDEPT As New ClsContractMaster
            OBJDEPT.alParaval.Add(0)
            OBJDEPT.alParaval.Add(YearId)
            Dim DT As DataTable = OBJDEPT.GETCONTRACT()
            GRIDBILLDETAILS.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal ID As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDEPT As New ContractMaster
            OBJDEPT.MdiParent = MDIMain
            OBJDEPT.EDIT = EDITVAL
            OBJDEPT.TEMPRACKID = ID
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
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("ID"))
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
            SHOWFORM(True, GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
