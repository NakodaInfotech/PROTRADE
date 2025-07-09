
Imports DB

Public Class ClsSalaryMaster

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

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save PAYMENT MASTER
            Dim strCommand As String = "SP_TRANS_SALARYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SALDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MONTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WORKDAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYDAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALDED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALEAR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NETTPAY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@DEDGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@EARGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARNINGS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function selectbill_edit() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_SALARY_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SALNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function update() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_SALARYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SALDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MONTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WORKDAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYDAYS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LEAVE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALDED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALEAR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NETTPAY", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@DEDGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@EARGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARNINGS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SALNO", alParaval(I)))
                I += 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_SALARYMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SALNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
