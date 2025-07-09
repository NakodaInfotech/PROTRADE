
Imports DB

Public Class ClsTDSChallan

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

    Public Function GETALL() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_TRANS_TDSCHALLAN_GETALL"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(5)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETUNPAID() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_TRANS_TDSCHALLAN_GETUNPAID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@fromdate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@todate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(5)))
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
            Dim strCommand As String = "SP_TRANS_TDSCHALLAN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHQNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@UNPAID", alParaval(I)))
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
