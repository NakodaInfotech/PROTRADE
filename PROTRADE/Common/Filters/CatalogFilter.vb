
Imports BL

Public Class CatalogFilter

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            Dim WHERECLAUSE As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DTITEM As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME ", " ", " ITEMMASTER ", WHERECLAUSE & " ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDITEMDETAILS.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDITEM.FocusedRowHandle = GRIDITEM.RowCount - 1
                GRIDITEM.TopRowIndex = GRIDITEM.RowCount - 15
            End If

            Dim DTDESIGN As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, DESIGNMASTER.DESIGN_NO AS DESIGNNO ", " ", " DESIGNMASTER ", WHERECLAUSE & " ORDER BY DESIGNMASTER.DESIGN_NO")
            GRIDDESIGNDETAILS.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                GRIDDESIGN.FocusedRowHandle = GRIDDESIGN.RowCount - 1
                GRIDDESIGN.TopRowIndex = GRIDDESIGN.RowCount - 15
            End If

            Dim DTSHADE As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, COLORMASTER.COLOR_NAME AS SHADE", " ", " COLORMASTER ", WHERECLAUSE & " ORDER BY COLORMASTER.COLOR_NAME")
            GRIDSHADEDETAILS.DataSource = DTSHADE
            If DTSHADE.Rows.Count > 0 Then
                GRIDSHADE.FocusedRowHandle = GRIDSHADE.RowCount - 1
                GRIDSHADE.TopRowIndex = GRIDSHADE.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CatalogFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CatalogFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(sender As Object, e As EventArgs) Handles cmdshow.Click
        Try

            'IF PRINTBARCODE IS TRUE THEN OPENGRID STOCK REPORTS OR ELSE OPEN CRYSTAL REPORTS
            Dim ITEMCLAUSE As String = ""
            Dim DESIGNCLAUSE As String = ""
            Dim SHADECLAUSE As String = ""


            Dim OBJCMN As New ClsCommon
            Dim OBJCATALOG As New CatalogDesign
            OBJCATALOG.MdiParent = MDIMain



            OBJCATALOG.WHERECLAUSE = " {CATALOGMASTER.CATALOG_YEARID}=" & YearId
            If CHKSTOCK.Checked = True Then OBJCATALOG.WHERECLAUSE = OBJCATALOG.WHERECLAUSE & " AND {BARCODESTOCK.MTRS} > 0 "

            'FOR ITEMNAME
            GRIDITEM.ClearColumnsFilter()
            For i As Integer = 0 To GRIDITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND ({ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR {ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJCATALOG.WHERECLAUSE = OBJCATALOG.WHERECLAUSE & ITEMCLAUSE
            End If

            'FOR DESIGN
            GRIDDESIGN.ClearColumnsFilter()
            For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If DESIGNCLAUSE = "" Then
                        DESIGNCLAUSE = " AND ({DESIGNMASTER.DESIGN_NO} = '" & dtrow("DESIGNNO") & "'"
                    Else
                        DESIGNCLAUSE = DESIGNCLAUSE & " OR {DESIGNMASTER.DESIGN_NO} = '" & dtrow("DESIGNNO") & "'"
                    End If
                End If
            Next
            If DESIGNCLAUSE <> "" Then
                DESIGNCLAUSE = DESIGNCLAUSE & ")"
                OBJCATALOG.WHERECLAUSE = OBJCATALOG.WHERECLAUSE & DESIGNCLAUSE
            End If

            'FOR SHADE
            GRIDSHADE.ClearColumnsFilter()
            For i As Integer = 0 To GRIDSHADE.RowCount - 1
                Dim dtrow As DataRow = GRIDSHADE.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If SHADECLAUSE = "" Then
                        SHADECLAUSE = " AND ({COLORMASTER.COLOR_NAME} = '" & dtrow("SHADE") & "'"
                    Else
                        SHADECLAUSE = SHADECLAUSE & " OR {COLORMASTER.COLOR_NAME} = '" & dtrow("SHADE") & "'"
                    End If
                End If
            Next
            If SHADECLAUSE <> "" Then
                SHADECLAUSE = SHADECLAUSE & ")"
                OBJCATALOG.WHERECLAUSE = OBJCATALOG.WHERECLAUSE & SHADECLAUSE
            End If


            If RBCATALOG.Checked = True Then
                OBJCATALOG.FRMSTRING = "ITEMCATALOG"
            End If
            OBJCATALOG.Show()
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

End Class