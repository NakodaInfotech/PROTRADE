
Imports DB

Public Class ClsSpecialRightsMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

    Public Function save() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_MASTER_SPECIALRIGHTS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@HOME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRNCHECKING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MATREC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INHOUSECHECK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GDN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JOBOUT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JOBIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ISSPACK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECPACK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PURCHASE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SALE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SALEORDER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHOWDASHBOARD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECOUTSTANDING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYOUTSTANDING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PENDINGPO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PENDINGSO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STOCK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MONTHLY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHALLANSO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKDISPUTE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCKPENDING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MERGEPARAMETER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STOCKADJUSTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SAMTRDIFF", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@username", alParaval(I)))
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
