<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockDetailsGridReport
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
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gtype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillinitials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRUNNINGBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.greg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TBSTOCK = New System.Windows.Forms.TabPage()
        Me.TBSUMMARY = New System.Windows.Forms.TabPage()
        Me.GRIDSUMMDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDSUMM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TBSTOCK.SuspendLayout()
        Me.TBSUMMARY.SuspendLayout()
        CType(Me.GRIDSUMMDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSUMM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(3, 3)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1169, 473)
        Me.griddetails.TabIndex = 447
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.Row.Options.UseTextOptions = True
        Me.gridregister.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gtype, Me.gDate, Me.gname, Me.gbillinitials, Me.GREFNO, Me.GGODOWN, Me.GITEMNAME, Me.GINMTRS, Me.GOUTMTRS, Me.GRUNNINGBAL, Me.gbillno, Me.greg})
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
        'gtype
        '
        Me.gtype.Caption = "Type"
        Me.gtype.FieldName = "ENTRYTYPE"
        Me.gtype.Name = "gtype"
        Me.gtype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gtype.Visible = True
        Me.gtype.VisibleIndex = 0
        '
        'gDate
        '
        Me.gDate.Caption = "Date"
        Me.gDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gDate.FieldName = "DATE"
        Me.gDate.Name = "gDate"
        Me.gDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.gDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gDate.Visible = True
        Me.gDate.VisibleIndex = 1
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 2
        Me.gname.Width = 200
        '
        'gbillinitials
        '
        Me.gbillinitials.Caption = "Bill No."
        Me.gbillinitials.FieldName = "BILLINITIALS"
        Me.gbillinitials.ImageIndex = 1
        Me.gbillinitials.Name = "gbillinitials"
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 3
        Me.gbillinitials.Width = 100
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "CHALLANNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 4
        Me.GREFNO.Width = 100
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 5
        Me.GGODOWN.Width = 100
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 6
        Me.GITEMNAME.Width = 200
        '
        'GINMTRS
        '
        Me.GINMTRS.Caption = "Inward Mtrs"
        Me.GINMTRS.DisplayFormat.FormatString = "0.00"
        Me.GINMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINMTRS.FieldName = "MTRS"
        Me.GINMTRS.Name = "GINMTRS"
        Me.GINMTRS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GINMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MTRS", "{0:0.00}")})
        Me.GINMTRS.Visible = True
        Me.GINMTRS.VisibleIndex = 7
        Me.GINMTRS.Width = 90
        '
        'GOUTMTRS
        '
        Me.GOUTMTRS.Caption = "Outward Mtrs"
        Me.GOUTMTRS.DisplayFormat.FormatString = "0.00"
        Me.GOUTMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOUTMTRS.FieldName = "ISSMTRS"
        Me.GOUTMTRS.Name = "GOUTMTRS"
        Me.GOUTMTRS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GOUTMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ISSMTRS", "{0:0.00}")})
        Me.GOUTMTRS.Visible = True
        Me.GOUTMTRS.VisibleIndex = 8
        Me.GOUTMTRS.Width = 90
        '
        'GRUNNINGBAL
        '
        Me.GRUNNINGBAL.Caption = "Running Mtrs"
        Me.GRUNNINGBAL.DisplayFormat.FormatString = "0.00"
        Me.GRUNNINGBAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRUNNINGBAL.FieldName = "RUNNINGBAL"
        Me.GRUNNINGBAL.Name = "GRUNNINGBAL"
        Me.GRUNNINGBAL.Visible = True
        Me.GRUNNINGBAL.VisibleIndex = 9
        Me.GRUNNINGBAL.Width = 90
        '
        'gbillno
        '
        Me.gbillno.Caption = "Bill no"
        Me.gbillno.FieldName = "NO"
        Me.gbillno.Name = "gbillno"
        '
        'greg
        '
        Me.greg.Caption = "Reg Name"
        Me.greg.FieldName = "REGNAME"
        Me.greg.Name = "greg"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 541)
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
        Me.cmdexit.Location = New System.Drawing.Point(595, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TBSTOCK)
        Me.TabControl1.Controls.Add(Me.TBSUMMARY)
        Me.TabControl1.Location = New System.Drawing.Point(26, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1183, 507)
        Me.TabControl1.TabIndex = 448
        '
        'TBSTOCK
        '
        Me.TBSTOCK.AutoScroll = True
        Me.TBSTOCK.Controls.Add(Me.griddetails)
        Me.TBSTOCK.Location = New System.Drawing.Point(4, 24)
        Me.TBSTOCK.Name = "TBSTOCK"
        Me.TBSTOCK.Padding = New System.Windows.Forms.Padding(3)
        Me.TBSTOCK.Size = New System.Drawing.Size(1175, 479)
        Me.TBSTOCK.TabIndex = 0
        Me.TBSTOCK.Text = "Stock Details"
        Me.TBSTOCK.UseVisualStyleBackColor = True
        '
        'TBSUMMARY
        '
        Me.TBSUMMARY.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TBSUMMARY.Controls.Add(Me.GRIDSUMMDETAILS)
        Me.TBSUMMARY.Location = New System.Drawing.Point(4, 24)
        Me.TBSUMMARY.Name = "TBSUMMARY"
        Me.TBSUMMARY.Padding = New System.Windows.Forms.Padding(3)
        Me.TBSUMMARY.Size = New System.Drawing.Size(1175, 479)
        Me.TBSUMMARY.TabIndex = 1
        Me.TBSUMMARY.Text = "Summary"
        '
        'GRIDSUMMDETAILS
        '
        Me.GRIDSUMMDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSUMMDETAILS.Location = New System.Drawing.Point(0, 3)
        Me.GRIDSUMMDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSUMMDETAILS.MainView = Me.GRIDSUMM
        Me.GRIDSUMMDETAILS.Name = "GRIDSUMMDETAILS"
        Me.GRIDSUMMDETAILS.Size = New System.Drawing.Size(1169, 473)
        Me.GRIDSUMMDETAILS.TabIndex = 448
        Me.GRIDSUMMDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSUMM})
        '
        'GRIDSUMM
        '
        Me.GRIDSUMM.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSUMM.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDSUMM.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSUMM.Appearance.Row.Options.UseFont = True
        Me.GRIDSUMM.Appearance.Row.Options.UseTextOptions = True
        Me.GRIDSUMM.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GRIDSUMM.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSUMM.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDSUMM.GridControl = Me.GRIDSUMMDETAILS
        Me.GRIDSUMM.Name = "GRIDSUMM"
        Me.GRIDSUMM.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSUMM.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDSUMM.OptionsBehavior.Editable = False
        Me.GRIDSUMM.OptionsMenu.EnableColumnMenu = False
        Me.GRIDSUMM.OptionsView.ColumnAutoWidth = False
        Me.GRIDSUMM.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDSUMM.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSUMM.OptionsView.ShowFooter = True
        Me.GRIDSUMM.OptionsView.ShowGroupPanel = False
        '
        'StockDetailsGridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockDetailsGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Details Grid Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TBSTOCK.ResumeLayout(False)
        Me.TBSUMMARY.ResumeLayout(False)
        CType(Me.GRIDSUMMDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSUMM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gDate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gtype As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillinitials As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GINMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GOUTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRUNNINGBAL As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gbillno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents greg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TBSTOCK As TabPage
    Friend WithEvents TBSUMMARY As TabPage
    Private WithEvents GRIDSUMMDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSUMM As DevExpress.XtraGrid.Views.Grid.GridView
End Class
