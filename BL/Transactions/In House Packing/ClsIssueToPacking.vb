
Imports DB

Public Class ClsIssueToPacking

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
            'save SALE order
            Dim strCommand As String = "SP_TRANS_JOB_ISSUEPACKING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SLTP", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@WEAVERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVERCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I))) 'BARCODE ADDED
                I = I + 1


                .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GREYMTRS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
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
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_JOB_ISSUEPACKING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SLTP", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@WEAVERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVERCHNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I))) 'BARCODE ADDED
                I = I + 1


                .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GREYMTRS", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTJO() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTISSUEPACKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(0)))
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
            Dim strCommand As String = "SP_TRANS_JOB_ISSUEPACKING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
