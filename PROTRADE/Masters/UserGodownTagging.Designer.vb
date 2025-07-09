<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserGodownTagging
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.CMBUSER = New System.Windows.Forms.ComboBox()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.LBLCODE = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.UserId = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.CMBUSER)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.LBLCODE)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.UserId)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(290, 175)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(75, 40)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(171, 22)
        Me.CMBGODOWN.TabIndex = 1
        '
        'CMBUSER
        '
        Me.CMBUSER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUSER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUSER.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBUSER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUSER.FormattingEnabled = True
        Me.CMBUSER.Location = New System.Drawing.Point(75, 12)
        Me.CMBUSER.MaxDropDownItems = 14
        Me.CMBUSER.Name = "CMBUSER"
        Me.CMBUSER.Size = New System.Drawing.Size(171, 22)
        Me.CMBUSER.TabIndex = 0
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(166, 79)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 3
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'LBLCODE
        '
        Me.LBLCODE.AutoSize = True
        Me.LBLCODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLCODE.Location = New System.Drawing.Point(24, 44)
        Me.LBLCODE.Name = "LBLCODE"
        Me.LBLCODE.Size = New System.Drawing.Size(52, 14)
        Me.LBLCODE.TabIndex = 154
        Me.LBLCODE.Text = "Godown"
        Me.LBLCODE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(80, 113)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(80, 79)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'UserId
        '
        Me.UserId.AutoSize = True
        Me.UserId.BackColor = System.Drawing.Color.Transparent
        Me.UserId.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UserId.Location = New System.Drawing.Point(8, 16)
        Me.UserId.Name = "UserId"
        Me.UserId.Size = New System.Drawing.Size(66, 15)
        Me.UserId.TabIndex = 149
        Me.UserId.Text = "User Name"
        Me.UserId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(166, 113)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'UserGodownTagging
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(290, 175)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UserGodownTagging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "User Godown Tagging"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents LBLCODE As Label
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents UserId As Label
    Friend WithEvents cmdexit As Button
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents CMBUSER As ComboBox
    Friend WithEvents CMBGODOWN As ComboBox
End Class
