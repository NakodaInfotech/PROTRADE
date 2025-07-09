
Imports DB

Public Class ClsDesignReplacement

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
    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update Design AND COLOR
            Dim strCommand As String = "SP_UTILITIES_DESIGNREPLACEMENT"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDDESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWDESIGN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OLDCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWCOLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function
#End Region
End Class
