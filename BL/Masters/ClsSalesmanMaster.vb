Imports DB

Public Class ClsSalesmanMaster
    Private objDBOperation As DBOperation
    Public ALPARAVAL As New ArrayList

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

    'Save Master
    Public Function SAVE() As Integer
        Try

            Dim strcommand As String = "SP_MASTER_SALESMAN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", ALPARAVAL(I)))
                I += 1

            End With

            Dim INTERES As Integer = objDBOperation.executeNonQuery(strcommand, alParameter)
            Return 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Update Master
    Public Function UPDATE() As Integer
        Try
            Dim intResult As Integer
            Dim strcommand As String = "SP_MASTER_SALESMAN_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@NAME", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MOBILENO", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", ALPARAVAL(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TEMPID", ALPARAVAL(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    'Delete Master
    Public Function DELETE() As Integer
        Try

            Dim strcommand As String = ""
            strcommand = "SP_MASTER_SALESMAN_DELETE"

            Dim alParameter As New ArrayList

            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TEMPID", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", ALPARAVAL(I)))
                I += 1
            End With

            Dim INTES As Integer = objDBOperation.executeNonQuery(strcommand, alParameter)

            Return 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Select Name
    Public Function GETSALESMAN() As DataTable
        Try
            Dim dtTable As DataTable
            Dim strcommand As String = ""
            strcommand = "SP_MASTER_SALESMAN_SELECT"

            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TEMPID", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", ALPARAVAL(I)))
                I += 1
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
