
Imports DB

Public Class ClsSaleReturn

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
            'save Sale Return
            Dim strCommand As String = "SP_TRANS_SALE_SALERETURN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPSALRETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEBITNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERYAT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEREGNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEINITIALS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWITHGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPLYTCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RACK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHELF", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GDNBARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1

                '' *****CHARGES GRID********
                .Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@ADJGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJAMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJEXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJRETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJBALANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1

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
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SALERETURN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPSALRETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEBITNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERYAT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEREGNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVOICEINITIALS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SRCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWITHGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPLYTCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RACK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHELF", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GDNBARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1

                '' *****CHARGES GRID********
                .Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@ADJGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NARR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJAMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJEXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJRETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ADJBALANCE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SALRETNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTSALRET(ByVal SALRETNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTSALERETURN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SALRETNO", SALRETNO))
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

    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SALERETURN_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SALRETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_SALE_SALERETURN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SALRETNO", alParaval(0)))
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
