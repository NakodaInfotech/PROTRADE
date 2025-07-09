Imports DB
Imports System.Data

Public Class ClsCommonMaster

    Private objDBOperation As DBOperation
    Dim intResult As Integer

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

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function savecmb(ByVal cityname As String, ByVal userid As Integer, Optional ByVal whereclause As String = "") As Integer

        Dim strCmd As String = "SP_MASTER_CITYMASTER_SAVE"
        Dim alpara As New ArrayList
        With alpara
            .Add(New SqlClient.SqlParameter("@city_name", cityname))
            .Add(New SqlClient.SqlParameter("@city_userid", userid))
            .Add(New SqlClient.SqlParameter("@city_transfer", "0"))
        End With

        intResult = objDBOperation.executeNonQuery(strCmd, alpara)

    End Function

    'Creating Database
    Public Function CreateDatabase(ByVal dbname As String) As Integer
        Dim dtTable As New DataTable
        Dim intResult As Integer

        Try
            Dim strCommand As String = "create database [" & dbname & "]"
            dtTable = objDBOperation.execute(strCommand).Tables(0)
            'intResult = dtTable.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function

#End Region

End Class
