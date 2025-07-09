<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceGridDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoiceGridDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAGENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPPEDTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSPDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHARGES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRETURNAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUPPLIERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.GGSTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADDRESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEWAYBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKINGADD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(228, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 14)
        Me.Label2.TabIndex = 447
        Me.Label2.Text = "Disputed"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightGreen
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(291, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 17)
        Me.Label3.TabIndex = 446
        Me.Label3.Text = "   "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(312, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 14)
        Me.Label21.TabIndex = 445
        Me.Label21.Text = "Checked"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(206, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 444
        Me.Label22.Text = "   "
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(22, 61)
        Me.gridbilldetails.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.gridbilldetails.Size = New System.Drawing.Size(1200, 472)
        Me.gridbilldetails.TabIndex = 7
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GLRNO, Me.GCHALLANNO, Me.GCHALLANDATE, Me.GREFNO, Me.gname, Me.GGSTNO, Me.GADDRESS, Me.GEWAYBILLNO, Me.GIRNNO, Me.GLRDATE, Me.GITEMNAME, Me.GHSNCODE, Me.GQUALITY, Me.GDESIGNNO, Me.GSHADE, Me.GBALENO, Me.GPCS, Me.GMTRS, Me.GRATE, Me.GAMT, Me.GAGENT, Me.GSHIPPEDTO, Me.GPACKINGADD, Me.GTRANSPORT, Me.GTRANSGSTIN, Me.GSO, Me.GBALES, Me.GTOTALAMT, Me.GDISC, Me.GSPDISCAMT, Me.GCHARGES, Me.GTOTALTAXABLEAMT, Me.GCGSTPER, Me.GTOTALCGSTAMT, Me.GSGSTPER, Me.GTOTALSGSTAMT, Me.GIGSTPER, Me.GTOTALIGSTAMT, Me.GGRANDTOTAL, Me.GRECDAMT, Me.GRETURNAMT, Me.GBALANCE, Me.GREMARKS, Me.GDISPUTED, Me.GBILLCHECKED, Me.GSUPPLIERNAME, Me.GRECDDATE, Me.GSTATE, Me.GCITY, Me.GREGNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "INVOICENO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        Me.gsrno.Width = 60
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "INVOICEDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 3
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No."
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 4
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Ch. Date"
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 5
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 6
        Me.gname.Width = 230
        '
        'GLRDATE
        '
        Me.GLRDATE.Caption = "LR Date"
        Me.GLRDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GLRDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GLRDATE.FieldName = "LRDATE"
        Me.GLRDATE.Name = "GLRDATE"
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 11
        Me.GITEMNAME.Width = 150
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Width = 100
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGN"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 13
        Me.GDESIGNNO.Width = 120
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "COLOR"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 14
        Me.GSHADE.Width = 100
        '
        'GBALENO
        '
        Me.GBALENO.Caption = "Bale No"
        Me.GBALENO.FieldName = "BALENO"
        Me.GBALENO.Name = "GBALENO"
        Me.GBALENO.Visible = True
        Me.GBALENO.VisibleIndex = 15
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0.00"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 16
        Me.GPCS.Width = 85
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 17
        Me.GMTRS.Width = 85
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 18
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 19
        '
        'GAGENT
        '
        Me.GAGENT.Caption = "Agent Name"
        Me.GAGENT.FieldName = "AGENT"
        Me.GAGENT.Name = "GAGENT"
        Me.GAGENT.Visible = True
        Me.GAGENT.VisibleIndex = 20
        Me.GAGENT.Width = 150
        '
        'GSHIPPEDTO
        '
        Me.GSHIPPEDTO.Caption = "Shipped To"
        Me.GSHIPPEDTO.FieldName = "PACKING"
        Me.GSHIPPEDTO.Name = "GSHIPPEDTO"
        Me.GSHIPPEDTO.Visible = True
        Me.GSHIPPEDTO.VisibleIndex = 21
        Me.GSHIPPEDTO.Width = 100
        '
        'GTRANSPORT
        '
        Me.GTRANSPORT.Caption = "Transport"
        Me.GTRANSPORT.FieldName = "TRANSNAME"
        Me.GTRANSPORT.Name = "GTRANSPORT"
        Me.GTRANSPORT.Visible = True
        Me.GTRANSPORT.VisibleIndex = 23
        Me.GTRANSPORT.Width = 150
        '
        'GSO
        '
        Me.GSO.Caption = "SO No."
        Me.GSO.FieldName = "PONO"
        Me.GSO.Name = "GSO"
        Me.GSO.Visible = True
        Me.GSO.VisibleIndex = 25
        '
        'GBALES
        '
        Me.GBALES.Caption = "Bales"
        Me.GBALES.DisplayFormat.FormatString = "0"
        Me.GBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALES.FieldName = "BALENOFROM"
        Me.GBALES.Name = "GBALES"
        Me.GBALES.Visible = True
        Me.GBALES.VisibleIndex = 26
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALAMT.FieldName = "AMOUNT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 27
        '
        'GDISC
        '
        Me.GDISC.Caption = "Total Disc Amt."
        Me.GDISC.FieldName = "TOTALDISCAMT"
        Me.GDISC.Name = "GDISC"
        Me.GDISC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISC.Visible = True
        Me.GDISC.VisibleIndex = 28
        Me.GDISC.Width = 80
        '
        'GSPDISCAMT
        '
        Me.GSPDISCAMT.Caption = "Total Sp Disc Amt."
        Me.GSPDISCAMT.FieldName = "TOTALSPDISCAMT"
        Me.GSPDISCAMT.Name = "GSPDISCAMT"
        Me.GSPDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSPDISCAMT.Visible = True
        Me.GSPDISCAMT.VisibleIndex = 29
        '
        'GCHARGES
        '
        Me.GCHARGES.Caption = "Charges"
        Me.GCHARGES.FieldName = "CHARGES"
        Me.GCHARGES.Name = "GCHARGES"
        Me.GCHARGES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCHARGES.Visible = True
        Me.GCHARGES.VisibleIndex = 30
        '
        'GTOTALTAXABLEAMT
        '
        Me.GTOTALTAXABLEAMT.Caption = "Total Taxable Amt."
        Me.GTOTALTAXABLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALTAXABLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALTAXABLEAMT.FieldName = "TOTALTAXABLEAMT"
        Me.GTOTALTAXABLEAMT.Name = "GTOTALTAXABLEAMT"
        Me.GTOTALTAXABLEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALTAXABLEAMT.Visible = True
        Me.GTOTALTAXABLEAMT.VisibleIndex = 31
        '
        'GTOTALCGSTAMT
        '
        Me.GTOTALCGSTAMT.Caption = "Total CGST Amt."
        Me.GTOTALCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCGSTAMT.FieldName = "TOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Name = "GTOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALCGSTAMT.Visible = True
        Me.GTOTALCGSTAMT.VisibleIndex = 33
        '
        'GTOTALSGSTAMT
        '
        Me.GTOTALSGSTAMT.Caption = "Total SGST Amt."
        Me.GTOTALSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALSGSTAMT.FieldName = "TOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Name = "GTOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALSGSTAMT.Visible = True
        Me.GTOTALSGSTAMT.VisibleIndex = 35
        '
        'GTOTALIGSTAMT
        '
        Me.GTOTALIGSTAMT.Caption = "Total IGST Amt."
        Me.GTOTALIGSTAMT.FieldName = "TOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Name = "GTOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALIGSTAMT.Visible = True
        Me.GTOTALIGSTAMT.VisibleIndex = 37
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRANDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRANDTOTAL.FieldName = "GRANDTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 38
        Me.GGRANDTOTAL.Width = 85
        '
        'GRECDAMT
        '
        Me.GRECDAMT.Caption = "Recd Amt"
        Me.GRECDAMT.DisplayFormat.FormatString = "0.00"
        Me.GRECDAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECDAMT.FieldName = "AMTREC"
        Me.GRECDAMT.Name = "GRECDAMT"
        Me.GRECDAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECDAMT.Visible = True
        Me.GRECDAMT.VisibleIndex = 39
        '
        'GRETURNAMT
        '
        Me.GRETURNAMT.Caption = "Sale Ret Amt"
        Me.GRETURNAMT.DisplayFormat.FormatString = "0.00"
        Me.GRETURNAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURNAMT.FieldName = "RETURN"
        Me.GRETURNAMT.Name = "GRETURNAMT"
        Me.GRETURNAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRETURNAMT.Visible = True
        Me.GRETURNAMT.VisibleIndex = 40
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "Bal Amt"
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 41
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 42
        Me.GREMARKS.Width = 150
        '
        'GDISPUTED
        '
        Me.GDISPUTED.Caption = "Disputed"
        Me.GDISPUTED.FieldName = "BILLDISPUTE"
        Me.GDISPUTED.Name = "GDISPUTED"
        Me.GDISPUTED.Visible = True
        Me.GDISPUTED.VisibleIndex = 43
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Checked"
        Me.GBILLCHECKED.FieldName = "BILLCHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.Visible = True
        Me.GBILLCHECKED.VisibleIndex = 44
        '
        'GSUPPLIERNAME
        '
        Me.GSUPPLIERNAME.Caption = "Supplier Name"
        Me.GSUPPLIERNAME.FieldName = "PURNAME"
        Me.GSUPPLIERNAME.Name = "GSUPPLIERNAME"
        Me.GSUPPLIERNAME.Width = 230
        '
        'GRECDDATE
        '
        Me.GRECDDATE.Caption = "Recd Date"
        Me.GRECDDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRECDDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRECDDATE.FieldName = "RECDATE"
        Me.GRECDDATE.Name = "GRECDDATE"
        '
        'GSTATE
        '
        Me.GSTATE.Caption = "State Name"
        Me.GSTATE.FieldName = "STATENAME"
        Me.GSTATE.Name = "GSTATE"
        Me.GSTATE.Visible = True
        Me.GSTATE.VisibleIndex = 45
        Me.GSTATE.Width = 100
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITYNAME"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 46
        Me.GCITY.Width = 100
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(535, 541)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 1
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(619, 540)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 2
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(967, 35)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(255, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(910, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "Register"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.TOOLMAIL, Me.ToolStripButton2, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
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
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.PROTRADE.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Invoice Directly"
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(20, 44)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(156, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select an Invoice to Change"
        '
        'GGSTNO
        '
        Me.GGSTNO.Caption = "GSTIN"
        Me.GGSTNO.FieldName = "GSTIN"
        Me.GGSTNO.Name = "GGSTNO"
        Me.GGSTNO.Visible = True
        Me.GGSTNO.VisibleIndex = 7
        Me.GGSTNO.Width = 120
        '
        'GREGNAME
        '
        Me.GREGNAME.Caption = "Register"
        Me.GREGNAME.FieldName = "REGNAME"
        Me.GREGNAME.Name = "GREGNAME"
        Me.GREGNAME.Visible = True
        Me.GREGNAME.VisibleIndex = 47
        Me.GREGNAME.Width = 120
        '
        'GADDRESS
        '
        Me.GADDRESS.Caption = "Address"
        Me.GADDRESS.FieldName = "ADDRESS"
        Me.GADDRESS.Name = "GADDRESS"
        Me.GADDRESS.Visible = True
        Me.GADDRESS.VisibleIndex = 8
        Me.GADDRESS.Width = 300
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 12
        '
        'GEWAYBILLNO
        '
        Me.GEWAYBILLNO.Caption = "Eway Bill No"
        Me.GEWAYBILLNO.FieldName = "EWAYBILLNO"
        Me.GEWAYBILLNO.Name = "GEWAYBILLNO"
        Me.GEWAYBILLNO.Visible = True
        Me.GEWAYBILLNO.VisibleIndex = 9
        Me.GEWAYBILLNO.Width = 120
        '
        'GCGSTPER
        '
        Me.GCGSTPER.Caption = "CGST %"
        Me.GCGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GCGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTPER.FieldName = "CGSTPER"
        Me.GCGSTPER.Name = "GCGSTPER"
        Me.GCGSTPER.Visible = True
        Me.GCGSTPER.VisibleIndex = 32
        '
        'GSGSTPER
        '
        Me.GSGSTPER.Caption = "SGST %"
        Me.GSGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GSGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTPER.FieldName = "SGSTPER"
        Me.GSGSTPER.Name = "GSGSTPER"
        Me.GSGSTPER.Visible = True
        Me.GSGSTPER.VisibleIndex = 34
        '
        'GIGSTPER
        '
        Me.GIGSTPER.Caption = "IGST %"
        Me.GIGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GIGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTPER.FieldName = "IGSTPER"
        Me.GIGSTPER.Name = "GIGSTPER"
        Me.GIGSTPER.Visible = True
        Me.GIGSTPER.VisibleIndex = 36
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "IRN No"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 10
        Me.GIRNNO.Width = 150
        '
        'GPACKINGADD
        '
        Me.GPACKINGADD.Caption = "Ship To Address"
        Me.GPACKINGADD.FieldName = "PACKINGADDRESS"
        Me.GPACKINGADD.Name = "GPACKINGADD"
        Me.GPACKINGADD.Visible = True
        Me.GPACKINGADD.VisibleIndex = 22
        Me.GPACKINGADD.Width = 300
        '
        'GTRANSGSTIN
        '
        Me.GTRANSGSTIN.Caption = "Trans GSTIN"
        Me.GTRANSGSTIN.FieldName = "TRANSGSTIN"
        Me.GTRANSGSTIN.Name = "GTRANSGSTIN"
        Me.GTRANSGSTIN.Visible = True
        Me.GTRANSGSTIN.VisibleIndex = 24
        Me.GTRANSGSTIN.Width = 100
        '
        'InvoiceGridDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "InvoiceGridDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice Grid Details"
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
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAGENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPPEDTO As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUPPLIERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents cmbregister As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADDRESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEWAYBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKINGADD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSGSTIN As DevExpress.XtraGrid.Columns.GridColumn
End Class
