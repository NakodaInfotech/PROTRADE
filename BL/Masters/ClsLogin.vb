Imports db


Public Class clsLogin

    Private objDBOperation As DBOperation


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

    Public Function getdate() As Date

        Dim mdate As Date
        Dim dtTable As DataTable

        Try
            Dim strCommand As String = "SELECT GETDATE()"
            dtTable = objDBOperation.execute(strCommand).Tables(0)
            mdate = dtTable.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return mdate
    End Function

#End Region

End Class


