
Imports DB

Public Class ClsYarnRecd

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
            Dim strCommand As String = "SP_TRANS_YARNRECD_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWNDATE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDLOTNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POGRIDSRNO", alParaval(I)))
                I = I + 1



                'POGRID
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERYARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERDESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRECDBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_YARNRECD_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWNDATE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDLOTNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POGRIDSRNO", alParaval(I)))
                I = I + 1



                'POGRID
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERYARNQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERDESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRECDBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@YARNNO", alParaval(I)))
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
            strcommand = "SP_TRANS_YARNRECD_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@YARNNO", alParaval(I)))
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

    Public Function selectYARN(ByVal YARNNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTYARNRECD_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@YARNno", YARNNO))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@LocationID", LocationID))
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
            Dim strCommand As String = "SP_TRANS_YARNRECD_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@YARNno", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region
End Class
