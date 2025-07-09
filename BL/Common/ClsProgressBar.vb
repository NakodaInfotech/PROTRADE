Imports DB
Imports System.Data

Public Class ClsProgressBar

    Private objDBOperation As DBOperation
    Dim intResult As Integer
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

    Public Function ExecSP() As DataTable
        Dim dt As DataTable

        Try

            Dim strCommand As String = "SP_GETMAXNO"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TBname", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@whereclause", alParaval(2)))
            End With
            dt = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dt
    End Function


#Region "GENERAL"

    Public Function CREATEDEPARTMENT() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEDEPARTMENT"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEUSER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEUSER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEPIECETYPE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEPIECETYPE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEPROCESS() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEPROCESS"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEUNIT() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEUNIT"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEPARAMETER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEPARAMETER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEGODOWN() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEGODOWN"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATESTATE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATESTATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

#Region "Accounts"

    Public Function CREATEGROUP() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEGROUP"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATELEDGER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATELEDGER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEREGISTER() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEREGISTER"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATETAX() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATETAX"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

#Region "Item"

    Public Function CREATEGRADE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEGRADE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATEMATERIALTYPE() As Integer

        Try

            'save group
            Dim strCommand As String = "SP_PROGRESSBAR_CREATEMATERIALTYPE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function CREATERATETYPE() As Integer
        Try
            Dim strCommand As String = "SP_PROGRESSBAR_CREATERATETYPE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region

#End Region

End Class
