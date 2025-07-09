<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MergeParameter
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbReplace = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOldName = New System.Windows.Forms.ComboBox()
        Me.lblvendorname = New System.Windows.Forms.Label()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Button1)
        Me.BlendPanel1.Controls.Add(Me.Button2)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbReplace)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbOldName)
        Me.BlendPanel1.Controls.Add(Me.lblvendorname)
        Me.BlendPanel1.Controls.Add(Me.lblheading)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(353, 176)
        Me.BlendPanel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(93, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 28)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(179, 134)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 28)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "E&xit"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"MERCHANT", "ITEM NAME", "PIECETYPE", "COLOR", "AREA", "CATEGORY", "CITY", "COUNTRY", "DEPARTMENT", "DESIGN", "QUALITY", "STATE", "UNIT", "GODOWN", "CONTRACTOR", "PROCESS", "TAX", "DESIGNATION", "EMPLOYEE", "PARTYBANK", "GROUP", "GROUPOFCOMPANY", "PACKINGTYPE", "TERM", "SALESMAN", "CURRENCY", "RACK", "SHELF", "MACHINE", "YARN MERCHANT"})
        Me.cmbtype.Location = New System.Drawing.Point(93, 46)
        Me.cmbtype.MaxDropDownItems = 14
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(199, 23)
        Me.cmbtype.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(60, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 423
        Me.Label2.Text = "Type"
        '
        'cmbReplace
        '
        Me.cmbReplace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbReplace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbReplace.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbReplace.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReplace.FormattingEnabled = True
        Me.cmbReplace.Location = New System.Drawing.Point(93, 102)
        Me.cmbReplace.MaxDropDownItems = 14
        Me.cmbReplace.Name = "cmbReplace"
        Me.cmbReplace.Size = New System.Drawing.Size(199, 23)
        Me.cmbReplace.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "Replace With "
        '
        'cmbOldName
        '
        Me.cmbOldName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOldName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOldName.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbOldName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOldName.FormattingEnabled = True
        Me.cmbOldName.Location = New System.Drawing.Point(93, 74)
        Me.cmbOldName.MaxDropDownItems = 14
        Me.cmbOldName.Name = "cmbOldName"
        Me.cmbOldName.Size = New System.Drawing.Size(199, 23)
        Me.cmbOldName.TabIndex = 1
        '
        'lblvendorname
        '
        Me.lblvendorname.AutoSize = True
        Me.lblvendorname.BackColor = System.Drawing.Color.Transparent
        Me.lblvendorname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendorname.ForeColor = System.Drawing.Color.Black
        Me.lblvendorname.Location = New System.Drawing.Point(32, 78)
        Me.lblvendorname.Name = "lblvendorname"
        Me.lblvendorname.Size = New System.Drawing.Size(61, 15)
        Me.lblvendorname.TabIndex = 419
        Me.lblvendorname.Text = "Old Name"
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(127, 14)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(83, 29)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Merge "
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'MergeParameter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(353, 176)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MergeParameter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Merge Parameter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbReplace As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOldName As System.Windows.Forms.ComboBox
    Friend WithEvents lblvendorname As System.Windows.Forms.Label
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
End Class
