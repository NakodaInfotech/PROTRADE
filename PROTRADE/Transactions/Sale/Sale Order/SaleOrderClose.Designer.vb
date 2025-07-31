<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SaleOrderClose
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.RBENTERED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.CMDAPPLY = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DTCLOSEDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBMAINREASON = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCLOSED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAGENTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTOCKPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTOCKMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFORWARD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSEDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREASON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBREASON = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GNOTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CMBREASON, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RBENTERED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.CMDAPPLY)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.DTCLOSEDATE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBMAINREASON)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'RBENTERED
        '
        Me.RBENTERED.AutoSize = True
        Me.RBENTERED.BackColor = System.Drawing.Color.Transparent
        Me.RBENTERED.Location = New System.Drawing.Point(193, 31)
        Me.RBENTERED.Name = "RBENTERED"
        Me.RBENTERED.Size = New System.Drawing.Size(66, 19)
        Me.RBENTERED.TabIndex = 807
        Me.RBENTERED.Text = "Entered"
        Me.RBENTERED.UseVisualStyleBackColor = False
        Me.RBENTERED.Visible = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(118, 31)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 806
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'CMDAPPLY
        '
        Me.CMDAPPLY.BackColor = System.Drawing.Color.Transparent
        Me.CMDAPPLY.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAPPLY.FlatAppearance.BorderSize = 0
        Me.CMDAPPLY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAPPLY.ForeColor = System.Drawing.Color.Black
        Me.CMDAPPLY.Location = New System.Drawing.Point(1143, 26)
        Me.CMDAPPLY.Name = "CMDAPPLY"
        Me.CMDAPPLY.Size = New System.Drawing.Size(80, 28)
        Me.CMDAPPLY.TabIndex = 579
        Me.CMDAPPLY.Text = "Apply"
        Me.CMDAPPLY.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(809, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 14)
        Me.Label9.TabIndex = 578
        Me.Label9.Text = "Reason"
        '
        'DTCLOSEDATE
        '
        Me.DTCLOSEDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTCLOSEDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTCLOSEDATE.Location = New System.Drawing.Point(723, 28)
        Me.DTCLOSEDATE.Name = "DTCLOSEDATE"
        Me.DTCLOSEDATE.Size = New System.Drawing.Size(80, 22)
        Me.DTCLOSEDATE.TabIndex = 576
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(661, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 577
        Me.Label2.Text = "Close Date"
        '
        'CMBMAINREASON
        '
        Me.CMBMAINREASON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMAINREASON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMAINREASON.BackColor = System.Drawing.Color.White
        Me.CMBMAINREASON.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMAINREASON.FormattingEnabled = True
        Me.CMBMAINREASON.Items.AddRange(New Object() {""})
        Me.CMBMAINREASON.Location = New System.Drawing.Point(857, 28)
        Me.CMBMAINREASON.Name = "CMBMAINREASON"
        Me.CMBMAINREASON.Size = New System.Drawing.Size(284, 22)
        Me.CMBMAINREASON.TabIndex = 575
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(489, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(186, 14)
        Me.Label21.TabIndex = 442
        Me.Label21.Text = "Please Enter Closed Date to Save"
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(577, 541)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 258
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(12, 32)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 257
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 56)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CMBREASON})
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 479)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCLOSED, Me.GSONO, Me.GGRIDSRNO, Me.GDATE, Me.GNAME, Me.GAGENTNAME, Me.GCITY, Me.GITEMNAME, Me.GDESIGNNO, Me.GQUALITY, Me.GCOLOR, Me.GGRIDPONO, Me.GPCS, Me.GCUT, Me.GMTRS, Me.GRATE, Me.GRECDPCS, Me.GRECDMTRS, Me.GBALPCS, Me.GBALMTRS, Me.GBALPER, Me.GSTOCKPCS, Me.GSTOCKMTRS, Me.GPARTYPONO, Me.GDELDATE, Me.GREMARKS, Me.GTYPE, Me.GFORWARD, Me.GCLOSEDDATE, Me.GREASON, Me.GNOTE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCLOSED
        '
        Me.GCLOSED.Caption = "Closed"
        Me.GCLOSED.FieldName = "CLOSED"
        Me.GCLOSED.Name = "GCLOSED"
        Me.GCLOSED.OptionsColumn.ShowCaption = False
        Me.GCLOSED.Visible = True
        Me.GCLOSED.VisibleIndex = 0
        Me.GCLOSED.Width = 50
        '
        'GSONO
        '
        Me.GSONO.Caption = "SO No"
        Me.GSONO.DisplayFormat.FormatString = "0"
        Me.GSONO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSONO.FieldName = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.OptionsColumn.AllowEdit = False
        Me.GSONO.Visible = True
        Me.GSONO.VisibleIndex = 1
        Me.GSONO.Width = 50
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "GRIDSRNO"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "SODATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageOptions.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 210
        '
        'GAGENTNAME
        '
        Me.GAGENTNAME.Caption = "Agent Name"
        Me.GAGENTNAME.FieldName = "AGENTNAME"
        Me.GAGENTNAME.Name = "GAGENTNAME"
        Me.GAGENTNAME.OptionsColumn.AllowEdit = False
        Me.GAGENTNAME.Visible = True
        Me.GAGENTNAME.VisibleIndex = 4
        Me.GAGENTNAME.Width = 200
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.OptionsColumn.AllowEdit = False
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 5
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BALES", "")})
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 6
        Me.GITEMNAME.Width = 150
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 7
        Me.GDESIGNNO.Width = 120
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 8
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.OptionsColumn.AllowEdit = False
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 9
        Me.GCOLOR.Width = 100
        '
        'GGRIDPONO
        '
        Me.GGRIDPONO.Caption = "Grid PO No"
        Me.GGRIDPONO.FieldName = "GRIDPARTYPONO"
        Me.GGRIDPONO.Name = "GGRIDPONO"
        Me.GGRIDPONO.OptionsColumn.AllowEdit = False
        Me.GGRIDPONO.Visible = True
        Me.GGRIDPONO.VisibleIndex = 10
        Me.GGRIDPONO.Width = 120
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 11
        Me.GPCS.Width = 60
        '
        'GCUT
        '
        Me.GCUT.Caption = "Cut"
        Me.GCUT.DisplayFormat.FormatString = "0.00"
        Me.GCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUT.FieldName = "CUT"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.OptionsColumn.AllowEdit = False
        Me.GCUT.Visible = True
        Me.GCUT.VisibleIndex = 12
        Me.GCUT.Width = 50
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 13
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.OptionsColumn.AllowEdit = False
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 14
        '
        'GRECDPCS
        '
        Me.GRECDPCS.Caption = "Out Pcs"
        Me.GRECDPCS.DisplayFormat.FormatString = "0"
        Me.GRECDPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECDPCS.FieldName = "OUTPCS"
        Me.GRECDPCS.Name = "GRECDPCS"
        Me.GRECDPCS.OptionsColumn.AllowEdit = False
        Me.GRECDPCS.Visible = True
        Me.GRECDPCS.VisibleIndex = 15
        Me.GRECDPCS.Width = 65
        '
        'GRECDMTRS
        '
        Me.GRECDMTRS.Caption = "Out Mtrs"
        Me.GRECDMTRS.DisplayFormat.FormatString = "0.00"
        Me.GRECDMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECDMTRS.FieldName = "OUTMTRS"
        Me.GRECDMTRS.Name = "GRECDMTRS"
        Me.GRECDMTRS.OptionsColumn.AllowEdit = False
        Me.GRECDMTRS.Visible = True
        Me.GRECDMTRS.VisibleIndex = 16
        '
        'GBALPCS
        '
        Me.GBALPCS.Caption = "Bal Pcs"
        Me.GBALPCS.DisplayFormat.FormatString = "0"
        Me.GBALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALPCS.FieldName = "BALPCS"
        Me.GBALPCS.Name = "GBALPCS"
        Me.GBALPCS.OptionsColumn.AllowEdit = False
        Me.GBALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALPCS.Visible = True
        Me.GBALPCS.VisibleIndex = 17
        Me.GBALPCS.Width = 65
        '
        'GBALMTRS
        '
        Me.GBALMTRS.Caption = "Bal Mtrs"
        Me.GBALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GBALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALMTRS.FieldName = "BALMTRS"
        Me.GBALMTRS.Name = "GBALMTRS"
        Me.GBALMTRS.OptionsColumn.AllowEdit = False
        Me.GBALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALMTRS.Visible = True
        Me.GBALMTRS.VisibleIndex = 18
        '
        'GBALPER
        '
        Me.GBALPER.Caption = "Bal %"
        Me.GBALPER.DisplayFormat.FormatString = "0.00"
        Me.GBALPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALPER.FieldName = "BALPER"
        Me.GBALPER.Name = "GBALPER"
        Me.GBALPER.OptionsColumn.AllowEdit = False
        Me.GBALPER.Visible = True
        Me.GBALPER.VisibleIndex = 19
        '
        'GSTOCKPCS
        '
        Me.GSTOCKPCS.Caption = "Stock Pcs"
        Me.GSTOCKPCS.DisplayFormat.FormatString = "0"
        Me.GSTOCKPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTOCKPCS.FieldName = "STOCKPCS"
        Me.GSTOCKPCS.Name = "GSTOCKPCS"
        Me.GSTOCKPCS.OptionsColumn.AllowEdit = False
        Me.GSTOCKPCS.Visible = True
        Me.GSTOCKPCS.VisibleIndex = 20
        '
        'GSTOCKMTRS
        '
        Me.GSTOCKMTRS.Caption = "Stock Mtrs"
        Me.GSTOCKMTRS.DisplayFormat.FormatString = "0.00"
        Me.GSTOCKMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTOCKMTRS.FieldName = "STOCKMTRS"
        Me.GSTOCKMTRS.Name = "GSTOCKMTRS"
        Me.GSTOCKMTRS.OptionsColumn.AllowEdit = False
        Me.GSTOCKMTRS.Visible = True
        Me.GSTOCKMTRS.VisibleIndex = 21
        '
        'GPARTYPONO
        '
        Me.GPARTYPONO.Caption = "PO No."
        Me.GPARTYPONO.FieldName = "PARTYPONO"
        Me.GPARTYPONO.Name = "GPARTYPONO"
        Me.GPARTYPONO.OptionsColumn.AllowEdit = False
        Me.GPARTYPONO.Visible = True
        Me.GPARTYPONO.VisibleIndex = 22
        Me.GPARTYPONO.Width = 80
        '
        'GDELDATE
        '
        Me.GDELDATE.Caption = "Del Date"
        Me.GDELDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDELDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDELDATE.FieldName = "DELDATE"
        Me.GDELDATE.Name = "GDELDATE"
        Me.GDELDATE.OptionsColumn.AllowEdit = False
        Me.GDELDATE.Visible = True
        Me.GDELDATE.VisibleIndex = 23
        Me.GDELDATE.Width = 80
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 24
        Me.GREMARKS.Width = 280
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 25
        '
        'GFORWARD
        '
        Me.GFORWARD.Caption = "Forward"
        Me.GFORWARD.FieldName = "FORWARD"
        Me.GFORWARD.Name = "GFORWARD"
        Me.GFORWARD.OptionsColumn.AllowEdit = False
        '
        'GCLOSEDDATE
        '
        Me.GCLOSEDDATE.Caption = "Close Date"
        Me.GCLOSEDDATE.FieldName = "CLOSEDDATE"
        Me.GCLOSEDDATE.Name = "GCLOSEDDATE"
        Me.GCLOSEDDATE.Visible = True
        Me.GCLOSEDDATE.VisibleIndex = 26
        '
        'GREASON
        '
        Me.GREASON.Caption = "Reason"
        Me.GREASON.ColumnEdit = Me.CMBREASON
        Me.GREASON.FieldName = "REASON"
        Me.GREASON.Name = "GREASON"
        Me.GREASON.Visible = True
        Me.GREASON.VisibleIndex = 27
        Me.GREASON.Width = 150
        '
        'CMBREASON
        '
        Me.CMBREASON.AutoHeight = False
        Me.CMBREASON.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CMBREASON.Name = "CMBREASON"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(663, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(491, 541)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GNOTE
        '
        Me.GNOTE.Caption = "Note"
        Me.GNOTE.FieldName = "NOTE"
        Me.GNOTE.Name = "GNOTE"
        Me.GNOTE.Visible = True
        Me.GNOTE.VisibleIndex = 28
        Me.GNOTE.Width = 280
        '
        'SaleOrderClose
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleOrderClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Order Close"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CMBREASON, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAGENTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLOSED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKSELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFORWARD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents GGRIDPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLOSEDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREASON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBREASON As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DTCLOSEDATE As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBMAINREASON As ComboBox
    Friend WithEvents CMDAPPLY As Button
    Friend WithEvents GBALPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBENTERED As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents GSTOCKPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOCKMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNOTE As DevExpress.XtraGrid.Columns.GridColumn
End Class
