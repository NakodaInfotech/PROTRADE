Imports DB
Public Class ClsProcessOut
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
            Dim strCommand As String = "SP_TRANS_MFG_PROCESSOUT_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PROTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROTOTALMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROGRAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIRECTOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDLRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@LINO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LISRNO", alParaval(I)))
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

                'grid parameters
                .Add(New SqlClient.SqlParameter("@PROSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROMERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROJOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROGRIDLRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROPOSRNO", alParaval(I)))
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
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_MFG_PROCESSOUT_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PROTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROTOTALMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROGRAM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLAN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIRECTOUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDLRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@LINO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LISRNO", alParaval(I)))
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

                'grid parameters
                .Add(New SqlClient.SqlParameter("@PROSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROMERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROJOBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROGRIDLRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCUT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROSAREE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROOUTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROPOSRNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectPROCESSOUT(ByVal PO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPROCESSOUT_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@POno", PO))
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
            Dim strCommand As String = "SP_TRANS_MFG_PROCESSOUT_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(0)))

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
