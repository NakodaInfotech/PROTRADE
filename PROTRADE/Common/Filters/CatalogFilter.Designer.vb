<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CHKSTOCK = New System.Windows.Forms.CheckBox()
        Me.GPDESIGN = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTDESIGN = New System.Windows.Forms.CheckBox()
        Me.GRIDDESIGNDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDESIGN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GDESIGNCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPSHADE = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTSHADE = New System.Windows.Forms.CheckBox()
        Me.GRIDSHADEDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDSHADE = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSHADECHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPITEMNAME = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTITEM = New System.Windows.Forms.CheckBox()
        Me.GRIDITEMDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDITEM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBCATALOG = New System.Windows.Forms.RadioButton()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel2.SuspendLayout()
        Me.GPDESIGN.SuspendLayout()
        CType(Me.GRIDDESIGNDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDESIGN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPSHADE.SuspendLayout()
        CType(Me.GRIDSHADEDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDSHADE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPITEMNAME.SuspendLayout()
        CType(Me.GRIDITEMDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CHKSTOCK)
        Me.BlendPanel2.Controls.Add(Me.GPDESIGN)
        Me.BlendPanel2.Controls.Add(Me.GPSHADE)
        Me.BlendPanel2.Controls.Add(Me.GPITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1066, 581)
        Me.BlendPanel2.TabIndex = 1
        '
        'CHKSTOCK
        '
        Me.CHKSTOCK.AutoSize = True
        Me.CHKSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKSTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSTOCK.ForeColor = System.Drawing.Color.Black
        Me.CHKSTOCK.Location = New System.Drawing.Point(34, 66)
        Me.CHKSTOCK.Name = "CHKSTOCK"
        Me.CHKSTOCK.Size = New System.Drawing.Size(98, 18)
        Me.CHKSTOCK.TabIndex = 763
        Me.CHKSTOCK.Text = "Stock Catalog"
        Me.CHKSTOCK.UseVisualStyleBackColor = False
        '
        'GPDESIGN
        '
        Me.GPDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.GPDESIGN.Controls.Add(Me.CHKSELECTDESIGN)
        Me.GPDESIGN.Controls.Add(Me.GRIDDESIGNDETAILS)
        Me.GPDESIGN.Location = New System.Drawing.Point(508, 12)
        Me.GPDESIGN.Name = "GPDESIGN"
        Me.GPDESIGN.Size = New System.Drawing.Size(264, 523)
        Me.GPDESIGN.TabIndex = 760
        Me.GPDESIGN.TabStop = False
        Me.GPDESIGN.Text = "Design"
        '
        'CHKSELECTDESIGN
        '
        Me.CHKSELECTDESIGN.AutoSize = True
        Me.CHKSELECTDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTDESIGN.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTDESIGN.Location = New System.Drawing.Point(33, 23)
        Me.CHKSELECTDESIGN.Name = "CHKSELECTDESIGN"
        Me.CHKSELECTDESIGN.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTDESIGN.TabIndex = 0
        Me.CHKSELECTDESIGN.Text = "Select All"
        Me.CHKSELECTDESIGN.UseVisualStyleBackColor = False
        '
        'GRIDDESIGNDETAILS
        '
        Me.GRIDDESIGNDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDESIGNDETAILS.Location = New System.Drawing.Point(6, 22)
        Me.GRIDDESIGNDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDDESIGNDETAILS.MainView = Me.GRIDDESIGN
        Me.GRIDDESIGNDETAILS.Name = "GRIDDESIGNDETAILS"
        Me.GRIDDESIGNDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit5})
        Me.GRIDDESIGNDETAILS.Size = New System.Drawing.Size(246, 497)
        Me.GRIDDESIGNDETAILS.TabIndex = 1
        Me.GRIDDESIGNDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDDESIGN})
        '
        'GRIDDESIGN
        '
        Me.GRIDDESIGN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDESIGN.Appearance.Row.Options.UseFont = True
        Me.GRIDDESIGN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDESIGNCHK, Me.GDESIGNNO})
        Me.GRIDDESIGN.GridControl = Me.GRIDDESIGNDETAILS
        Me.GRIDDESIGN.Name = "GRIDDESIGN"
        Me.GRIDDESIGN.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDDESIGN.OptionsView.ColumnAutoWidth = False
        Me.GRIDDESIGN.OptionsView.ShowAutoFilterRow = True
        Me.GRIDDESIGN.OptionsView.ShowGroupPanel = False
        '
        'GDESIGNCHK
        '
        Me.GDESIGNCHK.ColumnEdit = Me.RepositoryItemCheckEdit5
        Me.GDESIGNCHK.FieldName = "CHK"
        Me.GDESIGNCHK.Name = "GDESIGNCHK"
        Me.GDESIGNCHK.OptionsColumn.ShowCaption = False
        Me.GDESIGNCHK.Visible = True
        Me.GDESIGNCHK.VisibleIndex = 0
        Me.GDESIGNCHK.Width = 35
        '
        'RepositoryItemCheckEdit5
        '
        Me.RepositoryItemCheckEdit5.AutoHeight = False
        Me.RepositoryItemCheckEdit5.Name = "RepositoryItemCheckEdit5"
        Me.RepositoryItemCheckEdit5.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.ImageIndex = 0
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 1
        Me.GDESIGNNO.Width = 165
        '
        'GPSHADE
        '
        Me.GPSHADE.BackColor = System.Drawing.Color.Transparent
        Me.GPSHADE.Controls.Add(Me.CHKSELECTSHADE)
        Me.GPSHADE.Controls.Add(Me.GRIDSHADEDETAILS)
        Me.GPSHADE.Location = New System.Drawing.Point(778, 12)
        Me.GPSHADE.Name = "GPSHADE"
        Me.GPSHADE.Size = New System.Drawing.Size(264, 523)
        Me.GPSHADE.TabIndex = 759
        Me.GPSHADE.TabStop = False
        Me.GPSHADE.Text = "Shade"
        '
        'CHKSELECTSHADE
        '
        Me.CHKSELECTSHADE.AutoSize = True
        Me.CHKSELECTSHADE.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTSHADE.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTSHADE.Location = New System.Drawing.Point(33, 23)
        Me.CHKSELECTSHADE.Name = "CHKSELECTSHADE"
        Me.CHKSELECTSHADE.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTSHADE.TabIndex = 0
        Me.CHKSELECTSHADE.Text = "Select All"
        Me.CHKSELECTSHADE.UseVisualStyleBackColor = False
        '
        'GRIDSHADEDETAILS
        '
        Me.GRIDSHADEDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSHADEDETAILS.Location = New System.Drawing.Point(6, 22)
        Me.GRIDSHADEDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDSHADEDETAILS.MainView = Me.GRIDSHADE
        Me.GRIDSHADEDETAILS.Name = "GRIDSHADEDETAILS"
        Me.GRIDSHADEDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit6})
        Me.GRIDSHADEDETAILS.Size = New System.Drawing.Size(246, 497)
        Me.GRIDSHADEDETAILS.TabIndex = 1
        Me.GRIDSHADEDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDSHADE})
        '
        'GRIDSHADE
        '
        Me.GRIDSHADE.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDSHADE.Appearance.Row.Options.UseFont = True
        Me.GRIDSHADE.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSHADECHK, Me.GSHADE})
        Me.GRIDSHADE.GridControl = Me.GRIDSHADEDETAILS
        Me.GRIDSHADE.Name = "GRIDSHADE"
        Me.GRIDSHADE.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDSHADE.OptionsView.ColumnAutoWidth = False
        Me.GRIDSHADE.OptionsView.ShowAutoFilterRow = True
        Me.GRIDSHADE.OptionsView.ShowGroupPanel = False
        '
        'GSHADECHK
        '
        Me.GSHADECHK.ColumnEdit = Me.RepositoryItemCheckEdit6
        Me.GSHADECHK.FieldName = "CHK"
        Me.GSHADECHK.Name = "GSHADECHK"
        Me.GSHADECHK.OptionsColumn.ShowCaption = False
        Me.GSHADECHK.Visible = True
        Me.GSHADECHK.VisibleIndex = 0
        Me.GSHADECHK.Width = 35
        '
        'RepositoryItemCheckEdit6
        '
        Me.RepositoryItemCheckEdit6.AutoHeight = False
        Me.RepositoryItemCheckEdit6.Name = "RepositoryItemCheckEdit6"
        Me.RepositoryItemCheckEdit6.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.ImageIndex = 0
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.OptionsColumn.AllowEdit = False
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 1
        Me.GSHADE.Width = 165
        '
        'GPITEMNAME
        '
        Me.GPITEMNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPITEMNAME.Controls.Add(Me.CHKSELECTITEM)
        Me.GPITEMNAME.Controls.Add(Me.GRIDITEMDETAILS)
        Me.GPITEMNAME.Location = New System.Drawing.Point(238, 12)
        Me.GPITEMNAME.Name = "GPITEMNAME"
        Me.GPITEMNAME.Size = New System.Drawing.Size(264, 523)
        Me.GPITEMNAME.TabIndex = 758
        Me.GPITEMNAME.TabStop = False
        Me.GPITEMNAME.Text = "Item Name"
        '
        'CHKSELECTITEM
        '
        Me.CHKSELECTITEM.AutoSize = True
        Me.CHKSELECTITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTITEM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTITEM.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTITEM.Location = New System.Drawing.Point(34, 22)
        Me.CHKSELECTITEM.Name = "CHKSELECTITEM"
        Me.CHKSELECTITEM.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTITEM.TabIndex = 0
        Me.CHKSELECTITEM.Text = "Select All"
        Me.CHKSELECTITEM.UseVisualStyleBackColor = False
        '
        'GRIDITEMDETAILS
        '
        Me.GRIDITEMDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDITEMDETAILS.Location = New System.Drawing.Point(6, 20)
        Me.GRIDITEMDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDITEMDETAILS.MainView = Me.GRIDITEM
        Me.GRIDITEMDETAILS.Name = "GRIDITEMDETAILS"
        Me.GRIDITEMDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit4})
        Me.GRIDITEMDETAILS.Size = New System.Drawing.Size(246, 497)
        Me.GRIDITEMDETAILS.TabIndex = 1
        Me.GRIDITEMDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDITEM})
        '
        'GRIDITEM
        '
        Me.GRIDITEM.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDITEM.Appearance.Row.Options.UseFont = True
        Me.GRIDITEM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMCHK, Me.GITEMNAME})
        Me.GRIDITEM.GridControl = Me.GRIDITEMDETAILS
        Me.GRIDITEM.Name = "GRIDITEM"
        Me.GRIDITEM.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDITEM.OptionsView.ColumnAutoWidth = False
        Me.GRIDITEM.OptionsView.ShowAutoFilterRow = True
        Me.GRIDITEM.OptionsView.ShowGroupPanel = False
        '
        'GITEMCHK
        '
        Me.GITEMCHK.ColumnEdit = Me.RepositoryItemCheckEdit4
        Me.GITEMCHK.FieldName = "CHK"
        Me.GITEMCHK.Name = "GITEMCHK"
        Me.GITEMCHK.OptionsColumn.ShowCaption = False
        Me.GITEMCHK.Visible = True
        Me.GITEMCHK.VisibleIndex = 0
        Me.GITEMCHK.Width = 35
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        Me.RepositoryItemCheckEdit4.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.ImageIndex = 0
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 165
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBCATALOG)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(209, 109)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'RBCATALOG
        '
        Me.RBCATALOG.AutoSize = True
        Me.RBCATALOG.Checked = True
        Me.RBCATALOG.Location = New System.Drawing.Point(21, 12)
        Me.RBCATALOG.Name = "RBCATALOG"
        Me.RBCATALOG.Size = New System.Drawing.Size(94, 18)
        Me.RBCATALOG.TabIndex = 0
        Me.RBCATALOG.TabStop = True
        Me.RBCATALOG.Text = "Item Catalog"
        Me.RBCATALOG.UseVisualStyleBackColor = True
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(442, 541)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 9
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(536, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CatalogFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1066, 581)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CatalogFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Catalog Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GPDESIGN.ResumeLayout(False)
        Me.GPDESIGN.PerformLayout()
        CType(Me.GRIDDESIGNDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDESIGN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPSHADE.ResumeLayout(False)
        Me.GPSHADE.PerformLayout()
        CType(Me.GRIDSHADEDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDSHADE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPITEMNAME.ResumeLayout(False)
        Me.GPITEMNAME.PerformLayout()
        CType(Me.GRIDITEMDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CHKSTOCK As CheckBox
    Friend WithEvents GPDESIGN As GroupBox
    Friend WithEvents CHKSELECTDESIGN As CheckBox
    Private WithEvents GRIDDESIGNDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDDESIGN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDESIGNCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPSHADE As GroupBox
    Friend WithEvents CHKSELECTSHADE As CheckBox
    Private WithEvents GRIDSHADEDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDSHADE As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSHADECHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPITEMNAME As GroupBox
    Friend WithEvents CHKSELECTITEM As CheckBox
    Private WithEvents GRIDITEMDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDITEM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBCATALOG As RadioButton
    Friend WithEvents cmdshow As Button
    Friend WithEvents cmdexit As Button
End Class
