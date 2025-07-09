Imports DB
Public Class Clsli

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
            'save purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_LABOURINWARD_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SENDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POUTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@pono", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@podate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transrefno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transremarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POgridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LIDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTDONE", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CHECKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVEDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVEDMTRS", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_LABOURINWARD_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SENDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POUTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@pono", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@podate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transrefno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transremarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POgridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ACCMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LIDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTDONE", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@CHECKSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVEDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LINO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectLABOURINWARD(ByVal LABOURINWARDno As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTLI_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@LIno", LABOURINWARDno))

                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@LocationID", LocationID))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_LABOURINWARD_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@LIno", alParaval(0)))
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
