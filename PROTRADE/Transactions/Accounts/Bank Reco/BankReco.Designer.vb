<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BankReco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankReco))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTTOTALCR = New System.Windows.Forms.TextBox()
        Me.TXTTOTALDR = New System.Windows.Forms.TextBox()
        Me.LBLBOOKDRCR = New System.Windows.Forms.Label()
        Me.LBLBANKDRCR = New System.Windows.Forms.Label()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridBANKRECO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grecodate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.billinitials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gchqno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYEARID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lblbal = New System.Windows.Forms.Label()
        Me.txtbal = New System.Windows.Forms.TextBox()
        Me.lblClosingAmt = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcr = New System.Windows.Forms.TextBox()
        Me.txtdr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbalcmp = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLUPLOAD = New System.Windows.Forms.ToolStripButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTTEMPBAL = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridBANKRECO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTTEMPBAL)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALCR)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALDR)
        Me.BlendPanel1.Controls.Add(Me.LBLBOOKDRCR)
        Me.BlendPanel1.Controls.Add(Me.LBLBANKDRCR)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lblbal)
        Me.BlendPanel1.Controls.Add(Me.txtbal)
        Me.BlendPanel1.Controls.Add(Me.lblClosingAmt)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.txtcr)
        Me.BlendPanel1.Controls.Add(Me.txtdr)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.txtbalcmp)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.txtname)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.chkAll)
        Me.BlendPanel1.Controls.Add(Me.ShapeContainer1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1024, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(25, 495)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 14)
        Me.Label3.TabIndex = 463
        Me.Label3.Text = "Press F5 to copy Date in Bank Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(255, 499)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 460
        Me.Label1.Text = "Total Amount "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTTOTALCR
        '
        Me.TXTTOTALCR.BackColor = System.Drawing.Color.White
        Me.TXTTOTALCR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCR.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALCR.Location = New System.Drawing.Point(434, 495)
        Me.TXTTOTALCR.Name = "TXTTOTALCR"
        Me.TXTTOTALCR.ReadOnly = True
        Me.TXTTOTALCR.Size = New System.Drawing.Size(89, 22)
        Me.TXTTOTALCR.TabIndex = 462
        Me.TXTTOTALCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALDR
        '
        Me.TXTTOTALDR.BackColor = System.Drawing.Color.White
        Me.TXTTOTALDR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALDR.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALDR.Location = New System.Drawing.Point(339, 495)
        Me.TXTTOTALDR.Name = "TXTTOTALDR"
        Me.TXTTOTALDR.ReadOnly = True
        Me.TXTTOTALDR.Size = New System.Drawing.Size(89, 22)
        Me.TXTTOTALDR.TabIndex = 461
        Me.TXTTOTALDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLBOOKDRCR
        '
        Me.LBLBOOKDRCR.AutoSize = True
        Me.LBLBOOKDRCR.BackColor = System.Drawing.Color.Transparent
        Me.LBLBOOKDRCR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBOOKDRCR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLBOOKDRCR.Location = New System.Drawing.Point(814, 499)
        Me.LBLBOOKDRCR.Name = "LBLBOOKDRCR"
        Me.LBLBOOKDRCR.Size = New System.Drawing.Size(0, 14)
        Me.LBLBOOKDRCR.TabIndex = 459
        '
        'LBLBANKDRCR
        '
        Me.LBLBANKDRCR.AutoSize = True
        Me.LBLBANKDRCR.BackColor = System.Drawing.Color.Transparent
        Me.LBLBANKDRCR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBANKDRCR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLBANKDRCR.Location = New System.Drawing.Point(814, 552)
        Me.LBLBANKDRCR.Name = "LBLBANKDRCR"
        Me.LBLBANKDRCR.Size = New System.Drawing.Size(0, 14)
        Me.LBLBANKDRCR.TabIndex = 458
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshowdetails.Location = New System.Drawing.Point(848, 54)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 456
        Me.cmdshowdetails.Text = "Show &Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(755, 57)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 454
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(731, 61)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(18, 14)
        Me.lblto.TabIndex = 455
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(637, 57)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 22)
        Me.dtfrom.TabIndex = 453
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(599, 61)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(33, 14)
        Me.lblfrom.TabIndex = 451
        Me.lblfrom.Text = "From"
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(22, 87)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridBANKRECO
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.DateEdit})
        Me.griddetails.Size = New System.Drawing.Size(985, 402)
        Me.griddetails.TabIndex = 450
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridBANKRECO})
        '
        'gridBANKRECO
        '
        Me.gridBANKRECO.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBANKRECO.Appearance.Row.Options.UseFont = True
        Me.gridBANKRECO.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridBANKRECO.Appearance.ViewCaption.Options.UseFont = True
        Me.gridBANKRECO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gDate, Me.gname, Me.gtype, Me.grecodate, Me.gdr, Me.gcr, Me.billinitials, Me.gchqno, Me.GRIDSRNO, Me.GBILLNO, Me.GYEARID})
        Me.gridBANKRECO.GridControl = Me.griddetails
        Me.gridBANKRECO.Images = Me.imageList1
        Me.gridBANKRECO.Name = "gridBANKRECO"
        Me.gridBANKRECO.OptionsCustomization.AllowColumnMoving = False
        Me.gridBANKRECO.OptionsCustomization.AllowColumnResizing = False
        Me.gridBANKRECO.OptionsCustomization.AllowGroup = False
        Me.gridBANKRECO.OptionsMenu.EnableColumnMenu = False
        Me.gridBANKRECO.OptionsView.AllowCellMerge = True
        Me.gridBANKRECO.OptionsView.ShowFooter = True
        Me.gridBANKRECO.OptionsView.ShowGroupPanel = False
        '
        'gDate
        '
        Me.gDate.Caption = "Date"
        Me.gDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gDate.FieldName = "BillDate"
        Me.gDate.Name = "gDate"
        Me.gDate.OptionsColumn.AllowEdit = False
        Me.gDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.OptionsColumn.AllowMove = False
        Me.gDate.OptionsColumn.ReadOnly = True
        Me.gDate.Visible = True
        Me.gDate.VisibleIndex = 0
        Me.gDate.Width = 73
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "Name"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowEdit = False
        Me.gname.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.OptionsColumn.AllowMove = False
        Me.gname.OptionsColumn.ReadOnly = True
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 352
        '
        'gtype
        '
        Me.gtype.Caption = "Type"
        Me.gtype.FieldName = "Type"
        Me.gtype.Name = "gtype"
        Me.gtype.OptionsColumn.AllowEdit = False
        Me.gtype.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gtype.OptionsColumn.AllowIncrementalSearch = False
        Me.gtype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gtype.OptionsColumn.AllowMove = False
        Me.gtype.OptionsColumn.ReadOnly = True
        Me.gtype.Visible = True
        Me.gtype.VisibleIndex = 2
        Me.gtype.Width = 88
        '
        'grecodate
        '
        Me.grecodate.Caption = "Bank Date"
        Me.grecodate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.grecodate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.grecodate.FieldName = "RecoDate"
        Me.grecodate.Name = "grecodate"
        Me.grecodate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.grecodate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.grecodate.Visible = True
        Me.grecodate.VisibleIndex = 3
        Me.grecodate.Width = 100
        '
        'gdr
        '
        Me.gdr.Caption = "Debit"
        Me.gdr.DisplayFormat.FormatString = "0.00"
        Me.gdr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gdr.FieldName = "dr"
        Me.gdr.Name = "gdr"
        Me.gdr.OptionsColumn.AllowEdit = False
        Me.gdr.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdr.OptionsColumn.AllowMove = False
        Me.gdr.OptionsColumn.ReadOnly = True
        Me.gdr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gdr.Visible = True
        Me.gdr.VisibleIndex = 4
        Me.gdr.Width = 102
        '
        'gcr
        '
        Me.gcr.Caption = "Credit"
        Me.gcr.DisplayFormat.FormatString = "0.00"
        Me.gcr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcr.FieldName = "cr"
        Me.gcr.Name = "gcr"
        Me.gcr.OptionsColumn.AllowEdit = False
        Me.gcr.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.OptionsColumn.AllowMove = False
        Me.gcr.OptionsColumn.ReadOnly = True
        Me.gcr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gcr.Visible = True
        Me.gcr.VisibleIndex = 5
        Me.gcr.Width = 102
        '
        'billinitials
        '
        Me.billinitials.Caption = "Bill No."
        Me.billinitials.FieldName = "BillInitials"
        Me.billinitials.ImageIndex = 1
        Me.billinitials.Name = "billinitials"
        Me.billinitials.OptionsColumn.AllowEdit = False
        Me.billinitials.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.billinitials.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.billinitials.OptionsColumn.AllowMove = False
        Me.billinitials.OptionsColumn.ReadOnly = True
        Me.billinitials.Visible = True
        Me.billinitials.VisibleIndex = 6
        Me.billinitials.Width = 83
        '
        'gchqno
        '
        Me.gchqno.Caption = "Chq. No."
        Me.gchqno.FieldName = "ChqNo"
        Me.gchqno.Name = "gchqno"
        Me.gchqno.OptionsColumn.AllowEdit = False
        Me.gchqno.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gchqno.OptionsColumn.AllowMove = False
        Me.gchqno.OptionsColumn.ReadOnly = True
        Me.gchqno.Visible = True
        Me.gchqno.VisibleIndex = 7
        Me.gchqno.Width = 110
        '
        'GRIDSRNO
        '
        Me.GRIDSRNO.Caption = "GridColumn1"
        Me.GRIDSRNO.FieldName = "GridSrno"
        Me.GRIDSRNO.Name = "GRIDSRNO"
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "BILLNO"
        Me.GBILLNO.FieldName = "BillNo"
        Me.GBILLNO.Name = "GBILLNO"
        '
        'GYEARID
        '
        Me.GYEARID.Caption = "YEARID"
        Me.GYEARID.FieldName = "YEARID"
        Me.GYEARID.Name = "GYEARID"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        Me.imageList1.Images.SetKeyName(2, "Customer.ico")
        '
        'DateEdit
        '
        Me.DateEdit.AutoHeight = False
        Me.DateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.DateEdit.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit.CalendarTimeProperties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.DateEdit.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.DateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit.EditFormat.FormatString = "dd/MM/yyyy"
        Me.DateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit.Name = "DateEdit"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(234, 544)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 322
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
        Me.cmdexit.Location = New System.Drawing.Point(318, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 323
        Me.cmdexit.Text = "&Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lblbal
        '
        Me.lblbal.AutoSize = True
        Me.lblbal.BackColor = System.Drawing.Color.Transparent
        Me.lblbal.Location = New System.Drawing.Point(1012, 512)
        Me.lblbal.Name = "lblbal"
        Me.lblbal.Size = New System.Drawing.Size(0, 13)
        Me.lblbal.TabIndex = 320
        Me.lblbal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtbal
        '
        Me.txtbal.BackColor = System.Drawing.Color.White
        Me.txtbal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbal.ForeColor = System.Drawing.Color.Black
        Me.txtbal.Location = New System.Drawing.Point(722, 548)
        Me.txtbal.Name = "txtbal"
        Me.txtbal.ReadOnly = True
        Me.txtbal.Size = New System.Drawing.Size(89, 22)
        Me.txtbal.TabIndex = 319
        Me.txtbal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblClosingAmt
        '
        Me.lblClosingAmt.AutoSize = True
        Me.lblClosingAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblClosingAmt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClosingAmt.Location = New System.Drawing.Point(551, 523)
        Me.lblClosingAmt.Name = "lblClosingAmt"
        Me.lblClosingAmt.Size = New System.Drawing.Size(155, 14)
        Me.lblClosingAmt.TabIndex = 311
        Me.lblClosingAmt.Text = "Amount Not Reflected in Bank"
        Me.lblClosingAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(603, 551)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 14)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "Balance as per Bank"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtcr
        '
        Me.txtcr.BackColor = System.Drawing.Color.White
        Me.txtcr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcr.ForeColor = System.Drawing.Color.Black
        Me.txtcr.Location = New System.Drawing.Point(817, 519)
        Me.txtcr.Name = "txtcr"
        Me.txtcr.ReadOnly = True
        Me.txtcr.Size = New System.Drawing.Size(89, 22)
        Me.txtcr.TabIndex = 317
        Me.txtcr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdr
        '
        Me.txtdr.BackColor = System.Drawing.Color.White
        Me.txtdr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdr.ForeColor = System.Drawing.Color.Black
        Me.txtdr.Location = New System.Drawing.Point(722, 519)
        Me.txtdr.Name = "txtdr"
        Me.txtdr.ReadOnly = True
        Me.txtdr.Size = New System.Drawing.Size(89, 22)
        Me.txtdr.TabIndex = 312
        Me.txtdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(545, 499)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 14)
        Me.Label2.TabIndex = 314
        Me.Label2.Text = "Balance as per Company Books"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtbalcmp
        '
        Me.txtbalcmp.BackColor = System.Drawing.Color.White
        Me.txtbalcmp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalcmp.ForeColor = System.Drawing.Color.Black
        Me.txtbalcmp.Location = New System.Drawing.Point(722, 495)
        Me.txtbalcmp.Name = "txtbalcmp"
        Me.txtbalcmp.ReadOnly = True
        Me.txtbalcmp.Size = New System.Drawing.Size(89, 22)
        Me.txtbalcmp.TabIndex = 315
        Me.txtbalcmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.TOOLUPLOAD})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1024, 25)
        Me.ToolStrip1.TabIndex = 307
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
        'TOOLUPLOAD
        '
        Me.TOOLUPLOAD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLUPLOAD.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.TOOLUPLOAD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLUPLOAD.Name = "TOOLUPLOAD"
        Me.TOOLUPLOAD.Size = New System.Drawing.Size(23, 22)
        Me.TOOLUPLOAD.Text = "Upload Excel Statement"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 14)
        Me.Label5.TabIndex = 305
        Me.Label5.Text = "Bank Name"
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.Color.Black
        Me.txtname.Location = New System.Drawing.Point(96, 57)
        Me.txtname.Name = "txtname"
        Me.txtname.ReadOnly = True
        Me.txtname.Size = New System.Drawing.Size(362, 22)
        Me.txtname.TabIndex = 306
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(13, 28)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(184, 20)
        Me.lbl.TabIndex = 304
        Me.lbl.Text = "Pass Book Reconciler"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(464, 59)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(39, 18)
        Me.chkAll.TabIndex = 303
        Me.chkAll.Text = "&All"
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1024, 582)
        Me.ShapeContainer1.TabIndex = 321
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 538
        Me.LineShape1.X2 = 929
        Me.LineShape1.Y1 = 544
        Me.LineShape1.Y2 = 544
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(526, 527)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 14)
        Me.Label6.TabIndex = 465
        '
        'TXTTEMPBAL
        '
        Me.TXTTEMPBAL.BackColor = System.Drawing.Color.White
        Me.TXTTEMPBAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTEMPBAL.ForeColor = System.Drawing.Color.Black
        Me.TXTTEMPBAL.Location = New System.Drawing.Point(434, 523)
        Me.TXTTEMPBAL.Name = "TXTTEMPBAL"
        Me.TXTTEMPBAL.ReadOnly = True
        Me.TXTTEMPBAL.Size = New System.Drawing.Size(89, 22)
        Me.TXTTEMPBAL.TabIndex = 464
        Me.TXTTEMPBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BankReco
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1024, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "BankReco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bank Reconciler"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridBANKRECO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblbal As System.Windows.Forms.Label
    Friend WithEvents txtbal As System.Windows.Forms.TextBox
    Friend WithEvents lblClosingAmt As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcr As System.Windows.Forms.TextBox
    Friend WithEvents txtdr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbalcmp As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridBANKRECO As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gDate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gtype As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdr As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gcr As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grecodate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gchqno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents billinitials As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LBLBOOKDRCR As System.Windows.Forms.Label
    Friend WithEvents LBLBANKDRCR As System.Windows.Forms.Label
    Friend WithEvents GYEARID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLUPLOAD As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALCR As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALDR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTTEMPBAL As TextBox
End Class
