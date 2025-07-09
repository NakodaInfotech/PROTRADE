
Imports DB

Public Class ClsTransChallan

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_TRANSCHALLAN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TRANSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSGDNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPATCHTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPECHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_TRANSCHALLAN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TRANSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSGDNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPATCHTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPECHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSGDNNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTTRANSGDN() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTTRANSCHALLAN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TRANSGDNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_SALE_TRANSCHALLAN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TRANSGDNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
