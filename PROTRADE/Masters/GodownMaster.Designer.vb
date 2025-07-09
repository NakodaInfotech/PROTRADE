<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GodownMaster
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTADDRESS = New System.Windows.Forms.TextBox()
        Me.CHKDEFAULT = New System.Windows.Forms.CheckBox()
        Me.CHKOURGODOWN = New System.Windows.Forms.CheckBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTGODOWN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TXTKMS = New System.Windows.Forms.TextBox()
        Me.cmbstate = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXTPINCODE = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label63)
        Me.BlendPanel1.Controls.Add(Me.TXTKMS)
        Me.BlendPanel1.Controls.Add(Me.cmbstate)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.TXTPINCODE)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTADDRESS)
        Me.BlendPanel1.Controls.Add(Me.CHKDEFAULT)
        Me.BlendPanel1.Controls.Add(Me.CHKOURGODOWN)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTGODOWN)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(354, 284)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 314
        Me.Label1.Text = "Address"
        '
        'TXTADDRESS
        '
        Me.TXTADDRESS.ForeColor = System.Drawing.Color.Black
        Me.TXTADDRESS.Location = New System.Drawing.Point(107, 48)
        Me.TXTADDRESS.MaxLength = 1000
        Me.TXTADDRESS.Multiline = True
        Me.TXTADDRESS.Name = "TXTADDRESS"
        Me.TXTADDRESS.Size = New System.Drawing.Size(224, 85)
        Me.TXTADDRESS.TabIndex = 1
        '
        'CHKDEFAULT
        '
        Me.CHKDEFAULT.AutoSize = True
        Me.CHKDEFAULT.BackColor = System.Drawing.Color.Transparent
        Me.CHKDEFAULT.Location = New System.Drawing.Point(267, 197)
        Me.CHKDEFAULT.Name = "CHKDEFAULT"
        Me.CHKDEFAULT.Size = New System.Drawing.Size(64, 19)
        Me.CHKDEFAULT.TabIndex = 6
        Me.CHKDEFAULT.Text = "Default"
        Me.CHKDEFAULT.UseVisualStyleBackColor = False
        '
        'CHKOURGODOWN
        '
        Me.CHKOURGODOWN.AutoSize = True
        Me.CHKOURGODOWN.BackColor = System.Drawing.Color.Transparent
        Me.CHKOURGODOWN.Location = New System.Drawing.Point(107, 197)
        Me.CHKOURGODOWN.Name = "CHKOURGODOWN"
        Me.CHKOURGODOWN.Size = New System.Drawing.Size(95, 19)
        Me.CHKOURGODOWN.TabIndex = 5
        Me.CHKOURGODOWN.Text = "Our Godown"
        Me.CHKOURGODOWN.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(137, 228)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 8
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(51, 228)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 7
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(223, 228)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTGODOWN
        '
        Me.TXTGODOWN.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGODOWN.Location = New System.Drawing.Point(107, 19)
        Me.TXTGODOWN.Name = "TXTGODOWN"
        Me.TXTGODOWN.Size = New System.Drawing.Size(224, 23)
        Me.TXTGODOWN.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 310
        Me.Label3.Text = "Godown Name"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(250, 143)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(31, 15)
        Me.Label63.TabIndex = 693
        Me.Label63.Text = "KMS"
        '
        'TXTKMS
        '
        Me.TXTKMS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTKMS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKMS.Location = New System.Drawing.Point(283, 139)
        Me.TXTKMS.Name = "TXTKMS"
        Me.TXTKMS.Size = New System.Drawing.Size(48, 23)
        Me.TXTKMS.TabIndex = 3
        Me.TXTKMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbstate
        '
        Me.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbstate.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbstate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstate.FormattingEnabled = True
        Me.cmbstate.Location = New System.Drawing.Point(107, 168)
        Me.cmbstate.MaxDropDownItems = 14
        Me.cmbstate.Name = "cmbstate"
        Me.cmbstate.Size = New System.Drawing.Size(224, 23)
        Me.cmbstate.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(72, 172)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 15)
        Me.Label23.TabIndex = 691
        Me.Label23.Text = "State"
        '
        'TXTPINCODE
        '
        Me.TXTPINCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPINCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPINCODE.Location = New System.Drawing.Point(107, 139)
        Me.TXTPINCODE.Name = "TXTPINCODE"
        Me.TXTPINCODE.Size = New System.Drawing.Size(85, 23)
        Me.TXTPINCODE.TabIndex = 2
        Me.TXTPINCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(51, 143)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 15)
        Me.Label22.TabIndex = 690
        Me.Label22.Text = "Pin Code"
        '
        'GodownMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(354, 284)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GodownMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Godown Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTGODOWN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CHKOURGODOWN As System.Windows.Forms.CheckBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CHKDEFAULT As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTADDRESS As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As Label
    Friend WithEvents TXTKMS As TextBox
    Friend WithEvents cmbstate As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TXTPINCODE As TextBox
    Friend WithEvents Label22 As Label
End Class
