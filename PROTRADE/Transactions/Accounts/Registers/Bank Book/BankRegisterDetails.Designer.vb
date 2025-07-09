<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankRegisterDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankRegisterDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillinitials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRUNNINGBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.greg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gchqno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gremarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSECONDARY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.guser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.txtcrtotal = New System.Windows.Forms.TextBox()
        Me.txtdrtotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkdetails = New System.Windows.Forms.CheckBox()
        Me.lbldrcropening = New System.Windows.Forms.Label()
        Me.txtopening = New System.Windows.Forms.TextBox()
        Me.lblopbal = New System.Windows.Forms.Label()
        Me.lbldrcrclosing = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbln = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLDAILY = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.GCITYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.txtcrtotal)
        Me.BlendPanel1.Controls.Add(Me.txtdrtotal)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.chkdetails)
        Me.BlendPanel1.Controls.Add(Me.lbldrcropening)
        Me.BlendPanel1.Controls.Add(Me.txtopening)
        Me.BlendPanel1.Controls.Add(Me.lblopbal)
        Me.BlendPanel1.Controls.Add(Me.lbldrcrclosing)
        Me.BlendPanel1.Controls.Add(Me.txttotal)
        Me.BlendPanel1.Controls.Add(Me.lbln)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 582)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Location = New System.Drawing.Point(668, 58)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 449
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(17, 88)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1255, 430)
        Me.griddetails.TabIndex = 448
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
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gDate, Me.gname, Me.gtype, Me.gbillinitials, Me.gdr, Me.gcr, Me.GRUNNINGBAL, Me.gbillno, Me.greg, Me.gchqno, Me.gremarks, Me.GSECONDARY, Me.guser, Me.GCITYNAME})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Images = Me.imageList1
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.OptionsView.ShowAutoFilterRow = True
        Me.gridregister.OptionsView.ShowFooter = True
        '
        'gDate
        '
        Me.gDate.Caption = "Date"
        Me.gDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gDate.FieldName = "Date"
        Me.gDate.Name = "gDate"
        Me.gDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.Visible = True
        Me.gDate.VisibleIndex = 0
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "Name"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 250
        '
        'gtype
        '
        Me.gtype.Caption = "Type"
        Me.gtype.FieldName = "Type"
        Me.gtype.Name = "gtype"
        Me.gtype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gtype.Visible = True
        Me.gtype.VisibleIndex = 2
        Me.gtype.Width = 90
        '
        'gbillinitials
        '
        Me.gbillinitials.Caption = "Bill No."
        Me.gbillinitials.FieldName = "Bill No"
        Me.gbillinitials.ImageIndex = 1
        Me.gbillinitials.Name = "gbillinitials"
        Me.gbillinitials.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 3
        Me.gbillinitials.Width = 85
        '
        'gdr
        '
        Me.gdr.AppearanceCell.Options.UseTextOptions = True
        Me.gdr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gdr.Caption = "Debit"
        Me.gdr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gdr.FieldName = "Debit"
        Me.gdr.Name = "gdr"
        Me.gdr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:0.00}")})
        Me.gdr.Visible = True
        Me.gdr.VisibleIndex = 4
        Me.gdr.Width = 110
        '
        'gcr
        '
        Me.gcr.AppearanceCell.Options.UseTextOptions = True
        Me.gcr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gcr.Caption = "Credit"
        Me.gcr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcr.FieldName = "Credit"
        Me.gcr.Name = "gcr"
        Me.gcr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:0.00}")})
        Me.gcr.Visible = True
        Me.gcr.VisibleIndex = 5
        Me.gcr.Width = 110
        '
        'GRUNNINGBAL
        '
        Me.GRUNNINGBAL.Caption = "Running Bal"
        Me.GRUNNINGBAL.DisplayFormat.FormatString = "0.00"
        Me.GRUNNINGBAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRUNNINGBAL.FieldName = "RUNNINGBAL"
        Me.GRUNNINGBAL.Name = "GRUNNINGBAL"
        Me.GRUNNINGBAL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GRUNNINGBAL.Visible = True
        Me.GRUNNINGBAL.VisibleIndex = 6
        Me.GRUNNINGBAL.Width = 110
        '
        'gbillno
        '
        Me.gbillno.Caption = "Bill no"
        Me.gbillno.FieldName = "BILL"
        Me.gbillno.Name = "gbillno"
        Me.gbillno.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'greg
        '
        Me.greg.Caption = "Reg Name"
        Me.greg.FieldName = "REGTYPE"
        Me.greg.Name = "greg"
        Me.greg.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'gchqno
        '
        Me.gchqno.Caption = "Chq. No."
        Me.gchqno.FieldName = "Chq. No."
        Me.gchqno.Name = "gchqno"
        Me.gchqno.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gchqno.Visible = True
        Me.gchqno.VisibleIndex = 7
        Me.gchqno.Width = 80
        '
        'gremarks
        '
        Me.gremarks.Caption = "Remarks"
        Me.gremarks.FieldName = "REMARKS"
        Me.gremarks.Name = "gremarks"
        Me.gremarks.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gremarks.Visible = True
        Me.gremarks.VisibleIndex = 8
        Me.gremarks.Width = 180
        '
        'GSECONDARY
        '
        Me.GSECONDARY.Caption = "Group Name"
        Me.GSECONDARY.FieldName = "SECONDARY"
        Me.GSECONDARY.Name = "GSECONDARY"
        Me.GSECONDARY.Visible = True
        Me.GSECONDARY.VisibleIndex = 9
        Me.GSECONDARY.Width = 120
        '
        'guser
        '
        Me.guser.Caption = "User Name"
        Me.guser.FieldName = "USERNAME"
        Me.guser.ImageIndex = 2
        Me.guser.Name = "guser"
        Me.guser.Visible = True
        Me.guser.VisibleIndex = 10
        Me.guser.Width = 110
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        Me.imageList1.Images.SetKeyName(2, "Customer.ico")
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(574, 58)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 4
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
        Me.cmdok.Location = New System.Drawing.Point(559, 534)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
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
        Me.cmdexit.Location = New System.Drawing.Point(645, 534)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'txtcrtotal
        '
        Me.txtcrtotal.BackColor = System.Drawing.Color.White
        Me.txtcrtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtcrtotal.Location = New System.Drawing.Point(1059, 525)
        Me.txtcrtotal.Name = "txtcrtotal"
        Me.txtcrtotal.ReadOnly = True
        Me.txtcrtotal.Size = New System.Drawing.Size(136, 23)
        Me.txtcrtotal.TabIndex = 443
        Me.txtcrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdrtotal
        '
        Me.txtdrtotal.BackColor = System.Drawing.Color.White
        Me.txtdrtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtdrtotal.Location = New System.Drawing.Point(922, 525)
        Me.txtdrtotal.Name = "txtdrtotal"
        Me.txtdrtotal.ReadOnly = True
        Me.txtdrtotal.Size = New System.Drawing.Size(136, 23)
        Me.txtdrtotal.TabIndex = 442
        Me.txtdrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(885, 528)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "Total"
        '
        'chkdetails
        '
        Me.chkdetails.AutoSize = True
        Me.chkdetails.BackColor = System.Drawing.Color.Transparent
        Me.chkdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdetails.Location = New System.Drawing.Point(1106, 35)
        Me.chkdetails.Name = "chkdetails"
        Me.chkdetails.Size = New System.Drawing.Size(61, 19)
        Me.chkdetails.TabIndex = 440
        Me.chkdetails.Text = "Details"
        Me.chkdetails.UseVisualStyleBackColor = False
        '
        'lbldrcropening
        '
        Me.lbldrcropening.AutoSize = True
        Me.lbldrcropening.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcropening.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcropening.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcropening.Location = New System.Drawing.Point(1197, 64)
        Me.lbldrcropening.Name = "lbldrcropening"
        Me.lbldrcropening.Size = New System.Drawing.Size(0, 15)
        Me.lbldrcropening.TabIndex = 439
        '
        'txtopening
        '
        Me.txtopening.BackColor = System.Drawing.Color.White
        Me.txtopening.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopening.ForeColor = System.Drawing.Color.Black
        Me.txtopening.Location = New System.Drawing.Point(1059, 60)
        Me.txtopening.Name = "txtopening"
        Me.txtopening.ReadOnly = True
        Me.txtopening.Size = New System.Drawing.Size(136, 23)
        Me.txtopening.TabIndex = 438
        Me.txtopening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblopbal
        '
        Me.lblopbal.AutoSize = True
        Me.lblopbal.BackColor = System.Drawing.Color.Transparent
        Me.lblopbal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopbal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopbal.Location = New System.Drawing.Point(1008, 64)
        Me.lblopbal.Name = "lblopbal"
        Me.lblopbal.Size = New System.Drawing.Size(47, 15)
        Me.lblopbal.TabIndex = 437
        Me.lblopbal.Text = "O/P Bal"
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(1197, 554)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 15)
        Me.lbldrcrclosing.TabIndex = 436
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Black
        Me.txttotal.Location = New System.Drawing.Point(1059, 551)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(136, 23)
        Me.txttotal.TabIndex = 435
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(985, 555)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(67, 15)
        Me.lbln.TabIndex = 434
        Me.lbln.Text = "Closing Bal."
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.chkdate.Location = New System.Drawing.Point(385, 34)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(55, 21)
        Me.chkdate.TabIndex = 1
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(481, 58)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 24)
        Me.dtto.TabIndex = 3
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(457, 61)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(21, 17)
        Me.lblto.TabIndex = 432
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(480, 32)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 24)
        Me.dtfrom.TabIndex = 2
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(442, 35)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(37, 17)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ExcelExport, Me.ToolStripSeparator1, Me.TOOLDAILY, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 430
        Me.ToolStrip1.Text = "v"
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
        'TOOLDAILY
        '
        Me.TOOLDAILY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TOOLDAILY.Image = CType(resources.GetObject("TOOLDAILY.Image"), System.Drawing.Image)
        Me.TOOLDAILY.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDAILY.Name = "TOOLDAILY"
        Me.TOOLDAILY.Size = New System.Drawing.Size(60, 22)
        Me.TOOLDAILY.Text = "Daily - F4"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(11, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(139, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Bank Register"
        '
        'GCITYNAME
        '
        Me.GCITYNAME.Caption = "City Name"
        Me.GCITYNAME.FieldName = "CITYNAME"
        Me.GCITYNAME.Name = "GCITYNAME"
        '
        'BankRegisterDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1284, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BankRegisterDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bank Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txtcrtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtdrtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkdetails As System.Windows.Forms.CheckBox
    Friend WithEvents lbldrcropening As System.Windows.Forms.Label
    Friend WithEvents txtopening As System.Windows.Forms.TextBox
    Friend WithEvents lblopbal As System.Windows.Forms.Label
    Friend WithEvents lbldrcrclosing As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbln As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtype As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gbillinitials As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gbillno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents greg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gremarks As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents gchqno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents guser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRUNNINGBAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLDAILY As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents GSECONDARY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITYNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
