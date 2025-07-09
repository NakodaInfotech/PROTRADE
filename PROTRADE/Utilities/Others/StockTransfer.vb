Imports BL

Public Class StockTransfer

    Dim TEMPGODOWN As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Clear()
        Try
            TXTBARCODE.ReadOnly = False
            TXTBARCODE.Clear()
            TXTBALENO.Clear()
            TXTCOLOR.Clear()
            TXTDESIGNNO.Clear()
            TXTGODOWN.Clear()
            TXTITEM.Clear()
            TXTMTRS.Clear()
            TXTPCS.Clear()
            TXTPIECETYPE.Clear()
            TXTQUALITY.Clear()
            CMBGODOWN.SelectedItem = Nothing
            TXTBARCODE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockTransfer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
            Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTTEMPBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then
                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTBARCODE.ReadOnly = True
                    TXTCOLOR.Text = DT.Rows.Item(0).Item("COLOR")
                    TXTDESIGNNO.Text = DT.Rows.Item(0).Item("DESIGNNO")
                    CMBGODOWN.Text = DT.Rows.Item(0).Item("GODOWN")
                    TXTGODOWN.Text = DT.Rows.Item(0).Item("GODOWN")
                    TXTBALENO.Text = DT.Rows.Item(0).Item("BALENO")
                    TXTITEM.Text = DT.Rows.Item(0).Item("ITEMNAME")
                    TXTMTRS.Text = DT.Rows.Item(0).Item("MTRS")
                    TXTPCS.Text = DT.Rows.Item(0).Item("PCS")
                    TXTPIECETYPE.Text = DT.Rows.Item(0).Item("PIECETYPE")
                    TXTQUALITY.Text = DT.Rows.Item(0).Item("QUALITY")
                    TXTFROMNO.Text = DT.Rows.Item(0).Item("FROMNO")
                    TXTFROMSRNO.Text = DT.Rows.Item(0).Item("FROMSRNO")
                    TXTTYPE.Text = DT.Rows.Item(0).Item("TYPE")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim alparaval As New ArrayList

            alparaval.Add(CMBGODOWN.Text.Trim)
            alparaval.Add(TXTBARCODE.Text.Trim)
            alparaval.Add(TXTBALENO.Text.Trim)
            alparaval.Add(TXTFROMNO.Text.Trim)
            alparaval.Add(TXTFROMSRNO.Text.Trim)
            alparaval.Add(TXTTYPE.Text.Trim)
            alparaval.Add(CmpId)
            alparaval.Add(Userid)
            alparaval.Add(YearId)

            Dim ObjClsChangeStock As New ClsStockTransfer
            ObjClsChangeStock.alParaval = alparaval
            Dim intre As Integer = ObjClsChangeStock.Update
            MsgBox("Godown Changed")
            Clear()
            TXTBARCODE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Validated
        Try
            If CMBGODOWN.Text.Trim = TXTGODOWN.Text.Trim Then
                MsgBox("Please select another Godown")
                CMBGODOWN.SelectedItem = Nothing
                CMBGODOWN.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class