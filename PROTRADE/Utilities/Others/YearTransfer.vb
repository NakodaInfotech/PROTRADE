
Imports BL

Public Class YearTransfer

    Dim INTRES As Integer
    Dim OBJTRF As New ClsYearTransfer
    Public FRMSTRING As String = ""

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'transfering data from selected cmp
            If GRIDYEAR.SelectedRows.Count = 0 Then
                MsgBox("Select Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim SELECTEDYEARID As Integer = 0
            Dim TEMPMSG As Integer = MsgBox("Transfer Data from Selected Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you sure, wish to Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    SELECTEDYEARID = GRIDYEAR.CurrentRow.Cells(GYEARID.Index).Value

                    If FRMSTRING = "YEARTRANSFER" Then

                        '********* TRANSFERRING DATA ***********
                        TRANSFERUSER(SELECTEDYEARID)

                        TRANSFERGROUP(SELECTEDYEARID)
                        TRANSFERLOCATION(SELECTEDYEARID)
                        TRANSFERMATERIALTYPE(SELECTEDYEARID)
                        TRANSFERCATEGORY(SELECTEDYEARID)
                        TRANSFERPROCESS(SELECTEDYEARID)
                        TRANSFERUNIT(SELECTEDYEARID)
                        TRANSFERSTOREITEM(SELECTEDYEARID)
                        TRANSFERCONTRACT(SELECTEDYEARID)
                        TRANSFERCURRENCY(SELECTEDYEARID)
                        TRANSFERMACHINE(SELECTEDYEARID)
                        TRANSFERSALESMAN(SELECTEDYEARID)
                        TRANSFERRACKSHELF(SELECTEDYEARID)


                        TRANSFERHSN(SELECTEDYEARID)
                        TRANSFERYARNQUALITY(SELECTEDYEARID)
                        TRANSFERMILL(SELECTEDYEARID)
                        TRANSFERBEAM(SELECTEDYEARID)
                        TRANSFERITEM(SELECTEDYEARID)
                        TRANSFERLOOM(SELECTEDYEARID)
                        TRANSFERCOLOR(SELECTEDYEARID)

                        TRANSFERDESIGN(SELECTEDYEARID)
                        TRANSFERDEPARTMENT(SELECTEDYEARID)
                        TRANSFERPIECETYPE(SELECTEDYEARID)
                        TRANSFERPACKING(SELECTEDYEARID)
                        TRANSFERCHALLANTYPE(SELECTEDYEARID)
                        TRANSFERTERM(SELECTEDYEARID)
                        TRANSFERQUALITY(SELECTEDYEARID)

                        TRANSFERREORDER(SELECTEDYEARID)
                        TRANSFERREASON(SELECTEDYEARID)
                        TRANSFERNARRATION(SELECTEDYEARID)
                        TRANSFERPARTYBANK(SELECTEDYEARID)
                        TRANSFERGODOWN(SELECTEDYEARID)
                        TRANSFERGOC(SELECTEDYEARID)
                        TRANSFERREGISTER(SELECTEDYEARID)
                        TRANSFERTRANSPORT(SELECTEDYEARID)
                        TRANSFERAGENTS(SELECTEDYEARID)

                        TRANSFERACCOUNTS(SELECTEDYEARID)

                        'KEEP THIS PRICES LIST AFTER ALL OTHER TRANSFERS, COZ WE NEED LEDGERS / ITEM / DESIGN / COLOR / QUALITY / CATEGORY AND MANY OTHER MASTERS
                        TRANSFERITEMPRICELIST(SELECTEDYEARID)
                        TRANSFERCOLORTAGGING(SELECTEDYEARID)
                        TRANSFERPROGRAM(SELECTEDYEARID)
                        TRANSFERSAMPLEBARCODE(SELECTEDYEARID)


                        TRANSFERBILLS(SELECTEDYEARID)

                        TRANSFERBALANCE(SELECTEDYEARID)
                        TRANSFERPROFITLOSS(SELECTEDYEARID)

                        TRANSFERSALEORDER(SELECTEDYEARID)
                        TRANSFERPURORDER(SELECTEDYEARID)
                        TRANSFERYARNPURORDER(SELECTEDYEARID)


                        'TRANSFER CLOSING STOCK AS OPENINGSTOCK IN NEXT YEAR
                        Dim OBJCMN As New ClsCommon
                        Dim FROMLEDGERID, TOLEDGERID As Integer
                        Dim OPENINGVALUE As Decimal
                        'CHECK WHETHER DATA IS THERE FOR THIS YEAR OR NOT IF PRESENT THEN UPDATE ELSE INSERT
                        Dim DT As DataTable = OBJCMN.search("OPENINGSTOCK", "", "OPENINGCLOSINGSTOCK", " AND YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then DT = OBJCMN.Execute_Any_String("UPDATE OPENINGCLOSINGSTOCK SET OPENINGSTOCK = (SELECT CLOSINGSTOCK FROM OPENINGCLOSINGSTOCK WHERE YEARID = " & SELECTEDYEARID & ") WHERE YEARID = " & YearId, "", "") Else DT = OBJCMN.Execute_Any_String(" INSERT INTO OPENINGCLOSINGSTOCK VALUES ((SELECT ISNULL(CLOSINGSTOCK,0) AS CLOSINGSTOCK FROM OPENINGCLOSINGSTOCK WHERE YEARID = " & SELECTEDYEARID & "),0," & CmpId & "," & YearId & ")", "", "")

                        'ALSO UPDATE IN OPENINGSTOCK ACCOUNSTMASTER
                        'BUT DO ADD ACC POSTING OR THIS
                        DT = OBJCMN.Execute_Any_String("UPDATE ACCOUNTSMASTER SET ACC_DRCR = 'Dr.', ACC_OPBAL = (SELECT CLOSINGSTOCK FROM OPENINGCLOSINGSTOCK WHERE YEARID = " & SELECTEDYEARID & ") WHERE ACC_CMPNAME = 'OPENING STOCK' AND ACC_YEARID = " & YearId, "", "")


                        'POSTNG IN ACCMASTER
                        'OPENING STOCK DEBIT AND OPENING A/C CREDIT
                        DT = OBJCMN.search("ISNULL(ACC_ID,0) AS FROMLEDGERID ", "", "LEDGERS", " AND ACC_CMPNAME = 'Opening A/C' AND ACC_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then FROMLEDGERID = DT.Rows(0).Item(0)



                        DT = OBJCMN.search("ISNULL(ACC_ID,0) AS FROMLEDGERID ", "", "LEDGERS", " AND ACC_CMPNAME = 'Opening Stock' AND ACC_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then TOLEDGERID = DT.Rows(0).Item(0)


                        DT = OBJCMN.Execute_Any_String(" DELETE FROM ACCMASTER WHERE ACC_TYPE = 'OPENING' AND ACC_FROMID = " & FROMLEDGERID & " AND ACC_TOID = " & TOLEDGERID & " AND ACC_YEARID = " & YearId, "", "")
                        DT = OBJCMN.search("ISNULL(OPENINGSTOCK,0) AS OPENINGSTOCK", "", "OPENINGCLOSINGSTOCK", " AND YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            OPENINGVALUE = DT.Rows(0).Item("OPENINGSTOCK")
                            DT = OBJCMN.Execute_Any_String(" INSERT INTO ACCMASTER VALUES (" & Val(FROMLEDGERID) & "," & Val(OPENINGVALUE) & "," & TOLEDGERID & ",0,'" & Format(AccFrom.Date, "MM/dd/yyyy") & "','OPENING','','','', '" & Format(AccTo.Date, "MM/dd/yyyy") & "', '" & Format(AccTo.Date, "MM/dd/yyyy") & "','',0,'','',''," & CmpId & ",0," & Userid & "," & YearId & ",0,GETDATE())", "", "")
                        End If


                        '******* TRANSFERRING DATA DONE ********


                        'IF WE TRANSFER DATA WE HAVE TO RECOSORDER ALSO
                        'THIS CODE WILL AUTO RECO THE SALE/PURCHASEORDER
                        Dim CLSRECO As New ClsDataReco
                        CLSRECO.alParaval.Add(CmpId)
                        CLSRECO.alParaval.Add(0)
                        CLSRECO.alParaval.Add(YearId)
                        Dim INTRES As Integer = CLSRECO.ORDERRECO()
                        '*********************************************


                        MsgBox("Transfer Completed Successfully")

                    ElseIf FRMSTRING = "USERTRANSFER" Then
                        TRANSFERUSER(SELECTEDYEARID)
                        MsgBox("User Transferred Successfully")

                    ElseIf FRMSTRING = "STOCKTRANSFER" Then
                        TRANSFERSTOCK(SELECTEDYEARID)


                        'IF WE TRANSFER STOCK WE HAVE TO RECOSTOCK ALSO
                        'THIS CODE WILL AUTO RECO THE STOCK
                        Dim CLSRECO As New ClsDataReco
                        CLSRECO.alParaval.Add(CmpId)
                        CLSRECO.alParaval.Add(0)
                        CLSRECO.alParaval.Add(YearId)
                        Dim INTRES As Integer = CLSRECO.STOCKRECO()
                        '*********************************************

                        MsgBox("Stock Transferred Successfully")

                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FRMSTRING = "USERTRANSFER" Then
                Me.Text = "Transfer Users"
                LBLUSER.Visible = True
                CMBUSER.Visible = True
                fillUSER(CMBUSER, "")
            ElseIf FRMSTRING = "STOCKTRANSFER" Then
                Me.Text = "Stock Transfer"
            End If
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CONVERT(char(11), year_startdate , 6) + ' - ' + CONVERT(char(11), year_enddate , 6) AS YEARNAME, YEAR_ID AS YEARID   ", "", " YEARMASTER", " AND YEAR_STARTDATE <'" & AccFrom.Date & "' AND YEAR_ID <> " & YearId & " AND YEAR_CMPID = " & CmpId & " ORDER BY YEAR_ID DESC ")
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDYEAR.Rows.Add(DTROW("YEARNAME"), DTROW("YEARID"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERUSER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(CMBUSER.Text.Trim)
            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERUSER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLOCATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLOCATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGROUP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGROUP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERTRANSPORT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERTRANSPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERREGISTER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERREGISTER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERAGENTS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERAGENTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERACCOUNTS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERACCOUNTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERITEMPRICELIST(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERITEMPRICELIST()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOLORTAGGING(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOLORTAGGING()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROGRAM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROGRAM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSAMPLEBARCODE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFESAMPLEBARCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDESIGN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDESIGN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERUNIT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERUNIT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSTOREITEM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSTOREITEM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCONTRACT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCONTRACT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCURRENCY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCURRENCY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERMACHINE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERMACHINE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSALESMAN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSALESMAN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERRACKSHELF(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERRACKSHELF()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOLOR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOLOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERMATERIALTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERMATERIALTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERITEM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERITEM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLOOM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLOOM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCATEGORY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCATEGORY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERREORDER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERREORDER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERREASON(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERREASON()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERNARRATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERNARRATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPARTYBANK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPARTYBANK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGOC(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGOC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub TRANSFERGODOWN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGODOWN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDEPARTMENT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDEPARTMENT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPIECETYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPIECETYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub TRANSFERRATETYPE(ByVal SELECTEDYEARID As Integer)
    '    Try
    '        Dim ALPARAVAL As New ArrayList

    '        ALPARAVAL.Add(SELECTEDYEARID)
    '        ALPARAVAL.Add(CmpId)
    '        ALPARAVAL.Add(Locationid)
    '        ALPARAVAL.Add(Userid)
    '        ALPARAVAL.Add(YearId)

    '        OBJTRF.alParaval = ALPARAVAL
    '        INTRES = OBJTRF.TRANSFERRATETYPE()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub TRANSFERPACKING(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPACKING()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROCESS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROCESS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCHALLANTYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCHALLANTYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub TRANSFERITEMPRICELIST(ByVal SELECTEDYEARID As Integer)
    '    Try
    '        Dim ALPARAVAL As New ArrayList

    '        ALPARAVAL.Add(SELECTEDYEARID)
    '        ALPARAVAL.Add(CmpId)
    '        ALPARAVAL.Add(Locationid)
    '        ALPARAVAL.Add(Userid)
    '        ALPARAVAL.Add(YearId)

    '        OBJTRF.alParaval = ALPARAVAL
    '        INTRES = OBJTRF.TRANSFERITEMPRICELIST()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub TRANSFERTERM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERTERM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERQUALITY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERQUALITY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(ClientName)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub TRANSFEREMPLOYEES(ByVal SELECTEDYEARID As Integer)
    '    Try
    '        Dim ALPARAVAL As New ArrayList

    '        ALPARAVAL.Add(SELECTEDYEARID)
    '        ALPARAVAL.Add(CmpId)
    '        ALPARAVAL.Add(Locationid)
    '        ALPARAVAL.Add(Userid)
    '        ALPARAVAL.Add(YearId)

    '        OBJTRF.alParaval = ALPARAVAL
    '        INTRES = OBJTRF.TRANSFEREMPLOYEES()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub TRANSFERHSN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHSN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERYARNQUALITY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERYARN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERMILL(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERMILL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBEAM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBEAM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBILLS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBILLS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBALANCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROFITLOSS(ByVal SELECTEDYEARID As Integer)
        Try


            Dim ALPARAVAL As New ArrayList
            Dim OBJPL As New ClsProfitLoss

            Dim OBJCMN As New ClsCommon
            Dim DTF As DataTable = OBJCMN.search(" YEAR_STARTDATE AS FROMDATE, YEAR_ENDDATE AS TODATE", "", " YEARMASTER ", " AND YEAR_ID = " & SELECTEDYEARID)
            ALPARAVAL.Add(Format(DTF.Rows(0).Item("FROMDATE"), "MM/dd/yyyy"))
            ALPARAVAL.Add(Format(DTF.Rows(0).Item("TODATE"), "MM/dd/yyyy"))

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(SELECTEDYEARID)

            OBJPL.alParaval = ALPARAVAL
            Dim DT = OBJPL.GETLEDGER()


            'CODE BY GULKIT
            'GET OPSTOCK
            Dim OPSTOCK, CLOSTOCK As Double
            Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS, TOTALNETTPROFIT, TOTALNETTLOSS As Double
            OPSTOCK = 0
            CLOSTOCK = 0
            Dim OPSTOCKDT As DataTable = OBJCMN.search(" ISNULL(OPENINGSTOCK,0) AS OPENINGSTOCK, ISNULL(CLOSINGSTOCK,0) AS CLOSINGSTOCK", "", " OPENINGCLOSINGSTOCK ", " AND YEARID = " & SELECTEDYEARID)
            If OPSTOCKDT.Rows.Count > 0 Then
                OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("OPENINGSTOCK"))
                CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("CLOSINGSTOCK"))
            End If


            TOTALDREXP += OPSTOCK

            Dim i As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDREXP += Val(DTROW("CLOBALDR"))
                        TOTALCREXP += Val(DTROW("CLOBALCR"))
                    End If
                End If
                '*****************************************************************
                '*****************************************************************

                If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDRINC += Val(DTROW("CLOBALDR"))
                        TOTALCRINC += Val(DTROW("CLOBALCR"))
                    End If
                End If
            Next
            TOTALCRINC += CLOSTOCK

            If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
            Else
                TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
            End If
            ''**************************************************************************************



            TOTALDREXP = 0
            TOTALCREXP = 0
            TOTALDRINC = 0
            TOTALCRINC = 0


            'FORMATTING GRID
            For Each DTROW As DataRow In DT.Rows
                If DTROW("PRIMARYGP") = "Indirect Expenses" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDREXP += Val(DTROW("CLOBALDR"))
                        TOTALCREXP += Val(DTROW("CLOBALCR"))
                    End If
                End If
                '*****************************************************************
                '*****************************************************************

                If DTROW("PRIMARYGP") = "Indirect Income" Then
                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                        TOTALDRINC += Val(DTROW("CLOBALDR"))
                        TOTALCRINC += Val(DTROW("CLOBALCR"))
                    End If
                End If
            Next

            If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
                TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
            Else
                TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
            End If
            ''***************************************************************************************
            ALPARAVAL.Clear()


            'IF WE HAVE ENTERED JOURNAL ENTRY IN CURRENT YEAR THEN FETCH THAT VALUE AND ADD IN BELOW ENTRY
            Dim PLTBDR As Double = 0
            Dim PLTBCR As Double = 0
            Dim DTPLTB As DataTable = OBJCMN.search("(CASE WHEN (SUM(DR) - SUM(CR)) > 0 THEN (SUM(DR) - SUM(CR)) ELSE 0 END) AS DR, (CASE WHEN (SUM(CR) - SUM(DR)) > 0 THEN (SUM(CR) - SUM(DR)) ELSE 0 END) AS CR", "", "TRIALBALANCE", " AND PRIMARYGROUP = 'Profit & Loss' AND YEARID = " & SELECTEDYEARID)
            If DTPLTB.Rows.Count > 0 Then
                PLTBDR = Val(DTPLTB.Rows(0).Item("DR"))
                PLTBCR = Val(DTPLTB.Rows(0).Item("CR"))
            End If


            'IF PROFITLOSS LEDGER IS DEBIT THEN DEDUCT FROM TOTALNETTPROFIT OR ELSE DEDUCT FROM TOTALNETTLOSS
            If PLTBDR > 0 Then TOTALNETTPROFIT = Format(Val(TOTALNETTPROFIT) - Val(PLTBDR), "0.00")
            If PLTBCR > 0 Then TOTALNETTLOSS = Format(Val(TOTALNETTLOSS) - Val(PLTBCR), "0.00")


            If TOTALNETTPROFIT > 0 Then ALPARAVAL.Add(Val(TOTALNETTPROFIT)) Else ALPARAVAL.Add(Val(TOTALNETTLOSS))


            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROFITLOSS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSALEORDER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSALEORDER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPURORDER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPURORDER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERYARNPURORDER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERYARNPURORDER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class