
Imports DB

Public Class ClsSelectPO

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

    Public Function Selectpoforamend(Optional ByVal po_no As String = "", Optional ByVal cmpid As Integer = 0, Optional ByVal LocationID As Integer = 0, Optional ByVal yearID As Integer = 0) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPO_FOR_AMENDMENT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PO_NO", po_no))
                .Add(New SqlClient.SqlParameter("@Cmpid", cmpid))
                .Add(New SqlClient.SqlParameter("@LocationID", LocationID))
                .Add(New SqlClient.SqlParameter("@YearID", yearID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable


    End Function

End Class
