Imports BL
Imports System.Windows.Forms

Public Class SelectInvoiceForReturn
    Dim tempindex, i As Integer
    Dim SELECTIONFORMULA As String = ""
    Dim ADDCOL As Boolean = False
    Dim col As New DataGridViewCheckBoxColumn
    Public DT As New DataTable
    Public PARTYNAME As String = ""
    Dim WO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStockReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectStockReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Fill COMBOBOXES
        fillquality(CMBQUALITY)
        filldesign(CMBDESIGN)
        fillCOLOR(CMBSHADE)

        CMBQUALITY.SelectedItem = Nothing
        CMBDESIGN.SelectedItem = Nothing
        CMBSHADE.SelectedItem = Nothing
        'CMBQUALITY.Focus()
        fillgrid(" ")
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            If PARTYNAME <> "" Then WHERE = WHERE & " AND LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "'"

            'IF RECEIPT IS DONE THEN DONT FETCH BILL HERE
            Dim objclspreq As New ClsCommon()

            'DONE BY GULKIT, WE NEED TO GET DATA FROM OPENING ALSO
            'Dim DT As DataTable = objclspreq.search(" DISTINCT ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS INVNO, ISNULL(INVOICEMASTER.INVOICE_DATE, GETDATE()) AS INVDATE, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS GDNNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS GDNDATE, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(INVOICE_REGISTERID,0) AS REGID  ", "", " LEDGERS INNER JOIN INVOICEMASTER ON LEDGERS.Acc_id = INVOICEMASTER.INVOICE_LEDGERID", " " & WHERE & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " AND INVOICEMASTER.INVOICE_RETURN = 0 AND INVOICEMASTER.INVOICE_AMTREC = 0 AND INVOICEMASTER.INVOICE_EXTRAAMT = 0 ORDER BY INVNO")
            Dim DT As DataTable = objclspreq.search("*", "", "(SELECT DISTINCT ISNULL(OPENINGBILL.BILL_NO, 0) AS INVNO, ISNULL(OPENINGBILL.BILL_DATE, GETDATE()) AS INVDATE, '' AS GDNNO, ISNULL(OPENINGBILL.BILL_DATE, GETDATE()) AS GDNDATE, 0 AS TOTALPCS, 0 AS TOTALMTRS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(OPENINGBILL.BILL_REGISTERID,0) AS REGID, 'OPENING' AS INVOICETYPE, BILL_INITIALS AS INVINITIALS FROM LEDGERS INNER JOIN OPENINGBILL ON LEDGERS.Acc_id = OPENINGBILL.BILL_LEDGERID WHERE OPENINGBILL.BILL_YEARID = " & YearId & WHERE & " AND OPENINGBILL.BILL_BALANCE > 0 UNION ALL SELECT DISTINCT ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS INVNO, ISNULL(INVOICEMASTER.INVOICE_DATE, GETDATE()) AS INVDATE, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS GDNNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS GDNDATE, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(INVOICE_REGISTERID,0) AS REGID, 'INVOICE' AS INVOICETYPE, INVOICEMASTER.INVOICE_INITIALS AS INVINITIALS  FROM LEDGERS INNER JOIN INVOICEMASTER ON LEDGERS.Acc_id = INVOICEMASTER.INVOICE_LEDGERID WHERE INVOICEMASTER.INVOICE_YEARID = " & YearId & WHERE & " AND INVOICEMASTER.INVOICE_BALANCE > 0) AS T", " ORDER BY T.INVNO")

            GRIDRET.DataSource = DT
            If DT.Rows.Count > 0 Then

                If ADDCOL = False Then
                    GRIDRET.Columns.Insert(0, col)
                    ADDCOL = True
                End If
                Dim I As Integer = 0
                GRIDRET.Columns(I).Width = 40 'CHECK BOK
                I = I + 1

                GRIDRET.Columns(I).Width = 50 'INV NO
                GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                I = I + 1

                GRIDRET.Columns(I).Width = 80 'INV DATE
                I = I + 1
                'GRIDRET.Columns(I).Width = 120 'NAME
                'I = I + 1

                GRIDRET.Columns(I).Width = 50 'GDNNO
                I = I + 1

                GRIDRET.Columns(I).Width = 80 'GDNDATE
                I = I + 1

                'GRIDRET.Columns(I).Visible = False 'SRNO
                'I = I + 1

                'GRIDRET.Columns(I).Width = 80 'PIECETYPE
                'I = I + 1
                'GRIDRET.Columns(I).Width = 200 'ITEM
                'I = I + 1
                'GRIDRET.Columns(I).Width = 80 'HSNCODE
                'I = I + 1

                'GRIDRET.Columns(I).Width = 100 'QUALITY
                'I = I + 1
                'GRIDRET.Columns(I).Width = 100 'DESIGN
                'I = I + 1
                'GRIDRET.Columns(I).Width = 100 'COLOR
                'I = I + 1
                'GRIDRET.Columns(I).Width = 60 'BALENO
                'I = I + 1

                GRIDRET.Columns("TOTALPCS").Width = 100 'TOTAL PCS
                GRIDRET.Columns("TOTALPCS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRET.Columns("TOTALPCS").DefaultCellStyle.Format = "N2"
                I = I + 1

                GRIDRET.Columns("TOTALMTRS").Width = 100 'TOTAL MTRS
                GRIDRET.Columns("TOTALMTRS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRET.Columns("TOTALMTRS").DefaultCellStyle.Format = "N2"
                I = I + 1

                'GRIDRET.Columns(I).Width = 100 'RATE
                'GRIDRET.Columns(I).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'GRIDRET.Columns(I).DefaultCellStyle.Format = "N2"
                'I = I + 1

                'GRIDRET.Columns(I).Width = 50 'PER
                'I = I + 1

                GRIDRET.Columns("NAME").Visible = False 'NAME
                I = I + 1

                'GRIDRET.Columns(I).Visible = False 'GDN BARCODE
                'I = I + 1
                'GRIDRET.Columns(I).Visible = False 'CMPID
                'I = I + 1
                'GRIDRET.Columns(I).Visible = False ' LOCATIONID
                'I = I + 1
                'GRIDRET.Columns(I).Visible = False 'YEARID
                'I = I + 1


                GRIDRET.FirstDisplayedScrollingRowIndex = GRIDRET.RowCount - 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRIDRET_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRET.CellClick
        Dim N As String = ""
        Dim tempindex As Integer
        Dim i As Integer

        'CHECKING SIMILAR LOCATION
        For i = 0 To GRIDRET.RowCount - 1
            With GRIDRET.Rows(i).Cells(0)
                If .Value = True Then
                    N = GRIDRET.Item(1, i).Value.ToString
                End If
            End With
        Next

        If e.RowIndex >= 0 Then
            With GRIDRET.Rows(e.RowIndex).Cells(0)
                If .Value = True Then
                    .Value = False
                Else
                    If (GRIDRET.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                        .Value = True
                        WO = GRIDRET.Rows(e.RowIndex).Cells(1).Value
                        tempindex = e.RowIndex
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        'Try

        '    Dim objclspreq As New ClsCommon()
        '    DT.Columns.Add("GDNNO")
        '    DT.Columns.Add("DATE")
        '    DT.Columns.Add("NAME")
        '    DT.Columns.Add("PARTYCHALLANNO")
        '    DT.Columns.Add("SRNO")
        '    DT.Columns.Add("PIECETYPE")
        '    DT.Columns.Add("ITEM")
        '    DT.Columns.Add("QUALITY")
        '    DT.Columns.Add("DESIGN")
        '    DT.Columns.Add("COLOR")
        '    DT.Columns.Add("BALENO")
        '    DT.Columns.Add("PCS")
        '    DT.Columns.Add("MTRS")

        '    DT.Columns.Add("GDNBARCODE")

        '    For Each ROW As DataGridViewRow In GRIDRET.Rows
        '        If ROW.Cells(0).Value = True Then
        '            DT.Rows.Add(ROW.Cells(1).Value, ROW.Cells(2).Value, ROW.Cells(3).Value, ROW.Cells(4).Value, ROW.Cells(5).Value, ROW.Cells(6).Value, ROW.Cells(7).Value, ROW.Cells(8).Value, ROW.Cells(9).Value, ROW.Cells(10).Value, ROW.Cells(11).Value, Val(ROW.Cells(12).Value), Val(ROW.Cells(13).Value), ROW.Cells(14).Value)
        '        End If
        '    Next
        '    Me.Close()
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try


        Try

            Dim objclspreq As New ClsCommon()
            DT.Columns.Add("INVNO")
            DT.Columns.Add("REGID")
            DT.Columns.Add("INVOICETYPE")
            DT.Columns.Add("INVINITIALS")

            ' DT.Columns.Add("INVDATE")
            'DT.Columns.Add("NAME")
            ' DT.Columns.Add("GDNNO")
            'DT.Columns.Add("GDNDATE")
            'DT.Columns.Add("INVOICENO")

            'DT.Columns.Add("SRNO")
            'DT.Columns.Add("PIECETYPE")
            'DT.Columns.Add("ITEM")
            'DT.Columns.Add("HSNCODE")

            'DT.Columns.Add("QUALITY")
            'DT.Columns.Add("DESIGN")
            'DT.Columns.Add("COLOR")
            ' DT.Columns.Add("BALENO")
            ' DT.Columns.Add("PCS")
            ' DT.Columns.Add("MTRS")
            'DT.Columns.Add("RATE")
            'DT.Columns.Add("PER")
            'DT.Columns.Add("NAME")


            'DT.Columns.Add("GDNBARCODE")

            For Each ROW As DataGridViewRow In GRIDRET.Rows
                If ROW.Cells(0).Value = True Then
                    'DT.Rows.Add(ROW.Cells("INVNO").Value, ROW.Cells("INVDATE").Value, ROW.Cells("GDNNO").Value, ROW.Cells("GDNDATE").Value, ROW.Cells("ITEM").Value, ROW.Cells("HSNCODE").Value, ROW.Cells("QUALITY").Value, ROW.Cells("DESIGN").Value, ROW.Cells("COLOR").Value, ROW.Cells("PCS").Value, ROW.Cells("MTRS").Value, Val(ROW.Cells("RATE").Value), Val(ROW.Cells("PER").Value), Val(ROW.Cells("NAME").Value))

                    'DT.Rows.Add(ROW.Cells("INVNO").Value, ROW.Cells("INVDATE").Value, ROW.Cells("GDNNO").Value, ROW.Cells("GDNDATE").Value, ROW.Cells("TOTALPCS").Value, ROW.Cells("TOTALMTRS").Value, Val(ROW.Cells("NAME").Value))

                    DT.Rows.Add(ROW.Cells("INVNO").Value, ROW.Cells("REGID").Value, ROW.Cells("INVOICETYPE").Value, ROW.Cells("INVINITIALS").Value)

                End If
            Next

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillquality(ByRef CMBQUALITY As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim DT As DataTable = objclscommon.search(" DISTINCT QUALITY ", "", " SALERETURN_STOCK_VIEW ", " AND NAME = '" & PARTYNAME & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "QUALITY"
                CMBQUALITY.DataSource = DT
                CMBQUALITY.DisplayMember = "QUALITY"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filldesign(ByRef CMBDESIGN As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            'Dim DT As DataTable = objclscommon.search(" DISTINCT DESIGN ", "", "  SALERETURN_STOCK_VIEW ", " AND NAME = '" & PARTYNAME & "'  AND QUALITY = '" & CMBQUALITY.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            Dim DT As DataTable = objclscommon.search(" DISTINCT DESIGN ", "", "  SALERETURN_STOCK_VIEW ", " AND NAME = '" & PARTYNAME & "'  AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "DESIGN"
                CMBDESIGN.DataSource = DT
                CMBDESIGN.DisplayMember = "DESIGN"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCOLOR(ByRef CMBSHADE As ComboBox)
        Try
            Dim objclscommon As New ClsCommonMaster
            'Dim DT As DataTable = objclscommon.search(" DISTINCT COLOR ", "", " SALERETURN_STOCK_VIEW ", " AND NAME = '" & PARTYNAME & "'  AND QUALITY = '" & CMBQUALITY.Text.Trim & "' AND DESIGN = '" & CMBDESIGN.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            Dim DT As DataTable = objclscommon.search(" DISTINCT COLOR ", "", " SALERETURN_STOCK_VIEW ", " AND NAME = '" & PARTYNAME & "'  AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                DT.DefaultView.Sort = "COLOR"
                CMBSHADE.DataSource = DT
                CMBSHADE.DisplayMember = "COLOR"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then fillgrid(" AND QUALITY = '" & CMBQUALITY.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDESIGN.Validating
        Try
            If CMBDESIGN.Text.Trim <> "" Then fillgrid(" AND DESIGN =  '" & CMBDESIGN.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHADE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHADE.Validating
        Try
            If CMBSHADE.Text.Trim <> "" Then fillgrid(" AND COLOR = '" & CMBSHADE.Text.Trim & "'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated
        If cmbselect.Text.Trim <> "" Then
            If txtsearch.Text <> "" Then
                If cmbselect.Text = "Challan No" Then
                    fillgrid(" AND  SALERETURN_STOCK_VIEW.GDNNO = " & txtsearch.Text)
                ElseIf cmbselect.Text = "Party Challan No" Then
                    fillgrid(" AND SALERETURN_STOCK_VIEW.PARTYCHALLANNO = " & "'" & txtsearch.Text.Trim & "'")
                End If
            Else
                fillgrid(" ")
            End If
        End If
    End Sub
End Class