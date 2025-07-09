
Imports DB

Public Class ClsProgramMaster

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

#Region "Function"

    Public Function SAVE() As DataTable
        Try

            Dim strcommand As String = "SP_MASTER_PROGRAMMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CARDRECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CARDISSUEDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@URGENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROGISSDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PRODCUTTING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FINISHCUTTING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWARDDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRNTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESSNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FINISHTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I += 1

            End With

            Dim DTRESULT As DataTable = objDBOperation.execute(strcommand, alParameter).Tables(0)
            Return DTRESULT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            Dim strcommand As String = "SP_MASTER_PROGRAMMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CARDRECDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CARDISSUEDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LBLTOTALPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@URGENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROGISSDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STATUS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PRODCUTTING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FINISHCUTTING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@INWARDDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRNTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECDPCS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESSNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FINISHTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@PROGRAMNO", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As Integer
        Try
            Dim strcommand As String = "SP_MASTER_PROGRAMMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PROGRAMNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(1)))
            End With
            Dim INTRES As Integer = objDBOperation.executeNonQuery(strcommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
