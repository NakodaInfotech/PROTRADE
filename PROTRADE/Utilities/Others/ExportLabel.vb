
Imports System.IO
Imports BL

Public Class ExportLabel


    Private Sub TXTCHALLANNO_Validated(sender As Object, e As EventArgs) Handles TXTCHALLANNO.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("GDN_TOTALPCS AS TOTALPCS, GDN_TOTALMTRS AS TOTALMTRS", "", "GDN", " AND GDN_NO = " & Val(TXTCHALLANNO.Text.Trim) & " AND GDN_YEARID = " & YearId)
            TXTPCS.Text = Val(DT.Rows(0).Item("TOTALPCS"))
            TXTMTRS.Text = Val(DT.Rows(0).Item("TOTALMTRS"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            TXTCONSIGNEE.Clear()
            TXTSMARK.Clear()
            TXTCHALLANNO.Clear()
            TXTPCS.Clear()
            TXTMTRS.Clear()
            TXTCOPIES.Text = 2
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPRINT_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try
            For i As Integer = 1 To Val(TXTCOPIES.Text.Trim)
                Dim dirresults As String = ""

                Dim oWrite As System.IO.StreamWriter
                oWrite = File.CreateText("D:\Barcode.txt")

                If ClientName = "AVIS" Then

                    oWrite.WriteLine("<xpml><page quantity='0' pitch='75.1 mm'></xpml>G0")
                    oWrite.WriteLine("n")
                    oWrite.WriteLine("M0739")
                    oWrite.WriteLine("O0214")
                    oWrite.WriteLine("V0")
                    oWrite.WriteLine("t1")
                    oWrite.WriteLine("Kf0070")
                    oWrite.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='75.1 mm'></xpml>L")
                    oWrite.WriteLine("D11")
                    oWrite.WriteLine("ySPM")
                    oWrite.WriteLine("A2")
                    oWrite.WriteLine("1911C1402530011SHIPPER")
                    oWrite.WriteLine("1911C1002200011CONSIGNEE")
                    oWrite.WriteLine("1911C1801750011S. MARK")
                    oWrite.WriteLine("1911C1801340011C/NO")
                    oWrite.WriteLine("1911C1800920011PCS")
                    oWrite.WriteLine("1911C1800510011MTRS")
                    oWrite.WriteLine("1911C0800260141" & TXTLABEL.Text.Trim)
                    oWrite.WriteLine("1911C1402530098:")
                    oWrite.WriteLine("1911C1002200098:")
                    oWrite.WriteLine("1911C1801750126:")
                    oWrite.WriteLine("1911C1801330126:")
                    oWrite.WriteLine("1911C1800920126:")
                    oWrite.WriteLine("1911C1800500126:")
                    oWrite.WriteLine("1911C1402520106" & CmpName)
                    oWrite.WriteLine("1911C1002200106" & TXTCONSIGNEE.Text.Trim)
                    oWrite.WriteLine("1911C1801750137" & TXTSMARK.Text.Trim)
                    oWrite.WriteLine("1911C1801330137" & Val(TXTCHALLANNO.Text.Trim))
                    oWrite.WriteLine("1911C1800920137" & Format(Val(TXTPCS.Text.Trim), "0"))
                    oWrite.WriteLine("1911C1800500137" & Format(Val(TXTMTRS.Text.Trim), "0.00"))
                    oWrite.WriteLine("Q0001")
                    oWrite.WriteLine("E")
                    oWrite.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                    oWrite.Dispose()
                End If

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
End Class