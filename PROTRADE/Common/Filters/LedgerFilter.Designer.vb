<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LedgerFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LedgerFilter))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBGROUPOFCOMPANIES = New System.Windows.Forms.ComboBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.CHKREMARKS = New System.Windows.Forms.CheckBox()
        Me.CHKPANNO = New System.Windows.Forms.CheckBox()
        Me.CMBSIGN = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTAMT = New System.Windows.Forms.TextBox()
        Me.CHKHEADER = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RBPARTYMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RBPARTYSUMM = New System.Windows.Forms.RadioButton()
        Me.RBCONFIRMATIONSUMM = New System.Windows.Forms.RadioButton()
        Me.RBPARTYSTATEMENTDTLS = New System.Windows.Forms.RadioButton()
        Me.RBCONFIRMATION = New System.Windows.Forms.RadioButton()
        Me.RBPARTYSTATEMENT = New System.Windows.Forms.RadioButton()
        Me.RBSUMMARY = New System.Windows.Forms.RadioButton()
        Me.RBDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBTFORMAT = New System.Windows.Forms.RadioButton()
        Me.CHKINDEX = New System.Windows.Forms.CheckBox()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RBSELECTED = New System.Windows.Forms.RadioButton()
        Me.RBALL = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBGROUP = New System.Windows.Forms.RadioButton()
        Me.RBACCOUNT = New System.Windows.Forms.RadioButton()
        Me.CMBGROUP = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CHKGROUPONNEWPG = New System.Windows.Forms.CheckBox()
        Me.CHKADDRESS = New System.Windows.Forms.CheckBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lbldrcrclosing = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblname = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBGROUPOFCOMPANIES)
        Me.BlendPanel1.Controls.Add(Me.Label47)
        Me.BlendPanel1.Controls.Add(Me.CHKREMARKS)
        Me.BlendPanel1.Controls.Add(Me.CHKPANNO)
        Me.BlendPanel1.Controls.Add(Me.CMBSIGN)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTAMT)
        Me.BlendPanel1.Controls.Add(Me.CHKHEADER)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.CHKINDEX)
        Me.BlendPanel1.Controls.Add(Me.cmdshow)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.CMBGROUP)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CHKGROUPONNEWPG)
        Me.BlendPanel1.Controls.Add(Me.CHKADDRESS)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbldrcrclosing)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1086, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBGROUPOFCOMPANIES
        '
        Me.CMBGROUPOFCOMPANIES.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGROUPOFCOMPANIES.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGROUPOFCOMPANIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGROUPOFCOMPANIES.FormattingEnabled = True
        Me.CMBGROUPOFCOMPANIES.Location = New System.Drawing.Point(155, 124)
        Me.CMBGROUPOFCOMPANIES.MaxDropDownItems = 14
        Me.CMBGROUPOFCOMPANIES.Name = "CMBGROUPOFCOMPANIES"
        Me.CMBGROUPOFCOMPANIES.Size = New System.Drawing.Size(161, 22)
        Me.CMBGROUPOFCOMPANIES.TabIndex = 558
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(34, 128)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(119, 14)
        Me.Label47.TabIndex = 559
        Me.Label47.Text = "Group Of Companies"
        '
        'CHKREMARKS
        '
        Me.CHKREMARKS.AutoSize = True
        Me.CHKREMARKS.BackColor = System.Drawing.Color.Transparent
        Me.CHKREMARKS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKREMARKS.ForeColor = System.Drawing.Color.Black
        Me.CHKREMARKS.Location = New System.Drawing.Point(769, 138)
        Me.CHKREMARKS.Name = "CHKREMARKS"
        Me.CHKREMARKS.Size = New System.Drawing.Size(109, 18)
        Me.CHKREMARKS.TabIndex = 671
        Me.CHKREMARKS.Text = "Show Narration"
        Me.CHKREMARKS.UseVisualStyleBackColor = False
        '
        'CHKPANNO
        '
        Me.CHKPANNO.AutoSize = True
        Me.CHKPANNO.BackColor = System.Drawing.Color.Transparent
        Me.CHKPANNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPANNO.ForeColor = System.Drawing.Color.Black
        Me.CHKPANNO.Location = New System.Drawing.Point(665, 114)
        Me.CHKPANNO.Name = "CHKPANNO"
        Me.CHKPANNO.Size = New System.Drawing.Size(96, 18)
        Me.CHKPANNO.TabIndex = 670
        Me.CHKPANNO.Text = "Show PAN No"
        Me.CHKPANNO.UseVisualStyleBackColor = False
        '
        'CMBSIGN
        '
        Me.CMBSIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSIGN.FormattingEnabled = True
        Me.CMBSIGN.Items.AddRange(New Object() {"", "=", "<", ">", ">=", "<=", "<>"})
        Me.CMBSIGN.Location = New System.Drawing.Point(228, 95)
        Me.CMBSIGN.MaxDropDownItems = 14
        Me.CMBSIGN.Name = "CMBSIGN"
        Me.CMBSIGN.Size = New System.Drawing.Size(52, 23)
        Me.CMBSIGN.TabIndex = 669
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(122, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 667
        Me.Label6.Text = "Amt."
        '
        'TXTAMT
        '
        Me.TXTAMT.Location = New System.Drawing.Point(155, 95)
        Me.TXTAMT.Name = "TXTAMT"
        Me.TXTAMT.Size = New System.Drawing.Size(71, 23)
        Me.TXTAMT.TabIndex = 668
        '
        'CHKHEADER
        '
        Me.CHKHEADER.AutoSize = True
        Me.CHKHEADER.BackColor = System.Drawing.Color.Transparent
        Me.CHKHEADER.Checked = True
        Me.CHKHEADER.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKHEADER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKHEADER.ForeColor = System.Drawing.Color.Black
        Me.CHKHEADER.Location = New System.Drawing.Point(665, 138)
        Me.CHKHEADER.Name = "CHKHEADER"
        Me.CHKHEADER.Size = New System.Drawing.Size(98, 18)
        Me.CHKHEADER.TabIndex = 666
        Me.CHKHEADER.Text = "Show Header"
        Me.CHKHEADER.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.RBPARTYMONTHLY)
        Me.GroupBox5.Controls.Add(Me.RBPARTYSUMM)
        Me.GroupBox5.Controls.Add(Me.RBCONFIRMATIONSUMM)
        Me.GroupBox5.Controls.Add(Me.RBPARTYSTATEMENTDTLS)
        Me.GroupBox5.Controls.Add(Me.RBCONFIRMATION)
        Me.GroupBox5.Controls.Add(Me.RBPARTYSTATEMENT)
        Me.GroupBox5.Controls.Add(Me.RBSUMMARY)
        Me.GroupBox5.Controls.Add(Me.RBDETAILS)
        Me.GroupBox5.Controls.Add(Me.RBTFORMAT)
        Me.GroupBox5.Location = New System.Drawing.Point(845, 161)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(229, 353)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'RBPARTYMONTHLY
        '
        Me.RBPARTYMONTHLY.AutoSize = True
        Me.RBPARTYMONTHLY.BackColor = System.Drawing.Color.Transparent
        Me.RBPARTYMONTHLY.Location = New System.Drawing.Point(13, 212)
        Me.RBPARTYMONTHLY.Name = "RBPARTYMONTHLY"
        Me.RBPARTYMONTHLY.Size = New System.Drawing.Size(184, 19)
        Me.RBPARTYMONTHLY.TabIndex = 8
        Me.RBPARTYMONTHLY.Text = "Party Monthly Type Summary"
        Me.RBPARTYMONTHLY.UseVisualStyleBackColor = False
        '
        'RBPARTYSUMM
        '
        Me.RBPARTYSUMM.AutoSize = True
        Me.RBPARTYSUMM.BackColor = System.Drawing.Color.Transparent
        Me.RBPARTYSUMM.Location = New System.Drawing.Point(13, 187)
        Me.RBPARTYSUMM.Name = "RBPARTYSUMM"
        Me.RBPARTYSUMM.Size = New System.Drawing.Size(108, 19)
        Me.RBPARTYSUMM.TabIndex = 7
        Me.RBPARTYSUMM.Text = "Party Summary"
        Me.RBPARTYSUMM.UseVisualStyleBackColor = False
        '
        'RBCONFIRMATIONSUMM
        '
        Me.RBCONFIRMATIONSUMM.AutoSize = True
        Me.RBCONFIRMATIONSUMM.BackColor = System.Drawing.Color.Transparent
        Me.RBCONFIRMATIONSUMM.Location = New System.Drawing.Point(13, 162)
        Me.RBCONFIRMATIONSUMM.Name = "RBCONFIRMATIONSUMM"
        Me.RBCONFIRMATIONSUMM.Size = New System.Drawing.Size(205, 19)
        Me.RBCONFIRMATIONSUMM.TabIndex = 6
        Me.RBCONFIRMATIONSUMM.Text = "Party Confirmation Letter (Summ)"
        Me.RBCONFIRMATIONSUMM.UseVisualStyleBackColor = False
        '
        'RBPARTYSTATEMENTDTLS
        '
        Me.RBPARTYSTATEMENTDTLS.AutoSize = True
        Me.RBPARTYSTATEMENTDTLS.BackColor = System.Drawing.Color.Transparent
        Me.RBPARTYSTATEMENTDTLS.Location = New System.Drawing.Point(13, 113)
        Me.RBPARTYSTATEMENTDTLS.Name = "RBPARTYSTATEMENTDTLS"
        Me.RBPARTYSTATEMENTDTLS.Size = New System.Drawing.Size(153, 19)
        Me.RBPARTYSTATEMENTDTLS.TabIndex = 5
        Me.RBPARTYSTATEMENTDTLS.Text = "Party Statement Details"
        Me.RBPARTYSTATEMENTDTLS.UseVisualStyleBackColor = False
        '
        'RBCONFIRMATION
        '
        Me.RBCONFIRMATION.AutoSize = True
        Me.RBCONFIRMATION.BackColor = System.Drawing.Color.Transparent
        Me.RBCONFIRMATION.Location = New System.Drawing.Point(13, 137)
        Me.RBCONFIRMATION.Name = "RBCONFIRMATION"
        Me.RBCONFIRMATION.Size = New System.Drawing.Size(161, 19)
        Me.RBCONFIRMATION.TabIndex = 4
        Me.RBCONFIRMATION.Text = "Party Confirmation Letter"
        Me.RBCONFIRMATION.UseVisualStyleBackColor = False
        '
        'RBPARTYSTATEMENT
        '
        Me.RBPARTYSTATEMENT.AutoSize = True
        Me.RBPARTYSTATEMENT.BackColor = System.Drawing.Color.Transparent
        Me.RBPARTYSTATEMENT.Location = New System.Drawing.Point(13, 89)
        Me.RBPARTYSTATEMENT.Name = "RBPARTYSTATEMENT"
        Me.RBPARTYSTATEMENT.Size = New System.Drawing.Size(159, 19)
        Me.RBPARTYSTATEMENT.TabIndex = 3
        Me.RBPARTYSTATEMENT.Text = "Party Statement (F Form)"
        Me.RBPARTYSTATEMENT.UseVisualStyleBackColor = False
        '
        'RBSUMMARY
        '
        Me.RBSUMMARY.AutoSize = True
        Me.RBSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.RBSUMMARY.Checked = True
        Me.RBSUMMARY.Location = New System.Drawing.Point(13, 17)
        Me.RBSUMMARY.Name = "RBSUMMARY"
        Me.RBSUMMARY.Size = New System.Drawing.Size(76, 19)
        Me.RBSUMMARY.TabIndex = 2
        Me.RBSUMMARY.TabStop = True
        Me.RBSUMMARY.Text = "Summary"
        Me.RBSUMMARY.UseVisualStyleBackColor = False
        '
        'RBDETAILS
        '
        Me.RBDETAILS.AutoSize = True
        Me.RBDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILS.Location = New System.Drawing.Point(13, 41)
        Me.RBDETAILS.Name = "RBDETAILS"
        Me.RBDETAILS.Size = New System.Drawing.Size(64, 19)
        Me.RBDETAILS.TabIndex = 1
        Me.RBDETAILS.Text = "Details"
        Me.RBDETAILS.UseVisualStyleBackColor = False
        '
        'RBTFORMAT
        '
        Me.RBTFORMAT.AutoSize = True
        Me.RBTFORMAT.BackColor = System.Drawing.Color.Transparent
        Me.RBTFORMAT.Location = New System.Drawing.Point(13, 65)
        Me.RBTFORMAT.Name = "RBTFORMAT"
        Me.RBTFORMAT.Size = New System.Drawing.Size(73, 19)
        Me.RBTFORMAT.TabIndex = 0
        Me.RBTFORMAT.Text = "T Format"
        Me.RBTFORMAT.UseVisualStyleBackColor = False
        '
        'CHKINDEX
        '
        Me.CHKINDEX.AutoSize = True
        Me.CHKINDEX.BackColor = System.Drawing.Color.Transparent
        Me.CHKINDEX.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKINDEX.ForeColor = System.Drawing.Color.Black
        Me.CHKINDEX.Location = New System.Drawing.Point(571, 138)
        Me.CHKINDEX.Name = "CHKINDEX"
        Me.CHKINDEX.Size = New System.Drawing.Size(88, 18)
        Me.CHKINDEX.TabIndex = 6
        Me.CHKINDEX.Text = "Show Index"
        Me.CHKINDEX.UseVisualStyleBackColor = False
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(459, 526)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(84, 28)
        Me.cmdshow.TabIndex = 9
        Me.cmdshow.Text = "&Show Report"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.gridbilldetails)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 161)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(825, 359)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selection"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(10, 43)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(805, 310)
        Me.gridbilldetails.TabIndex = 2
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
        Me.GNAME.Width = 350
        '
        'GUNDER
        '
        Me.GUNDER.Caption = "Under"
        Me.GUNDER.FieldName = "UNDER"
        Me.GUNDER.Name = "GUNDER"
        Me.GUNDER.OptionsColumn.AllowEdit = False
        Me.GUNDER.Visible = True
        Me.GUNDER.VisibleIndex = 2
        Me.GUNDER.Width = 200
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
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.RBSELECTED)
        Me.GroupBox4.Controls.Add(Me.RBALL)
        Me.GroupBox4.Location = New System.Drawing.Point(422, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(157, 38)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
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
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.BackColor = System.Drawing.Color.Transparent
        Me.RBALL.Checked = True
        Me.RBALL.Location = New System.Drawing.Point(6, 14)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(40, 19)
        Me.RBALL.TabIndex = 0
        Me.RBALL.TabStop = True
        Me.RBALL.Text = "All"
        Me.RBALL.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBGROUP)
        Me.GroupBox3.Controls.Add(Me.RBACCOUNT)
        Me.GroupBox3.Location = New System.Drawing.Point(258, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(157, 38)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
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
        'CMBGROUP
        '
        Me.CMBGROUP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGROUP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGROUP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGROUP.FormattingEnabled = True
        Me.CMBGROUP.Location = New System.Drawing.Point(155, 67)
        Me.CMBGROUP.MaxDropDownItems = 14
        Me.CMBGROUP.Name = "CMBGROUP"
        Me.CMBGROUP.Size = New System.Drawing.Size(264, 22)
        Me.CMBGROUP.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(114, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 665
        Me.Label2.Text = "Group"
        '
        'CHKGROUPONNEWPG
        '
        Me.CHKGROUPONNEWPG.AutoSize = True
        Me.CHKGROUPONNEWPG.BackColor = System.Drawing.Color.Transparent
        Me.CHKGROUPONNEWPG.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGROUPONNEWPG.ForeColor = System.Drawing.Color.Black
        Me.CHKGROUPONNEWPG.Location = New System.Drawing.Point(456, 114)
        Me.CHKGROUPONNEWPG.Name = "CHKGROUPONNEWPG"
        Me.CHKGROUPONNEWPG.Size = New System.Drawing.Size(193, 18)
        Me.CHKGROUPONNEWPG.TabIndex = 4
        Me.CHKGROUPONNEWPG.Text = "Show Each Group On New Page"
        Me.CHKGROUPONNEWPG.UseVisualStyleBackColor = False
        '
        'CHKADDRESS
        '
        Me.CHKADDRESS.AutoSize = True
        Me.CHKADDRESS.BackColor = System.Drawing.Color.Transparent
        Me.CHKADDRESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKADDRESS.ForeColor = System.Drawing.Color.Black
        Me.CHKADDRESS.Location = New System.Drawing.Point(456, 138)
        Me.CHKADDRESS.Name = "CHKADDRESS"
        Me.CHKADDRESS.Size = New System.Drawing.Size(102, 18)
        Me.CHKADDRESS.TabIndex = 5
        Me.CHKADDRESS.Text = "Show Address"
        Me.CHKADDRESS.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(435, 37)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 1
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
        Me.GroupBox1.Location = New System.Drawing.Point(427, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 2
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
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
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
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(547, 526)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(999, 526)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcrclosing.TabIndex = 436
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1086, 25)
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
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(116, 42)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(38, 15)
        Me.lblname.TabIndex = 429
        Me.lblname.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(155, 38)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(264, 23)
        Me.cmbname.TabIndex = 0
        '
        'LedgerFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1086, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LedgerFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ledger Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbldrcrclosing As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CHKGROUPONNEWPG As System.Windows.Forms.CheckBox
    Friend WithEvents CHKADDRESS As System.Windows.Forms.CheckBox
    Friend WithEvents CMBGROUP As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGROUP As System.Windows.Forms.RadioButton
    Friend WithEvents RBACCOUNT As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RBSELECTED As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GUNDER As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CHKINDEX As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RBSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RBDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents RBTFORMAT As System.Windows.Forms.RadioButton
    Friend WithEvents RBPARTYSTATEMENT As System.Windows.Forms.RadioButton
    Friend WithEvents CHKHEADER As System.Windows.Forms.CheckBox
    Friend WithEvents CMBSIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTAMT As System.Windows.Forms.TextBox
    Friend WithEvents RBCONFIRMATION As System.Windows.Forms.RadioButton
    Friend WithEvents RBPARTYSTATEMENTDTLS As System.Windows.Forms.RadioButton
    Friend WithEvents CHKPANNO As System.Windows.Forms.CheckBox
    Friend WithEvents RBCONFIRMATIONSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBPARTYSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBPARTYMONTHLY As RadioButton
    Friend WithEvents CHKREMARKS As CheckBox
    Friend WithEvents CMBGROUPOFCOMPANIES As ComboBox
    Friend WithEvents Label47 As Label
End Class
