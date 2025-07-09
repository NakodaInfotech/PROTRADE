<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContraEntry
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContraEntry))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.LBLREFNO = New System.Windows.Forms.Label()
        Me.CMDRECO = New System.Windows.Forms.Button()
        Me.TXTCHQNO = New System.Windows.Forms.TextBox()
        Me.LBLRECO = New System.Windows.Forms.Label()
        Me.CHKRECO = New System.Windows.Forms.CheckBox()
        Me.RECODATE = New System.Windows.Forms.DateTimePicker()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.PBlock = New System.Windows.Forms.PictureBox()
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
        Me.gridcontra = New System.Windows.Forms.DataGridView()
        Me.gridtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paytype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.refno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.griddr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridcr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.griddone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRIDSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRECODATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.txtjournalno = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.contradate = New System.Windows.Forms.DateTimePicker()
        Me.lbl = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridcontra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.LBLREFNO)
        Me.BlendPanel1.Controls.Add(Me.CMDRECO)
        Me.BlendPanel1.Controls.Add(Me.TXTCHQNO)
        Me.BlendPanel1.Controls.Add(Me.LBLRECO)
        Me.BlendPanel1.Controls.Add(Me.CHKRECO)
        Me.BlendPanel1.Controls.Add(Me.RECODATE)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
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
        Me.BlendPanel1.Controls.Add(Me.gridcontra)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.txtjournalno)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.contradate)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(797, 348)
        Me.BlendPanel1.TabIndex = 0
        '
        'LBLREFNO
        '
        Me.LBLREFNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLREFNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLREFNO.Location = New System.Drawing.Point(644, 23)
        Me.LBLREFNO.Name = "LBLREFNO"
        Me.LBLREFNO.Size = New System.Drawing.Size(50, 13)
        Me.LBLREFNO.TabIndex = 594
        Me.LBLREFNO.Text = "Chq No."
        Me.LBLREFNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMDRECO
        '
        Me.CMDRECO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDRECO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDRECO.Location = New System.Drawing.Point(345, 43)
        Me.CMDRECO.Name = "CMDRECO"
        Me.CMDRECO.Size = New System.Drawing.Size(34, 24)
        Me.CMDRECO.TabIndex = 587
        Me.CMDRECO.Text = "Reco"
        Me.CMDRECO.UseVisualStyleBackColor = True
        Me.CMDRECO.Visible = False
        '
        'TXTCHQNO
        '
        Me.TXTCHQNO.BackColor = System.Drawing.Color.Linen
        Me.TXTCHQNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHQNO.Location = New System.Drawing.Point(696, 18)
        Me.TXTCHQNO.Name = "TXTCHQNO"
        Me.TXTCHQNO.Size = New System.Drawing.Size(80, 22)
        Me.TXTCHQNO.TabIndex = 2
        '
        'LBLRECO
        '
        Me.LBLRECO.AutoSize = True
        Me.LBLRECO.BackColor = System.Drawing.Color.Transparent
        Me.LBLRECO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRECO.Location = New System.Drawing.Point(379, 48)
        Me.LBLRECO.Name = "LBLRECO"
        Me.LBLRECO.Size = New System.Drawing.Size(62, 14)
        Me.LBLRECO.TabIndex = 586
        Me.LBLRECO.Text = "Reco Date"
        '
        'CHKRECO
        '
        Me.CHKRECO.AutoSize = True
        Me.CHKRECO.Location = New System.Drawing.Point(443, 23)
        Me.CHKRECO.Name = "CHKRECO"
        Me.CHKRECO.Size = New System.Drawing.Size(15, 14)
        Me.CHKRECO.TabIndex = 585
        Me.CHKRECO.UseVisualStyleBackColor = True
        Me.CHKRECO.Visible = False
        '
        'RECODATE
        '
        Me.RECODATE.CustomFormat = "dd/MM/yyyy"
        Me.RECODATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RECODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RECODATE.Location = New System.Drawing.Point(443, 44)
        Me.RECODATE.Name = "RECODATE"
        Me.RECODATE.Size = New System.Drawing.Size(79, 22)
        Me.RECODATE.TabIndex = 584
        Me.RECODATE.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(283, 45)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 582
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {""})
        Me.CMBCODE.Location = New System.Drawing.Point(176, 10)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBCODE.TabIndex = 483
        Me.CMBCODE.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(227, 16)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(50, 50)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 583
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(666, 45)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBACCCODE.TabIndex = 482
        Me.CMBACCCODE.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTADD.Location = New System.Drawing.Point(95, 3)
        Me.TXTADD.Multiline = True
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(79, 29)
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
        Me.cmdclear.Location = New System.Drawing.Point(516, 296)
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
        Me.cmdok.Location = New System.Drawing.Point(431, 296)
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
        Me.cmdexit.Location = New System.Drawing.Point(600, 296)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmbpaytype
        '
        Me.cmbpaytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpaytype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpaytype.FormattingEnabled = True
        Me.cmbpaytype.Items.AddRange(New Object() {"On Account"})
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
        Me.Label2.Size = New System.Drawing.Size(54, 14)
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
        Me.Label23.Size = New System.Drawing.Size(52, 14)
        Me.Label23.TabIndex = 318
        Me.Label23.Text = "Register"
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(460, 24)
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
        'gridcontra
        '
        Me.gridcontra.AllowUserToAddRows = False
        Me.gridcontra.AllowUserToDeleteRows = False
        Me.gridcontra.AllowUserToResizeColumns = False
        Me.gridcontra.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.gridcontra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridcontra.BackgroundColor = System.Drawing.Color.White
        Me.gridcontra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridcontra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridcontra.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridcontra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridcontra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gridtype, Me.gridname, Me.paytype, Me.refno, Me.griddr, Me.gridcr, Me.griddone, Me.RTOTAL, Me.GRIDSRNO, Me.GRECODATE})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcontra.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridcontra.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridcontra.Location = New System.Drawing.Point(30, 92)
        Me.gridcontra.Margin = New System.Windows.Forms.Padding(2)
        Me.gridcontra.MultiSelect = False
        Me.gridcontra.Name = "gridcontra"
        Me.gridcontra.ReadOnly = True
        Me.gridcontra.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.gridcontra.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.gridcontra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridcontra.Size = New System.Drawing.Size(736, 184)
        Me.gridcontra.TabIndex = 303
        Me.gridcontra.TabStop = False
        '
        'gridtype
        '
        Me.gridtype.HeaderText = "Type"
        Me.gridtype.Name = "gridtype"
        Me.gridtype.ReadOnly = True
        Me.gridtype.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridtype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gridtype.Width = 50
        '
        'gridname
        '
        Me.gridname.HeaderText = "Name"
        Me.gridname.Name = "gridname"
        Me.gridname.ReadOnly = True
        Me.gridname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gridname.Width = 250
        '
        'paytype
        '
        Me.paytype.HeaderText = "Pay Type"
        Me.paytype.Name = "paytype"
        Me.paytype.ReadOnly = True
        Me.paytype.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.paytype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.paytype.Width = 90
        '
        'refno
        '
        Me.refno.HeaderText = "Ref. No"
        Me.refno.Name = "refno"
        Me.refno.ReadOnly = True
        Me.refno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.refno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.refno.Width = 80
        '
        'griddr
        '
        Me.griddr.HeaderText = "Debit"
        Me.griddr.Name = "griddr"
        Me.griddr.ReadOnly = True
        Me.griddr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.griddr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.griddr.Width = 80
        '
        'gridcr
        '
        Me.gridcr.HeaderText = "Credit"
        Me.gridcr.Name = "gridcr"
        Me.gridcr.ReadOnly = True
        Me.gridcr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridcr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gridcr.Width = 80
        '
        'griddone
        '
        Me.griddone.HeaderText = "Done"
        Me.griddone.Name = "griddone"
        Me.griddone.ReadOnly = True
        Me.griddone.Visible = False
        '
        'RTOTAL
        '
        Me.RTOTAL.HeaderText = "Bal. Amt"
        Me.RTOTAL.Name = "RTOTAL"
        Me.RTOTAL.ReadOnly = True
        Me.RTOTAL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RTOTAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RTOTAL.Width = 80
        '
        'GRIDSRNO
        '
        Me.GRIDSRNO.HeaderText = "GRIDSRNO"
        Me.GRIDSRNO.Name = "GRIDSRNO"
        Me.GRIDSRNO.ReadOnly = True
        Me.GRIDSRNO.Visible = False
        '
        'GRECODATE
        '
        Me.GRECODATE.HeaderText = "RECODATE"
        Me.GRECODATE.Name = "GRECODATE"
        Me.GRECODATE.ReadOnly = True
        Me.GRECODATE.Visible = False
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
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(284, 11)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(46, 24)
        Me.cmdedit.TabIndex = 309
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'txtjournalno
        '
        Me.txtjournalno.BackColor = System.Drawing.Color.White
        Me.txtjournalno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtjournalno.Location = New System.Drawing.Point(573, 18)
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
        Me.lblsrno.Location = New System.Drawing.Point(521, 22)
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
        Me.Label5.Location = New System.Drawing.Point(538, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Date"
        '
        'contradate
        '
        Me.contradate.CustomFormat = "dd/MM/yyyy"
        Me.contradate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contradate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.contradate.Location = New System.Drawing.Point(573, 44)
        Me.contradate.Name = "contradate"
        Me.contradate.Size = New System.Drawing.Size(87, 22)
        Me.contradate.TabIndex = 1
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(77, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Contra"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.ToolStripdelete, Me.toolStripSeparator, Me.toolprevious, Me.ToolStripSeparator2, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(797, 25)
        Me.ToolStrip1.TabIndex = 285
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
        Me.ToolStripdelete.Text = "&Delete"
        Me.ToolStripdelete.ToolTipText = "Delete Contra"
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
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 22)
        Me.tstxtbillno.TabIndex = 1
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ContraEntry
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(797, 373)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ContraEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridcontra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
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
    Friend WithEvents gridcontra As System.Windows.Forms.DataGridView
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents txtjournalno As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents contradate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl As System.Windows.Forms.Label
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
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents CMDRECO As System.Windows.Forms.Button
    Friend WithEvents LBLRECO As System.Windows.Forms.Label
    Friend WithEvents CHKRECO As System.Windows.Forms.CheckBox
    Friend WithEvents RECODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents gridtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gridname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents paytype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents refno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents griddr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gridcr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents griddone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RTOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRIDSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRECODATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LBLREFNO As System.Windows.Forms.Label
    Friend WithEvents TXTCHQNO As System.Windows.Forms.TextBox
End Class
