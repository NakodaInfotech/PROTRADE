<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignReplacement
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
        Me.components = New System.ComponentModel.Container
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.CMDUPDATE = New System.Windows.Forms.Button
        Me.CMBNEWCOLOR = New System.Windows.Forms.ComboBox
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox
        Me.CMBOLDDESIGN = New System.Windows.Forms.ComboBox
        Me.CMBOLDCOLOR = New System.Windows.Forms.ComboBox
        Me.CMBNEWDESIGN = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Controls.Add(Me.CMBNEWCOLOR)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CMBOLDDESIGN)
        Me.BlendPanel1.Controls.Add(Me.CMBOLDCOLOR)
        Me.BlendPanel1.Controls.Add(Me.CMBNEWDESIGN)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(471, 175)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(281, 124)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 7
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(195, 124)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 6
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.Location = New System.Drawing.Point(109, 124)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPDATE.TabIndex = 5
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.UseVisualStyleBackColor = True
        '
        'CMBNEWCOLOR
        '
        Me.CMBNEWCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNEWCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNEWCOLOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNEWCOLOR.FormattingEnabled = True
        Me.CMBNEWCOLOR.Location = New System.Drawing.Point(306, 78)
        Me.CMBNEWCOLOR.Name = "CMBNEWCOLOR"
        Me.CMBNEWCOLOR.Size = New System.Drawing.Size(140, 23)
        Me.CMBNEWCOLOR.TabIndex = 4
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(72, 20)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(140, 23)
        Me.CMBQUALITY.TabIndex = 0
        '
        'CMBOLDDESIGN
        '
        Me.CMBOLDDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOLDDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOLDDESIGN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBOLDDESIGN.FormattingEnabled = True
        Me.CMBOLDDESIGN.Location = New System.Drawing.Point(72, 49)
        Me.CMBOLDDESIGN.Name = "CMBOLDDESIGN"
        Me.CMBOLDDESIGN.Size = New System.Drawing.Size(140, 23)
        Me.CMBOLDDESIGN.TabIndex = 1
        '
        'CMBOLDCOLOR
        '
        Me.CMBOLDCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOLDCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOLDCOLOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBOLDCOLOR.FormattingEnabled = True
        Me.CMBOLDCOLOR.Location = New System.Drawing.Point(72, 78)
        Me.CMBOLDCOLOR.Name = "CMBOLDCOLOR"
        Me.CMBOLDCOLOR.Size = New System.Drawing.Size(140, 23)
        Me.CMBOLDCOLOR.TabIndex = 3
        '
        'CMBNEWDESIGN
        '
        Me.CMBNEWDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNEWDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNEWDESIGN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNEWDESIGN.FormattingEnabled = True
        Me.CMBNEWDESIGN.Location = New System.Drawing.Point(306, 49)
        Me.CMBNEWDESIGN.Name = "CMBNEWDESIGN"
        Me.CMBNEWDESIGN.Size = New System.Drawing.Size(140, 23)
        Me.CMBNEWDESIGN.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(230, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "New Design"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(234, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "New Shade"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(5, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Old Design"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Old Shade"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(23, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quality"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'DesignReplacement
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(471, 175)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignReplacement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Replacement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBNEWCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents CMBOLDDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents CMBOLDCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNEWDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDUPDATE As System.Windows.Forms.Button
End Class
