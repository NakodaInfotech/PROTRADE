Imports DB

Public Class ClsTaxMaster

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

            'save Taxmaster
            Dim strCommand As String = "SP_MASTER_TAXMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@taxname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@taxabbr", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@taxremarks", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@ISVAT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@ISCST", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@ISGST", alParaval(10)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer

        Try

            'save Taxmaster
            Dim strCommand As String = "SP_MASTER_TAXMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@taxname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@taxabbr", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@taxremarks", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@ISVAT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@ISCST", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@ISGST", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@taxid", alParaval(11)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As Integer
        Dim INTRESULT As Integer
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_TAXMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region


End Class
