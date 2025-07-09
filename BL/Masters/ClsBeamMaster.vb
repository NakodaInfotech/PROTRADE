
Imports DB

Public Class ClsBeamMaster
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

    Public Function SAVE() As Integer

        Dim intResult As Integer

        Try

            Dim strCommand As String = "SP_MASTER_BEAMMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BEAM_NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAM_ENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAM_TL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WTMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WTTL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDWT", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Dim intResult As Integer

        Try

            Dim strCommand As String = "SP_MASTER_BEAMMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BEAM_NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAM_ENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAM_TL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WTMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WTTL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BEAMID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As DataTable

        Dim DT As DataTable

        Try

            Dim strCommand As String = "SP_MASTER_BEAMMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BEAMID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

#End Region

End Class
