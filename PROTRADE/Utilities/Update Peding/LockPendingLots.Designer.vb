<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LockPendingLots
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LockPendingLots))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.RBENTERED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GGRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDYEINGNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        resources.ApplyResources(Me.BlendPanel1, "BlendPanel1")
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.RBENTERED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Name = "BlendPanel1"
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.CMDREFRESH, "CMDREFRESH")
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'RBENTERED
        '
        resources.ApplyResources(Me.RBENTERED, "RBENTERED")
        Me.RBENTERED.BackColor = System.Drawing.Color.Transparent
        Me.RBENTERED.Name = "RBENTERED"
        Me.RBENTERED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        resources.ApplyResources(Me.RBPENDING, "RBPENDING")
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'CMDSAVE
        '
        Me.CMDSAVE.BackColor = System.Drawing.Color.Transparent
        Me.CMDSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSAVE.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.CMDSAVE, "CMDSAVE")
        Me.CMDSAVE.ForeColor = System.Drawing.Color.Black
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.cmdexit, "cmdexit")
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        resources.ApplyResources(Me.gridbilldetails, "gridbilldetails")
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = CType(resources.GetObject("gridbill.Appearance.HeaderPanel.Font"), System.Drawing.Font)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = CType(resources.GetObject("gridbill.Appearance.Row.Font"), System.Drawing.Font)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGRNNO, Me.GLOTNO, Me.GDATE, Me.GNAME, Me.GDYEINGNAME, Me.GPCS, Me.GMTRS, Me.GBALPCS, Me.GBALMTRS, Me.GTYPE})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GGRNNO
        '
        resources.ApplyResources(Me.GGRNNO, "GGRNNO")
        Me.GGRNNO.FieldName = "GRNNO"
        Me.GGRNNO.Name = "GGRNNO"
        '
        'GLOTNO
        '
        resources.ApplyResources(Me.GLOTNO, "GLOTNO")
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        '
        'GDATE
        '
        resources.ApplyResources(Me.GDATE, "GDATE")
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        '
        'GNAME
        '
        resources.ApplyResources(Me.GNAME, "GNAME")
        Me.GNAME.FieldName = "PARTYNAME"
        Me.GNAME.Name = "GNAME"
        '
        'GDYEINGNAME
        '
        resources.ApplyResources(Me.GDYEINGNAME, "GDYEINGNAME")
        Me.GDYEINGNAME.FieldName = "JOBBERNAME"
        Me.GDYEINGNAME.Name = "GDYEINGNAME"
        '
        'GPCS
        '
        resources.ApplyResources(Me.GPCS, "GPCS")
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "ACCEPTEDPCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("GPCS.Summary"), DevExpress.Data.SummaryItemType))})
        '
        'GMTRS
        '
        resources.ApplyResources(Me.GMTRS, "GMTRS")
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "ACCEPTEDMTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("GMTRS.Summary"), DevExpress.Data.SummaryItemType))})
        '
        'GBALPCS
        '
        resources.ApplyResources(Me.GBALPCS, "GBALPCS")
        Me.GBALPCS.DisplayFormat.FormatString = "0"
        Me.GBALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALPCS.FieldName = "BALPCS"
        Me.GBALPCS.Name = "GBALPCS"
        Me.GBALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("GBALPCS.Summary"), DevExpress.Data.SummaryItemType))})
        '
        'GBALMTRS
        '
        resources.ApplyResources(Me.GBALMTRS, "GBALMTRS")
        Me.GBALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GBALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALMTRS.FieldName = "BALMTRS"
        Me.GBALMTRS.Name = "GBALMTRS"
        Me.GBALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("GBALMTRS.Summary"), DevExpress.Data.SummaryItemType))})
        '
        'GTYPE
        '
        resources.ApplyResources(Me.GTYPE, "GTYPE")
        Me.GTYPE.FieldName = "GRNTYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        resources.ApplyResources(Me.PrintToolStripButton, "PrintToolStripButton")
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        '
        'LockPendingLots
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "LockPendingLots"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents RBENTERED As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents cmdexit As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GGRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDYEINGNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents GBALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
