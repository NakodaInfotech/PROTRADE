<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SamplePriceList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SamplePriceList))
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.TXTNARRATION = New System.Windows.Forms.TextBox()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.GRIDSPL = New System.Windows.Forms.DataGridView()
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNARRATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.SPLDATE = New System.Windows.Forms.MaskedTextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLDELETE = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPREVIOUS = New System.Windows.Forms.ToolStripButton()
        Me.Toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdEXIT = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label()
        Me.LBLTOTALAMT = New System.Windows.Forms.Label()
        Me.TXTAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.lblbarcode = New System.Windows.Forms.Label()
        Me.CMBPARTYNAME = New System.Windows.Forms.ComboBox()
        Me.TXTMODEOFSHIPMENT = New System.Windows.Forms.TextBox()
        Me.TXTSPLNO = New System.Windows.Forms.TextBox()
        Me.LBLMODEOFSHIPMENT = New System.Windows.Forms.Label()
        Me.LBLDATE = New System.Windows.Forms.Label()
        Me.LBLSRNO = New System.Windows.Forms.Label()
        Me.lblpartyname = New System.Windows.Forms.Label()
        CType(Me.GRIDSPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.White
        Me.CMBCOLOR.DropDownWidth = 400
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(622, 131)
        Me.CMBCOLOR.MaxLength = 100
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(100, 23)
        Me.CMBCOLOR.TabIndex = 7
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.BackColor = System.Drawing.Color.White
        Me.CMBDESIGN.DropDownWidth = 400
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(472, 131)
        Me.CMBDESIGN.MaxLength = 100
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(150, 23)
        Me.CMBDESIGN.TabIndex = 6
        '
        'TXTNARRATION
        '
        Me.TXTNARRATION.Location = New System.Drawing.Point(962, 131)
        Me.TXTNARRATION.MaxLength = 200
        Me.TXTNARRATION.Name = "TXTNARRATION"
        Me.TXTNARRATION.Size = New System.Drawing.Size(200, 23)
        Me.TXTNARRATION.TabIndex = 11
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Location = New System.Drawing.Point(722, 131)
        Me.TXTRATE.MaxLength = 100
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(80, 23)
        Me.TXTRATE.TabIndex = 8
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDSPL
        '
        Me.GRIDSPL.AllowUserToAddRows = False
        Me.GRIDSPL.AllowUserToDeleteRows = False
        Me.GRIDSPL.AllowUserToResizeColumns = False
        Me.GRIDSPL.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSPL.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSPL.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSPL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSPL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSPL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSPL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSPL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.gitemname, Me.GQUALITY, Me.GDESIGN, Me.GCOLOR, Me.GRATE, Me.GMTRS, Me.GAMOUNT, Me.GNARRATION})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSPL.DefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDSPL.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSPL.Location = New System.Drawing.Point(37, 154)
        Me.GRIDSPL.MultiSelect = False
        Me.GRIDSPL.Name = "GRIDSPL"
        Me.GRIDSPL.RowHeadersVisible = False
        Me.GRIDSPL.RowHeadersWidth = 30
        Me.GRIDSPL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSPL.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDSPL.RowTemplate.Height = 20
        Me.GRIDSPL.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSPL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSPL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSPL.Size = New System.Drawing.Size(1160, 286)
        Me.GRIDSPL.TabIndex = 12
        Me.GRIDSPL.TabStop = False
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 35
        '
        'gitemname
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gitemname.DefaultCellStyle = DataGridViewCellStyle3
        Me.gitemname.HeaderText = "Item Name"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.ReadOnly = True
        Me.gitemname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gitemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gitemname.Width = 200
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 200
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGN.Width = 150
        '
        'GCOLOR
        '
        Me.GCOLOR.HeaderText = "Shade"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.ReadOnly = True
        Me.GCOLOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOLOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GRATE
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GRATE.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRATE.HeaderText = "Rate"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.ReadOnly = True
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 80
        '
        'GMTRS
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle5
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 80
        '
        'GAMOUNT
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GAMOUNT.DefaultCellStyle = DataGridViewCellStyle6
        Me.GAMOUNT.HeaderText = "Amount"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.ReadOnly = True
        Me.GAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAMOUNT.Width = 80
        '
        'GNARRATION
        '
        Me.GNARRATION.HeaderText = "Narration"
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.ReadOnly = True
        Me.GNARRATION.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNARRATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNARRATION.Width = 200
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.DropDownWidth = 400
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(72, 131)
        Me.CMBITEMNAME.MaxLength = 100
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(200, 23)
        Me.CMBITEMNAME.TabIndex = 4
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(37, 131)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(35, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'SPLDATE
        '
        Me.SPLDATE.AsciiOnly = True
        Me.SPLDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.SPLDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.SPLDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.SPLDATE.Location = New System.Drawing.Point(680, 69)
        Me.SPLDATE.Mask = "00/00/0000"
        Me.SPLDATE.Name = "SPLDATE"
        Me.SPLDATE.Size = New System.Drawing.Size(88, 23)
        Me.SPLDATE.TabIndex = 0
        Me.SPLDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.SPLDATE.ValidatingType = GetType(Date)
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(620, 519)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 16
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(448, 519)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 14
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(243, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(61, 22)
        Me.tstxtbillno.TabIndex = 12
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.TOOLDELETE, Me.ToolStripSeparator2, Me.ToolPREVIOUS, Me.Toolnext, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 32
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
        'TOOLDELETE
        '
        Me.TOOLDELETE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLDELETE.Image = CType(resources.GetObject("TOOLDELETE.Image"), System.Drawing.Image)
        Me.TOOLDELETE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDELETE.Name = "TOOLDELETE"
        Me.TOOLDELETE.Size = New System.Drawing.Size(23, 22)
        Me.TOOLDELETE.Text = "&Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolPREVIOUS
        '
        Me.ToolPREVIOUS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolPREVIOUS.Image = CType(resources.GetObject("ToolPREVIOUS.Image"), System.Drawing.Image)
        Me.ToolPREVIOUS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPREVIOUS.Name = "ToolPREVIOUS"
        Me.ToolPREVIOUS.Size = New System.Drawing.Size(68, 22)
        Me.ToolPREVIOUS.Text = "Previous"
        '
        'Toolnext
        '
        Me.Toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Toolnext.Image = CType(resources.GetObject("Toolnext.Image"), System.Drawing.Image)
        Me.Toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolnext.Name = "Toolnext"
        Me.Toolnext.Size = New System.Drawing.Size(50, 22)
        Me.Toolnext.Text = "Next"
        Me.Toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(386, 70)
        Me.TXTADD.MaxLength = 100
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(75, 23)
        Me.TXTADD.TabIndex = 739
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(386, 40)
        Me.CMBCODE.MaxLength = 100
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(75, 23)
        Me.CMBCODE.TabIndex = 738
        Me.CMBCODE.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(25, 446)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(236, 107)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 16)
        Me.txtremarks.MaxLength = 200
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(225, 85)
        Me.txtremarks.TabIndex = 0
        Me.txtremarks.TabStop = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(534, 519)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 15
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'cmdEXIT
        '
        Me.cmdEXIT.BackColor = System.Drawing.Color.Transparent
        Me.cmdEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEXIT.FlatAppearance.BorderSize = 0
        Me.cmdEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEXIT.ForeColor = System.Drawing.Color.Black
        Me.cmdEXIT.Location = New System.Drawing.Point(706, 519)
        Me.cmdEXIT.Name = "cmdEXIT"
        Me.cmdEXIT.Size = New System.Drawing.Size(80, 28)
        Me.cmdEXIT.TabIndex = 17
        Me.cmdEXIT.Text = "E&xit"
        Me.cmdEXIT.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTAMOUNT)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel1.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Controls.Add(Me.lblbarcode)
        Me.BlendPanel1.Controls.Add(Me.TXTNARRATION)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.GRIDSPL)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.SPLDATE)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMBPARTYNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTMODEOFSHIPMENT)
        Me.BlendPanel1.Controls.Add(Me.TXTSPLNO)
        Me.BlendPanel1.Controls.Add(Me.LBLMODEOFSHIPMENT)
        Me.BlendPanel1.Controls.Add(Me.LBLDATE)
        Me.BlendPanel1.Controls.Add(Me.LBLSRNO)
        Me.BlendPanel1.Controls.Add(Me.lblpartyname)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.White
        Me.CMBQUALITY.DropDownWidth = 400
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(272, 131)
        Me.CMBQUALITY.MaxLength = 100
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(200, 23)
        Me.CMBQUALITY.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(742, 446)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 742
        Me.Label2.Text = "Total"
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(802, 446)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(80, 15)
        Me.LBLTOTALMTRS.TabIndex = 741
        Me.LBLTOTALMTRS.Text = "0.00"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALAMT
        '
        Me.LBLTOTALAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALAMT.Location = New System.Drawing.Point(882, 446)
        Me.LBLTOTALAMT.Name = "LBLTOTALAMT"
        Me.LBLTOTALAMT.Size = New System.Drawing.Size(80, 15)
        Me.LBLTOTALAMT.TabIndex = 740
        Me.LBLTOTALAMT.Text = "0.00"
        Me.LBLTOTALAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTAMOUNT
        '
        Me.TXTAMOUNT.BackColor = System.Drawing.Color.Linen
        Me.TXTAMOUNT.Location = New System.Drawing.Point(882, 131)
        Me.TXTAMOUNT.MaxLength = 100
        Me.TXTAMOUNT.Name = "TXTAMOUNT"
        Me.TXTAMOUNT.ReadOnly = True
        Me.TXTAMOUNT.Size = New System.Drawing.Size(80, 23)
        Me.TXTAMOUNT.TabIndex = 10
        Me.TXTAMOUNT.TabStop = False
        Me.TXTAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.White
        Me.TXTMTRS.Location = New System.Drawing.Point(802, 131)
        Me.TXTMTRS.MaxLength = 100
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(80, 23)
        Me.TXTMTRS.TabIndex = 9
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.Location = New System.Drawing.Point(680, 98)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(140, 23)
        Me.TXTBARCODE.TabIndex = 3
        '
        'lblbarcode
        '
        Me.lblbarcode.AutoSize = True
        Me.lblbarcode.BackColor = System.Drawing.Color.Transparent
        Me.lblbarcode.Location = New System.Drawing.Point(625, 102)
        Me.lblbarcode.Name = "lblbarcode"
        Me.lblbarcode.Size = New System.Drawing.Size(50, 15)
        Me.lblbarcode.TabIndex = 1
        Me.lblbarcode.Text = "Barcode"
        '
        'CMBPARTYNAME
        '
        Me.CMBPARTYNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPARTYNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPARTYNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPARTYNAME.FormattingEnabled = True
        Me.CMBPARTYNAME.Location = New System.Drawing.Point(133, 40)
        Me.CMBPARTYNAME.MaxLength = 100
        Me.CMBPARTYNAME.Name = "CMBPARTYNAME"
        Me.CMBPARTYNAME.Size = New System.Drawing.Size(240, 23)
        Me.CMBPARTYNAME.TabIndex = 1
        '
        'TXTMODEOFSHIPMENT
        '
        Me.TXTMODEOFSHIPMENT.Location = New System.Drawing.Point(133, 69)
        Me.TXTMODEOFSHIPMENT.MaxLength = 100
        Me.TXTMODEOFSHIPMENT.Name = "TXTMODEOFSHIPMENT"
        Me.TXTMODEOFSHIPMENT.Size = New System.Drawing.Size(240, 23)
        Me.TXTMODEOFSHIPMENT.TabIndex = 2
        '
        'TXTSPLNO
        '
        Me.TXTSPLNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSPLNO.Location = New System.Drawing.Point(680, 40)
        Me.TXTSPLNO.Name = "TXTSPLNO"
        Me.TXTSPLNO.ReadOnly = True
        Me.TXTSPLNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTSPLNO.TabIndex = 0
        '
        'LBLMODEOFSHIPMENT
        '
        Me.LBLMODEOFSHIPMENT.AutoSize = True
        Me.LBLMODEOFSHIPMENT.BackColor = System.Drawing.Color.Transparent
        Me.LBLMODEOFSHIPMENT.Location = New System.Drawing.Point(22, 73)
        Me.LBLMODEOFSHIPMENT.Name = "LBLMODEOFSHIPMENT"
        Me.LBLMODEOFSHIPMENT.Size = New System.Drawing.Size(107, 15)
        Me.LBLMODEOFSHIPMENT.TabIndex = 6
        Me.LBLMODEOFSHIPMENT.Text = "Mode Of Shipment"
        '
        'LBLDATE
        '
        Me.LBLDATE.AutoSize = True
        Me.LBLDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLDATE.Location = New System.Drawing.Point(645, 73)
        Me.LBLDATE.Name = "LBLDATE"
        Me.LBLDATE.Size = New System.Drawing.Size(31, 15)
        Me.LBLDATE.TabIndex = 5
        Me.LBLDATE.Text = "Date"
        '
        'LBLSRNO
        '
        Me.LBLSRNO.AutoSize = True
        Me.LBLSRNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSRNO.Location = New System.Drawing.Point(641, 44)
        Me.LBLSRNO.Name = "LBLSRNO"
        Me.LBLSRNO.Size = New System.Drawing.Size(36, 15)
        Me.LBLSRNO.TabIndex = 4
        Me.LBLSRNO.Text = "Sr No"
        '
        'lblpartyname
        '
        Me.lblpartyname.AutoSize = True
        Me.lblpartyname.BackColor = System.Drawing.Color.Transparent
        Me.lblpartyname.Location = New System.Drawing.Point(60, 44)
        Me.lblpartyname.Name = "lblpartyname"
        Me.lblpartyname.Size = New System.Drawing.Size(68, 15)
        Me.lblpartyname.TabIndex = 0
        Me.lblpartyname.Text = "Party Name"
        '
        'SamplePriceList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SamplePriceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sample Price List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GRIDSPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GRIDSPL As DataGridView
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents SPLDATE As MaskedTextBox
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents TOOLDELETE As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolPREVIOUS As ToolStripButton
    Friend WithEvents Toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents cmdclear As Button
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdEXIT As Button
    Friend WithEvents CMBPARTYNAME As ComboBox
    Friend WithEvents TXTMODEOFSHIPMENT As TextBox
    Friend WithEvents TXTSPLNO As TextBox
    Friend WithEvents LBLMODEOFSHIPMENT As Label
    Friend WithEvents LBLDATE As Label
    Friend WithEvents LBLSRNO As Label
    Friend WithEvents lblbarcode As Label
    Friend WithEvents lblpartyname As Label
    Friend WithEvents TXTBARCODE As TextBox
    Friend WithEvents TXTNARRATION As TextBox
    Friend WithEvents TXTRATE As TextBox
    Friend WithEvents CMBCOLOR As ComboBox
    Friend WithEvents CMBDESIGN As ComboBox
    Friend WithEvents TXTAMOUNT As TextBox
    Friend WithEvents TXTMTRS As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LBLTOTALMTRS As Label
    Friend WithEvents LBLTOTALAMT As Label
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents gitemname As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GAMOUNT As DataGridViewTextBoxColumn
    Friend WithEvents GNARRATION As DataGridViewTextBoxColumn
    Friend WithEvents CMBQUALITY As ComboBox
End Class
