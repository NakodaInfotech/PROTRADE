
Imports DB


Public Class ClsPurchaseRequisition

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
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQUEST_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@preqdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@reqby", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@prref", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@type", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@grade", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@item_or_setname", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@sizename", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@length", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@unit", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@pcs", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@griddone", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@gridmake", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@gridname", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@gridmailed", alParaval(25)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function selectrequisition(ByVal preqno As Integer, ByVal cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPREQ_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@preq_no", preqno))
                .Add(New SqlClient.SqlParameter("@Cmpid", cmpid))
                .Add(New SqlClient.SqlParameter("@LocationID", LocationID))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))

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
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQUEST_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@preqdate", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@reqby", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@prref", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))
                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@type", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@grade", alParaval(12)))
                .Add(New SqlClient.SqlParameter("@item_or_setname", alParaval(13)))
                .Add(New SqlClient.SqlParameter("@sizename", alParaval(14)))
                .Add(New SqlClient.SqlParameter("@length", alParaval(15)))
                .Add(New SqlClient.SqlParameter("@unit", alParaval(16)))
                .Add(New SqlClient.SqlParameter("@qty", alParaval(17)))
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(18)))
                .Add(New SqlClient.SqlParameter("@pcs", alParaval(19)))
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(20)))
                .Add(New SqlClient.SqlParameter("@griddone", alParaval(21)))
                .Add(New SqlClient.SqlParameter("@gridmake", alParaval(22)))
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(23)))
                .Add(New SqlClient.SqlParameter("@gridname", alParaval(24)))
                .Add(New SqlClient.SqlParameter("@gridmailed", alParaval(25)))
                .Add(New SqlClient.SqlParameter("@PREQNO", alParaval(26)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQUEST_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@preqno", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearID", alParaval(3)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function updateformail() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQUEST_UPDATE_FOR_MAIL"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PREQNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Manually() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEREQUEST_MANUALLY"
            Dim alParameter As New ArrayList
            With alParameter
                
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(7)))
                

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region

End Class
