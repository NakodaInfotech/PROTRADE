
Imports DB

Public Class ClsGDN

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
            Dim strCommand As String = "SP_TRANS_SALE_GDN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GDNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSIGNEE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBBER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTISONO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RISK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPATCHTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transrefno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transremarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOLDFORAPPROVAL", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDSONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPARTYPONO", alParaval(I)))
                I = I + 1



                'grid parameters
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
                .Add(New SqlClient.SqlParameter("@ORDERGDNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGDNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPARTYPONO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CHALLANTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPECHALLANNO", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_SALE_GDN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GDNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSIGNEE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBBER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MULTISONO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RISK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOFROM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISPATCHTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transrefno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transremarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpcs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalmtrs", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HOLDFORAPPROVAL", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDLOTNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRIDSONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPARTYPONO", alParaval(I)))
                I = I + 1

                'grid parameters
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
                .Add(New SqlClient.SqlParameter("@ORDERGDNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGDNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPARTYPONO", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@CHALLANTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPECHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GDNNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTGDN(ByVal GDNno As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTGDN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GDNno", GDNno))
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
            Dim strCommand As String = "SP_TRANS_SALE_GDN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GDNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@SOGRIDSRNO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@CLIENTNAME", alParaval(6)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
