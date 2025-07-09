Imports DB
Public Class ClsStockGridReport
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

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


    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_REPORTS_STOCKGRIDREPORTS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PENDINGPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PENDINGMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PACKINGMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DYEINGMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
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

    Public Sub DELETE(ByVal CMPID As Integer)
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_REPORTS_STOCKGRIDREPORTS_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))

            End With
            objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
End Class
