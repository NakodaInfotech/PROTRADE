
Imports DB

Public Class ClsOpeningStoreStock

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

    Public Function SAVE() As DataTable
        Try
            Dim strcommand As String = "SP_ACCOUNTS_OPENINGSTORE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@STOREITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            Dim DT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UPDATE() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_ACCOUNTS_OPENINGSTORE_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@STOREITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@OPSTOCKNO", alParaval(I)))
                I += 1
            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_ACCOUNTS_OPENINGSTORE_DELETE"

            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@TEMP_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))


            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function GETSTOCK() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_SELECTOPENINGSTORE_FOR_EDIT"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@OPSTOCKNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
