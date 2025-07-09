
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class ItemDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub ItemDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
            showform(False, "")
        End If
    End Sub

    Private Sub ItemDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "MERCHANT" Then
                Me.Text = "Merchant Details"
                TabControl1.TabPages(0).Text = "Merchant Details"
                lbl.Text = "Double Click on Merchant to Edit"
                txtmaterial.Visible = False
                LBLMATERIAL.Visible = False
                txtmaterial.Text = "Finished Goods"
            End If

            fillgriditem()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgriditem(Optional ByVal WHERE As String = "")

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search(" Item_Name AS NAME , Item_code AS CODE, ISNULL(ITEMMASTER.ITEM_DISPLAYNAME, '') AS DISPLAYNAME, ISNULL(ITEM_BLOCKED,0) AS BLOCKED, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY", "", " ItemMaster LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.ITEM_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " AND ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_yearid = " & YearId & WHERE & " order by item_name")
        GRIDNAME.DataSource = dttable
    End Sub

    Sub getdetails(ByRef name As String)

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search("  ITEMMASTER.ITEM_ID AS ITEMID, MATERIALTYPEMASTER.material_name AS MATERIALTYPE, ISNULL(CATEGORYMASTER.category_name,'') AS CATEGORY, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE, ISNULL(UNITMASTER.unit_abbr,'') AS UNIT, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name,'') AS DEPARTMENT, ITEMMASTER.item_reorder AS REORDER, ITEMMASTER.ITEM_FOLD AS FOLD, ITEMMASTER.ITEM_RATE AS RATE,ITEMMASTER.ITEM_TRANSRATE AS TRANSPORTRATE, ITEMMASTER.ITEM_CHECKRATE AS CHECKINGRATE, ITEMMASTER.ITEM_PACKRATE AS PACKINGRATE, ITEMMASTER.ITEM_DESIGNRATE AS DESIGNRATE, ITEMMASTER.item_upper AS UPPER, ITEMMASTER.item_lower AS LOWER, ISNULL(ITEM_WIDTH,'') AS WIDTH, ISNULL(ITEM_SHRINKFROM,0) AS SHRINKFROM, ISNULL(ITEM_SHRINKTO,0) AS SHRINKTO, ISNULL(ITEM_SELVEDGE,'') AS SELVEDGE, ISNULL(ITEMMASTER.item_remarks,'') AS REMARKS, '' AS RATETYPE, 0 AS RATE, ISNULL(ITEMMASTER.ITEM_DISPLAYNAME, '') AS DISPLAYNAME,ISNULL(ITEMMASTER.ITEM_WARP, '') AS WARP,ISNULL(ITEMMASTER.ITEM_WEFT, '') AS WEFT, ISNULL(HSNMASTER.HSN_CODE,'') AS HSNCODE", "", " DEPARTMENTMASTER RIGHT OUTER JOIN ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_cmpid = MATERIALTYPEMASTER.material_cmpid AND ITEMMASTER.item_locationid = MATERIALTYPEMASTER.material_locationid AND ITEMMASTER.item_yearid = MATERIALTYPEMASTER.material_yearid AND ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_yearid = UNITMASTER.unit_yearid AND ITEMMASTER.item_locationid = UNITMASTER.unit_locationid AND ITEMMASTER.item_cmpid = UNITMASTER.unit_cmpid AND ITEMMASTER.item_unitid = UNITMASTER.unit_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id AND ITEMMASTER.item_cmpid = CATEGORYMASTER.category_cmpid AND ITEMMASTER.item_locationid = CATEGORYMASTER.category_locationid AND ITEMMASTER.item_yearid = CATEGORYMASTER.category_yearid ON DEPARTMENTMASTER.DEPARTMENT_yearid = ITEMMASTER.item_yearid AND DEPARTMENTMASTER.DEPARTMENT_locationid = ITEMMASTER.item_locationid AND DEPARTMENTMASTER.DEPARTMENT_cmpid = ITEMMASTER.item_cmpid AND DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN HSNMASTER ON ITEM_HSNCODEID = HSN_ID", " and ITEMMASTER.Item_Name = '" & name & "' and ITEMMASTER.Item_yearid = " & YearId)
        cleartextbox()
        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows

                txtmaterial.Text = ROW("MATERIALTYPE").ToString
                txtcategory.Text = ROW("CATEGORY").ToString

                txtitemname.Text = ROW("ITEMNAME").ToString
                TXTDISPLAYNAME.Text = ROW("DISPLAYNAME").ToString
                txtcode.Text = ROW("ITEMCODE").ToString
                txtunit.Text = ROW("UNIT").ToString
                TXTDEPARTMENT.Text = ROW("DEPARTMENT").ToString
                TXTHSNCODE.Text = ROW("HSNCODE").ToString
                txtreorder.Text = Val(ROW("REORDER").ToString)
                TXTFOLD.Text = Val(ROW("FOLD").ToString)
                TXTRATE.Text = Val(ROW("RATE").ToString)
                TXTTRANSPORTRATE.Text = Val(ROW("TRANSPORTRATE").ToString)
                TXTCHECKINGRATE.Text = Val(ROW("CHECKINGRATE").ToString)
                TXTPACKINGRATE.Text = Val(ROW("PACKINGRATE").ToString)
                TXTDESIGNRATE.Text = Val(ROW("DESIGNRATE").ToString)
                txtupper.Text = Val(ROW("UPPER").ToString)
                txtlower.Text = Val(ROW("LOWER").ToString)

                TXTWIDTH.Text = ROW("WIDTH").ToString
                TXTSHRINKFROM.Text = Val(ROW("SHRINKFROM"))
                TXTSHRINKTO.Text = Val(ROW("SHRINKTO"))
                TXTSELVEDGE.Text = ROW("SELVEDGE").ToString
                txtremarks.Text = ROW("REMARKS").ToString
                TXTWARP.Text = ROW("WARP").ToString
                TXTWEFT.Text = ROW("WEFT").ToString
            Next


            'GET RATE FROM ITEMPRICELIST
            Dim DTRATE As DataTable = objClsCommon.search("  RATE1, RATE2, RATE3, RATE4, RATE5, RATE6, RATE7, RATE8, RATE9, RATE10 ", "", " ITEMPRICELIST ", " AND ITEMID = " & dttable.Rows(0).Item("ITEMID") & " AND YEARID = " & YearId)
            If DTRATE.Rows.Count > 0 Then
                TXTRATE1.Text = Val(DTRATE.Rows(0).Item("RATE1"))
                TXTRATE2.Text = Val(DTRATE.Rows(0).Item("RATE2"))
                TXTRATE3.Text = Val(DTRATE.Rows(0).Item("RATE3"))
                TXTRATE4.Text = Val(DTRATE.Rows(0).Item("RATE4"))
                TXTRATE5.Text = Val(DTRATE.Rows(0).Item("RATE5"))
                TXTRATE6.Text = Val(DTRATE.Rows(0).Item("RATE6"))
                TXTRATE7.Text = Val(DTRATE.Rows(0).Item("RATE7"))
                TXTRATE8.Text = Val(DTRATE.Rows(0).Item("RATE8"))
                TXTRATE9.Text = Val(DTRATE.Rows(0).Item("RATE9"))
                TXTRATE10.Text = Val(DTRATE.Rows(0).Item("RATE10"))
            End If
        End If

    End Sub

    Sub cleartextbox()
        txtmaterial.Clear()
        txtcategory.Clear()
        TXTDEPARTMENT.Clear()
        txtitemname.Clear()
        txtcode.Clear()
        txtunit.Clear()
        txtupper.Clear()
        txtlower.Clear()
        txtreorder.Clear()
        txtremarks.Clear()
        TXTWARP.Clear()
        TXTWEFT.Clear()
        TXTTRANSPORTRATE.Clear()
        TXTDESIGNRATE.Clear()
        TXTPACKINGRATE.Clear()
        TXTCHECKINGRATE.Clear()

        TXTRATE1.Clear()
        TXTRATE2.Clear()
        TXTRATE3.Clear()
        TXTRATE4.Clear()
        TXTRATE5.Clear()
        TXTRATE6.Clear()
        TXTRATE7.Clear()
        TXTRATE8.Clear()
        TXTRATE9.Clear()
        TXTRATE10.Clear()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim objItemmaster As New ItemMaster
                objItemmaster.MdiParent = MDIMain
                objItemmaster.EDIT = editval
                objItemmaster.tempItemName = name
                objItemmaster.frmstring = FRMSTRING
                objItemmaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgriditem()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SANGHVI" Then
            LBLMATERIAL.Text = "Mill No"
            GDISPLAYNAME.Caption = "Mill No"
        End If

        If ClientName = "BARKHA" Or ClientName = "SHUBHI" Then LBLOPSTOCK.Text = "FLD"
        If ClientName = "KOCHAR" Then LBLTO.Text = "GSM"

        If ClientName = "SAFFRON" Or ClientName = "SAFFRONOFF" Then
            LBLCOPIES.Visible = True
            TXTCOPIES.Visible = True
            CMDBARCODE.Visible = True
        End If

    End Sub

    Private Sub CMDBARCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBARCODE.Click
        Try
            If Val(TXTCOPIES.Text.Trim) = 0 Or TXTDISPLAYNAME.Text.Trim = "" Then Exit Sub
            If MsgBox("Print Barcode?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.No Then Exit Sub
            Dim dirresults As String = ""
            For I As Integer = 1 To Val(TXTCOPIES.Text.Trim)
                Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText("D:\Barcode.txt")
                oWrite.WriteLine("I8,A,001")
                oWrite.WriteLine("")
                oWrite.WriteLine("")
                oWrite.WriteLine("Q200,024")
                oWrite.WriteLine("q863")
                oWrite.WriteLine("rN")
                oWrite.WriteLine("S5")
                oWrite.WriteLine("D10")
                oWrite.WriteLine("ZT")
                oWrite.WriteLine("JF")
                oWrite.WriteLine("O")
                oWrite.WriteLine("R231,0")
                oWrite.WriteLine("f100")
                oWrite.WriteLine("N")
                oWrite.WriteLine("A24,180,3,2,2,2,N,""SAFFRON""")
                oWrite.WriteLine("A88,12,0,1,2,2,N,""" & TXTDISPLAYNAME.Text.Trim & """")
                oWrite.WriteLine("A89,111,0,4,1,1,N,""WIDTH""")
                oWrite.WriteLine("A89,62,0,1,2,2,N,""D.NO""")
                oWrite.WriteLine("A201,111,0,4,1,1,N,""" & TXTWIDTH.Text.Trim & """")
                oWrite.WriteLine("A174,110,0,1,2,2,N,"":""")
                oWrite.WriteLine("A173,62,0,1,2,2,N,"":""")
                oWrite.WriteLine("A199,62,0,1,2,2,N,""" & txtitemname.Text.Trim & """")
                oWrite.WriteLine("A87,159,0,3,1,1,N,""" & txtremarks.Text.Trim & """")
                oWrite.WriteLine("P1")
                oWrite.Dispose()



                'Printing Barcode
                Dim psi As New ProcessStartInfo()
                psi.FileName = "cmd.exe"
                psi.RedirectStandardInput = False
                psi.RedirectStandardOutput = True
                psi.Arguments = "/c print D:\Barcode.txt"    ' specify your command
                psi.UseShellExecute = False

                Dim proc As Process
                proc = Process.Start(psi)
                dirresults = proc.StandardOutput.ReadToEnd() ' // read from stdout
                proc.WaitForExit()
                proc.Dispose()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBEXCEL_Click(sender As Object, e As EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJACC As New ItemExcelDetails
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATERATE_Click(sender As Object, e As EventArgs) Handles CMDUPDATERATE.Click
        Try
            If gridledger.GetFocusedRowCellValue("NAME") = "" Then Exit Sub

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" DELETE ITEMPRICELIST FROM ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMMASTER.ITEM_ID = ITEMPRICELIST.ITEMID WHERE ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId, "", "")
            DT = OBJCMN.Execute_Any_String("INSERT INTO ITEMPRICELIST VALUES ((SELECT ISNULL(CATEGORYMASTER.category_id,0) FROM ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = category_id WHERE ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & "), (SELECT ISNULL(ITEMMASTER.ITEM_ID,0) FROM ITEMMASTER WHERE ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & ")," & Val(TXTRATE1.Text.Trim) & "," & Val(TXTRATE2.Text.Trim) & "," & Val(TXTRATE3.Text.Trim) & "," & Val(TXTRATE4.Text.Trim) & "," & Val(TXTRATE5.Text.Trim) & "," & Val(TXTRATE6.Text.Trim) & "," & Val(TXTRATE7.Text.Trim) & "," & Val(TXTRATE8.Text.Trim) & "," & Val(TXTRATE9.Text.Trim) & "," & Val(TXTRATE10.Text.Trim) & "," & CmpId & "," & Userid & "," & YearId & ")", "", "")
            MsgBox("Rates Modified Successfully")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPIES_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

End Class