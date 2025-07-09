<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseInvoiceFilter
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
        Me.GPPARTYNAME = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAREA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKNARRATION = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.TXTAGENTCOMM = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBLABEL = New System.Windows.Forms.RadioButton()
        Me.RDBCOMMISSIONOPENING = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYENTRYWISE = New System.Windows.Forms.RadioButton()
        Me.RBITEMRATE = New System.Windows.Forms.RadioButton()
        Me.RDBPURCHASEENTRYWISE = New System.Windows.Forms.RadioButton()
        Me.RDBENTRYWISE = New System.Windows.Forms.RadioButton()
        Me.RDBCOMMISSION = New System.Windows.Forms.RadioButton()
        Me.RDBTRANS = New System.Windows.Forms.RadioButton()
        Me.RDBMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RDSHADE = New System.Windows.Forms.RadioButton()
        Me.RDQUALITY = New System.Windows.Forms.RadioButton()
        Me.RDBAGENT = New System.Windows.Forms.RadioButton()
        Me.RDITEM = New System.Windows.Forms.RadioButton()
        Me.RDBPARTY = New System.Windows.Forms.RadioButton()
        Me.CMBSIGN = New System.Windows.Forms.ComboBox()
        Me.CMBCHARGES = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTAMT = New System.Windows.Forms.TextBox()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbtrans = New System.Windows.Forms.ComboBox()
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBAGENT = New System.Windows.Forms.ComboBox()
        Me.cmbacccode = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RBENVELOPE = New System.Windows.Forms.RadioButton()
        Me.BlendPanel2.SuspendLayout()
        Me.GPPARTYNAME.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.GPPARTYNAME)
        Me.BlendPanel2.Controls.Add(Me.CHKNARRATION)
        Me.BlendPanel2.Controls.Add(Me.Label12)
        Me.BlendPanel2.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.TXTAGENTCOMM)
        Me.BlendPanel2.Controls.Add(Me.Label13)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.CMBSIGN)
        Me.BlendPanel2.Controls.Add(Me.CMBCHARGES)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.TXTAMT)
        Me.BlendPanel2.Controls.Add(Me.cmbregister)
        Me.BlendPanel2.Controls.Add(Me.Label37)
        Me.BlendPanel2.Controls.Add(Me.Label27)
        Me.BlendPanel2.Controls.Add(Me.cmbtrans)
        Me.BlendPanel2.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel2.Controls.Add(Me.Label10)
        Me.BlendPanel2.Controls.Add(Me.CMBAGENT)
        Me.BlendPanel2.Controls.Add(Me.cmbacccode)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.CMBNAME)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel2.TabIndex = 0
        '
        'GPPARTYNAME
        '
        Me.GPPARTYNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPPARTYNAME.Controls.Add(Me.CHKSELECTALL)
        Me.GPPARTYNAME.Controls.Add(Me.gridbilldetails)
        Me.GPPARTYNAME.Location = New System.Drawing.Point(671, 10)
        Me.GPPARTYNAME.Name = "GPPARTYNAME"
        Me.GPPARTYNAME.Size = New System.Drawing.Size(551, 548)
        Me.GPPARTYNAME.TabIndex = 760
        Me.GPPARTYNAME.TabStop = False
        Me.GPPARTYNAME.Text = "Party Name"
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(18, 22)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(72, 18)
        Me.CHKSELECTALL.TabIndex = 0
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(6, 43)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(539, 499)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME, Me.GGROUPNAME, Me.GCITYNAME, Me.GSTATENAME, Me.GAREA})
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
        Me.GCHK.Width = 35
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
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 2
        Me.GGROUPNAME.Width = 100
        '
        'GCITYNAME
        '
        Me.GCITYNAME.Caption = "City Name"
        Me.GCITYNAME.FieldName = "CITY"
        Me.GCITYNAME.Name = "GCITYNAME"
        Me.GCITYNAME.OptionsColumn.AllowEdit = False
        Me.GCITYNAME.Visible = True
        Me.GCITYNAME.VisibleIndex = 3
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.OptionsColumn.AllowEdit = False
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 4
        Me.GSTATENAME.Width = 80
        '
        'GAREA
        '
        Me.GAREA.Caption = "Area"
        Me.GAREA.FieldName = "AREA"
        Me.GAREA.Name = "GAREA"
        Me.GAREA.OptionsColumn.AllowEdit = False
        Me.GAREA.Visible = True
        Me.GAREA.VisibleIndex = 5
        Me.GAREA.Width = 100
        '
        'CHKNARRATION
        '
        Me.CHKNARRATION.AutoSize = True
        Me.CHKNARRATION.BackColor = System.Drawing.Color.Transparent
        Me.CHKNARRATION.Location = New System.Drawing.Point(242, 152)
        Me.CHKNARRATION.Name = "CHKNARRATION"
        Me.CHKNARRATION.Size = New System.Drawing.Size(77, 19)
        Me.CHKNARRATION.TabIndex = 759
        Me.CHKNARRATION.Text = "Narration"
        Me.CHKNARRATION.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(32, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 14)
        Me.Label12.TabIndex = 758
        Me.Label12.Text = "Category"
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.BackColor = System.Drawing.Color.White
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(88, 122)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(230, 22)
        Me.CMBCATEGORY.TabIndex = 4
        '
        'TXTAGENTCOMM
        '
        Me.TXTAGENTCOMM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAGENTCOMM.Location = New System.Drawing.Point(88, 150)
        Me.TXTAGENTCOMM.Name = "TXTAGENTCOMM"
        Me.TXTAGENTCOMM.Size = New System.Drawing.Size(71, 23)
        Me.TXTAGENTCOMM.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 756
        Me.Label13.Text = "Agent Comm"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBENVELOPE)
        Me.GroupBox3.Controls.Add(Me.RDBLABEL)
        Me.GroupBox3.Controls.Add(Me.RDBCOMMISSIONOPENING)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYENTRYWISE)
        Me.GroupBox3.Controls.Add(Me.RBITEMRATE)
        Me.GroupBox3.Controls.Add(Me.RDBPURCHASEENTRYWISE)
        Me.GroupBox3.Controls.Add(Me.RDBENTRYWISE)
        Me.GroupBox3.Controls.Add(Me.RDBCOMMISSION)
        Me.GroupBox3.Controls.Add(Me.RDBTRANS)
        Me.GroupBox3.Controls.Add(Me.RDBMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDSHADE)
        Me.GroupBox3.Controls.Add(Me.RDQUALITY)
        Me.GroupBox3.Controls.Add(Me.RDBAGENT)
        Me.GroupBox3.Controls.Add(Me.RDITEM)
        Me.GroupBox3.Controls.Add(Me.RDBPARTY)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(140, 224)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(425, 164)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'RDBLABEL
        '
        Me.RDBLABEL.AutoSize = True
        Me.RDBLABEL.Location = New System.Drawing.Point(300, 116)
        Me.RDBLABEL.Name = "RDBLABEL"
        Me.RDBLABEL.Size = New System.Drawing.Size(77, 18)
        Me.RDBLABEL.TabIndex = 14
        Me.RDBLABEL.Text = "Label Print"
        Me.RDBLABEL.UseVisualStyleBackColor = True
        '
        'RDBCOMMISSIONOPENING
        '
        Me.RDBCOMMISSIONOPENING.AutoSize = True
        Me.RDBCOMMISSIONOPENING.Location = New System.Drawing.Point(26, 92)
        Me.RDBCOMMISSIONOPENING.Name = "RDBCOMMISSIONOPENING"
        Me.RDBCOMMISSIONOPENING.Size = New System.Drawing.Size(114, 18)
        Me.RDBCOMMISSIONOPENING.TabIndex = 12
        Me.RDBCOMMISSIONOPENING.Text = "Agent Comm (Op)"
        Me.RDBCOMMISSIONOPENING.UseVisualStyleBackColor = True
        '
        'RDBPARTYENTRYWISE
        '
        Me.RDBPARTYENTRYWISE.AutoSize = True
        Me.RDBPARTYENTRYWISE.Location = New System.Drawing.Point(300, 92)
        Me.RDBPARTYENTRYWISE.Name = "RDBPARTYENTRYWISE"
        Me.RDBPARTYENTRYWISE.Size = New System.Drawing.Size(106, 18)
        Me.RDBPARTYENTRYWISE.TabIndex = 11
        Me.RDBPARTYENTRYWISE.Text = "Party Entry Wise"
        Me.RDBPARTYENTRYWISE.UseVisualStyleBackColor = True
        '
        'RBITEMRATE
        '
        Me.RBITEMRATE.AutoSize = True
        Me.RBITEMRATE.Location = New System.Drawing.Point(26, 116)
        Me.RBITEMRATE.Name = "RBITEMRATE"
        Me.RBITEMRATE.Size = New System.Drawing.Size(97, 18)
        Me.RBITEMRATE.TabIndex = 10
        Me.RBITEMRATE.Text = "Item Last Rate"
        Me.RBITEMRATE.UseVisualStyleBackColor = True
        '
        'RDBPURCHASEENTRYWISE
        '
        Me.RDBPURCHASEENTRYWISE.AutoSize = True
        Me.RDBPURCHASEENTRYWISE.Location = New System.Drawing.Point(166, 92)
        Me.RDBPURCHASEENTRYWISE.Name = "RDBPURCHASEENTRYWISE"
        Me.RDBPURCHASEENTRYWISE.Size = New System.Drawing.Size(101, 18)
        Me.RDBPURCHASEENTRYWISE.TabIndex = 9
        Me.RDBPURCHASEENTRYWISE.Text = "Purchase Detail"
        Me.RDBPURCHASEENTRYWISE.UseVisualStyleBackColor = True
        '
        'RDBENTRYWISE
        '
        Me.RDBENTRYWISE.AutoSize = True
        Me.RDBENTRYWISE.Location = New System.Drawing.Point(300, 68)
        Me.RDBENTRYWISE.Name = "RDBENTRYWISE"
        Me.RDBENTRYWISE.Size = New System.Drawing.Size(78, 18)
        Me.RDBENTRYWISE.TabIndex = 8
        Me.RDBENTRYWISE.Text = "Entry Wise"
        Me.RDBENTRYWISE.UseVisualStyleBackColor = True
        '
        'RDBCOMMISSION
        '
        Me.RDBCOMMISSION.AutoSize = True
        Me.RDBCOMMISSION.Location = New System.Drawing.Point(26, 68)
        Me.RDBCOMMISSION.Name = "RDBCOMMISSION"
        Me.RDBCOMMISSION.Size = New System.Drawing.Size(89, 18)
        Me.RDBCOMMISSION.TabIndex = 2
        Me.RDBCOMMISSION.Text = "Agent Comm"
        Me.RDBCOMMISSION.UseVisualStyleBackColor = True
        '
        'RDBTRANS
        '
        Me.RDBTRANS.AutoSize = True
        Me.RDBTRANS.Location = New System.Drawing.Point(300, 20)
        Me.RDBTRANS.Name = "RDBTRANS"
        Me.RDBTRANS.Size = New System.Drawing.Size(99, 18)
        Me.RDBTRANS.TabIndex = 6
        Me.RDBTRANS.Text = "Transport Wise"
        Me.RDBTRANS.UseVisualStyleBackColor = True
        '
        'RDBMONTHLY
        '
        Me.RDBMONTHLY.AutoSize = True
        Me.RDBMONTHLY.Location = New System.Drawing.Point(166, 68)
        Me.RDBMONTHLY.Name = "RDBMONTHLY"
        Me.RDBMONTHLY.Size = New System.Drawing.Size(65, 18)
        Me.RDBMONTHLY.TabIndex = 5
        Me.RDBMONTHLY.Text = "Monthly"
        Me.RDBMONTHLY.UseVisualStyleBackColor = True
        '
        'RDSHADE
        '
        Me.RDSHADE.AutoSize = True
        Me.RDSHADE.Location = New System.Drawing.Point(166, 44)
        Me.RDSHADE.Name = "RDSHADE"
        Me.RDSHADE.Size = New System.Drawing.Size(83, 18)
        Me.RDSHADE.TabIndex = 4
        Me.RDSHADE.Text = "Shade Wise"
        Me.RDSHADE.UseVisualStyleBackColor = True
        '
        'RDQUALITY
        '
        Me.RDQUALITY.AutoSize = True
        Me.RDQUALITY.Location = New System.Drawing.Point(166, 20)
        Me.RDQUALITY.Name = "RDQUALITY"
        Me.RDQUALITY.Size = New System.Drawing.Size(88, 18)
        Me.RDQUALITY.TabIndex = 3
        Me.RDQUALITY.Text = "Quality Wise"
        Me.RDQUALITY.UseVisualStyleBackColor = True
        '
        'RDBAGENT
        '
        Me.RDBAGENT.AutoSize = True
        Me.RDBAGENT.Location = New System.Drawing.Point(26, 44)
        Me.RDBAGENT.Name = "RDBAGENT"
        Me.RDBAGENT.Size = New System.Drawing.Size(82, 18)
        Me.RDBAGENT.TabIndex = 1
        Me.RDBAGENT.Text = "Agent Wise"
        Me.RDBAGENT.UseVisualStyleBackColor = True
        '
        'RDITEM
        '
        Me.RDITEM.AutoSize = True
        Me.RDITEM.Location = New System.Drawing.Point(300, 44)
        Me.RDITEM.Name = "RDITEM"
        Me.RDITEM.Size = New System.Drawing.Size(76, 18)
        Me.RDITEM.TabIndex = 7
        Me.RDITEM.Text = "Item Wise"
        Me.RDITEM.UseVisualStyleBackColor = True
        '
        'RDBPARTY
        '
        Me.RDBPARTY.AutoSize = True
        Me.RDBPARTY.Checked = True
        Me.RDBPARTY.Location = New System.Drawing.Point(26, 20)
        Me.RDBPARTY.Name = "RDBPARTY"
        Me.RDBPARTY.Size = New System.Drawing.Size(78, 18)
        Me.RDBPARTY.TabIndex = 0
        Me.RDBPARTY.TabStop = True
        Me.RDBPARTY.Text = "Party Wise"
        Me.RDBPARTY.UseVisualStyleBackColor = True
        '
        'CMBSIGN
        '
        Me.CMBSIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSIGN.FormattingEnabled = True
        Me.CMBSIGN.Items.AddRange(New Object() {"", "=", "<", ">"})
        Me.CMBSIGN.Location = New System.Drawing.Point(501, 122)
        Me.CMBSIGN.MaxDropDownItems = 14
        Me.CMBSIGN.Name = "CMBSIGN"
        Me.CMBSIGN.Size = New System.Drawing.Size(64, 23)
        Me.CMBSIGN.TabIndex = 11
        '
        'CMBCHARGES
        '
        Me.CMBCHARGES.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCHARGES.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCHARGES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCHARGES.FormattingEnabled = True
        Me.CMBCHARGES.Location = New System.Drawing.Point(424, 94)
        Me.CMBCHARGES.MaxDropDownItems = 14
        Me.CMBCHARGES.Name = "CMBCHARGES"
        Me.CMBCHARGES.Size = New System.Drawing.Size(230, 22)
        Me.CMBCHARGES.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(391, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Amt."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(336, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 14)
        Me.Label3.TabIndex = 747
        Me.Label3.Text = "Charges Name"
        '
        'TXTAMT
        '
        Me.TXTAMT.Location = New System.Drawing.Point(424, 122)
        Me.TXTAMT.Name = "TXTAMT"
        Me.TXTAMT.Size = New System.Drawing.Size(71, 23)
        Me.TXTAMT.TabIndex = 10
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.BackColor = System.Drawing.Color.White
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(424, 66)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(230, 23)
        Me.cmbregister.TabIndex = 8
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(370, 70)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(49, 15)
        Me.Label37.TabIndex = 745
        Me.Label37.Text = "Register"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(361, 42)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 15)
        Me.Label27.TabIndex = 743
        Me.Label27.Text = "Transport"
        '
        'cmbtrans
        '
        Me.cmbtrans.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtrans.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtrans.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtrans.FormattingEnabled = True
        Me.cmbtrans.Location = New System.Drawing.Point(424, 38)
        Me.cmbtrans.MaxDropDownItems = 14
        Me.cmbtrans.Name = "cmbtrans"
        Me.cmbtrans.Size = New System.Drawing.Size(230, 23)
        Me.cmbtrans.TabIndex = 7
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Location = New System.Drawing.Point(159, 208)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(76, 19)
        Me.CHKSUMMARY.TabIndex = 12
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(88, 66)
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
        Me.Label5.Location = New System.Drawing.Point(19, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 740
        Me.Label5.Text = "Item Name"
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(61, 530)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 738
        Me.CMBCODE.Visible = False
        '
        'txtDeliveryadd
        '
        Me.txtDeliveryadd.BackColor = System.Drawing.Color.White
        Me.txtDeliveryadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDeliveryadd.Enabled = False
        Me.txtDeliveryadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryadd.Location = New System.Drawing.Point(58, 530)
        Me.txtDeliveryadd.Name = "txtDeliveryadd"
        Me.txtDeliveryadd.ReadOnly = True
        Me.txtDeliveryadd.Size = New System.Drawing.Size(34, 22)
        Me.txtDeliveryadd.TabIndex = 737
        Me.txtDeliveryadd.TabStop = False
        Me.txtDeliveryadd.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(48, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 652
        Me.Label10.Text = "Agent"
        '
        'CMBAGENT
        '
        Me.CMBAGENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENT.BackColor = System.Drawing.Color.White
        Me.CMBAGENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENT.FormattingEnabled = True
        Me.CMBAGENT.Location = New System.Drawing.Point(88, 38)
        Me.CMBAGENT.MaxDropDownItems = 14
        Me.CMBAGENT.Name = "CMBAGENT"
        Me.CMBAGENT.Size = New System.Drawing.Size(230, 22)
        Me.CMBAGENT.TabIndex = 1
        '
        'cmbacccode
        '
        Me.cmbacccode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbacccode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbacccode.BackColor = System.Drawing.Color.White
        Me.cmbacccode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbacccode.FormattingEnabled = True
        Me.cmbacccode.Location = New System.Drawing.Point(60, 530)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(60, 531)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(30, 23)
        Me.txtadd.TabIndex = 649
        Me.txtadd.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(380, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 648
        Me.Label4.Text = "Shade"
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.BackColor = System.Drawing.Color.White
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(424, 10)
        Me.CMBSHADE.MaxDropDownItems = 14
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(230, 22)
        Me.CMBSHADE.TabIndex = 6
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(57, 533)
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
        Me.chkdate.Location = New System.Drawing.Point(61, 451)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 14
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
        Me.GroupBox1.Location = New System.Drawing.Point(53, 465)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 15
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
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
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(88, 94)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(230, 22)
        Me.CMBQUALITY.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 439
        Me.Label2.Text = "Quality"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(88, 10)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBNAME.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(47, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 14)
        Me.Label9.TabIndex = 419
        Me.Label9.Text = "Name"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(358, 483)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 16
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
        Me.cmdexit.Location = New System.Drawing.Point(452, 483)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 17
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBENVELOPE
        '
        Me.RBENVELOPE.AutoSize = True
        Me.RBENVELOPE.Location = New System.Drawing.Point(300, 140)
        Me.RBENVELOPE.Name = "RBENVELOPE"
        Me.RBENVELOPE.Size = New System.Drawing.Size(110, 18)
        Me.RBENVELOPE.TabIndex = 15
        Me.RBENVELOPE.Text = "Envelope Printing"
        Me.RBENVELOPE.UseVisualStyleBackColor = True
        '
        'PurchaseInvoiceFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PurchaseInvoiceFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PurchaseInvoiceFilter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GPPARTYNAME.ResumeLayout(False)
        Me.GPPARTYNAME.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtDeliveryadd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CMBSIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTAMT As System.Windows.Forms.TextBox
    Friend WithEvents RDBTRANS As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDSHADE As System.Windows.Forms.RadioButton
    Friend WithEvents RDQUALITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBAGENT As System.Windows.Forms.RadioButton
    Friend WithEvents RDITEM As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTY As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBAGENT As System.Windows.Forms.ComboBox
    Friend WithEvents cmbacccode As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmbtrans As System.Windows.Forms.ComboBox
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents RDBCOMMISSION As System.Windows.Forms.RadioButton
    Friend WithEvents CMBCHARGES As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RDBENTRYWISE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPURCHASEENTRYWISE As System.Windows.Forms.RadioButton
    Friend WithEvents RBITEMRATE As RadioButton
    Friend WithEvents TXTAGENTCOMM As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents RDBPARTYENTRYWISE As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents CMBCATEGORY As ComboBox
    Friend WithEvents CHKNARRATION As CheckBox
    Friend WithEvents GPPARTYNAME As GroupBox
    Friend WithEvents CHKSELECTALL As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAREA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RDBCOMMISSIONOPENING As RadioButton
    Friend WithEvents RDBLABEL As RadioButton
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBENVELOPE As RadioButton
End Class
