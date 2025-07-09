<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TermsAndConditions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LBLMODEOFSHIPMENT = New System.Windows.Forms.Label()
        Me.LBLSONO = New System.Windows.Forms.Label()
        Me.lblpartyname = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLMODEOFSHIPMENT
        '
        Me.LBLMODEOFSHIPMENT.AutoSize = True
        Me.LBLMODEOFSHIPMENT.BackColor = System.Drawing.Color.Transparent
        Me.LBLMODEOFSHIPMENT.Location = New System.Drawing.Point(-127, 89)
        Me.LBLMODEOFSHIPMENT.Name = "LBLMODEOFSHIPMENT"
        Me.LBLMODEOFSHIPMENT.Size = New System.Drawing.Size(108, 15)
        Me.LBLMODEOFSHIPMENT.TabIndex = 749
        Me.LBLMODEOFSHIPMENT.Text = "Mode Of Shipment"
        '
        'LBLSONO
        '
        Me.LBLSONO.AutoSize = True
        Me.LBLSONO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSONO.Location = New System.Drawing.Point(-57, 60)
        Me.LBLSONO.Name = "LBLSONO"
        Me.LBLSONO.Size = New System.Drawing.Size(38, 15)
        Me.LBLSONO.TabIndex = 743
        Me.LBLSONO.Text = "So No"
        '
        'lblpartyname
        '
        Me.lblpartyname.AutoSize = True
        Me.lblpartyname.BackColor = System.Drawing.Color.Transparent
        Me.lblpartyname.Location = New System.Drawing.Point(-89, 31)
        Me.lblpartyname.Name = "lblpartyname"
        Me.lblpartyname.Size = New System.Drawing.Size(70, 15)
        Me.lblpartyname.TabIndex = 740
        Me.lblpartyname.Text = "Party Name"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(462, 272)
        Me.BlendPanel1.TabIndex = 750
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.Location = New System.Drawing.Point(150, 224)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 4
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(236, 224)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 5
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(64, 224)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(435, 199)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Terms And Conditions"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(422, 176)
        Me.txtremarks.TabIndex = 0
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(322, 224)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TermsAndConditions
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(462, 272)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.LBLMODEOFSHIPMENT)
        Me.Controls.Add(Me.LBLSONO)
        Me.Controls.Add(Me.lblpartyname)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TermsAndConditions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Terms And Conditions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLMODEOFSHIPMENT As Label
    Friend WithEvents LBLSONO As Label
    Friend WithEvents lblpartyname As Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents cmdexit As Button
End Class
