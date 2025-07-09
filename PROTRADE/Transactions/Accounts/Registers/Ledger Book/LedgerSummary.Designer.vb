<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerSummary))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTCLOSING = New System.Windows.Forms.TextBox()
        Me.TXTCREDIT = New System.Windows.Forms.TextBox()
        Me.TXTDEBIT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbbillwise = New System.Windows.Forms.RadioButton()
        Me.rbdaily = New System.Windows.Forms.RadioButton()
        Me.rbmonthly = New System.Windows.Forms.RadioButton()
        Me.rbdetailed = New System.Windows.Forms.RadioButton()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.rbpart = New System.Windows.Forms.RadioButton()
        Me.rbstart = New System.Windows.Forms.RadioButton()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GMOBILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTCLOSING)
        Me.BlendPanel1.Controls.Add(Me.TXTCREDIT)
        Me.BlendPanel1.Controls.Add(Me.TXTDEBIT)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
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
        Me.BlendPanel1.Size = New System.Drawing.Size(999, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Location = New System.Drawing.Point(533, 56)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 466
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(651, 555)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 465
        Me.Label1.Text = "CLosing"
        '
        'TXTCLOSING
        '
        Me.TXTCLOSING.BackColor = System.Drawing.Color.White
        Me.TXTCLOSING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLOSING.ForeColor = System.Drawing.Color.Black
        Me.TXTCLOSING.Location = New System.Drawing.Point(703, 551)
        Me.TXTCLOSING.Name = "TXTCLOSING"
        Me.TXTCLOSING.ReadOnly = True
        Me.TXTCLOSING.Size = New System.Drawing.Size(118, 22)
        Me.TXTCLOSING.TabIndex = 464
        Me.TXTCLOSING.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCREDIT
        '
        Me.TXTCREDIT.BackColor = System.Drawing.Color.White
        Me.TXTCREDIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCREDIT.ForeColor = System.Drawing.Color.Black
        Me.TXTCREDIT.Location = New System.Drawing.Point(822, 525)
        Me.TXTCREDIT.Name = "TXTCREDIT"
        Me.TXTCREDIT.ReadOnly = True
        Me.TXTCREDIT.Size = New System.Drawing.Size(118, 22)
        Me.TXTCREDIT.TabIndex = 463
        Me.TXTCREDIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDEBIT
        '
        Me.TXTDEBIT.BackColor = System.Drawing.Color.White
        Me.TXTDEBIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDEBIT.ForeColor = System.Drawing.Color.Black
        Me.TXTDEBIT.Location = New System.Drawing.Point(703, 525)
        Me.TXTDEBIT.Name = "TXTDEBIT"
        Me.TXTDEBIT.ReadOnly = True
        Me.TXTDEBIT.Size = New System.Drawing.Size(118, 22)
        Me.TXTDEBIT.TabIndex = 461
        Me.TXTDEBIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(666, 528)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 460
        Me.Label2.Text = "Total"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbbillwise)
        Me.GroupBox1.Controls.Add(Me.rbdaily)
        Me.GroupBox1.Controls.Add(Me.rbmonthly)
        Me.GroupBox1.Controls.Add(Me.rbdetailed)
        Me.GroupBox1.Location = New System.Drawing.Point(632, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 59)
        Me.GroupBox1.TabIndex = 452
        Me.GroupBox1.TabStop = False
        '
        'rbbillwise
        '
        Me.rbbillwise.AutoSize = True
        Me.rbbillwise.BackColor = System.Drawing.Color.Transparent
        Me.rbbillwise.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbbillwise.Location = New System.Drawing.Point(102, 38)
        Me.rbbillwise.Name = "rbbillwise"
        Me.rbbillwise.Size = New System.Drawing.Size(69, 18)
        Me.rbbillwise.TabIndex = 453
        Me.rbbillwise.Text = "Bill Wise"
        Me.rbbillwise.UseVisualStyleBackColor = False
        '
        'rbdaily
        '
        Me.rbdaily.AutoSize = True
        Me.rbdaily.BackColor = System.Drawing.Color.Transparent
        Me.rbdaily.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdaily.Location = New System.Drawing.Point(102, 14)
        Me.rbdaily.Name = "rbdaily"
        Me.rbdaily.Size = New System.Drawing.Size(49, 18)
        Me.rbdaily.TabIndex = 452
        Me.rbdaily.Text = "Daily"
        Me.rbdaily.UseVisualStyleBackColor = False
        '
        'rbmonthly
        '
        Me.rbmonthly.AutoSize = True
        Me.rbmonthly.BackColor = System.Drawing.Color.Transparent
        Me.rbmonthly.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbmonthly.Location = New System.Drawing.Point(13, 38)
        Me.rbmonthly.Name = "rbmonthly"
        Me.rbmonthly.Size = New System.Drawing.Size(65, 18)
        Me.rbmonthly.TabIndex = 451
        Me.rbmonthly.Text = "Monthly"
        Me.rbmonthly.UseVisualStyleBackColor = False
        '
        'rbdetailed
        '
        Me.rbdetailed.AutoSize = True
        Me.rbdetailed.BackColor = System.Drawing.Color.Transparent
        Me.rbdetailed.Checked = True
        Me.rbdetailed.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbdetailed.Location = New System.Drawing.Point(13, 14)
        Me.rbdetailed.Name = "rbdetailed"
        Me.rbdetailed.Size = New System.Drawing.Size(66, 18)
        Me.rbdetailed.TabIndex = 450
        Me.rbdetailed.TabStop = True
        Me.rbdetailed.Text = "Detailed"
        Me.rbdetailed.UseVisualStyleBackColor = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {"", "Name", "Group", "City"})
        Me.cmbname.Location = New System.Drawing.Point(22, 65)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(96, 22)
        Me.cmbname.TabIndex = 1
        Me.cmbname.Visible = False
        '
        'rbpart
        '
        Me.rbpart.AutoSize = True
        Me.rbpart.BackColor = System.Drawing.Color.Transparent
        Me.rbpart.Checked = True
        Me.rbpart.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpart.Location = New System.Drawing.Point(414, 64)
        Me.rbpart.Name = "rbpart"
        Me.rbpart.Size = New System.Drawing.Size(106, 18)
        Me.rbpart.TabIndex = 3
        Me.rbpart.TabStop = True
        Me.rbpart.Text = "Any Part of Field"
        Me.rbpart.UseVisualStyleBackColor = False
        Me.rbpart.Visible = False
        '
        'rbstart
        '
        Me.rbstart.AutoSize = True
        Me.rbstart.BackColor = System.Drawing.Color.Transparent
        Me.rbstart.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbstart.Location = New System.Drawing.Point(414, 38)
        Me.rbstart.Name = "rbstart"
        Me.rbstart.Size = New System.Drawing.Size(78, 18)
        Me.rbstart.TabIndex = 2
        Me.rbstart.Text = "From Start"
        Me.rbstart.UseVisualStyleBackColor = False
        Me.rbstart.Visible = False
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.White
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTNAME.Location = New System.Drawing.Point(118, 65)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.Size = New System.Drawing.Size(275, 22)
        Me.TXTNAME.TabIndex = 0
        Me.TXTNAME.Visible = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(23, 87)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(957, 433)
        Me.griddetails.TabIndex = 4
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GMOBILENO, Me.GGROUP, Me.GCITY, Me.GDEBIT, Me.GCREDIT, Me.GDRCR})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Images = Me.imageList1
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.OptionsView.ShowAutoFilterRow = True
        Me.gridregister.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 280
        '
        'GGROUP
        '
        Me.GGROUP.Caption = "Group"
        Me.GGROUP.FieldName = "GROUPNAME"
        Me.GGROUP.ImageIndex = 2
        Me.GGROUP.Name = "GGROUP"
        Me.GGROUP.Visible = True
        Me.GGROUP.VisibleIndex = 2
        Me.GGROUP.Width = 170
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 3
        Me.GCITY.Width = 110
        '
        'GDEBIT
        '
        Me.GDEBIT.AppearanceCell.Options.UseTextOptions = True
        Me.GDEBIT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GDEBIT.Caption = "Debit"
        Me.GDEBIT.FieldName = "DEBIT"
        Me.GDEBIT.ImageIndex = 1
        Me.GDEBIT.Name = "GDEBIT"
        Me.GDEBIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BALANCE", "")})
        Me.GDEBIT.Visible = True
        Me.GDEBIT.VisibleIndex = 4
        Me.GDEBIT.Width = 110
        '
        'GCREDIT
        '
        Me.GCREDIT.Caption = "Credit"
        Me.GCREDIT.FieldName = "CREDIT"
        Me.GCREDIT.Name = "GCREDIT"
        Me.GCREDIT.Visible = True
        Me.GCREDIT.VisibleIndex = 5
        Me.GCREDIT.Width = 110
        '
        'GDRCR
        '
        Me.GDRCR.FieldName = "DRCR"
        Me.GDRCR.Name = "GDRCR"
        Me.GDRCR.OptionsFilter.AllowAutoFilter = False
        Me.GDRCR.Visible = True
        Me.GDRCR.VisibleIndex = 6
        Me.GDRCR.Width = 30
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
        Me.cmdok.Location = New System.Drawing.Point(416, 533)
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
        Me.cmdexit.Location = New System.Drawing.Point(502, 533)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(999, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(11, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(169, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Ledger Summary"
        '
        'GMOBILENO
        '
        Me.GMOBILENO.Caption = "Mobile No"
        Me.GMOBILENO.FieldName = "MOBILENO"
        Me.GMOBILENO.Name = "GMOBILENO"
        Me.GMOBILENO.Visible = True
        Me.GMOBILENO.VisibleIndex = 1
        Me.GMOBILENO.Width = 100
        '
        'LedgerSummary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(999, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LedgerSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ledger Summary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents rbpart As System.Windows.Forms.RadioButton
    Friend WithEvents rbstart As System.Windows.Forms.RadioButton
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbdetailed As System.Windows.Forms.RadioButton
    Friend WithEvents rbmonthly As System.Windows.Forms.RadioButton
    Friend WithEvents rbbillwise As System.Windows.Forms.RadioButton
    Friend WithEvents rbdaily As System.Windows.Forms.RadioButton
    Friend WithEvents GDRCR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTDEBIT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GCREDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTCREDIT As System.Windows.Forms.TextBox
    Friend WithEvents TXTCLOSING As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents GMOBILENO As DevExpress.XtraGrid.Columns.GridColumn
End Class
