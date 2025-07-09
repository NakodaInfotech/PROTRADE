
Imports DB

Public Class ClsProductionFloorReturn

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
            Dim strCommand As String = "SP_TRANS_PRODUCTIONRETURN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1

                '''''UPLOAD

                '.Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                'I = I + 1


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
            Dim strCommand As String = "SP_TRANS_PRODUCTIONRETURN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1


                '''''UPLOAD

                '.Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@PRODRETNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SAVEUPLOAD() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_TRANS_PRODUCTIONRETURN_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PRODRETNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectPROD(ByVal PRODNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPRODUCTIONRETURN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRODRETNO", PRODNO))
                '.Add(New SqlClient.SqlParameter("@TYPE", CMBTYPE))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
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
            Dim strCommand As String = "SP_TRANS_PRODUCTIONRETURN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRODRETNO", alParaval(0)))
                '.Add(New SqlClient.SqlParameter("@TYPE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                '.Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(2)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
