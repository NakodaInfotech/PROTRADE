
Imports DB

Public Class ClsCreditNote

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public alP As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save CREDITNOTE
            Dim strCommand As String = "SP_TRANS_CREDITNOTE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TEMPCNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CNdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEBITNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERYAT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INVPRINTINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOGSTR1", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CNRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXID", alParaval(I)))
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

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function selectCREDITNOTE_edit(ByVal CNNO As Integer, ByVal REGISTERNAME As String, ByVal CMPID As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_CREDITNOTE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CNNO", CNNO))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", REGISTERNAME))
                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UPDATE() As Integer
        Try
            'update CREDITNOTE Entry
            Dim strCommand As String = "SP_TRANS_CREDITNOTE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@CREDITNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CNdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DEBITNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERYAT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INVPRINTINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACTUALINVAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SALEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHARGES", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NOGSTR1", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMTREC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CNRETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXID", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CNNO", alParaval(I)))
                I = I + 1

            End With
            Dim INTRES As Integer = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_CREDITNOTE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CNNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARid", alParaval(4)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function SAVEQRCODE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_CREDITNOTE_QRCODE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CNNO", alParaval(I)))
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
