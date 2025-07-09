
Imports DB

Public Class ClsPurchaseQuotation

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

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEQUOTATION_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@QUOTDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@PRNO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@PARTYQUOTNO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@PARTYQUOTDATE", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@VALIDDATE", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@imgpath", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(14)))

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@REED", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@rate", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@amount", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@RECDQTY", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@GPRNO", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@prgridsrno", alParaval(29)))


            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEQUOTATION_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@QUOTDATE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@PRNO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@PARTYQUOTNO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@PARTYQUOTDATE", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@VALIDDATE", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@imgpath", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(14)))

                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@REED", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@rate", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@amount", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@RECDQTY", alParaval(26)))
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(27)))
                .Add(New SqlClient.SqlParameter("@GPRNO", alParaval(28)))
                .Add(New SqlClient.SqlParameter("@prgridsrno", alParaval(29)))
                .Add(New SqlClient.SqlParameter("@QUOTNO", alParaval(30)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function selectquotation() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPURCHASEQUOTATION_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@QUOTNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEQUOTATION_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@QUOTNO", alParaval(0)))
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
