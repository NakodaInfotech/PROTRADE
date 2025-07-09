
Imports DB

Public Class ClsLoan


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

    Public Function save() As Integer
        Dim intResult As Integer
        Try
            'save purchase REQUEST
            Dim strCommand As String = "SP_TRANS_PURCHASE_LoanMaster_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@date", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Name", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Loan", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@TOTALAmt", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(10)))

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@desc", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@unit", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@Amt", alParaval(16)))


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_LoanMaster_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@date", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Name", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Loan", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@TOTALAmt", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(10)))

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@desc", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@unit", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@Amt", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@LOANNO", alParaval(17)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectLoan() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTLoan_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@LoanNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CmpID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_LoanMaster_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@LoanNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
