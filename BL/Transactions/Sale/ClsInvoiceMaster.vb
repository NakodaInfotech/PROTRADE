
Imports DB

Public Class ClsInvoiceMaster

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
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOTO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INVOICEDATE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@LOCALTRANSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HASTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GATEPASSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GPDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPORTGST", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKBARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSPDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TOTALWITHGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPLYTCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TERMNAME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CIF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPTERMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARKNOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPINSURANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VESSEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOADINGPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCHARGEPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPHSN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SQMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALUSDAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSTINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTOMINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDSUSD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOCKETDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COURIER", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDESC", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPARTYPONO", alParaval(I)))
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


                ''*******UPLOAD GRID *************

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

                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DISPATCHFROM", alParaval(I)))
                I += 1


            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOTO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INVOICEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@LOCALTRANSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HASTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GATEPASSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GPDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPORTGST", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHKBARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSPDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TOTALWITHGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPLYTCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TCSAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TERMNAME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CIF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPTERMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARKNOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPINSURANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VESSEL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOADINGPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCHARGEPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPHSN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SQMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALUSDAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSTINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTOMINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDSUSD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DOCKETNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DOCKETDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COURIER", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDESC", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPARTYPONO", alParaval(I)))
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


                ''*******UPLOAD GRID *************

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

                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@IRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACKDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QRCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DISPATCHFROM", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectINVOICE(ByVal INVNO As Integer, ByVal REGISTERNAME As String, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTINVOICE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@INVOICENO", INVNO))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", REGISTERNAME))
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
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CHKBARCODE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(5)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
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

#End Region


End Class
