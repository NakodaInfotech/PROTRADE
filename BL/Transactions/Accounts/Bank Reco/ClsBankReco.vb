
Imports DB

Public Class ClsBankReco

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

    Public Function GETTOTAL() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BANKRECO_GETTOTAL"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(5)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function GETDATA() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BANKRECO_GETDATA"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(5)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function GETALLDATA() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_BANKRECO_GETALLDATA"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(5)))
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
            'save Journal
            Dim strCommand As String = "SP_TRANS_BANKRECO_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLYEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'save Journal
            Dim strCommand As String = "SP_TRANS_BANKRECO_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLYEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
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
