Imports DB

Public Class ClsStockAdjustment

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
            Dim strCommand As String = "SP_UTILITIES_STOCKADJUSTMENT_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALINPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALINMTRS", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALRATE", alParaval(I)))
                'I = I + 1

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
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1



                'INGRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@INGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INPIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INBALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INGRIDDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INDESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INQTYUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INRACK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSHELF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INBARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INGRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INOUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INOUTMTRS", alParaval(I)))
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
            Dim strCommand As String = "SP_UTILITIES_STOCKADJUSTMENT_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALINPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALINMTRS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1



                'INGRID PARAMETERS
                .Add(New SqlClient.SqlParameter("@INGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INPIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INBALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INGRIDDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INDESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INQTYUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INRACK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSHELF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INBARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INGRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INOUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INOUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SANO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTSTOCKADJUSTMENT(ByVal RECONO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTSTOCKADJUSTMENT_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@RECONO", RECONO))
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
            Dim strCommand As String = "SP_UTILITIES_STOCKADJUSTMENT_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@RECONO", alParaval(0)))
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
