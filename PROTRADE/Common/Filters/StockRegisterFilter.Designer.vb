<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockRegisterFilter
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
        Me.GPUNIT = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTUNIT = New System.Windows.Forms.CheckBox()
        Me.gridbilldetailsunit = New DevExpress.XtraGrid.GridControl()
        Me.gridbillunit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHKCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBFINISHSTOCKMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RBDYEINGSTOCKMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RBGREYSTOCKMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RBCHALLANSTOCK = New System.Windows.Forms.RadioButton()
        Me.RBGODOWNSTOCK = New System.Windows.Forms.RadioButton()
        Me.RBPACKINGSTOCK = New System.Windows.Forms.RadioButton()
        Me.RBDYEINGSTOCK = New System.Windows.Forms.RadioButton()
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
        Me.GPUNIT.SuspendLayout()
        CType(Me.gridbilldetailsunit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbillunit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.GPDESIGN)
        Me.BlendPanel2.Controls.Add(Me.GPSHADE)
        Me.BlendPanel2.Controls.Add(Me.GPITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.GPUNIT)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBPIECETYPE)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1237, 494)
        Me.BlendPanel2.TabIndex = 0
        '
        'GPDESIGN
        '
        Me.GPDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.GPDESIGN.Controls.Add(Me.CHKSELECTDESIGN)
        Me.GPDESIGN.Controls.Add(Me.GRIDDESIGNDETAILS)
        Me.GPDESIGN.Location = New System.Drawing.Point(973, 16)
        Me.GPDESIGN.Name = "GPDESIGN"
        Me.GPDESIGN.Size = New System.Drawing.Size(264, 450)
        Me.GPDESIGN.TabIndex = 12
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
        Me.CHKSELECTDESIGN.Size = New System.Drawing.Size(72, 18)
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
        Me.GRIDDESIGNDETAILS.Size = New System.Drawing.Size(246, 419)
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
        Me.GPSHADE.Location = New System.Drawing.Point(413, 237)
        Me.GPSHADE.Name = "GPSHADE"
        Me.GPSHADE.Size = New System.Drawing.Size(264, 229)
        Me.GPSHADE.TabIndex = 10
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
        Me.CHKSELECTSHADE.Size = New System.Drawing.Size(72, 18)
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
        Me.GRIDSHADEDETAILS.Size = New System.Drawing.Size(246, 200)
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
        Me.GPITEMNAME.Location = New System.Drawing.Point(700, 12)
        Me.GPITEMNAME.Name = "GPITEMNAME"
        Me.GPITEMNAME.Size = New System.Drawing.Size(264, 454)
        Me.GPITEMNAME.TabIndex = 11
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
        Me.CHKSELECTITEM.Size = New System.Drawing.Size(72, 18)
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
        Me.GRIDITEMDETAILS.Size = New System.Drawing.Size(246, 425)
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
        'GPUNIT
        '
        Me.GPUNIT.BackColor = System.Drawing.Color.Transparent
        Me.GPUNIT.Controls.Add(Me.CHKSELECTUNIT)
        Me.GPUNIT.Controls.Add(Me.gridbilldetailsunit)
        Me.GPUNIT.Location = New System.Drawing.Point(184, 237)
        Me.GPUNIT.Name = "GPUNIT"
        Me.GPUNIT.Size = New System.Drawing.Size(223, 229)
        Me.GPUNIT.TabIndex = 9
        Me.GPUNIT.TabStop = False
        Me.GPUNIT.Text = "Unit"
        '
        'CHKSELECTUNIT
        '
        Me.CHKSELECTUNIT.AutoSize = True
        Me.CHKSELECTUNIT.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTUNIT.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTUNIT.Location = New System.Drawing.Point(25, 22)
        Me.CHKSELECTUNIT.Name = "CHKSELECTUNIT"
        Me.CHKSELECTUNIT.Size = New System.Drawing.Size(72, 18)
        Me.CHKSELECTUNIT.TabIndex = 0
        Me.CHKSELECTUNIT.Text = "Select All"
        Me.CHKSELECTUNIT.UseVisualStyleBackColor = False
        '
        'gridbilldetailsunit
        '
        Me.gridbilldetailsunit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetailsunit.Location = New System.Drawing.Point(12, 20)
        Me.gridbilldetailsunit.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetailsunit.MainView = Me.gridbillunit
        Me.gridbilldetailsunit.Name = "gridbilldetailsunit"
        Me.gridbilldetailsunit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3})
        Me.gridbilldetailsunit.Size = New System.Drawing.Size(197, 200)
        Me.gridbilldetailsunit.TabIndex = 1
        Me.gridbilldetailsunit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbillunit})
        '
        'gridbillunit
        '
        Me.gridbillunit.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbillunit.Appearance.Row.Options.UseFont = True
        Me.gridbillunit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHKCOLOR, Me.GUNIT})
        Me.gridbillunit.GridControl = Me.gridbilldetailsunit
        Me.gridbillunit.Name = "gridbillunit"
        Me.gridbillunit.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbillunit.OptionsView.ColumnAutoWidth = False
        Me.gridbillunit.OptionsView.ShowAutoFilterRow = True
        Me.gridbillunit.OptionsView.ShowGroupPanel = False
        '
        'GCHKCOLOR
        '
        Me.GCHKCOLOR.ColumnEdit = Me.RepositoryItemCheckEdit3
        Me.GCHKCOLOR.FieldName = "CHK"
        Me.GCHKCOLOR.Name = "GCHKCOLOR"
        Me.GCHKCOLOR.OptionsColumn.ShowCaption = False
        Me.GCHKCOLOR.Visible = True
        Me.GCHKCOLOR.VisibleIndex = 0
        Me.GCHKCOLOR.Width = 35
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.ImageIndex = 0
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 1
        Me.GUNIT.Width = 120
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(35, 237)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 6
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(30, 237)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(148, 86)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(50, 48)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From :"
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(238, 25)
        Me.CMBPIECETYPE.MaxDropDownItems = 14
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(85, 22)
        Me.CMBPIECETYPE.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(179, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 14)
        Me.Label8.TabIndex = 752
        Me.Label8.Text = "Piece Type"
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(399, 53)
        Me.CMBSHADE.MaxDropDownItems = 14
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(230, 22)
        Me.CMBSHADE.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(361, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 750
        Me.Label6.Text = "Shade"
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(399, 25)
        Me.CMBDESIGN.MaxDropDownItems = 14
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(230, 22)
        Me.CMBDESIGN.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(358, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 748
        Me.Label4.Text = "Design"
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(93, 25)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(85, 22)
        Me.CMBGODOWN.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(43, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 744
        Me.Label2.Text = "Godown"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(93, 53)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBITEMNAME.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 742
        Me.Label5.Text = "Item Name"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBFINISHSTOCKMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RBDYEINGSTOCKMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RBGREYSTOCKMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RBCHALLANSTOCK)
        Me.GroupBox3.Controls.Add(Me.RBGODOWNSTOCK)
        Me.GroupBox3.Controls.Add(Me.RBPACKINGSTOCK)
        Me.GroupBox3.Controls.Add(Me.RBDYEINGSTOCK)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(35, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(594, 148)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'RBFINISHSTOCKMONTHLY
        '
        Me.RBFINISHSTOCKMONTHLY.AutoSize = True
        Me.RBFINISHSTOCKMONTHLY.Location = New System.Drawing.Point(21, 113)
        Me.RBFINISHSTOCKMONTHLY.Name = "RBFINISHSTOCKMONTHLY"
        Me.RBFINISHSTOCKMONTHLY.Size = New System.Drawing.Size(126, 18)
        Me.RBFINISHSTOCKMONTHLY.TabIndex = 6
        Me.RBFINISHSTOCKMONTHLY.Text = "Finish Stock Monthly"
        Me.RBFINISHSTOCKMONTHLY.UseVisualStyleBackColor = True
        Me.RBFINISHSTOCKMONTHLY.Visible = False
        '
        'RBDYEINGSTOCKMONTHLY
        '
        Me.RBDYEINGSTOCKMONTHLY.AutoSize = True
        Me.RBDYEINGSTOCKMONTHLY.Location = New System.Drawing.Point(20, 89)
        Me.RBDYEINGSTOCKMONTHLY.Name = "RBDYEINGSTOCKMONTHLY"
        Me.RBDYEINGSTOCKMONTHLY.Size = New System.Drawing.Size(130, 18)
        Me.RBDYEINGSTOCKMONTHLY.TabIndex = 5
        Me.RBDYEINGSTOCKMONTHLY.Text = "Dyeing Stock Monthly"
        Me.RBDYEINGSTOCKMONTHLY.UseVisualStyleBackColor = True
        Me.RBDYEINGSTOCKMONTHLY.Visible = False
        '
        'RBGREYSTOCKMONTHLY
        '
        Me.RBGREYSTOCKMONTHLY.AutoSize = True
        Me.RBGREYSTOCKMONTHLY.Location = New System.Drawing.Point(21, 65)
        Me.RBGREYSTOCKMONTHLY.Name = "RBGREYSTOCKMONTHLY"
        Me.RBGREYSTOCKMONTHLY.Size = New System.Drawing.Size(120, 18)
        Me.RBGREYSTOCKMONTHLY.TabIndex = 4
        Me.RBGREYSTOCKMONTHLY.Text = "Grey Stock Monthly"
        Me.RBGREYSTOCKMONTHLY.UseVisualStyleBackColor = True
        Me.RBGREYSTOCKMONTHLY.Visible = False
        '
        'RBCHALLANSTOCK
        '
        Me.RBCHALLANSTOCK.AutoSize = True
        Me.RBCHALLANSTOCK.Location = New System.Drawing.Point(203, 41)
        Me.RBCHALLANSTOCK.Name = "RBCHALLANSTOCK"
        Me.RBCHALLANSTOCK.Size = New System.Drawing.Size(176, 18)
        Me.RBCHALLANSTOCK.TabIndex = 3
        Me.RBCHALLANSTOCK.Text = "Challan Stock (Not Dispatched)"
        Me.RBCHALLANSTOCK.UseVisualStyleBackColor = True
        '
        'RBGODOWNSTOCK
        '
        Me.RBGODOWNSTOCK.AutoSize = True
        Me.RBGODOWNSTOCK.Location = New System.Drawing.Point(21, 41)
        Me.RBGODOWNSTOCK.Name = "RBGODOWNSTOCK"
        Me.RBGODOWNSTOCK.Size = New System.Drawing.Size(95, 18)
        Me.RBGODOWNSTOCK.TabIndex = 1
        Me.RBGODOWNSTOCK.Text = "Godown Stock"
        Me.RBGODOWNSTOCK.UseVisualStyleBackColor = True
        '
        'RBPACKINGSTOCK
        '
        Me.RBPACKINGSTOCK.AutoSize = True
        Me.RBPACKINGSTOCK.Location = New System.Drawing.Point(203, 17)
        Me.RBPACKINGSTOCK.Name = "RBPACKINGSTOCK"
        Me.RBPACKINGSTOCK.Size = New System.Drawing.Size(91, 18)
        Me.RBPACKINGSTOCK.TabIndex = 2
        Me.RBPACKINGSTOCK.Text = "Packing Stock"
        Me.RBPACKINGSTOCK.UseVisualStyleBackColor = True
        '
        'RBDYEINGSTOCK
        '
        Me.RBDYEINGSTOCK.AutoSize = True
        Me.RBDYEINGSTOCK.Checked = True
        Me.RBDYEINGSTOCK.Location = New System.Drawing.Point(21, 17)
        Me.RBDYEINGSTOCK.Name = "RBDYEINGSTOCK"
        Me.RBDYEINGSTOCK.Size = New System.Drawing.Size(119, 18)
        Me.RBDYEINGSTOCK.TabIndex = 0
        Me.RBDYEINGSTOCK.TabStop = True
        Me.RBDYEINGSTOCK.Text = "Dyeing Stock (Grid)"
        Me.RBDYEINGSTOCK.UseVisualStyleBackColor = True
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(55, 329)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 13
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
        Me.cmdexit.Location = New System.Drawing.Point(55, 363)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'StockRegisterFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1237, 494)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockRegisterFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Register Filter"
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
        Me.GPUNIT.ResumeLayout(False)
        Me.GPUNIT.PerformLayout()
        CType(Me.gridbilldetailsunit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbillunit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
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
    Friend WithEvents GPUNIT As GroupBox
    Friend WithEvents CHKSELECTUNIT As CheckBox
    Private WithEvents gridbilldetailsunit As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbillunit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHKCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents CMBPIECETYPE As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CMBSHADE As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CMBDESIGN As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CMBGODOWN As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBCHALLANSTOCK As RadioButton
    Friend WithEvents RBGODOWNSTOCK As RadioButton
    Friend WithEvents RBPACKINGSTOCK As RadioButton
    Friend WithEvents RBDYEINGSTOCK As RadioButton
    Friend WithEvents cmdshow As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents RBFINISHSTOCKMONTHLY As RadioButton
    Friend WithEvents RBDYEINGSTOCKMONTHLY As RadioButton
    Friend WithEvents RBGREYSTOCKMONTHLY As RadioButton
End Class
