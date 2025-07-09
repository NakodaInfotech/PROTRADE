<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMaster))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBUSER = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbgodown = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbdepartment = New System.Windows.Forms.ComboBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtsmtppass = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtsmtpemail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtpop = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtsmtp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txttel = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.lblm = New System.Windows.Forms.Label()
        Me.LSTCMP = New System.Windows.Forms.CheckedListBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbmodule = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtconfirmpass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.griduser = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gformname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gadd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gedit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gview = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbformname = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cmbmodule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griduser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBUSER)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.cmbgodown)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.cmbdepartment)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.txttel)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.txtemail)
        Me.BlendPanel1.Controls.Add(Me.lblm)
        Me.BlendPanel1.Controls.Add(Me.LSTCMP)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmbmodule)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.txtconfirmpass)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txtpassword)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.txtusername)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(905, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBUSER
        '
        Me.CMBUSER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUSER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUSER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUSER.FormattingEnabled = True
        Me.CMBUSER.Location = New System.Drawing.Point(171, 34)
        Me.CMBUSER.Name = "CMBUSER"
        Me.CMBUSER.Size = New System.Drawing.Size(179, 23)
        Me.CMBUSER.TabIndex = 489
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(72, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 15)
        Me.Label13.TabIndex = 488
        Me.Label13.Text = "Copy From User"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(664, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 14)
        Me.Label12.TabIndex = 487
        Me.Label12.Text = "Godown"
        '
        'cmbgodown
        '
        Me.cmbgodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgodown.DropDownWidth = 400
        Me.cmbgodown.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgodown.FormattingEnabled = True
        Me.cmbgodown.Location = New System.Drawing.Point(718, 78)
        Me.cmbgodown.Name = "cmbgodown"
        Me.cmbgodown.Size = New System.Drawing.Size(175, 22)
        Me.cmbgodown.TabIndex = 486
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(644, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 14)
        Me.Label11.TabIndex = 485
        Me.Label11.Text = "Department"
        '
        'cmbdepartment
        '
        Me.cmbdepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdepartment.DropDownWidth = 400
        Me.cmbdepartment.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdepartment.FormattingEnabled = True
        Me.cmbdepartment.Location = New System.Drawing.Point(718, 50)
        Me.cmbdepartment.Name = "cmbdepartment"
        Me.cmbdepartment.Size = New System.Drawing.Size(175, 22)
        Me.cmbdepartment.TabIndex = 484
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(17, 180)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(72, 18)
        Me.chkall.TabIndex = 448
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(412, 533)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 9
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(647, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 14)
        Me.Label10.TabIndex = 446
        Me.Label10.Text = "Select Company"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtsmtppass)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtsmtpemail)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtpop)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtsmtp)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(409, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 139)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SMTP Details"
        '
        'txtsmtppass
        '
        Me.txtsmtppass.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsmtppass.Location = New System.Drawing.Point(50, 105)
        Me.txtsmtppass.Name = "txtsmtppass"
        Me.txtsmtppass.Size = New System.Drawing.Size(173, 22)
        Me.txtsmtppass.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 450
        Me.Label9.Text = "PWD"
        '
        'txtsmtpemail
        '
        Me.txtsmtpemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsmtpemail.Location = New System.Drawing.Point(50, 77)
        Me.txtsmtpemail.Name = "txtsmtpemail"
        Me.txtsmtpemail.Size = New System.Drawing.Size(173, 22)
        Me.txtsmtpemail.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 448
        Me.Label8.Text = "Email"
        '
        'txtpop
        '
        Me.txtpop.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpop.Location = New System.Drawing.Point(50, 49)
        Me.txtpop.Name = "txtpop"
        Me.txtpop.Size = New System.Drawing.Size(173, 22)
        Me.txtpop.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 14)
        Me.Label5.TabIndex = 446
        Me.Label5.Text = "POP"
        '
        'txtsmtp
        '
        Me.txtsmtp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsmtp.Location = New System.Drawing.Point(50, 21)
        Me.txtsmtp.Name = "txtsmtp"
        Me.txtsmtp.Size = New System.Drawing.Size(173, 22)
        Me.txtsmtp.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 14)
        Me.Label7.TabIndex = 444
        Me.Label7.Text = "SMTP"
        '
        'txttel
        '
        Me.txttel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttel.Location = New System.Drawing.Point(171, 175)
        Me.txttel.Name = "txttel"
        Me.txttel.Size = New System.Drawing.Size(100, 22)
        Me.txttel.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(145, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 14)
        Me.Label6.TabIndex = 442
        Me.Label6.Text = "Tel"
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(171, 147)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(179, 22)
        Me.txtemail.TabIndex = 3
        '
        'lblm
        '
        Me.lblm.AutoSize = True
        Me.lblm.BackColor = System.Drawing.Color.Transparent
        Me.lblm.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblm.Location = New System.Drawing.Point(127, 150)
        Me.lblm.Name = "lblm"
        Me.lblm.Size = New System.Drawing.Size(39, 14)
        Me.lblm.TabIndex = 440
        Me.lblm.Text = "E-mail"
        '
        'LSTCMP
        '
        Me.LSTCMP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSTCMP.FormattingEnabled = True
        Me.LSTCMP.Location = New System.Drawing.Point(647, 117)
        Me.LSTCMP.Name = "LSTCMP"
        Me.LSTCMP.Size = New System.Drawing.Size(246, 72)
        Me.LSTCMP.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripdelete, Me.toolStripSeparator})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(905, 25)
        Me.ToolStrip1.TabIndex = 437
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
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
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "&Delete"
        Me.ToolStripdelete.ToolTipText = "Delete User"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'cmbmodule
        '
        Me.cmbmodule.EditValue = ""
        Me.cmbmodule.Location = New System.Drawing.Point(21, 151)
        Me.cmbmodule.Name = "cmbmodule"
        Me.cmbmodule.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmodule.Properties.Appearance.Options.UseFont = True
        Me.cmbmodule.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbmodule.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.CheckedListBoxItem() {New DevExpress.XtraEditors.Controls.CheckedListBoxItem("MASTER"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("TRANSACTIONS")})
        Me.cmbmodule.Size = New System.Drawing.Size(68, 22)
        Me.cmbmodule.TabIndex = 3
        Me.cmbmodule.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(297, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 14)
        Me.Label4.TabIndex = 435
        Me.Label4.Text = "(Max 8 Characters)"
        '
        'txtconfirmpass
        '
        Me.txtconfirmpass.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtconfirmpass.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconfirmpass.Location = New System.Drawing.Point(171, 118)
        Me.txtconfirmpass.MaxLength = 8
        Me.txtconfirmpass.Name = "txtconfirmpass"
        Me.txtconfirmpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtconfirmpass.Size = New System.Drawing.Size(100, 22)
        Me.txtconfirmpass.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 14)
        Me.Label3.TabIndex = 434
        Me.Label3.Text = "Confirm Password"
        '
        'txtpassword
        '
        Me.txtpassword.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtpassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(171, 90)
        Me.txtpassword.MaxLength = 8
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(100, 22)
        Me.txtpassword.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 432
        Me.Label1.Text = "Password"
        '
        'txtusername
        '
        Me.txtusername.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtusername.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(171, 62)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(179, 22)
        Me.txtusername.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(101, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 14)
        Me.Label2.TabIndex = 321
        Me.Label2.Text = "User Name"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(332, 533)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(492, 533)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(17, 204)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.griduser
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbformname, Me.RepositoryItemCheckEdit1})
        Me.griddetails.Size = New System.Drawing.Size(876, 324)
        Me.griddetails.TabIndex = 7
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.griduser})
        '
        'griduser
        '
        Me.griduser.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griduser.Appearance.Row.Options.UseFont = True
        Me.griduser.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gformname, Me.gadd, Me.gedit, Me.gview, Me.gdelete})
        Me.griduser.GridControl = Me.griddetails
        Me.griduser.Images = Me.imageList1
        Me.griduser.Name = "griduser"
        Me.griduser.OptionsCustomization.AllowGroup = False
        Me.griduser.OptionsView.ShowGroupPanel = False
        '
        'gformname
        '
        Me.gformname.Caption = "Form Name"
        Me.gformname.FieldName = "FormName"
        Me.gformname.ImageIndex = 0
        Me.gformname.Name = "gformname"
        Me.gformname.OptionsColumn.AllowEdit = False
        Me.gformname.Visible = True
        Me.gformname.VisibleIndex = 0
        Me.gformname.Width = 376
        '
        'gadd
        '
        Me.gadd.Caption = "Add"
        Me.gadd.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gadd.FieldName = "Addf"
        Me.gadd.Name = "gadd"
        Me.gadd.Visible = True
        Me.gadd.VisibleIndex = 1
        Me.gadd.Width = 120
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gedit
        '
        Me.gedit.Caption = "Edit"
        Me.gedit.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gedit.FieldName = "Editf"
        Me.gedit.Name = "gedit"
        Me.gedit.Visible = True
        Me.gedit.VisibleIndex = 2
        Me.gedit.Width = 120
        '
        'gview
        '
        Me.gview.Caption = "View"
        Me.gview.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gview.FieldName = "Viewf"
        Me.gview.Name = "gview"
        Me.gview.Visible = True
        Me.gview.VisibleIndex = 3
        Me.gview.Width = 120
        '
        'gdelete
        '
        Me.gdelete.Caption = "Delete"
        Me.gdelete.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gdelete.FieldName = "Deletef"
        Me.gdelete.Name = "gdelete"
        Me.gdelete.Visible = True
        Me.gdelete.VisibleIndex = 4
        Me.gdelete.Width = 120
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'cmbformname
        '
        Me.cmbformname.AutoHeight = False
        Me.cmbformname.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbformname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbformname.DropDownRows = 10
        Me.cmbformname.Name = "cmbformname"
        Me.cmbformname.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbformname.ValidateOnEnterKey = True
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'UserMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(905, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "UserMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Master"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cmbmodule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griduser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents griduser As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gformname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gadd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gedit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gview As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbformname As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtconfirmpass As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbmodule As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LSTCMP As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtsmtp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txttel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents lblm As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtsmtppass As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtsmtpemail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtpop As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbgodown As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbdepartment As System.Windows.Forms.ComboBox
    Friend WithEvents CMBUSER As ComboBox
    Friend WithEvents Label13 As Label
End Class
