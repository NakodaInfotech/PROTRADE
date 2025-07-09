Imports DB

Public Class ClsPurchaseMaster

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
            Dim I As Integer = 0
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@PURNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SACCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFFNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DYEINGNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALROUNDOFF", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FOOTERDISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOOTERDISCAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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

                '.Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                'I = I + 1

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
                .Add(New SqlClient.SqlParameter("@MANUALTCS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
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
                   .Add(New SqlClient.SqlParameter("@CHADTI", alParaval(I)))
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

                ' ''CHECKEDLISTBOX
                .Add(New SqlClient.SqlParameter("@FORMTYPE", alParaval(I)))
                I = I + 1


                'grid parameters********************************
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1



                'POGRID
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERDESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1


            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DTTABLE

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update Enquiry
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PURNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SACCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFFNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOOFBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DYEINGNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALROUNDOFF", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FOOTERDISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOOTERDISCAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                '.Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                'I = I + 1

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
                .Add(New SqlClient.SqlParameter("@MANUALTCS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CHADTI", alParaval(I)))
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

                ' ''CHECKEDLISTBOX
                .Add(New SqlClient.SqlParameter("@FORMTYPE", alParaval(I)))
                I = I + 1


                'grid parameters********************************
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRINTDESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(I)))
                I = I + 1


                'POGRID
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERDESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectpurchase() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPURCHASE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
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

            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function

    Public Function COPY() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_COPY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CPINVOICE_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function SAVEUPLOAD() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_TRANS_PURCHASE_PURCHASEMASTER_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
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

    Public Function PACKINGSLIPDATA() As DataTable
        Dim dtTable As DataTable

        Try

            Dim strCommand As String = "SP_GETDATA_PACKINGSLIP"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GDNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@ACCFROM", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPNAME", alParaval(2)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
