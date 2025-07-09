Imports DB

Public Class Clsformtype

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

#Region "Functions"

    Public Function saveform() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_formtype_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@form_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FORM_REMARK", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@form_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@form_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@form_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@form_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@form_transfer", alParaval(6)))
        
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function Updateform() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_formtype_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@form_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@form_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@form_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@form_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@form_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@form_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@form_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@formid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function


#End Region

End Class
