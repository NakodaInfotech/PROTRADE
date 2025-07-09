<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningBalance
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpeningBalance))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.cmdok = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RDBALL = New System.Windows.Forms.RadioButton
        Me.RDBGROUP = New System.Windows.Forms.RadioButton
        Me.cmbgroup = New System.Windows.Forms.ComboBox
        Me.lblgroup = New System.Windows.Forms.Label
        Me.gridname = New DevExpress.XtraGrid.GridControl
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCODE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDEBIT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCREDIT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmbgroup)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(889, 575)
        Me.BlendPanel1.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(889, 25)
        Me.ToolStrip1.TabIndex = 718
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
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
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(361, 536)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(445, 536)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 4
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RDBALL)
        Me.GroupBox1.Controls.Add(Me.RDBGROUP)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 41)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Group"
        '
        'RDBALL
        '
        Me.RDBALL.AutoSize = True
        Me.RDBALL.Checked = True
        Me.RDBALL.Location = New System.Drawing.Point(49, 17)
        Me.RDBALL.Name = "RDBALL"
        Me.RDBALL.Size = New System.Drawing.Size(40, 19)
        Me.RDBALL.TabIndex = 0
        Me.RDBALL.TabStop = True
        Me.RDBALL.Text = "All"
        Me.RDBALL.UseVisualStyleBackColor = True
        '
        'RDBGROUP
        '
        Me.RDBGROUP.AutoSize = True
        Me.RDBGROUP.Location = New System.Drawing.Point(95, 17)
        Me.RDBGROUP.Name = "RDBGROUP"
        Me.RDBGROUP.Size = New System.Drawing.Size(95, 19)
        Me.RDBGROUP.TabIndex = 1
        Me.RDBGROUP.Text = "Under Group"
        Me.RDBGROUP.UseVisualStyleBackColor = True
        '
        'cmbgroup
        '
        Me.cmbgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgroup.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgroup.FormattingEnabled = True
        Me.cmbgroup.Location = New System.Drawing.Point(284, 39)
        Me.cmbgroup.MaxDropDownItems = 14
        Me.cmbgroup.Name = "cmbgroup"
        Me.cmbgroup.Size = New System.Drawing.Size(281, 23)
        Me.cmbgroup.TabIndex = 1
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.Location = New System.Drawing.Point(243, 43)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(41, 15)
        Me.lblgroup.TabIndex = 717
        Me.lblgroup.Text = "Group"
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(21, 70)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemTextEdit1})
        Me.gridname.Size = New System.Drawing.Size(839, 460)
        Me.gridname.TabIndex = 0
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GCODE, Me.GGROUPNAME, Me.GDEBIT, Me.GCREDIT})
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ColumnAutoWidth = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowFooter = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.OptionsColumn.ReadOnly = True
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 250
        '
        'GCODE
        '
        Me.GCODE.Caption = "Code"
        Me.GCODE.FieldName = "CODE"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.OptionsColumn.AllowEdit = False
        Me.GCODE.OptionsColumn.ReadOnly = True
        Me.GCODE.Visible = True
        Me.GCODE.VisibleIndex = 1
        Me.GCODE.Width = 100
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUP"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.OptionsColumn.AllowEdit = False
        Me.GGROUPNAME.OptionsColumn.ReadOnly = True
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 2
        Me.GGROUPNAME.Width = 200
        '
        'GDEBIT
        '
        Me.GDEBIT.Caption = "Debit"
        Me.GDEBIT.DisplayFormat.FormatString = "0.00"
        Me.GDEBIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDEBIT.FieldName = "DEBIT"
        Me.GDEBIT.Name = "GDEBIT"
        Me.GDEBIT.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GDEBIT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GDEBIT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GDEBIT.Visible = True
        Me.GDEBIT.VisibleIndex = 3
        Me.GDEBIT.Width = 120
        '
        'GCREDIT
        '
        Me.GCREDIT.Caption = "Credit"
        Me.GCREDIT.DisplayFormat.FormatString = "0.00"
        Me.GCREDIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCREDIT.FieldName = "CREDIT"
        Me.GCREDIT.Name = "GCREDIT"
        Me.GCREDIT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCREDIT.Visible = True
        Me.GCREDIT.VisibleIndex = 4
        Me.GCREDIT.Width = 120
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(571, 35)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 5
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpeningBalance
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(889, 575)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningBalance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "OpeningBalance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBALL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBGROUP As System.Windows.Forms.RadioButton
    Friend WithEvents cmbgroup As System.Windows.Forms.ComboBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCREDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
End Class
