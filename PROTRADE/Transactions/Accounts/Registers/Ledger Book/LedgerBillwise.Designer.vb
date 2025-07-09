<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerBillwise
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerBillwise))
        Me.GRIDREC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GRECINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBANKNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECUSERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.lbldrcropening = New System.Windows.Forms.Label()
        Me.txtopening = New System.Windows.Forms.TextBox()
        Me.lblopbal = New System.Windows.Forms.Label()
        Me.chkpaid = New System.Windows.Forms.CheckBox()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.txtcrtotal = New System.Windows.Forms.TextBox()
        Me.txtdrtotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.lbldrcrclosing = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbln = New System.Windows.Forms.Label()
        Me.txttempbillno = New System.Windows.Forms.TextBox()
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
        Me.TOOLDETAIL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLDAILY = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLMONTHLY = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblname = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.registerdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl = New System.Windows.Forms.Label()
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRIDREC
        '
        Me.GRIDREC.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDREC.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDREC.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDREC.Appearance.Row.Options.UseFont = True
        Me.GRIDREC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GRECINITIALS, Me.GRECDATE, Me.GBANKNAME, Me.GAMOUNT, Me.GRECREMARKS, Me.GRECUSERNAME, Me.GRECNO, Me.GREGNAME, Me.GRECTYPE})
        Me.GRIDREC.GridControl = Me.griddetails
        Me.GRIDREC.Name = "GRIDREC"
        Me.GRIDREC.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDREC.OptionsBehavior.Editable = False
        Me.GRIDREC.OptionsView.ColumnAutoWidth = False
        Me.GRIDREC.OptionsView.ShowGroupPanel = False
        '
        'GRECINITIALS
        '
        Me.GRECINITIALS.Caption = "Rec No"
        Me.GRECINITIALS.FieldName = "RECINITIALS"
        Me.GRECINITIALS.Name = "GRECINITIALS"
        Me.GRECINITIALS.Visible = True
        Me.GRECINITIALS.VisibleIndex = 0
        Me.GRECINITIALS.Width = 90
        '
        'GRECDATE
        '
        Me.GRECDATE.Caption = "Date"
        Me.GRECDATE.FieldName = "RECDATE"
        Me.GRECDATE.Name = "GRECDATE"
        Me.GRECDATE.Visible = True
        Me.GRECDATE.VisibleIndex = 1
        Me.GRECDATE.Width = 90
        '
        'GBANKNAME
        '
        Me.GBANKNAME.Caption = "Bank Name"
        Me.GBANKNAME.FieldName = "BANKNAME"
        Me.GBANKNAME.Name = "GBANKNAME"
        Me.GBANKNAME.Visible = True
        Me.GBANKNAME.VisibleIndex = 2
        Me.GBANKNAME.Width = 250
        '
        'GAMOUNT
        '
        Me.GAMOUNT.Caption = "Amount"
        Me.GAMOUNT.DisplayFormat.FormatString = "0.00"
        Me.GAMOUNT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMOUNT.FieldName = "AMOUNT"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.Visible = True
        Me.GAMOUNT.VisibleIndex = 3
        Me.GAMOUNT.Width = 100
        '
        'GRECREMARKS
        '
        Me.GRECREMARKS.Caption = "Remarks"
        Me.GRECREMARKS.FieldName = "RECREMARKS"
        Me.GRECREMARKS.Name = "GRECREMARKS"
        Me.GRECREMARKS.Visible = True
        Me.GRECREMARKS.VisibleIndex = 4
        Me.GRECREMARKS.Width = 280
        '
        'GRECUSERNAME
        '
        Me.GRECUSERNAME.Caption = "User Name"
        Me.GRECUSERNAME.FieldName = "RECUSERNAME"
        Me.GRECUSERNAME.Name = "GRECUSERNAME"
        Me.GRECUSERNAME.Visible = True
        Me.GRECUSERNAME.VisibleIndex = 5
        Me.GRECUSERNAME.Width = 150
        '
        'GRECNO
        '
        Me.GRECNO.Caption = "RECNO"
        Me.GRECNO.FieldName = "RECNO"
        Me.GRECNO.Name = "GRECNO"
        '
        'GREGNAME
        '
        Me.GREGNAME.Caption = "REGNAME"
        Me.GREGNAME.FieldName = "RECREGTYPE"
        Me.GREGNAME.Name = "GREGNAME"
        '
        'GRECTYPE
        '
        Me.GRECTYPE.Caption = "RECTYPE"
        Me.GRECTYPE.FieldName = "RECTYPE"
        Me.GRECTYPE.Name = "GRECTYPE"
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.LevelTemplate = Me.GRIDREC
        GridLevelNode1.RelationName = "BILLDETAILS"
        Me.griddetails.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.griddetails.Location = New System.Drawing.Point(15, 102)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1241, 417)
        Me.griddetails.TabIndex = 447
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister, Me.GRIDREC})
        '
        'gridregister
        '
        Me.gridregister.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gDate, Me.gname, Me.gtype, Me.gbillinitials, Me.GREFNO, Me.gdr, Me.gcr, Me.gbillno, Me.greg, Me.gremarks, Me.GUSER})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsView.AllowCellMerge = True
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
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
        Me.gDate.Width = 80
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
        '
        'gbillinitials
        '
        Me.gbillinitials.Caption = "Bill No."
        Me.gbillinitials.FieldName = "Bill No"
        Me.gbillinitials.ImageIndex = 1
        Me.gbillinitials.Name = "gbillinitials"
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 2
        Me.gbillinitials.Width = 100
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 3
        Me.GREFNO.Width = 90
        '
        'gdr
        '
        Me.gdr.Caption = "Debit"
        Me.gdr.DisplayFormat.FormatString = "0.00"
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
        Me.gcr.Caption = "Credit"
        Me.gcr.DisplayFormat.FormatString = "0.00"
        Me.gcr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcr.FieldName = "Credit"
        Me.gcr.Name = "gcr"
        Me.gcr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gcr.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:0.00}")})
        Me.gcr.Visible = True
        Me.gcr.VisibleIndex = 5
        Me.gcr.Width = 110
        '
        'gbillno
        '
        Me.gbillno.Caption = "Bill no"
        Me.gbillno.FieldName = "BILL"
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
        Me.gremarks.VisibleIndex = 6
        Me.gremarks.Width = 300
        '
        'GUSER
        '
        Me.GUSER.Caption = "User Name"
        Me.GUSER.FieldName = "USERNAME"
        Me.GUSER.ImageIndex = 2
        Me.GUSER.Name = "GUSER"
        Me.GUSER.Visible = True
        Me.GUSER.VisibleIndex = 7
        Me.GUSER.Width = 150
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.lbldrcropening)
        Me.BlendPanel1.Controls.Add(Me.txtopening)
        Me.BlendPanel1.Controls.Add(Me.lblopbal)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.chkpaid)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.txtcrtotal)
        Me.BlendPanel1.Controls.Add(Me.txtdrtotal)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.lbldrcrclosing)
        Me.BlendPanel1.Controls.Add(Me.txttotal)
        Me.BlendPanel1.Controls.Add(Me.lbln)
        Me.BlendPanel1.Controls.Add(Me.txttempbillno)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.lbldate)
        Me.BlendPanel1.Controls.Add(Me.registerdate)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 582)
        Me.BlendPanel1.TabIndex = 1
        '
        'lbldrcropening
        '
        Me.lbldrcropening.AutoSize = True
        Me.lbldrcropening.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcropening.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcropening.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcropening.Location = New System.Drawing.Point(1114, 79)
        Me.lbldrcropening.Name = "lbldrcropening"
        Me.lbldrcropening.Size = New System.Drawing.Size(0, 15)
        Me.lbldrcropening.TabIndex = 487
        Me.lbldrcropening.Visible = False
        '
        'txtopening
        '
        Me.txtopening.BackColor = System.Drawing.Color.White
        Me.txtopening.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtopening.ForeColor = System.Drawing.Color.Black
        Me.txtopening.Location = New System.Drawing.Point(987, 76)
        Me.txtopening.Name = "txtopening"
        Me.txtopening.ReadOnly = True
        Me.txtopening.Size = New System.Drawing.Size(125, 23)
        Me.txtopening.TabIndex = 486
        Me.txtopening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtopening.Visible = False
        '
        'lblopbal
        '
        Me.lblopbal.AutoSize = True
        Me.lblopbal.BackColor = System.Drawing.Color.Transparent
        Me.lblopbal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblopbal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblopbal.Location = New System.Drawing.Point(935, 79)
        Me.lblopbal.Name = "lblopbal"
        Me.lblopbal.Size = New System.Drawing.Size(49, 15)
        Me.lblopbal.TabIndex = 485
        Me.lblopbal.Text = "O/P Bal"
        Me.lblopbal.Visible = False
        '
        'chkpaid
        '
        Me.chkpaid.AutoSize = True
        Me.chkpaid.BackColor = System.Drawing.Color.Transparent
        Me.chkpaid.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkpaid.Location = New System.Drawing.Point(1061, 46)
        Me.chkpaid.Name = "chkpaid"
        Me.chkpaid.Size = New System.Drawing.Size(79, 19)
        Me.chkpaid.TabIndex = 484
        Me.chkpaid.Text = "Paid Bills"
        Me.chkpaid.UseVisualStyleBackColor = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(1139, 31)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(28, 23)
        Me.CMBACCCODE.TabIndex = 483
        Me.CMBACCCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(253, 65)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(112, 22)
        Me.txtadd.TabIndex = 448
        Me.txtadd.Visible = False
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(759, 59)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(90, 31)
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
        Me.cmdok.Location = New System.Drawing.Point(549, 535)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(90, 31)
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
        Me.cmdexit.Location = New System.Drawing.Point(645, 535)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(90, 31)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'txtcrtotal
        '
        Me.txtcrtotal.BackColor = System.Drawing.Color.White
        Me.txtcrtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtcrtotal.Location = New System.Drawing.Point(987, 526)
        Me.txtcrtotal.Name = "txtcrtotal"
        Me.txtcrtotal.ReadOnly = True
        Me.txtcrtotal.Size = New System.Drawing.Size(125, 23)
        Me.txtcrtotal.TabIndex = 443
        Me.txtcrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdrtotal
        '
        Me.txtdrtotal.BackColor = System.Drawing.Color.White
        Me.txtdrtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtdrtotal.Location = New System.Drawing.Point(860, 526)
        Me.txtdrtotal.Name = "txtdrtotal"
        Me.txtdrtotal.ReadOnly = True
        Me.txtdrtotal.Size = New System.Drawing.Size(125, 23)
        Me.txtdrtotal.TabIndex = 442
        Me.txtdrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(825, 530)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "Total"
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkall.Location = New System.Drawing.Point(987, 46)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(69, 19)
        Me.chkall.TabIndex = 440
        Me.chkall.Text = "All Bills"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(1114, 555)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 15)
        Me.lbldrcrclosing.TabIndex = 436
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Black
        Me.txttotal.Location = New System.Drawing.Point(987, 552)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(125, 23)
        Me.txttotal.TabIndex = 435
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(912, 557)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(72, 15)
        Me.lbln.TabIndex = 434
        Me.lbln.Text = "Closing Bal."
        '
        'txttempbillno
        '
        Me.txttempbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempbillno.Location = New System.Drawing.Point(135, 68)
        Me.txttempbillno.Name = "txttempbillno"
        Me.txttempbillno.Size = New System.Drawing.Size(112, 22)
        Me.txttempbillno.TabIndex = 433
        Me.txttempbillno.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(575, 39)
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
        Me.dtto.Location = New System.Drawing.Point(666, 63)
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
        Me.lblto.Location = New System.Drawing.Point(642, 67)
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
        Me.dtfrom.Location = New System.Drawing.Point(665, 37)
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
        Me.lblfrom.Location = New System.Drawing.Point(627, 41)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ExcelExport, Me.ToolStripSeparator1, Me.TOOLDETAIL, Me.ToolStripSeparator3, Me.TOOLDAILY, Me.ToolStripSeparator4, Me.TOOLMONTHLY, Me.ToolStripSeparator5})
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
        Me.PrintToolStripButton.Visible = False
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
        'TOOLDETAIL
        '
        Me.TOOLDETAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TOOLDETAIL.Image = CType(resources.GetObject("TOOLDETAIL.Image"), System.Drawing.Image)
        Me.TOOLDETAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDETAIL.Name = "TOOLDETAIL"
        Me.TOOLDETAIL.Size = New System.Drawing.Size(77, 22)
        Me.TOOLDETAIL.Text = "Detailed - F8"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLDAILY
        '
        Me.TOOLDAILY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TOOLDAILY.Image = CType(resources.GetObject("TOOLDAILY.Image"), System.Drawing.Image)
        Me.TOOLDAILY.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDAILY.Name = "TOOLDAILY"
        Me.TOOLDAILY.Size = New System.Drawing.Size(60, 22)
        Me.TOOLDAILY.Text = "Daily - F6"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLMONTHLY
        '
        Me.TOOLMONTHLY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TOOLMONTHLY.Image = CType(resources.GetObject("TOOLMONTHLY.Image"), System.Drawing.Image)
        Me.TOOLMONTHLY.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMONTHLY.Name = "TOOLMONTHLY"
        Me.TOOLMONTHLY.Size = New System.Drawing.Size(79, 22)
        Me.TOOLMONTHLY.Text = "Monthly - F7"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(139, 43)
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
        Me.cmbname.Location = New System.Drawing.Point(181, 39)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(322, 22)
        Me.cmbname.TabIndex = 0
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.BackColor = System.Drawing.Color.Transparent
        Me.lbldate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.Location = New System.Drawing.Point(22, 76)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(33, 14)
        Me.lbldate.TabIndex = 428
        Me.lbldate.Text = "Date"
        Me.lbldate.Visible = False
        '
        'registerdate
        '
        Me.registerdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registerdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.registerdate.Location = New System.Drawing.Point(56, 72)
        Me.registerdate.Name = "registerdate"
        Me.registerdate.Size = New System.Drawing.Size(87, 22)
        Me.registerdate.TabIndex = 423
        Me.registerdate.Visible = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(11, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(110, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Ledger Bill"
        '
        'LedgerBillwise
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LedgerBillwise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ledger Billwise"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GRIDREC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
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
    Friend WithEvents chkpaid As System.Windows.Forms.CheckBox
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txtcrtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtdrtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents lbldrcrclosing As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbln As System.Windows.Forms.Label
    Friend WithEvents txttempbillno As System.Windows.Forms.TextBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents registerdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lbldrcropening As System.Windows.Forms.Label
    Friend WithEvents txtopening As System.Windows.Forms.TextBox
    Friend WithEvents lblopbal As System.Windows.Forms.Label
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLDETAIL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLDAILY As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLMONTHLY As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GRIDREC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GRECINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBANKNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECUSERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
