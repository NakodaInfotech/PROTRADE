
Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class Shortcuts

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        Try
            Try
                Dim OBJGRN As New GRNChecking
                OBJGRN.MdiParent = MDIMain
                OBJGRN.Show()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        Try
            Try
                Dim OBJGRN As New MaterialReceipt
                OBJGRN.MdiParent = MDIMain
                OBJGRN.Show()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click
        Try
            Dim OBJGRN As New JobOut
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click
        Try
            Dim OBJGRN As New JobIn
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Try
            Dim OBJGRN As New PaymentMaster
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Try
            Dim OBJGRN As New Receipt
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Try
            Dim OBJGRN As New InvoiceMaster
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Try
            Dim OBJGRN As New PurchaseMaster
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Try
            Dim OBJGRN As New journal
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Try
            Dim OBJGRN As New OutstandingFilter
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        Try
            Dim OBJGRN As New PurchaseOrder
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Try
            Dim OBJGRN As New SaleOrder
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Try
            Dim OBJGRN As New GDN
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Try
            Dim OBJGRN As New BankReco
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Try
            Dim OBJGRN As New PL
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Try
            Dim OBJGRN As New TB
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Try
            Dim OBJGRN As New BS
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click
        Try
            Dim OBJGRN As New ExpenseVoucher
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click
        Try
            Dim OBJGRN As New CREDITNOTE
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click
        Try
            Dim OBJGRN As New DebitNote
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = MDIMain
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class