
Imports DB

Public Class ClsDayBook

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function getdata() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_DAYBOOK"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CHECK", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function getDETAILS() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_DAYBOOK_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CHECK", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

#End Region

End Class
