Imports DB

Public Class ClsProvisionalBS

        Private objDBOperation As DBOperation
        Public alParaval As New ArrayList
        Dim rackid As Integer
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

#Region "Function"

    Public Function SAVE() As Integer
            Dim intResult As Integer
            Try
            Dim strcommand As String = "SP_MASTER_PROVISIONAL_SAVE"
            Dim alParameter As New ArrayList
                With alParameter

                    Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@APRIL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MAY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JUNE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JULY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AUGUST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SEPTEMBER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OCTOBER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NOVEMBER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DECEMBER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JANUARY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FABRUARY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MARCH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
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


#End Region

End Class








