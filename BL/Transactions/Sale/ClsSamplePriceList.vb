Imports DB

Public Class ClsSamplePriceList
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

        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SAMPLEPRICELIST_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", ALPARAVAL(I)))
                I = I + 1


                'grid parameters
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
                .Add(New SqlClient.SqlParameter("@RATE", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", ALPARAVAL(I)))
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
            Dim strCommand As String = "SP_TRANS_SALE_SAMPLEPRICELIST_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", ALPARAVAL(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MODE", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", ALPARAVAL(I)))
                I = I + 1


                'grid parameters
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
                .Add(New SqlClient.SqlParameter("@RATE", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", ALPARAVAL(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPLNO", ALPARAVAL(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectSMP(ByVal INVNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTSAMPLEPRICELIST_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SPLNO", INVNO))
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
            Dim strCommand As String = "SP_TRANS_SALE_SAMPLEPRICELIST_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SPLNO", ALPARAVAL(0)))
                .Add(New SqlClient.SqlParameter("@YearID", ALPARAVAL(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
