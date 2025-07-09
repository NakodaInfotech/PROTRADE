Imports DB

Public Class ClsOpeningSaleOrder

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
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@OPSONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPSOdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HASTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANS1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANS2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RISK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSIGNOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSIGNEE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalbales", alParaval(I)))         ''TOTAL BALES INSTED OF TOTAL AMT
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@DISPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TESTCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROINAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROIAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TNC", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@MISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCLOT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KATAI", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADVANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALESMAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FORWARD", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTYUNIT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@RECDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOGRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOGRIDSAMPLEDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1

            End With

            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@OPSONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPSOdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HASTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANS1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANS2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CITY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RISK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSIGNOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONSIGNEE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalbales", alParaval(I)))         ''TOTAL BALES INSTED OF TOTAL AMT
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@DISPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TESTCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROINAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROIAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TNC", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@MISC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCLOT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@KATAI", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADAT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INTS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADVANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALESMAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FORWARD", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTYUNIT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@RECDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOGRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOGRIDSAMPLEDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TEMPOPSONO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectSo(ByVal pono As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTOPSO_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@OPSONO", pono))
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
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_DELETE"
            Dim alParameter As New ArrayList
            Dim I As Integer = 0
            With alParameter
                .Add(New SqlClient.SqlParameter("@OPSONO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(I)))
                I += 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CLOSESO() As Integer
        Dim intResult As Integer
        Try
            'CLOSE SALE order
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_CLOSESO"
            Dim alParameter As New ArrayList
            Dim I As Integer = 0
            With alParameter
                .Add(New SqlClient.SqlParameter("@OPSONO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CLOSE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult


    End Function

#End Region

#Region "PO Deatils"

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
