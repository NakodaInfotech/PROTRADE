
Imports DB

Public Class ClsEmployeeMaster

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

    Public Function save() As Integer
        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_MASTER_EMPLOYEEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@EMPNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ENROLLNO", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CONTACTNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@panno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PFNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SALMODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@DEDGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@EARGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARNINGS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim intResult As Integer
        Dim strcommand As String = ""

        Try

            'Update AccountsMaster
            strcommand = "SP_MASTER_EMPLOYEEMASTER_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@EMPNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNATION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ENROLLNO", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@areaname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cityname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@zipcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@statename", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@countryname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@resino", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CONTACTNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@altno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@mobileno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@email", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@panno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PFNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SALMODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ACNO", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@add", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OURLOCATION", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@DEDGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDUCTION", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEDAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@EARGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARNINGS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EARAMT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@EMPID", alParaval(I)))
                I += 1
                
            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Dim DTTABLE As DataTable
        Dim strcommand As String = ""

        Try

            'save CategoryMaster
            strcommand = "SP_MASTER_EMPLOYEEMASTER_DELETE"

            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@EMPNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))

            End With

            DTTABLE = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function GETEMPLOYEE() As DataTable
        Dim dtTable As DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_SELECT_EMPLOYEE"

            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
