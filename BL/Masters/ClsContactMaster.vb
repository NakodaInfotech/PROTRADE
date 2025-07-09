Imports DB

Public Class ClsContactMaster
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

    Public Function SAVE() As DataTable

        Try

            Dim strCommand As String = "SP_MASTER_CONTACT_SAVE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SURNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1



            End With

            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CONTACT_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SURNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EMAIL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TEMPCONTACTNO", alParaval(I)))
                I += 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As Integer
        Try

            Dim STRCOMMAND As String = "SP_MASTER_CONTACT_DELETE"
            Dim SQLPARA As New ArrayList

            SQLPARA.Add(New SqlClient.SqlParameter("@CONTACTNO", alParaval(0)))

            Dim INTRES As Integer = objDBOperation.executeNonQuery(STRCOMMAND, SQLPARA)

            Return 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
