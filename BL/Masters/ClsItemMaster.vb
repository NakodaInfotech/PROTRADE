
Imports DB

Public Class clsItemmaster

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
            Dim strCommand As String = "SP_MASTER_ITEMMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@material", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@category", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DISPLAYNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@VALUATIONRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSPORTRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHECKINGRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PACKINGRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REORDER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@upper", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@lower", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HIDEINDESIGN", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GREYWIDTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHRINKFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHRINKTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELVEDGE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@RATETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FRMSTRING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARP", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFT", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@GREYQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WTMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REEDSPACE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITYWT", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@WEFTSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTCHANGE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTGRIDNO", alParaval(I)))
                I += 1



                .Add(New SqlClient.SqlParameter("@TOTALBEAMENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALBEAMWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BEAMSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDBEAMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMTL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDBEAMWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALPICKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTTL", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer
        Dim strcommand As String = ""
        Try
            'Update AccountsMaster
            strcommand = "SP_MASTER_ITEMMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@material", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@category", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DISPLAYNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEPARTMENT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@itemcode", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@VALUATIONRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TRANSPORTRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHECKINGRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PACKINGRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DESIGNRATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REORDER", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@upper", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@lower", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BLOCKED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@HIDEINDESIGN", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GREYWIDTH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHRINKFROM", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHRINKTO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SELVEDGE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RATETYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDRATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@YARNQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@FRMSTRING", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WARP", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFT", alParaval(I)))
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


                .Add(New SqlClient.SqlParameter("@GREYQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@ENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WTMTRS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REEDSPACE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QUALITYWT", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@WEFTSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTCHANGE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@SRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDQUALITY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDWT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTGRIDNO", alParaval(I)))
                I += 1


                .Add(New SqlClient.SqlParameter("@TOTALBEAMENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALBEAMWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@BEAMSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDBEAMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMENDS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BEAMTL", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDBEAMWT", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TOTALPICKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@WEFTTL", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@itemid", alParaval(I)))
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
            Dim strCommand As String = "SP_MASTER_ITEMMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SAVESTORE() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_ITEMMASTER_STORES_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@STOREITEMNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

#End Region

End Class
