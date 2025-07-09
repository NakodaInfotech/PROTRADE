<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SaleOrderVsStockGridReport
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
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERTOTALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKINGMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDYEINGMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRGMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGGRN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPENDINGPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREORDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TBSTOCK = New System.Windows.Forms.TabPage()
        Me.GRIDSTOCKDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDSTOCK = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SPIECETYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TBDYEINGPROGRAM = New System.Windows.Forms.TabPage()
        Me.GRIDPRGDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDPRG = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GRIDGRNDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDGRN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GRIDPODETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDPO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDORDERDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDORDER = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ODUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TBSTOCK.SuspendLayout()
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TBDYEINGPROGRAM.SuspendLayout()
        CType(Me.GRIDPRGDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDPRG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.GRIDGRNDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDGRN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.GRIDPODETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDORDERDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDORDER, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.GRIDORDERDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1334, 581)
        Me.BlendPanel1.TabIndex = 4
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(12, 38)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(802, 497)
        Me.GRIDBILLDETAILS.TabIndex = 447
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDBILL.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDBILL.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMNAME, Me.GMILLNAME, Me.GDESIGNNO, Me.GSHADE, Me.GPCS, Me.GMTRS, Me.GORDERTOTALMTRS, Me.GPENDINGPCS, Me.GPENDINGMTRS, Me.GPACKINGMTRS, Me.GDYEINGMTRS, Me.GPRGMTRS, Me.GBALMTRS, Me.GPENDINGGRN, Me.GPENDINGPO, Me.GREORDER, Me.GFINALBAL, Me.GCATEGORY})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsMenu.EnableColumnMenu = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowFooter = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 180
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 7
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 1
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "COLOR"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 2
        '
        'GPCS
        '
        Me.GPCS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GPCS.AppearanceCell.Options.UseBackColor = True
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GMTRS
        '
        Me.GMTRS.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 3
        '
        'GORDERTOTALMTRS
        '
        Me.GORDERTOTALMTRS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.GORDERTOTALMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GORDERTOTALMTRS.Caption = "Total Order Mtrs"
        Me.GORDERTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GORDERTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GORDERTOTALMTRS.FieldName = "ORDERMTRS"
        Me.GORDERTOTALMTRS.Name = "GORDERTOTALMTRS"
        Me.GORDERTOTALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GPENDINGPCS
        '
        Me.GPENDINGPCS.Caption = "Pending Pcs"
        Me.GPENDINGPCS.DisplayFormat.FormatString = "0"
        Me.GPENDINGPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGPCS.FieldName = "PENDINGPCS"
        Me.GPENDINGPCS.Name = "GPENDINGPCS"
        Me.GPENDINGPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GPENDINGMTRS
        '
        Me.GPENDINGMTRS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.GPENDINGMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GPENDINGMTRS.Caption = "Pending Order"
        Me.GPENDINGMTRS.DisplayFormat.FormatString = "0.00"
        Me.GPENDINGMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGMTRS.FieldName = "PENDINGMTRS"
        Me.GPENDINGMTRS.Name = "GPENDINGMTRS"
        Me.GPENDINGMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPENDINGMTRS.Visible = True
        Me.GPENDINGMTRS.VisibleIndex = 4
        '
        'GPACKINGMTRS
        '
        Me.GPACKINGMTRS.Caption = "Packing Mtrs"
        Me.GPACKINGMTRS.DisplayFormat.FormatString = "0.00"
        Me.GPACKINGMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPACKINGMTRS.FieldName = "PACKINGMTRS"
        Me.GPACKINGMTRS.Name = "GPACKINGMTRS"
        Me.GPACKINGMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GDYEINGMTRS
        '
        Me.GDYEINGMTRS.Caption = "Dyeing Mtrs"
        Me.GDYEINGMTRS.DisplayFormat.FormatString = "0.00"
        Me.GDYEINGMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDYEINGMTRS.FieldName = "DYEINGMTRS"
        Me.GDYEINGMTRS.Name = "GDYEINGMTRS"
        Me.GDYEINGMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GPRGMTRS
        '
        Me.GPRGMTRS.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GPRGMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GPRGMTRS.Caption = "Prg Mtrs"
        Me.GPRGMTRS.DisplayFormat.FormatString = "0.00"
        Me.GPRGMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPRGMTRS.FieldName = "PROGRAMMTRS"
        Me.GPRGMTRS.Name = "GPRGMTRS"
        Me.GPRGMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPRGMTRS.Visible = True
        Me.GPRGMTRS.VisibleIndex = 5
        '
        'GBALMTRS
        '
        Me.GBALMTRS.Caption = "Bal Stock"
        Me.GBALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GBALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALMTRS.FieldName = "BALMTRS"
        Me.GBALMTRS.Name = "GBALMTRS"
        Me.GBALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALMTRS.Visible = True
        Me.GBALMTRS.VisibleIndex = 6
        '
        'GPENDINGGRN
        '
        Me.GPENDINGGRN.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GPENDINGGRN.AppearanceCell.Options.UseBackColor = True
        Me.GPENDINGGRN.Caption = "GRN For Prg"
        Me.GPENDINGGRN.DisplayFormat.FormatString = "0.00"
        Me.GPENDINGGRN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGGRN.FieldName = "PENDINGPRG"
        Me.GPENDINGGRN.Name = "GPENDINGGRN"
        '
        'GPENDINGPO
        '
        Me.GPENDINGPO.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GPENDINGPO.AppearanceCell.Options.UseBackColor = True
        Me.GPENDINGPO.Caption = "Pending PO"
        Me.GPENDINGPO.DisplayFormat.FormatString = "0.00"
        Me.GPENDINGPO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPENDINGPO.FieldName = "PENDINGPO"
        Me.GPENDINGPO.Name = "GPENDINGPO"
        '
        'GREORDER
        '
        Me.GREORDER.Caption = "Reorder Mtrs"
        Me.GREORDER.DisplayFormat.FormatString = "0.00"
        Me.GREORDER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREORDER.FieldName = "REORDERMTRS"
        Me.GREORDER.Name = "GREORDER"
        '
        'GFINALBAL
        '
        Me.GFINALBAL.Caption = "Final Stock"
        Me.GFINALBAL.DisplayFormat.FormatString = "0.00"
        Me.GFINALBAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINALBAL.FieldName = "FINALBAL"
        Me.GFINALBAL.Name = "GFINALBAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 545)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 669
        Me.Label6.Text = "Mtrs >"
        '
        'TXTMTRS
        '
        Me.TXTMTRS.Location = New System.Drawing.Point(78, 541)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(71, 23)
        Me.TXTMTRS.TabIndex = 670
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TBSTOCK)
        Me.TabControl1.Controls.Add(Me.TBDYEINGPROGRAM)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(820, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(502, 270)
        Me.TabControl1.TabIndex = 480
        '
        'TBSTOCK
        '
        Me.TBSTOCK.BackColor = System.Drawing.Color.Linen
        Me.TBSTOCK.Controls.Add(Me.GRIDSTOCKDETAILS)
        Me.TBSTOCK.Location = New System.Drawing.Point(4, 24)
        Me.TBSTOCK.Name = "TBSTOCK"
        Me.TBSTOCK.Padding = New System.Windows.Forms.Padding(3)
        Me.TBSTOCK.Size = New System.Drawing.Size(494, 242)
        Me.TBSTOCK.TabIndex = 0
        Me.TBSTOCK.Text = "Stock Details"
        '
        'GRIDSTOCKDETAILS
        '
        Me.GRIDSTOCKDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCKDETAILS.Location = New System.Drawing.Point(2, 2)
        Me.GRIDSTOCKDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSTOCKDETAILS.MainView = Me.GRIDSTOCK
        Me.GRIDSTOCKDETAILS.Name = "GRIDSTOCKDETAILS"
        Me.GRIDSTOCKDETAILS.Size = New System.Drawing.Size(490, 238)
        Me.GRIDSTOCKDETAILS.TabIndex = 448
        Me.GRIDSTOCKDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSTOCK})
        '
        'GRIDSTOCK
        '
        Me.GRIDSTOCK.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDSTOCK.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.Row.Options.UseFont = True
        Me.GRIDSTOCK.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDSTOCK.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDSTOCK.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDSTOCK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SPIECETYPE, Me.SUNIT, Me.GridColumn4, Me.GridColumn5})
        Me.GRIDSTOCK.GridControl = Me.GRIDSTOCKDETAILS
        Me.GRIDSTOCK.Name = "GRIDSTOCK"
        Me.GRIDSTOCK.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSTOCK.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDSTOCK.OptionsBehavior.Editable = False
        Me.GRIDSTOCK.OptionsMenu.EnableColumnMenu = False
        Me.GRIDSTOCK.OptionsView.ColumnAutoWidth = False
        Me.GRIDSTOCK.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDSTOCK.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSTOCK.OptionsView.ShowFooter = True
        Me.GRIDSTOCK.OptionsView.ShowGroupPanel = False
        '
        'SPIECETYPE
        '
        Me.SPIECETYPE.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.SPIECETYPE.AppearanceCell.Options.UseBackColor = True
        Me.SPIECETYPE.Caption = "Piece Type"
        Me.SPIECETYPE.FieldName = "PIECETYPE"
        Me.SPIECETYPE.Name = "SPIECETYPE"
        Me.SPIECETYPE.Visible = True
        Me.SPIECETYPE.VisibleIndex = 0
        Me.SPIECETYPE.Width = 130
        '
        'SUNIT
        '
        Me.SUNIT.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.SUNIT.AppearanceCell.Options.UseBackColor = True
        Me.SUNIT.Caption = "Unit"
        Me.SUNIT.FieldName = "UNIT"
        Me.SUNIT.Name = "SUNIT"
        Me.SUNIT.Visible = True
        Me.SUNIT.VisibleIndex = 1
        Me.SUNIT.Width = 130
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GridColumn4.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn4.Caption = "Pcs"
        Me.GridColumn4.DisplayFormat.FormatString = "0"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "PCS"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GridColumn5.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn5.Caption = "Mtrs"
        Me.GridColumn5.DisplayFormat.FormatString = "0.00"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "MTRS"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 100
        '
        'TBDYEINGPROGRAM
        '
        Me.TBDYEINGPROGRAM.BackColor = System.Drawing.Color.LightCyan
        Me.TBDYEINGPROGRAM.Controls.Add(Me.GRIDPRGDETAILS)
        Me.TBDYEINGPROGRAM.Location = New System.Drawing.Point(4, 22)
        Me.TBDYEINGPROGRAM.Name = "TBDYEINGPROGRAM"
        Me.TBDYEINGPROGRAM.Padding = New System.Windows.Forms.Padding(3)
        Me.TBDYEINGPROGRAM.Size = New System.Drawing.Size(494, 244)
        Me.TBDYEINGPROGRAM.TabIndex = 1
        Me.TBDYEINGPROGRAM.Text = "Dyeing Program Details"
        '
        'GRIDPRGDETAILS
        '
        Me.GRIDPRGDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPRGDETAILS.Location = New System.Drawing.Point(2, 2)
        Me.GRIDPRGDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDPRGDETAILS.MainView = Me.GRIDPRG
        Me.GRIDPRGDETAILS.Name = "GRIDPRGDETAILS"
        Me.GRIDPRGDETAILS.Size = New System.Drawing.Size(489, 238)
        Me.GRIDPRGDETAILS.TabIndex = 450
        Me.GRIDPRGDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDPRG})
        '
        'GRIDPRG
        '
        Me.GRIDPRG.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPRG.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDPRG.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPRG.Appearance.Row.Options.UseFont = True
        Me.GRIDPRG.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDPRG.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDPRG.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPRG.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDPRG.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn2, Me.GridColumn3, Me.GridColumn8, Me.GridColumn14})
        Me.GRIDPRG.GridControl = Me.GRIDPRGDETAILS
        Me.GRIDPRG.Name = "GRIDPRG"
        Me.GRIDPRG.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDPRG.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDPRG.OptionsBehavior.Editable = False
        Me.GRIDPRG.OptionsMenu.EnableColumnMenu = False
        Me.GRIDPRG.OptionsView.ColumnAutoWidth = False
        Me.GRIDPRG.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDPRG.OptionsView.ShowAutoFilterRow = True
        Me.GRIDPRG.OptionsView.ShowFooter = True
        Me.GRIDPRG.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GridColumn1.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn1.Caption = "Dyeing Name"
        Me.GridColumn1.FieldName = "NAME"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 200
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GridColumn6.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn6.Caption = "Lot No"
        Me.GridColumn6.FieldName = "LOTNO"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GridColumn2.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn2.Caption = "Prg No"
        Me.GridColumn2.FieldName = "PRGNO"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Width = 65
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GridColumn3.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn3.Caption = "Date"
        Me.GridColumn3.FieldName = "DATE"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GridColumn8.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn8.Caption = "Prg Mtrs"
        Me.GridColumn8.DisplayFormat.FormatString = "0.00"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "MTRS"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        Me.GridColumn8.Width = 60
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GridColumn14.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn14.Caption = "Bal Prg"
        Me.GridColumn14.DisplayFormat.FormatString = "0.00"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "BALMTRS"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 60
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LightPink
        Me.TabPage1.Controls.Add(Me.GRIDGRNDETAILS)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(494, 244)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Pending GRN for Program"
        '
        'GRIDGRNDETAILS
        '
        Me.GRIDGRNDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDGRNDETAILS.Location = New System.Drawing.Point(3, 2)
        Me.GRIDGRNDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDGRNDETAILS.MainView = Me.GRIDGRN
        Me.GRIDGRNDETAILS.Name = "GRIDGRNDETAILS"
        Me.GRIDGRNDETAILS.Size = New System.Drawing.Size(489, 238)
        Me.GRIDGRNDETAILS.TabIndex = 451
        Me.GRIDGRNDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDGRN})
        '
        'GRIDGRN
        '
        Me.GRIDGRN.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDGRN.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDGRN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDGRN.Appearance.Row.Options.UseFont = True
        Me.GRIDGRN.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDGRN.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDGRN.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDGRN.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDGRN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn18})
        Me.GRIDGRN.GridControl = Me.GRIDGRNDETAILS
        Me.GRIDGRN.Name = "GRIDGRN"
        Me.GRIDGRN.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDGRN.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDGRN.OptionsBehavior.Editable = False
        Me.GRIDGRN.OptionsMenu.EnableColumnMenu = False
        Me.GRIDGRN.OptionsView.ColumnAutoWidth = False
        Me.GRIDGRN.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDGRN.OptionsView.ShowAutoFilterRow = True
        Me.GRIDGRN.OptionsView.ShowFooter = True
        Me.GRIDGRN.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GridColumn7.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn7.Caption = "Dyeing Name"
        Me.GridColumn7.FieldName = "NAME"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 225
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GridColumn9.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn9.Caption = "Lot No"
        Me.GridColumn9.FieldName = "LOTNO"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GridColumn10.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn10.Caption = "Prg No"
        Me.GridColumn10.FieldName = "GRNNO"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Width = 65
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GridColumn11.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn11.Caption = "Date"
        Me.GridColumn11.FieldName = "DATE"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 3
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GridColumn12.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn12.Caption = "GRN Mtrs"
        Me.GridColumn12.DisplayFormat.FormatString = "0.00"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "MTRS"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        Me.GridColumn12.Width = 70
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.BackColor = System.Drawing.Color.LightPink
        Me.GridColumn18.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn18.Caption = "GRN No"
        Me.GridColumn18.FieldName = "GRNNO"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GRIDPODETAILS)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(494, 244)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Pending PO"
        '
        'GRIDPODETAILS
        '
        Me.GRIDPODETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPODETAILS.Location = New System.Drawing.Point(3, 2)
        Me.GRIDPODETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDPODETAILS.MainView = Me.GRIDPO
        Me.GRIDPODETAILS.Name = "GRIDPODETAILS"
        Me.GRIDPODETAILS.Size = New System.Drawing.Size(489, 238)
        Me.GRIDPODETAILS.TabIndex = 452
        Me.GRIDPODETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDPO})
        '
        'GRIDPO
        '
        Me.GRIDPO.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPO.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDPO.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPO.Appearance.Row.Options.UseFont = True
        Me.GRIDPO.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDPO.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDPO.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDPO.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDPO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17})
        Me.GRIDPO.GridControl = Me.GRIDPODETAILS
        Me.GRIDPO.Name = "GRIDPO"
        Me.GRIDPO.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDPO.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDPO.OptionsBehavior.Editable = False
        Me.GRIDPO.OptionsMenu.EnableColumnMenu = False
        Me.GRIDPO.OptionsView.ColumnAutoWidth = False
        Me.GRIDPO.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDPO.OptionsView.ShowAutoFilterRow = True
        Me.GRIDPO.OptionsView.ShowFooter = True
        Me.GRIDPO.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn13.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn13.Caption = "Name"
        Me.GridColumn13.FieldName = "NAME"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 225
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn15.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn15.Caption = "PO No"
        Me.GridColumn15.FieldName = "PONO"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        Me.GridColumn15.Width = 65
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn16.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn16.Caption = "Date"
        Me.GridColumn16.FieldName = "DATE"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn17.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn17.Caption = "PO Mtrs"
        Me.GridColumn17.DisplayFormat.FormatString = "0.00"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "MTRS"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        Me.GridColumn17.Width = 70
        '
        'GRIDORDERDETAILS
        '
        Me.GRIDORDERDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDERDETAILS.Location = New System.Drawing.Point(820, 314)
        Me.GRIDORDERDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDORDERDETAILS.MainView = Me.GRIDORDER
        Me.GRIDORDERDETAILS.Name = "GRIDORDERDETAILS"
        Me.GRIDORDERDETAILS.Size = New System.Drawing.Size(502, 255)
        Me.GRIDORDERDETAILS.TabIndex = 449
        Me.GRIDORDERDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDORDER})
        '
        'GRIDORDER
        '
        Me.GRIDORDER.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDER.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDORDER.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDER.Appearance.Row.Options.UseFont = True
        Me.GRIDORDER.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDORDER.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDORDER.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDORDER.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDORDER.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ONAME, Me.OORDERNO, Me.ODUEDATE, Me.OUNIT, Me.OPCS, Me.OMTRS})
        Me.GRIDORDER.GridControl = Me.GRIDORDERDETAILS
        Me.GRIDORDER.Name = "GRIDORDER"
        Me.GRIDORDER.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDORDER.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDORDER.OptionsBehavior.Editable = False
        Me.GRIDORDER.OptionsMenu.EnableColumnMenu = False
        Me.GRIDORDER.OptionsView.ColumnAutoWidth = False
        Me.GRIDORDER.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDORDER.OptionsView.ShowAutoFilterRow = True
        Me.GRIDORDER.OptionsView.ShowFooter = True
        Me.GRIDORDER.OptionsView.ShowGroupPanel = False
        '
        'ONAME
        '
        Me.ONAME.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.ONAME.AppearanceCell.Options.UseBackColor = True
        Me.ONAME.Caption = "Name"
        Me.ONAME.FieldName = "NAME"
        Me.ONAME.Name = "ONAME"
        Me.ONAME.Visible = True
        Me.ONAME.VisibleIndex = 0
        Me.ONAME.Width = 160
        '
        'OORDERNO
        '
        Me.OORDERNO.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OORDERNO.AppearanceCell.Options.UseBackColor = True
        Me.OORDERNO.Caption = "Order No"
        Me.OORDERNO.FieldName = "ORDERNO"
        Me.OORDERNO.Name = "OORDERNO"
        Me.OORDERNO.Visible = True
        Me.OORDERNO.VisibleIndex = 1
        Me.OORDERNO.Width = 65
        '
        'ODUEDATE
        '
        Me.ODUEDATE.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.ODUEDATE.AppearanceCell.Options.UseBackColor = True
        Me.ODUEDATE.Caption = "Due Date"
        Me.ODUEDATE.FieldName = "DUEDATE"
        Me.ODUEDATE.Name = "ODUEDATE"
        Me.ODUEDATE.Visible = True
        Me.ODUEDATE.VisibleIndex = 2
        '
        'OUNIT
        '
        Me.OUNIT.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OUNIT.AppearanceCell.Options.UseBackColor = True
        Me.OUNIT.Caption = "Unit"
        Me.OUNIT.FieldName = "UNIT"
        Me.OUNIT.Name = "OUNIT"
        Me.OUNIT.Visible = True
        Me.OUNIT.VisibleIndex = 3
        Me.OUNIT.Width = 60
        '
        'OPCS
        '
        Me.OPCS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OPCS.AppearanceCell.Options.UseBackColor = True
        Me.OPCS.Caption = "Pcs"
        Me.OPCS.DisplayFormat.FormatString = "0"
        Me.OPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.OPCS.FieldName = "PCS"
        Me.OPCS.Name = "OPCS"
        Me.OPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.OPCS.Visible = True
        Me.OPCS.VisibleIndex = 4
        Me.OPCS.Width = 40
        '
        'OMTRS
        '
        Me.OMTRS.AppearanceCell.BackColor = System.Drawing.Color.LemonChiffon
        Me.OMTRS.AppearanceCell.Options.UseBackColor = True
        Me.OMTRS.Caption = "Mtrs"
        Me.OMTRS.DisplayFormat.FormatString = "0.00"
        Me.OMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.OMTRS.FieldName = "MTRS"
        Me.OMTRS.Name = "OMTRS"
        Me.OMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.OMTRS.Visible = True
        Me.OMTRS.VisibleIndex = 5
        Me.OMTRS.Width = 60
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMDPRINT.Location = New System.Drawing.Point(627, 541)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(80, 28)
        Me.CMDPRINT.TabIndex = 5
        Me.CMDPRINT.Text = "&Print"
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(713, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1, Me.TOOLREFRESH})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1334, 25)
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
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.PROTRADE.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'SaleOrderVsStockGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1334, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SaleOrderVsStockGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Order Vs Stock Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TBSTOCK.ResumeLayout(False)
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TBDYEINGPROGRAM.ResumeLayout(False)
        CType(Me.GRIDPRGDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDPRG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.GRIDGRNDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDGRN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.GRIDPODETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDORDERDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDORDER, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TBSTOCK As TabPage
    Private WithEvents GRIDSTOCKDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSTOCK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SPIECETYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TBDYEINGPROGRAM As TabPage
    Private WithEvents GRIDPRGDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDPRG As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDORDERDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDORDER As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ONAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ODUEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKINGMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDYEINGMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRGMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDPRINT As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents GREORDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGGRN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabPage1 As TabPage
    Private WithEvents GRIDGRNDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDGRN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabPage2 As TabPage
    Private WithEvents GRIDPODETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDPO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTMTRS As TextBox
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALBAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn

    'Friend WithEvents gridliabilities As System.Windows.Forms.DataGridView
End Class
