Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class UploadSign

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub Clear()
        Try
            TXTPHOTOIMGPATH.Clear()
            PBPHOTO.Image = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CmpId)
            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            Dim objDESIGN As New ClsUploadSign
            objDESIGN.alParaval = alParaval
            IntResult = objDESIGN.save()
            MsgBox("Sign Updated")
            Me.Close()

        Catch ex As Exception
            Throw ex
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

    Private Sub DesignMasterg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim objclsJO As New ClsUploadSign()
            Dim dttable As DataTable = objclsJO.selectdesign(CmpId)
            If dttable.Rows.Count > 0 Then
                For Each dr As DataRow In dttable.Rows
                    If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                        PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                        TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                    Else
                        PBPHOTO.Image = Nothing
                    End If
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class