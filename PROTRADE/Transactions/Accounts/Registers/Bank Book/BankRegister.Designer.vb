<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankRegister
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankRegister))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox
        Me.cmbbank = New System.Windows.Forms.ComboBox
        Me.lblopdrcr = New System.Windows.Forms.Label
        Me.txtopening = New System.Windows.Forms.TextBox
        Me.lblopbal = New System.Windows.Forms.Label
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.lblname = New System.Windows.Forms.Label
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.chkreco = New System.Windows.Forms.CheckBox
        Me.txtdr = New System.Windows.Forms.TextBox
        Me.txtcr = New System.Windows.Forms.TextBox
        Me.gridregister = New System.Windows.Forms.DataGridView
        Me.gridmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.griddebit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.runningtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.lbln = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.txtclosing = New System.Windows.Forms.TextBox
        Me.groupdate = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.lbldrcr = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.groupdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.cmbbank)
        Me.BlendPanel1.Controls.Add(Me.lblopdrcr)
        Me.BlendPanel1.Controls.Add(Me.txtopening)
        Me.BlendPanel1.Controls.Add(Me.lblopbal)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.chkreco)
        Me.BlendPanel1.Controls.Add(Me.txtdr)
        Me.BlendPanel1.Controls.Add(Me.txtcr)
        Me.BlendPanel1.Controls.Add(Me.gridregister)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbln)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.txtclosing)
        Me.BlendPanel1.Controls.Add(Me.groupdate)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.lbldrcr)
        Me.BlendPanel1.Controls.Add(Me.ShapeContainer1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(709, 450)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(197, 31)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBACCCODE.TabIndex = 483
        Me.CMBACCCODE.Visible = False
        '
        'cmbbank
        '
        Me.cmbbank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbbank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbbank.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbank.FormattingEnabled = True
        Me.cmbbank.Location = New System.Drawing.Point(77, 71)
        Me.cmbbank.MaxDropDownItems = 14
        Me.cmbbank.Name = "cmbbank"
        Me.cmbbank.Size = New System.Drawing.Size(209, 22)
        Me.cmbbank.TabIndex = 0
        '
        'lblopdrcr
        '
        Me.lblopdrcr.AutoSize = True
        Me.lblopdrcr.BackColor = System.Drawing.Color.Transparent
        Me.lblopdrcr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopdrcr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopdrcr.Location = New System.Drawing.Point(670, 76)
        Me.lblopdrcr.Name = "lblopdrcr"
        Me.lblopdrcr.Size = New System.Drawing.Size(0, 14)
        Me.lblopdrcr.TabIndex = 443
        '
        'txtopening
        '
        Me.txtopening.BackColor = System.Drawing.Color.White
        Me.txtopening.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopening.ForeColor = System.Drawing.Color.Black
        Me.txtopening.Location = New System.Drawing.Point(597, 72)
        Me.txtopening.Name = "txtopening"
        Me.txtopening.ReadOnly = True
        Me.txtopening.Size = New System.Drawing.Size(71, 22)
        Me.txtopening.TabIndex = 441
        Me.txtopening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblopbal
        '
        Me.lblopbal.AutoSize = True
        Me.lblopbal.BackColor = System.Drawing.Color.Transparent
        Me.lblopbal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopbal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopbal.Location = New System.Drawing.Point(547, 75)
        Me.lblopbal.Name = "lblopbal"
        Me.lblopbal.Size = New System.Drawing.Size(47, 14)
        Me.lblopbal.TabIndex = 440
        Me.lblopbal.Text = "O/P Bal"
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(157, 24)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(34, 31)
        Me.txtadd.TabIndex = 432
        Me.txtadd.TabStop = False
        Me.txtadd.Visible = False
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(7, 75)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(69, 14)
        Me.lblname.TabIndex = 431
        Me.lblname.Text = "Bank Name"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(361, 414)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
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
        Me.cmdshowdetails.Location = New System.Drawing.Point(267, 414)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 5
        Me.cmdshowdetails.Text = "&Show Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'chkreco
        '
        Me.chkreco.AutoSize = True
        Me.chkreco.BackColor = System.Drawing.Color.Transparent
        Me.chkreco.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkreco.Location = New System.Drawing.Point(597, 47)
        Me.chkreco.Name = "chkreco"
        Me.chkreco.Size = New System.Drawing.Size(79, 18)
        Me.chkreco.TabIndex = 3
        Me.chkreco.Text = "Reconcile"
        Me.chkreco.UseVisualStyleBackColor = False
        '
        'txtdr
        '
        Me.txtdr.BackColor = System.Drawing.Color.White
        Me.txtdr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdr.ForeColor = System.Drawing.Color.Black
        Me.txtdr.Location = New System.Drawing.Point(350, 378)
        Me.txtdr.Name = "txtdr"
        Me.txtdr.ReadOnly = True
        Me.txtdr.Size = New System.Drawing.Size(100, 22)
        Me.txtdr.TabIndex = 327
        Me.txtdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcr
        '
        Me.txtcr.BackColor = System.Drawing.Color.White
        Me.txtcr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcr.ForeColor = System.Drawing.Color.Black
        Me.txtcr.Location = New System.Drawing.Point(450, 378)
        Me.txtcr.Name = "txtcr"
        Me.txtcr.ReadOnly = True
        Me.txtcr.Size = New System.Drawing.Size(100, 22)
        Me.txtcr.TabIndex = 326
        Me.txtcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridregister
        '
        Me.gridregister.AllowUserToAddRows = False
        Me.gridregister.AllowUserToDeleteRows = False
        Me.gridregister.AllowUserToResizeColumns = False
        Me.gridregister.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridregister.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridregister.BackgroundColor = System.Drawing.Color.White
        Me.gridregister.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridregister.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridregister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridregister.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gridmonth, Me.griddebit, Me.cr, Me.runningtotal})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridregister.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridregister.GridColor = System.Drawing.SystemColors.Control
        Me.gridregister.Location = New System.Drawing.Point(25, 101)
        Me.gridregister.Margin = New System.Windows.Forms.Padding(2)
        Me.gridregister.MultiSelect = False
        Me.gridregister.Name = "gridregister"
        Me.gridregister.ReadOnly = True
        Me.gridregister.RowHeadersVisible = False
        Me.gridregister.RowHeadersWidth = 30
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.gridregister.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridregister.RowTemplate.Height = 20
        Me.gridregister.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridregister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridregister.Size = New System.Drawing.Size(658, 273)
        Me.gridregister.TabIndex = 4
        '
        'gridmonth
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gridmonth.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridmonth.HeaderText = "Month"
        Me.gridmonth.Name = "gridmonth"
        Me.gridmonth.ReadOnly = True
        Me.gridmonth.Width = 300
        '
        'griddebit
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.griddebit.DefaultCellStyle = DataGridViewCellStyle4
        Me.griddebit.HeaderText = "Debit"
        Me.griddebit.Name = "griddebit"
        Me.griddebit.ReadOnly = True
        Me.griddebit.Width = 110
        '
        'cr
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cr.DefaultCellStyle = DataGridViewCellStyle5
        Me.cr.HeaderText = "Credit"
        Me.cr.Name = "cr"
        Me.cr.ReadOnly = True
        Me.cr.Width = 110
        '
        'runningtotal
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.runningtotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.runningtotal.HeaderText = "Closing Bal"
        Me.runningtotal.Name = "runningtotal"
        Me.runningtotal.ReadOnly = True
        Me.runningtotal.Width = 110
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(709, 25)
        Me.ToolStrip1.TabIndex = 325
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
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(279, 381)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(70, 14)
        Me.lbln.TabIndex = 317
        Me.lbln.Text = "Grand Total"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(305, 47)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 1
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'txtclosing
        '
        Me.txtclosing.BackColor = System.Drawing.Color.White
        Me.txtclosing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclosing.ForeColor = System.Drawing.Color.Black
        Me.txtclosing.Location = New System.Drawing.Point(550, 378)
        Me.txtclosing.Name = "txtclosing"
        Me.txtclosing.ReadOnly = True
        Me.txtclosing.Size = New System.Drawing.Size(100, 22)
        Me.txtclosing.TabIndex = 316
        Me.txtclosing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'groupdate
        '
        Me.groupdate.BackColor = System.Drawing.Color.Transparent
        Me.groupdate.Controls.Add(Me.dtto)
        Me.groupdate.Controls.Add(Me.Label1)
        Me.groupdate.Controls.Add(Me.dtfrom)
        Me.groupdate.Controls.Add(Me.Label6)
        Me.groupdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupdate.Location = New System.Drawing.Point(298, 50)
        Me.groupdate.Name = "groupdate"
        Me.groupdate.Size = New System.Drawing.Size(242, 45)
        Me.groupdate.TabIndex = 2
        Me.groupdate.TabStop = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Enabled = False
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(150, 19)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(86, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(126, 22)
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
        Me.dtfrom.Location = New System.Drawing.Point(38, 19)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(86, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 31)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(140, 22)
        Me.lbl.TabIndex = 318
        Me.lbl.Text = "Bank Register"
        '
        'lbldrcr
        '
        Me.lbldrcr.AutoSize = True
        Me.lbldrcr.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcr.Location = New System.Drawing.Point(653, 381)
        Me.lbldrcr.Name = "lbldrcr"
        Me.lbldrcr.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcr.TabIndex = 330
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(709, 450)
        Me.ShapeContainer1.TabIndex = 335
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Gray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 24
        Me.LineShape2.X2 = 684
        Me.LineShape2.Y1 = 406
        Me.LineShape2.Y2 = 406
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Gray
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 24
        Me.LineShape1.X2 = 684
        Me.LineShape1.Y1 = 403
        Me.LineShape1.Y2 = 403
        '
        'BankRegister
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(709, 450)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BankRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bank Register"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.groupdate.ResumeLayout(False)
        Me.groupdate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents chkreco As System.Windows.Forms.CheckBox
    Friend WithEvents txtdr As System.Windows.Forms.TextBox
    Friend WithEvents txtcr As System.Windows.Forms.TextBox
    Friend WithEvents gridregister As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbln As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents txtclosing As System.Windows.Forms.TextBox
    Friend WithEvents groupdate As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lbldrcr As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents cmbbank As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents txtopening As System.Windows.Forms.TextBox
    Friend WithEvents lblopbal As System.Windows.Forms.Label
    Friend WithEvents lblopdrcr As System.Windows.Forms.Label
    Friend WithEvents gridmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents griddebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents runningtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
End Class
