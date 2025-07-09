<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFilter
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
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.CMBBROKER = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CHKGROUPONNEWPG = New System.Windows.Forms.CheckBox
        Me.RECDTO = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.RECDFROM = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.CHKRECDDATE = New System.Windows.Forms.CheckBox
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox
        Me.GPREPORTS = New System.Windows.Forms.GroupBox
        Me.RBLETTERALL = New System.Windows.Forms.RadioButton
        Me.RBDETAILSRECEIVED = New System.Windows.Forms.RadioButton
        Me.RBDETAILSPENDING = New System.Windows.Forms.RadioButton
        Me.RBLETTER = New System.Windows.Forms.RadioButton
        Me.RBBROKERALL = New System.Windows.Forms.RadioButton
        Me.RBBROKERRECD = New System.Windows.Forms.RadioButton
        Me.RBBROKERPENDING = New System.Windows.Forms.RadioButton
        Me.RBPENDING = New System.Windows.Forms.RadioButton
        Me.RBALL = New System.Windows.Forms.RadioButton
        Me.RBRECEIVED = New System.Windows.Forms.RadioButton
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNDER = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.RBSELECTED = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.RBGROUP = New System.Windows.Forms.RadioButton
        Me.RBACCOUNT = New System.Windows.Forms.RadioButton
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.RBPAYABLE = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.RBREC = New System.Windows.Forms.RadioButton
        Me.CHKEXCEL = New System.Windows.Forms.CheckBox
        Me.CMBFORM = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.GPREPORTS.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBBROKER)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CHKGROUPONNEWPG)
        Me.BlendPanel1.Controls.Add(Me.RECDTO)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.RECDFROM)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.CHKRECDDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel1.Controls.Add(Me.GPREPORTS)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox4)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.RBPAYABLE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.RBREC)
        Me.BlendPanel1.Controls.Add(Me.CHKEXCEL)
        Me.BlendPanel1.Controls.Add(Me.CMBFORM)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.cmdShowReport)
        Me.BlendPanel1.Controls.Add(Me.cmdExit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(957, 513)
        Me.BlendPanel1.TabIndex = 9
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(802, 45)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(63, 23)
        Me.TXTADD.TabIndex = 729
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(802, 18)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(63, 22)
        Me.CMBCODE.TabIndex = 728
        Me.CMBCODE.Visible = False
        '
        'CMBBROKER
        '
        Me.CMBBROKER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBROKER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBROKER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBROKER.FormattingEnabled = True
        Me.CMBBROKER.Location = New System.Drawing.Point(116, 22)
        Me.CMBBROKER.MaxDropDownItems = 14
        Me.CMBBROKER.Name = "CMBBROKER"
        Me.CMBBROKER.Size = New System.Drawing.Size(184, 22)
        Me.CMBBROKER.TabIndex = 726
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 727
        Me.Label4.Text = "Broker Name"
        '
        'CHKGROUPONNEWPG
        '
        Me.CHKGROUPONNEWPG.AutoSize = True
        Me.CHKGROUPONNEWPG.BackColor = System.Drawing.Color.Transparent
        Me.CHKGROUPONNEWPG.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGROUPONNEWPG.ForeColor = System.Drawing.Color.Black
        Me.CHKGROUPONNEWPG.Location = New System.Drawing.Point(733, 135)
        Me.CHKGROUPONNEWPG.Name = "CHKGROUPONNEWPG"
        Me.CHKGROUPONNEWPG.Size = New System.Drawing.Size(193, 18)
        Me.CHKGROUPONNEWPG.TabIndex = 725
        Me.CHKGROUPONNEWPG.Text = "Show Each Group On New Page"
        Me.CHKGROUPONNEWPG.UseVisualStyleBackColor = False
        '
        'RECDTO
        '
        Me.RECDTO.CustomFormat = "dd/MM/yyyy"
        Me.RECDTO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.RECDTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RECDTO.Location = New System.Drawing.Point(659, 50)
        Me.RECDTO.Name = "RECDTO"
        Me.RECDTO.Size = New System.Drawing.Size(92, 22)
        Me.RECDTO.TabIndex = 721
        Me.RECDTO.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(636, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 14)
        Me.Label2.TabIndex = 724
        Me.Label2.Text = "To"
        Me.Label2.Visible = False
        '
        'RECDFROM
        '
        Me.RECDFROM.CustomFormat = "dd/MM/yyyy"
        Me.RECDFROM.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.RECDFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.RECDFROM.Location = New System.Drawing.Point(659, 22)
        Me.RECDFROM.Name = "RECDFROM"
        Me.RECDFROM.Size = New System.Drawing.Size(92, 22)
        Me.RECDFROM.TabIndex = 720
        Me.RECDFROM.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(622, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 723
        Me.Label3.Text = "From"
        Me.Label3.Visible = False
        '
        'CHKRECDDATE
        '
        Me.CHKRECDDATE.AutoSize = True
        Me.CHKRECDDATE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECDDATE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKRECDDATE.Location = New System.Drawing.Point(547, 24)
        Me.CHKRECDDATE.Name = "CHKRECDDATE"
        Me.CHKRECDDATE.Size = New System.Drawing.Size(74, 18)
        Me.CHKRECDDATE.TabIndex = 722
        Me.CHKRECDDATE.Text = "Rec Date"
        Me.CHKRECDDATE.UseVisualStyleBackColor = False
        Me.CHKRECDDATE.Visible = False
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSUMMARY.ForeColor = System.Drawing.Color.Black
        Me.CHKSUMMARY.Location = New System.Drawing.Point(733, 111)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(75, 18)
        Me.CHKSUMMARY.TabIndex = 719
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        '
        'GPREPORTS
        '
        Me.GPREPORTS.BackColor = System.Drawing.Color.Transparent
        Me.GPREPORTS.Controls.Add(Me.RBLETTERALL)
        Me.GPREPORTS.Controls.Add(Me.RBDETAILSRECEIVED)
        Me.GPREPORTS.Controls.Add(Me.RBDETAILSPENDING)
        Me.GPREPORTS.Controls.Add(Me.RBLETTER)
        Me.GPREPORTS.Controls.Add(Me.RBBROKERALL)
        Me.GPREPORTS.Controls.Add(Me.RBBROKERRECD)
        Me.GPREPORTS.Controls.Add(Me.RBBROKERPENDING)
        Me.GPREPORTS.Controls.Add(Me.RBPENDING)
        Me.GPREPORTS.Controls.Add(Me.RBALL)
        Me.GPREPORTS.Controls.Add(Me.RBRECEIVED)
        Me.GPREPORTS.Location = New System.Drawing.Point(733, 150)
        Me.GPREPORTS.Name = "GPREPORTS"
        Me.GPREPORTS.Size = New System.Drawing.Size(202, 263)
        Me.GPREPORTS.TabIndex = 2
        Me.GPREPORTS.TabStop = False
        '
        'RBLETTERALL
        '
        Me.RBLETTERALL.AutoSize = True
        Me.RBLETTERALL.BackColor = System.Drawing.Color.Transparent
        Me.RBLETTERALL.Location = New System.Drawing.Point(16, 236)
        Me.RBLETTERALL.Name = "RBLETTERALL"
        Me.RBLETTERALL.Size = New System.Drawing.Size(123, 19)
        Me.RBLETTERALL.TabIndex = 729
        Me.RBLETTERALL.Text = "Letter Format (All)"
        Me.RBLETTERALL.UseVisualStyleBackColor = False
        '
        'RBDETAILSRECEIVED
        '
        Me.RBDETAILSRECEIVED.AutoSize = True
        Me.RBDETAILSRECEIVED.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILSRECEIVED.Location = New System.Drawing.Point(16, 44)
        Me.RBDETAILSRECEIVED.Name = "RBDETAILSRECEIVED"
        Me.RBDETAILSRECEIVED.Size = New System.Drawing.Size(105, 19)
        Me.RBDETAILSRECEIVED.TabIndex = 727
        Me.RBDETAILSRECEIVED.Text = "All &Bills (Recd)"
        Me.RBDETAILSRECEIVED.UseVisualStyleBackColor = False
        '
        'RBDETAILSPENDING
        '
        Me.RBDETAILSPENDING.AutoSize = True
        Me.RBDETAILSPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILSPENDING.Checked = True
        Me.RBDETAILSPENDING.Location = New System.Drawing.Point(16, 20)
        Me.RBDETAILSPENDING.Name = "RBDETAILSPENDING"
        Me.RBDETAILSPENDING.Size = New System.Drawing.Size(123, 19)
        Me.RBDETAILSPENDING.TabIndex = 726
        Me.RBDETAILSPENDING.TabStop = True
        Me.RBDETAILSPENDING.Text = "All &Bills (Pending)"
        Me.RBDETAILSPENDING.UseVisualStyleBackColor = False
        '
        'RBLETTER
        '
        Me.RBLETTER.AutoSize = True
        Me.RBLETTER.BackColor = System.Drawing.Color.Transparent
        Me.RBLETTER.Location = New System.Drawing.Point(16, 212)
        Me.RBLETTER.Name = "RBLETTER"
        Me.RBLETTER.Size = New System.Drawing.Size(152, 19)
        Me.RBLETTER.TabIndex = 725
        Me.RBLETTER.Text = "Letter Format (Pending)"
        Me.RBLETTER.UseVisualStyleBackColor = False
        '
        'RBBROKERALL
        '
        Me.RBBROKERALL.AutoSize = True
        Me.RBBROKERALL.BackColor = System.Drawing.Color.Transparent
        Me.RBBROKERALL.Location = New System.Drawing.Point(16, 188)
        Me.RBBROKERALL.Name = "RBBROKERALL"
        Me.RBBROKERALL.Size = New System.Drawing.Size(116, 19)
        Me.RBBROKERALL.TabIndex = 724
        Me.RBBROKERALL.Text = "&Broker All Forms"
        Me.RBBROKERALL.UseVisualStyleBackColor = False
        '
        'RBBROKERRECD
        '
        Me.RBBROKERRECD.AutoSize = True
        Me.RBBROKERRECD.BackColor = System.Drawing.Color.Transparent
        Me.RBBROKERRECD.Location = New System.Drawing.Point(16, 164)
        Me.RBBROKERRECD.Name = "RBBROKERRECD"
        Me.RBBROKERRECD.Size = New System.Drawing.Size(127, 19)
        Me.RBBROKERRECD.TabIndex = 723
        Me.RBBROKERRECD.Text = "&Broker Recd Forms"
        Me.RBBROKERRECD.UseVisualStyleBackColor = False
        '
        'RBBROKERPENDING
        '
        Me.RBBROKERPENDING.AutoSize = True
        Me.RBBROKERPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBBROKERPENDING.Location = New System.Drawing.Point(16, 140)
        Me.RBBROKERPENDING.Name = "RBBROKERPENDING"
        Me.RBBROKERPENDING.Size = New System.Drawing.Size(145, 19)
        Me.RBBROKERPENDING.TabIndex = 722
        Me.RBBROKERPENDING.Text = "&Broker Pending Forms"
        Me.RBBROKERPENDING.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Location = New System.Drawing.Point(16, 68)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(176, 19)
        Me.RBPENDING.TabIndex = 720
        Me.RBPENDING.Text = "&Pending Forms - Party Wise"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.BackColor = System.Drawing.Color.Transparent
        Me.RBALL.Location = New System.Drawing.Point(16, 116)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(77, 19)
        Me.RBALL.TabIndex = 719
        Me.RBALL.Text = "A&ll Forms"
        Me.RBALL.UseVisualStyleBackColor = False
        '
        'RBRECEIVED
        '
        Me.RBRECEIVED.AutoSize = True
        Me.RBRECEIVED.BackColor = System.Drawing.Color.Transparent
        Me.RBRECEIVED.Location = New System.Drawing.Point(16, 92)
        Me.RBRECEIVED.Name = "RBRECEIVED"
        Me.RBRECEIVED.Size = New System.Drawing.Size(180, 19)
        Me.RBRECEIVED.TabIndex = 721
        Me.RBRECEIVED.Text = "&Received Forms - Party Wise"
        Me.RBRECEIVED.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(434, 50)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(92, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(405, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CHKSELECTALL)
        Me.GroupBox4.Controls.Add(Me.gridbilldetails)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 107)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(692, 359)
        Me.GroupBox4.TabIndex = 718
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selection"
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(18, 22)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 2
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(18, 43)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(656, 310)
        Me.gridbilldetails.TabIndex = 3
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME, Me.GUNDER, Me.GCITY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
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
        'GUNDER
        '
        Me.GUNDER.Caption = "Under"
        Me.GUNDER.FieldName = "UNDER"
        Me.GUNDER.Name = "GUNDER"
        Me.GUNDER.OptionsColumn.AllowEdit = False
        Me.GUNDER.Visible = True
        Me.GUNDER.VisibleIndex = 2
        Me.GUNDER.Width = 180
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.OptionsColumn.AllowEdit = False
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 3
        Me.GCITY.Width = 150
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.RBSELECTED)
        Me.GroupBox5.Controls.Add(Me.RadioButton1)
        Me.GroupBox5.Location = New System.Drawing.Point(350, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(157, 38)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'RBSELECTED
        '
        Me.RBSELECTED.AutoSize = True
        Me.RBSELECTED.BackColor = System.Drawing.Color.Transparent
        Me.RBSELECTED.Location = New System.Drawing.Point(66, 14)
        Me.RBSELECTED.Name = "RBSELECTED"
        Me.RBSELECTED.Size = New System.Drawing.Size(70, 19)
        Me.RBSELECTED.TabIndex = 1
        Me.RBSELECTED.Text = "Selected"
        Me.RBSELECTED.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(40, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "All"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.RBGROUP)
        Me.GroupBox6.Controls.Add(Me.RBACCOUNT)
        Me.GroupBox6.Location = New System.Drawing.Point(186, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(157, 38)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'RBGROUP
        '
        Me.RBGROUP.AutoSize = True
        Me.RBGROUP.BackColor = System.Drawing.Color.Transparent
        Me.RBGROUP.Location = New System.Drawing.Point(88, 14)
        Me.RBGROUP.Name = "RBGROUP"
        Me.RBGROUP.Size = New System.Drawing.Size(59, 19)
        Me.RBGROUP.TabIndex = 1
        Me.RBGROUP.Text = "Group"
        Me.RBGROUP.UseVisualStyleBackColor = False
        '
        'RBACCOUNT
        '
        Me.RBACCOUNT.AutoSize = True
        Me.RBACCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.RBACCOUNT.Checked = True
        Me.RBACCOUNT.Location = New System.Drawing.Point(6, 14)
        Me.RBACCOUNT.Name = "RBACCOUNT"
        Me.RBACCOUNT.Size = New System.Drawing.Size(69, 19)
        Me.RBACCOUNT.TabIndex = 0
        Me.RBACCOUNT.TabStop = True
        Me.RBACCOUNT.Text = "Account"
        Me.RBACCOUNT.UseVisualStyleBackColor = False
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(434, 22)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(92, 22)
        Me.dtfrom.TabIndex = 0
        '
        'RBPAYABLE
        '
        Me.RBPAYABLE.AutoSize = True
        Me.RBPAYABLE.BackColor = System.Drawing.Color.Transparent
        Me.RBPAYABLE.Checked = True
        Me.RBPAYABLE.Location = New System.Drawing.Point(369, 86)
        Me.RBPAYABLE.Name = "RBPAYABLE"
        Me.RBPAYABLE.Size = New System.Drawing.Size(75, 19)
        Me.RBPAYABLE.TabIndex = 717
        Me.RBPAYABLE.TabStop = True
        Me.RBPAYABLE.Text = "Payables"
        Me.RBPAYABLE.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(390, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "From :"
        '
        'RBREC
        '
        Me.RBREC.AutoSize = True
        Me.RBREC.BackColor = System.Drawing.Color.Transparent
        Me.RBREC.Location = New System.Drawing.Point(275, 86)
        Me.RBREC.Name = "RBREC"
        Me.RBREC.Size = New System.Drawing.Size(90, 19)
        Me.RBREC.TabIndex = 716
        Me.RBREC.Text = "Receivables"
        Me.RBREC.UseVisualStyleBackColor = False
        Me.RBREC.Visible = False
        '
        'CHKEXCEL
        '
        Me.CHKEXCEL.AutoSize = True
        Me.CHKEXCEL.BackColor = System.Drawing.Color.Transparent
        Me.CHKEXCEL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKEXCEL.Location = New System.Drawing.Point(732, 87)
        Me.CHKEXCEL.Name = "CHKEXCEL"
        Me.CHKEXCEL.Size = New System.Drawing.Size(94, 18)
        Me.CHKEXCEL.TabIndex = 715
        Me.CHKEXCEL.Text = "Excel Format"
        Me.CHKEXCEL.UseVisualStyleBackColor = False
        Me.CHKEXCEL.Visible = False
        '
        'CMBFORM
        '
        Me.CMBFORM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFORM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFORM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFORM.FormattingEnabled = True
        Me.CMBFORM.Location = New System.Drawing.Point(116, 50)
        Me.CMBFORM.MaxDropDownItems = 14
        Me.CMBFORM.Name = "CMBFORM"
        Me.CMBFORM.Size = New System.Drawing.Size(84, 22)
        Me.CMBFORM.TabIndex = 713
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(59, 54)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 14)
        Me.Label16.TabIndex = 714
        Me.Label16.Text = "Form No."
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(335, 24)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 2
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdShowReport.FlatAppearance.BorderSize = 0
        Me.cmdShowReport.Location = New System.Drawing.Point(392, 472)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(86, 28)
        Me.cmdShowReport.TabIndex = 3
        Me.cmdShowReport.Text = "&Show Details"
        Me.cmdShowReport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.Location = New System.Drawing.Point(484, 472)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 28)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'FormFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(957, 513)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FormFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPREPORTS.ResumeLayout(False)
        Me.GPREPORTS.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBFORM As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CHKEXCEL As System.Windows.Forms.CheckBox
    Friend WithEvents RBPAYABLE As System.Windows.Forms.RadioButton
    Friend WithEvents RBREC As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CHKSELECTALL As System.Windows.Forms.CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RBSELECTED As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGROUP As System.Windows.Forms.RadioButton
    Friend WithEvents RBACCOUNT As System.Windows.Forms.RadioButton
    Friend WithEvents RBRECEIVED As System.Windows.Forms.RadioButton
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents GPREPORTS As System.Windows.Forms.GroupBox
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents RECDTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RECDFROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CHKRECDDATE As System.Windows.Forms.CheckBox
    Friend WithEvents RBBROKERPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBBROKERALL As System.Windows.Forms.RadioButton
    Friend WithEvents RBBROKERRECD As System.Windows.Forms.RadioButton
    Friend WithEvents RBLETTER As System.Windows.Forms.RadioButton
    Friend WithEvents CHKGROUPONNEWPG As System.Windows.Forms.CheckBox
    Friend WithEvents CMBBROKER As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents RBDETAILSPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBDETAILSRECEIVED As System.Windows.Forms.RadioButton
    Friend WithEvents RBLETTERALL As System.Windows.Forms.RadioButton
End Class
