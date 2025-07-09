Imports DB

Public Class ClsChangeReminderDays
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Function"

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_REMINDERDAYS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_REMINDERDAYS_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function GETREMINDERDAYS(ByVal Cmpid As Integer) As DataTable
        Dim DT As DataTable
        Try
            Dim strcommand As String = "SP_MASTER_SELECT_REMINDERDAYS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpid", Cmpid))
            End With
            DT = objDBOperation.execute(strcommand, alParameter).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return DT
    End Function

#End Region

End Class
