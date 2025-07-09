
Imports DB

Public Class ClsDesignProcessWiseRateChart
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

#Region "Function"

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_DESIGNPROCESSWISERATECHART_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As Integer
        Try
            Dim strcommand As String = "SP_DESIGNPROCESSWISERATECHART_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(1)))
            End With
            Dim INTRES As Integer = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
