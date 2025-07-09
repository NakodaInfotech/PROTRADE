Imports DB
Public Class ClsUserGodownTagging
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim rackid As Integer
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


#Region "Function"

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            Dim strcommand As String = "SP_MASTER_USERGODOWN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@USER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
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

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try

            Dim strcommand As String = "SP_MASTER_USERGODOWN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@USER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TEMPUSER", alParaval(I)))
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
            Dim strcommand As String = "SP_MASTER_USERGODOWN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPUSER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)
            Return intResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GETUSER() As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_USERGODOWN_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPUSER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
            End With

            Dim DT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DT

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
End Class








