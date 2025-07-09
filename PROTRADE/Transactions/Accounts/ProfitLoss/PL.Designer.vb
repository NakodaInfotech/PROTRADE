<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PL))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKLEDGER = New System.Windows.Forms.CheckBox()
        Me.chkcondensed = New System.Windows.Forms.CheckBox()
        Me.chkdetails = New System.Windows.Forms.CheckBox()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gridincome = New System.Windows.Forms.DataGridView()
        Me.GINCNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GINCDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GINCCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridexpenses = New System.Windows.Forms.DataGridView()
        Me.GEXPNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXPDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXPCR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridincome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridexpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKLEDGER)
        Me.BlendPanel1.Controls.Add(Me.chkcondensed)
        Me.BlendPanel1.Controls.Add(Me.chkdetails)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(984, 582)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKLEDGER
        '
        Me.CHKLEDGER.AutoSize = True
        Me.CHKLEDGER.BackColor = System.Drawing.Color.Transparent
        Me.CHKLEDGER.Checked = True
        Me.CHKLEDGER.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKLEDGER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLEDGER.Location = New System.Drawing.Point(650, 50)
        Me.CHKLEDGER.Name = "CHKLEDGER"
        Me.CHKLEDGER.Size = New System.Drawing.Size(96, 18)
        Me.CHKLEDGER.TabIndex = 465
        Me.CHKLEDGER.Text = "Ledger Details"
        Me.CHKLEDGER.UseVisualStyleBackColor = False
        '
        'chkcondensed
        '
        Me.chkcondensed.AutoSize = True
        Me.chkcondensed.BackColor = System.Drawing.Color.Transparent
        Me.chkcondensed.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkcondensed.Location = New System.Drawing.Point(545, 30)
        Me.chkcondensed.Name = "chkcondensed"
        Me.chkcondensed.Size = New System.Drawing.Size(79, 18)
        Me.chkcondensed.TabIndex = 464
        Me.chkcondensed.Text = "Condensed"
        Me.chkcondensed.UseVisualStyleBackColor = False
        Me.chkcondensed.Visible = False
        '
        'chkdetails
        '
        Me.chkdetails.AutoSize = True
        Me.chkdetails.BackColor = System.Drawing.Color.Transparent
        Me.chkdetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdetails.Location = New System.Drawing.Point(545, 50)
        Me.chkdetails.Name = "chkdetails"
        Me.chkdetails.Size = New System.Drawing.Size(60, 18)
        Me.chkdetails.TabIndex = 463
        Me.chkdetails.Text = "Details"
        Me.chkdetails.UseVisualStyleBackColor = False
        Me.chkdetails.Visible = False
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.Black
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(429, 33)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(93, 28)
        Me.CMDSHOWDETAILS.TabIndex = 461
        Me.CMDSHOWDETAILS.Text = "&Show Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(334, 54)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 460
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(310, 57)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(18, 14)
        Me.lblto.TabIndex = 462
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(333, 30)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 459
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(246, 32)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 457
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(295, 33)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(33, 14)
        Me.lblfrom.TabIndex = 458
        Me.lblfrom.Text = "From"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(456, 554)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 456
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip1.TabIndex = 288
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(17, 61)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(950, 489)
        Me.TabControl1.TabIndex = 286
        Me.TabControl1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridincome)
        Me.TabPage2.Controls.Add(Me.gridexpenses)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(942, 461)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Detailed"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gridincome
        '
        Me.gridincome.AllowUserToDeleteRows = False
        Me.gridincome.AllowUserToResizeColumns = False
        Me.gridincome.AllowUserToResizeRows = False
        Me.gridincome.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridincome.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridincome.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridincome.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridincome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridincome.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GINCNAME, Me.GINCDR, Me.GINCCR})
        Me.gridincome.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridincome.GridColor = System.Drawing.SystemColors.Control
        Me.gridincome.Location = New System.Drawing.Point(455, 22)
        Me.gridincome.MultiSelect = False
        Me.gridincome.Name = "gridincome"
        Me.gridincome.RowHeadersVisible = False
        Me.gridincome.RowHeadersWidth = 20
        Me.gridincome.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.gridincome.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridincome.RowTemplate.Height = 16
        Me.gridincome.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridincome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridincome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridincome.Size = New System.Drawing.Size(482, 438)
        Me.gridincome.TabIndex = 156
        '
        'GINCNAME
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.GINCNAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.GINCNAME.HeaderText = "Particulars"
        Me.GINCNAME.Name = "GINCNAME"
        Me.GINCNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GINCNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GINCNAME.Width = 250
        '
        'GINCDR
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Format = "N2"
        Me.GINCDR.DefaultCellStyle = DataGridViewCellStyle3
        Me.GINCDR.HeaderText = ""
        Me.GINCDR.Name = "GINCDR"
        Me.GINCDR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GINCCR
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "N2"
        Me.GINCCR.DefaultCellStyle = DataGridViewCellStyle4
        Me.GINCCR.HeaderText = ""
        Me.GINCCR.Name = "GINCCR"
        '
        'gridexpenses
        '
        Me.gridexpenses.AllowUserToDeleteRows = False
        Me.gridexpenses.AllowUserToResizeColumns = False
        Me.gridexpenses.AllowUserToResizeRows = False
        Me.gridexpenses.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.gridexpenses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridexpenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridexpenses.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridexpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridexpenses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GEXPNAME, Me.GEXPDR, Me.GEXPCR})
        Me.gridexpenses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridexpenses.GridColor = System.Drawing.SystemColors.Control
        Me.gridexpenses.Location = New System.Drawing.Point(4, 22)
        Me.gridexpenses.MultiSelect = False
        Me.gridexpenses.Name = "gridexpenses"
        Me.gridexpenses.RowHeadersVisible = False
        Me.gridexpenses.RowHeadersWidth = 20
        Me.gridexpenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        Me.gridexpenses.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridexpenses.RowTemplate.Height = 16
        Me.gridexpenses.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridexpenses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridexpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridexpenses.Size = New System.Drawing.Size(484, 438)
        Me.gridexpenses.TabIndex = 0
        '
        'GEXPNAME
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GEXPNAME.DefaultCellStyle = DataGridViewCellStyle7
        Me.GEXPNAME.HeaderText = "Particulars"
        Me.GEXPNAME.Name = "GEXPNAME"
        Me.GEXPNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GEXPNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GEXPNAME.Width = 250
        '
        'GEXPDR
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.Format = "N2"
        Me.GEXPDR.DefaultCellStyle = DataGridViewCellStyle8
        Me.GEXPDR.HeaderText = ""
        Me.GEXPDR.Name = "GEXPDR"
        Me.GEXPDR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GEXPCR
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.Format = "N2"
        Me.GEXPCR.DefaultCellStyle = DataGridViewCellStyle9
        Me.GEXPCR.HeaderText = ""
        Me.GEXPCR.Name = "GEXPCR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(452, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "Income"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "Expenses"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(3, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(126, 24)
        Me.Label13.TabIndex = 287
        Me.Label13.Text = "Profit && Loss"
        '
        'PL
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(984, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Profit & Loss"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.gridincome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridexpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKLEDGER As System.Windows.Forms.CheckBox
    Friend WithEvents chkcondensed As System.Windows.Forms.CheckBox
    Friend WithEvents chkdetails As System.Windows.Forms.CheckBox
    Friend WithEvents CMDSHOWDETAILS As System.Windows.Forms.Button
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents gridincome As System.Windows.Forms.DataGridView
    Friend WithEvents gridexpenses As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GINCNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GINCDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GINCCR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEXPNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEXPDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEXPCR As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
