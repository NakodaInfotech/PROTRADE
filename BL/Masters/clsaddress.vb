Imports DB
Public Class clsaddress

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

    Public Function save() As Integer
        Dim intResult As Integer

        Try

            'save gradeMaster
            Dim strCommand As String = "SP_MASTER_ADDRESSMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CMPNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ALIAS", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@ADDRESS", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@STATE", alParaval(11)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer
        Dim intResult As Integer

        Try

            'save gradeMaster
            Dim strCommand As String = "SP_MASTER_ADDRESSMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CMPNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ALIAS", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@ADDRESS", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@cstno", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@vatno", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@STATE", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@addressid", alParaval(12)))
              
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    

#End Region
End Class
