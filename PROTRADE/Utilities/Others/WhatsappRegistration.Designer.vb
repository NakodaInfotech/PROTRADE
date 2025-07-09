<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WhatsappRegistration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CMDGETQRCODE = New System.Windows.Forms.Button()
        Me.TXTRESPONSE = New System.Windows.Forms.TextBox()
        Me.CMDSTATUS = New System.Windows.Forms.Button()
        Me.CMDSENDDOC = New System.Windows.Forms.Button()
        Me.CMDDISCONNECT = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(465, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(245, 252)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'CMDGETQRCODE
        '
        Me.CMDGETQRCODE.Location = New System.Drawing.Point(24, 55)
        Me.CMDGETQRCODE.Name = "CMDGETQRCODE"
        Me.CMDGETQRCODE.Size = New System.Drawing.Size(80, 28)
        Me.CMDGETQRCODE.TabIndex = 1
        Me.CMDGETQRCODE.Text = "Get QRCode"
        Me.CMDGETQRCODE.UseVisualStyleBackColor = True
        '
        'TXTRESPONSE
        '
        Me.TXTRESPONSE.Location = New System.Drawing.Point(129, 12)
        Me.TXTRESPONSE.Multiline = True
        Me.TXTRESPONSE.Name = "TXTRESPONSE"
        Me.TXTRESPONSE.Size = New System.Drawing.Size(330, 252)
        Me.TXTRESPONSE.TabIndex = 2
        '
        'CMDSTATUS
        '
        Me.CMDSTATUS.Location = New System.Drawing.Point(24, 89)
        Me.CMDSTATUS.Name = "CMDSTATUS"
        Me.CMDSTATUS.Size = New System.Drawing.Size(80, 28)
        Me.CMDSTATUS.TabIndex = 3
        Me.CMDSTATUS.Text = "Get Status"
        Me.CMDSTATUS.UseVisualStyleBackColor = True
        '
        'CMDSENDDOC
        '
        Me.CMDSENDDOC.Location = New System.Drawing.Point(24, 123)
        Me.CMDSENDDOC.Name = "CMDSENDDOC"
        Me.CMDSENDDOC.Size = New System.Drawing.Size(80, 28)
        Me.CMDSENDDOC.TabIndex = 4
        Me.CMDSENDDOC.Text = "Send Doc"
        Me.CMDSENDDOC.UseVisualStyleBackColor = True
        '
        'CMDDISCONNECT
        '
        Me.CMDDISCONNECT.Location = New System.Drawing.Point(24, 21)
        Me.CMDDISCONNECT.Name = "CMDDISCONNECT"
        Me.CMDDISCONNECT.Size = New System.Drawing.Size(80, 28)
        Me.CMDDISCONNECT.TabIndex = 5
        Me.CMDDISCONNECT.Text = "Disconnect"
        Me.CMDDISCONNECT.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(342, 270)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 6
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'WhatsappRegistration
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(748, 308)
        Me.Controls.Add(Me.CMDEXIT)
        Me.Controls.Add(Me.CMDDISCONNECT)
        Me.Controls.Add(Me.CMDSENDDOC)
        Me.Controls.Add(Me.CMDSTATUS)
        Me.Controls.Add(Me.TXTRESPONSE)
        Me.Controls.Add(Me.CMDGETQRCODE)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "WhatsappRegistration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Whatsapp Registration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CMDGETQRCODE As Button
    Friend WithEvents TXTRESPONSE As TextBox
    Friend WithEvents CMDSTATUS As Button
    Friend WithEvents CMDSENDDOC As Button
    Friend WithEvents CMDDISCONNECT As Button
    Friend WithEvents CMDEXIT As Button
End Class
