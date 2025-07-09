<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewImage
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
        Me.pbsoftcopy = New System.Windows.Forms.PictureBox
        CType(Me.pbsoftcopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbsoftcopy
        '
        Me.pbsoftcopy.BackColor = System.Drawing.Color.Transparent
        Me.pbsoftcopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbsoftcopy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbsoftcopy.ErrorImage = Nothing
        Me.pbsoftcopy.InitialImage = Nothing
        Me.pbsoftcopy.Location = New System.Drawing.Point(0, 0)
        Me.pbsoftcopy.Name = "pbsoftcopy"
        Me.pbsoftcopy.Size = New System.Drawing.Size(794, 728)
        Me.pbsoftcopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbsoftcopy.TabIndex = 417
        Me.pbsoftcopy.TabStop = False
        '
        'ViewImage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(794, 728)
        Me.Controls.Add(Me.pbsoftcopy)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "ViewImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image"
        CType(Me.pbsoftcopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbsoftcopy As System.Windows.Forms.PictureBox
End Class
