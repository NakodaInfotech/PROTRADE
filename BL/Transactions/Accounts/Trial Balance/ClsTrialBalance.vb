
Imports DB

Public Class ClsTrialBalance

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
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_SUMMARY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETDETAILS() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETDETAILSRND() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_DETAILS_RND"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETDETAILSOPCLOSINGRND() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_OPCLO_DETAILS_RND"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETSUMMARYOPCLOSING() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_OPCLO_SUMMARY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETDETAILSOPCLOSING() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_OPCLO_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@OPENINGDR", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@OPENINGCR", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@DEBIT", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CREDIT", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@CLOSINGDR", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@CLOSINGCR", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@ROWNO", alParaval(8)))

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
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_TRIALBALANCE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))

            End With
            objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function SAVEOUTSTANDING() As Integer
        Dim intResult As Integer
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_TRANS_GRIDOUTSTANDING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region

End Class
