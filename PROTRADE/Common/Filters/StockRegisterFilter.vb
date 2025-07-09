
Imports BL

Public Class StockRegisterFilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            Dim OBJCMN As New ClsCommon
            Dim DTUNIT As DataTable = OBJCMN.search(" CASE WHEN ISNULL(DEFAULTSTOCKUNIT.UNIT_ABBR,'') = '' THEN  CAST (0 AS BIT) ELSE  CAST (1 AS BIT) END AS CHK, UNITMASTER.UNIT_ABBR AS UNIT ", " ", " UNITMASTER LEFT OUTER JOIN DEFAULTSTOCKUNIT ON UNITMASTER.UNIT_ABBR = DEFAULTSTOCKUNIT.UNIT_ABBR ", " AND UNITMASTER.UNIT_YEARID = '" & YearId & "' ORDER BY UNITMASTER.UNIT_ABBR")
            gridbilldetailsunit.DataSource = DTUNIT
            If DTUNIT.Rows.Count > 0 Then
                gridbillunit.FocusedRowHandle = gridbillunit.RowCount - 1
                gridbillunit.TopRowIndex = gridbillunit.RowCount - 15
            End If


            Dim DTITEM As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME ", " ", " ITEMMASTER ", " AND ITEMMASTER.ITEM_YEARID = " & YearId & " ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDITEMDETAILS.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDITEM.FocusedRowHandle = GRIDITEM.RowCount - 1
                GRIDITEM.TopRowIndex = GRIDITEM.RowCount - 15
            End If

            Dim DTDESIGN As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, DESIGNMASTER.DESIGN_NO AS DESIGNNO ", " ", " DESIGNMASTER ", " AND DESIGNMASTER.DESIGN_YEARID = " & YearId & " ORDER BY DESIGNMASTER.DESIGN_NO")
            GRIDDESIGNDETAILS.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                GRIDDESIGN.FocusedRowHandle = GRIDDESIGN.RowCount - 1
                GRIDDESIGN.TopRowIndex = GRIDDESIGN.RowCount - 15
            End If

            Dim DTSHADE As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS SHADE", " ", " COLORMASTER ", " AND COLORMASTER.COLOR_YEARID = " & YearId & " ORDER BY COLORMASTER.COLOR_NAME")
            GRIDSHADEDETAILS.DataSource = DTSHADE
            If DTSHADE.Rows.Count > 0 Then
                GRIDSHADE.FocusedRowHandle = GRIDSHADE.RowCount - 1
                GRIDSHADE.TopRowIndex = GRIDSHADE.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub StockFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            'IF PRINTBARCODE IS TRUE THEN OPENGRID STOCK REPORTS OR ELSE OPEN CRYSTAL REPORTS
            Dim UNITCLAUSE As String = ""
            Dim ITEMCLAUSE As String = ""
            Dim DESIGNCLAUSE As String = ""
            Dim SHADECLAUSE As String = ""

            Dim WHERECLAUSE As String = " AND YEARID=" & YearId

            'FOR UNIT
            gridbillunit.ClearColumnsFilter()
            For i As Integer = 0 To gridbillunit.RowCount - 1
                Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If UNITCLAUSE = "" Then
                        UNITCLAUSE = " And (UNIT = '" & dtrow("UNIT") & "'"
                    Else
                        UNITCLAUSE = UNITCLAUSE & " OR UNIT = '" & dtrow("UNIT") & "'"
                    End If
                End If
            Next
            If UNITCLAUSE <> "" Then
                UNITCLAUSE = UNITCLAUSE & ")"
                WHERECLAUSE = WHERECLAUSE & UNITCLAUSE
            End If


            'FOR ITEMNAME
            GRIDITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND (ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR ITEMNAME = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                WHERECLAUSE = WHERECLAUSE & ITEMCLAUSE
            End If

            'FOR DESIGN
            GRIDDESIGN.ClearColumnsFilter()
            For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If DESIGNCLAUSE = "" Then
                        DESIGNCLAUSE = " AND (DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                    Else
                        DESIGNCLAUSE = DESIGNCLAUSE & " OR DESIGNNO = '" & dtrow("DESIGNNO") & "'"
                    End If
                End If
            Next
            If DESIGNCLAUSE <> "" Then
                DESIGNCLAUSE = DESIGNCLAUSE & ")"
                WHERECLAUSE = WHERECLAUSE & DESIGNCLAUSE
            End If

            'FOR SHADE
            GRIDSHADE.ClearColumnsFilter()
            For i As Integer = 0 To GRIDSHADE.RowCount - 1
                Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If SHADECLAUSE = "" Then
                        SHADECLAUSE = " AND (COLOR = '" & dtrow("SHADE") & "'"
                    Else
                        SHADECLAUSE = SHADECLAUSE & " OR COLOR = '" & dtrow("SHADE") & "'"
                    End If
                End If
            Next
            If SHADECLAUSE <> "" Then
                SHADECLAUSE = SHADECLAUSE & ")"
                WHERECLAUSE = WHERECLAUSE & SHADECLAUSE
            End If

            If CMBGODOWN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and GODOWN='" & CMBGODOWN.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and ITEMNAME='" & CMBITEMNAME.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and DESIGNNO='" & CMBDESIGN.Text.Trim & "'"
            If CMBSHADE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and COLOR='" & CMBSHADE.Text.Trim & "'"
            If CMBPIECETYPE.Text.Trim <> "" Then WHERECLAUSE = WHERECLAUSE & " and PIECETYPE='" & CMBPIECETYPE.Text.Trim & "'"
            If chkdate.Checked = True Then WHERECLAUSE = WHERECLAUSE & " AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"

            If RBDYEINGSTOCK.Checked = True Then
                Dim OBJDYEING As New LotGridreport
                OBJDYEING.MdiParent = MDIMain
                OBJDYEING.WHERECLAUSE = " AND YEARID=" & YearId & " AND DATE <= '" & Format(dtto.Value.Date, "MM/dd/yyyy") & "'"
                OBJDYEING.TILLDATE = dtto.Value.Date
                OBJDYEING.FRMSTRING = "STOCKREGISTER"
                OBJDYEING.Show()
            ElseIf RBGODOWNSTOCK.Checked = True Then
                Dim OBJGODOWN As New GodownStockRegister
                OBJGODOWN.MdiParent = MDIMain
                OBJGODOWN.WHERECLAUSE = WHERECLAUSE
                OBJGODOWN.Show()
            ElseIf RBPACKINGSTOCK.Checked = True Then
                Dim OBJPACKING As New PackingStockRegister
                OBJPACKING.MdiParent = MDIMain
                OBJPACKING.WHERECLAUSE = WHERECLAUSE
                OBJPACKING.Show()
            ElseIf RBCHALLANSTOCK.Checked = True Then
                Dim OBJCHALLAN As New ChallanStockRegister
                OBJCHALLAN.MdiParent = MDIMain
                If chkdate.Checked = True Then OBJCHALLAN.TILLDATE = dtto.Value.Date Else OBJCHALLAN.TILLDATE = AccTo.Date
                OBJCHALLAN.Show()



            Else

                'FOR CRYSTAL REPORTS
                Dim OBJSTOCK As New StockDesign
                OBJSTOCK.MdiParent = MDIMain
                OBJSTOCK.WHERECLAUSE = " 1=1 "
                If chkdate.CheckState = CheckState.Checked Then
                    getFromToDate()
                    OBJSTOCK.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & "-" & Format(dtto.Value.Date, "dd/MM/yyyy")
                    OBJSTOCK.FROMDATE = dtfrom.Value.Date
                    OBJSTOCK.TODATE = dtto.Value.Date
                    OBJSTOCK.WHERECLAUSE = OBJSTOCK.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
                Else
                    OBJSTOCK.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & "-" & Format(AccTo.Date, "dd/MM/yyyy")
                End If
                If RBGREYSTOCKMONTHLY.Checked = True Then
                    OBJSTOCK.FRMSTRING = "GREYSTOCKMONTHLY"

                ElseIf RBDYEINGSTOCKMONTHLY.Checked = True Then
                    OBJSTOCK.FRMSTRING = "DYEINGSTOCKMONTHLY"

                ElseIf RBFINISHSTOCKMONTHLY.Checked = True Then
                    OBJSTOCK.FRMSTRING = "GODOWNSTOCKMONTHLY"

                End If

                OBJSTOCK.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDESIGN.Enter
        Try
            If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then DESIGNVALIDATE(CMBDESIGN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHADE.Enter
        Try
            If CMBSHADE.Text.Trim = "" Then FILLCOLOR(CMBSHADE, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then COLORVALIDATE(CMBSHADE, e, Me, CMBDESIGN.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTDESIGN_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTDESIGN.CheckedChanged
        Try
            For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                dtrow("CHK") = CHKSELECTDESIGN.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTSHADE_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTSHADE.CheckedChanged
        Try
            For i As Integer = 0 To GRIDSHADE.RowCount - 1
                Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                dtrow("CHK") = CHKSELECTSHADE.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTITEM_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTITEM.CheckedChanged
        Try
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                dtrow("CHK") = CHKSELECTITEM.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTUNIT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTUNIT.CheckedChanged
        Try
            For i As Integer = 0 To gridbillunit.RowCount - 1
                Dim dtrow As DataRow = gridbillunit.GetDataRow(i)
                dtrow("CHK") = CHKSELECTUNIT.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class