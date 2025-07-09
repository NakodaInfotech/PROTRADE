
Imports DB

Public Class ClsShelfMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim SHELFid As Integer
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

            Dim strcommand As String = "SP_MASTER_SHELFMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
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

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try

            Dim strcommand As String = "SP_MASTER_SHELFMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
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


            Dim strcommand As String = "SP_MASTER_SHELFMASTER_DELETE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)
            Return intResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GETSHELF() As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_SHELFMASTER_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
            End With

            Dim DT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DT

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region


End Class





