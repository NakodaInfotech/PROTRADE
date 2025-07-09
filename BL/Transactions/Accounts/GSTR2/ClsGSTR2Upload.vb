
Imports DB

Public Class ClsGSTR2Upload


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
            Dim strCommand As String = "SP_TRANS_GSTR2B2B_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MONTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTRATE", alParaval(I)))
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

    Public Function SAVECNDN() As Integer
        Dim intResult As Integer
        Try
            'save TRIALBALANCE
            Dim strCommand As String = "SP_TRANS_GSTR2CNDN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MONTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTIN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GSTRATE", alParaval(I)))
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

#End Region

End Class
