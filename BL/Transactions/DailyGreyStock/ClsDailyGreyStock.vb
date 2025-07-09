Imports DB
Public Class ClsDailyGreyStock

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

    Public Function save() As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_DAILYGREYSTOCK_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@STOCKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSINGPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters


                .Add(New SqlClient.SqlParameter("@GRIDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDCLOSINGPCS", alParaval(I)))
                I = I + 1


            End With

            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_DAILYGREYSTOCK_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@STOCKNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSINGPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDCLOSINGPCS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPSTOCKNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectstock(ByVal STOCKNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_DAILYGREYSTOCK_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@STOCKNO", Stockno))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
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
            Dim strCommand As String = "SP_TRANS_DAILYGREYSTOCK_DELETE"
            Dim alParameter As New ArrayList
            Dim I As Integer = 0
            With alParameter
                .Add(New SqlClient.SqlParameter("@STOCKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(I)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
