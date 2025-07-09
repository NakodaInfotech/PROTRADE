
Imports System.IO
Imports BL

Public Class CatalogMaster

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

    Private Sub CMDPHOTOUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub CMDPHOTOREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOREMOVE.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPHOTOVIEW.Click
        Try
            If TXTPHOTOIMGPATH.Text.Trim <> "" Then
                If Path.GetExtension(TXTPHOTOIMGPATH.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(TXTPHOTOIMGPATH.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBPHOTO.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
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
        Dim DT As DataTable = OBJCMN.search(" CATALOG_NO AS NO, COLORMASTER.COLOR_name AS SHADE, DESIGNMASTER.DESIGN_NO AS DESIGN ", "", " CATALOGMASTER INNER JOIN ITEMMASTER ON CATALOG_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON CATALOG_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON CATALOG_COLORID = COLORMASTER.COLOR_id ", " AND ITEMMASTER.item_name = '" & CMBMERCHANT.Text.Trim & "' AND isnull(COLORMASTER.COLOR_name,'') = '" & CMBCOLOR.Text.Trim & "' AND isnull(DESIGNMASTER.DESIGN_NO,'') = '" & CMBDESIGNNO.Text.Trim & "' AND CATALOG_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                EP.SetError(CMBCOLOR, "ITEM ALREADY PRESENT")
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
                CMBDESIGNNO.Text = gridbill.GetFocusedRowCellValue("DESIGNNO")
                CMBCOLOR.Text = gridbill.GetFocusedRowCellValue("SHADE")
                TXTPHOTOIMGPATH.Text = gridbill.GetFocusedRowCellValue("IMGPATH")
                PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(gridbill.GetFocusedRowCellValue("PHOTO"), Byte())))
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
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' ", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGNNO.GotFocus
        Try
            If CMBDESIGNNO.Text.Trim = "" Then FILLDESIGN(CMBDESIGNNO, CMBMERCHANT.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGNNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGNNO.Validating
        Try
            If CMBDESIGNNO.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGNNO, e, Me)
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
            FILLDESIGN(CMBDESIGNNO, CMBMERCHANT.Text.Trim)
            FILLCOLOR(CMBCOLOR, CMBDESIGNNO.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT CAST(0 AS BIT) AS CHK, CATALOGMASTER.CATALOG_NO AS NO, CATALOGMASTER.CATALOG_GRIDSRNO AS SRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS SHADE, ISNULL(CATALOGMASTER.CATALOG_IMGPATH, '') AS IMGPATH, CATALOGMASTER.CATALOG_PHOTO AS PHOTO FROM CATALOGMASTER INNER JOIN ITEMMASTER ON CATALOGMASTER.CATALOG_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON CATALOGMASTER.CATALOG_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON CATALOGMASTER.CATALOG_DESIGNID = DESIGNMASTER.DESIGN_id WHERE CATALOGMASTER.CATALOG_YEARID = " & YearId & " ORDER BY ITEMMASTER.ITEM_NAME, DESIGNMASTER.DESIGN_NO", "", "")
            gridbilldetails.DataSource = DT
            getsrno()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CATALOGMASTER_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            txtsrno.Text = gridbill.RowCount + 1
            CMBMERCHANT.Text = ""
            CMBDESIGNNO.Text = ""
            CMBCOLOR.Text = ""
            TXTPHOTOIMGPATH.Clear()
            PBPHOTO.Image = Nothing
            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CATALOGMASTER_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillcmb()
            FILLGRID()
            CLEAR()
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
            Dim OBJSM As New ClsCatalogMaster

            ALPARAVAL.Add(Val(txtsrno.Text.Trim))
            ALPARAVAL.Add(CMBMERCHANT.Text.Trim)
            ALPARAVAL.Add(CMBDESIGNNO.Text.Trim)
            ALPARAVAL.Add(CMBCOLOR.Text.Trim)
            ALPARAVAL.Add(TXTPHOTOIMGPATH.Text.Trim)


            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                ALPARAVAL.Add(MS.ToArray)
            Else
                ALPARAVAL.Add(DBNull.Value)
            End If

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJSM.ALPARAVAL = ALPARAVAL
            If GRIDDOUBLECLICK = False Then
                Dim DT As DataTable = OBJSM.SAVE()
                If DT.Rows.Count > 0 Then TXTNO.Text = Val(DT.Rows(0).Item(0))
            Else
                ALPARAVAL.Add(Val(TXTNO.Text.Trim))
                Dim INTRES As Integer = OBJSM.UPDATE()
                GRIDDOUBLECLICK = False
            End If

            CMBMERCHANT.Text = ""
            CMBDESIGNNO.Text = ""
            CMBCOLOR.Text = ""
            TXTPHOTOIMGPATH.Clear()
            PBPHOTO.Image = Nothing
            txtsrno.Text = gridbill.RowCount + 1

            CMBMERCHANT.Focus()
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
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
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

                'DELETE FROM CATALOGMASTER
                Dim OBJSM As New ClsCATALOGMASTER
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

    Private Sub CMDADD_Click(sender As Object, e As EventArgs) Handles CMDADD.Click
        Try
            If CMBMERCHANT.Text.Trim <> "" And TXTPHOTOIMGPATH.Text.Trim <> "" Then
                EP.Clear()
                If Not errorvalid() Then
                    Exit Sub
                End If
                SAVE()
                FILLGRID()
                CMBMERCHANT.Focus()
            Else
                MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class