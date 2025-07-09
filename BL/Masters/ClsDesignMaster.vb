Imports DB
Public Class ClsDesignMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

    Public Function SAVE() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_DESIGN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CADNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FABRIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DYEING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBWORK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BASE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PRINT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I += 1

                ''grid parameter
                '.Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                'I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer

        Dim strcommand As String = ""

        Try

            strcommand = "SP_MASTER_DESIGN_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CADNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PURRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SALERATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FABRIC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DYEING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOBWORK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXTRA", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
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

                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BASE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PRINT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I += 1


                ''grid parameter
                '.Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@DESIGNID", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As DataTable

        Try
            Dim strCommand As String = "SP_MASTER_DESIGN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DESIGNID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearID", alParaval(3)))
            End With
            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function selectdesign(ByVal designno As String, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTDESIGN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DESIGNno", designno))
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
#End Region

End Class
