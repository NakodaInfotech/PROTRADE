Imports DB

Public Class ClsBeamIssueToWeaver

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
            Dim strCommand As String = "SP_MFG_BEAMISSUETOWEAVER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BEAMISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICALNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@SCHSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHBEAMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHLOOMNO", alParaval(I)))
                I = I + 1



                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEAMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEAMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAPLINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WTCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOOMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADDATE", alParaval(I)))
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
            Dim strCommand As String = "SP_MFG_BEAMISSUETOWEAVER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BEAMISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICALNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@SCHSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHBEAMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCHLOOMNO", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEAMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BEAMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ENDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAPLINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WTCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOOMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADDATE", alParaval(I)))
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

    Public Function selectBEAMISSUE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTBEAMISSUETOWEAVER_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BEAMISSUENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_MFG_BEAMISSUETOWEAVER_DELETE"
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


    Public Function SAVEUPLOAD() As Integer
        Dim INTRESULT As Integer
        Try
            Dim STRCOMMAND As String = "SP_MFG_BEAMISSUETOWEAVER_SAVEUPLOAD"
            Dim ALPARAMATER As New ArrayList
            With ALPARAMATER
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BEAMISSUENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            INTRESULT = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMATER)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
