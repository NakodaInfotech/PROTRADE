<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class summarydesign
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
        Me.CRPO = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRPO
        '
        Me.CRPO.ActiveViewIndex = -1
        Me.CRPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPO.DisplayGroupTree = False
        Me.CRPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRPO.EnableDrillDown = False
        Me.CRPO.Location = New System.Drawing.Point(0, 0)
        Me.CRPO.Name = "CRPO"
        Me.CRPO.SelectionFormula = ""
        Me.CRPO.Size = New System.Drawing.Size(292, 266)
        Me.CRPO.TabIndex = 208
        Me.CRPO.ViewTimeSelectionFormula = ""
        '
        'summarydesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.CRPO)
        Me.Name = "summarydesign"
        Me.Text = "summarydesign"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRPO As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
