
Imports DB

Public Class ClsInterestCalc

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

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_INTEREST_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@PERIOD", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@INTPER", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@DRBAL", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CRBAL", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@INTREC", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@INTPAY", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TDSAMT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@TDSFORM", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@PANNO", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@GROUPNAME", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@LINENO", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@SIDEINT", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@TOTALINT", alParaval(16)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function SAVEDETAILS() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_INTERESTDETAILS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PERIOD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INTPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSPER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDSFORM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PANNO", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SIDE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DRBAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CRBAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NETTBALANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INTTOPAY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INTTOREC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LINENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GROUPNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
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
