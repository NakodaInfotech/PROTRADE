<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TDSChallan
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDAPPLY = New System.Windows.Forms.Button()
        Me.TXTBSRCODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTCHQNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTCHNO = New System.Windows.Forms.TextBox()
        Me.CHDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillinitials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHQNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBANKNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMPNOPCMP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CHKUNPAID = New System.Windows.Forms.CheckBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblname = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.LBLBALEFROM = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDAPPLY)
        Me.BlendPanel1.Controls.Add(Me.TXTBSRCODE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTCHQNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTCHNO)
        Me.BlendPanel1.Controls.Add(Me.CHDATE)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CHKUNPAID)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.LBLBALEFROM)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDAPPLY
        '
        Me.CMDAPPLY.BackColor = System.Drawing.Color.Transparent
        Me.CMDAPPLY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAPPLY.FlatAppearance.BorderSize = 0
        Me.CMDAPPLY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAPPLY.ForeColor = System.Drawing.Color.Black
        Me.CMDAPPLY.Location = New System.Drawing.Point(1036, 51)
        Me.CMDAPPLY.Name = "CMDAPPLY"
        Me.CMDAPPLY.Size = New System.Drawing.Size(93, 28)
        Me.CMDAPPLY.TabIndex = 9
        Me.CMDAPPLY.Text = "Apply for All"
        Me.CMDAPPLY.UseVisualStyleBackColor = False
        '
        'TXTBSRCODE
        '
        Me.TXTBSRCODE.BackColor = System.Drawing.Color.White
        Me.TXTBSRCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBSRCODE.Location = New System.Drawing.Point(946, 59)
        Me.TXTBSRCODE.Name = "TXTBSRCODE"
        Me.TXTBSRCODE.Size = New System.Drawing.Size(84, 22)
        Me.TXTBSRCODE.TabIndex = 8
        Me.TXTBSRCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(856, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 14)
        Me.Label2.TabIndex = 823
        Me.Label2.Text = "BSR Code"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTCHQNO
        '
        Me.TXTCHQNO.BackColor = System.Drawing.Color.White
        Me.TXTCHQNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHQNO.Location = New System.Drawing.Point(946, 34)
        Me.TXTCHQNO.Name = "TXTCHQNO"
        Me.TXTCHQNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTCHQNO.TabIndex = 7
        Me.TXTCHQNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(856, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 822
        Me.Label1.Text = "Chq No"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTCHNO
        '
        Me.TXTCHNO.BackColor = System.Drawing.Color.White
        Me.TXTCHNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHNO.Location = New System.Drawing.Point(767, 34)
        Me.TXTCHNO.Name = "TXTCHNO"
        Me.TXTCHNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTCHNO.TabIndex = 5
        Me.TXTCHNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHDATE
        '
        Me.CHDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.CHDATE.Location = New System.Drawing.Point(767, 59)
        Me.CHDATE.Name = "CHDATE"
        Me.CHDATE.Size = New System.Drawing.Size(84, 22)
        Me.CHDATE.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(715, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 820
        Me.Label7.Text = "Ch Date"
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(1237, 38)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(12, 22)
        Me.TXTADD.TabIndex = 484
        Me.TXTADD.Visible = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(15, 93)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1205, 452)
        Me.griddetails.TabIndex = 10
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gDate, Me.gname, Me.gbillinitials, Me.GPARTYBILLNO, Me.GPANNO, Me.GBILLAMT, Me.GTDS, Me.GCHALLANNO, Me.GCHALLANDATE, Me.GCHQNO, Me.GBANKNAME, Me.GCMPNOPCMP})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsMenu.EnableColumnMenu = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.OptionsView.ShowFooter = True
        Me.gridregister.OptionsView.ShowGroupPanel = False
        '
        'gDate
        '
        Me.gDate.Caption = "Date"
        Me.gDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gDate.FieldName = "DATE"
        Me.gDate.Name = "gDate"
        Me.gDate.OptionsColumn.AllowEdit = False
        Me.gDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.gDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.Visible = True
        Me.gDate.VisibleIndex = 0
        Me.gDate.Width = 65
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowEdit = False
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 220
        '
        'gbillinitials
        '
        Me.gbillinitials.Caption = "Bill No."
        Me.gbillinitials.FieldName = "BILLINITIALS"
        Me.gbillinitials.ImageIndex = 1
        Me.gbillinitials.Name = "gbillinitials"
        Me.gbillinitials.OptionsColumn.AllowEdit = False
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 2
        '
        'GPARTYBILLNO
        '
        Me.GPARTYBILLNO.Caption = "Party Bill No"
        Me.GPARTYBILLNO.FieldName = "PARTYBILLNO"
        Me.GPARTYBILLNO.Name = "GPARTYBILLNO"
        Me.GPARTYBILLNO.OptionsColumn.AllowEdit = False
        Me.GPARTYBILLNO.Visible = True
        Me.GPARTYBILLNO.VisibleIndex = 3
        Me.GPARTYBILLNO.Width = 80
        '
        'GPANNO
        '
        Me.GPANNO.Caption = "Pan No."
        Me.GPANNO.FieldName = "PANNO"
        Me.GPANNO.Name = "GPANNO"
        Me.GPANNO.OptionsColumn.AllowEdit = False
        Me.GPANNO.Visible = True
        Me.GPANNO.VisibleIndex = 4
        '
        'GBILLAMT
        '
        Me.GBILLAMT.Caption = "Bill Amt"
        Me.GBILLAMT.DisplayFormat.FormatString = "0.00"
        Me.GBILLAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBILLAMT.FieldName = "BILLAMT"
        Me.GBILLAMT.Name = "GBILLAMT"
        Me.GBILLAMT.OptionsColumn.AllowEdit = False
        Me.GBILLAMT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GBILLAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBILLAMT.Visible = True
        Me.GBILLAMT.VisibleIndex = 5
        '
        'GTDS
        '
        Me.GTDS.Caption = "TDS Amt"
        Me.GTDS.DisplayFormat.FormatString = "0.00"
        Me.GTDS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDS.FieldName = "TDSAMT"
        Me.GTDS.Name = "GTDS"
        Me.GTDS.OptionsColumn.AllowEdit = False
        Me.GTDS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GTDS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTDS.Visible = True
        Me.GTDS.VisibleIndex = 6
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No"
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 7
        Me.GCHALLANNO.Width = 80
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Challan Date"
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 8
        Me.GCHALLANDATE.Width = 80
        '
        'GCHQNO
        '
        Me.GCHQNO.Caption = "Chq No"
        Me.GCHQNO.FieldName = "CHQNO"
        Me.GCHQNO.Name = "GCHQNO"
        Me.GCHQNO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHQNO.Visible = True
        Me.GCHQNO.VisibleIndex = 9
        Me.GCHQNO.Width = 65
        '
        'GBANKNAME
        '
        Me.GBANKNAME.Caption = "BSR Code"
        Me.GBANKNAME.FieldName = "BANKNAME"
        Me.GBANKNAME.Name = "GBANKNAME"
        Me.GBANKNAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GBANKNAME.Visible = True
        Me.GBANKNAME.VisibleIndex = 10
        Me.GBANKNAME.Width = 110
        '
        'GCMPNOPCMP
        '
        Me.GCMPNOPCMP.Caption = "Company/Non Company"
        Me.GCMPNOPCMP.FieldName = "CMPNONCMP"
        Me.GCMPNOPCMP.Name = "GCMPNOPCMP"
        Me.GCMPNOPCMP.OptionsColumn.AllowEdit = False
        Me.GCMPNOPCMP.Visible = True
        Me.GCMPNOPCMP.VisibleIndex = 11
        Me.GCMPNOPCMP.Width = 150
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(1203, 38)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBACCCODE.TabIndex = 483
        Me.CMBACCCODE.Visible = False
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(489, 56)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(93, 28)
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
        Me.cmdok.Location = New System.Drawing.Point(536, 550)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 11
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
        Me.cmdexit.Location = New System.Drawing.Point(622, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CHKUNPAID
        '
        Me.CHKUNPAID.AutoSize = True
        Me.CHKUNPAID.BackColor = System.Drawing.Color.Transparent
        Me.CHKUNPAID.Checked = True
        Me.CHKUNPAID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKUNPAID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKUNPAID.Location = New System.Drawing.Point(498, 36)
        Me.CHKUNPAID.Name = "CHKUNPAID"
        Me.CHKUNPAID.Size = New System.Drawing.Size(66, 18)
        Me.CHKUNPAID.TabIndex = 440
        Me.CHKUNPAID.Text = "Unpaid"
        Me.CHKUNPAID.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(309, 40)
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
        Me.dtto.Location = New System.Drawing.Point(399, 59)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 3
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(377, 63)
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
        Me.dtfrom.Location = New System.Drawing.Point(399, 34)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(84, 22)
        Me.dtfrom.TabIndex = 2
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(361, 38)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 430
        Me.ToolStrip1.Text = "v"
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
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(14, 42)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(39, 14)
        Me.lblname.TabIndex = 429
        Me.lblname.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(56, 38)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(234, 22)
        Me.cmbname.TabIndex = 0
        '
        'LBLBALEFROM
        '
        Me.LBLBALEFROM.BackColor = System.Drawing.Color.Transparent
        Me.LBLBALEFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBALEFROM.ForeColor = System.Drawing.Color.Black
        Me.LBLBALEFROM.Location = New System.Drawing.Point(677, 38)
        Me.LBLBALEFROM.Name = "LBLBALEFROM"
        Me.LBLBALEFROM.Size = New System.Drawing.Size(88, 14)
        Me.LBLBALEFROM.TabIndex = 821
        Me.LBLBALEFROM.Text = "Challan No"
        Me.LBLBALEFROM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TDSChallan
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TDSChallan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TDS Challan"
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
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gDate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillinitials As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CHKUNPAID As System.Windows.Forms.CheckBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents GBILLAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBANKNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents GPARTYBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMPNOPCMP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDAPPLY As Button
    Friend WithEvents TXTBSRCODE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTCHQNO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTCHNO As TextBox
    Friend WithEvents CHDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents LBLBALEFROM As Label
End Class
