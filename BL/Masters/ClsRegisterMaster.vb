
Imports DB

Public Class ClsRegisterMaster

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
            Dim strCommand As String = "SP_MASTER_REGISTERMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@registername", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@registerabbr", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@registerinitials", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@registertype", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@registerdefault", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@ledgername", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(10)))

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
            Dim strCommand As String = "SP_MASTER_REGISTERMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@registername", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@registerabbr", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@registerinitials", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@registertype", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@registerdefault", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@ledgername", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@registerid", alParaval(11)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_REGISTERMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGTYPE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
