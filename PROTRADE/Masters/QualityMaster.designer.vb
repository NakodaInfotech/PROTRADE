<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QualityMaster
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
        Me.TXTWARP = New System.Windows.Forms.TextBox()
        Me.TXTWEFT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTSELVEDGE = New System.Windows.Forms.TextBox()
        Me.TXTWIDTH = New System.Windows.Forms.TextBox()
        Me.TXTPICK = New System.Windows.Forms.TextBox()
        Me.TXTCOUNT = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTREED = New System.Windows.Forms.TextBox()
        Me.cmbQuality = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBLCOUNT = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmbprocessname = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTWARP)
        Me.BlendPanel1.Controls.Add(Me.TXTWEFT)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTSELVEDGE)
        Me.BlendPanel1.Controls.Add(Me.TXTWIDTH)
        Me.BlendPanel1.Controls.Add(Me.TXTPICK)
        Me.BlendPanel1.Controls.Add(Me.TXTCOUNT)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTREED)
        Me.BlendPanel1.Controls.Add(Me.cmbQuality)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.LBLCOUNT)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.cmbunit)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmbitemname)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.cmbprocessname)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(322, 335)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTWARP
        '
        Me.TXTWARP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWARP.Location = New System.Drawing.Point(85, 211)
        Me.TXTWARP.Name = "TXTWARP"
        Me.TXTWARP.Size = New System.Drawing.Size(68, 22)
        Me.TXTWARP.TabIndex = 9
        Me.TXTWARP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTWEFT
        '
        Me.TXTWEFT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWEFT.Location = New System.Drawing.Point(223, 211)
        Me.TXTWEFT.Name = "TXTWEFT"
        Me.TXTWEFT.Size = New System.Drawing.Size(73, 22)
        Me.TXTWEFT.TabIndex = 10
        Me.TXTWEFT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(185, 215)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 14)
        Me.Label10.TabIndex = 497
        Me.Label10.Text = "Weft"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(44, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 14)
        Me.Label9.TabIndex = 496
        Me.Label9.Text = "Warp"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 495
        Me.Label7.Text = "Selvedge"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTSELVEDGE
        '
        Me.TXTSELVEDGE.ForeColor = System.Drawing.Color.Black
        Me.TXTSELVEDGE.Location = New System.Drawing.Point(90, 245)
        Me.TXTSELVEDGE.MaxLength = 200
        Me.TXTSELVEDGE.Name = "TXTSELVEDGE"
        Me.TXTSELVEDGE.Size = New System.Drawing.Size(206, 23)
        Me.TXTSELVEDGE.TabIndex = 11
        '
        'TXTWIDTH
        '
        Me.TXTWIDTH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWIDTH.Location = New System.Drawing.Point(226, 125)
        Me.TXTWIDTH.Name = "TXTWIDTH"
        Me.TXTWIDTH.Size = New System.Drawing.Size(70, 23)
        Me.TXTWIDTH.TabIndex = 7
        '
        'TXTPICK
        '
        Me.TXTPICK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPICK.Location = New System.Drawing.Point(226, 97)
        Me.TXTPICK.Name = "TXTPICK"
        Me.TXTPICK.Size = New System.Drawing.Size(70, 23)
        Me.TXTPICK.TabIndex = 5
        '
        'TXTCOUNT
        '
        Me.TXTCOUNT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOUNT.Location = New System.Drawing.Point(84, 125)
        Me.TXTCOUNT.Name = "TXTCOUNT"
        Me.TXTCOUNT.Size = New System.Drawing.Size(70, 23)
        Me.TXTCOUNT.TabIndex = 6
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(216, 284)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTREED
        '
        Me.TXTREED.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREED.Location = New System.Drawing.Point(84, 97)
        Me.TXTREED.Name = "TXTREED"
        Me.TXTREED.Size = New System.Drawing.Size(70, 23)
        Me.TXTREED.TabIndex = 4
        '
        'cmbQuality
        '
        Me.cmbQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbQuality.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbQuality.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbQuality.FormattingEnabled = True
        Me.cmbQuality.Location = New System.Drawing.Point(84, 12)
        Me.cmbQuality.MaxDropDownItems = 14
        Me.cmbQuality.Name = "cmbQuality"
        Me.cmbQuality.Size = New System.Drawing.Size(212, 23)
        Me.cmbQuality.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(184, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 355
        Me.Label8.Text = "Width"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Quality"
        '
        'LBLCOUNT
        '
        Me.LBLCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOUNT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOUNT.Location = New System.Drawing.Point(12, 129)
        Me.LBLCOUNT.Name = "LBLCOUNT"
        Me.LBLCOUNT.Size = New System.Drawing.Size(70, 14)
        Me.LBLCOUNT.TabIndex = 354
        Me.LBLCOUNT.Text = "Count"
        Me.LBLCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(186, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 15)
        Me.Label15.TabIndex = 340
        Me.Label15.Text = "Unit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(196, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 15)
        Me.Label6.TabIndex = 353
        Me.Label6.Text = "Pick"
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(221, 40)
        Me.cmbunit.MaxDropDownItems = 14
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(75, 23)
        Me.cmbunit.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "Reed"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(44, 284)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 12
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 351
        Me.Label4.Text = "Item Group"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(130, 284)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 13
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.DropDownWidth = 400
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(84, 68)
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(212, 23)
        Me.cmbitemname.TabIndex = 3
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(84, 153)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(212, 42)
        Me.txtremarks.TabIndex = 8
        '
        'cmbprocessname
        '
        Me.cmbprocessname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocessname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocessname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocessname.FormattingEnabled = True
        Me.cmbprocessname.Location = New System.Drawing.Point(84, 40)
        Me.cmbprocessname.MaxDropDownItems = 14
        Me.cmbprocessname.Name = "cmbprocessname"
        Me.cmbprocessname.Size = New System.Drawing.Size(70, 23)
        Me.cmbprocessname.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 349
        Me.Label1.Text = "Weave"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 350
        Me.Label2.Text = "Ini. Process"
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'QualityMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(322, 335)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "QualityMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Quality Master"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbprocessname As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents TXTWIDTH As System.Windows.Forms.TextBox
    Friend WithEvents TXTPICK As System.Windows.Forms.TextBox
    Friend WithEvents TXTCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTREED As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLCOUNT As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTWARP As TextBox
    Friend WithEvents TXTWEFT As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTSELVEDGE As TextBox
End Class
