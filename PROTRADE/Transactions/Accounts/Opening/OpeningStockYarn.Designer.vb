<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningStockYarn
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpeningStockYarn))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTCONES = New System.Windows.Forms.TextBox
        Me.LRDATE = New System.Windows.Forms.DateTimePicker
        Me.TXTLRNO = New System.Windows.Forms.TextBox
        Me.CMBSHADE = New System.Windows.Forms.ComboBox
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox
        Me.CMBMILL = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBTONAME = New System.Windows.Forms.ComboBox
        Me.TXTNO = New System.Windows.Forms.TextBox
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox
        Me.cmbdyeing = New System.Windows.Forms.ComboBox
        Me.TXTWT = New System.Windows.Forms.TextBox
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox
        Me.TXTLOTNO = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gridstock = New System.Windows.Forms.DataGridView
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GYARNQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMILL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSHADE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPROCESS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLRDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gtoname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GGODOWN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBAGS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GWT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCONES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMBYARNQUALITY = New System.Windows.Forms.ComboBox
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.TXTBAGS = New System.Windows.Forms.TextBox
        Me.txtsrno = New System.Windows.Forms.TextBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.cmbtype = New System.Windows.Forms.ComboBox
        Me.openingdate = New System.Windows.Forms.DateTimePicker
        Me.cmdexit = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridstock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTCONES)
        Me.BlendPanel1.Controls.Add(Me.LRDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTLRNO)
        Me.BlendPanel1.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Controls.Add(Me.CMBMILL)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBTONAME)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.cmbdyeing)
        Me.BlendPanel1.Controls.Add(Me.TXTWT)
        Me.BlendPanel1.Controls.Add(Me.CMBPROCESS)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.gridstock)
        Me.BlendPanel1.Controls.Add(Me.CMBYARNQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTBAGS)
        Me.BlendPanel1.Controls.Add(Me.txtsrno)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.openingdate)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 571)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTCONES
        '
        Me.TXTCONES.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCONES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCONES.Location = New System.Drawing.Point(1089, 45)
        Me.TXTCONES.Name = "TXTCONES"
        Me.TXTCONES.Size = New System.Drawing.Size(60, 22)
        Me.TXTCONES.TabIndex = 10
        Me.TXTCONES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LRDATE
        '
        Me.LRDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LRDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.LRDATE.Location = New System.Drawing.Point(715, 12)
        Me.LRDATE.Name = "LRDATE"
        Me.LRDATE.Size = New System.Drawing.Size(80, 22)
        Me.LRDATE.TabIndex = 6
        Me.LRDATE.Value = New Date(2013, 4, 1, 8, 54, 0, 0)
        Me.LRDATE.Visible = False
        '
        'TXTLRNO
        '
        Me.TXTLRNO.BackColor = System.Drawing.Color.White
        Me.TXTLRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLRNO.Location = New System.Drawing.Point(810, 12)
        Me.TXTLRNO.Name = "TXTLRNO"
        Me.TXTLRNO.Size = New System.Drawing.Size(80, 22)
        Me.TXTLRNO.TabIndex = 5
        Me.TXTLRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTLRNO.Visible = False
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.DropDownWidth = 400
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(509, 45)
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(80, 22)
        Me.CMBSHADE.TabIndex = 4
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.DropDownWidth = 400
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(429, 45)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(80, 22)
        Me.CMBDESIGN.TabIndex = 3
        '
        'CMBMILL
        '
        Me.CMBMILL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMILL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMILL.BackColor = System.Drawing.Color.White
        Me.CMBMILL.FormattingEnabled = True
        Me.CMBMILL.Location = New System.Drawing.Point(269, 45)
        Me.CMBMILL.Name = "CMBMILL"
        Me.CMBMILL.Size = New System.Drawing.Size(160, 22)
        Me.CMBMILL.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 507)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(625, 45)
        Me.Label1.TabIndex = 721
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'CMBTONAME
        '
        Me.CMBTONAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTONAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTONAME.DropDownWidth = 400
        Me.CMBTONAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTONAME.FormattingEnabled = True
        Me.CMBTONAME.Location = New System.Drawing.Point(689, 45)
        Me.CMBTONAME.Name = "CMBTONAME"
        Me.CMBTONAME.Size = New System.Drawing.Size(160, 22)
        Me.CMBTONAME.TabIndex = 6
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(289, 16)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTNO.TabIndex = 715
        Me.TXTNO.Text = " "
        Me.TXTNO.Visible = False
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBGODOWN.DropDownWidth = 400
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(849, 45)
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(120, 22)
        Me.CMBGODOWN.TabIndex = 7
        '
        'cmbdyeing
        '
        Me.cmbdyeing.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdyeing.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdyeing.FormattingEnabled = True
        Me.cmbdyeing.Location = New System.Drawing.Point(530, 12)
        Me.cmbdyeing.Name = "cmbdyeing"
        Me.cmbdyeing.Size = New System.Drawing.Size(80, 22)
        Me.cmbdyeing.TabIndex = 12
        Me.cmbdyeing.Visible = False
        '
        'TXTWT
        '
        Me.TXTWT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWT.Location = New System.Drawing.Point(1029, 45)
        Me.TXTWT.Name = "TXTWT"
        Me.TXTWT.Size = New System.Drawing.Size(60, 22)
        Me.TXTWT.TabIndex = 9
        Me.TXTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROCESS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROCESS.DropDownWidth = 400
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Location = New System.Drawing.Point(589, 45)
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(100, 22)
        Me.CMBPROCESS.TabIndex = 5
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.White
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(49, 45)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(60, 22)
        Me.TXTLOTNO.TabIndex = 0
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Date :"
        Me.Label6.Visible = False
        '
        'gridstock
        '
        Me.gridstock.AllowUserToAddRows = False
        Me.gridstock.AllowUserToDeleteRows = False
        Me.gridstock.AllowUserToResizeColumns = False
        Me.gridstock.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridstock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridstock.BackgroundColor = System.Drawing.Color.White
        Me.gridstock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridstock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridstock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridstock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GNO, Me.GLOTNO, Me.GYARNQUALITY, Me.GMILL, Me.GDESIGN, Me.GSHADE, Me.GPROCESS, Me.GLRNO, Me.GLRDATE, Me.gtoname, Me.GGODOWN, Me.GBAGS, Me.GWT, Me.GCONES})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridstock.DefaultCellStyle = DataGridViewCellStyle5
        Me.gridstock.GridColor = System.Drawing.SystemColors.Control
        Me.gridstock.Location = New System.Drawing.Point(9, 67)
        Me.gridstock.MultiSelect = False
        Me.gridstock.Name = "gridstock"
        Me.gridstock.ReadOnly = True
        Me.gridstock.RowHeadersVisible = False
        Me.gridstock.RowHeadersWidth = 30
        Me.gridstock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.gridstock.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridstock.RowTemplate.Height = 20
        Me.gridstock.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridstock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridstock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridstock.Size = New System.Drawing.Size(1166, 439)
        Me.gridstock.TabIndex = 11
        Me.gridstock.TabStop = False
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 40
        '
        'GNO
        '
        Me.GNO.HeaderText = "NO"
        Me.GNO.Name = "GNO"
        Me.GNO.ReadOnly = True
        Me.GNO.Visible = False
        '
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No."
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.ReadOnly = True
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOTNO.Width = 60
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.HeaderText = "Yarn Quality"
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.ReadOnly = True
        Me.GYARNQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GYARNQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GYARNQUALITY.Width = 160
        '
        'GMILL
        '
        Me.GMILL.HeaderText = "Mill Name"
        Me.GMILL.Name = "GMILL"
        Me.GMILL.ReadOnly = True
        Me.GMILL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMILL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMILL.Width = 160
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGN.Width = 80
        '
        'GSHADE
        '
        Me.GSHADE.HeaderText = "Shade"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.ReadOnly = True
        Me.GSHADE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHADE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSHADE.Width = 80
        '
        'GPROCESS
        '
        Me.GPROCESS.HeaderText = "Process"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.ReadOnly = True
        Me.GPROCESS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPROCESS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GLRNO
        '
        Me.GLRNO.HeaderText = "LR No"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.ReadOnly = True
        Me.GLRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLRNO.Visible = False
        Me.GLRNO.Width = 80
        '
        'GLRDATE
        '
        Me.GLRDATE.HeaderText = "LR Date"
        Me.GLRDATE.Name = "GLRDATE"
        Me.GLRDATE.ReadOnly = True
        Me.GLRDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLRDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLRDATE.Visible = False
        Me.GLRDATE.Width = 80
        '
        'gtoname
        '
        Me.gtoname.HeaderText = "Jobber Name"
        Me.gtoname.Name = "gtoname"
        Me.gtoname.ReadOnly = True
        Me.gtoname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gtoname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gtoname.Width = 160
        '
        'GGODOWN
        '
        Me.GGODOWN.HeaderText = "Godown"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.ReadOnly = True
        Me.GGODOWN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGODOWN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGODOWN.Width = 120
        '
        'GBAGS
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GBAGS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GBAGS.HeaderText = "Bags"
        Me.GBAGS.Name = "GBAGS"
        Me.GBAGS.ReadOnly = True
        Me.GBAGS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBAGS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBAGS.Width = 60
        '
        'GWT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWT.DefaultCellStyle = DataGridViewCellStyle4
        Me.GWT.HeaderText = "Wt"
        Me.GWT.Name = "GWT"
        Me.GWT.ReadOnly = True
        Me.GWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWT.Width = 60
        '
        'GCONES
        '
        Me.GCONES.HeaderText = "Cones"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.ReadOnly = True
        Me.GCONES.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCONES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCONES.Width = 60
        '
        'CMBYARNQUALITY
        '
        Me.CMBYARNQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBYARNQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBYARNQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBYARNQUALITY.DropDownWidth = 400
        Me.CMBYARNQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBYARNQUALITY.FormattingEnabled = True
        Me.CMBYARNQUALITY.Location = New System.Drawing.Point(109, 45)
        Me.CMBYARNQUALITY.Name = "CMBYARNQUALITY"
        Me.CMBYARNQUALITY.Size = New System.Drawing.Size(160, 22)
        Me.CMBYARNQUALITY.TabIndex = 1
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.DropDownWidth = 400
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(436, 16)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMBCODE.TabIndex = 20
        Me.CMBCODE.Visible = False
        '
        'TXTBAGS
        '
        Me.TXTBAGS.BackColor = System.Drawing.Color.White
        Me.TXTBAGS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBAGS.Location = New System.Drawing.Point(969, 45)
        Me.TXTBAGS.Name = "TXTBAGS"
        Me.TXTBAGS.Size = New System.Drawing.Size(60, 22)
        Me.TXTBAGS.TabIndex = 8
        Me.TXTBAGS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(9, 45)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(40, 22)
        Me.txtsrno.TabIndex = 0
        Me.txtsrno.TabStop = False
        Me.txtsrno.Text = " "
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtadd.Location = New System.Drawing.Point(636, 8)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(30, 22)
        Me.txtadd.TabIndex = 15
        Me.txtadd.Text = " "
        Me.txtadd.Visible = False
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.DropDownWidth = 400
        Me.cmbtype.Enabled = False
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"GODOWNSTOCKYARN", "JOBBERSTOCKYARN"})
        Me.cmbtype.Location = New System.Drawing.Point(150, 16)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(99, 23)
        Me.cmbtype.TabIndex = 1
        '
        'openingdate
        '
        Me.openingdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.openingdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.openingdate.Location = New System.Drawing.Point(55, 16)
        Me.openingdate.Name = "openingdate"
        Me.openingdate.Size = New System.Drawing.Size(88, 22)
        Me.openingdate.TabIndex = 0
        Me.openingdate.Value = New Date(2013, 4, 1, 8, 54, 0, 0)
        Me.openingdate.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(715, 530)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpeningStockYarn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 571)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningStockYarn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Stock Yarn"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridstock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents cmbdyeing As System.Windows.Forms.ComboBox
    Friend WithEvents CMBPROCESS As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBMILL As System.Windows.Forms.ComboBox
    Friend WithEvents CMBTONAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents TXTWT As System.Windows.Forms.TextBox
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents gridstock As System.Windows.Forms.DataGridView
    Friend WithEvents CMBYARNQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents TXTBAGS As System.Windows.Forms.TextBox
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents openingdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents LRDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTLRNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTCONES As System.Windows.Forms.TextBox
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GYARNQUALITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMILL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSHADE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPROCESS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLRDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gtoname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GGODOWN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBAGS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GWT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCONES As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
