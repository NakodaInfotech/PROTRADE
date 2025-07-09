<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GroupDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl
        Me.GRIDGROUP = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGROUP = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNDER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdedit = New System.Windows.Forms.Button
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDGROUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(244, 535)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 319
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Black
        Me.cmdadd.Location = New System.Drawing.Point(158, 535)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(80, 28)
        Me.cmdadd.TabIndex = 320
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(24, 41)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 14)
        Me.Label7.TabIndex = 323
        Me.Label7.Text = "Double Click to Edit"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(483, 581)
        Me.BlendPanel1.TabIndex = 5
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(15, 65)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDGROUP
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(452, 464)
        Me.GRIDBILLDETAILS.TabIndex = 329
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDGROUP})
        '
        'GRIDGROUP
        '
        Me.GRIDGROUP.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDGROUP.Appearance.Row.Options.UseFont = True
        Me.GRIDGROUP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GID, Me.GGROUP, Me.GUNDER})
        Me.GRIDGROUP.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDGROUP.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDGROUP.Name = "GRIDGROUP"
        Me.GRIDGROUP.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDGROUP.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDGROUP.OptionsBehavior.Editable = False
        Me.GRIDGROUP.OptionsView.ColumnAutoWidth = False
        Me.GRIDGROUP.OptionsView.ShowAutoFilterRow = True
        Me.GRIDGROUP.OptionsView.ShowGroupPanel = False
        '
        'GID
        '
        Me.GID.Caption = "ID"
        Me.GID.FieldName = "ID"
        Me.GID.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.GID.Name = "GID"
        '
        'GGROUP
        '
        Me.GGROUP.Caption = "Group"
        Me.GGROUP.FieldName = "GROUPNAME"
        Me.GGROUP.ImageIndex = 0
        Me.GGROUP.Name = "GGROUP"
        Me.GGROUP.Visible = True
        Me.GGROUP.VisibleIndex = 0
        Me.GGROUP.Width = 200
        '
        'GUNDER
        '
        Me.GUNDER.Caption = "Under"
        Me.GUNDER.FieldName = "UNDERGROUP"
        Me.GUNDER.Name = "GUNDER"
        Me.GUNDER.Visible = True
        Me.GUNDER.VisibleIndex = 1
        Me.GUNDER.Width = 200
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(483, 25)
        Me.ToolStrip1.TabIndex = 328
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(333, 31)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(80, 28)
        Me.cmdedit.TabIndex = 322
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'GroupDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(483, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GroupDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Group Details"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDGROUP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDGROUP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GGROUP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdedit As System.Windows.Forms.Button
End Class
