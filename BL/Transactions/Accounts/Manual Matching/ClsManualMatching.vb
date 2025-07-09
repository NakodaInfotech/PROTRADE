
Imports DB

Public Class ClsManualMatching

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
            'save PAYMENT MASTER
            Dim strCommand As String = "SP_TRANS_MANUALMATCHING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MATCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREGID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAIDAMT", alParaval(I)))
                I = I + 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function SELECTBILL(ByVal MATCHNO As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MANUALMATCHING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@MATCHNO", MATCHNO))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_MANUALMATCHING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@MATCHDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALPAY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREGID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLINITIALS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDBALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAIDAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@MATCHNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function GETBILLS(ByVal NAME As String, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_MATCHING_GETBILLS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", NAME))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_MANUALMATCHING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@MATCHNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(1)))

            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
