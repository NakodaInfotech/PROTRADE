<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSOforScheduling
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.GRIDSTOCKDETAILS = New DevExpress.XtraGrid.GridControl
        Me.GRIDSTOCK = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GSTOCKITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTOCKSHADE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTOCKPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox
        Me.lbl = New System.Windows.Forms.Label
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.GSTOCKMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTOCKUNIT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GRIDSTOCKDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1304, 712)
        Me.BlendPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(851, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 23)
        Me.Label1.TabIndex = 651
        Me.Label1.Text = "Stock"
        '
        'GRIDSTOCKDETAILS
        '
        Me.GRIDSTOCKDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCKDETAILS.Location = New System.Drawing.Point(851, 36)
        Me.GRIDSTOCKDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSTOCKDETAILS.MainView = Me.GRIDSTOCK
        Me.GRIDSTOCKDETAILS.Name = "GRIDSTOCKDETAILS"
        Me.GRIDSTOCKDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemDateEdit1})
        Me.GRIDSTOCKDETAILS.Size = New System.Drawing.Size(441, 630)
        Me.GRIDSTOCKDETAILS.TabIndex = 650
        Me.GRIDSTOCKDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSTOCK})
        '
        'GRIDSTOCK
        '
        Me.GRIDSTOCK.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSTOCK.Appearance.Row.Options.UseFont = True
        Me.GRIDSTOCK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSTOCKITEMNAME, Me.GSTOCKSHADE, Me.GSTOCKUNIT, Me.GSTOCKPCS, Me.GSTOCKMTRS})
        Me.GRIDSTOCK.GridControl = Me.GRIDSTOCKDETAILS
        Me.GRIDSTOCK.Name = "GRIDSTOCK"
        Me.GRIDSTOCK.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSTOCK.OptionsCustomization.AllowColumnMoving = False
        Me.GRIDSTOCK.OptionsCustomization.AllowGroup = False
        Me.GRIDSTOCK.OptionsCustomization.AllowQuickHideColumns = False
        Me.GRIDSTOCK.OptionsView.ColumnAutoWidth = False
        Me.GRIDSTOCK.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSTOCK.OptionsView.ShowFooter = True
        Me.GRIDSTOCK.OptionsView.ShowGroupPanel = False
        '
        'GSTOCKITEMNAME
        '
        Me.GSTOCKITEMNAME.Caption = "Item Name"
        Me.GSTOCKITEMNAME.FieldName = "ITEMNAME"
        Me.GSTOCKITEMNAME.Name = "GSTOCKITEMNAME"
        Me.GSTOCKITEMNAME.OptionsColumn.AllowEdit = False
        Me.GSTOCKITEMNAME.OptionsColumn.ReadOnly = True
        Me.GSTOCKITEMNAME.Visible = True
        Me.GSTOCKITEMNAME.VisibleIndex = 0
        Me.GSTOCKITEMNAME.Width = 150
        '
        'GSTOCKSHADE
        '
        Me.GSTOCKSHADE.Caption = "Shade"
        Me.GSTOCKSHADE.FieldName = "COLOR"
        Me.GSTOCKSHADE.Name = "GSTOCKSHADE"
        Me.GSTOCKSHADE.OptionsColumn.AllowEdit = False
        Me.GSTOCKSHADE.OptionsColumn.ReadOnly = True
        Me.GSTOCKSHADE.Visible = True
        Me.GSTOCKSHADE.VisibleIndex = 1
        '
        'GSTOCKPCS
        '
        Me.GSTOCKPCS.Caption = "Qty"
        Me.GSTOCKPCS.DisplayFormat.FormatString = "0"
        Me.GSTOCKPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTOCKPCS.FieldName = "PCS"
        Me.GSTOCKPCS.Name = "GSTOCKPCS"
        Me.GSTOCKPCS.OptionsColumn.AllowEdit = False
        Me.GSTOCKPCS.OptionsColumn.ReadOnly = True
        Me.GSTOCKPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSTOCKPCS.Visible = True
        Me.GSTOCKPCS.VisibleIndex = 3
        Me.GSTOCKPCS.Width = 60
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(133, 12)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 13
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(85, 23)
        Me.lbl.TabIndex = 649
        Me.lbl.Text = "Select SO"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(25, 36)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(820, 630)
        Me.gridbilldetails.TabIndex = 648
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GSRNO, Me.GNAME, Me.GGRIDSRNO, Me.GITEM, Me.GQUALITY, Me.GDESIGNNO, Me.GCOLOR, Me.GQTY, Me.GMTRS, Me.GTYPE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr. No."
        Me.GSRNO.FieldName = "SONO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.OptionsColumn.ReadOnly = True
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.OptionsColumn.ReadOnly = True
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 150
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "Grid SrNo"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        Me.GGRIDSRNO.OptionsColumn.ReadOnly = True
        '
        'GITEM
        '
        Me.GITEM.Caption = "Item Name"
        Me.GITEM.FieldName = "ITEM"
        Me.GITEM.Name = "GITEM"
        Me.GITEM.OptionsColumn.AllowEdit = False
        Me.GITEM.OptionsColumn.ReadOnly = True
        Me.GITEM.Visible = True
        Me.GITEM.VisibleIndex = 3
        Me.GITEM.Width = 200
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.OptionsColumn.ReadOnly = True
        Me.GQUALITY.Width = 150
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No."
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.OptionsColumn.ReadOnly = True
        Me.GDESIGNNO.Width = 85
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.OptionsColumn.AllowEdit = False
        Me.GCOLOR.OptionsColumn.ReadOnly = True
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 4
        Me.GCOLOR.Width = 100
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.DisplayFormat.FormatString = "0"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.OptionsColumn.AllowEdit = False
        Me.GQTY.OptionsColumn.ReadOnly = True
        Me.GQTY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 5
        Me.GQTY.Width = 60
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.OptionsColumn.ReadOnly = True
        Me.GMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 6
        Me.GMTRS.Width = 80
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.OptionsColumn.ReadOnly = True
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 7
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.Name = "APPROXDATE"
        Me.APPROXDATE.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 672)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 672)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GSTOCKMTRS
        '
        Me.GSTOCKMTRS.Caption = "Mtrs"
        Me.GSTOCKMTRS.DisplayFormat.FormatString = "0.00"
        Me.GSTOCKMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTOCKMTRS.FieldName = "MTRS"
        Me.GSTOCKMTRS.Name = "GSTOCKMTRS"
        Me.GSTOCKMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSTOCKMTRS.Visible = True
        Me.GSTOCKMTRS.VisibleIndex = 4
        '
        'GSTOCKUNIT
        '
        Me.GSTOCKUNIT.Caption = "Unit"
        Me.GSTOCKUNIT.FieldName = "UNIT"
        Me.GSTOCKUNIT.Name = "GSTOCKUNIT"
        Me.GSTOCKUNIT.Visible = True
        Me.GSTOCKUNIT.VisibleIndex = 2
        '
        'SelectSOforScheduling
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1304, 712)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SelectSOforScheduling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select SO for Scheduling"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDSTOCKDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSTOCK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKSELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDSTOCKDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSTOCK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GSTOCKITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOCKSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOCKPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GSTOCKUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOCKMTRS As DevExpress.XtraGrid.Columns.GridColumn
End Class
