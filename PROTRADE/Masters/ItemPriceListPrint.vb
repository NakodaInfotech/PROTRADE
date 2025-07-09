
Imports BL

Public Class ItemPriceListPrint

    Public WHERECLAUSE As String = ""

    Private Sub ItemPriceListPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If ClientName = "YASHVI" Then
                TXTHEADER.Text = "NATURAL FABRICS PRICE LIST EFFECTIVE FROM " & Format(Now.Date, "dd/MM/yyyy")
                TXTHEADERDESC.Text = "Made from mainly Natural Fibre as Linen. Cotton, Bamboo, Ramie, Tancel etc for better Ventilation and High comfort. Skin Friendly and Versatile fabrics."
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try
            If CMBPRICELIST.Text.Trim = "" Then
                MsgBox("Select Price List to be Printed", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Me.Close()
            Dim OBJPRICELIST As New SaleInvoiceDesign
            OBJPRICELIST.MdiParent = MDIMain
            OBJPRICELIST.FRMSTRING = "PRICELIST"
            OBJPRICELIST.PERIOD = TXTHEADER.Text.Trim
            OBJPRICELIST.WHERECLAUSE = WHERECLAUSE
            OBJPRICELIST.SELECTEDRATE = CMBPRICELIST.Text.Trim
            OBJPRICELIST.PLDESC = TXTHEADERDESC.Text.Trim
            OBJPRICELIST.PLREMARKS = TXTREMARKS.Text.Trim
            OBJPRICELIST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class