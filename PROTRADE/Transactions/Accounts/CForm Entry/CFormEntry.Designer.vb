<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFormEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormEntry))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTREMARKS = New System.Windows.Forms.TextBox
        Me.DTRECDATE = New System.Windows.Forms.MaskedTextBox
        Me.LBLDATE = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.CMDAPPLY = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTFORMNO = New System.Windows.Forms.TextBox
        Me.DTFORMDATE = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblname = New System.Windows.Forms.Label
        Me.CMBFORM = New System.Windows.Forms.ComboBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.lblto = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.lblfrom = New System.Windows.Forms.Label
        Me.RBRECEIVED = New System.Windows.Forms.RadioButton
        Me.RBPENDING = New System.Windows.Forms.RadioButton
        Me.RBALL = New System.Windows.Forms.RadioButton
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBILL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREGTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBILLINITIALS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCFORMNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFORMDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.FORMDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Me.GRECDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFORMNARRATION = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.LBL = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.TOOLDELETE = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FORMDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FORMDATE.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTREMARKS)
        Me.BlendPanel1.Controls.Add(Me.DTRECDATE)
        Me.BlendPanel1.Controls.Add(Me.LBLDATE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.CMDAPPLY)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTFORMNO)
        Me.BlendPanel1.Controls.Add(Me.DTFORMDATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.CMBFORM)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.RBRECEIVED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.RBALL)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label33)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.LBL)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(476, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 739
        Me.Label3.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.BackColor = System.Drawing.Color.White
        Me.TXTREMARKS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTREMARKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREMARKS.Location = New System.Drawing.Point(531, 94)
        Me.TXTREMARKS.MaxLength = 2000
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(520, 23)
        Me.TXTREMARKS.TabIndex = 6
        '
        'DTRECDATE
        '
        Me.DTRECDATE.AsciiOnly = True
        Me.DTRECDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTRECDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DTRECDATE.Location = New System.Drawing.Point(675, 65)
        Me.DTRECDATE.Mask = "00/00/0000"
        Me.DTRECDATE.Name = "DTRECDATE"
        Me.DTRECDATE.Size = New System.Drawing.Size(78, 23)
        Me.DTRECDATE.TabIndex = 5
        Me.DTRECDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DTRECDATE.ValidatingType = GetType(Date)
        '
        'LBLDATE
        '
        Me.LBLDATE.AutoSize = True
        Me.LBLDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDATE.Location = New System.Drawing.Point(620, 69)
        Me.LBLDATE.Name = "LBLDATE"
        Me.LBLDATE.Size = New System.Drawing.Size(54, 15)
        Me.LBLDATE.TabIndex = 737
        Me.LBLDATE.Text = "Rec Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(339, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 14)
        Me.Label2.TabIndex = 735
        Me.Label2.Text = "Type"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"PURCHASE", "SALE"})
        Me.CMBTYPE.Location = New System.Drawing.Point(372, 40)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(84, 22)
        Me.CMBTYPE.TabIndex = 1
        '
        'CMDAPPLY
        '
        Me.CMDAPPLY.BackColor = System.Drawing.Color.Transparent
        Me.CMDAPPLY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAPPLY.FlatAppearance.BorderSize = 0
        Me.CMDAPPLY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAPPLY.ForeColor = System.Drawing.Color.Black
        Me.CMDAPPLY.Location = New System.Drawing.Point(760, 62)
        Me.CMDAPPLY.Name = "CMDAPPLY"
        Me.CMDAPPLY.Size = New System.Drawing.Size(80, 28)
        Me.CMDAPPLY.TabIndex = 7
        Me.CMDAPPLY.Text = "&Apply"
        Me.CMDAPPLY.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(476, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 733
        Me.Label6.Text = "Form No"
        '
        'TXTFORMNO
        '
        Me.TXTFORMNO.BackColor = System.Drawing.Color.White
        Me.TXTFORMNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFORMNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFORMNO.Location = New System.Drawing.Point(531, 36)
        Me.TXTFORMNO.MaxLength = 16
        Me.TXTFORMNO.Name = "TXTFORMNO"
        Me.TXTFORMNO.Size = New System.Drawing.Size(122, 23)
        Me.TXTFORMNO.TabIndex = 3
        '
        'DTFORMDATE
        '
        Me.DTFORMDATE.AsciiOnly = True
        Me.DTFORMDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFORMDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DTFORMDATE.Location = New System.Drawing.Point(531, 65)
        Me.DTFORMDATE.Mask = "00/00/0000"
        Me.DTFORMDATE.Name = "DTFORMDATE"
        Me.DTFORMDATE.Size = New System.Drawing.Size(78, 23)
        Me.DTFORMDATE.TabIndex = 4
        Me.DTFORMDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DTFORMDATE.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(466, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 724
        Me.Label1.Text = "Form Date"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(309, 69)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(61, 14)
        Me.lblname.TabIndex = 722
        Me.lblname.Text = "Form Type"
        '
        'CMBFORM
        '
        Me.CMBFORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFORM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFORM.FormattingEnabled = True
        Me.CMBFORM.Location = New System.Drawing.Point(372, 65)
        Me.CMBFORM.MaxDropDownItems = 14
        Me.CMBFORM.Name = "CMBFORM"
        Me.CMBFORM.Size = New System.Drawing.Size(84, 22)
        Me.CMBFORM.TabIndex = 2
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(189, 36)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(112, 22)
        Me.txtadd.TabIndex = 720
        Me.txtadd.Visible = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(967, 32)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBACCCODE.TabIndex = 719
        Me.CMBACCCODE.Visible = False
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(965, 61)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(86, 28)
        Me.cmdshowdetails.TabIndex = 11
        Me.cmdshowdetails.Text = "S&how Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(786, 38)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 8
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(878, 65)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(79, 22)
        Me.dtto.TabIndex = 10
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(857, 69)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 718
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(877, 36)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(80, 22)
        Me.dtfrom.TabIndex = 9
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(842, 40)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 714
        Me.lblfrom.Text = "From"
        '
        'RBRECEIVED
        '
        Me.RBRECEIVED.AutoSize = True
        Me.RBRECEIVED.BackColor = System.Drawing.Color.Transparent
        Me.RBRECEIVED.Location = New System.Drawing.Point(1056, 85)
        Me.RBRECEIVED.Name = "RBRECEIVED"
        Me.RBRECEIVED.Size = New System.Drawing.Size(110, 19)
        Me.RBRECEIVED.TabIndex = 14
        Me.RBRECEIVED.Text = "&Received Forms"
        Me.RBRECEIVED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(1056, 64)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(106, 19)
        Me.RBPENDING.TabIndex = 13
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "&Pending Forms"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.BackColor = System.Drawing.Color.Transparent
        Me.RBALL.Location = New System.Drawing.Point(1056, 43)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(72, 19)
        Me.RBALL.TabIndex = 12
        Me.RBALL.Text = "Show A&ll"
        Me.RBALL.UseVisualStyleBackColor = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(61, 65)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(240, 23)
        Me.CMBNAME.TabIndex = 0
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(20, 69)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(38, 15)
        Me.Label33.TabIndex = 708
        Me.Label33.Text = "Name"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 127)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.FORMDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1163, 397)
        Me.gridbilldetails.TabIndex = 15
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTYPE, Me.GBILL, Me.GREGTYPE, Me.GBILLINITIALS, Me.GDATE, Me.GNAME, Me.GTOTALWT, Me.GAMT, Me.GCFORMNO, Me.GFORMDATE, Me.GRECDATE, Me.GFORMNARRATION})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "TYPE"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        '
        'GBILL
        '
        Me.GBILL.Caption = "Bill No"
        Me.GBILL.FieldName = "BILL"
        Me.GBILL.Name = "GBILL"
        Me.GBILL.OptionsColumn.AllowEdit = False
        '
        'GREGTYPE
        '
        Me.GREGTYPE.Caption = "Register Name"
        Me.GREGTYPE.FieldName = "REGTYPE"
        Me.GREGTYPE.Name = "GREGTYPE"
        Me.GREGTYPE.OptionsColumn.AllowEdit = False
        '
        'GBILLINITIALS
        '
        Me.GBILLINITIALS.Caption = "Bill No"
        Me.GBILLINITIALS.FieldName = "BILLINITIALS"
        Me.GBILLINITIALS.Name = "GBILLINITIALS"
        Me.GBILLINITIALS.OptionsColumn.AllowEdit = False
        Me.GBILLINITIALS.Visible = True
        Me.GBILLINITIALS.VisibleIndex = 0
        '
        'GDATE
        '
        Me.GDATE.Caption = "Bill Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "BILLDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 250
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Wt"
        Me.GTOTALWT.DisplayFormat.FormatString = "0"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.OptionsColumn.AllowEdit = False
        Me.GTOTALWT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 3
        Me.GTOTALWT.Width = 70
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.OptionsColumn.AllowEdit = False
        Me.GAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 4
        Me.GAMT.Width = 110
        '
        'GCFORMNO
        '
        Me.GCFORMNO.Caption = "Form No"
        Me.GCFORMNO.FieldName = "FORMNO"
        Me.GCFORMNO.Name = "GCFORMNO"
        Me.GCFORMNO.OptionsColumn.AllowEdit = False
        Me.GCFORMNO.Visible = True
        Me.GCFORMNO.VisibleIndex = 5
        Me.GCFORMNO.Width = 130
        '
        'GFORMDATE
        '
        Me.GFORMDATE.Caption = "Form Date"
        Me.GFORMDATE.ColumnEdit = Me.FORMDATE
        Me.GFORMDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GFORMDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GFORMDATE.FieldName = "FORMDATE"
        Me.GFORMDATE.Name = "GFORMDATE"
        Me.GFORMDATE.OptionsColumn.AllowEdit = False
        Me.GFORMDATE.Visible = True
        Me.GFORMDATE.VisibleIndex = 6
        '
        'FORMDATE
        '
        Me.FORMDATE.AutoHeight = False
        Me.FORMDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FORMDATE.Name = "FORMDATE"
        Me.FORMDATE.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'GRECDATE
        '
        Me.GRECDATE.Caption = "Rec Date"
        Me.GRECDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRECDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRECDATE.FieldName = "RECDATE"
        Me.GRECDATE.Name = "GRECDATE"
        Me.GRECDATE.OptionsColumn.AllowEdit = False
        Me.GRECDATE.Visible = True
        Me.GRECDATE.VisibleIndex = 7
        '
        'GFORMNARRATION
        '
        Me.GFORMNARRATION.Caption = "Remarks"
        Me.GFORMNARRATION.FieldName = "REMARKS"
        Me.GFORMNARRATION.Name = "GFORMNARRATION"
        Me.GFORMNARRATION.Visible = True
        Me.GFORMNARRATION.VisibleIndex = 8
        Me.GFORMNARRATION.Width = 250
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(552, 529)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 17
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
        Me.cmdok.Location = New System.Drawing.Point(466, 529)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 16
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(638, 529)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 18
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(980, 37)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 441
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'LBL
        '
        Me.LBL.AutoSize = True
        Me.LBL.BackColor = System.Drawing.Color.Transparent
        Me.LBL.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBL.Location = New System.Drawing.Point(18, 30)
        Me.LBL.Name = "LBL"
        Me.LBL.Size = New System.Drawing.Size(107, 26)
        Me.LBL.TabIndex = 430
        Me.LBL.Text = "Form Entry"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.TOOLDELETE, Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 611
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&Save"
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
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
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
        'CFormEntry
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CFormEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FORMDATE.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FORMDATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GFORMDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FORMDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents LBL As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TOOLDELETE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents RBRECEIVED As System.Windows.Forms.RadioButton
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents GBILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFORMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFORMNARRATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents CMBFORM As System.Windows.Forms.ComboBox
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents DTFORMDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTFORMNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDAPPLY As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents DTRECDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LBLDATE As System.Windows.Forms.Label
    Friend WithEvents GRECDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
End Class
