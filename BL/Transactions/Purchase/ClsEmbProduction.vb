
Imports DB

Public Class ClsEmbProduction

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
            Dim strCommand As String = "SP_TRANS_JOB_EMBPROD_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PRODENTRYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABOUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STITCHES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRAMES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RUNFRAMES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPROD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALPROD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@THREAD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@THREADMTRS", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_JOB_EMBPROD_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PRODENTRYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABOUR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STITCHES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRAMES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RUNFRAMES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPROD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALPROD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@THREAD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@THREADMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRODNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTEMBPROD(ByVal PRODNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTEMBPROD_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRODNO", PRODNO))
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

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_JOB_EMBPROD_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRODNO", alParaval(0)))
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
