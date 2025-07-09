<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PackingSlip
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackingSlip))
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LBLTOTALPCS = New System.Windows.Forms.Label()
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.CHKHIDEPCS = New System.Windows.Forms.CheckBox()
        Me.PACKINGDATE = New System.Windows.Forms.MaskedTextBox()
        Me.SALELOCK = New System.Windows.Forms.PictureBox()
        Me.TXTTRANSADD = New System.Windows.Forms.TextBox()
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox()
        Me.CMDSELECTSTOCK = New System.Windows.Forms.Button()
        Me.LBLGODOWN = New System.Windows.Forms.Label()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKWHITELABEL = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.TXTPACKINGNO = New System.Windows.Forms.TextBox()
        Me.LBLSRNO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.TXTCUT = New System.Windows.Forms.TextBox()
        Me.TXTDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.GRIDPACKING = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPIECETYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPRINTDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GSHADE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gmtrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SALELOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GRIDPACKING, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLTOTALPCS
        '
        Me.LBLTOTALPCS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALPCS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALPCS.Location = New System.Drawing.Point(723, 284)
        Me.LBLTOTALPCS.Name = "LBLTOTALPCS"
        Me.LBLTOTALPCS.Size = New System.Drawing.Size(50, 14)
        Me.LBLTOTALPCS.TabIndex = 685
        Me.LBLTOTALPCS.Text = "0"
        Me.LBLTOTALPCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALMTRS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(819, 284)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(85, 14)
        Me.LBLTOTALMTRS.TabIndex = 684
        Me.LBLTOTALMTRS.Text = "0.00"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(580, 284)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 683
        Me.Label10.Text = "Total"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(68, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
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
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(544, 514)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(81, 27)
        Me.cmddelete.TabIndex = 17
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(70, 468)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(254, 79)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 16)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(241, 57)
        Me.txtremarks.TabIndex = 0
        Me.txtremarks.TabStop = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(460, 514)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(81, 27)
        Me.cmdclear.TabIndex = 16
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(376, 514)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(81, 27)
        Me.cmdok.TabIndex = 15
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(628, 514)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(81, 27)
        Me.cmdexit.TabIndex = 18
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 26)
        Me.Label2.TabIndex = 430
        Me.Label2.Text = "Packing Slip"
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(239, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(66, 22)
        Me.tstxtbillno.TabIndex = 20
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(143, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 434
        Me.Label6.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.White
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(184, 84)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(243, 22)
        Me.cmbname.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1097, 25)
        Me.ToolStrip1.TabIndex = 610
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CHKHIDEPCS
        '
        Me.CHKHIDEPCS.AutoSize = True
        Me.CHKHIDEPCS.BackColor = System.Drawing.SystemColors.Control
        Me.CHKHIDEPCS.Location = New System.Drawing.Point(511, 2)
        Me.CHKHIDEPCS.Name = "CHKHIDEPCS"
        Me.CHKHIDEPCS.Size = New System.Drawing.Size(104, 18)
        Me.CHKHIDEPCS.TabIndex = 806
        Me.CHKHIDEPCS.Text = "Hide Pcs Details"
        Me.CHKHIDEPCS.UseVisualStyleBackColor = False
        '
        'PACKINGDATE
        '
        Me.PACKINGDATE.AsciiOnly = True
        Me.PACKINGDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.PACKINGDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.PACKINGDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.PACKINGDATE.Location = New System.Drawing.Point(797, 81)
        Me.PACKINGDATE.Mask = "00/00/0000"
        Me.PACKINGDATE.Name = "PACKINGDATE"
        Me.PACKINGDATE.Size = New System.Drawing.Size(84, 23)
        Me.PACKINGDATE.TabIndex = 1
        Me.PACKINGDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PACKINGDATE.ValidatingType = GetType(Date)
        '
        'SALELOCK
        '
        Me.SALELOCK.BackColor = System.Drawing.Color.Transparent
        Me.SALELOCK.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.SALELOCK.Location = New System.Drawing.Point(736, 475)
        Me.SALELOCK.Name = "SALELOCK"
        Me.SALELOCK.Size = New System.Drawing.Size(60, 60)
        Me.SALELOCK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SALELOCK.TabIndex = 738
        Me.SALELOCK.TabStop = False
        Me.SALELOCK.Visible = False
        '
        'TXTTRANSADD
        '
        Me.TXTTRANSADD.BackColor = System.Drawing.Color.White
        Me.TXTTRANSADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTRANSADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTTRANSADD.Location = New System.Drawing.Point(764, 28)
        Me.TXTTRANSADD.Name = "TXTTRANSADD"
        Me.TXTTRANSADD.ReadOnly = True
        Me.TXTTRANSADD.Size = New System.Drawing.Size(23, 22)
        Me.TXTTRANSADD.TabIndex = 737
        Me.TXTTRANSADD.TabStop = False
        Me.TXTTRANSADD.Visible = False
        '
        'txtDeliveryadd
        '
        Me.txtDeliveryadd.BackColor = System.Drawing.Color.White
        Me.txtDeliveryadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryadd.Enabled = False
        Me.txtDeliveryadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryadd.Location = New System.Drawing.Point(876, 29)
        Me.txtDeliveryadd.Name = "txtDeliveryadd"
        Me.txtDeliveryadd.ReadOnly = True
        Me.txtDeliveryadd.Size = New System.Drawing.Size(34, 22)
        Me.txtDeliveryadd.TabIndex = 736
        Me.txtDeliveryadd.TabStop = False
        Me.txtDeliveryadd.Visible = False
        '
        'CMDSELECTSTOCK
        '
        Me.CMDSELECTSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTSTOCK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTSTOCK.FlatAppearance.BorderSize = 0
        Me.CMDSELECTSTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTSTOCK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSELECTSTOCK.Location = New System.Drawing.Point(499, 484)
        Me.CMDSELECTSTOCK.Name = "CMDSELECTSTOCK"
        Me.CMDSELECTSTOCK.Size = New System.Drawing.Size(81, 27)
        Me.CMDSELECTSTOCK.TabIndex = 13
        Me.CMDSELECTSTOCK.Text = "Select Stock"
        Me.CMDSELECTSTOCK.UseVisualStyleBackColor = False
        '
        'LBLGODOWN
        '
        Me.LBLGODOWN.AutoSize = True
        Me.LBLGODOWN.BackColor = System.Drawing.Color.Transparent
        Me.LBLGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGODOWN.ForeColor = System.Drawing.Color.Black
        Me.LBLGODOWN.Location = New System.Drawing.Point(130, 61)
        Me.LBLGODOWN.Name = "LBLGODOWN"
        Me.LBLGODOWN.Size = New System.Drawing.Size(52, 15)
        Me.LBLGODOWN.TabIndex = 729
        Me.LBLGODOWN.Text = "Godown"
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.BackColor = System.Drawing.Color.White
        Me.CMBGODOWN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(184, 57)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(243, 23)
        Me.CMBGODOWN.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(446, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 14)
        Me.Label11.TabIndex = 727
        Me.Label11.Text = "Barcode"
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBARCODE.Location = New System.Drawing.Point(499, 53)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(195, 22)
        Me.TXTBARCODE.TabIndex = 11
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(793, 28)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(51, 22)
        Me.CMBCODE.TabIndex = 721
        Me.CMBCODE.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(736, 475)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 446
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKHIDEPCS)
        Me.BlendPanel1.Controls.Add(Me.CHKWHITELABEL)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.PACKINGDATE)
        Me.BlendPanel1.Controls.Add(Me.SALELOCK)
        Me.BlendPanel1.Controls.Add(Me.TXTTRANSADD)
        Me.BlendPanel1.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTSTOCK)
        Me.BlendPanel1.Controls.Add(Me.LBLGODOWN)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.TXTPACKINGNO)
        Me.BlendPanel1.Controls.Add(Me.LBLSRNO)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1097, 561)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKWHITELABEL
        '
        Me.CHKWHITELABEL.AutoSize = True
        Me.CHKWHITELABEL.BackColor = System.Drawing.SystemColors.Control
        Me.CHKWHITELABEL.Location = New System.Drawing.Point(391, 2)
        Me.CHKWHITELABEL.Name = "CHKWHITELABEL"
        Me.CHKWHITELABEL.Size = New System.Drawing.Size(91, 18)
        Me.CHKWHITELABEL.TabIndex = 805
        Me.CHKWHITELABEL.Text = "Blank Header"
        Me.CHKWHITELABEL.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(311, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 14)
        Me.Label12.TabIndex = 801
        Me.Label12.Text = "Copies"
        Me.Label12.Visible = False
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(356, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 798
        Me.TXTCOPIES.Text = "2"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCOPIES.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(796, 484)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 445
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(383, 34)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(44, 12)
        Me.txtadd.TabIndex = 11
        Me.txtadd.Visible = False
        '
        'TXTPACKINGNO
        '
        Me.TXTPACKINGNO.BackColor = System.Drawing.Color.Linen
        Me.TXTPACKINGNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPACKINGNO.Location = New System.Drawing.Point(797, 56)
        Me.TXTPACKINGNO.Name = "TXTPACKINGNO"
        Me.TXTPACKINGNO.ReadOnly = True
        Me.TXTPACKINGNO.Size = New System.Drawing.Size(57, 22)
        Me.TXTPACKINGNO.TabIndex = 627
        Me.TXTPACKINGNO.TabStop = False
        Me.TXTPACKINGNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLSRNO
        '
        Me.LBLSRNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSRNO.ForeColor = System.Drawing.Color.Black
        Me.LBLSRNO.Location = New System.Drawing.Point(700, 60)
        Me.LBLSRNO.Name = "LBLSRNO"
        Me.LBLSRNO.Size = New System.Drawing.Size(95, 14)
        Me.LBLSRNO.TabIndex = 630
        Me.LBLSRNO.Text = "P.S. No"
        Me.LBLSRNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(762, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 14)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Date"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(373, 476)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 14)
        Me.Label15.TabIndex = 613
        Me.Label15.Text = "Locked"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Location = New System.Drawing.Point(354, 475)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(18, 16)
        Me.Label23.TabIndex = 612
        Me.Label23.Text = "   "
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(5, 117)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1084, 346)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.CMBUNIT)
        Me.TabPage1.Controls.Add(Me.TXTCUT)
        Me.TabPage1.Controls.Add(Me.TXTDESCRIPTION)
        Me.TabPage1.Controls.Add(Me.CMBQUALITY)
        Me.TabPage1.Controls.Add(Me.TXTPCS)
        Me.TabPage1.Controls.Add(Me.CMBITEMNAME)
        Me.TabPage1.Controls.Add(Me.CMBPIECETYPE)
        Me.TabPage1.Controls.Add(Me.CMBCOLOR)
        Me.TabPage1.Controls.Add(Me.txtsrno)
        Me.TabPage1.Controls.Add(Me.TXTMTRS)
        Me.TabPage1.Controls.Add(Me.CMBDESIGN)
        Me.TabPage1.Controls.Add(Me.GRIDPACKING)
        Me.TabPage1.Controls.Add(Me.LBLTOTALMTRS)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.LBLTOTALPCS)
        Me.TabPage1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1076, 319)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Item Details"
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBUNIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(775, 1)
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(60, 23)
        Me.CMBUNIT.TabIndex = 7
        Me.CMBUNIT.Visible = False
        '
        'TXTCUT
        '
        Me.TXTCUT.BackColor = System.Drawing.Color.White
        Me.TXTCUT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUT.Location = New System.Drawing.Point(835, 1)
        Me.TXTCUT.Name = "TXTCUT"
        Me.TXTCUT.Size = New System.Drawing.Size(50, 23)
        Me.TXTCUT.TabIndex = 8
        Me.TXTCUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCUT.Visible = False
        '
        'TXTDESCRIPTION
        '
        Me.TXTDESCRIPTION.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESCRIPTION.Location = New System.Drawing.Point(364, 1)
        Me.TXTDESCRIPTION.Name = "TXTDESCRIPTION"
        Me.TXTDESCRIPTION.Size = New System.Drawing.Size(130, 23)
        Me.TXTDESCRIPTION.TabIndex = 3
        Me.TXTDESCRIPTION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTDESCRIPTION.Visible = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.White
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(233, 1)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(131, 23)
        Me.CMBQUALITY.TabIndex = 2
        Me.CMBQUALITY.Visible = False
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(725, 1)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(50, 23)
        Me.TXTPCS.TabIndex = 6
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPCS.Visible = False
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(123, 1)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(110, 23)
        Me.CMBITEMNAME.TabIndex = 1
        Me.CMBITEMNAME.Visible = False
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPIECETYPE.DropDownWidth = 400
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(35, 1)
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(88, 23)
        Me.CMBPIECETYPE.TabIndex = 0
        Me.CMBPIECETYPE.Visible = False
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.White
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(625, 1)
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(100, 23)
        Me.CMBCOLOR.TabIndex = 5
        Me.CMBCOLOR.Visible = False
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(4, 1)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(31, 23)
        Me.txtsrno.TabIndex = 688
        Me.txtsrno.TabStop = False
        Me.txtsrno.Visible = False
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(885, 1)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(80, 23)
        Me.TXTMTRS.TabIndex = 9
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTMTRS.Visible = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(494, 1)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(131, 23)
        Me.CMBDESIGN.TabIndex = 4
        Me.CMBDESIGN.Visible = False
        '
        'GRIDPACKING
        '
        Me.GRIDPACKING.AllowUserToAddRows = False
        Me.GRIDPACKING.AllowUserToDeleteRows = False
        Me.GRIDPACKING.AllowUserToResizeColumns = False
        Me.GRIDPACKING.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDPACKING.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.GRIDPACKING.BackgroundColor = System.Drawing.Color.White
        Me.GRIDPACKING.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDPACKING.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDPACKING.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.GRIDPACKING.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDPACKING.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GPIECETYPE, Me.GITEMNAME, Me.GQUALITY, Me.GPRINTDESC, Me.GDESIGN, Me.GSHADE, Me.Gpcs, Me.Gunit, Me.GCUT, Me.Gmtrs, Me.GBARCODE, Me.GOUTPCS, Me.GOUTMTRS, Me.GFROMNO, Me.GFROMSRNO, Me.GFROMTYPE})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDPACKING.DefaultCellStyle = DataGridViewCellStyle23
        Me.GRIDPACKING.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDPACKING.Location = New System.Drawing.Point(3, 23)
        Me.GRIDPACKING.MultiSelect = False
        Me.GRIDPACKING.Name = "GRIDPACKING"
        Me.GRIDPACKING.RowHeadersVisible = False
        Me.GRIDPACKING.RowHeadersWidth = 30
        Me.GRIDPACKING.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDPACKING.RowsDefaultCellStyle = DataGridViewCellStyle24
        Me.GRIDPACKING.RowTemplate.Height = 20
        Me.GRIDPACKING.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDPACKING.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDPACKING.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDPACKING.Size = New System.Drawing.Size(1100, 258)
        Me.GRIDPACKING.TabIndex = 0
        Me.GRIDPACKING.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 30
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.HeaderText = "Piece Type"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.ReadOnly = True
        Me.GPIECETYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPIECETYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPIECETYPE.Width = 90
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 110
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 130
        '
        'GPRINTDESC
        '
        Me.GPRINTDESC.HeaderText = "Description"
        Me.GPRINTDESC.Name = "GPRINTDESC"
        Me.GPRINTDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPRINTDESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPRINTDESC.Width = 130
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.Width = 130
        '
        'GSHADE
        '
        Me.GSHADE.HeaderText = "Shade"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.ReadOnly = True
        Me.GSHADE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHADE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Gpcs
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Gpcs.DefaultCellStyle = DataGridViewCellStyle19
        Me.Gpcs.HeaderText = "Pcs"
        Me.Gpcs.Name = "Gpcs"
        Me.Gpcs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gpcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gpcs.Width = 50
        '
        'Gunit
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Gunit.DefaultCellStyle = DataGridViewCellStyle20
        Me.Gunit.HeaderText = "Unit"
        Me.Gunit.Name = "Gunit"
        Me.Gunit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gunit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gunit.Width = 60
        '
        'GCUT
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCUT.DefaultCellStyle = DataGridViewCellStyle21
        Me.GCUT.HeaderText = "Cut"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUT.Width = 50
        '
        'Gmtrs
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Gmtrs.DefaultCellStyle = DataGridViewCellStyle22
        Me.Gmtrs.HeaderText = "Mtrs"
        Me.Gmtrs.Name = "Gmtrs"
        Me.Gmtrs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gmtrs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gmtrs.Width = 80
        '
        'GBARCODE
        '
        Me.GBARCODE.HeaderText = "Barcode"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.ReadOnly = True
        Me.GBARCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBARCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBARCODE.Width = 110
        '
        'GOUTPCS
        '
        Me.GOUTPCS.HeaderText = "OUTPCS"
        Me.GOUTPCS.Name = "GOUTPCS"
        Me.GOUTPCS.Visible = False
        '
        'GOUTMTRS
        '
        Me.GOUTMTRS.HeaderText = "OUTMTRS"
        Me.GOUTMTRS.Name = "GOUTMTRS"
        Me.GOUTMTRS.Visible = False
        '
        'GFROMNO
        '
        Me.GFROMNO.HeaderText = "FROMNO"
        Me.GFROMNO.Name = "GFROMNO"
        Me.GFROMNO.Visible = False
        '
        'GFROMSRNO
        '
        Me.GFROMSRNO.HeaderText = "FROMSRNO"
        Me.GFROMSRNO.Name = "GFROMSRNO"
        Me.GFROMSRNO.Visible = False
        '
        'GFROMTYPE
        '
        Me.GFROMTYPE.HeaderText = "FROMTYPE"
        Me.GFROMTYPE.Name = "GFROMTYPE"
        Me.GFROMTYPE.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'PackingSlip
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1097, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PackingSlip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Packing Slip"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SALELOCK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GRIDPACKING, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LBLTOTALPCS As Label
    Friend WithEvents LBLTOTALMTRS As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents toolprevious As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents cmddelete As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents cmdclear As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbname As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents CHKHIDEPCS As CheckBox
    Friend WithEvents PACKINGDATE As MaskedTextBox
    Friend WithEvents SALELOCK As PictureBox
    Friend WithEvents TXTTRANSADD As TextBox
    Friend WithEvents txtDeliveryadd As TextBox
    Friend WithEvents CMDSELECTSTOCK As Button
    Friend WithEvents LBLGODOWN As Label
    Friend WithEvents CMBGODOWN As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTBARCODE As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents PBlock As PictureBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbllocked As Label
    Friend WithEvents txtadd As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TXTCUT As TextBox
    Friend WithEvents TXTDESCRIPTION As TextBox
    Friend WithEvents CMBQUALITY As ComboBox
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents CMBPIECETYPE As ComboBox
    Friend WithEvents CMBCOLOR As ComboBox
    Friend WithEvents txtsrno As TextBox
    Friend WithEvents TXTMTRS As TextBox
    Friend WithEvents CMBDESIGN As ComboBox
    Friend WithEvents GRIDPACKING As DataGridView
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents TXTPACKINGNO As TextBox
    Friend WithEvents LBLSRNO As Label
    Friend WithEvents CHKWHITELABEL As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents CMBUNIT As ComboBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GPIECETYPE As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GPRINTDESC As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewComboBoxColumn
    Friend WithEvents GSHADE As DataGridViewTextBoxColumn
    Friend WithEvents Gpcs As DataGridViewTextBoxColumn
    Friend WithEvents Gunit As DataGridViewTextBoxColumn
    Friend WithEvents GCUT As DataGridViewTextBoxColumn
    Friend WithEvents Gmtrs As DataGridViewTextBoxColumn
    Friend WithEvents GBARCODE As DataGridViewTextBoxColumn
    Friend WithEvents GOUTPCS As DataGridViewTextBoxColumn
    Friend WithEvents GOUTMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GFROMNO As DataGridViewTextBoxColumn
    Friend WithEvents GFROMSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GFROMTYPE As DataGridViewTextBoxColumn
End Class
