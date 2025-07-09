<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScheduleMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScheduleMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.SALELOCK = New System.Windows.Forms.PictureBox
        Me.PBlock = New System.Windows.Forms.PictureBox
        Me.lbllocked = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label
        Me.lbltotalqty = New System.Windows.Forms.Label
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.TOOLDELETE = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolPREVIOUS = New System.Windows.Forms.ToolStripButton
        Me.Toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.CMDSELECTSTOCK = New System.Windows.Forms.Button
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdEXIT = New System.Windows.Forms.Button
        Me.SCHDATE = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTSCHNO = New System.Windows.Forms.TextBox
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.tbitem = New System.Windows.Forms.TabPage
        Me.GRIDSO = New System.Windows.Forms.DataGridView
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSONO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GGRIDSONO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPARTYNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gitemname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcolor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRECDQTY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.SALELOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbitem.SuspendLayout()
        CType(Me.GRIDSO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.SALELOCK)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.lbltotalqty)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTSTOCK)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdOK)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdEXIT)
        Me.BlendPanel1.Controls.Add(Me.SCHDATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTSCHNO)
        Me.BlendPanel1.Controls.Add(Me.TabControl2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(834, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'SALELOCK
        '
        Me.SALELOCK.BackColor = System.Drawing.Color.Transparent
        Me.SALELOCK.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.SALELOCK.Location = New System.Drawing.Point(646, 460)
        Me.SALELOCK.Name = "SALELOCK"
        Me.SALELOCK.Size = New System.Drawing.Size(60, 60)
        Me.SALELOCK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SALELOCK.TabIndex = 741
        Me.SALELOCK.TabStop = False
        Me.SALELOCK.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(646, 460)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 740
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(706, 469)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 739
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(18, 453)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(261, 97)
        Me.GroupBox5.TabIndex = 731
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 16)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(248, 75)
        Me.txtremarks.TabIndex = 0
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALMTRS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(711, 442)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(66, 15)
        Me.LBLTOTALMTRS.TabIndex = 730
        Me.LBLTOTALMTRS.Text = "0.00"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotalqty
        '
        Me.lbltotalqty.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalqty.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalqty.ForeColor = System.Drawing.Color.Black
        Me.lbltotalqty.Location = New System.Drawing.Point(630, 442)
        Me.lbltotalqty.Name = "lbltotalqty"
        Me.lbltotalqty.Size = New System.Drawing.Size(57, 15)
        Me.lbltotalqty.TabIndex = 729
        Me.lbltotalqty.Text = "0"
        Me.lbltotalqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(243, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(61, 22)
        Me.tstxtbillno.TabIndex = 327
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.TOOLDELETE, Me.ToolStripSeparator2, Me.ToolPREVIOUS, Me.Toolnext, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(834, 25)
        Me.ToolStrip1.TabIndex = 0
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
        Me.ToolPREVIOUS.Size = New System.Drawing.Size(73, 22)
        Me.ToolPREVIOUS.Text = "Previous"
        '
        'Toolnext
        '
        Me.Toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Toolnext.Image = CType(resources.GetObject("Toolnext.Image"), System.Drawing.Image)
        Me.Toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolnext.Name = "Toolnext"
        Me.Toolnext.Size = New System.Drawing.Size(51, 22)
        Me.Toolnext.Text = "Next"
        Me.Toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'CMDSELECTSTOCK
        '
        Me.CMDSELECTSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTSTOCK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTSTOCK.FlatAppearance.BorderSize = 0
        Me.CMDSELECTSTOCK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTSTOCK.ForeColor = System.Drawing.Color.Black
        Me.CMDSELECTSTOCK.Location = New System.Drawing.Point(291, 488)
        Me.CMDSELECTSTOCK.Name = "CMDSELECTSTOCK"
        Me.CMDSELECTSTOCK.Size = New System.Drawing.Size(80, 28)
        Me.CMDSELECTSTOCK.TabIndex = 2
        Me.CMDSELECTSTOCK.Text = "S&elect SO"
        Me.CMDSELECTSTOCK.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(334, 522)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 6
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.Transparent
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOK.FlatAppearance.BorderSize = 0
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.Black
        Me.cmdOK.Location = New System.Drawing.Point(377, 488)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 28)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "&Save"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(463, 488)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 5
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdEXIT
        '
        Me.cmdEXIT.BackColor = System.Drawing.Color.Transparent
        Me.cmdEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEXIT.FlatAppearance.BorderSize = 0
        Me.cmdEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEXIT.ForeColor = System.Drawing.Color.Black
        Me.cmdEXIT.Location = New System.Drawing.Point(420, 522)
        Me.cmdEXIT.Name = "cmdEXIT"
        Me.cmdEXIT.Size = New System.Drawing.Size(80, 28)
        Me.cmdEXIT.TabIndex = 7
        Me.cmdEXIT.Text = "E&xit"
        Me.cmdEXIT.UseVisualStyleBackColor = False
        '
        'SCHDATE
        '
        Me.SCHDATE.AsciiOnly = True
        Me.SCHDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.SCHDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.SCHDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.SCHDATE.Location = New System.Drawing.Point(732, 64)
        Me.SCHDATE.Mask = "00/00/0000"
        Me.SCHDATE.Name = "SCHDATE"
        Me.SCHDATE.Size = New System.Drawing.Size(88, 23)
        Me.SCHDATE.TabIndex = 1
        Me.SCHDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.SCHDATE.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(694, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 318
        Me.Label1.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(689, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 319
        Me.Label3.Text = "Sr No."
        '
        'TXTSCHNO
        '
        Me.TXTSCHNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSCHNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSCHNO.Location = New System.Drawing.Point(732, 38)
        Me.TXTSCHNO.Name = "TXTSCHNO"
        Me.TXTSCHNO.ReadOnly = True
        Me.TXTSCHNO.Size = New System.Drawing.Size(88, 22)
        Me.TXTSCHNO.TabIndex = 316
        Me.TXTSCHNO.TabStop = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tbitem)
        Me.TabControl2.Location = New System.Drawing.Point(18, 70)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(802, 369)
        Me.TabControl2.TabIndex = 3
        '
        'tbitem
        '
        Me.tbitem.BackColor = System.Drawing.Color.White
        Me.tbitem.Controls.Add(Me.GRIDSO)
        Me.tbitem.Location = New System.Drawing.Point(4, 24)
        Me.tbitem.Name = "tbitem"
        Me.tbitem.Padding = New System.Windows.Forms.Padding(3)
        Me.tbitem.Size = New System.Drawing.Size(794, 341)
        Me.tbitem.TabIndex = 0
        Me.tbitem.Text = "Item Details"
        '
        'GRIDSO
        '
        Me.GRIDSO.AllowUserToAddRows = False
        Me.GRIDSO.AllowUserToDeleteRows = False
        Me.GRIDSO.AllowUserToResizeColumns = False
        Me.GRIDSO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSO.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GSONO, Me.GGRIDSONO, Me.GPARTYNAME, Me.gitemname, Me.gcolor, Me.gQty, Me.GMTRS, Me.GRECDQTY, Me.GTYPE})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSO.DefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDSO.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSO.Location = New System.Drawing.Point(3, 6)
        Me.GRIDSO.MultiSelect = False
        Me.GRIDSO.Name = "GRIDSO"
        Me.GRIDSO.RowHeadersVisible = False
        Me.GRIDSO.RowHeadersWidth = 30
        Me.GRIDSO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSO.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDSO.RowTemplate.Height = 20
        Me.GRIDSO.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSO.Size = New System.Drawing.Size(785, 329)
        Me.GRIDSO.TabIndex = 13
        Me.GRIDSO.TabStop = False
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 30
        '
        'GSONO
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GSONO.DefaultCellStyle = DataGridViewCellStyle3
        Me.GSONO.HeaderText = "SO No."
        Me.GSONO.Name = "GSONO"
        Me.GSONO.ReadOnly = True
        Me.GSONO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSONO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSONO.Width = 60
        '
        'GGRIDSONO
        '
        Me.GGRIDSONO.HeaderText = "GRIDSONO"
        Me.GGRIDSONO.Name = "GGRIDSONO"
        Me.GGRIDSONO.ReadOnly = True
        Me.GGRIDSONO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRIDSONO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRIDSONO.Visible = False
        '
        'GPARTYNAME
        '
        Me.GPARTYNAME.HeaderText = "Party Name"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.ReadOnly = True
        Me.GPARTYNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPARTYNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPARTYNAME.Width = 200
        '
        'gitemname
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gitemname.DefaultCellStyle = DataGridViewCellStyle4
        Me.gitemname.HeaderText = "Item Name"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.ReadOnly = True
        Me.gitemname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gitemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gitemname.Width = 200
        '
        'gcolor
        '
        Me.gcolor.HeaderText = "Shade"
        Me.gcolor.Name = "gcolor"
        Me.gcolor.ReadOnly = True
        Me.gcolor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gcolor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gQty
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.NullValue = Nothing
        Me.gQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.gQty.HeaderText = "Qty"
        Me.gQty.Name = "gQty"
        Me.gQty.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gQty.Width = 80
        '
        'GMTRS
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle6
        Me.GMTRS.HeaderText = "Mtrs."
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 80
        '
        'GRECDQTY
        '
        Me.GRECDQTY.HeaderText = "Recd MTRS"
        Me.GRECDQTY.Name = "GRECDQTY"
        Me.GRECDQTY.ReadOnly = True
        Me.GRECDQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRECDQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRECDQTY.Visible = False
        '
        'GTYPE
        '
        Me.GTYPE.HeaderText = "Type"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.ReadOnly = True
        Me.GTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GTYPE.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ScheduleMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ScheduleMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Schedule Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.SALELOCK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tbitem.ResumeLayout(False)
        CType(Me.GRIDSO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents SCHDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTSCHNO As System.Windows.Forms.TextBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tbitem As System.Windows.Forms.TabPage
    Friend WithEvents GRIDSO As System.Windows.Forms.DataGridView
    Friend WithEvents CMDSELECTSTOCK As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdEXIT As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TOOLDELETE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolPREVIOUS As System.Windows.Forms.ToolStripButton
    Friend WithEvents Toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents LBLTOTALMTRS As System.Windows.Forms.Label
    Friend WithEvents lbltotalqty As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GGRIDSONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPARTYNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gitemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcolor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRECDQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALELOCK As System.Windows.Forms.PictureBox
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
End Class
