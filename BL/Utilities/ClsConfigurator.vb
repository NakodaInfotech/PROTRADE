Imports DB

Public Class ClsConfigurator

    Private ObjDBOperation As DBOperation
    Public alParaval As New ArrayList


#Region "Constructor"
    Public Sub New()
        Try
            ObjDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Public Function UPDATE() As Integer
        Dim IntResult As Integer
        Try
            Dim strCommand As String = "SP_CONFIGURATOR_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MANUALINVOICE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIRECTPRINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKPRINTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYRATES", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONid", alParaval(I)))
                I = I + 1

            End With

            IntResult = ObjDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function
End Class
