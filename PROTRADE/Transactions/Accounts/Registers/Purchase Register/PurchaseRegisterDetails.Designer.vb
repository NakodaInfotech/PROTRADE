<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseRegisterDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseRegisterDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillinitials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.greg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gremarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUSER = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.lbl = New System.Windows.Forms.Label()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1024, 582)
        Me.BlendPanel1.TabIndex = 5
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.Location = New System.Drawing.Point(668, 59)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 450
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(11, 99)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1002, 417)
        Me.griddetails.TabIndex = 449
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gDate, Me.gname, Me.gtype, Me.gbillinitials, Me.GREFNO, Me.gdr, Me.gcr, Me.gbillno, Me.greg, Me.gremarks, Me.GUSER})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Images = Me.imageList1
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
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
        Me.gDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gDate.OptionsColumn.AllowMove = False
        Me.gDate.Visible = True
        Me.gDate.VisibleIndex = 0
        Me.gDate.Width = 70
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "Name"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.OptionsColumn.AllowMove = False
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 230
        '
        'gtype
        '
        Me.gtype.Caption = "Type"
        Me.gtype.FieldName = "Type"
        Me.gtype.Name = "gtype"
        Me.gtype.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gtype.OptionsColumn.AllowIncrementalSearch = False
        Me.gtype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gtype.OptionsColumn.AllowMove = False
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
        Me.gbillinitials.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gbillinitials.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gbillinitials.OptionsColumn.AllowMove = False
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 3
        Me.gbillinitials.Width = 80
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 4
        Me.GREFNO.Width = 80
        '
        'gdr
        '
        Me.gdr.Caption = "Debit"
        Me.gdr.DisplayFormat.FormatString = "0.00"
        Me.gdr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gdr.FieldName = "Debit"
        Me.gdr.Name = "gdr"
        Me.gdr.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdr.OptionsColumn.AllowMove = False
        Me.gdr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:0.00}")})
        Me.gdr.Visible = True
        Me.gdr.VisibleIndex = 5
        Me.gdr.Width = 90
        '
        'gcr
        '
        Me.gcr.Caption = "Credit"
        Me.gcr.DisplayFormat.FormatString = "0.00"
        Me.gcr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcr.FieldName = "Credit"
        Me.gcr.Name = "gcr"
        Me.gcr.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.OptionsColumn.AllowMove = False
        Me.gcr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:0.00}")})
        Me.gcr.Visible = True
        Me.gcr.VisibleIndex = 6
        Me.gcr.Width = 90
        '
        'gbillno
        '
        Me.gbillno.Caption = "Bill no"
        Me.gbillno.FieldName = "BILL"
        Me.gbillno.ImageIndex = 1
        Me.gbillno.Name = "gbillno"
        '
        'greg
        '
        Me.greg.Caption = "Reg Name"
        Me.greg.FieldName = "REGTYPE"
        Me.greg.Name = "greg"
        '
        'gremarks
        '
        Me.gremarks.Caption = "Remarks"
        Me.gremarks.FieldName = "REMARKS"
        Me.gremarks.Name = "gremarks"
        Me.gremarks.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gremarks.Visible = True
        Me.gremarks.VisibleIndex = 7
        Me.gremarks.Width = 140
        '
        'GUSER
        '
        Me.GUSER.Caption = "User Name"
        Me.GUSER.FieldName = "USERNAME"
        Me.GUSER.ImageIndex = 2
        Me.GUSER.Name = "GUSER"
        Me.GUSER.Visible = True
        Me.GUSER.VisibleIndex = 8
        Me.GUSER.Width = 90
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
        Me.cmdshowdetails.Location = New System.Drawing.Point(574, 59)
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
        Me.cmdok.Location = New System.Drawing.Point(429, 532)
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
        Me.cmdexit.Location = New System.Drawing.Point(515, 532)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'txtcrtotal
        '
        Me.txtcrtotal.BackColor = System.Drawing.Color.White
        Me.txtcrtotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtcrtotal.Location = New System.Drawing.Point(839, 522)
        Me.txtcrtotal.Name = "txtcrtotal"
        Me.txtcrtotal.ReadOnly = True
        Me.txtcrtotal.Size = New System.Drawing.Size(100, 22)
        Me.txtcrtotal.TabIndex = 443
        Me.txtcrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdrtotal
        '
        Me.txtdrtotal.BackColor = System.Drawing.Color.White
        Me.txtdrtotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtdrtotal.Location = New System.Drawing.Point(739, 522)
        Me.txtdrtotal.Name = "txtdrtotal"
        Me.txtdrtotal.ReadOnly = True
        Me.txtdrtotal.Size = New System.Drawing.Size(100, 22)
        Me.txtdrtotal.TabIndex = 442
        Me.txtdrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(703, 525)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 14)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "Total"
        '
        'chkdetails
        '
        Me.chkdetails.AutoSize = True
        Me.chkdetails.BackColor = System.Drawing.Color.Transparent
        Me.chkdetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdetails.Location = New System.Drawing.Point(839, 39)
        Me.chkdetails.Name = "chkdetails"
        Me.chkdetails.Size = New System.Drawing.Size(66, 18)
        Me.chkdetails.TabIndex = 440
        Me.chkdetails.Text = "Details"
        Me.chkdetails.UseVisualStyleBackColor = False
        '
        'lbldrcropening
        '
        Me.lbldrcropening.AutoSize = True
        Me.lbldrcropening.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcropening.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcropening.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcropening.Location = New System.Drawing.Point(941, 67)
        Me.lbldrcropening.Name = "lbldrcropening"
        Me.lbldrcropening.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcropening.TabIndex = 439
        Me.lbldrcropening.Visible = False
        '
        'txtopening
        '
        Me.txtopening.BackColor = System.Drawing.Color.White
        Me.txtopening.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopening.ForeColor = System.Drawing.Color.Black
        Me.txtopening.Location = New System.Drawing.Point(839, 64)
        Me.txtopening.Name = "txtopening"
        Me.txtopening.ReadOnly = True
        Me.txtopening.Size = New System.Drawing.Size(100, 22)
        Me.txtopening.TabIndex = 438
        Me.txtopening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtopening.Visible = False
        '
        'lblopbal
        '
        Me.lblopbal.AutoSize = True
        Me.lblopbal.BackColor = System.Drawing.Color.Transparent
        Me.lblopbal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopbal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopbal.Location = New System.Drawing.Point(789, 67)
        Me.lblopbal.Name = "lblopbal"
        Me.lblopbal.Size = New System.Drawing.Size(45, 14)
        Me.lblopbal.TabIndex = 437
        Me.lblopbal.Text = "O/P Bal"
        Me.lblopbal.Visible = False
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(941, 551)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcrclosing.TabIndex = 436
        Me.lbldrcrclosing.Visible = False
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Black
        Me.txttotal.Location = New System.Drawing.Point(839, 548)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 435
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotal.Visible = False
        '
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(764, 551)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(64, 14)
        Me.lbln.TabIndex = 434
        Me.lbln.Text = "Closing Bal."
        Me.lbln.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(393, 39)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 1
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(481, 63)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 3
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(457, 66)
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
        Me.dtfrom.Location = New System.Drawing.Point(480, 37)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 2
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(442, 40)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1024, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(11, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(181, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Purchase Register"
        '
        'PurchaseRegisterDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1024, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PurchaseRegisterDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Purchase Register"
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
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gDate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gtype As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillinitials As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdr As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gcr As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents greg As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gremarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUSER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
End Class
