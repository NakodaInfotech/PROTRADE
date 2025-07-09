<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GDNDESIGN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GDNDESIGN))
        Me.crpo = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.sendmailtool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'crpo
        '
        Me.crpo.ActiveViewIndex = -1
        Me.crpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crpo.Cursor = System.Windows.Forms.Cursors.Default
        Me.crpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crpo.EnableDrillDown = False
        Me.crpo.Location = New System.Drawing.Point(0, 25)
        Me.crpo.Name = "crpo"
        Me.crpo.SelectionFormula = ""
        Me.crpo.Size = New System.Drawing.Size(284, 237)
        Me.crpo.TabIndex = 208
        Me.crpo.ViewTimeSelectionFormula = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sendmailtool, Me.ToolStripSeparator1, Me.TOOLWHATSAPP, Me.ToolStripSeparator2, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(284, 25)
        Me.ToolStrip1.TabIndex = 207
        Me.ToolStrip1.Text = "v"
        '
        'sendmailtool
        '
        Me.sendmailtool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sendmailtool.Image = Global.PROTRADE.My.Resources.sendforms
        Me.sendmailtool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sendmailtool.Name = "sendmailtool"
        Me.sendmailtool.Size = New System.Drawing.Size(23, 22)
        Me.sendmailtool.Text = "Send E-Mail"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        Me.PrintToolStripButton.Visible = False
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(109, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 799
        Me.TXTCOPIES.Text = "2"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCOPIES.Visible = False
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.PROTRADE.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "&Whatsapp"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GDNDESIGN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.TXTCOPIES)
        Me.Controls.Add(Me.crpo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "GDNDESIGN"
        Me.Text = "GDNDESIGN"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crpo As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents sendmailtool As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TXTCOPIES As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
