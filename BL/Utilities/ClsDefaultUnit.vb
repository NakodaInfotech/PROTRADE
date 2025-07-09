
Imports DB

Public Class ClsDefaultUnit

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master

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

    Public Function DEFAULTSTOCKUNIT() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""
        Try
            strcommand = "SP_UTILITIES_DEFAULTSTOCKUNIT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
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
