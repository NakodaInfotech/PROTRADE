<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterestCalc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterestCalc))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.lbldrcrclosing = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbln = New System.Windows.Forms.Label()
        Me.TXTDAYS = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTPERCENT = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.RBPASSDATE = New System.Windows.Forms.RadioButton()
        Me.RBBILLDATE = New System.Windows.Forms.RadioButton()
        Me.RBDUEDATE = New System.Windows.Forms.RadioButton()
        Me.CHKDATE = New System.Windows.Forms.CheckBox()
        Me.CHKDN = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GBILL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAPPDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gduedate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEBIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCREDIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETTBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOPAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOREC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbgroup = New System.Windows.Forms.ComboBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmbgroup)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.lbldrcrclosing)
        Me.BlendPanel1.Controls.Add(Me.txttotal)
        Me.BlendPanel1.Controls.Add(Me.lbln)
        Me.BlendPanel1.Controls.Add(Me.TXTDAYS)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTPERCENT)
        Me.BlendPanel1.Controls.Add(Me.Label28)
        Me.BlendPanel1.Controls.Add(Me.RBPASSDATE)
        Me.BlendPanel1.Controls.Add(Me.RBBILLDATE)
        Me.BlendPanel1.Controls.Add(Me.RBDUEDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKDN)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.Label31)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(1004, 532)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcrclosing.TabIndex = 760
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Black
        Me.txttotal.Location = New System.Drawing.Point(876, 529)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 759
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(794, 533)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(80, 14)
        Me.lbln.TabIndex = 758
        Me.lbln.Text = "Int Closing Bal."
        '
        'TXTDAYS
        '
        Me.TXTDAYS.BackColor = System.Drawing.Color.White
        Me.TXTDAYS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDAYS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDAYS.Location = New System.Drawing.Point(816, 59)
        Me.TXTDAYS.Name = "TXTDAYS"
        Me.TXTDAYS.Size = New System.Drawing.Size(37, 22)
        Me.TXTDAYS.TabIndex = 7
        Me.TXTDAYS.Text = "360"
        Me.TXTDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(781, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 757
        Me.Label1.Text = "Days"
        '
        'TXTPERCENT
        '
        Me.TXTPERCENT.BackColor = System.Drawing.Color.White
        Me.TXTPERCENT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPERCENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPERCENT.Location = New System.Drawing.Point(816, 33)
        Me.TXTPERCENT.Name = "TXTPERCENT"
        Me.TXTPERCENT.Size = New System.Drawing.Size(37, 22)
        Me.TXTPERCENT.TabIndex = 6
        Me.TXTPERCENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(798, 37)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 14)
        Me.Label28.TabIndex = 755
        Me.Label28.Text = "%"
        '
        'RBPASSDATE
        '
        Me.RBPASSDATE.AutoSize = True
        Me.RBPASSDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBPASSDATE.Location = New System.Drawing.Point(583, 61)
        Me.RBPASSDATE.Name = "RBPASSDATE"
        Me.RBPASSDATE.Size = New System.Drawing.Size(79, 19)
        Me.RBPASSDATE.TabIndex = 496
        Me.RBPASSDATE.Text = "Pass Date"
        Me.RBPASSDATE.UseVisualStyleBackColor = False
        Me.RBPASSDATE.Visible = False
        '
        'RBBILLDATE
        '
        Me.RBBILLDATE.AutoSize = True
        Me.RBBILLDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBBILLDATE.Checked = True
        Me.RBBILLDATE.Location = New System.Drawing.Point(486, 61)
        Me.RBBILLDATE.Name = "RBBILLDATE"
        Me.RBBILLDATE.Size = New System.Drawing.Size(72, 19)
        Me.RBBILLDATE.TabIndex = 2
        Me.RBBILLDATE.TabStop = True
        Me.RBBILLDATE.Text = "Bill Date"
        Me.RBBILLDATE.UseVisualStyleBackColor = False
        '
        'RBDUEDATE
        '
        Me.RBDUEDATE.AutoSize = True
        Me.RBDUEDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBDUEDATE.Location = New System.Drawing.Point(486, 35)
        Me.RBDUEDATE.Name = "RBDUEDATE"
        Me.RBDUEDATE.Size = New System.Drawing.Size(74, 19)
        Me.RBDUEDATE.TabIndex = 1
        Me.RBDUEDATE.Text = "Due Date"
        Me.RBDUEDATE.UseVisualStyleBackColor = False
        '
        'CHKDATE
        '
        Me.CHKDATE.AutoSize = True
        Me.CHKDATE.BackColor = System.Drawing.Color.Transparent
        Me.CHKDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDATE.Location = New System.Drawing.Point(583, 35)
        Me.CHKDATE.Name = "CHKDATE"
        Me.CHKDATE.Size = New System.Drawing.Size(52, 18)
        Me.CHKDATE.TabIndex = 3
        Me.CHKDATE.Text = "Date"
        Me.CHKDATE.UseVisualStyleBackColor = False
        '
        'CHKDN
        '
        Me.CHKDN.AutoSize = True
        Me.CHKDN.BackColor = System.Drawing.Color.Transparent
        Me.CHKDN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDN.Location = New System.Drawing.Point(1021, 62)
        Me.CHKDN.Name = "CHKDN"
        Me.CHKDN.Size = New System.Drawing.Size(129, 18)
        Me.CHKDN.TabIndex = 492
        Me.CHKDN.Text = "Include Debit Note"
        Me.CHKDN.UseVisualStyleBackColor = False
        Me.CHKDN.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLPRINT, Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 489
        Me.ToolStrip1.Text = "v"
        '
        'TOOLPRINT
        '
        Me.TOOLPRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLPRINT.Image = CType(resources.GetObject("TOOLPRINT.Image"), System.Drawing.Image)
        Me.TOOLPRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRINT.Name = "TOOLPRINT"
        Me.TOOLPRINT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLPRINT.Text = "&Print"
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
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(21, 63)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBACCCODE.TabIndex = 488
        Me.CMBACCCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(109, 59)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(10, 31)
        Me.txtadd.TabIndex = 487
        Me.txtadd.TabStop = False
        Me.txtadd.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(169, 42)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(39, 14)
        Me.Label31.TabIndex = 449
        Me.Label31.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(210, 38)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(252, 22)
        Me.cmbname.TabIndex = 0
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(16, 94)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1152, 430)
        Me.griddetails.TabIndex = 447
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBILL, Me.GBILLINITIALS, Me.GTYPE, Me.GREGTYPE, Me.GNAME, Me.GDATE, Me.GAPPDATE, Me.gduedate, Me.GBALES, Me.GDEBIT, Me.GCREDIT, Me.GNETTBALANCE, Me.GDAYS, Me.GTOPAY, Me.GTOREC, Me.GREMARKS})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsMenu.EnableColumnMenu = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.OptionsView.ShowAutoFilterRow = True
        Me.gridregister.OptionsView.ShowFooter = True
        Me.gridregister.OptionsView.ShowGroupPanel = False
        '
        'GBILL
        '
        Me.GBILL.Caption = "BILL"
        Me.GBILL.FieldName = "SRNO"
        Me.GBILL.Name = "GBILL"
        '
        'GBILLINITIALS
        '
        Me.GBILLINITIALS.Caption = "Bill No"
        Me.GBILLINITIALS.FieldName = "BILLINITIALS"
        Me.GBILLINITIALS.Name = "GBILLINITIALS"
        Me.GBILLINITIALS.Visible = True
        Me.GBILLINITIALS.VisibleIndex = 0
        Me.GBILLINITIALS.Width = 80
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 1
        Me.GTYPE.Width = 100
        '
        'GREGTYPE
        '
        Me.GREGTYPE.Caption = "REGTYPE"
        Me.GREGTYPE.FieldName = "REGTYPE"
        Me.GREGTYPE.Name = "GREGTYPE"
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Width = 200
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'GAPPDATE
        '
        Me.GAPPDATE.Caption = "Passing Date"
        Me.GAPPDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GAPPDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GAPPDATE.FieldName = "APPDATE"
        Me.GAPPDATE.Name = "GAPPDATE"
        Me.GAPPDATE.Width = 90
        '
        'gduedate
        '
        Me.gduedate.Caption = "Due Date"
        Me.gduedate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gduedate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gduedate.FieldName = "DUEDATE"
        Me.gduedate.Name = "gduedate"
        Me.gduedate.Visible = True
        Me.gduedate.VisibleIndex = 3
        Me.gduedate.Width = 80
        '
        'GBALES
        '
        Me.GBALES.Caption = "Bales"
        Me.GBALES.DisplayFormat.FormatString = "0"
        Me.GBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALES.FieldName = "TOTALBALES"
        Me.GBALES.Name = "GBALES"
        Me.GBALES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALES.Width = 60
        '
        'GDEBIT
        '
        Me.GDEBIT.Caption = "Debit"
        Me.GDEBIT.DisplayFormat.FormatString = "0.00"
        Me.GDEBIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDEBIT.FieldName = "DEBIT"
        Me.GDEBIT.Name = "GDEBIT"
        Me.GDEBIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DEBIT", "{0:0.00}")})
        Me.GDEBIT.Visible = True
        Me.GDEBIT.VisibleIndex = 4
        Me.GDEBIT.Width = 120
        '
        'GCREDIT
        '
        Me.GCREDIT.Caption = "Credit"
        Me.GCREDIT.DisplayFormat.FormatString = "0.00"
        Me.GCREDIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCREDIT.FieldName = "CREDIT"
        Me.GCREDIT.Name = "GCREDIT"
        Me.GCREDIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CREDIT", "{0:0.00}")})
        Me.GCREDIT.Visible = True
        Me.GCREDIT.VisibleIndex = 5
        Me.GCREDIT.Width = 120
        '
        'GNETTBALANCE
        '
        Me.GNETTBALANCE.Caption = "Nett Balance"
        Me.GNETTBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GNETTBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTBALANCE.FieldName = "NETTBALANCE"
        Me.GNETTBALANCE.Name = "GNETTBALANCE"
        Me.GNETTBALANCE.Visible = True
        Me.GNETTBALANCE.VisibleIndex = 6
        Me.GNETTBALANCE.Width = 120
        '
        'GDAYS
        '
        Me.GDAYS.Caption = "Days"
        Me.GDAYS.DisplayFormat.FormatString = "0"
        Me.GDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDAYS.FieldName = "DAYS"
        Me.GDAYS.Name = "GDAYS"
        Me.GDAYS.Visible = True
        Me.GDAYS.VisibleIndex = 7
        Me.GDAYS.Width = 50
        '
        'GTOPAY
        '
        Me.GTOPAY.Caption = "To Pay"
        Me.GTOPAY.DisplayFormat.FormatString = "0.00"
        Me.GTOPAY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOPAY.FieldName = "TOPAY"
        Me.GTOPAY.Name = "GTOPAY"
        Me.GTOPAY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOPAY", "{0:0.00}")})
        Me.GTOPAY.Visible = True
        Me.GTOPAY.VisibleIndex = 8
        Me.GTOPAY.Width = 120
        '
        'GTOREC
        '
        Me.GTOREC.Caption = "To Rec"
        Me.GTOREC.DisplayFormat.FormatString = "0.00"
        Me.GTOREC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOREC.FieldName = "TOREC"
        Me.GTOREC.Name = "GTOREC"
        Me.GTOREC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOREC", "{0:0.00}")})
        Me.GTOREC.Visible = True
        Me.GTOREC.VisibleIndex = 9
        Me.GTOREC.Width = 120
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 10
        Me.GREMARKS.Width = 190
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(902, 58)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 8
        Me.cmdshowdetails.Text = "&Show Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 530)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 9
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 530)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(693, 59)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(79, 22)
        Me.dtto.TabIndex = 5
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(669, 63)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 432
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(692, 33)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(80, 22)
        Me.dtfrom.TabIndex = 4
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(654, 37)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(5, 29)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(146, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Interest Report"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'cmbgroup
        '
        Me.cmbgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgroup.FormattingEnabled = True
        Me.cmbgroup.Location = New System.Drawing.Point(902, 32)
        Me.cmbgroup.MaxDropDownItems = 14
        Me.cmbgroup.Name = "cmbgroup"
        Me.cmbgroup.Size = New System.Drawing.Size(161, 22)
        Me.cmbgroup.TabIndex = 768
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.Location = New System.Drawing.Point(861, 36)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(40, 14)
        Me.lblgroup.TabIndex = 769
        Me.lblgroup.Text = "Group"
        '
        'InterestCalc
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "InterestCalc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Interest Calculator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GBILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAPPDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gduedate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCREDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOREC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKDN As System.Windows.Forms.CheckBox
    Friend WithEvents RBPASSDATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBBILLDATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBDUEDATE As System.Windows.Forms.RadioButton
    Friend WithEvents CHKDATE As System.Windows.Forms.CheckBox
    Friend WithEvents TXTDAYS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTPERCENT As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbldrcrclosing As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbln As System.Windows.Forms.Label
    Friend WithEvents TOOLPRINT As ToolStripButton
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbgroup As ComboBox
    Friend WithEvents lblgroup As Label
End Class
