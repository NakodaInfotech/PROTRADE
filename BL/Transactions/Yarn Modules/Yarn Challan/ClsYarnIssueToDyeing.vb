Imports DB


Public Class ClsYarnIssueToDyeing

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
            Dim strCommand As String = "SP_MFG_YARNISSUEDYEING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICALNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGNOCOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAREWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFRESH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFIRKA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPLIER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAREWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRESH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FIRKA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTYPE", alParaval(I)))
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
            Dim strCommand As String = "SP_MFG_YARNISSUEDYEING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICALNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGNOCOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAREWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFRESH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFIRKA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPLIER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAREWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRESH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WINDING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FIRKA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@YISSUENO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectYARNISSUE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTYARNISSUEDYEING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@YISSUENO", alParaval(0)))
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
            Dim strCommand As String = "SP_MFG_YARNISSUEDYEING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@YISSUENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
