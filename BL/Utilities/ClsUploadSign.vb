Imports DB


Public Class ClsUploadSign
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

    Public Function save() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_UTILITIES_UPLOADSIGN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function selectdesign(ByVal Cmpid As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_UTILITIES_UPLOADSIGN_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region
End Class
