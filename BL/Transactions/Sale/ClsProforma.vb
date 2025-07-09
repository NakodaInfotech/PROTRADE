Imports DB
Public Class ClsProforma
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
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_PROFORMA_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPATCHTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEDONE", alParaval(I)))
                I = I + 1
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_PROFORMA_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPATCHTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALEDONE", alParaval(I)))
                I = I + 1
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRONO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPROFORMA(ByVal PRONO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPROFORMA_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRONO", PRONO))
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
            Dim strCommand As String = "SP_TRANS_SALE_PROFORMA_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(4)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class


