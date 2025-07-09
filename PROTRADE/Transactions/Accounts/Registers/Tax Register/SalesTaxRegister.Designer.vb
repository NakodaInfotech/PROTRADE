<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesTaxRegister
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesTaxRegister))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.lblregister = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.groupdate = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.gridregister = New System.Windows.Forms.DataGridView()
        Me.lbl = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.BlendPanel1.SuspendLayout()
        Me.groupdate.SuspendLayout()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.lblregister)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.groupdate)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.gridregister)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.ShapeContainer1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(702, 449)
        Me.BlendPanel1.TabIndex = 0
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(282, 49)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(141, 22)
        Me.cmbregister.TabIndex = 335
        Me.cmbregister.Visible = False
        '
        'lblregister
        '
        Me.lblregister.AutoSize = True
        Me.lblregister.BackColor = System.Drawing.Color.Transparent
        Me.lblregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblregister.Location = New System.Drawing.Point(228, 53)
        Me.lblregister.Name = "lblregister"
        Me.lblregister.Size = New System.Drawing.Size(52, 14)
        Me.lblregister.TabIndex = 337
        Me.lblregister.Text = "Register"
        Me.lblregister.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(443, 34)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 336
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        Me.chkdate.Visible = False
        '
        'groupdate
        '
        Me.groupdate.BackColor = System.Drawing.Color.Transparent
        Me.groupdate.Controls.Add(Me.dtto)
        Me.groupdate.Controls.Add(Me.Label1)
        Me.groupdate.Controls.Add(Me.dtfrom)
        Me.groupdate.Controls.Add(Me.Label6)
        Me.groupdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupdate.Location = New System.Drawing.Point(429, 35)
        Me.groupdate.Name = "groupdate"
        Me.groupdate.Size = New System.Drawing.Size(248, 45)
        Me.groupdate.TabIndex = 334
        Me.groupdate.TabStop = False
        Me.groupdate.Visible = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Enabled = False
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(158, 19)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(134, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Enabled = False
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(42, 19)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(7, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(361, 411)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 330
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(268, 411)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(87, 28)
        Me.cmdshowdetails.TabIndex = 329
        Me.cmdshowdetails.Text = "&Show Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'gridregister
        '
        Me.gridregister.AllowUserToAddRows = False
        Me.gridregister.AllowUserToDeleteRows = False
        Me.gridregister.AllowUserToResizeColumns = False
        Me.gridregister.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridregister.BackgroundColor = System.Drawing.Color.White
        Me.gridregister.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridregister.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridregister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridregister.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridregister.GridColor = System.Drawing.SystemColors.Control
        Me.gridregister.Location = New System.Drawing.Point(19, 89)
        Me.gridregister.Margin = New System.Windows.Forms.Padding(2)
        Me.gridregister.MultiSelect = False
        Me.gridregister.Name = "gridregister"
        Me.gridregister.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridregister.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridregister.RowHeadersVisible = False
        Me.gridregister.RowHeadersWidth = 30
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.gridregister.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridregister.RowTemplate.Height = 20
        Me.gridregister.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.gridregister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridregister.Size = New System.Drawing.Size(658, 301)
        Me.gridregister.TabIndex = 328
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(14, 43)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(185, 24)
        Me.lbl.TabIndex = 327
        Me.lbl.Text = "Sales Tax Register"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(702, 25)
        Me.ToolStrip1.TabIndex = 326
        Me.ToolStrip1.Text = "v"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1, Me.LineShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(702, 449)
        Me.ShapeContainer1.TabIndex = 6
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Gray
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 18
        Me.LineShape1.X2 = 683
        Me.LineShape1.Y1 = 401
        Me.LineShape1.Y2 = 401
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Gray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 18
        Me.LineShape2.X2 = 683
        Me.LineShape2.Y1 = 404
        Me.LineShape2.Y2 = 404
        '
        'SalesTaxRegister
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(702, 449)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "SalesTaxRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sales Tax Register"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.groupdate.ResumeLayout(False)
        Me.groupdate.PerformLayout()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents gridregister As System.Windows.Forms.DataGridView
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents lblregister As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents groupdate As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
