<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cmppassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdback = New System.Windows.Forms.Button
        Me.cmdnext = New System.Windows.Forms.Button
        Me.txtretypepassword = New System.Windows.Forms.TextBox
        Me.lblretype = New System.Windows.Forms.Label
        Me.txtpassword = New System.Windows.Forms.TextBox
        Me.lblgroup = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PictureBox2)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdback)
        Me.BlendPanel1.Controls.Add(Me.cmdnext)
        Me.BlendPanel1.Controls.Add(Me.txtretypepassword)
        Me.BlendPanel1.Controls.Add(Me.lblretype)
        Me.BlendPanel1.Controls.Add(Me.txtpassword)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(290, 143)
        Me.BlendPanel1.TabIndex = 15
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.PROTRADE.My.Resources.Resources.Close
        Me.PictureBox2.Location = New System.Drawing.Point(273, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 12)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 205
        Me.PictureBox2.TabStop = False
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(3, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(258, 20)
        Me.lbl.TabIndex = 204
        Me.lbl.Text = "Enter Password Used To Access Company"
        '
        'cmdback
        '
        Me.cmdback.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdback.Location = New System.Drawing.Point(111, 109)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(80, 24)
        Me.cmdback.TabIndex = 200
        Me.cmdback.Tag = ""
        Me.cmdback.Text = "< &Back"
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmdnext
        '
        Me.cmdnext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdnext.Location = New System.Drawing.Point(197, 109)
        Me.cmdnext.Name = "cmdnext"
        Me.cmdnext.Size = New System.Drawing.Size(80, 24)
        Me.cmdnext.TabIndex = 199
        Me.cmdnext.Tag = ""
        Me.cmdnext.Text = "&Next >"
        Me.cmdnext.UseVisualStyleBackColor = True
        '
        'txtretypepassword
        '
        Me.txtretypepassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtretypepassword.Location = New System.Drawing.Point(132, 74)
        Me.txtretypepassword.MaxLength = 8
        Me.txtretypepassword.Name = "txtretypepassword"
        Me.txtretypepassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtretypepassword.Size = New System.Drawing.Size(129, 22)
        Me.txtretypepassword.TabIndex = 198
        '
        'lblretype
        '
        Me.lblretype.AutoSize = True
        Me.lblretype.BackColor = System.Drawing.Color.Transparent
        Me.lblretype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblretype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblretype.Location = New System.Drawing.Point(26, 78)
        Me.lblretype.Name = "lblretype"
        Me.lblretype.Size = New System.Drawing.Size(104, 14)
        Me.lblretype.TabIndex = 203
        Me.lblretype.Text = "Re-Type Password"
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(132, 47)
        Me.txtpassword.MaxLength = 8
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(129, 22)
        Me.txtpassword.TabIndex = 197
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(32, 51)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(98, 14)
        Me.lblgroup.TabIndex = 202
        Me.lblgroup.Text = "Access Password"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(6, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 111)
        Me.GroupBox1.TabIndex = 201
        Me.GroupBox1.TabStop = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'Cmppassword
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(290, 143)
        Me.Controls.Add(Me.BlendPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Cmppassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cmp Password"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdnext As System.Windows.Forms.Button
    Friend WithEvents txtretypepassword As System.Windows.Forms.TextBox
    Friend WithEvents lblretype As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
End Class
