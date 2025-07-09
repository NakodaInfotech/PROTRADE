Imports DB


Public Class ClsDeliveryOrder

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
        Dim DTTABLE As DataTable
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_DELIVERYORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURGODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBBERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LIFTINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHGS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I = I + 1

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


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDLIFTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTRANSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGRNSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPLIERNAME", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_DELIVERYORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURGODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBBERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LIFTINGDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHGS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I = I + 1

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


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDLIFTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTRANSPORT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDGRNSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTBAGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTCONES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPLIERNAME", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@DONO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SAVEUPLOAD() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_TRANS_PURCHASE_DELIVERYORDER_SAVEUPLOAD"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DONO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectDO() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTDO_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_DELIVERYORDER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
