
Imports DB

Public Class ClsYarnChallan

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
            Dim strCommand As String = "SP_TRANS_YARNCHALLAN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_YARNCHALLAN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
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

    Public Function SELECTYARN(ByVal YARNNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTYARNCHALLAN_FOR_EDIT"
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

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_YARNCHALLAN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@YARNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
