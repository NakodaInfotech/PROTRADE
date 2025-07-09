''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'' BOMBAY IT SOLUTIONS
''                                                                                                          ''
''                                                                                                          ''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    

Imports System.Data.SqlClient
Imports System.Collections

Public Class DBOperation

    Public objConnection As DBConnection
    Private _objTransaction As SqlTransaction

    Public Sub New()
        objConnection = New DBConnection
    End Sub

    Public ReadOnly Property ConnectionObject() As SqlConnection
        Get
            Return objConnection.GetConnection
        End Get
    End Property

    Public ReadOnly Property Transaction() As SqlTransaction
        Get
            Return _objTransaction
        End Get
    End Property

    Public Function StartNewTransaction() As SqlTransaction
        Try

            If objConnection.GetConnection.State = ConnectionState.Closed Or _
                objConnection.GetConnection.State = ConnectionState.Broken Then
                objConnection.GetConnection.Open()
            End If
            _objTransaction = ConnectionObject.BeginTransaction()
            Return _objTransaction
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CloseConnection()
        If ConnectionObject.State <> ConnectionState.Broken And _
            ConnectionObject.State <> ConnectionState.Closed Then objConnection.CloseConnection()
    End Sub

    Public Function executeNonQuery(ByVal CommandString As String) As Integer
        Dim intResult As Integer
        Try
            Dim objSqlCommand As New SqlCommand
            Try
                With objSqlCommand
                    .CommandText = CommandString
                    .CommandType = CommandType.StoredProcedure
                    .Connection = objConnection.GetConnection
                End With

                objConnection.OpenConnection()
                objSqlCommand.CommandTimeout = 9999
                intResult = objSqlCommand.ExecuteNonQuery

            Catch exsql As SqlException
                Throw exsql
            Catch ex As Exception
                Throw ex
                intResult = Nothing
            Finally
                objConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw ex
            intResult = Nothing
        End Try
        Return intResult
    End Function

    Public Function executeNonQuery(ByVal CommandString As String, ByVal parameter As ICollection, _
        Optional ByRef ErrorCode As Integer = 0) As Integer
        Dim intResult As Integer
        Try
            Dim objIEnumerator As IEnumerator
            Dim objSqlCommand As New SqlCommand
            Try
                objIEnumerator = parameter.GetEnumerator
                With objSqlCommand
                    .CommandText = CommandString
                    .CommandType = CommandType.StoredProcedure
                    .Connection = objConnection.GetConnection
                End With
                objSqlCommand.Parameters.Clear()
                objSqlCommand.CommandTimeout = 9999
                While objIEnumerator.MoveNext
                    objSqlCommand.Parameters.Add(objIEnumerator.Current)
                End While
                objConnection.OpenConnection()
                intResult = objSqlCommand.ExecuteNonQuery
            Catch exsql As SqlException
                ErrorCode = exsql.ErrorCode
                Throw exsql
            Catch ex As Exception
                Throw ex
                intResult = Nothing
            Finally
                objConnection.CloseConnection()
            End Try
        Catch ex As Exception
            Throw ex
            intResult = Nothing
        End Try
        Return intResult
    End Function

    Public Function executeNonQuery(ByVal CommandString As String, ByVal parameter As ICollection, _
    ByVal objTransaction As SqlTransaction, Optional ByRef ErrorCode As Integer = 0) As Integer
        Dim intResult As Integer
        Try
            Dim objIEnumerator As IEnumerator
            Dim objSqlCommand As New SqlCommand
            Try
                objIEnumerator = parameter.GetEnumerator
                With objSqlCommand
                    .CommandText = CommandString
                    .CommandType = CommandType.StoredProcedure
                    .Connection = objTransaction.Connection
                    .Transaction = objTransaction
                End With
                objSqlCommand.CommandTimeout = 9999
                objSqlCommand.Parameters.Clear()
                While objIEnumerator.MoveNext
                    objSqlCommand.Parameters.Add(objIEnumerator.Current)
                End While
                intResult = objSqlCommand.ExecuteNonQuery
            Catch exsql As SqlException
                ErrorCode = exsql.ErrorCode
                Throw exsql
            Catch ex As Exception
                Throw ex
                intResult = Nothing
            End Try
        Catch ex As Exception
            Throw ex
            intResult = Nothing
        End Try
        Return intResult
    End Function

    Public Function executeint(ByVal CommandString As String) As Integer
        Dim intResult As Integer = Nothing

        Dim objSqlCommand As New SqlCommand
        'Dim objSqlDataAdapter As New SqlDataAdapter
        Try
            With objSqlCommand
                .CommandText = CommandString
                .CommandType = CommandType.Text
                .Connection = objConnection.GetConnection
            End With
            objConnection.OpenConnection()
            objSqlCommand.CommandTimeout = 9999
            Dim obj As Object = objSqlCommand.ExecuteScalar()
            If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                intResult = CType(obj, Integer)
            End If
        Catch ex As Exception
            Throw ex
            intResult = Nothing
        End Try

        Return intResult
    End Function

    Public Function execute(ByVal CommandString As String) As DataSet
        Dim dsResult As DataSet = Nothing

        Dim objSqlCommand As New SqlCommand
        Dim objSqlDataAdapter As New SqlDataAdapter
        Try
            With objSqlCommand
                .CommandText = CommandString
                .CommandType = CommandType.Text
                .Connection = objConnection.GetConnection
            End With
            objSqlCommand.Parameters.Clear()
            objSqlCommand.CommandTimeout = 9999
            objSqlDataAdapter.SelectCommand = objSqlCommand
            dsResult = New DataSet

            objSqlDataAdapter.Fill(dsResult)
        Catch ex As Exception
            Throw ex
            dsResult = Nothing
        Finally
            If dsResult.Tables.Count = 0 Then
                Dim dt As New DataTable
                dsResult.Tables.Add(dt)
            End If
            objConnection.CloseConnection()
        End Try

        Return dsResult
    End Function

    Public Function execute(ByVal CommandString As String, ByVal parameter As ICollection) As DataSet
        Dim dsResult As DataSet

        Dim objIEnumerator As IEnumerator
        Dim objSqlCommand As New SqlCommand
        Dim objSqlDataAdapter As New SqlDataAdapter
        Try
            objIEnumerator = parameter.GetEnumerator
            With objSqlCommand
                .CommandText = CommandString
                .CommandType = CommandType.StoredProcedure
                .Connection = objConnection.GetConnection
            End With
            objSqlCommand.Parameters.Clear()
            objSqlCommand.CommandTimeout = 9999
            While objIEnumerator.MoveNext
                objSqlCommand.Parameters.Add(objIEnumerator.Current)
            End While
            objSqlDataAdapter.SelectCommand = objSqlCommand
            dsResult = New DataSet
            objSqlDataAdapter.Fill(dsResult)
        Catch ex As Exception
            Throw ex
            dsResult = Nothing
        End Try
        Return dsResult
    End Function

    Public Function execute(ByVal CommandString As String, ByVal parameter As ICollection, ByVal objTran As SqlClient.SqlTransaction) As DataSet
        Dim dsResult As DataSet

        Dim objIEnumerator As IEnumerator
        Dim objSqlCommand As New SqlCommand
        Dim objSqlDataAdapter As New SqlDataAdapter
        Try
            objIEnumerator = parameter.GetEnumerator
            With objSqlCommand
                .CommandText = CommandString
                .CommandType = CommandType.StoredProcedure
                .Connection = objConnection.GetConnection
                .Transaction = objTran
            End With
            objSqlCommand.Parameters.Clear()
            objSqlCommand.CommandTimeout = 9999
            While objIEnumerator.MoveNext
                objSqlCommand.Parameters.Add(objIEnumerator.Current)
            End While
            objSqlDataAdapter.SelectCommand = objSqlCommand
            dsResult = New DataSet
            objSqlDataAdapter.Fill(dsResult)
        Catch ex As Exception
            Throw ex
            dsResult = Nothing

        End Try

        Return dsResult
    End Function


End Class
