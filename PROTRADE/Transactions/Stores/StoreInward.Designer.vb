<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreInward
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreInward))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.LBLTOTALQTY = New System.Windows.Forms.Label()
        Me.LBLTOTAL = New System.Windows.Forms.Label()
        Me.GRIDINWARD = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.cmbcode = New System.Windows.Forms.ComboBox()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.CHALLANDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTCHALLANNO = New System.Windows.Forms.TextBox()
        Me.CMBSTOREITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.CMBTRANS = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.INWARDDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTINWARDNO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblgrndate = New System.Windows.Forms.Label()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDINWARD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBUNIT)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.TXTDESC)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALQTY)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTAL)
        Me.BlendPanel1.Controls.Add(Me.GRIDINWARD)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.cmbcode)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.CHALLANDATE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTCHALLANNO)
        Me.BlendPanel1.Controls.Add(Me.CMBSTOREITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBTRANS)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.INWARDDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTINWARDNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.lblgrndate)
        Me.BlendPanel1.Controls.Add(Me.TXTQTY)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(729, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBUNIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(585, 113)
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(80, 23)
        Me.CMBUNIT.TabIndex = 8
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(20, 113)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 859
        Me.TXTSRNO.TabStop = False
        '
        'TXTDESC
        '
        Me.TXTDESC.BackColor = System.Drawing.Color.White
        Me.TXTDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(310, 113)
        Me.TXTDESC.MaxLength = 100
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(200, 23)
        Me.TXTDESC.TabIndex = 6
        '
        'LBLTOTALQTY
        '
        Me.LBLTOTALQTY.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALQTY.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALQTY.Location = New System.Drawing.Point(501, 406)
        Me.LBLTOTALQTY.Name = "LBLTOTALQTY"
        Me.LBLTOTALQTY.Size = New System.Drawing.Size(78, 15)
        Me.LBLTOTALQTY.TabIndex = 853
        Me.LBLTOTALQTY.Text = "0"
        Me.LBLTOTALQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTAL
        '
        Me.LBLTOTAL.AutoSize = True
        Me.LBLTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTAL.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTAL.Location = New System.Drawing.Point(462, 406)
        Me.LBLTOTAL.Name = "LBLTOTAL"
        Me.LBLTOTAL.Size = New System.Drawing.Size(33, 15)
        Me.LBLTOTAL.TabIndex = 852
        Me.LBLTOTAL.Text = "Total"
        '
        'GRIDINWARD
        '
        Me.GRIDINWARD.AllowUserToAddRows = False
        Me.GRIDINWARD.AllowUserToDeleteRows = False
        Me.GRIDINWARD.AllowUserToResizeColumns = False
        Me.GRIDINWARD.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDINWARD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDINWARD.BackgroundColor = System.Drawing.Color.White
        Me.GRIDINWARD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDINWARD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDINWARD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDINWARD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDINWARD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GITEMNAME, Me.GDESC, Me.GQTY, Me.GUNIT})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDINWARD.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDINWARD.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDINWARD.Location = New System.Drawing.Point(20, 136)
        Me.GRIDINWARD.MultiSelect = False
        Me.GRIDINWARD.Name = "GRIDINWARD"
        Me.GRIDINWARD.ReadOnly = True
        Me.GRIDINWARD.RowHeadersVisible = False
        Me.GRIDINWARD.RowHeadersWidth = 30
        Me.GRIDINWARD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDINWARD.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDINWARD.RowTemplate.Height = 20
        Me.GRIDINWARD.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDINWARD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDINWARD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDINWARD.Size = New System.Drawing.Size(678, 267)
        Me.GRIDINWARD.TabIndex = 9
        Me.GRIDINWARD.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Store Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 250
        '
        'GDESC
        '
        Me.GDESC.HeaderText = "Desc"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.ReadOnly = True
        Me.GDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESC.Width = 200
        '
        'GQTY
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GQTY.DefaultCellStyle = DataGridViewCellStyle3
        Me.GQTY.HeaderText = "Qty"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.ReadOnly = True
        Me.GQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQTY.Width = 75
        '
        'GUNIT
        '
        Me.GUNIT.HeaderText = "Unit"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.ReadOnly = True
        Me.GUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUNIT.Width = 80
        '
        'TXTADD
        '
        Me.TXTADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(671, 98)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(29, 21)
        Me.TXTADD.TabIndex = 851
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'cmbcode
        '
        Me.cmbcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcode.FormattingEnabled = True
        Me.cmbcode.Location = New System.Drawing.Point(706, 97)
        Me.cmbcode.Name = "cmbcode"
        Me.cmbcode.Size = New System.Drawing.Size(25, 22)
        Me.cmbcode.TabIndex = 850
        Me.cmbcode.Visible = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(239, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(61, 22)
        Me.tstxtbillno.TabIndex = 13
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(729, 25)
        Me.ToolStrip1.TabIndex = 848
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
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
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
        Me.toolprevious.Size = New System.Drawing.Size(68, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.PROTRADE.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(50, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(20, 421)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(277, 81)
        Me.GroupBox5.TabIndex = 10
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
        Me.txtremarks.Size = New System.Drawing.Size(266, 60)
        Me.txtremarks.TabIndex = 0
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(568, 437)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 13
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(482, 437)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 12
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(396, 437)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 11
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'CHALLANDATE
        '
        Me.CHALLANDATE.AsciiOnly = True
        Me.CHALLANDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CHALLANDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHALLANDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.CHALLANDATE.Location = New System.Drawing.Point(465, 70)
        Me.CHALLANDATE.Mask = "00/00/0000"
        Me.CHALLANDATE.Name = "CHALLANDATE"
        Me.CHALLANDATE.Size = New System.Drawing.Size(82, 23)
        Me.CHALLANDATE.TabIndex = 4
        Me.CHALLANDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.CHALLANDATE.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(390, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 847
        Me.Label3.Text = "Challan Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(399, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 845
        Me.Label2.Text = "Challan No"
        '
        'TXTCHALLANNO
        '
        Me.TXTCHALLANNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCHALLANNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHALLANNO.Location = New System.Drawing.Point(465, 41)
        Me.TXTCHALLANNO.MaxLength = 20
        Me.TXTCHALLANNO.Name = "TXTCHALLANNO"
        Me.TXTCHALLANNO.Size = New System.Drawing.Size(82, 23)
        Me.TXTCHALLANNO.TabIndex = 3
        '
        'CMBSTOREITEMNAME
        '
        Me.CMBSTOREITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTOREITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTOREITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSTOREITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTOREITEMNAME.FormattingEnabled = True
        Me.CMBSTOREITEMNAME.Location = New System.Drawing.Point(60, 113)
        Me.CMBSTOREITEMNAME.MaxDropDownItems = 14
        Me.CMBSTOREITEMNAME.Name = "CMBSTOREITEMNAME"
        Me.CMBSTOREITEMNAME.Size = New System.Drawing.Size(250, 23)
        Me.CMBSTOREITEMNAME.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(28, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 838
        Me.Label6.Text = "Party Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(99, 41)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(246, 23)
        Me.CMBNAME.TabIndex = 1
        '
        'CMBTRANS
        '
        Me.CMBTRANS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTRANS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTRANS.BackColor = System.Drawing.Color.White
        Me.CMBTRANS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTRANS.FormattingEnabled = True
        Me.CMBTRANS.Location = New System.Drawing.Point(99, 70)
        Me.CMBTRANS.MaxDropDownItems = 14
        Me.CMBTRANS.Name = "CMBTRANS"
        Me.CMBTRANS.Size = New System.Drawing.Size(246, 23)
        Me.CMBTRANS.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(38, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 15)
        Me.Label18.TabIndex = 836
        Me.Label18.Text = "Transport"
        '
        'INWARDDATE
        '
        Me.INWARDDATE.AsciiOnly = True
        Me.INWARDDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.INWARDDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INWARDDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.INWARDDATE.Location = New System.Drawing.Point(616, 70)
        Me.INWARDDATE.Mask = "00/00/0000"
        Me.INWARDDATE.Name = "INWARDDATE"
        Me.INWARDDATE.Size = New System.Drawing.Size(82, 23)
        Me.INWARDDATE.TabIndex = 0
        Me.INWARDDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.INWARDDATE.ValidatingType = GetType(Date)
        '
        'TXTINWARDNO
        '
        Me.TXTINWARDNO.BackColor = System.Drawing.Color.Linen
        Me.TXTINWARDNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINWARDNO.Location = New System.Drawing.Point(616, 41)
        Me.TXTINWARDNO.Name = "TXTINWARDNO"
        Me.TXTINWARDNO.ReadOnly = True
        Me.TXTINWARDNO.Size = New System.Drawing.Size(82, 23)
        Me.TXTINWARDNO.TabIndex = 833
        Me.TXTINWARDNO.TabStop = False
        Me.TXTINWARDNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(576, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 834
        Me.Label12.Text = "Sr. No"
        '
        'lblgrndate
        '
        Me.lblgrndate.AutoSize = True
        Me.lblgrndate.BackColor = System.Drawing.Color.Transparent
        Me.lblgrndate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgrndate.ForeColor = System.Drawing.Color.Black
        Me.lblgrndate.Location = New System.Drawing.Point(582, 74)
        Me.lblgrndate.Name = "lblgrndate"
        Me.lblgrndate.Size = New System.Drawing.Size(31, 15)
        Me.lblgrndate.TabIndex = 832
        Me.lblgrndate.Text = "Date"
        '
        'TXTQTY
        '
        Me.TXTQTY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQTY.Location = New System.Drawing.Point(510, 113)
        Me.TXTQTY.MaxLength = 10
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.Size = New System.Drawing.Size(75, 23)
        Me.TXTQTY.TabIndex = 7
        Me.TXTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(482, 471)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'StoreInward
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(729, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StoreInward"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Store Inward"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDINWARD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents cmbcode As System.Windows.Forms.ComboBox
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents CHALLANDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTCHALLANNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBSTOREITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBTRANS As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents INWARDDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TXTINWARDNO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblgrndate As System.Windows.Forms.Label
    Friend WithEvents TXTQTY As System.Windows.Forms.TextBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GRIDINWARD As System.Windows.Forms.DataGridView
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents LBLTOTALQTY As System.Windows.Forms.Label
    Friend WithEvents LBLTOTAL As System.Windows.Forms.Label
    Friend WithEvents CMBUNIT As ComboBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents TXTDESC As TextBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GDESC As DataGridViewTextBoxColumn
    Friend WithEvents GQTY As DataGridViewTextBoxColumn
    Friend WithEvents GUNIT As DataGridViewTextBoxColumn
End Class
