<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Taxmaster
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
        Me.components = New System.ComponentModel.Container()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.RBGST = New System.Windows.Forms.RadioButton()
        Me.RBOTHER = New System.Windows.Forms.RadioButton()
        Me.RBCST = New System.Windows.Forms.RadioButton()
        Me.RBVAT = New System.Windows.Forms.RadioButton()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txttax = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblgroup
        '
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(8, 13)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(79, 22)
        Me.lblgroup.TabIndex = 149
        Me.lblgroup.Text = "Tax Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(292, 56)
        Me.txtremarks.TabIndex = 0
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(90, 13)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(99, 22)
        Me.txtname.TabIndex = 0
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(15, 92)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(305, 82)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(192, 15)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(153, 32)
        Me.lbl.TabIndex = 150
        Me.lbl.Text = "e.g. C.S.T. ,V.A.T. , ect.  "
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RBGST)
        Me.BlendPanel1.Controls.Add(Me.RBOTHER)
        Me.BlendPanel1.Controls.Add(Me.RBCST)
        Me.BlendPanel1.Controls.Add(Me.RBVAT)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txttax)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.txtname)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(419, 212)
        Me.BlendPanel1.TabIndex = 0
        '
        'RBGST
        '
        Me.RBGST.AutoSize = True
        Me.RBGST.BackColor = System.Drawing.Color.Transparent
        Me.RBGST.Checked = True
        Me.RBGST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBGST.Location = New System.Drawing.Point(204, 72)
        Me.RBGST.Name = "RBGST"
        Me.RBGST.Size = New System.Drawing.Size(52, 19)
        Me.RBGST.TabIndex = 319
        Me.RBGST.TabStop = True
        Me.RBGST.Text = "G.S.T."
        Me.RBGST.UseVisualStyleBackColor = False
        '
        'RBOTHER
        '
        Me.RBOTHER.AutoSize = True
        Me.RBOTHER.BackColor = System.Drawing.Color.Transparent
        Me.RBOTHER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBOTHER.Location = New System.Drawing.Point(264, 72)
        Me.RBOTHER.Name = "RBOTHER"
        Me.RBOTHER.Size = New System.Drawing.Size(56, 19)
        Me.RBOTHER.TabIndex = 318
        Me.RBOTHER.Text = "Other"
        Me.RBOTHER.UseVisualStyleBackColor = False
        '
        'RBCST
        '
        Me.RBCST.AutoSize = True
        Me.RBCST.BackColor = System.Drawing.Color.Transparent
        Me.RBCST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCST.Location = New System.Drawing.Point(147, 72)
        Me.RBCST.Name = "RBCST"
        Me.RBCST.Size = New System.Drawing.Size(51, 19)
        Me.RBCST.TabIndex = 317
        Me.RBCST.Text = "C.S.T."
        Me.RBCST.UseVisualStyleBackColor = False
        '
        'RBVAT
        '
        Me.RBVAT.AutoSize = True
        Me.RBVAT.BackColor = System.Drawing.Color.Transparent
        Me.RBVAT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBVAT.Location = New System.Drawing.Point(90, 72)
        Me.RBVAT.Name = "RBVAT"
        Me.RBVAT.Size = New System.Drawing.Size(51, 19)
        Me.RBVAT.TabIndex = 316
        Me.RBVAT.Text = "V.A.T."
        Me.RBVAT.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(336, 42)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 312
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(192, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 22)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "%"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txttax
        '
        Me.txttax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttax.Location = New System.Drawing.Point(90, 44)
        Me.txttax.Name = "txttax"
        Me.txttax.Size = New System.Drawing.Size(99, 22)
        Me.txttax.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(369, 34)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "Used to Calculate Tax at a specific rate that You pay to a Tax agency"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 22)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "Tax "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(337, 14)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(335, 71)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Taxmaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(419, 212)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "Taxmaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax Master"
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txttax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents RBOTHER As System.Windows.Forms.RadioButton
    Friend WithEvents RBCST As System.Windows.Forms.RadioButton
    Friend WithEvents RBVAT As System.Windows.Forms.RadioButton
    Friend WithEvents RBGST As System.Windows.Forms.RadioButton
End Class
