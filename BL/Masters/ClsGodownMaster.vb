
Imports DB

Public Class ClsGodownMaster

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

            'save GODOWNMaster
            Dim strCommand As String = "SP_MASTER_GODOWNMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GODOWNname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GODOWNADDRESS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OURGODOWN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEFAULT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PINCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@KMS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1

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

            'save GODOWNMaster
            Dim strCommand As String = "SP_MASTER_GODOWNMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GODOWNname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GODOWNADDRESS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OURGODOWN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEFAULT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PINCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@KMS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STATENAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GODOWNid", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
