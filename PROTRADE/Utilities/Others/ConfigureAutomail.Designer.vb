<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigureAutomail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKSHOWPASS = New System.Windows.Forms.CheckBox()
        Me.txtsmtppass = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtsmtpemail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtsmtp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDUPDATE = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSHOWPASS)
        Me.BlendPanel1.Controls.Add(Me.txtsmtppass)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.txtsmtpemail)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.txtsmtp)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(492, 374)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKSHOWPASS
        '
        Me.CHKSHOWPASS.AutoSize = True
        Me.CHKSHOWPASS.BackColor = System.Drawing.Color.Transparent
        Me.CHKSHOWPASS.Location = New System.Drawing.Point(65, 99)
        Me.CHKSHOWPASS.Name = "CHKSHOWPASS"
        Me.CHKSHOWPASS.Size = New System.Drawing.Size(112, 19)
        Me.CHKSHOWPASS.TabIndex = 457
        Me.CHKSHOWPASS.Text = "Show Password"
        Me.CHKSHOWPASS.UseVisualStyleBackColor = False
        '
        'txtsmtppass
        '
        Me.txtsmtppass.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtsmtppass.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsmtppass.Location = New System.Drawing.Point(65, 71)
        Me.txtsmtppass.Name = "txtsmtppass"
        Me.txtsmtppass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtsmtppass.Size = New System.Drawing.Size(173, 22)
        Me.txtsmtppass.TabIndex = 453
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 14)
        Me.Label9.TabIndex = 456
        Me.Label9.Text = "PWD"
        '
        'txtsmtpemail
        '
        Me.txtsmtpemail.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtsmtpemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsmtpemail.Location = New System.Drawing.Point(65, 43)
        Me.txtsmtpemail.Name = "txtsmtpemail"
        Me.txtsmtpemail.Size = New System.Drawing.Size(173, 22)
        Me.txtsmtpemail.TabIndex = 452
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 14)
        Me.Label8.TabIndex = 455
        Me.Label8.Text = "Email"
        '
        'txtsmtp
        '
        Me.txtsmtp.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtsmtp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsmtp.Location = New System.Drawing.Point(65, 15)
        Me.txtsmtp.Name = "txtsmtp"
        Me.txtsmtp.Size = New System.Drawing.Size(173, 22)
        Me.txtsmtp.TabIndex = 451
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 14)
        Me.Label7.TabIndex = 454
        Me.Label7.Text = "SMTP"
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(310, 334)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 4
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(224, 334)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 3
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.Location = New System.Drawing.Point(138, 334)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPDATE.TabIndex = 2
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.UseVisualStyleBackColor = True
        '
        'ConfigureAutomail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(492, 374)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ConfigureAutomail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Configure Automail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDUPDATE As Button
    Friend WithEvents txtsmtppass As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtsmtpemail As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtsmtp As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CHKSHOWPASS As CheckBox
End Class
