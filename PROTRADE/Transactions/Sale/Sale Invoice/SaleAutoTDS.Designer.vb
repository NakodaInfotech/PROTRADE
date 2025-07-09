<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleAutoTDS
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
        Me.CMDAPPLYTDS = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTTDSAMT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTTDSPER = New System.Windows.Forms.TextBox()
        Me.CMBTDS = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAGENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPPEDTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEWAYBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSPDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHARGES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWITHGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAPPLYTCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTCSPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTCSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURNAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUPPLIERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDOCKETNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDOCKETDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOURIER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHGSDTLS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CMDPOST = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.POSTINGDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.POSTINGDATE)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMDAPPLYTDS)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTTDSAMT)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTTDSPER)
        Me.BlendPanel1.Controls.Add(Me.CMBTDS)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDPOST)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDAPPLYTDS
        '
        Me.CMDAPPLYTDS.BackColor = System.Drawing.Color.Transparent
        Me.CMDAPPLYTDS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDAPPLYTDS.FlatAppearance.BorderSize = 0
        Me.CMDAPPLYTDS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDAPPLYTDS.ForeColor = System.Drawing.Color.Black
        Me.CMDAPPLYTDS.Location = New System.Drawing.Point(1101, 29)
        Me.CMDAPPLYTDS.Name = "CMDAPPLYTDS"
        Me.CMDAPPLYTDS.Size = New System.Drawing.Size(80, 28)
        Me.CMDAPPLYTDS.TabIndex = 5
        Me.CMDAPPLYTDS.Text = "Apply TDS"
        Me.CMDAPPLYTDS.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(966, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 319
        Me.Label4.Text = "TDS Amt"
        '
        'TXTTDSAMT
        '
        Me.TXTTDSAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTTDSAMT.Location = New System.Drawing.Point(1019, 33)
        Me.TXTTDSAMT.Name = "TXTTDSAMT"
        Me.TXTTDSAMT.Size = New System.Drawing.Size(76, 23)
        Me.TXTTDSAMT.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(844, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 317
        Me.Label3.Text = "TDS%"
        '
        'TXTTDSPER
        '
        Me.TXTTDSPER.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTTDSPER.Location = New System.Drawing.Point(884, 33)
        Me.TXTTDSPER.Name = "TXTTDSPER"
        Me.TXTTDSPER.Size = New System.Drawing.Size(76, 23)
        Me.TXTTDSPER.TabIndex = 3
        '
        'CMBTDS
        '
        Me.CMBTDS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTDS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTDS.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTDS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTDS.FormattingEnabled = True
        Me.CMBTDS.Items.AddRange(New Object() {""})
        Me.CMBTDS.Location = New System.Drawing.Point(615, 33)
        Me.CMBTDS.Name = "CMBTDS"
        Me.CMBTDS.Size = New System.Drawing.Size(215, 22)
        Me.CMBTDS.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(554, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 315
        Me.Label2.Text = "TDS Name"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(17, 61)
        Me.gridbilldetails.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.gridbilldetails.Size = New System.Drawing.Size(1200, 472)
        Me.gridbilldetails.TabIndex = 6
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.gsrno, Me.gdate, Me.GREFNO, Me.GCHALLANNO, Me.GCHALLANDATE, Me.gname, Me.GGSTIN, Me.GCITY, Me.GSTATENAME, Me.GSTATECODE, Me.GADD, Me.GAGENT, Me.GSHIPPEDTO, Me.GEWAYBILLNO, Me.GTRANSPORT, Me.GLRNO, Me.GLRDATE, Me.GSO, Me.GBALES, Me.GPCS, Me.GMTRS, Me.GTOTALAMT, Me.GDISC, Me.GSPDISCAMT, Me.GCHARGES, Me.GTOTALTAXABLEAMT, Me.GTOTALCGSTAMT, Me.GTOTALSGSTAMT, Me.GTOTALIGSTAMT, Me.GTOTALWITHGST, Me.GAPPLYTCS, Me.GTCSPER, Me.GTCSAMT, Me.GGRANDTOTAL, Me.GRECDAMT, Me.GRETURNAMT, Me.GBALANCE, Me.GREMARKS, Me.GDISPUTED, Me.GBILLCHECKED, Me.GSUPPLIERNAME, Me.GRECDDATE, Me.GIRNNO, Me.GDOCKETNO, Me.GDOCKETDATE, Me.GCOURIER, Me.GCHGSDTLS, Me.GTOCITY, Me.GINVINITIALS, Me.GTDSAMT, Me.GPOSTAMT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        Me.gsrno.Width = 60
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.OptionsColumn.AllowEdit = False
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.OptionsColumn.AllowEdit = False
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No."
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.OptionsColumn.AllowEdit = False
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Ch. Date"
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.OptionsColumn.AllowEdit = False
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowEdit = False
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 3
        Me.gname.Width = 230
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.OptionsColumn.AllowEdit = False
        Me.GGSTIN.Width = 100
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.OptionsColumn.AllowEdit = False
        Me.GCITY.Width = 100
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.OptionsColumn.AllowEdit = False
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.OptionsColumn.AllowEdit = False
        Me.GSTATECODE.Width = 40
        '
        'GADD
        '
        Me.GADD.Caption = "Add."
        Me.GADD.FieldName = "ADDRESS"
        Me.GADD.Name = "GADD"
        Me.GADD.OptionsColumn.AllowEdit = False
        Me.GADD.Width = 150
        '
        'GAGENT
        '
        Me.GAGENT.Caption = "Agent Name"
        Me.GAGENT.FieldName = "AGENTNAME"
        Me.GAGENT.Name = "GAGENT"
        Me.GAGENT.OptionsColumn.AllowEdit = False
        Me.GAGENT.Visible = True
        Me.GAGENT.VisibleIndex = 4
        Me.GAGENT.Width = 150
        '
        'GSHIPPEDTO
        '
        Me.GSHIPPEDTO.Caption = "Shipped To"
        Me.GSHIPPEDTO.FieldName = "PACKING"
        Me.GSHIPPEDTO.Name = "GSHIPPEDTO"
        Me.GSHIPPEDTO.OptionsColumn.AllowEdit = False
        Me.GSHIPPEDTO.Width = 100
        '
        'GEWAYBILLNO
        '
        Me.GEWAYBILLNO.Caption = "E-Way Bill No."
        Me.GEWAYBILLNO.FieldName = "EWAYBILLNO"
        Me.GEWAYBILLNO.Name = "GEWAYBILLNO"
        Me.GEWAYBILLNO.OptionsColumn.AllowEdit = False
        '
        'GTRANSPORT
        '
        Me.GTRANSPORT.Caption = "Transport"
        Me.GTRANSPORT.FieldName = "TRANSNAME"
        Me.GTRANSPORT.Name = "GTRANSPORT"
        Me.GTRANSPORT.OptionsColumn.AllowEdit = False
        Me.GTRANSPORT.Width = 150
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.OptionsColumn.AllowEdit = False
        '
        'GLRDATE
        '
        Me.GLRDATE.Caption = "LR Date"
        Me.GLRDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GLRDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GLRDATE.FieldName = "LRDATE"
        Me.GLRDATE.Name = "GLRDATE"
        Me.GLRDATE.OptionsColumn.AllowEdit = False
        '
        'GSO
        '
        Me.GSO.Caption = "SO No."
        Me.GSO.FieldName = "SONO"
        Me.GSO.Name = "GSO"
        Me.GSO.OptionsColumn.AllowEdit = False
        '
        'GBALES
        '
        Me.GBALES.Caption = "Bales"
        Me.GBALES.DisplayFormat.FormatString = "0"
        Me.GBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALES.FieldName = "NOOFBALES"
        Me.GBALES.Name = "GBALES"
        Me.GBALES.OptionsColumn.AllowEdit = False
        '
        'GPCS
        '
        Me.GPCS.Caption = "Total Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0.00"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "TOTALPCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Width = 85
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Total Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "TOTALMTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 5
        Me.GMTRS.Width = 85
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALAMT.FieldName = "TOTALAMT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.OptionsColumn.AllowEdit = False
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 6
        '
        'GDISC
        '
        Me.GDISC.Caption = "Total Disc Amt."
        Me.GDISC.FieldName = "TOTALDISC"
        Me.GDISC.Name = "GDISC"
        Me.GDISC.OptionsColumn.AllowEdit = False
        Me.GDISC.Width = 80
        '
        'GSPDISCAMT
        '
        Me.GSPDISCAMT.Caption = "Total Sp Disc Amt."
        Me.GSPDISCAMT.FieldName = "TOTALSPDISCAMT"
        Me.GSPDISCAMT.Name = "GSPDISCAMT"
        Me.GSPDISCAMT.OptionsColumn.AllowEdit = False
        '
        'GCHARGES
        '
        Me.GCHARGES.Caption = "Charges"
        Me.GCHARGES.FieldName = "CHARGES"
        Me.GCHARGES.Name = "GCHARGES"
        Me.GCHARGES.OptionsColumn.AllowEdit = False
        Me.GCHARGES.Visible = True
        Me.GCHARGES.VisibleIndex = 7
        '
        'GTOTALTAXABLEAMT
        '
        Me.GTOTALTAXABLEAMT.Caption = "Total Taxable Amt."
        Me.GTOTALTAXABLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALTAXABLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALTAXABLEAMT.FieldName = "TOTALTAXABLEAMT"
        Me.GTOTALTAXABLEAMT.Name = "GTOTALTAXABLEAMT"
        Me.GTOTALTAXABLEAMT.OptionsColumn.AllowEdit = False
        Me.GTOTALTAXABLEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALTAXABLEAMT.Visible = True
        Me.GTOTALTAXABLEAMT.VisibleIndex = 8
        Me.GTOTALTAXABLEAMT.Width = 105
        '
        'GTOTALCGSTAMT
        '
        Me.GTOTALCGSTAMT.Caption = "Total CGST Amt."
        Me.GTOTALCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCGSTAMT.FieldName = "TOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Name = "GTOTALCGSTAMT"
        Me.GTOTALCGSTAMT.OptionsColumn.AllowEdit = False
        Me.GTOTALCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GTOTALSGSTAMT
        '
        Me.GTOTALSGSTAMT.Caption = "Total SGST Amt."
        Me.GTOTALSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALSGSTAMT.FieldName = "TOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Name = "GTOTALSGSTAMT"
        Me.GTOTALSGSTAMT.OptionsColumn.AllowEdit = False
        Me.GTOTALSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GTOTALIGSTAMT
        '
        Me.GTOTALIGSTAMT.Caption = "Total IGST Amt."
        Me.GTOTALIGSTAMT.FieldName = "TOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Name = "GTOTALIGSTAMT"
        Me.GTOTALIGSTAMT.OptionsColumn.AllowEdit = False
        Me.GTOTALIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GTOTALWITHGST
        '
        Me.GTOTALWITHGST.Caption = "Total With GST"
        Me.GTOTALWITHGST.DisplayFormat.FormatString = "0.00"
        Me.GTOTALWITHGST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWITHGST.FieldName = "TOTALWITHGST"
        Me.GTOTALWITHGST.Name = "GTOTALWITHGST"
        Me.GTOTALWITHGST.OptionsColumn.AllowEdit = False
        Me.GTOTALWITHGST.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GAPPLYTCS
        '
        Me.GAPPLYTCS.Caption = "TCS"
        Me.GAPPLYTCS.FieldName = "APPLYTCS"
        Me.GAPPLYTCS.Name = "GAPPLYTCS"
        Me.GAPPLYTCS.OptionsColumn.AllowEdit = False
        '
        'GTCSPER
        '
        Me.GTCSPER.Caption = "TCS %"
        Me.GTCSPER.DisplayFormat.FormatString = "0.000"
        Me.GTCSPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTCSPER.FieldName = "TCSPER"
        Me.GTCSPER.Name = "GTCSPER"
        Me.GTCSPER.OptionsColumn.AllowEdit = False
        '
        'GTCSAMT
        '
        Me.GTCSAMT.Caption = "TCS Amt"
        Me.GTCSAMT.DisplayFormat.FormatString = "0.00"
        Me.GTCSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTCSAMT.FieldName = "TCSAMT"
        Me.GTCSAMT.Name = "GTCSAMT"
        Me.GTCSAMT.OptionsColumn.AllowEdit = False
        Me.GTCSAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRANDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRANDTOTAL.FieldName = "GRANDTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.OptionsColumn.AllowEdit = False
        Me.GGRANDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 9
        Me.GGRANDTOTAL.Width = 95
        '
        'GRECDAMT
        '
        Me.GRECDAMT.Caption = "Recd Amt"
        Me.GRECDAMT.DisplayFormat.FormatString = "0.00"
        Me.GRECDAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECDAMT.FieldName = "RECDAMT"
        Me.GRECDAMT.Name = "GRECDAMT"
        Me.GRECDAMT.OptionsColumn.AllowEdit = False
        Me.GRECDAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GRETURNAMT
        '
        Me.GRETURNAMT.Caption = "Sale Ret Amt"
        Me.GRETURNAMT.DisplayFormat.FormatString = "0.00"
        Me.GRETURNAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURNAMT.FieldName = "RETURNAMT"
        Me.GRETURNAMT.Name = "GRETURNAMT"
        Me.GRETURNAMT.OptionsColumn.AllowEdit = False
        Me.GRETURNAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "Bal Amt"
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCEAMT"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.OptionsColumn.AllowEdit = False
        Me.GBALANCE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Width = 150
        '
        'GDISPUTED
        '
        Me.GDISPUTED.Caption = "Disputed"
        Me.GDISPUTED.FieldName = "DISPUTED"
        Me.GDISPUTED.Name = "GDISPUTED"
        Me.GDISPUTED.OptionsColumn.AllowEdit = False
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Checked"
        Me.GBILLCHECKED.FieldName = "CHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.OptionsColumn.AllowEdit = False
        '
        'GSUPPLIERNAME
        '
        Me.GSUPPLIERNAME.Caption = "Supplier Name"
        Me.GSUPPLIERNAME.FieldName = "PURNAME"
        Me.GSUPPLIERNAME.Name = "GSUPPLIERNAME"
        Me.GSUPPLIERNAME.OptionsColumn.AllowEdit = False
        Me.GSUPPLIERNAME.Width = 230
        '
        'GRECDDATE
        '
        Me.GRECDDATE.Caption = "Recd Date"
        Me.GRECDDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRECDDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRECDDATE.FieldName = "RECDATE"
        Me.GRECDDATE.Name = "GRECDDATE"
        Me.GRECDDATE.OptionsColumn.AllowEdit = False
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "IRN No"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.OptionsColumn.AllowEdit = False
        Me.GIRNNO.Width = 120
        '
        'GDOCKETNO
        '
        Me.GDOCKETNO.Caption = "Docket No"
        Me.GDOCKETNO.FieldName = "DOCKETNO"
        Me.GDOCKETNO.Name = "GDOCKETNO"
        Me.GDOCKETNO.OptionsColumn.AllowEdit = False
        '
        'GDOCKETDATE
        '
        Me.GDOCKETDATE.Caption = "Docket Date"
        Me.GDOCKETDATE.FieldName = "DOCKETDATE"
        Me.GDOCKETDATE.Name = "GDOCKETDATE"
        Me.GDOCKETDATE.OptionsColumn.AllowEdit = False
        '
        'GCOURIER
        '
        Me.GCOURIER.Caption = "Courier"
        Me.GCOURIER.FieldName = "COURIER"
        Me.GCOURIER.Name = "GCOURIER"
        Me.GCOURIER.OptionsColumn.AllowEdit = False
        '
        'GCHGSDTLS
        '
        Me.GCHGSDTLS.Caption = "Charges Details"
        Me.GCHGSDTLS.FieldName = "CHGSDTLS"
        Me.GCHGSDTLS.Name = "GCHGSDTLS"
        Me.GCHGSDTLS.OptionsColumn.AllowEdit = False
        Me.GCHGSDTLS.Width = 200
        '
        'GTOCITY
        '
        Me.GTOCITY.Caption = "To City"
        Me.GTOCITY.FieldName = "TOCITY"
        Me.GTOCITY.Name = "GTOCITY"
        '
        'GINVINITIALS
        '
        Me.GINVINITIALS.Caption = "Inv Initial"
        Me.GINVINITIALS.FieldName = "INVINITIALS"
        Me.GINVINITIALS.Name = "GINVINITIALS"
        '
        'GTDSAMT
        '
        Me.GTDSAMT.Caption = "TDS Amt"
        Me.GTDSAMT.DisplayFormat.FormatString = "0.00"
        Me.GTDSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDSAMT.FieldName = "TDSAMT"
        Me.GTDSAMT.Name = "GTDSAMT"
        Me.GTDSAMT.OptionsColumn.AllowEdit = False
        Me.GTDSAMT.Visible = True
        Me.GTDSAMT.VisibleIndex = 10
        '
        'GPOSTAMT
        '
        Me.GPOSTAMT.Caption = "Post Amt"
        Me.GPOSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GPOSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPOSTAMT.FieldName = "POSTAMT"
        Me.GPOSTAMT.Name = "GPOSTAMT"
        Me.GPOSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPOSTAMT.Visible = True
        Me.GPOSTAMT.VisibleIndex = 11
        Me.GPOSTAMT.Width = 85
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'CMDPOST
        '
        Me.CMDPOST.BackColor = System.Drawing.Color.Transparent
        Me.CMDPOST.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPOST.FlatAppearance.BorderSize = 0
        Me.CMDPOST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPOST.ForeColor = System.Drawing.Color.Black
        Me.CMDPOST.Location = New System.Drawing.Point(535, 541)
        Me.CMDPOST.Name = "CMDPOST"
        Me.CMDPOST.Size = New System.Drawing.Size(80, 28)
        Me.CMDPOST.TabIndex = 7
        Me.CMDPOST.Text = "&Auto Post"
        Me.CMDPOST.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(619, 541)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 8
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(75, 33)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(255, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "Register"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'POSTINGDATE
        '
        Me.POSTINGDATE.AsciiOnly = True
        Me.POSTINGDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.POSTINGDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.POSTINGDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.POSTINGDATE.Location = New System.Drawing.Point(466, 33)
        Me.POSTINGDATE.Mask = "00/00/0000"
        Me.POSTINGDATE.Name = "POSTINGDATE"
        Me.POSTINGDATE.Size = New System.Drawing.Size(82, 23)
        Me.POSTINGDATE.TabIndex = 1
        Me.POSTINGDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.POSTINGDATE.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(388, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 14)
        Me.Label5.TabIndex = 702
        Me.Label5.Text = "Posting Date"
        '
        'SaleAutoTDS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleAutoTDS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Auto TDS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAGENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPPEDTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEWAYBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSPORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSPDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHARGES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWITHGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAPPLYTCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTCSPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTCSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUPPLIERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOCKETNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDOCKETDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOURIER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHGSDTLS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CMDPOST As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents cmbregister As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTTDSPER As TextBox
    Friend WithEvents CMBTDS As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GINVINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTTDSAMT As TextBox
    Friend WithEvents CMDAPPLYTDS As Button
    Friend WithEvents GTDSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents POSTINGDATE As MaskedTextBox
    Friend WithEvents Label5 As Label
End Class
