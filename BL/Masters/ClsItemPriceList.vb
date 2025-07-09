Imports DB
Imports System.Data

Public Class ClsItemPriceList

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
        Dim DTTABLE As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_MASTER_ITEMPRICELISTMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE01", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE02", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE03", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE04", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE05", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE06", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE07", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE08", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE09", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE010", alParaval(I)))
                I = I + 1
                
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

            Return DTTABLE
        Catch ex As Exception
            Throw ex
        End Try

    End Function

  

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_MASTER_ITEMPRICELISTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@CATEGORY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
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
