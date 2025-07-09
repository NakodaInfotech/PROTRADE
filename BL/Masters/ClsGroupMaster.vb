
Imports DB
Imports System.Data

Public Class ClsGroupMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer
    Dim groupid As Integer


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

    Public Function save() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_GROUPMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@groupname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@groupunder", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@groupremarks", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_GROUPMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@groupname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@groupunder", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@groupremarks", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@groupid", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
