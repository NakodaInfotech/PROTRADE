<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotFilter
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
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBPENDING = New System.Windows.Forms.RadioButton()
        Me.RDBCOMPLETE = New System.Windows.Forms.RadioButton()
        Me.RDBFULL = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBJOBBER = New System.Windows.Forms.ComboBox()
        Me.cmbacccode = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.GPITEMNAME = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CHKSELECTITEM = New System.Windows.Forms.CheckBox()
        Me.GRIDITEMDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDITEM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPPARTYNAME = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTPARTY = New System.Windows.Forms.CheckBox()
        Me.gridpartydetails = New DevExpress.XtraGrid.GridControl()
        Me.Gridparty = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbilldetailschallan = New DevExpress.XtraGrid.GridControl()
        Me.gridbillchallan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHALLANCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GCHALLAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKPENDINGPROG = New System.Windows.Forms.CheckBox()
        Me.CHKGRIDDETAILS = New System.Windows.Forms.CheckBox()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMBGROUP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.GPITEMNAME.SuspendLayout()
        CType(Me.GRIDITEMDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPPARTYNAME.SuspendLayout()
        CType(Me.gridpartydetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridparty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetailschallan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbillchallan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(631, 360)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 738
        Me.CMBCODE.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'txtDeliveryadd
        '
        Me.txtDeliveryadd.BackColor = System.Drawing.Color.White
        Me.txtDeliveryadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryadd.Enabled = False
        Me.txtDeliveryadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryadd.Location = New System.Drawing.Point(631, 348)
        Me.txtDeliveryadd.Name = "txtDeliveryadd"
        Me.txtDeliveryadd.ReadOnly = True
        Me.txtDeliveryadd.Size = New System.Drawing.Size(34, 22)
        Me.txtDeliveryadd.TabIndex = 737
        Me.txtDeliveryadd.TabStop = False
        Me.txtDeliveryadd.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBPENDING)
        Me.GroupBox3.Controls.Add(Me.RDBCOMPLETE)
        Me.GroupBox3.Controls.Add(Me.RDBFULL)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(28, 161)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(306, 100)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'RDBPENDING
        '
        Me.RDBPENDING.AutoSize = True
        Me.RDBPENDING.Checked = True
        Me.RDBPENDING.Location = New System.Drawing.Point(12, 21)
        Me.RDBPENDING.Name = "RDBPENDING"
        Me.RDBPENDING.Size = New System.Drawing.Size(88, 18)
        Me.RDBPENDING.TabIndex = 0
        Me.RDBPENDING.TabStop = True
        Me.RDBPENDING.Text = "Pending Lot"
        Me.RDBPENDING.UseVisualStyleBackColor = True
        '
        'RDBCOMPLETE
        '
        Me.RDBCOMPLETE.AutoSize = True
        Me.RDBCOMPLETE.Location = New System.Drawing.Point(12, 45)
        Me.RDBCOMPLETE.Name = "RDBCOMPLETE"
        Me.RDBCOMPLETE.Size = New System.Drawing.Size(103, 18)
        Me.RDBCOMPLETE.TabIndex = 1
        Me.RDBCOMPLETE.Text = "Lot Completed"
        Me.RDBCOMPLETE.UseVisualStyleBackColor = True
        '
        'RDBFULL
        '
        Me.RDBFULL.AutoSize = True
        Me.RDBFULL.Location = New System.Drawing.Point(12, 69)
        Me.RDBFULL.Name = "RDBFULL"
        Me.RDBFULL.Size = New System.Drawing.Size(85, 18)
        Me.RDBFULL.TabIndex = 2
        Me.RDBFULL.Text = "Full Report"
        Me.RDBFULL.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(18, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 14)
        Me.Label10.TabIndex = 652
        Me.Label10.Text = "Jobber"
        '
        'CMBJOBBER
        '
        Me.CMBJOBBER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBJOBBER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBJOBBER.BackColor = System.Drawing.Color.White
        Me.CMBJOBBER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBJOBBER.FormattingEnabled = True
        Me.CMBJOBBER.Location = New System.Drawing.Point(63, 18)
        Me.CMBJOBBER.MaxDropDownItems = 14
        Me.CMBJOBBER.Name = "CMBJOBBER"
        Me.CMBJOBBER.Size = New System.Drawing.Size(230, 22)
        Me.CMBJOBBER.TabIndex = 0
        '
        'cmbacccode
        '
        Me.cmbacccode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbacccode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbacccode.BackColor = System.Drawing.Color.White
        Me.cmbacccode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbacccode.FormattingEnabled = True
        Me.cmbacccode.Location = New System.Drawing.Point(671, 360)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(671, 361)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(30, 23)
        Me.txtadd.TabIndex = 649
        Me.txtadd.Visible = False
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(668, 363)
        Me.TXTTEMP.Name = "TXTTEMP"
        Me.TXTTEMP.Size = New System.Drawing.Size(30, 23)
        Me.TXTTEMP.TabIndex = 646
        Me.TXTTEMP.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(28, 310)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
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
        Me.GroupBox1.Location = New System.Drawing.Point(28, 313)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
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
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMBGROUP)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.GPITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.GPPARTYNAME)
        Me.BlendPanel2.Controls.Add(Me.gridbilldetailschallan)
        Me.BlendPanel2.Controls.Add(Me.CHKPENDINGPROG)
        Me.BlendPanel2.Controls.Add(Me.CHKGRIDDETAILS)
        Me.BlendPanel2.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.Label10)
        Me.BlendPanel2.Controls.Add(Me.CMBJOBBER)
        Me.BlendPanel2.Controls.Add(Me.cmbacccode)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel2.TabIndex = 0
        '
        'GPITEMNAME
        '
        Me.GPITEMNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPITEMNAME.Controls.Add(Me.ComboBox1)
        Me.GPITEMNAME.Controls.Add(Me.CHKSELECTITEM)
        Me.GPITEMNAME.Controls.Add(Me.GRIDITEMDETAILS)
        Me.GPITEMNAME.Location = New System.Drawing.Point(612, 18)
        Me.GPITEMNAME.Name = "GPITEMNAME"
        Me.GPITEMNAME.Size = New System.Drawing.Size(264, 552)
        Me.GPITEMNAME.TabIndex = 763
        Me.GPITEMNAME.TabStop = False
        Me.GPITEMNAME.Text = "Item Name"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(158, -6)
        Me.ComboBox1.MaxDropDownItems = 14
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(35, 22)
        Me.ComboBox1.TabIndex = 767
        Me.ComboBox1.Visible = False
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
        Me.GRIDITEMDETAILS.Size = New System.Drawing.Size(246, 526)
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
        Me.GITEMNAME.Caption = "NAME"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.ImageIndex = 0
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 165
        '
        'GPPARTYNAME
        '
        Me.GPPARTYNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPPARTYNAME.Controls.Add(Me.CHKSELECTPARTY)
        Me.GPPARTYNAME.Controls.Add(Me.gridpartydetails)
        Me.GPPARTYNAME.Location = New System.Drawing.Point(882, 18)
        Me.GPPARTYNAME.Name = "GPPARTYNAME"
        Me.GPPARTYNAME.Size = New System.Drawing.Size(330, 552)
        Me.GPPARTYNAME.TabIndex = 762
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
        'gridpartydetails
        '
        Me.gridpartydetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridpartydetails.Location = New System.Drawing.Point(6, 20)
        Me.gridpartydetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridpartydetails.MainView = Me.Gridparty
        Me.gridpartydetails.Name = "gridpartydetails"
        Me.gridpartydetails.Size = New System.Drawing.Size(311, 526)
        Me.gridpartydetails.TabIndex = 1
        Me.gridpartydetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Gridparty})
        '
        'Gridparty
        '
        Me.Gridparty.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gridparty.Appearance.Row.Options.UseFont = True
        Me.Gridparty.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GNAME})
        Me.Gridparty.GridControl = Me.gridpartydetails
        Me.Gridparty.Name = "Gridparty"
        Me.Gridparty.OptionsBehavior.AllowIncrementalSearch = True
        Me.Gridparty.OptionsView.ColumnAutoWidth = False
        Me.Gridparty.OptionsView.ShowAutoFilterRow = True
        Me.Gridparty.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "CHK"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ShowCaption = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 35
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
        'gridbilldetailschallan
        '
        Me.gridbilldetailschallan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetailschallan.Location = New System.Drawing.Point(366, 341)
        Me.gridbilldetailschallan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetailschallan.MainView = Me.gridbillchallan
        Me.gridbilldetailschallan.Name = "gridbilldetailschallan"
        Me.gridbilldetailschallan.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.gridbilldetailschallan.Size = New System.Drawing.Size(230, 229)
        Me.gridbilldetailschallan.TabIndex = 761
        Me.gridbilldetailschallan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbillchallan})
        '
        'gridbillchallan
        '
        Me.gridbillchallan.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbillchallan.Appearance.Row.Options.UseFont = True
        Me.gridbillchallan.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHALLANCHK, Me.GCHALLAN})
        Me.gridbillchallan.GridControl = Me.gridbilldetailschallan
        Me.gridbillchallan.Name = "gridbillchallan"
        Me.gridbillchallan.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbillchallan.OptionsView.ColumnAutoWidth = False
        Me.gridbillchallan.OptionsView.ShowAutoFilterRow = True
        Me.gridbillchallan.OptionsView.ShowGroupPanel = False
        '
        'GCHALLANCHK
        '
        Me.GCHALLANCHK.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.GCHALLANCHK.FieldName = "CHK"
        Me.GCHALLANCHK.Name = "GCHALLANCHK"
        Me.GCHALLANCHK.OptionsColumn.ShowCaption = False
        Me.GCHALLANCHK.Visible = True
        Me.GCHALLANCHK.VisibleIndex = 0
        Me.GCHALLANCHK.Width = 30
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GCHALLAN
        '
        Me.GCHALLAN.Caption = "Challan No"
        Me.GCHALLAN.FieldName = "CHALLANNO"
        Me.GCHALLAN.ImageIndex = 0
        Me.GCHALLAN.Name = "GCHALLAN"
        Me.GCHALLAN.OptionsColumn.AllowEdit = False
        Me.GCHALLAN.Visible = True
        Me.GCHALLAN.VisibleIndex = 1
        Me.GCHALLAN.Width = 150
        '
        'CHKPENDINGPROG
        '
        Me.CHKPENDINGPROG.AutoSize = True
        Me.CHKPENDINGPROG.BackColor = System.Drawing.Color.Transparent
        Me.CHKPENDINGPROG.ForeColor = System.Drawing.Color.Black
        Me.CHKPENDINGPROG.Location = New System.Drawing.Point(79, 267)
        Me.CHKPENDINGPROG.Name = "CHKPENDINGPROG"
        Me.CHKPENDINGPROG.Size = New System.Drawing.Size(182, 19)
        Me.CHKPENDINGPROG.TabIndex = 751
        Me.CHKPENDINGPROG.Text = "Show Lots with Pending Prog"
        Me.CHKPENDINGPROG.UseVisualStyleBackColor = False
        '
        'CHKGRIDDETAILS
        '
        Me.CHKGRIDDETAILS.AutoSize = True
        Me.CHKGRIDDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CHKGRIDDETAILS.ForeColor = System.Drawing.Color.Black
        Me.CHKGRIDDETAILS.Location = New System.Drawing.Point(63, 136)
        Me.CHKGRIDDETAILS.Name = "CHKGRIDDETAILS"
        Me.CHKGRIDDETAILS.Size = New System.Drawing.Size(92, 19)
        Me.CHKGRIDDETAILS.TabIndex = 746
        Me.CHKGRIDDETAILS.Text = "Grid Details"
        Me.CHKGRIDDETAILS.UseVisualStyleBackColor = False
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(376, 46)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(230, 22)
        Me.CMBCATEGORY.TabIndex = 744
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(321, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 14)
        Me.Label4.TabIndex = 745
        Me.Label4.Text = "Category"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(366, 74)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(230, 265)
        Me.gridbilldetails.TabIndex = 743
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GLOTNO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 50
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.ImageIndex = 0
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 1
        Me.GLOTNO.Width = 100
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(376, 18)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBITEMNAME.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(307, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 14)
        Me.Label3.TabIndex = 742
        Me.Label3.Text = "Item Name"
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Checked = True
        Me.CHKSUMMARY.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSUMMARY.ForeColor = System.Drawing.Color.Black
        Me.CHKSUMMARY.Location = New System.Drawing.Point(109, 413)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(77, 19)
        Me.CHKSUMMARY.TabIndex = 4
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        Me.CHKSUMMARY.Visible = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(63, 46)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(230, 22)
        Me.CMBQUALITY.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 439
        Me.Label2.Text = "Quality"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(98, 376)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 8
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
        Me.cmdexit.Location = New System.Drawing.Point(192, 376)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMBGROUP
        '
        Me.CMBGROUP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGROUP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGROUP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGROUP.FormattingEnabled = True
        Me.CMBGROUP.Location = New System.Drawing.Point(63, 74)
        Me.CMBGROUP.MaxDropDownItems = 14
        Me.CMBGROUP.Name = "CMBGROUP"
        Me.CMBGROUP.Size = New System.Drawing.Size(230, 22)
        Me.CMBGROUP.TabIndex = 764
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(21, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 765
        Me.Label5.Text = "Group"
        '
        'LotFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LotFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "LotFilter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GPITEMNAME.ResumeLayout(False)
        Me.GPITEMNAME.PerformLayout()
        CType(Me.GRIDITEMDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPPARTYNAME.ResumeLayout(False)
        Me.GPPARTYNAME.PerformLayout()
        CType(Me.gridpartydetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridparty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetailschallan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbillchallan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryadd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RDBCOMPLETE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBFULL As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBJOBBER As System.Windows.Forms.ComboBox
    Friend WithEvents cmbacccode As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CHKGRIDDETAILS As CheckBox
    Friend WithEvents CHKPENDINGPROG As CheckBox
    Friend WithEvents GPITEMNAME As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CHKSELECTITEM As CheckBox
    Private WithEvents GRIDITEMDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDITEM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPPARTYNAME As GroupBox
    Friend WithEvents CHKSELECTPARTY As CheckBox
    Private WithEvents gridpartydetails As DevExpress.XtraGrid.GridControl
    Private WithEvents Gridparty As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetailschallan As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbillchallan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHALLANCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GCHALLAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBGROUP As ComboBox
    Friend WithEvents Label5 As Label
End Class
