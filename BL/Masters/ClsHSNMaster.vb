Imports DB

Public Class ClsHSNMaster

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
            Dim strCommand As String = "SP_MASTER_HSNMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMDESC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPCGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPSGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPIGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@WEFDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDCGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDIGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDCGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDIGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDEXPORTCGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDEXPORTSGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDEXPORTIGST", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer
        Dim strcommand As String = ""
        Try
            'Update AccountsMaster
            strcommand = "SP_MASTER_HSNMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMDESC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPCGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPSGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXPIGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@WEFDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDCGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDIGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDCGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDIGST1", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDEXPORTCGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDEXPORTSGST", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDEXPORTIGST", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strcommand As String = "SP_MASTER_HSNMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)
            Return intResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GETHSN() As DataTable
        Try

            'save CategoryMaster
            Dim strcommand As String = "SP_MASTER_HSNMASTER_SELECT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
            End With

            Dim DT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DT

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class
