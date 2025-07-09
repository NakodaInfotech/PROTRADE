
Imports DB

Public Class ClsCForm

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

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_CFORMENTRY_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FORMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FORMDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                '7 FIELDS


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



            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function DELETE() As Integer
        Dim INTRES As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_CFORMENTRY_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FORMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
            End With
            INTRES = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function GETSUMMARY() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_SUMMARY"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                '.Add(New SqlClient.SqlParameter("@TYPE", alParaval(6)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETALLBILLS() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_DETAILS_ALLBILLS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(7)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETPENDINGBILLS() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_DETAILS_PENDINGBILLS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(7)))
            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETRECDBILLS() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_DETAILS_RECDBILLS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(7)))

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETALLBILLSSUMMARY() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_SUMMARY_ALLBILLS"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETPENDINGBILLSSUMMARY() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_SUMMARY_PENDINGBILLS"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function GETRECDBILLSSUMMARY() As DataTable
        Dim DT As DataTable
        Try
            'get data from register
            Dim strCommand As String = "SP_REPORTS_ACCOUNTS_CFORM_SUMMARY_RECDBILLS"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FORMNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FROMdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TODATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

#End Region

End Class
