
Imports BL
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class ItemPriceList

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public DT As New DataTable
    Public EDIT As Boolean

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ItemPriceList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Sub CLEAR()
        Try
            cmbcategory.Text = ""
            GRIDBILLDETAILS.DataSource = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Enter
        Try
            If cmbcategory.Text.Trim = "" Then fillCATEGORY(cmbcategory, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMPRICELIST.RATE1, 0) AS RATE1, ISNULL(ITEMPRICELIST.RATE2, 0) AS RATE2, ISNULL(ITEMPRICELIST.RATE3, 0) AS RATE3, ISNULL(ITEMPRICELIST.RATE4, 0) AS RATE4, ISNULL(ITEMPRICELIST.RATE5, 0) AS RATE5, ISNULL(ITEMPRICELIST.RATE6, 0) AS RATE6, ISNULL(ITEMPRICELIST.RATE7, 0) AS RATE7, ISNULL(ITEMPRICELIST.RATE8, 0) AS RATE8, ISNULL(ITEMPRICELIST.RATE9, 0) AS RATE9, ISNULL(ITEMPRICELIST.RATE10, 0) AS RATE10 ", "", "ITEMMASTER LEFT OUTER JOIN ITEMPRICELIST ON ITEMMASTER.item_id = ITEMPRICELIST.ITEMID LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id  ", " AND ISNULL(CATEGORYMASTER.category_name,'') = '" & cmbcategory.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & " ORDER BY ITEMNAME ASC ")
            GRIDBILLDETAILS.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
                GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
            End If

            'CHANGE LABELS OF ALL RATES FROM RATETYPEMASTER
            Dim DTRATE As DataTable = OBJCMN.Execute_Any_String("SELECT COLNAME, RATENAME FROM RATETYPEMASTER WHERE CMPID = " & CmpId, "", "")
            For Each DTROW As DataRow In DTRATE.Rows
                If DTROW("COLNAME") = "RATE01" Then GRATE1.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE02" Then GRATE2.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE03" Then GRATE3.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE04" Then GRATE4.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE05" Then GRATE5.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE06" Then GRATE6.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE07" Then GRATE7.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE08" Then GRATE8.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE09" Then GRATE9.Caption = DTROW("RATENAME")
                If DTROW("COLNAME") = "RATE10" Then GRATE10.Caption = DTROW("RATENAME")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        GRIDBILL.ClearColumnsFilter()

        Dim ALPARAVAL As New ArrayList
        Dim OBJCONFIG As New ClsItemPriceList

        ALPARAVAL.Add(cmbcategory.Text.Trim)

        Dim ITEMNAME As String = ""
        Dim RATE1 As String = ""
        Dim RATE2 As String = ""
        Dim RATE3 As String = ""
        Dim RATE4 As String = ""

        Dim RATE5 As String = ""
        Dim RATE6 As String = ""
        Dim RATE7 As String = ""
        Dim RATE8 As String = ""
        Dim RATE9 As String = ""
        Dim RATE10 As String = ""

        For I As Integer = 0 To GRIDBILL.RowCount - 1
            Dim ROW As DataRow = GRIDBILL.GetDataRow(I)
            If ITEMNAME = "" Then
                ITEMNAME = ROW("ITEMNAME")
                RATE1 = Val(ROW("RATE1"))
                RATE2 = Val(ROW("RATE2"))
                RATE3 = Val(ROW("RATE3"))
                RATE4 = Val(ROW("RATE4"))
                RATE5 = Val(ROW("RATE5"))
                RATE6 = Val(ROW("RATE6"))
                RATE7 = Val(ROW("RATE7"))
                RATE8 = Val(ROW("RATE8"))
                RATE9 = Val(ROW("RATE9"))
                RATE10 = Val(ROW("RATE10"))

            Else
                ITEMNAME = ITEMNAME & "|" & ROW("ITEMNAME")
                RATE1 = RATE1 & "|" & Val(ROW("RATE1"))
                RATE2 = RATE2 & "|" & Val(ROW("RATE2"))
                RATE3 = RATE3 & "|" & Val(ROW("RATE3"))
                RATE4 = RATE4 & "|" & Val(ROW("RATE4"))
                RATE5 = RATE5 & "|" & Val(ROW("RATE5"))
                RATE6 = RATE6 & "|" & Val(ROW("RATE6"))
                RATE7 = RATE7 & "|" & Val(ROW("RATE7"))
                RATE8 = RATE8 & "|" & Val(ROW("RATE8"))
                RATE9 = RATE9 & "|" & Val(ROW("RATE9"))
                RATE10 = RATE10 & "|" & Val(ROW("RATE10"))
            End If
        Next

        ALPARAVAL.Add(ITEMNAME)
        ALPARAVAL.Add(RATE1)
        ALPARAVAL.Add(RATE2)
        ALPARAVAL.Add(RATE3)
        ALPARAVAL.Add(RATE4)
        ALPARAVAL.Add(RATE5)
        ALPARAVAL.Add(RATE6)
        ALPARAVAL.Add(RATE7)
        ALPARAVAL.Add(RATE8)
        ALPARAVAL.Add(RATE9)
        ALPARAVAL.Add(RATE10)


        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Userid)
        ALPARAVAL.Add(YearId)
        OBJCONFIG.alParaval = ALPARAVAL

        Dim DT As DataTable = OBJCONFIG.save()
        MsgBox("Details Added")
        CLEAR()
        cmbcategory.Focus()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim OBJPRINT As New ItemPriceListPrint
            OBJPRINT.WHERECLAUSE = "{CATEGORYMASTER.CATEGORY_NAME} = '" & cmbcategory.Text.Trim & "' AND {ITEMPRICELIST.YEARID} = " & YearId
            OBJPRINT.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(sender As Object, e As EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Price List.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Price List"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Price List", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            MsgBox("Price List Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub FILLCMB()
        Try
            fillCATEGORY(cmbcategory, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemPriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If cmbcategory.Text.Trim = "" Then fillCATEGORY(cmbcategory, EDIT)
    End Sub

    Private Sub TXTRATEPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATEPER.Validating
        Try
            If Val(TXTRATEPER.Text.Trim) <> 0 And CMBRATETYPE.Text.Trim <> "" Then
                For I As Integer = 0 To GRIDBILL.RowCount - 1
                    Dim DTROW As DataRow = GRIDBILL.GetDataRow(I)
                    DTROW(CMBRATETYPE.Text.Trim) = Format(Val(DTROW("RATE1")) + ((Val(DTROW("RATE1")) * Val(TXTRATEPER.Text.Trim)) / 100), "0")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class