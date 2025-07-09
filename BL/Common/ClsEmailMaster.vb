Imports DB
Imports System.Data

Public Class ClsEmailMaster

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
            Dim strCommand As String = "SP_MASTER_EMAILMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@email_id", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Email_name", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))

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
            Dim strCommand As String = "SP_MASTER_EMAILMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@email_id", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@email_name", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@email_oldname", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region


End Class
