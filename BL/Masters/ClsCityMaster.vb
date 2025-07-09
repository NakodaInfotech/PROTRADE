Imports DB
Imports System.Data

Public Class ClsCityMaster

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

    Public Function save() As Integer

        Dim intResult As Integer
        'Dim cityid, stateid, countryid As Integer

        'Dim objTrans As SqlClient.SqlTransaction
        'objTrans = objDBOperation.StartNewTransaction
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@city_name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_remark", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@city_transfer", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function search(ByVal fld1 As String, Optional ByVal fld2 As String = "", Optional ByVal tablename As String = "", Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_MASTER_GET_ANYID"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@ptable_name", tablename))
                .Add(New SqlClient.SqlParameter("@fld2", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UpdateCity() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_CITYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@city_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@city_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@city_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@city_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@city_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@city_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@city_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@cityid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateArea() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_AREAMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@area_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@area_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@area_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@area_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@area_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@area_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@area_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@areaid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateState() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_STATEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@state_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@state_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@state_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@state_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@state_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@state_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@state_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@stateid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UpdateCountry() As Integer

        Dim intResult As Integer
        Try

            Dim strCommand As String = "SP_MASTER_COUNTRYMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@Country_name", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Country_remark", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Country_cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Country_locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Country_userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Country_yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@Country_transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@Countryid", alParaval(7)))
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
