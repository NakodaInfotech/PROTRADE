
Imports DB

Public Class ClsBalanceSheet

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

    Public Function GETSUMMARY() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BALANCESHEET_SUMMARY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function GETDETAILS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BALANCESHEET_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function GETLEDGERDETAILS() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BALANCESHEET_LEDGERDETAILS_RND"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BALANCESHEET_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@LIANAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@LIADR", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LIACR", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@ASSNAME", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@ASSDR", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@ASSCR", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@ROWNO", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@LIABOLD", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@ASSBOLD", alParaval(9)))


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Sub DELETE(ByVal CMPID As Integer)
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BALANCESHEET_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))

            End With
            objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
