<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GroupRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupRegister))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTCREDIT = New System.Windows.Forms.TextBox()
        Me.TXTDEBIT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.rbpart = New System.Windows.Forms.RadioButton()
        Me.rbstart = New System.Windows.Forms.RadioButton()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GGROUP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSECONDARY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHEAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEBIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCREDIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDRCR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTCREDIT)
        Me.BlendPanel1.Controls.Add(Me.TXTDEBIT)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.rbpart)
        Me.BlendPanel1.Controls.Add(Me.rbstart)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(801, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTCREDIT
        '
        Me.TXTCREDIT.BackColor = System.Drawing.Color.White
        Me.TXTCREDIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCREDIT.ForeColor = System.Drawing.Color.Black
        Me.TXTCREDIT.Location = New System.Drawing.Point(620, 544)
        Me.TXTCREDIT.Name = "TXTCREDIT"
        Me.TXTCREDIT.ReadOnly = True
        Me.TXTCREDIT.Size = New System.Drawing.Size(112, 22)
        Me.TXTCREDIT.TabIndex = 460
        Me.TXTCREDIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCREDIT.Visible = False
        '
        'TXTDEBIT
        '
        Me.TXTDEBIT.BackColor = System.Drawing.Color.White
        Me.TXTDEBIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDEBIT.ForeColor = System.Drawing.Color.Black
        Me.TXTDEBIT.Location = New System.Drawing.Point(504, 544)
        Me.TXTDEBIT.Name = "TXTDEBIT"
        Me.TXTDEBIT.ReadOnly = True
        Me.TXTDEBIT.Size = New System.Drawing.Size(112, 22)
        Me.TXTDEBIT.TabIndex = 458
        Me.TXTDEBIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTDEBIT.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(468, 548)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 457
        Me.Label2.Text = "Total"
        Me.Label2.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {"", "Name", "Main Group", "Under"})
        Me.cmbname.Location = New System.Drawing.Point(22, 74)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(96, 22)
        Me.cmbname.TabIndex = 1
        '
        'rbpart
        '
        Me.rbpart.AutoSize = True
        Me.rbpart.BackColor = System.Drawing.Color.Transparent
        Me.rbpart.Checked = True
        Me.rbpart.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpart.Location = New System.Drawing.Point(414, 73)
        Me.rbpart.Name = "rbpart"
        Me.rbpart.Size = New System.Drawing.Size(113, 18)
        Me.rbpart.TabIndex = 3
        Me.rbpart.TabStop = True
        Me.rbpart.Text = "Any Part of Field"
        Me.rbpart.UseVisualStyleBackColor = False
        '
        'rbstart
        '
        Me.rbstart.AutoSize = True
        Me.rbstart.BackColor = System.Drawing.Color.Transparent
        Me.rbstart.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbstart.Location = New System.Drawing.Point(414, 47)
        Me.rbstart.Name = "rbstart"
        Me.rbstart.Size = New System.Drawing.Size(80, 18)
        Me.rbstart.TabIndex = 2
        Me.rbstart.Text = "From Start"
        Me.rbstart.UseVisualStyleBackColor = False
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.White
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTNAME.Location = New System.Drawing.Point(118, 74)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.Size = New System.Drawing.Size(275, 22)
        Me.TXTNAME.TabIndex = 0
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(24, 96)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(753, 442)
        Me.griddetails.TabIndex = 4
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGROUP, Me.GSECONDARY, Me.GHEAD, Me.GDEBIT, Me.GCREDIT, Me.GDRCR})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Images = Me.imageList1
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.OptionsView.ShowAutoFilterRow = True
        Me.gridregister.OptionsView.ShowFooter = True
        '
        'GGROUP
        '
        Me.GGROUP.Caption = "Group Name"
        Me.GGROUP.FieldName = "GROUPNAME"
        Me.GGROUP.ImageIndex = 0
        Me.GGROUP.Name = "GGROUP"
        Me.GGROUP.Visible = True
        Me.GGROUP.VisibleIndex = 0
        Me.GGROUP.Width = 180
        '
        'GSECONDARY
        '
        Me.GSECONDARY.Caption = "Main Group"
        Me.GSECONDARY.FieldName = "SECONDARY"
        Me.GSECONDARY.ImageIndex = 2
        Me.GSECONDARY.Name = "GSECONDARY"
        Me.GSECONDARY.Visible = True
        Me.GSECONDARY.VisibleIndex = 1
        Me.GSECONDARY.Width = 200
        '
        'GHEAD
        '
        Me.GHEAD.Caption = "Under"
        Me.GHEAD.FieldName = "UNDER"
        Me.GHEAD.Name = "GHEAD"
        Me.GHEAD.Visible = True
        Me.GHEAD.VisibleIndex = 2
        Me.GHEAD.Width = 100
        '
        'GDEBIT
        '
        Me.GDEBIT.AppearanceCell.Options.UseTextOptions = True
        Me.GDEBIT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GDEBIT.Caption = "Debit"
        Me.GDEBIT.FieldName = "DEBIT"
        Me.GDEBIT.ImageIndex = 1
        Me.GDEBIT.Name = "GDEBIT"
        Me.GDEBIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDEBIT.Visible = True
        Me.GDEBIT.VisibleIndex = 3
        Me.GDEBIT.Width = 100
        '
        'GCREDIT
        '
        Me.GCREDIT.Caption = "Credit"
        Me.GCREDIT.FieldName = "CREDIT"
        Me.GCREDIT.Name = "GCREDIT"
        Me.GCREDIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCREDIT.Visible = True
        Me.GCREDIT.VisibleIndex = 4
        Me.GCREDIT.Width = 100
        '
        'GDRCR
        '
        Me.GDRCR.FieldName = "DRCR"
        Me.GDRCR.Name = "GDRCR"
        Me.GDRCR.Visible = True
        Me.GDRCR.VisibleIndex = 5
        Me.GDRCR.Width = 20
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        Me.imageList1.Images.SetKeyName(2, "Customer.ico")
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(290, 543)
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
        Me.cmdexit.Location = New System.Drawing.Point(378, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(801, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(11, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(161, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Group Summary"
        '
        'GroupRegister
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(801, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GroupRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Group Summary"
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
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents rbpart As System.Windows.Forms.RadioButton
    Friend WithEvents rbstart As System.Windows.Forms.RadioButton
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GGROUP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSECONDARY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHEAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDRCR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTDEBIT As System.Windows.Forms.TextBox
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GCREDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTCREDIT As System.Windows.Forms.TextBox
End Class
