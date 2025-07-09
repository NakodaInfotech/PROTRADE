<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualMatching
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManualMatching))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.GRIDRECPAY = New System.Windows.Forms.DataGridView
        Me.DCHK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DBILLNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DREGID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DBILLINITIALS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DBILLAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DBALAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRIDMATCH = New System.Windows.Forms.DataGridView
        Me.GCHK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBILLNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREGID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBILLINITIALS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREFNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBILLAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBALAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPAIDAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTTOTALBAL = New System.Windows.Forms.TextBox
        Me.TXTTOTALPAY = New System.Windows.Forms.TextBox
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.cmdclear = New System.Windows.Forms.Button
        Me.CMDSAVE = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.TXTMATCHNO = New System.Windows.Forms.TextBox
        Me.lblsrno = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.MATCHDATE = New System.Windows.Forms.DateTimePicker
        Me.lbl = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDRECPAY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDMATCH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.toolStripSeparator, Me.toolprevious, Me.ToolStripSeparator2, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(824, 25)
        Me.ToolStrip1.TabIndex = 287
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
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
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "&Delete Journal"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.PROTRADE.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDRECPAY)
        Me.BlendPanel1.Controls.Add(Me.GRIDMATCH)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALBAL)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPAY)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label33)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.TXTMATCHNO)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.MATCHDATE)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(824, 536)
        Me.BlendPanel1.TabIndex = 0
        '
        'GRIDRECPAY
        '
        Me.GRIDRECPAY.AllowUserToAddRows = False
        Me.GRIDRECPAY.AllowUserToDeleteRows = False
        Me.GRIDRECPAY.AllowUserToResizeColumns = False
        Me.GRIDRECPAY.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDRECPAY.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDRECPAY.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRECPAY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRECPAY.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRECPAY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDRECPAY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRECPAY.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DCHK, Me.DTYPE, Me.DBILLNO, Me.DREGID, Me.DBILLINITIALS, Me.DDATE, Me.DBILLAMT, Me.DBALAMT})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRECPAY.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDRECPAY.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDRECPAY.Location = New System.Drawing.Point(26, 64)
        Me.GRIDRECPAY.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRECPAY.MultiSelect = False
        Me.GRIDRECPAY.Name = "GRIDRECPAY"
        Me.GRIDRECPAY.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRECPAY.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRECPAY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRECPAY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRECPAY.Size = New System.Drawing.Size(550, 140)
        Me.GRIDRECPAY.TabIndex = 2
        '
        'DCHK
        '
        Me.DCHK.HeaderText = ""
        Me.DCHK.Name = "DCHK"
        Me.DCHK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DCHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DCHK.Width = 40
        '
        'DTYPE
        '
        Me.DTYPE.HeaderText = "Type"
        Me.DTYPE.Name = "DTYPE"
        Me.DTYPE.ReadOnly = True
        Me.DTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DBILLNO
        '
        Me.DBILLNO.HeaderText = "Bill No"
        Me.DBILLNO.Name = "DBILLNO"
        Me.DBILLNO.ReadOnly = True
        Me.DBILLNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DBILLNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DBILLNO.Visible = False
        '
        'DREGID
        '
        Me.DREGID.HeaderText = "Regid"
        Me.DREGID.Name = "DREGID"
        Me.DREGID.ReadOnly = True
        Me.DREGID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DREGID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DREGID.Visible = False
        '
        'DBILLINITIALS
        '
        Me.DBILLINITIALS.HeaderText = "Bill No"
        Me.DBILLINITIALS.Name = "DBILLINITIALS"
        Me.DBILLINITIALS.ReadOnly = True
        Me.DBILLINITIALS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DBILLINITIALS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DDATE
        '
        Me.DDATE.HeaderText = "Date"
        Me.DDATE.Name = "DDATE"
        Me.DDATE.ReadOnly = True
        Me.DDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DDATE.Width = 80
        '
        'DBILLAMT
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DBILLAMT.DefaultCellStyle = DataGridViewCellStyle3
        Me.DBILLAMT.HeaderText = "Bill Amt"
        Me.DBILLAMT.Name = "DBILLAMT"
        Me.DBILLAMT.ReadOnly = True
        Me.DBILLAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DBILLAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DBALAMT
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DBALAMT.DefaultCellStyle = DataGridViewCellStyle4
        Me.DBALAMT.HeaderText = "Bal Amt"
        Me.DBALAMT.Name = "DBALAMT"
        Me.DBALAMT.ReadOnly = True
        Me.DBALAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DBALAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GRIDMATCH
        '
        Me.GRIDMATCH.AllowUserToAddRows = False
        Me.GRIDMATCH.AllowUserToDeleteRows = False
        Me.GRIDMATCH.AllowUserToResizeColumns = False
        Me.GRIDMATCH.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDMATCH.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDMATCH.BackgroundColor = System.Drawing.Color.White
        Me.GRIDMATCH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDMATCH.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDMATCH.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDMATCH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDMATCH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GCHK, Me.GTYPE, Me.GBILLNO, Me.GREGID, Me.GBILLINITIALS, Me.GDATE, Me.GREFNO, Me.GBILLAMT, Me.GBALAMT, Me.GPAIDAMT})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDMATCH.DefaultCellStyle = DataGridViewCellStyle12
        Me.GRIDMATCH.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDMATCH.Location = New System.Drawing.Point(26, 218)
        Me.GRIDMATCH.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDMATCH.MultiSelect = False
        Me.GRIDMATCH.Name = "GRIDMATCH"
        Me.GRIDMATCH.RowHeadersVisible = False
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDMATCH.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GRIDMATCH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDMATCH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDMATCH.Size = New System.Drawing.Size(773, 195)
        Me.GRIDMATCH.TabIndex = 3
        '
        'GCHK
        '
        Me.GCHK.HeaderText = ""
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GCHK.Width = 40
        '
        'GTYPE
        '
        Me.GTYPE.HeaderText = "Type"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.ReadOnly = True
        Me.GTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GBILLNO
        '
        Me.GBILLNO.HeaderText = "Bill No"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.ReadOnly = True
        Me.GBILLNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBILLNO.Visible = False
        '
        'GREGID
        '
        Me.GREGID.HeaderText = "Regid"
        Me.GREGID.Name = "GREGID"
        Me.GREGID.ReadOnly = True
        Me.GREGID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREGID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREGID.Visible = False
        '
        'GBILLINITIALS
        '
        Me.GBILLINITIALS.HeaderText = "Bill No"
        Me.GBILLINITIALS.Name = "GBILLINITIALS"
        Me.GBILLINITIALS.ReadOnly = True
        Me.GBILLINITIALS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLINITIALS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GDATE
        '
        Me.GDATE.HeaderText = "Date"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.ReadOnly = True
        Me.GDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDATE.Width = 80
        '
        'GREFNO
        '
        Me.GREFNO.HeaderText = "Ref No"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.ReadOnly = True
        Me.GREFNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREFNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREFNO.Width = 120
        '
        'GBILLAMT
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GBILLAMT.DefaultCellStyle = DataGridViewCellStyle9
        Me.GBILLAMT.HeaderText = "Bill Amt"
        Me.GBILLAMT.Name = "GBILLAMT"
        Me.GBILLAMT.ReadOnly = True
        Me.GBILLAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GBALAMT
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GBALAMT.DefaultCellStyle = DataGridViewCellStyle10
        Me.GBALAMT.HeaderText = "Bal Amt"
        Me.GBALAMT.Name = "GBALAMT"
        Me.GBALAMT.ReadOnly = True
        Me.GBALAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBALAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GPAIDAMT
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPAIDAMT.DefaultCellStyle = DataGridViewCellStyle11
        Me.GPAIDAMT.HeaderText = "Pay Amt"
        Me.GPAIDAMT.Name = "GPAIDAMT"
        Me.GPAIDAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPAIDAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.Linen
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ForeColor = System.Drawing.Color.Black
        Me.TXTADD.Location = New System.Drawing.Point(411, 30)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(90, 22)
        Me.TXTADD.TabIndex = 718
        Me.TXTADD.Text = "0.00"
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(408, 422)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 716
        Me.Label1.Text = "Total Amt"
        '
        'TXTTOTALBAL
        '
        Me.TXTTOTALBAL.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALBAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALBAL.Location = New System.Drawing.Point(469, 418)
        Me.TXTTOTALBAL.Name = "TXTTOTALBAL"
        Me.TXTTOTALBAL.ReadOnly = True
        Me.TXTTOTALBAL.Size = New System.Drawing.Size(100, 23)
        Me.TXTTOTALBAL.TabIndex = 715
        Me.TXTTOTALBAL.TabStop = False
        Me.TXTTOTALBAL.Text = "0.00"
        Me.TXTTOTALBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALPAY
        '
        Me.TXTTOTALPAY.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPAY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPAY.Location = New System.Drawing.Point(572, 418)
        Me.TXTTOTALPAY.Name = "TXTTOTALPAY"
        Me.TXTTOTALPAY.ReadOnly = True
        Me.TXTTOTALPAY.Size = New System.Drawing.Size(100, 23)
        Me.TXTTOTALPAY.TabIndex = 713
        Me.TXTTOTALPAY.TabStop = False
        Me.TXTTOTALPAY.Text = "0.00"
        Me.TXTTOTALPAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(427, 34)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(74, 22)
        Me.CMBACCCODE.TabIndex = 705
        Me.CMBACCCODE.Visible = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(78, 34)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(251, 22)
        Me.CMBNAME.TabIndex = 1
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(37, 38)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(39, 14)
        Me.Label33.TabIndex = 681
        Me.Label33.Text = "Name"
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(462, 486)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 5
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'CMDSAVE
        '
        Me.CMDSAVE.BackColor = System.Drawing.Color.Transparent
        Me.CMDSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSAVE.FlatAppearance.BorderSize = 0
        Me.CMDSAVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSAVE.ForeColor = System.Drawing.Color.Black
        Me.CMDSAVE.Location = New System.Drawing.Point(376, 486)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 4
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(548, 486)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 472)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(78, 469)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(274, 45)
        Me.txtremarks.TabIndex = 8
        '
        'TXTMATCHNO
        '
        Me.TXTMATCHNO.BackColor = System.Drawing.Color.Linen
        Me.TXTMATCHNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMATCHNO.Location = New System.Drawing.Point(712, 6)
        Me.TXTMATCHNO.Name = "TXTMATCHNO"
        Me.TXTMATCHNO.ReadOnly = True
        Me.TXTMATCHNO.Size = New System.Drawing.Size(87, 22)
        Me.TXTMATCHNO.TabIndex = 315
        Me.TXTMATCHNO.TabStop = False
        Me.TXTMATCHNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(659, 11)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(50, 13)
        Me.lblsrno.TabIndex = 316
        Me.lblsrno.Text = "Sr. No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(676, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Date"
        '
        'MATCHDATE
        '
        Me.MATCHDATE.CustomFormat = "dd/MM/yyyy"
        Me.MATCHDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MATCHDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MATCHDATE.Location = New System.Drawing.Point(712, 34)
        Me.MATCHDATE.Name = "MATCHDATE"
        Me.MATCHDATE.Size = New System.Drawing.Size(87, 22)
        Me.MATCHDATE.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 5)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(145, 20)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Manual Matching"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(245, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(80, 22)
        Me.tstxtbillno.TabIndex = 719
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ManualMatching
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(824, 561)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ManualMatching"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Manual Matching"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDRECPAY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDMATCH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GRIDMATCH As System.Windows.Forms.DataGridView
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALBAL As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALPAY As System.Windows.Forms.TextBox
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents TXTMATCHNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MATCHDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GRIDRECPAY As System.Windows.Forms.DataGridView
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents DCHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DBILLNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DREGID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DBILLINITIALS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DBILLAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DBALAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCHK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBILLNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREGID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBILLINITIALS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREFNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBILLAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBALAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPAIDAMT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
