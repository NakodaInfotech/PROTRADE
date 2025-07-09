<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChqEnteriesDesign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChqEnteriesDesign))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.sendmailtool = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.crpo = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.TXTCOPIES = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sendmailtool, Me.PrintToolStripButton, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(306, 25)
        Me.ToolStrip1.TabIndex = 214
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
        'crpo
        '
        Me.crpo.ActiveViewIndex = -1
        Me.crpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crpo.DisplayGroupTree = False
        Me.crpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crpo.EnableDrillDown = False
        Me.crpo.Location = New System.Drawing.Point(0, 25)
        Me.crpo.Name = "crpo"
        Me.crpo.SelectionFormula = ""
        Me.crpo.Size = New System.Drawing.Size(306, 273)
        Me.crpo.TabIndex = 215
        Me.crpo.ViewTimeSelectionFormula = ""
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(67, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 801
        Me.TXTCOPIES.Text = "2"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCOPIES.Visible = False
        '
        'ChqEnteriesDesign
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(306, 298)
        Me.Controls.Add(Me.TXTCOPIES)
        Me.Controls.Add(Me.crpo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ChqEnteriesDesign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Chq Enteries Design"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents sendmailtool As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents crpo As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TXTCOPIES As System.Windows.Forms.TextBox
End Class
