
Imports DB

Public Class ClsSalesTaxRegister

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

    Public Function SALETAX() As DataTable
        Dim dtTable As DataTable
        'Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_SALESTAX_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FROMDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1

            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function getdata() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_SALESTAX"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function getdetails() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_SALESTAX_DETAILS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

#End Region

End Class
