
Imports DB

Public Class ClsDataReco

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

    Public Function INVRECO() As Integer
        Dim intResult As Integer
        Try
            'save NONPURCHASE 
            Dim strCommand As String = "SP_UTILITIES_RECOINVOICE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function PURRECO() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_RECOPURCHASE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function NONPURRECO() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_RECONONPURCHASE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function STOCKRECO() As Integer
        Dim intResult As Integer
        Try
            'save NONPURCHASE 
            Dim strCommand As String = "SP_UTILITIES_RECOSTOCK"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function GRNCHALLANRECO() As Integer
        Dim intResult As Integer
        Try
            'save NONPURCHASE 
            Dim strCommand As String = "SP_UTILITIES_RECOGRNCHALLAN"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function ORDERRECO() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_RECOORDER"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
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
