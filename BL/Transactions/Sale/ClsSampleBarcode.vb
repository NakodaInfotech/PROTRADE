Imports DB

Public Class ClsSampleBarcode
    Private objDBOperation As DBOperation
    Public ALPARAVAL As New ArrayList
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
            'SAVE SAMPLE BARCODE 
            Dim strCommand As String = "SP_TRANS_SALE_SAMPLEBARCODE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@GRIDSRNO", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", ALPARAVAL(I)))
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
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SAMPLEBARCODE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@GRIDSRNO", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", ALPARAVAL(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SBNO", ALPARAVAL(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SAMPLEBARCODE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@SBNO", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", ALPARAVAL(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region
End Class
