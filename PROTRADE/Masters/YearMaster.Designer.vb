<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YearMaster
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdback = New System.Windows.Forms.Button
        Me.cmdfinish = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblgroup = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.enddate = New System.Windows.Forms.DateTimePicker
        Me.startdate = New System.Windows.Forms.DateTimePicker
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PictureBox2)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdback)
        Me.BlendPanel1.Controls.Add(Me.cmdfinish)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(246, 163)
        Me.BlendPanel1.TabIndex = 16
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.PROTRADE.My.Resources.Resources.Close
        Me.PictureBox2.Location = New System.Drawing.Point(227, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 12)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 206
        Me.PictureBox2.TabStop = False
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(5, 10)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(209, 18)
        Me.lbl.TabIndex = 182
        Me.lbl.Text = "Select Accounting Year For Company"
        '
        'cmdback
        '
        Me.cmdback.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdback.Location = New System.Drawing.Point(74, 120)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(71, 24)
        Me.cmdback.TabIndex = 178
        Me.cmdback.Text = "< &Back"
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmdfinish
        '
        Me.cmdfinish.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfinish.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdfinish.Location = New System.Drawing.Point(151, 120)
        Me.cmdfinish.Name = "cmdfinish"
        Me.cmdfinish.Size = New System.Drawing.Size(71, 24)
        Me.cmdfinish.TabIndex = 177
        Me.cmdfinish.Text = "&Finish >"
        Me.cmdfinish.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(58, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "End Date"
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.Black
        Me.lblgroup.Location = New System.Drawing.Point(53, 59)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(61, 14)
        Me.lblgroup.TabIndex = 180
        Me.lblgroup.Text = "Start Date"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.enddate)
        Me.GroupBox1.Controls.Add(Me.startdate)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 120)
        Me.GroupBox1.TabIndex = 179
        Me.GroupBox1.TabStop = False
        '
        'enddate
        '
        Me.enddate.CustomFormat = "dd/MM/yyyy"
        Me.enddate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.enddate.Location = New System.Drawing.Point(98, 49)
        Me.enddate.Name = "enddate"
        Me.enddate.Size = New System.Drawing.Size(83, 22)
        Me.enddate.TabIndex = 1
        '
        'startdate
        '
        Me.startdate.CustomFormat = "dd/MM/yyyy"
        Me.startdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.startdate.Location = New System.Drawing.Point(98, 23)
        Me.startdate.Name = "startdate"
        Me.startdate.Size = New System.Drawing.Size(83, 22)
        Me.startdate.TabIndex = 0
        '
        'YearMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(246, 163)
        Me.Controls.Add(Me.BlendPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "YearMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accounting Year"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdfinish As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents enddate As System.Windows.Forms.DateTimePicker
    Friend WithEvents startdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
