
Imports BL

Public Class UploadGSTR2

    Private Sub CMBMONTH_Validated(sender As Object, e As EventArgs) Handles CMBMONTH.Validated
        Try
            If CMBMONTH.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("COUNT(PURCHASEMASTER.BILL_INITIALS) AS BILLS", "", "PURCHASEMASTER INNER JOIN LEDGERS ON LEDGERS.ACC_ID = PURCHASEMASTER.BILL_LEDGERID ", " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND UPPER(datename(M,PURCHASEMASTER.BILL_PARTYBILLDATE)) = '" & CMBMONTH.Text.Trim & "' AND PURCHASEMASTER.BILL_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTPURENTRIES.Text = Val(DT.Rows(0).Item("BILLS"))

                DT = OBJCMN.search("COUNT(NONPURCHASE.NP_INITIALS) AS BILLS", "", "NONPURCHASE INNER JOIN LEDGERS ON LEDGERS.ACC_ID = NONPURCHASE.NP_LEDGERID ", " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> ''  AND UPPER(datename(M,NONPURCHASE.NP_PARTYBILLDATE)) = '" & CMBMONTH.Text.Trim & "' AND NONPURCHASE.NP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTNPENTRIES.Text = Val(DT.Rows(0).Item("BILLS"))


                DT = OBJCMN.search("COUNT(CREDITNOTEMASTER.CN_INITIALS) AS BILLS", "", "CREDITNOTEMASTER INNER JOIN LEDGERS ON LEDGERS.ACC_ID = CREDITNOTEMASTER.CN_LEDGERID ", " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND ISNULL(CREDITNOTEMASTER.CN_NOGSTR1,0) = 'TRUE' AND UPPER(datename(M,CREDITNOTEMASTER.CN_DATE)) = '" & CMBMONTH.Text.Trim & "' AND CREDITNOTEMASTER.CN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTCNENTRIES.Text = Val(DT.Rows(0).Item("BILLS"))

                DT = OBJCMN.search("COUNT(DEBITNOTEMASTER.DN_INITIALS) AS BILLS", "", "DEBITNOTEMASTER INNER JOIN LEDGERS ON LEDGERS.ACC_ID = DEBITNOTEMASTER.DN_LEDGERID ", " AND ISNULL(LEDGERS.ACC_GSTIN,'') <> '' AND ISNULL(DEBITNOTEMASTER.DN_GSTR1,0) = 'FALSE' AND UPPER(datename(M,DEBITNOTEMASTER.DN_DATE)) = '" & CMBMONTH.Text.Trim & "' AND DEBITNOTEMASTER.DN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTDNENTRIES.Text = Val(DT.Rows(0).Item("BILLS"))

                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            TXTTOTALB2BENTRIES.Text = Val(TXTPURENTRIES.Text.Trim) + Val(TXTNPENTRIES.Text.Trim)
            TXTTOTALCNDNENTRIES.Text = Val(TXTCNENTRIES.Text.Trim) + Val(TXTDNENTRIES.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDB2BUPLOAD_Click(sender As Object, e As EventArgs) Handles CMDB2BUPLOAD.Click
        Try
            If Val(TXTB2BSTART.Text.Trim) = 0 Or Val(TXTB2BEND.Text.Trim) = 0 Then
                MsgBox("Enter Proper Row Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If
            OpenFileDialog1.Filter = "Excel (*.xls;*.xlsx;*.csv)|*.xls;*.xlsx;*.csv"
            OpenFileDialog1.ShowDialog()

            OpenFileDialog1.AddExtension = True
            TXTFILENAME.Text = OpenFileDialog1.SafeFileName
            TXTB2BPATH.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCNDNUPLOAD_Click(sender As Object, e As EventArgs) Handles CMDCNDNUPLOAD.Click
        Try
            If Val(TXTCNDNSTART.Text.Trim) = 0 Or Val(TXTCNDNEND.Text.Trim) = 0 Then
                MsgBox("Enter Proper Row Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If

            OpenFileDialog1.Filter = "Excel (*.xls;*.xlsx;*.csv)|*.xls;*.xlsx;*.csv"
            OpenFileDialog1.ShowDialog()

            OpenFileDialog1.AddExtension = True
            TXTFILENAME.Text = OpenFileDialog1.SafeFileName
            TXTCNDNPATH.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOAD_Click(sender As Object, e As EventArgs) Handles CMDUPLOAD.Click
        Try

            If CMBMONTH.Text.Trim = "" Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If TXTB2BPATH.Text.Trim = "" Or Val(TXTB2BSTART.Text.Trim) = 0 Or Val(TXTB2BEND.Text.Trim) = 0 Or TXTB2BSHEETNAME.Text.Trim = "" Then GoTo SKIPB2B

            'UPLOAD B2B
            If Val(TXTB2BSTART.Text.Trim) > Val(TXTB2BEND.Text.Trim) Then
                MsgBox("Enter Proper Row Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'upload the files data
            ''Reading from Excel Woorkbook
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open(TXTB2BPATH.Text.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets(TXTB2BSHEETNAME.Text.Trim)

            'GRID
            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("GSTIN")
            DTSAVE.Columns.Add("NAME")
            DTSAVE.Columns.Add("INVNO")
            DTSAVE.Columns.Add("INVDATE")
            DTSAVE.Columns.Add("GRANDTOTAL")
            DTSAVE.Columns.Add("TAXABLEAMT")
            DTSAVE.Columns.Add("IGSTAMT")
            DTSAVE.Columns.Add("CGSTAMT")
            DTSAVE.Columns.Add("SGSTAMT")
            DTSAVE.Columns.Add("GSTRATE")


            'FIRST DELETE DATA FROM GSTR2B2B WITH SAME MONTH AND YEARID
            DT = OBJCMN.Execute_Any_String("DELETE FROM GSTR2B2B WHERE MONTH = '" & CMBMONTH.Text.Trim & "' AND YEARID = " & YearId, "", "")


            Dim ARR As New ArrayList
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            For I As Integer = Val(TXTB2BSTART.Text.Trim) To Val(TXTB2BEND.Text.Trim)

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTIN") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("GSTIN") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("NAME") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("NAME") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("INVNO") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("INVNO") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("INVDATE") = Format(Convert.ToDateTime(oSheet.Range("E" & I.ToString).Text).Date, "MM/dd/yyyy")
                Else
                    DTROWSAVE("INVDATE") = 0
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("GRANDTOTAL") = Val(oSheet.Range("F" & I.ToString).Text)
                Else
                    DTROWSAVE("GRANDTOTAL") = 0
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTRATE") = Val(oSheet.Range("I" & I.ToString).Text)
                Else
                    DTROWSAVE("GSTRATE") = 0
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("TAXABLEAMT") = Val(oSheet.Range("J" & I.ToString).Text)
                Else
                    DTROWSAVE("TAXABLEAMT") = 0
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("IGSTAMT") = Val(oSheet.Range("K" & I.ToString).Text)
                Else
                    DTROWSAVE("IGSTAMT") = 0
                End If

                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("CGSTAMT") = Val(oSheet.Range("L" & I.ToString).Text)
                Else
                    DTROWSAVE("CGSTAMT") = 0
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("SGSTAMT") = Val(oSheet.Range("M" & I.ToString).Text)
                Else
                    DTROWSAVE("SGSTAMT") = 0
                End If




                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Clear()
                Dim OBJGSTR2 As New ClsGSTR2Upload

                ALPARAVAL.Add(CMBMONTH.Text.Trim)
                ALPARAVAL.Add(DTROWSAVE("GSTIN"))
                ALPARAVAL.Add(DTROWSAVE("NAME"))
                ALPARAVAL.Add(DTROWSAVE("INVNO"))
                ALPARAVAL.Add(DTROWSAVE("INVDATE"))
                ALPARAVAL.Add(Val(DTROWSAVE("GRANDTOTAL")))
                ALPARAVAL.Add(Val(DTROWSAVE("TAXABLEAMT")))
                ALPARAVAL.Add(Val(DTROWSAVE("IGSTAMT")))
                ALPARAVAL.Add(Val(DTROWSAVE("CGSTAMT")))
                ALPARAVAL.Add(Val(DTROWSAVE("SGSTAMT")))
                ALPARAVAL.Add(Val(DTROWSAVE("GSTRATE")))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)


                OBJGSTR2.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJGSTR2.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

            Next

            oBook.Close()

SKIPB2B:


            If TXTCNDNPATH.Text.Trim = "" Or Val(TXTCNDNSTART.Text.Trim) = 0 Or Val(TXTCNDNEND.Text.Trim) = 0 Or TXTCNDNSHEETNAME.Text.Trim = "" Then GoTo UPLOADDONE


            'UPLOAD B2B
            If Val(TXTCNDNSTART.Text.Trim) > Val(TXTCNDNEND.Text.Trim) Then
                MsgBox("Enter Proper Row Nos", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'upload the files data
            ''Reading from Excel Woorkbook
            Dim oExcelCNDN As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBookCNDN As Microsoft.Office.Interop.Excel.Workbook = oExcelCNDN.Workbooks.Open(TXTCNDNPATH.Text.Trim, , False)
            Dim oSheetCNDN As New Microsoft.Office.Interop.Excel.Worksheet
            oSheetCNDN = oBookCNDN.Worksheets(TXTCNDNSHEETNAME.Text.Trim)

            'GRID
            Dim DTSAVECNDN As New System.Data.DataTable
            DTSAVECNDN.Columns.Add("GSTIN")
            DTSAVECNDN.Columns.Add("NAME")
            DTSAVECNDN.Columns.Add("TYPE")
            DTSAVECNDN.Columns.Add("INVNO")
            DTSAVECNDN.Columns.Add("INVDATE")
            DTSAVECNDN.Columns.Add("GRANDTOTAL")
            DTSAVECNDN.Columns.Add("TAXABLEAMT")
            DTSAVECNDN.Columns.Add("IGSTAMT")
            DTSAVECNDN.Columns.Add("CGSTAMT")
            DTSAVECNDN.Columns.Add("SGSTAMT")
            DTSAVECNDN.Columns.Add("GSTRATE")


            'FIRST DELETE DATA FROM GSTR2CNDN WITH SAME MONTH AND YEARID
            DT = OBJCMN.Execute_Any_String("DELETE FROM GSTR2CNDN WHERE MONTH = '" & CMBMONTH.Text.Trim & "' AND YEARID = " & YearId, "", "")


            Dim DTROWSAVECNDN As System.Data.DataRow = DTSAVECNDN.NewRow()

            For I As Integer = Val(TXTCNDNSTART.Text.Trim) To Val(TXTCNDNEND.Text.Trim)

                If IsDBNull(oSheetCNDN.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("GSTIN") = oSheetCNDN.Range("A" & I.ToString).Text
                Else
                    DTROWSAVECNDN("GSTIN") = ""
                End If

                If IsDBNull(oSheetCNDN.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("NAME") = oSheetCNDN.Range("B" & I.ToString).Text
                Else
                    DTROWSAVECNDN("NAME") = ""
                End If

                'IT IS INTERCHANGED IN PORTAL.... NOW TYPE IS D COLUMN
                If IsDBNull(oSheetCNDN.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("TYPE") = oSheetCNDN.Range("D" & I.ToString).Text
                Else
                    DTROWSAVECNDN("TYPE") = ""
                End If

                'IT IS INTERCHANGED IN PORTAL.... NOW INVNO IS C COLUMN
                If IsDBNull(oSheetCNDN.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("INVNO") = oSheetCNDN.Range("C" & I.ToString).Text
                Else
                    DTROWSAVECNDN("INVNO") = ""
                End If

                If IsDBNull(oSheetCNDN.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("INVDATE") = Format(Convert.ToDateTime(oSheetCNDN.Range("F" & I.ToString).Text).Date, "MM/dd/yyyy")
                Else
                    DTROWSAVECNDN("INVDATE") = 0
                End If

                If IsDBNull(oSheetCNDN.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("GRANDTOTAL") = Val(oSheetCNDN.Range("G" & I.ToString).Text)
                Else
                    DTROWSAVECNDN("GRANDTOTAL") = 0
                End If

                If IsDBNull(oSheetCNDN.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("GSTRATE") = Val(oSheetCNDN.Range("J" & I.ToString).Text)
                Else
                    DTROWSAVECNDN("GSTRATE") = 0
                End If

                If IsDBNull(oSheetCNDN.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("TAXABLEAMT") = Val(oSheetCNDN.Range("K" & I.ToString).Text)
                Else
                    DTROWSAVECNDN("TAXABLEAMT") = 0
                End If

                If IsDBNull(oSheetCNDN.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("IGSTAMT") = Val(oSheetCNDN.Range("L" & I.ToString).Text)
                Else
                    DTROWSAVECNDN("IGSTAMT") = 0
                End If

                If IsDBNull(oSheetCNDN.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("CGSTAMT") = Val(oSheetCNDN.Range("M" & I.ToString).Text)
                Else
                    DTROWSAVECNDN("CGSTAMT") = 0
                End If

                If IsDBNull(oSheetCNDN.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVECNDN("SGSTAMT") = Val(oSheetCNDN.Range("N" & I.ToString).Text)
                Else
                    DTROWSAVECNDN("SGSTAMT") = 0
                End If


                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Clear()
                Dim OBJGSTR2 As New ClsGSTR2Upload

                ALPARAVAL.Add(CMBMONTH.Text.Trim)
                ALPARAVAL.Add(DTROWSAVECNDN("GSTIN"))
                ALPARAVAL.Add(DTROWSAVECNDN("NAME"))
                ALPARAVAL.Add(DTROWSAVECNDN("TYPE"))
                ALPARAVAL.Add(DTROWSAVECNDN("INVNO"))
                ALPARAVAL.Add(DTROWSAVECNDN("INVDATE"))

                If DTROWSAVECNDN("TYPE") = "Credit note" Then
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("GRANDTOTAL")) * -1)
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("TAXABLEAMT")) * -1)
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("IGSTAMT")) * -1)
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("CGSTAMT")) * -1)
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("SGSTAMT")) * -1)
                Else
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("GRANDTOTAL")))
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("TAXABLEAMT")))
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("IGSTAMT")))
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("CGSTAMT")))
                    ALPARAVAL.Add(Val(DTROWSAVECNDN("SGSTAMT")))
                End If
                ALPARAVAL.Add(Val(DTROWSAVECNDN("GSTRATE")))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)


                OBJGSTR2.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJGSTR2.SAVECNDN()

                DTROWSAVECNDN = DTSAVECNDN.NewRow()

            Next

            oBookCNDN.Close()

UPLOADDONE:


            If MsgBox("Data Uploaded Successfully, Show Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call CMDREPORT_Click(sender, e)
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREPORT_Click(sender As Object, e As EventArgs) Handles CMDREPORT.Click
        Try
            Dim OBJGSTR2 As New GSTR2MatchGridReport
            OBJGSTR2.MdiParent = MDIMain
            OBJGSTR2.WHERECLAUSE = OBJGSTR2.WHERECLAUSE & " AND UPPER(DATENAME(M,T.INVDATEBOOKS)) = '" & CMBMONTH.Text.Trim & "' "
            OBJGSTR2.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class