
Imports System.ComponentModel
Imports System.IO
Imports BL

Public Class SampleBarcode

    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean

    Sub getsrno()
        Try
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                ROW("SRNO") = I + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBMERCHANT.Text.Trim = "" Then
            EP.SetError(CMBMERCHANT, " Please Fill Item Name ")
            bln = False
        End If

        'CHECK WHETHER SAME ITEMNAME WITH SAME DESIGN AND SHADE IS ENTERED OR NOT
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" SB_NO AS NO, COLORMASTER.COLOR_name AS SHADE, DESIGNMASTER.DESIGN_NO AS DESIGN ", "", " SAMPLEBARCODE INNER JOIN ITEMMASTER ON SB_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON SB_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON SB_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON SB_QUALITYID = QUALITYMASTER.QUALITY_ID ", " AND ITEMMASTER.item_name = '" & CMBMERCHANT.Text.Trim & "' AND ISNULL(QUALITYMASTER.QUALITY_NAME,'') = '" & CMBQUALITY.Text.Trim & "' AND isnull(COLORMASTER.COLOR_name,'') = '" & CMBCOLOR.Text.Trim & "' AND isnull(DESIGNMASTER.DESIGN_NO,'') = '" & CMBDESIGNNO.Text.Trim & "' AND SB_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                EP.SetError(TXTREMARKS, "ITEM ALREADY PRESENT")
                bln = False
            End If
        End If

        Return bln
    End Function

    Sub EDITROW()
        Try
            If gridbill.GetFocusedRowCellValue("NO") > 0 Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = Val(gridbill.GetFocusedRowCellValue("NO"))
                txtsrno.Text = Val(gridbill.GetFocusedRowCellValue("SRNO"))
                CMBMERCHANT.Text = gridbill.GetFocusedRowCellValue("ITEMNAME")
                CMBQUALITY.Text = gridbill.GetFocusedRowCellValue("QUALITY")
                CMBDESIGNNO.Text = gridbill.GetFocusedRowCellValue("DESIGNNO")
                CMBCOLOR.Text = gridbill.GetFocusedRowCellValue("SHADE")
                TXTREMARKS.Text = gridbill.GetFocusedRowCellValue("REMARKS")
                TXTBARCODE.Text = gridbill.GetFocusedRowCellValue("BARCODE")
                CMBMERCHANT.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING IN ('MERCHANT')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then
                itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' ", "MERCHANT")

                'THIS CODE IS FOR SAVING ALL ITEMS AND DESIGNS ONCE IN THE SAMPLE ENTRY
                'Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search("DISTINCT ITEMNAME ", "", " BARCODESTOCK ", " AND YEARID =" & YearId & " ORDER BY ITEMNAME")
                'For Each DTROW As DataRow In DT.Rows
                '    Dim DTDESIGN As DataTable = OBJCMN.search(" DISTINCT DESIGNNO ", "", " BARCODESTOCK ", " AND ITEMNAME = '" & DTROW("ITEMNAME") & "' AND YEARID = " & YearId & " ORDER BY DESIGNNO")
                '    For Each DRDESIGN As DataRow In DTDESIGN.Rows
                '        CMBMERCHANT.Text = DTROW("ITEMNAME")
                '        CMBDESIGNNO.Text = DRDESIGN("DESIGNNO")

                '        Dim DTCHECK As DataTable = OBJCMN.search(" SB_BARCODE AS BARCODE ", "", " SAMPLEBARCODE LEFT OUTER JOIN ITEMMASTER ON SB_ITEMID = ITEM_ID LEFT OUTER JOIN DESIGNMASTER ON SB_DESIGNID = DESIGN_ID", " AND ITEMMASTER.ITEM_NAME = '" & CMBMERCHANT.Text.Trim & "' AND DESIGN_NO = '" & CMBDESIGNNO.Text.Trim & "' AND SB_YEARID = " & YearId)
                '        If DTCHECK.Rows.Count = 0 Then Call TXTREMARKS_Validating(sender, e)
                '    Next
                'Next

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me, CMBMERCHANT.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCOLOR.Enter
        Try
            If CMBCOLOR.Text.Trim = "" Then FILLCOLOR(CMBCOLOR, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORVALIDATE(CMBCOLOR, e, Me, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " And ITEMMASTER.ITEM_FRMSTRING IN ('ITEMNAME')")
            fillQUALITY(CMBQUALITY, EDIT)
            FILLDESIGN(CMBDESIGNNO, CMBMERCHANT.Text.Trim)
            FILLCOLOR(CMBCOLOR, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT CAST(0 AS BIT) AS CHK, SAMPLEBARCODE.SB_NO AS NO, SAMPLEBARCODE.SB_GRIDSRNO AS SRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS QUALITYNAME, ISNULL(DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(SAMPLEBARCODE.SB_REMARKS, '') AS REMARKS, SAMPLEBARCODE.SB_BARCODE AS BARCODE FROM SAMPLEBARCODE INNER JOIN ITEMMASTER ON SAMPLEBARCODE.SB_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON SAMPLEBARCODE.SB_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON SAMPLEBARCODE.SB_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON SAMPLEBARCODE.SB_QUALITYID = QUALITYMASTER.QUALITY_ID  WHERE SAMPLEBARCODE.SB_YEARID = " & YearId & " ORDER BY SAMPLEBARCODE.SB_NO", "", "")
            gridbilldetails.DataSource = DT
            getsrno()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SampleBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.F5 Then
                gridbilldetails.Focus()
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTNO.Clear()
            txtsrno.Clear()
            CMBMERCHANT.Text = ""
            CMBQUALITY.Text = ""
            CMBDESIGNNO.Text = ""
            CMBCOLOR.Text = ""
            TXTREMARKS.Clear()
            TXTFROM.Clear()
            TXTTO.Clear()
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SampleBarcode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillcmb()
            CLEAR()

            FILLGRID()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub SAVE()
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJSM As New ClsSampleBarcode

            ALPARAVAL.Add(Val(txtsrno.Text.Trim))
            ALPARAVAL.Add(CMBMERCHANT.Text.Trim)
            ALPARAVAL.Add(CMBQUALITY.Text.Trim)
            ALPARAVAL.Add(CMBDESIGNNO.Text.Trim)
            ALPARAVAL.Add(CMBCOLOR.Text.Trim)
            ALPARAVAL.Add(TXTREMARKS.Text.Trim)
            ALPARAVAL.Add(TXTBARCODE.Text.Trim)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)

            OBJSM.ALPARAVAL = ALPARAVAL
            If GRIDDOUBLECLICK = False Then

                Dim DT As DataTable = OBJSM.SAVE()
                If DT.Rows.Count > 0 Then TXTNO.Text = Val(DT.Rows(0).Item(0))
                BARCODE()
            Else
                ALPARAVAL.Add(Val(TXTNO.Text.Trim))
                Dim INTRES As Integer = OBJSM.UPDATE()
                GRIDDOUBLECLICK = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BARCODE()
        Try
            'GET BARCODE NO FROM DATABASE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" SB_BARCODE AS BARCODE ", "", " SAMPLEBARCODE ", " AND SB_NO = " & TXTNO.Text.Trim & " AND SB_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTBARCODE.Text = DT.Rows(0).Item("BARCODE")
            'PRINTBARCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try
            If ALLOWBARCODEPRINT = True Then


                Dim TEMPMSG As Integer = MsgBox("Wish to Print Bar Code?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub


                Dim TEMPHEADER As String = ""
                If ClientName = "GELATO" Then
                    TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR MRP" & Chr(13) & "3 FOR WSP")
                    If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" Then Exit Sub
                End If


                If ClientName = "KDFAB" Then
                    If MsgBox("Print Sticker With Rate?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then TEMPHEADER = "1"
                End If


                If CHKPRINT.CheckState = CheckState.Checked Then
                    Dim dirresults As String = ""

                    'Writing in file
                    Dim oWrite As System.IO.StreamWriter
                    oWrite = File.CreateText("D:\Barcode.txt")

                    For J As Integer = 1 To Val(TXTCOPIES.Text.Trim)

                        If ClientName = "REAL" Then

                            oWrite.WriteLine("SIZE 39.5 mm, 38 mm")
                            oWrite.WriteLine("GAP 3 mm, 0 mm")
                            oWrite.WriteLine("DIRECTION 0,0")
                            oWrite.WriteLine("REFERENCE 0,0")
                            oWrite.WriteLine("OFFSET 0 mm")
                            oWrite.WriteLine("SET PEEL OFF")
                            oWrite.WriteLine("SET CUTTER OFF")
                            oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                            oWrite.WriteLine("SET TEAR ON")
                            oWrite.WriteLine("CLS")
                            oWrite.WriteLine("CODEPAGE 1252")
                            oWrite.WriteLine("TEXT 305,281,""ROMAN.TTF"",180,1,10,""" & CMBMERCHANT.Text.Trim & """")
                            oWrite.WriteLine("TEXT 305,200,""ROMAN.TTF"",180,1,10,""DSN""")
                            oWrite.WriteLine("TEXT 246,200,""ROMAN.TTF"",180,1,10,""" & CMBDESIGNNO.Text.Trim & """")
                            oWrite.WriteLine("TEXT 305,159,""ROMAN.TTF"",180,1,9,""WIDTH""")

                            'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
                            Dim TEMPWIDTH As String = ""
                            Dim OBJCMN As New ClsCommon
                            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & CMBMERCHANT.Text.Trim & "' AND ITEM_YEARID = " & YearId)
                            If DT.Rows.Count > 0 Then
                                TEMPWIDTH = DT.Rows(0).Item("WIDTH")
                            End If

                            oWrite.WriteLine("TEXT 227,159,""ROMAN.TTF"",180,1,9,""" & TEMPWIDTH & """")
                            oWrite.WriteLine("TEXT 305,70,""ROMAN.TTF"",180,1,8,""" & TXTREMARKS.Text.Trim & """")  'REMARKS
                            oWrite.WriteLine("BARCODE 305,124,""128M"",42,0,180,1,2,""" & TXTBARCODE.Text.Trim & """") 'BARCODE
                            oWrite.WriteLine("TEXT 304,37,""ROMAN.TTF"",180,1,8,""" & Format(Now.Date, "dd.MM.yyyy") & """") 'PRINTDATE
                            oWrite.WriteLine("TEXT 254,200,""ROMAN.TTF"",180,1,10,"":""")
                            oWrite.WriteLine("TEXT 214,240,""ROMAN.TTF"",180,1,10,""" & CMBCOLOR.Text.Trim & """")
                            oWrite.WriteLine("TEXT 305,240,""ROMAN.TTF"",180,1,10,""SHADE""")
                            oWrite.WriteLine("TEXT 221,240,""ROMAN.TTF"",180,1,10,"":""")
                            oWrite.WriteLine("TEXT 234,161,""ROMAN.TTF"",180,1,10,"":""")
                            oWrite.WriteLine("PRINT 1,1")
                            oWrite.Dispose()

                        End If

                        'Printing Barcode
                        Dim psi As New ProcessStartInfo()
                        psi.FileName = "cmd.exe"
                        psi.RedirectStandardInput = False
                        psi.RedirectStandardOutput = True
                        'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
                        psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                        psi.UseShellExecute = False

                        Dim proc As Process
                        proc = Process.Start(psi)
                        dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                        '// do something with result stream
                        proc.WaitForExit()
                        proc.Dispose()

                    Next

                Else
                    If (Val(TXTTO.Text.Trim) > 0 And Val(TXTFROM.Text.Trim) > 0) Or CHKPRINTSELECTED.CheckState = CheckState.Checked Then
                        If CHKPRINTSELECTED.Checked = False Then
                            If (Val(TXTTO.Text.Trim) < Val(TXTFROM.Text.Trim)) Or (Val(TXTFROM.Text.Trim) > gridbill.RowCount) Or (Val(TXTTO.Text.Trim) > gridbill.RowCount) Then
                                MsgBox("Invalid No Entered", MsgBoxStyle.Critical)
                                TXTFROM.Focus()
                                Exit Sub
                            End If
                        End If



                        If CHKPRINTSELECTED.Checked = True Then
                            TXTFROM.Text = 1
                            TXTTO.Text = gridbill.RowCount
                        End If

                        For i As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)

                            For J As Integer = 1 To Val(TXTCOPIES.Text.Trim)


                                Dim ROW As DataRow = gridbill.GetDataRow(i - 1)

                                If CHKPRINTSELECTED.CheckState = CheckState.Checked And Convert.ToBoolean(ROW("CHK")) = False Then GoTo NEXTLINE


                                Dim dirresults As String = ""
                                'Writing in file
                                Dim oWrite As System.IO.StreamWriter
                                oWrite = File.CreateText("D:\Barcode.txt")

                                If ClientName = "REAL" Then

                                    oWrite.WriteLine("SIZE 39.5 mm, 38 mm")
                                    oWrite.WriteLine("GAP 3 mm, 0 mm")
                                    oWrite.WriteLine("DIRECTION 0,0")
                                    oWrite.WriteLine("REFERENCE 0,0")
                                    oWrite.WriteLine("OFFSET 0 mm")
                                    oWrite.WriteLine("SET PEEL OFF")
                                    oWrite.WriteLine("SET CUTTER OFF")
                                    oWrite.WriteLine("SET PARTIAL_CUTTER OFF")
                                    oWrite.WriteLine("SET TEAR ON")
                                    oWrite.WriteLine("CLS")
                                    oWrite.WriteLine("CODEPAGE 1252")



                                    oWrite.WriteLine("TEXT 308,281,""ROMAN.TTF"",180,1,10,""" & ROW("ITEMNAME") & """")
                                    oWrite.WriteLine("TEXT 306,200,""ROMAN.TTF"",180,1,10,""DSN""")
                                    oWrite.WriteLine("TEXT 246,200,""ROMAN.TTF"",180,1,10,""" & ROW("DESIGNNO") & """")
                                    oWrite.WriteLine("TEXT 306,159,""ROMAN.TTF"",180,1,9,""WIDTH""")

                                    'GET REMARKS FROM CATEGORYMASTER LEFT OUTER JOIN FROM ITEMMASTER
                                    Dim TEMPWIDTH As String = ""
                                    Dim OBJCMN As New ClsCommon
                                    Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_WIDTH, '') AS WIDTH, ISNULL(ITEMMASTER.ITEM_REMARKS, '') AS REMARKS, ISNULL(CATEGORYMASTER.CATEGORY_NAME, '') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id ", " AND ITEM_NAME = '" & ROW("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                                    If DT.Rows.Count > 0 Then
                                        TEMPWIDTH = DT.Rows(0).Item("WIDTH")
                                    End If

                                    oWrite.WriteLine("TEXT 227,159,""ROMAN.TTF"",180,1,9,""" & TEMPWIDTH & """")
                                    oWrite.WriteLine("TEXT 308,70,""ROMAN.TTF"",180,1,8,""" & ROW("REMARKS") & """")  'REMARKS
                                    oWrite.WriteLine("BARCODE 305,124,""128M"",42,0,180,1,2,""" & ROW("BARCODE") & """") 'BARCODE
                                    oWrite.WriteLine("TEXT 304,37,""ROMAN.TTF"",180,1,8,""" & Format(Now.Date, "dd.MM.yyyy") & """") 'PRINTDATE
                                    oWrite.WriteLine("TEXT 254,200,""ROMAN.TTF"",180,1,10,"":""")
                                    oWrite.WriteLine("TEXT 214,240,""ROMAN.TTF"",180,1,10,""" & ROW("SHADE") & """")
                                    oWrite.WriteLine("TEXT 306,240,""ROMAN.TTF"",180,1,10,""SHADE""")
                                    oWrite.WriteLine("TEXT 221,240,""ROMAN.TTF"",180,1,10,"":""")
                                    oWrite.WriteLine("TEXT 234,161,""ROMAN.TTF"",180,1,10,"":""")
                                    oWrite.WriteLine("PRINT 1,1")
                                    oWrite.Dispose()

                                End If


                                'Printing Barcode
                                Dim psi As New ProcessStartInfo()
                                psi.FileName = "cmd.exe"
                                psi.RedirectStandardInput = False
                                psi.RedirectStandardOutput = True
                                'psi.Arguments = "/c print " & Application.StartupPath & "\Barcode.txt"    ' specify your command
                                psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                                psi.UseShellExecute = False

                                Dim proc As Process
                                proc = Process.Start(psi)
                                dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                                '// do something with result stream
                                proc.WaitForExit()

NEXTLINE:
                            Next
                        Next

                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        EDITROW()
    End Sub

    Private Sub CMBDESIGNNO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBDESIGNNO.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJDESIGN As New SelectDesign
                OBJDESIGN.FRMSTRING = "DESIGN"
                OBJDESIGN.ShowDialog()
                If OBJDESIGN.TEMPNAME <> "" Then CMBDESIGNNO.Text = OBJDESIGN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbITEMNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBMERCHANT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "ITEMNAME"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBMERCHANT.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBCOLOR.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCOLOR As New SelectShade
                OBJCOLOR.FRMSTRING = "COLOR"
                OBJCOLOR.ShowDialog()
                If OBJCOLOR.TEMPNAME <> "" Then CMBCOLOR.Text = OBJCOLOR.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREMARKS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTREMARKS.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then
                EP.Clear()
                If Not errorvalid() Then
                    Exit Sub
                End If
                SAVE()
                FILLGRID()
                If ClientName = "KDFAB" Then
                    CMBDESIGNNO.Focus()
                    CMBCOLOR.Text = ""
                    CMBDESIGNNO.Text = ""
                    TXTREMARKS.Clear()
                Else
                    CMBMERCHANT.Focus()
                End If
            Else
                MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTO.KeyPress, TXTFROM.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTTO_Validating(sender As Object, e As CancelEventArgs) Handles TXTTO.Validating
        PRINTBARCODE()
    End Sub

    Private Sub SampleBarcode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "KARAN" Then
                GREMARKS.Caption = "Rate"
                TXTREMARKS.TextAlign = HorizontalAlignment.Right
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREMARKS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTREMARKS.KeyPress
        Try
            If ClientName = "KARAN" Then numdotkeypress(sender, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbilldetails.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                Dim ROW As DataRow = gridbill.GetFocusedDataRow()

                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DELETE FROM SAMPLEBARCODE
                Dim OBJSM As New ClsSampleBarcode
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(ROW("NO"))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJSM.ALPARAVAL = ALPARAVAL
                Dim INTRES As Integer = OBJSM.DELETE()

                FILLGRID()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim ROW As DataRow = gridbill.GetDataRow(I)
                ROW("CHK") = CHKSELECTALL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try
            PRINTBARCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Enter(sender As Object, e As EventArgs) Handles CMBDESIGNNO.Enter
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, CMBMERCHANT.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class