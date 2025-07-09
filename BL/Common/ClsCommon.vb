
Imports DB
Imports System.Data

Public Class ClsCommon

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

    Public Function GETMAXNO(ByVal fld1 As String, ByVal tablename As String, Optional ByVal whereclause As String = "") As DataTable
        Dim dtTable As DataTable
        'Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_GETMAXNO"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@TBname", tablename))
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function mergeparameter() As Integer
        'ByRef modulename As String, ByVal srno As Integer, ByVal cmpid As Integer, ByVal Locationid As Integer, ByVal yearid As Integer
        Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_UTILITIES_MERGEPARAMETER"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@OLDNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@NEWNAME", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(5)))

            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function Execute_Any_String(ByVal fld1 As String, ByVal fld2 As String, ByVal fld3 As String) As DataTable
        Dim dtTable As DataTable
        'Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_ANY_STRING_EXECUTE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@fld1", fld1))
                .Add(New SqlClient.SqlParameter("@fld2", fld2))
                .Add(New SqlClient.SqlParameter("@fld3", fld3))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Dim DT As New DataTable
            DT.Columns.Add("NO")
            DT.Rows.Add(0)
            Return DT
        End Try
        Return dtTable
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
                .Add(New SqlClient.SqlParameter("@whereclause", whereclause))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable

    End Function


    Public Function changeNAme() As Integer
        'ByRef modulename As String, ByVal srno As Integer, ByVal cmpid As Integer, ByVal Locationid As Integer, ByVal yearid As Integer
        Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_CHANGE_CUSTOMER"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@OLD", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@NEW", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@WO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(5)))

            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function save_gridset() As Integer
        Dim intResult As Integer
        Try
            'save Grid set temporary in temptable_gridset table
            Dim strCommand As String = "SP_GRIDSET_SAVE_TEMPTABLE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@tablename", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@formsrno", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@setid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@GRADENAME", alParaval(6)))

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(9)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(10)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(11)))
                .Add(New SqlClient.SqlParameter("@itemid", alParaval(12)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function deletesingle_gridset() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_DELETESINGLE_GRIDSET_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TABLENAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(6)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function deletetemp_gridset() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_DELETETEMP_GRIDSET_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                '.Add(New SqlClient.SqlParameter("@gridlineno", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(3)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function fill_temp_gridset_editmode() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_FILL_TEMP_GRIDSET_EDIT_MODE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TABLENAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@fld2", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function

    Public Function fill_temp_gridset_FORPQ() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_FILL_TEMP_GRIDSET_FOR_PQ"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TABLENAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@fld2", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function

    Public Function UPDATE_TEMPGRIDSET() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TEMPGRIDSET_LINEITEM_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@OLDNO", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@NEWNO", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(5)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function

    Public Function DELETE_TEMPGRIDSET_LINEITEM() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TEMPGRIDSET_LINEITEM_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@gridlineno", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@temptableid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(4)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DELETE() As Integer
        'ByRef modulename As String, ByVal srno As Integer, ByVal cmpid As Integer, ByVal Locationid As Integer, ByVal yearid As Integer
        Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_DELETE_TRANSACTION"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@modulename", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@srno", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@regname", alParaval(5)))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function DELETEMASTER() As Integer
        'ByRef modulename As String, ByVal srno As Integer, ByVal cmpid As Integer, ByVal Locationid As Integer, ByVal yearid As Integer
        Dim INTRESULT As Integer
        Try

            Dim strCommand As String = "SP_DELETE_MASTER"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@modulename", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@srno", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
            End With
            INTRESULT = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function checkSetUseOrNot(ByRef setname As String, ByVal cmpid As Integer, ByVal Loc As Integer, ByVal yid As Integer) As DataTable
        Dim dtTable As DataTable
        Dim strCommand As String = "Check_SetMasterUse_or_Not"
        Dim alParameter As New ArrayList
        With alParameter
            .Add(New SqlClient.SqlParameter("@setname", setname))
            .Add(New SqlClient.SqlParameter("@cmpid", cmpid))
            .Add(New SqlClient.SqlParameter("@Locationid", Loc))
            .Add(New SqlClient.SqlParameter("@Yearid", yid))
        End With
        dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
        Return dtTable

    End Function

    Public Function getfirstdate(ByVal ddate As Date) As Date
        Dim dtTable As New DataTable
        Dim dtdate As Date
        Try
            Dim strCommand As String = "SELECT CONVERT(date,DATEADD(dd,-(DAY('" & ddate & "' )-1),'" & ddate & "'),101) AS Date_Value"
            dtTable = objDBOperation.execute(strCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        dtdate = Convert.ToDateTime(dtTable.Rows(0).Item(0))
        Return dtdate

        'DECLARE @mydate DATETIME
        'SELECT @mydate = getdate()
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)-1),@mydate),101) AS Date_Value,
        '        'First Day of Current Month' AS Date_Type

    End Function

    Public Function getlastdate(ByVal ddate As Date) As Date
        Dim dtTable As New DataTable
        Dim dtdate As Date
        Try
            Dim strCommand As String = "SELECT CONVERT(date,DATEADD(dd,-(DAY(DATEADD(mm,1,'" & ddate & "'))),DATEADD(mm,1,'" & ddate & "')),101)"
            dtTable = objDBOperation.execute(strCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
        dtdate = dtTable.Rows(0).Item(0)
        Return dtdate

        'DECLARE @mydate DATETIME
        'SELECT @mydate = getdate()
        'SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@mydate))),DATEADD(mm,1,@mydate)),101) ,
        'Last Day of Current Month'

    End Function


#End Region

End Class
