
Imports DB

Public Class ClsStockTransfer

    Private objDBOperation As New DBOperation
    Public alParaval As New ArrayList


    Public Function UPDATE() As Integer
        Dim INTRES As Integer
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_UTILITES_CHANGESTOCK"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
            End With

            INTRES = objDBOperation.executeNonQuery(strcommand, alParameter)
            Return 0
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
