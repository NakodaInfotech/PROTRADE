<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CHKNEGATIVESTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKALLCMP = New System.Windows.Forms.CheckBox()
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
        Me.CMBFORWARD = New System.Windows.Forms.ComboBox()
        Me.LBLFORWARD = New System.Windows.Forms.Label()
        Me.GPPARTYNAME = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTPARTY = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPREGISTER = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTREGISTER = New System.Windows.Forms.CheckBox()
        Me.gridbilldetailsregister = New DevExpress.XtraGrid.GridControl()
        Me.gridbillregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GREGCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GREGISTER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPUNIT = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTUNIT = New System.Windows.Forms.CheckBox()
        Me.gridbilldetailsunit = New DevExpress.XtraGrid.GridControl()
        Me.gridbillunit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHKCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBSTOCKVSORDER = New System.Windows.Forms.RadioButton()
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER = New System.Windows.Forms.RadioButton()
        Me.RDBBARCODESTOCKSUMM = New System.Windows.Forms.RadioButton()
        Me.RBBARCODESTOCKDTLS = New System.Windows.Forms.RadioButton()
        Me.RBITEMWISEBARCODESTOCK = New System.Windows.Forms.RadioButton()
        Me.RBDESIGNNOTSENT = New System.Windows.Forms.RadioButton()
        Me.RBDESIGNSTOCKREGISTER = New System.Windows.Forms.RadioButton()
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM = New System.Windows.Forms.RadioButton()
        Me.RBITEMSHADEGODOWNSUMM = New System.Windows.Forms.RadioButton()
        Me.RBORDERVSSTOCK = New System.Windows.Forms.RadioButton()
        Me.RBGODOWNWISESUMM = New System.Windows.Forms.RadioButton()
        Me.RBBALEWISESUMM = New System.Windows.Forms.RadioButton()
        Me.RBGRIDSTOCKDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBPURSALEMTRS = New System.Windows.Forms.RadioButton()
        Me.RBITEMDESIGNSHADESMALLSUMM = New System.Windows.Forms.RadioButton()
        Me.RBITEMQUALITYSUMM = New System.Windows.Forms.RadioButton()
        Me.RBDESIGNSHADESUMM = New System.Windows.Forms.RadioButton()
        Me.RBITEMDESIGNSHADESUMM = New System.Windows.Forms.RadioButton()
        Me.RBITEMSHADESUMM = New System.Windows.Forms.RadioButton()
        Me.RBSHADESUMM = New System.Windows.Forms.RadioButton()
        Me.RBQUALITYSUMM = New System.Windows.Forms.RadioButton()
        Me.RBDESIGNSUMM = New System.Windows.Forms.RadioButton()
        Me.RBITEMSUMM = New System.Windows.Forms.RadioButton()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RBREORDER = New System.Windows.Forms.RadioButton()
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
        Me.GPPARTYNAME.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPREGISTER.SuspendLayout()
        CType(Me.gridbilldetailsregister, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbillregister, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BlendPanel2.Controls.Add(Me.CHKNEGATIVESTOCK)
        Me.BlendPanel2.Controls.Add(Me.CHKALLCMP)
        Me.BlendPanel2.Controls.Add(Me.GPDESIGN)
        Me.BlendPanel2.Controls.Add(Me.GPSHADE)
        Me.BlendPanel2.Controls.Add(Me.GPITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.CMBFORWARD)
        Me.BlendPanel2.Controls.Add(Me.LBLFORWARD)
        Me.BlendPanel2.Controls.Add(Me.GPPARTYNAME)
        Me.BlendPanel2.Controls.Add(Me.GPREGISTER)
        Me.BlendPanel2.Controls.Add(Me.GPUNIT)
        Me.BlendPanel2.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBPIECETYPE)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel2.Controls.Add(Me.Label3)
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
        Me.BlendPanel2.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel2.TabIndex = 0
        '
        'CHKNEGATIVESTOCK
        '
        Me.CHKNEGATIVESTOCK.AutoSize = True
        Me.CHKNEGATIVESTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKNEGATIVESTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKNEGATIVESTOCK.ForeColor = System.Drawing.Color.Black
        Me.CHKNEGATIVESTOCK.Location = New System.Drawing.Point(263, 43)
        Me.CHKNEGATIVESTOCK.Name = "CHKNEGATIVESTOCK"
        Me.CHKNEGATIVESTOCK.Size = New System.Drawing.Size(134, 18)
        Me.CHKNEGATIVESTOCK.TabIndex = 764
        Me.CHKNEGATIVESTOCK.Text = "Show Bal Stock Only"
        Me.CHKNEGATIVESTOCK.UseVisualStyleBackColor = False
        '
        'CHKALLCMP
        '
        Me.CHKALLCMP.AutoSize = True
        Me.CHKALLCMP.BackColor = System.Drawing.Color.Transparent
        Me.CHKALLCMP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKALLCMP.ForeColor = System.Drawing.Color.Black
        Me.CHKALLCMP.Location = New System.Drawing.Point(399, 72)
        Me.CHKALLCMP.Name = "CHKALLCMP"
        Me.CHKALLCMP.Size = New System.Drawing.Size(93, 18)
        Me.CHKALLCMP.TabIndex = 763
        Me.CHKALLCMP.Text = "All Compnay"
        Me.CHKALLCMP.UseVisualStyleBackColor = False
        '
        'GPDESIGN
        '
        Me.GPDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.GPDESIGN.Controls.Add(Me.CHKSELECTDESIGN)
        Me.GPDESIGN.Controls.Add(Me.GRIDDESIGNDETAILS)
        Me.GPDESIGN.Location = New System.Drawing.Point(700, 345)
        Me.GPDESIGN.Name = "GPDESIGN"
        Me.GPDESIGN.Size = New System.Drawing.Size(264, 229)
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
        Me.GRIDDESIGNDETAILS.Size = New System.Drawing.Size(246, 200)
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
        Me.GPSHADE.Location = New System.Drawing.Point(964, 345)
        Me.GPSHADE.Name = "GPSHADE"
        Me.GPSHADE.Size = New System.Drawing.Size(264, 229)
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
        Me.GPITEMNAME.Size = New System.Drawing.Size(264, 327)
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
        Me.GRIDITEMDETAILS.Size = New System.Drawing.Size(246, 297)
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
        'CMBFORWARD
        '
        Me.CMBFORWARD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFORWARD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFORWARD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFORWARD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFORWARD.FormattingEnabled = True
        Me.CMBFORWARD.Items.AddRange(New Object() {"", "READY", "FORWARD"})
        Me.CMBFORWARD.Location = New System.Drawing.Point(582, 68)
        Me.CMBFORWARD.Name = "CMBFORWARD"
        Me.CMBFORWARD.Size = New System.Drawing.Size(85, 22)
        Me.CMBFORWARD.TabIndex = 7
        Me.CMBFORWARD.Visible = False
        '
        'LBLFORWARD
        '
        Me.LBLFORWARD.BackColor = System.Drawing.Color.Transparent
        Me.LBLFORWARD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFORWARD.ForeColor = System.Drawing.Color.Black
        Me.LBLFORWARD.Location = New System.Drawing.Point(483, 72)
        Me.LBLFORWARD.Name = "LBLFORWARD"
        Me.LBLFORWARD.Size = New System.Drawing.Size(97, 14)
        Me.LBLFORWARD.TabIndex = 715
        Me.LBLFORWARD.Text = "Ready / Forward"
        Me.LBLFORWARD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBLFORWARD.Visible = False
        '
        'GPPARTYNAME
        '
        Me.GPPARTYNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPPARTYNAME.Controls.Add(Me.CHKSELECTPARTY)
        Me.GPPARTYNAME.Controls.Add(Me.gridbilldetails)
        Me.GPPARTYNAME.Location = New System.Drawing.Point(964, 12)
        Me.GPPARTYNAME.Name = "GPPARTYNAME"
        Me.GPPARTYNAME.Size = New System.Drawing.Size(264, 327)
        Me.GPPARTYNAME.TabIndex = 757
        Me.GPPARTYNAME.TabStop = False
        Me.GPPARTYNAME.Text = "Party Name"
        '
        'CHKSELECTPARTY
        '
        Me.CHKSELECTPARTY.AutoSize = True
        Me.CHKSELECTPARTY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTPARTY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTPARTY.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTPARTY.Location = New System.Drawing.Point(32, 22)
        Me.CHKSELECTPARTY.Name = "CHKSELECTPARTY"
        Me.CHKSELECTPARTY.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTPARTY.TabIndex = 0
        Me.CHKSELECTPARTY.Text = "Select All"
        Me.CHKSELECTPARTY.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(6, 20)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.gridbilldetails.Size = New System.Drawing.Size(246, 297)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 35
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 230
        '
        'GPREGISTER
        '
        Me.GPREGISTER.BackColor = System.Drawing.Color.Transparent
        Me.GPREGISTER.Controls.Add(Me.CHKSELECTREGISTER)
        Me.GPREGISTER.Controls.Add(Me.gridbilldetailsregister)
        Me.GPREGISTER.Location = New System.Drawing.Point(399, 404)
        Me.GPREGISTER.Name = "GPREGISTER"
        Me.GPREGISTER.Size = New System.Drawing.Size(277, 178)
        Me.GPREGISTER.TabIndex = 756
        Me.GPREGISTER.TabStop = False
        Me.GPREGISTER.Text = "Register"
        '
        'CHKSELECTREGISTER
        '
        Me.CHKSELECTREGISTER.AutoSize = True
        Me.CHKSELECTREGISTER.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTREGISTER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTREGISTER.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTREGISTER.Location = New System.Drawing.Point(28, 19)
        Me.CHKSELECTREGISTER.Name = "CHKSELECTREGISTER"
        Me.CHKSELECTREGISTER.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTREGISTER.TabIndex = 0
        Me.CHKSELECTREGISTER.Text = "Select All"
        Me.CHKSELECTREGISTER.UseVisualStyleBackColor = False
        '
        'gridbilldetailsregister
        '
        Me.gridbilldetailsregister.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetailsregister.Location = New System.Drawing.Point(6, 16)
        Me.gridbilldetailsregister.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetailsregister.MainView = Me.gridbillregister
        Me.gridbilldetailsregister.Name = "gridbilldetailsregister"
        Me.gridbilldetailsregister.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetailsregister.Size = New System.Drawing.Size(266, 143)
        Me.gridbilldetailsregister.TabIndex = 1
        Me.gridbilldetailsregister.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbillregister})
        '
        'gridbillregister
        '
        Me.gridbillregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbillregister.Appearance.Row.Options.UseFont = True
        Me.gridbillregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GREGCHK, Me.GREGISTER})
        Me.gridbillregister.GridControl = Me.gridbilldetailsregister
        Me.gridbillregister.Name = "gridbillregister"
        Me.gridbillregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbillregister.OptionsView.ColumnAutoWidth = False
        Me.gridbillregister.OptionsView.ShowAutoFilterRow = True
        Me.gridbillregister.OptionsView.ShowGroupPanel = False
        '
        'GREGCHK
        '
        Me.GREGCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GREGCHK.FieldName = "CHK"
        Me.GREGCHK.Name = "GREGCHK"
        Me.GREGCHK.OptionsColumn.ShowCaption = False
        Me.GREGCHK.Visible = True
        Me.GREGCHK.VisibleIndex = 0
        Me.GREGCHK.Width = 35
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GREGISTER
        '
        Me.GREGISTER.Caption = "Register"
        Me.GREGISTER.FieldName = "REGNAME"
        Me.GREGISTER.ImageIndex = 0
        Me.GREGISTER.Name = "GREGISTER"
        Me.GREGISTER.OptionsColumn.AllowEdit = False
        Me.GREGISTER.Visible = True
        Me.GREGISTER.VisibleIndex = 1
        Me.GREGISTER.Width = 300
        '
        'GPUNIT
        '
        Me.GPUNIT.BackColor = System.Drawing.Color.Transparent
        Me.GPUNIT.Controls.Add(Me.CHKSELECTUNIT)
        Me.GPUNIT.Controls.Add(Me.gridbilldetailsunit)
        Me.GPUNIT.Location = New System.Drawing.Point(184, 405)
        Me.GPUNIT.Name = "GPUNIT"
        Me.GPUNIT.Size = New System.Drawing.Size(209, 164)
        Me.GPUNIT.TabIndex = 755
        Me.GPUNIT.TabStop = False
        Me.GPUNIT.Text = "Unit"
        '
        'CHKSELECTUNIT
        '
        Me.CHKSELECTUNIT.AutoSize = True
        Me.CHKSELECTUNIT.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTUNIT.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTUNIT.Location = New System.Drawing.Point(25, 18)
        Me.CHKSELECTUNIT.Name = "CHKSELECTUNIT"
        Me.CHKSELECTUNIT.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTUNIT.TabIndex = 0
        Me.CHKSELECTUNIT.Text = "Select All"
        Me.CHKSELECTUNIT.UseVisualStyleBackColor = False
        '
        'gridbilldetailsunit
        '
        Me.gridbilldetailsunit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetailsunit.Location = New System.Drawing.Point(6, 15)
        Me.gridbilldetailsunit.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetailsunit.MainView = Me.gridbillunit
        Me.gridbilldetailsunit.Name = "gridbilldetailsunit"
        Me.gridbilldetailsunit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3})
        Me.gridbilldetailsunit.Size = New System.Drawing.Size(201, 143)
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
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(76, 68)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(85, 22)
        Me.CMBCATEGORY.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 14)
        Me.Label9.TabIndex = 754
        Me.Label9.Text = "Category"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(35, 413)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 7
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
        Me.GroupBox1.Location = New System.Drawing.Point(30, 413)
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
        Me.Label1.Size = New System.Drawing.Size(25, 14)
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
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From :"
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(307, 68)
        Me.CMBPIECETYPE.MaxDropDownItems = 14
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(85, 22)
        Me.CMBPIECETYPE.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(248, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 14)
        Me.Label8.TabIndex = 752
        Me.Label8.Text = "Piece Type"
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(437, 40)
        Me.CMBSHADE.MaxDropDownItems = 14
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(230, 22)
        Me.CMBSHADE.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(399, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 14)
        Me.Label6.TabIndex = 750
        Me.Label6.Text = "Shade"
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(437, 12)
        Me.CMBDESIGN.MaxDropDownItems = 14
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(230, 22)
        Me.CMBDESIGN.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(396, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 14)
        Me.Label4.TabIndex = 748
        Me.Label4.Text = "Design"
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(307, 12)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(85, 22)
        Me.CMBQUALITY.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(263, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 14)
        Me.Label3.TabIndex = 746
        Me.Label3.Text = "Quality"
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(76, 12)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(181, 22)
        Me.CMBGODOWN.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 744
        Me.Label2.Text = "Godown"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(76, 40)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(181, 22)
        Me.CMBITEMNAME.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(7, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 742
        Me.Label5.Text = "Item Name"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBREORDER)
        Me.GroupBox3.Controls.Add(Me.RBSTOCKVSORDER)
        Me.GroupBox3.Controls.Add(Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER)
        Me.GroupBox3.Controls.Add(Me.RDBBARCODESTOCKSUMM)
        Me.GroupBox3.Controls.Add(Me.RBBARCODESTOCKDTLS)
        Me.GroupBox3.Controls.Add(Me.RBITEMWISEBARCODESTOCK)
        Me.GroupBox3.Controls.Add(Me.RBDESIGNNOTSENT)
        Me.GroupBox3.Controls.Add(Me.RBDESIGNSTOCKREGISTER)
        Me.GroupBox3.Controls.Add(Me.RBITEMDESIGNSHADESMALLNOUNITSUMM)
        Me.GroupBox3.Controls.Add(Me.RBITEMSHADEGODOWNSUMM)
        Me.GroupBox3.Controls.Add(Me.RBORDERVSSTOCK)
        Me.GroupBox3.Controls.Add(Me.RBGODOWNWISESUMM)
        Me.GroupBox3.Controls.Add(Me.RBBALEWISESUMM)
        Me.GroupBox3.Controls.Add(Me.RBGRIDSTOCKDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBPURSALEMTRS)
        Me.GroupBox3.Controls.Add(Me.RBITEMDESIGNSHADESMALLSUMM)
        Me.GroupBox3.Controls.Add(Me.RBITEMQUALITYSUMM)
        Me.GroupBox3.Controls.Add(Me.RBDESIGNSHADESUMM)
        Me.GroupBox3.Controls.Add(Me.RBITEMDESIGNSHADESUMM)
        Me.GroupBox3.Controls.Add(Me.RBITEMSHADESUMM)
        Me.GroupBox3.Controls.Add(Me.RBSHADESUMM)
        Me.GroupBox3.Controls.Add(Me.RBQUALITYSUMM)
        Me.GroupBox3.Controls.Add(Me.RBDESIGNSUMM)
        Me.GroupBox3.Controls.Add(Me.RBITEMSUMM)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(682, 308)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'RBSTOCKVSORDER
        '
        Me.RBSTOCKVSORDER.AutoSize = True
        Me.RBSTOCKVSORDER.Location = New System.Drawing.Point(21, 252)
        Me.RBSTOCKVSORDER.Name = "RBSTOCKVSORDER"
        Me.RBSTOCKVSORDER.Size = New System.Drawing.Size(164, 18)
        Me.RBSTOCKVSORDER.TabIndex = 16
        Me.RBSTOCKVSORDER.Text = "Stock Against Order (Grid)"
        Me.RBSTOCKVSORDER.UseVisualStyleBackColor = True
        '
        'RBITEMDESIGNSHADEGRIDSTOCKREGISTER
        '
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.AutoSize = True
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Location = New System.Drawing.Point(21, 180)
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Name = "RBITEMDESIGNSHADEGRIDSTOCKREGISTER"
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Size = New System.Drawing.Size(255, 18)
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.TabIndex = 7
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.Text = "Item - Design - Shade Stock Register (Grid)"
        Me.RBITEMDESIGNSHADEGRIDSTOCKREGISTER.UseVisualStyleBackColor = True
        '
        'RDBBARCODESTOCKSUMM
        '
        Me.RDBBARCODESTOCKSUMM.AutoSize = True
        Me.RDBBARCODESTOCKSUMM.Location = New System.Drawing.Point(248, 84)
        Me.RDBBARCODESTOCKSUMM.Name = "RDBBARCODESTOCKSUMM"
        Me.RDBBARCODESTOCKSUMM.Size = New System.Drawing.Size(191, 18)
        Me.RDBBARCODESTOCKSUMM.TabIndex = 14
        Me.RDBBARCODESTOCKSUMM.Text = "Barcode Stock Summary Report"
        Me.RDBBARCODESTOCKSUMM.UseVisualStyleBackColor = True
        '
        'RBBARCODESTOCKDTLS
        '
        Me.RBBARCODESTOCKDTLS.AutoSize = True
        Me.RBBARCODESTOCKDTLS.Location = New System.Drawing.Point(248, 60)
        Me.RBBARCODESTOCKDTLS.Name = "RBBARCODESTOCKDTLS"
        Me.RBBARCODESTOCKDTLS.Size = New System.Drawing.Size(182, 18)
        Me.RBBARCODESTOCKDTLS.TabIndex = 13
        Me.RBBARCODESTOCKDTLS.Text = "Barcode Stock Details Report"
        Me.RBBARCODESTOCKDTLS.UseVisualStyleBackColor = True
        '
        'RBITEMWISEBARCODESTOCK
        '
        Me.RBITEMWISEBARCODESTOCK.AutoSize = True
        Me.RBITEMWISEBARCODESTOCK.Checked = True
        Me.RBITEMWISEBARCODESTOCK.Location = New System.Drawing.Point(21, 12)
        Me.RBITEMWISEBARCODESTOCK.Name = "RBITEMWISEBARCODESTOCK"
        Me.RBITEMWISEBARCODESTOCK.Size = New System.Drawing.Size(167, 18)
        Me.RBITEMWISEBARCODESTOCK.TabIndex = 0
        Me.RBITEMWISEBARCODESTOCK.TabStop = True
        Me.RBITEMWISEBARCODESTOCK.Text = "Item Wise Stock (Barcode)"
        Me.RBITEMWISEBARCODESTOCK.UseVisualStyleBackColor = True
        '
        'RBDESIGNNOTSENT
        '
        Me.RBDESIGNNOTSENT.AutoSize = True
        Me.RBDESIGNNOTSENT.Location = New System.Drawing.Point(248, 132)
        Me.RBDESIGNNOTSENT.Name = "RBDESIGNNOTSENT"
        Me.RBDESIGNNOTSENT.Size = New System.Drawing.Size(279, 18)
        Me.RBDESIGNNOTSENT.TabIndex = 10
        Me.RBDESIGNNOTSENT.Text = "Design Not Sent to Party and Available in Stock"
        Me.RBDESIGNNOTSENT.UseVisualStyleBackColor = True
        '
        'RBDESIGNSTOCKREGISTER
        '
        Me.RBDESIGNSTOCKREGISTER.AutoSize = True
        Me.RBDESIGNSTOCKREGISTER.Location = New System.Drawing.Point(21, 156)
        Me.RBDESIGNSTOCKREGISTER.Name = "RBDESIGNSTOCKREGISTER"
        Me.RBDESIGNSTOCKREGISTER.Size = New System.Drawing.Size(176, 18)
        Me.RBDESIGNSTOCKREGISTER.TabIndex = 6
        Me.RBDESIGNSTOCKREGISTER.Text = "Design Stock Register (Grid)"
        Me.RBDESIGNSTOCKREGISTER.UseVisualStyleBackColor = True
        '
        'RBITEMDESIGNSHADESMALLNOUNITSUMM
        '
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.AutoSize = True
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.Location = New System.Drawing.Point(248, 36)
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.Name = "RBITEMDESIGNSHADESMALLNOUNITSUMM"
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.Size = New System.Drawing.Size(319, 18)
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.TabIndex = 12
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.Text = "Item - Design - Shade Wise Stock Without Unit (Small)"
        Me.RBITEMDESIGNSHADESMALLNOUNITSUMM.UseVisualStyleBackColor = True
        '
        'RBITEMSHADEGODOWNSUMM
        '
        Me.RBITEMSHADEGODOWNSUMM.AutoSize = True
        Me.RBITEMSHADEGODOWNSUMM.Location = New System.Drawing.Point(516, 236)
        Me.RBITEMSHADEGODOWNSUMM.Name = "RBITEMSHADEGODOWNSUMM"
        Me.RBITEMSHADEGODOWNSUMM.Size = New System.Drawing.Size(204, 18)
        Me.RBITEMSHADEGODOWNSUMM.TabIndex = 9
        Me.RBITEMSHADEGODOWNSUMM.Text = "Item - Shade Godown Wise Stock"
        Me.RBITEMSHADEGODOWNSUMM.UseVisualStyleBackColor = True
        Me.RBITEMSHADEGODOWNSUMM.Visible = False
        '
        'RBORDERVSSTOCK
        '
        Me.RBORDERVSSTOCK.AutoSize = True
        Me.RBORDERVSSTOCK.Location = New System.Drawing.Point(21, 228)
        Me.RBORDERVSSTOCK.Name = "RBORDERVSSTOCK"
        Me.RBORDERVSSTOCK.Size = New System.Drawing.Size(207, 18)
        Me.RBORDERVSSTOCK.TabIndex = 9
        Me.RBORDERVSSTOCK.Text = "Order Against Stock Details (Grid)"
        Me.RBORDERVSSTOCK.UseVisualStyleBackColor = True
        '
        'RBGODOWNWISESUMM
        '
        Me.RBGODOWNWISESUMM.AutoSize = True
        Me.RBGODOWNWISESUMM.Location = New System.Drawing.Point(248, 108)
        Me.RBGODOWNWISESUMM.Name = "RBGODOWNWISESUMM"
        Me.RBGODOWNWISESUMM.Size = New System.Drawing.Size(222, 18)
        Me.RBGODOWNWISESUMM.TabIndex = 15
        Me.RBGODOWNWISESUMM.Text = "Godown - Item Wise Stock (Barcode)"
        Me.RBGODOWNWISESUMM.UseVisualStyleBackColor = True
        '
        'RBBALEWISESUMM
        '
        Me.RBBALEWISESUMM.AutoSize = True
        Me.RBBALEWISESUMM.Location = New System.Drawing.Point(21, 204)
        Me.RBBALEWISESUMM.Name = "RBBALEWISESUMM"
        Me.RBBALEWISESUMM.Size = New System.Drawing.Size(112, 18)
        Me.RBBALEWISESUMM.TabIndex = 8
        Me.RBBALEWISESUMM.Text = "Bale Wise Stock"
        Me.RBBALEWISESUMM.UseVisualStyleBackColor = True
        '
        'RBGRIDSTOCKDETAILS
        '
        Me.RBGRIDSTOCKDETAILS.AutoSize = True
        Me.RBGRIDSTOCKDETAILS.Location = New System.Drawing.Point(21, 132)
        Me.RBGRIDSTOCKDETAILS.Name = "RBGRIDSTOCKDETAILS"
        Me.RBGRIDSTOCKDETAILS.Size = New System.Drawing.Size(130, 18)
        Me.RBGRIDSTOCKDETAILS.TabIndex = 5
        Me.RBGRIDSTOCKDETAILS.Text = "Stock Details (Grid)"
        Me.RBGRIDSTOCKDETAILS.UseVisualStyleBackColor = True
        '
        'RBPURSALEMTRS
        '
        Me.RBPURSALEMTRS.AutoSize = True
        Me.RBPURSALEMTRS.Location = New System.Drawing.Point(21, 108)
        Me.RBPURSALEMTRS.Name = "RBPURSALEMTRS"
        Me.RBPURSALEMTRS.Size = New System.Drawing.Size(168, 18)
        Me.RBPURSALEMTRS.TabIndex = 4
        Me.RBPURSALEMTRS.Text = "Pur - Sale Mtrs Stock (Grid)"
        Me.RBPURSALEMTRS.UseVisualStyleBackColor = True
        '
        'RBITEMDESIGNSHADESMALLSUMM
        '
        Me.RBITEMDESIGNSHADESMALLSUMM.AutoSize = True
        Me.RBITEMDESIGNSHADESMALLSUMM.Location = New System.Drawing.Point(248, 12)
        Me.RBITEMDESIGNSHADESMALLSUMM.Name = "RBITEMDESIGNSHADESMALLSUMM"
        Me.RBITEMDESIGNSHADESMALLSUMM.Size = New System.Drawing.Size(246, 18)
        Me.RBITEMDESIGNSHADESMALLSUMM.TabIndex = 11
        Me.RBITEMDESIGNSHADESMALLSUMM.Text = "Item - Design - Shade Wise Stock (Small)"
        Me.RBITEMDESIGNSHADESMALLSUMM.UseVisualStyleBackColor = True
        '
        'RBITEMQUALITYSUMM
        '
        Me.RBITEMQUALITYSUMM.AutoSize = True
        Me.RBITEMQUALITYSUMM.Location = New System.Drawing.Point(516, 188)
        Me.RBITEMQUALITYSUMM.Name = "RBITEMQUALITYSUMM"
        Me.RBITEMQUALITYSUMM.Size = New System.Drawing.Size(161, 18)
        Me.RBITEMQUALITYSUMM.TabIndex = 15
        Me.RBITEMQUALITYSUMM.Text = "Item - Quality Wise Stock"
        Me.RBITEMQUALITYSUMM.UseVisualStyleBackColor = True
        Me.RBITEMQUALITYSUMM.Visible = False
        '
        'RBDESIGNSHADESUMM
        '
        Me.RBDESIGNSHADESUMM.AutoSize = True
        Me.RBDESIGNSHADESUMM.Location = New System.Drawing.Point(516, 164)
        Me.RBDESIGNSHADESUMM.Name = "RBDESIGNSHADESUMM"
        Me.RBDESIGNSHADESUMM.Size = New System.Drawing.Size(169, 18)
        Me.RBDESIGNSHADESUMM.TabIndex = 14
        Me.RBDESIGNSHADESUMM.Text = "Design - Shade Wise Stock"
        Me.RBDESIGNSHADESUMM.UseVisualStyleBackColor = True
        Me.RBDESIGNSHADESUMM.Visible = False
        '
        'RBITEMDESIGNSHADESUMM
        '
        Me.RBITEMDESIGNSHADESUMM.AutoSize = True
        Me.RBITEMDESIGNSHADESUMM.Location = New System.Drawing.Point(516, 260)
        Me.RBITEMDESIGNSHADESUMM.Name = "RBITEMDESIGNSHADESUMM"
        Me.RBITEMDESIGNSHADESUMM.Size = New System.Drawing.Size(204, 18)
        Me.RBITEMDESIGNSHADESUMM.TabIndex = 10
        Me.RBITEMDESIGNSHADESUMM.Text = "Item - Design - Shade Wise Stock"
        Me.RBITEMDESIGNSHADESUMM.UseVisualStyleBackColor = True
        Me.RBITEMDESIGNSHADESUMM.Visible = False
        '
        'RBITEMSHADESUMM
        '
        Me.RBITEMSHADESUMM.AutoSize = True
        Me.RBITEMSHADESUMM.Location = New System.Drawing.Point(516, 212)
        Me.RBITEMSHADESUMM.Name = "RBITEMSHADESUMM"
        Me.RBITEMSHADESUMM.Size = New System.Drawing.Size(156, 18)
        Me.RBITEMSHADESUMM.TabIndex = 8
        Me.RBITEMSHADESUMM.Text = "Item - Shade Wise Stock"
        Me.RBITEMSHADESUMM.UseVisualStyleBackColor = True
        Me.RBITEMSHADESUMM.Visible = False
        '
        'RBSHADESUMM
        '
        Me.RBSHADESUMM.AutoSize = True
        Me.RBSHADESUMM.Location = New System.Drawing.Point(21, 84)
        Me.RBSHADESUMM.Name = "RBSHADESUMM"
        Me.RBSHADESUMM.Size = New System.Drawing.Size(121, 18)
        Me.RBSHADESUMM.TabIndex = 3
        Me.RBSHADESUMM.Text = "Shade Wise Stock"
        Me.RBSHADESUMM.UseVisualStyleBackColor = True
        '
        'RBQUALITYSUMM
        '
        Me.RBQUALITYSUMM.AutoSize = True
        Me.RBQUALITYSUMM.Location = New System.Drawing.Point(21, 36)
        Me.RBQUALITYSUMM.Name = "RBQUALITYSUMM"
        Me.RBQUALITYSUMM.Size = New System.Drawing.Size(126, 18)
        Me.RBQUALITYSUMM.TabIndex = 1
        Me.RBQUALITYSUMM.Text = "Quality Wise Stock"
        Me.RBQUALITYSUMM.UseVisualStyleBackColor = True
        '
        'RBDESIGNSUMM
        '
        Me.RBDESIGNSUMM.AutoSize = True
        Me.RBDESIGNSUMM.Location = New System.Drawing.Point(21, 60)
        Me.RBDESIGNSUMM.Name = "RBDESIGNSUMM"
        Me.RBDESIGNSUMM.Size = New System.Drawing.Size(125, 18)
        Me.RBDESIGNSUMM.TabIndex = 2
        Me.RBDESIGNSUMM.Text = "Design Wise Stock"
        Me.RBDESIGNSUMM.UseVisualStyleBackColor = True
        '
        'RBITEMSUMM
        '
        Me.RBITEMSUMM.AutoSize = True
        Me.RBITEMSUMM.Location = New System.Drawing.Point(516, 284)
        Me.RBITEMSUMM.Name = "RBITEMSUMM"
        Me.RBITEMSUMM.Size = New System.Drawing.Size(112, 18)
        Me.RBITEMSUMM.TabIndex = 0
        Me.RBITEMSUMM.Text = "Item Wise Stock"
        Me.RBITEMSUMM.UseVisualStyleBackColor = True
        Me.RBITEMSUMM.Visible = False
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(30, 505)
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
        Me.cmdexit.Location = New System.Drawing.Point(30, 539)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBREORDER
        '
        Me.RBREORDER.AutoSize = True
        Me.RBREORDER.Location = New System.Drawing.Point(21, 276)
        Me.RBREORDER.Name = "RBREORDER"
        Me.RBREORDER.Size = New System.Drawing.Size(107, 18)
        Me.RBREORDER.TabIndex = 17
        Me.RBREORDER.Text = "Re-Order (Grid)"
        Me.RBREORDER.UseVisualStyleBackColor = True
        '
        'StockFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Filter"
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
        Me.GPPARTYNAME.ResumeLayout(False)
        Me.GPPARTYNAME.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPREGISTER.ResumeLayout(False)
        Me.GPREGISTER.PerformLayout()
        CType(Me.gridbilldetailsregister, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbillregister, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBITEMSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBPIECETYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RBDESIGNSHADESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBITEMDESIGNSHADESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBITEMSHADESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBSHADESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBQUALITYSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBDESIGNSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RBITEMQUALITYSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBITEMDESIGNSHADESMALLSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents GPUNIT As System.Windows.Forms.GroupBox
    Friend WithEvents CHKSELECTUNIT As System.Windows.Forms.CheckBox
    Private WithEvents gridbilldetailsunit As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbillunit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHKCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPREGISTER As GroupBox
    Friend WithEvents CHKSELECTREGISTER As CheckBox
    Private WithEvents gridbilldetailsregister As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbillregister As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GREGCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GREGISTER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBPURSALEMTRS As RadioButton
    Friend WithEvents RBGRIDSTOCKDETAILS As RadioButton
    Friend WithEvents RBBALEWISESUMM As RadioButton
    Friend WithEvents RBGODOWNWISESUMM As RadioButton
    Friend WithEvents RBORDERVSSTOCK As RadioButton
    Friend WithEvents GPPARTYNAME As GroupBox
    Friend WithEvents CHKSELECTPARTY As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBITEMSHADEGODOWNSUMM As RadioButton
    Friend WithEvents CMBFORWARD As ComboBox
    Friend WithEvents LBLFORWARD As Label
    Friend WithEvents RBITEMDESIGNSHADESMALLNOUNITSUMM As RadioButton
    Friend WithEvents RBDESIGNSTOCKREGISTER As RadioButton
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
    Friend WithEvents CHKALLCMP As CheckBox
    Friend WithEvents RBDESIGNNOTSENT As RadioButton
    Friend WithEvents RBITEMWISEBARCODESTOCK As RadioButton
    Friend WithEvents RBBARCODESTOCKDTLS As RadioButton
    Friend WithEvents RDBBARCODESTOCKSUMM As RadioButton
    Friend WithEvents CHKNEGATIVESTOCK As CheckBox
    Friend WithEvents RBITEMDESIGNSHADEGRIDSTOCKREGISTER As RadioButton
    Friend WithEvents RBSTOCKVSORDER As RadioButton
    Friend WithEvents RBREORDER As RadioButton
End Class
