
Imports DB

Public Class ClsRateTypeMaster

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
        Try
            Dim strcommand As String = "SP_MASTER_RATETYPEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RATE01", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE02", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE03", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE04", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE05", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE06", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE07", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE08", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE09", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE10", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
