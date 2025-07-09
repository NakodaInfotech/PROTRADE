
Imports DB

Public Class ClsShrinkageEntry
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
    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SHRINKAGE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@ENTRYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SKDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@LBLTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALRECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALRECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALBALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALBALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALSMPMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALSHRINKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLAVGSHRINKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SMPMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHRINKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHRINKAGEPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNTYPE", alParaval(I)))
                I = I + 1




            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_SHRINKAGE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@ENTRYNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SKDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@LBLTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALRECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALRECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALBALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALBALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALSMPMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALSHRINKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLAVGSHRINKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SMPMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHRINKAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHRINKAGEPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNTYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPENTRYNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectSHRINKAGE(ByVal TEMPENTRYNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTSHRINKAGE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TEMPENTRYNO", TEMPENTRYNO))

                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))

                .Add(New SqlClient.SqlParameter("@YearID", YearID))

            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_SALE_SHRINKAGE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ENTRYNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(2)))


            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class




