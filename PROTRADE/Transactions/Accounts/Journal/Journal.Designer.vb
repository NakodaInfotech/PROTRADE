<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class journal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(journal))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDAUTOPOST = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.JOURNALDATE = New System.Windows.Forms.MaskedTextBox()
        Me.CHKTDS = New System.Windows.Forms.CheckBox()
        Me.TXTBILLREMARKS = New System.Windows.Forms.TextBox()
        Me.PARTYBILLDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTINVAMT = New System.Windows.Forms.TextBox()
        Me.LBLBILLAMT = New System.Windows.Forms.Label()
        Me.LBLREFNO = New System.Windows.Forms.Label()
        Me.TXTPARTYBILLNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTBILLAMT = New System.Windows.Forms.TextBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.TXTTOTALCR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTTOTALDR = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmbpaytype = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.txtrefno = New System.Windows.Forms.TextBox()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.txtcredit = New System.Windows.Forms.TextBox()
        Me.txtdebit = New System.Windows.Forms.TextBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.gridjournal = New System.Windows.Forms.DataGridView()
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPAYTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GREFNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDEBIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCREDIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDONE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBALAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRIDSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMTPAIDREC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.txtjournalno = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridjournal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.TOOLWHATSAPP, Me.toolStripSeparator, Me.toolprevious, Me.ToolStripSeparator2, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(797, 25)
        Me.ToolStrip1.TabIndex = 283
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
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.PROTRADE.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "&Whatsapp"
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
        Me.toolnext.Size = New System.Drawing.Size(50, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Pay Type"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ref. No"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Done"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDAUTOPOST)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.JOURNALDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKTDS)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLREMARKS)
        Me.BlendPanel1.Controls.Add(Me.PARTYBILLDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTINVAMT)
        Me.BlendPanel1.Controls.Add(Me.LBLBILLAMT)
        Me.BlendPanel1.Controls.Add(Me.LBLREFNO)
        Me.BlendPanel1.Controls.Add(Me.TXTPARTYBILLNO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLAMT)
        Me.BlendPanel1.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALCR)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALDR)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmbpaytype)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.txtrefno)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.txtcredit)
        Me.BlendPanel1.Controls.Add(Me.txtdebit)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.gridjournal)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.txtjournalno)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(797, 418)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDAUTOPOST
        '
        Me.CMDAUTOPOST.BackColor = System.Drawing.Color.Transparent
        Me.CMDAUTOPOST.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAUTOPOST.FlatAppearance.BorderSize = 0
        Me.CMDAUTOPOST.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAUTOPOST.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDAUTOPOST.Location = New System.Drawing.Point(435, 347)
        Me.CMDAUTOPOST.Name = "CMDAUTOPOST"
        Me.CMDAUTOPOST.Size = New System.Drawing.Size(89, 28)
        Me.CMDAUTOPOST.TabIndex = 895
        Me.CMDAUTOPOST.Text = "&Auto Post"
        Me.CMDAUTOPOST.UseVisualStyleBackColor = False
        Me.CMDAUTOPOST.Visible = False
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDDELETE.Location = New System.Drawing.Point(616, 312)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 12
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'JOURNALDATE
        '
        Me.JOURNALDATE.AsciiOnly = True
        Me.JOURNALDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JOURNALDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.JOURNALDATE.Location = New System.Drawing.Point(551, 44)
        Me.JOURNALDATE.Mask = "00/00/0000"
        Me.JOURNALDATE.Name = "JOURNALDATE"
        Me.JOURNALDATE.Size = New System.Drawing.Size(82, 23)
        Me.JOURNALDATE.TabIndex = 1
        Me.JOURNALDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.JOURNALDATE.ValidatingType = GetType(Date)
        '
        'CHKTDS
        '
        Me.CHKTDS.AutoSize = True
        Me.CHKTDS.BackColor = System.Drawing.Color.Transparent
        Me.CHKTDS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTDS.Location = New System.Drawing.Point(663, 71)
        Me.CHKTDS.Name = "CHKTDS"
        Me.CHKTDS.Size = New System.Drawing.Size(86, 19)
        Me.CHKTDS.TabIndex = 732
        Me.CHKTDS.Text = "Deduct &TDS"
        Me.CHKTDS.UseVisualStyleBackColor = False
        '
        'TXTBILLREMARKS
        '
        Me.TXTBILLREMARKS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLREMARKS.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBILLREMARKS.Location = New System.Drawing.Point(102, 8)
        Me.TXTBILLREMARKS.Multiline = True
        Me.TXTBILLREMARKS.Name = "TXTBILLREMARKS"
        Me.TXTBILLREMARKS.Size = New System.Drawing.Size(79, 21)
        Me.TXTBILLREMARKS.TabIndex = 596
        Me.TXTBILLREMARKS.Visible = False
        '
        'PARTYBILLDATE
        '
        Me.PARTYBILLDATE.CustomFormat = "dd/MM/yyyy"
        Me.PARTYBILLDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PARTYBILLDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PARTYBILLDATE.Location = New System.Drawing.Point(405, 1)
        Me.PARTYBILLDATE.Name = "PARTYBILLDATE"
        Me.PARTYBILLDATE.Size = New System.Drawing.Size(83, 22)
        Me.PARTYBILLDATE.TabIndex = 595
        Me.PARTYBILLDATE.Visible = False
        '
        'TXTINVAMT
        '
        Me.TXTINVAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTINVAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINVAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTINVAMT.Location = New System.Drawing.Point(696, 44)
        Me.TXTINVAMT.Multiline = True
        Me.TXTINVAMT.Name = "TXTINVAMT"
        Me.TXTINVAMT.ReadOnly = True
        Me.TXTINVAMT.Size = New System.Drawing.Size(80, 22)
        Me.TXTINVAMT.TabIndex = 594
        Me.TXTINVAMT.TabStop = False
        '
        'LBLBILLAMT
        '
        Me.LBLBILLAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLBILLAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBILLAMT.Location = New System.Drawing.Point(644, 49)
        Me.LBLBILLAMT.Name = "LBLBILLAMT"
        Me.LBLBILLAMT.Size = New System.Drawing.Size(50, 13)
        Me.LBLBILLAMT.TabIndex = 593
        Me.LBLBILLAMT.Text = "Bill Amt"
        Me.LBLBILLAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLREFNO
        '
        Me.LBLREFNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLREFNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLREFNO.Location = New System.Drawing.Point(644, 23)
        Me.LBLREFNO.Name = "LBLREFNO"
        Me.LBLREFNO.Size = New System.Drawing.Size(50, 13)
        Me.LBLREFNO.TabIndex = 592
        Me.LBLREFNO.Text = "Ref No."
        Me.LBLREFNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTPARTYBILLNO
        '
        Me.TXTPARTYBILLNO.BackColor = System.Drawing.Color.Linen
        Me.TXTPARTYBILLNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPARTYBILLNO.Location = New System.Drawing.Point(696, 18)
        Me.TXTPARTYBILLNO.Name = "TXTPARTYBILLNO"
        Me.TXTPARTYBILLNO.ReadOnly = True
        Me.TXTPARTYBILLNO.Size = New System.Drawing.Size(80, 22)
        Me.TXTPARTYBILLNO.TabIndex = 590
        Me.TXTPARTYBILLNO.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(83, 333)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 15)
        Me.Label3.TabIndex = 589
        Me.Label3.Text = "Ctrl + Shift + R = Copy Old Remarks"
        '
        'TXTBILLAMT
        '
        Me.TXTBILLAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTBILLAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTBILLAMT.Location = New System.Drawing.Point(244, 32)
        Me.TXTBILLAMT.Multiline = True
        Me.TXTBILLAMT.Name = "TXTBILLAMT"
        Me.TXTBILLAMT.ReadOnly = True
        Me.TXTBILLAMT.Size = New System.Drawing.Size(80, 22)
        Me.TXTBILLAMT.TabIndex = 588
        Me.TXTBILLAMT.TabStop = False
        Me.TXTBILLAMT.Visible = False
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDVIEW.Location = New System.Drawing.Point(420, 39)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(88, 28)
        Me.CMDVIEW.TabIndex = 587
        Me.CMDVIEW.Text = "S&how Details"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(693, 280)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 584
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(697, 298)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(50, 50)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 585
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'TXTTOTALCR
        '
        Me.TXTTOTALCR.BackColor = System.Drawing.Color.White
        Me.TXTTOTALCR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCR.Location = New System.Drawing.Point(580, 281)
        Me.TXTTOTALCR.Name = "TXTTOTALCR"
        Me.TXTTOTALCR.ReadOnly = True
        Me.TXTTOTALCR.Size = New System.Drawing.Size(90, 22)
        Me.TXTTOTALCR.TabIndex = 487
        Me.TXTTOTALCR.TabStop = False
        Me.TXTTOTALCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(454, 285)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 486
        Me.Label1.Text = "Total"
        '
        'TXTTOTALDR
        '
        Me.TXTTOTALDR.BackColor = System.Drawing.Color.White
        Me.TXTTOTALDR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALDR.Location = New System.Drawing.Point(490, 281)
        Me.TXTTOTALDR.Name = "TXTTOTALDR"
        Me.TXTTOTALDR.ReadOnly = True
        Me.TXTTOTALDR.Size = New System.Drawing.Size(90, 22)
        Me.TXTTOTALDR.TabIndex = 485
        Me.TXTTOTALDR.TabStop = False
        Me.TXTTOTALDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {""})
        Me.CMBCODE.Location = New System.Drawing.Point(276, 22)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBCODE.TabIndex = 484
        Me.CMBCODE.Visible = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(388, 4)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBACCCODE.TabIndex = 483
        Me.CMBACCCODE.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTADD.Location = New System.Drawing.Point(154, 12)
        Me.TXTADD.Multiline = True
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(79, 21)
        Me.TXTADD.TabIndex = 323
        Me.TXTADD.Visible = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(530, 312)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 11
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(444, 312)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 10
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(530, 346)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 13
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmbpaytype
        '
        Me.cmbpaytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpaytype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpaytype.FormattingEnabled = True
        Me.cmbpaytype.Items.AddRange(New Object() {"On Account", "New Ref.", "Advance", "Against Bill"})
        Me.cmbpaytype.Location = New System.Drawing.Point(330, 71)
        Me.cmbpaytype.MaxDropDownItems = 14
        Me.cmbpaytype.Name = "cmbpaytype"
        Me.cmbpaytype.Size = New System.Drawing.Size(90, 22)
        Me.cmbpaytype.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 14)
        Me.Label2.TabIndex = 319
        Me.Label2.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(87, 283)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(328, 47)
        Me.txtremarks.TabIndex = 9
        '
        'txtrefno
        '
        Me.txtrefno.BackColor = System.Drawing.Color.White
        Me.txtrefno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrefno.Location = New System.Drawing.Point(420, 71)
        Me.txtrefno.Name = "txtrefno"
        Me.txtrefno.Size = New System.Drawing.Size(80, 22)
        Me.txtrefno.TabIndex = 6
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(80, 43)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(141, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(28, 47)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 14)
        Me.Label23.TabIndex = 318
        Me.Label23.Text = "Register"
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(239, 12)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 317
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'txtcredit
        '
        Me.txtcredit.BackColor = System.Drawing.Color.White
        Me.txtcredit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcredit.ForeColor = System.Drawing.Color.Black
        Me.txtcredit.Location = New System.Drawing.Point(580, 71)
        Me.txtcredit.Name = "txtcredit"
        Me.txtcredit.Size = New System.Drawing.Size(80, 22)
        Me.txtcredit.TabIndex = 8
        Me.txtcredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdebit
        '
        Me.txtdebit.BackColor = System.Drawing.Color.White
        Me.txtdebit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdebit.ForeColor = System.Drawing.Color.Black
        Me.txtdebit.Location = New System.Drawing.Point(500, 71)
        Me.txtdebit.Name = "txtdebit"
        Me.txtdebit.Size = New System.Drawing.Size(80, 22)
        Me.txtdebit.TabIndex = 7
        Me.txtdebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbtype
        '
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"Cr", "Dr"})
        Me.cmbtype.Location = New System.Drawing.Point(30, 71)
        Me.cmbtype.MaxDropDownItems = 14
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(50, 22)
        Me.cmbtype.TabIndex = 3
        '
        'gridjournal
        '
        Me.gridjournal.AllowUserToAddRows = False
        Me.gridjournal.AllowUserToDeleteRows = False
        Me.gridjournal.AllowUserToResizeColumns = False
        Me.gridjournal.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.gridjournal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridjournal.BackgroundColor = System.Drawing.Color.White
        Me.gridjournal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridjournal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridjournal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridjournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridjournal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GTYPE, Me.GNAME, Me.GPAYTYPE, Me.GREFNO, Me.GDEBIT, Me.GCREDIT, Me.GDONE, Me.GBALAMT, Me.GRIDSRNO, Me.GAMTPAIDREC})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridjournal.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridjournal.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridjournal.Location = New System.Drawing.Point(30, 92)
        Me.gridjournal.Margin = New System.Windows.Forms.Padding(2)
        Me.gridjournal.MultiSelect = False
        Me.gridjournal.Name = "gridjournal"
        Me.gridjournal.ReadOnly = True
        Me.gridjournal.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.gridjournal.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridjournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridjournal.Size = New System.Drawing.Size(736, 184)
        Me.gridjournal.TabIndex = 303
        Me.gridjournal.TabStop = False
        '
        'GTYPE
        '
        Me.GTYPE.HeaderText = "Type"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.ReadOnly = True
        Me.GTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GTYPE.Width = 50
        '
        'GNAME
        '
        Me.GNAME.HeaderText = "Name"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.ReadOnly = True
        Me.GNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNAME.Width = 250
        '
        'GPAYTYPE
        '
        Me.GPAYTYPE.HeaderText = "Pay Type"
        Me.GPAYTYPE.Name = "GPAYTYPE"
        Me.GPAYTYPE.ReadOnly = True
        Me.GPAYTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPAYTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPAYTYPE.Width = 90
        '
        'GREFNO
        '
        Me.GREFNO.HeaderText = "Ref. No"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.ReadOnly = True
        Me.GREFNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREFNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREFNO.Width = 80
        '
        'GDEBIT
        '
        Me.GDEBIT.HeaderText = "Debit"
        Me.GDEBIT.Name = "GDEBIT"
        Me.GDEBIT.ReadOnly = True
        Me.GDEBIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDEBIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDEBIT.Width = 80
        '
        'GCREDIT
        '
        Me.GCREDIT.HeaderText = "Credit"
        Me.GCREDIT.Name = "GCREDIT"
        Me.GCREDIT.ReadOnly = True
        Me.GCREDIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCREDIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCREDIT.Width = 80
        '
        'GDONE
        '
        Me.GDONE.HeaderText = "Done"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.ReadOnly = True
        Me.GDONE.Visible = False
        '
        'GBALAMT
        '
        Me.GBALAMT.HeaderText = "Bal. Amt"
        Me.GBALAMT.Name = "GBALAMT"
        Me.GBALAMT.ReadOnly = True
        Me.GBALAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBALAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBALAMT.Width = 80
        '
        'GRIDSRNO
        '
        Me.GRIDSRNO.HeaderText = "GRIDSRNO"
        Me.GRIDSRNO.Name = "GRIDSRNO"
        Me.GRIDSRNO.ReadOnly = True
        Me.GRIDSRNO.Visible = False
        '
        'GAMTPAIDREC
        '
        Me.GAMTPAIDREC.HeaderText = "AMTPAIDREC"
        Me.GAMTPAIDREC.Name = "GAMTPAIDREC"
        Me.GAMTPAIDREC.ReadOnly = True
        Me.GAMTPAIDREC.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(80, 71)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(250, 22)
        Me.cmbname.TabIndex = 4
        '
        'txtjournalno
        '
        Me.txtjournalno.BackColor = System.Drawing.Color.Linen
        Me.txtjournalno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjournalno.Location = New System.Drawing.Point(551, 18)
        Me.txtjournalno.Name = "txtjournalno"
        Me.txtjournalno.ReadOnly = True
        Me.txtjournalno.Size = New System.Drawing.Size(65, 22)
        Me.txtjournalno.TabIndex = 315
        Me.txtjournalno.TabStop = False
        Me.txtjournalno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(499, 22)
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
        Me.Label5.Location = New System.Drawing.Point(516, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 14)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Date"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(84, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Journal"
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
        Me.tstxtbillno.Location = New System.Drawing.Point(268, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 22)
        Me.tstxtbillno.TabIndex = 481
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'journal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(797, 443)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "journal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Journal Voucher"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridjournal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbpaytype As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents txtrefno As System.Windows.Forms.TextBox
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents txtcredit As System.Windows.Forms.TextBox
    Friend WithEvents txtdebit As System.Windows.Forms.TextBox
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents gridjournal As System.Windows.Forms.DataGridView
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents txtjournalno As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTTOTALCR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALDR As System.Windows.Forms.TextBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents TXTBILLAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBLBILLAMT As System.Windows.Forms.Label
    Friend WithEvents LBLREFNO As System.Windows.Forms.Label
    Friend WithEvents TXTPARTYBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTINVAMT As System.Windows.Forms.TextBox
    Friend WithEvents PARTYBILLDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTBILLREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents CHKTDS As System.Windows.Forms.CheckBox
    Friend WithEvents JOURNALDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPAYTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREFNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDEBIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCREDIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDONE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBALAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRIDSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GAMTPAIDREC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents CMDAUTOPOST As Button
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
End Class
