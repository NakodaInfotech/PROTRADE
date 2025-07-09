
Imports DB

Public Class ClsJournalRegister

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
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_journalREGISTER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CHECK", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function getSUMMARY() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_JOURNAL_SUMMARY"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@REGNAME", alParaval(0)))
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
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_JOURNAL_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@REGNAME", alParaval(0)))
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

    Public Function GETDAILY() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_JOURNAL_DAILY"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@REGNAME", alParaval(0)))
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

#End Region

End Class
