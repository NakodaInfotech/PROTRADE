<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalarySlipDesign
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.sendmailtool = New System.Windows.Forms.ToolStripButton
        Me.CRPO = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sendmailtool})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(284, 25)
        Me.ToolStrip1.TabIndex = 207
        Me.ToolStrip1.Text = "v"
        '
        'sendmailtool
        '
        Me.sendmailtool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sendmailtool.Image = Global.PROTRADE.My.Resources.Resources.email_initiator
        Me.sendmailtool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sendmailtool.Name = "sendmailtool"
        Me.sendmailtool.Size = New System.Drawing.Size(23, 22)
        Me.sendmailtool.Text = "Send E-Mail"
        '
        'CRPO
        '
        Me.CRPO.ActiveViewIndex = -1
        Me.CRPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPO.DisplayGroupTree = False
        Me.CRPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRPO.EnableDrillDown = False
        Me.CRPO.Location = New System.Drawing.Point(0, 25)
        Me.CRPO.Name = "CRPO"
        Me.CRPO.SelectionFormula = ""
        Me.CRPO.Size = New System.Drawing.Size(284, 257)
        Me.CRPO.TabIndex = 208
        Me.CRPO.ViewTimeSelectionFormula = ""
        '
        'SalarySlipDesign
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 282)
        Me.Controls.Add(Me.CRPO)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SalarySlipDesign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Salary Slip Design"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents sendmailtool As System.Windows.Forms.ToolStripButton
    Friend WithEvents CRPO As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
