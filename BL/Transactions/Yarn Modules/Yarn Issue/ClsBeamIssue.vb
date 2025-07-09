
Imports DB

Public Class ClsBeamIssue

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
        Dim DTTABLE As DataTable
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_YARNISSUE_BEAMISSUE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@APPROXVALUE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BORENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEAMWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIPEWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@RSPACE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1




            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_YARNISSUE_BEAMISSUE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROXVALUE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BORENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEAMWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIPEWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@RSPACE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BEAMISSUENO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTISSUE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTBEAMISSUE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TEMPBEAMISSUENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_YARNISSUE_BEAMISSUE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class

