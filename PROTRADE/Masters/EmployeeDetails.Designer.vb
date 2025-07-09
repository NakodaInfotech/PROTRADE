<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeDetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.gridname = New DevExpress.XtraGrid.GridControl
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.cmdadd = New System.Windows.Forms.Button
        Me.cmdedit = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Details = New System.Windows.Forms.TabPage
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.TXTOURLOCATION = New System.Windows.Forms.TextBox
        Me.TXTFILENAME = New System.Windows.Forms.TextBox
        Me.txtimgpath = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CMDVIEW = New System.Windows.Forms.Button
        Me.PBIMG = New System.Windows.Forms.PictureBox
        Me.TXTSALMODE = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TXTACNO = New System.Windows.Forms.TextBox
        Me.txtpanno = New System.Windows.Forms.TextBox
        Me.TXTPFNO = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TXTDEPARTMENT = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTCODE = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TXTEMPNAME = New System.Windows.Forms.TextBox
        Me.txtaltno = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtcountry = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.txtstate = New System.Windows.Forms.TextBox
        Me.TXTCONTACTNO = New System.Windows.Forms.TextBox
        Me.txtzipcode = New System.Windows.Forms.TextBox
        Me.txtmobile = New System.Windows.Forms.TextBox
        Me.txtcity = New System.Windows.Forms.TextBox
        Me.txtarea = New System.Windows.Forms.TextBox
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.TXTRESINO = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.TXTDESIGNATION = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Roomdetails = New System.Windows.Forms.TabPage
        Me.BlendPanel3 = New VbPowerPack.BlendPanel
        Me.GRIDDED = New System.Windows.Forms.DataGridView
        Me.GDEDSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDEDUCTION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDEDAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRIDEAR = New System.Windows.Forms.DataGridView
        Me.GEARSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GEARNINGS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GEARAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label21 = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Details.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Roomdetails.SuspendLayout()
        Me.BlendPanel3.SuspendLayout()
        CType(Me.GRIDDED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDEAR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(982, 546)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDREFRESH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Image = Global.PROTRADE.My.Resources.Resources.refresh1
        Me.CMDREFRESH.Location = New System.Drawing.Point(742, 25)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(78, 25)
        Me.CMDREFRESH.TabIndex = 449
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(18, 33)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(349, 475)
        Me.gridname.TabIndex = 315
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdadd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadd.Image = Global.PROTRADE.My.Resources.Resources.Bookings
        Me.cmdadd.Location = New System.Drawing.Point(416, 514)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 25)
        Me.cmdadd.TabIndex = 2
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Image = Global.PROTRADE.My.Resources.Resources.email_initiator
        Me.cmdedit.Location = New System.Drawing.Point(825, 25)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(72, 25)
        Me.cmdedit.TabIndex = 4
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.PROTRADE.My.Resources.Resources.Bookings
        Me.cmdexit.Location = New System.Drawing.Point(494, 514)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Details)
        Me.TabControl1.Controls.Add(Me.Roomdetails)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(370, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 475)
        Me.TabControl1.TabIndex = 239
        '
        'Details
        '
        Me.Details.Controls.Add(Me.BlendPanel2)
        Me.Details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details.Location = New System.Drawing.Point(4, 23)
        Me.Details.Name = "Details"
        Me.Details.Padding = New System.Windows.Forms.Padding(3)
        Me.Details.Size = New System.Drawing.Size(592, 448)
        Me.Details.TabIndex = 0
        Me.Details.Text = "Employee Details"
        Me.Details.UseVisualStyleBackColor = True
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.TXTOURLOCATION)
        Me.BlendPanel2.Controls.Add(Me.TXTFILENAME)
        Me.BlendPanel2.Controls.Add(Me.txtimgpath)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel2.Controls.Add(Me.PBIMG)
        Me.BlendPanel2.Controls.Add(Me.TXTSALMODE)
        Me.BlendPanel2.Controls.Add(Me.Label12)
        Me.BlendPanel2.Controls.Add(Me.TXTACNO)
        Me.BlendPanel2.Controls.Add(Me.txtpanno)
        Me.BlendPanel2.Controls.Add(Me.TXTPFNO)
        Me.BlendPanel2.Controls.Add(Me.Label19)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.Label10)
        Me.BlendPanel2.Controls.Add(Me.TXTDEPARTMENT)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.TXTCODE)
        Me.BlendPanel2.Controls.Add(Me.Label29)
        Me.BlendPanel2.Controls.Add(Me.TXTEMPNAME)
        Me.BlendPanel2.Controls.Add(Me.txtaltno)
        Me.BlendPanel2.Controls.Add(Me.Label31)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.txtcountry)
        Me.BlendPanel2.Controls.Add(Me.Label33)
        Me.BlendPanel2.Controls.Add(Me.Label53)
        Me.BlendPanel2.Controls.Add(Me.Label52)
        Me.BlendPanel2.Controls.Add(Me.Label49)
        Me.BlendPanel2.Controls.Add(Me.txtstate)
        Me.BlendPanel2.Controls.Add(Me.TXTCONTACTNO)
        Me.BlendPanel2.Controls.Add(Me.txtzipcode)
        Me.BlendPanel2.Controls.Add(Me.txtmobile)
        Me.BlendPanel2.Controls.Add(Me.txtcity)
        Me.BlendPanel2.Controls.Add(Me.txtarea)
        Me.BlendPanel2.Controls.Add(Me.txtemail)
        Me.BlendPanel2.Controls.Add(Me.Label50)
        Me.BlendPanel2.Controls.Add(Me.Label40)
        Me.BlendPanel2.Controls.Add(Me.TXTRESINO)
        Me.BlendPanel2.Controls.Add(Me.Label41)
        Me.BlendPanel2.Controls.Add(Me.Label43)
        Me.BlendPanel2.Controls.Add(Me.Label42)
        Me.BlendPanel2.Controls.Add(Me.TXTDESIGNATION)
        Me.BlendPanel2.Controls.Add(Me.Label30)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel2.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(586, 442)
        Me.BlendPanel2.TabIndex = 0
        '
        'TXTOURLOCATION
        '
        Me.TXTOURLOCATION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOURLOCATION.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTOURLOCATION.Location = New System.Drawing.Point(365, 204)
        Me.TXTOURLOCATION.Multiline = True
        Me.TXTOURLOCATION.Name = "TXTOURLOCATION"
        Me.TXTOURLOCATION.Size = New System.Drawing.Size(45, 22)
        Me.TXTOURLOCATION.TabIndex = 474
        Me.TXTOURLOCATION.Visible = False
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(330, 204)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(45, 22)
        Me.TXTFILENAME.TabIndex = 473
        Me.TXTFILENAME.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.BackColor = System.Drawing.Color.White
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ForeColor = System.Drawing.Color.Black
        Me.txtimgpath.Location = New System.Drawing.Point(416, 203)
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(22, 22)
        Me.txtimgpath.TabIndex = 472
        Me.txtimgpath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtimgpath.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(53, 310)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 471
        Me.Label1.Text = "Address"
        Me.Label1.Visible = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.ForeColor = System.Drawing.Color.Black
        Me.txtadd.Location = New System.Drawing.Point(106, 307)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(186, 109)
        Me.txtadd.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(362, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 14)
        Me.Label2.TabIndex = 470
        Me.Label2.Text = "Photograph"
        Me.Label2.Visible = False
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDVIEW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDVIEW.Image = Global.PROTRADE.My.Resources.Resources.VIEW
        Me.CMDVIEW.Location = New System.Drawing.Point(437, 214)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(79, 29)
        Me.CMDVIEW.TabIndex = 469
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.Transparent
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBIMG.ErrorImage = Nothing
        Me.PBIMG.InitialImage = Nothing
        Me.PBIMG.Location = New System.Drawing.Point(365, 246)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(170, 170)
        Me.PBIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBIMG.TabIndex = 467
        Me.PBIMG.TabStop = False
        '
        'TXTSALMODE
        '
        Me.TXTSALMODE.BackColor = System.Drawing.Color.White
        Me.TXTSALMODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALMODE.ForeColor = System.Drawing.Color.Black
        Me.TXTSALMODE.Location = New System.Drawing.Point(106, 253)
        Me.TXTSALMODE.Name = "TXTSALMODE"
        Me.TXTSALMODE.ReadOnly = True
        Me.TXTSALMODE.Size = New System.Drawing.Size(186, 22)
        Me.TXTSALMODE.TabIndex = 266
        Me.TXTSALMODE.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(59, 203)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 14)
        Me.Label12.TabIndex = 262
        Me.Label12.Text = "PAN No"
        '
        'TXTACNO
        '
        Me.TXTACNO.BackColor = System.Drawing.Color.White
        Me.TXTACNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACNO.ForeColor = System.Drawing.Color.Black
        Me.TXTACNO.Location = New System.Drawing.Point(106, 280)
        Me.TXTACNO.Name = "TXTACNO"
        Me.TXTACNO.ReadOnly = True
        Me.TXTACNO.Size = New System.Drawing.Size(186, 22)
        Me.TXTACNO.TabIndex = 261
        Me.TXTACNO.Visible = False
        '
        'txtpanno
        '
        Me.txtpanno.BackColor = System.Drawing.Color.White
        Me.txtpanno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpanno.ForeColor = System.Drawing.Color.Black
        Me.txtpanno.Location = New System.Drawing.Point(106, 199)
        Me.txtpanno.Name = "txtpanno"
        Me.txtpanno.ReadOnly = True
        Me.txtpanno.Size = New System.Drawing.Size(186, 22)
        Me.txtpanno.TabIndex = 259
        '
        'TXTPFNO
        '
        Me.TXTPFNO.BackColor = System.Drawing.Color.White
        Me.TXTPFNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPFNO.ForeColor = System.Drawing.Color.Black
        Me.TXTPFNO.Location = New System.Drawing.Point(106, 226)
        Me.TXTPFNO.Name = "TXTPFNO"
        Me.TXTPFNO.ReadOnly = True
        Me.TXTPFNO.Size = New System.Drawing.Size(186, 22)
        Me.TXTPFNO.TabIndex = 260
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(46, 230)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 14)
        Me.Label19.TabIndex = 263
        Me.Label19.Text = "PF A/C No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(61, 284)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 14)
        Me.Label9.TabIndex = 265
        Me.Label9.Text = "A/C No"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(30, 257)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 14)
        Me.Label10.TabIndex = 264
        Me.Label10.Text = "Salary Mode"
        '
        'TXTDEPARTMENT
        '
        Me.TXTDEPARTMENT.BackColor = System.Drawing.Color.White
        Me.TXTDEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDEPARTMENT.ForeColor = System.Drawing.Color.Black
        Me.TXTDEPARTMENT.Location = New System.Drawing.Point(383, 37)
        Me.TXTDEPARTMENT.Name = "TXTDEPARTMENT"
        Me.TXTDEPARTMENT.ReadOnly = True
        Me.TXTDEPARTMENT.Size = New System.Drawing.Size(186, 22)
        Me.TXTDEPARTMENT.TabIndex = 258
        Me.TXTDEPARTMENT.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(308, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 14)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Department"
        '
        'TXTCODE
        '
        Me.TXTCODE.BackColor = System.Drawing.Color.White
        Me.TXTCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCODE.ForeColor = System.Drawing.Color.Black
        Me.TXTCODE.Location = New System.Drawing.Point(106, 37)
        Me.TXTCODE.Name = "TXTCODE"
        Me.TXTCODE.ReadOnly = True
        Me.TXTCODE.Size = New System.Drawing.Size(186, 22)
        Me.TXTCODE.TabIndex = 218
        Me.TXTCODE.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(39, 14)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 14)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = "Emp Name"
        '
        'TXTEMPNAME
        '
        Me.TXTEMPNAME.BackColor = System.Drawing.Color.White
        Me.TXTEMPNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEMPNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTEMPNAME.Location = New System.Drawing.Point(106, 10)
        Me.TXTEMPNAME.Name = "TXTEMPNAME"
        Me.TXTEMPNAME.ReadOnly = True
        Me.TXTEMPNAME.Size = New System.Drawing.Size(186, 22)
        Me.TXTEMPNAME.TabIndex = 219
        Me.TXTEMPNAME.TabStop = False
        '
        'txtaltno
        '
        Me.txtaltno.BackColor = System.Drawing.Color.White
        Me.txtaltno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaltno.ForeColor = System.Drawing.Color.Black
        Me.txtaltno.Location = New System.Drawing.Point(383, 118)
        Me.txtaltno.Name = "txtaltno"
        Me.txtaltno.ReadOnly = True
        Me.txtaltno.Size = New System.Drawing.Size(186, 22)
        Me.txtaltno.TabIndex = 251
        Me.txtaltno.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(44, 41)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 14)
        Me.Label31.TabIndex = 217
        Me.Label31.Text = "Emp Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(337, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 14)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Alt No."
        '
        'txtcountry
        '
        Me.txtcountry.BackColor = System.Drawing.Color.White
        Me.txtcountry.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcountry.ForeColor = System.Drawing.Color.Black
        Me.txtcountry.Location = New System.Drawing.Point(106, 172)
        Me.txtcountry.Name = "txtcountry"
        Me.txtcountry.ReadOnly = True
        Me.txtcountry.Size = New System.Drawing.Size(186, 22)
        Me.txtcountry.TabIndex = 247
        Me.txtcountry.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(57, 176)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 14)
        Me.Label33.TabIndex = 246
        Me.Label33.Text = "Country"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(315, 95)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(65, 14)
        Me.Label53.TabIndex = 227
        Me.Label53.Text = "Contact No"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(334, 149)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 14)
        Me.Label52.TabIndex = 226
        Me.Label52.Text = "Mobile"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(342, 176)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(38, 14)
        Me.Label49.TabIndex = 228
        Me.Label49.Text = "Email"
        '
        'txtstate
        '
        Me.txtstate.BackColor = System.Drawing.Color.White
        Me.txtstate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstate.ForeColor = System.Drawing.Color.Black
        Me.txtstate.Location = New System.Drawing.Point(106, 145)
        Me.txtstate.Name = "txtstate"
        Me.txtstate.ReadOnly = True
        Me.txtstate.Size = New System.Drawing.Size(186, 22)
        Me.txtstate.TabIndex = 243
        Me.txtstate.TabStop = False
        '
        'TXTCONTACTNO
        '
        Me.TXTCONTACTNO.BackColor = System.Drawing.Color.White
        Me.TXTCONTACTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCONTACTNO.ForeColor = System.Drawing.Color.Black
        Me.TXTCONTACTNO.Location = New System.Drawing.Point(383, 91)
        Me.TXTCONTACTNO.Name = "TXTCONTACTNO"
        Me.TXTCONTACTNO.ReadOnly = True
        Me.TXTCONTACTNO.Size = New System.Drawing.Size(186, 22)
        Me.TXTCONTACTNO.TabIndex = 233
        Me.TXTCONTACTNO.TabStop = False
        '
        'txtzipcode
        '
        Me.txtzipcode.BackColor = System.Drawing.Color.White
        Me.txtzipcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtzipcode.ForeColor = System.Drawing.Color.Black
        Me.txtzipcode.Location = New System.Drawing.Point(106, 118)
        Me.txtzipcode.Name = "txtzipcode"
        Me.txtzipcode.ReadOnly = True
        Me.txtzipcode.Size = New System.Drawing.Size(186, 22)
        Me.txtzipcode.TabIndex = 242
        Me.txtzipcode.TabStop = False
        '
        'txtmobile
        '
        Me.txtmobile.BackColor = System.Drawing.Color.White
        Me.txtmobile.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobile.ForeColor = System.Drawing.Color.Black
        Me.txtmobile.Location = New System.Drawing.Point(383, 145)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.ReadOnly = True
        Me.txtmobile.Size = New System.Drawing.Size(186, 22)
        Me.txtmobile.TabIndex = 232
        Me.txtmobile.TabStop = False
        '
        'txtcity
        '
        Me.txtcity.BackColor = System.Drawing.Color.White
        Me.txtcity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcity.ForeColor = System.Drawing.Color.Black
        Me.txtcity.Location = New System.Drawing.Point(106, 91)
        Me.txtcity.Name = "txtcity"
        Me.txtcity.ReadOnly = True
        Me.txtcity.Size = New System.Drawing.Size(186, 22)
        Me.txtcity.TabIndex = 241
        Me.txtcity.TabStop = False
        '
        'txtarea
        '
        Me.txtarea.BackColor = System.Drawing.Color.White
        Me.txtarea.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtarea.ForeColor = System.Drawing.Color.Black
        Me.txtarea.Location = New System.Drawing.Point(106, 64)
        Me.txtarea.Name = "txtarea"
        Me.txtarea.ReadOnly = True
        Me.txtarea.Size = New System.Drawing.Size(186, 22)
        Me.txtarea.TabIndex = 240
        Me.txtarea.TabStop = False
        '
        'txtemail
        '
        Me.txtemail.BackColor = System.Drawing.Color.White
        Me.txtemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.ForeColor = System.Drawing.Color.Black
        Me.txtemail.Location = New System.Drawing.Point(383, 172)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.ReadOnly = True
        Me.txtemail.Size = New System.Drawing.Size(186, 22)
        Me.txtemail.TabIndex = 234
        Me.txtemail.TabStop = False
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(331, 68)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(49, 14)
        Me.Label50.TabIndex = 224
        Me.Label50.Text = "Resi No"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(69, 149)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(35, 14)
        Me.Label40.TabIndex = 239
        Me.Label40.Text = "State"
        '
        'TXTRESINO
        '
        Me.TXTRESINO.BackColor = System.Drawing.Color.White
        Me.TXTRESINO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESINO.ForeColor = System.Drawing.Color.Black
        Me.TXTRESINO.Location = New System.Drawing.Point(383, 64)
        Me.TXTRESINO.Name = "TXTRESINO"
        Me.TXTRESINO.ReadOnly = True
        Me.TXTRESINO.Size = New System.Drawing.Size(186, 22)
        Me.TXTRESINO.TabIndex = 230
        Me.TXTRESINO.TabStop = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(50, 122)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 14)
        Me.Label41.TabIndex = 238
        Me.Label41.Text = "Zip Code"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(72, 68)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(32, 14)
        Me.Label43.TabIndex = 236
        Me.Label43.Text = "Area"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(78, 95)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(26, 14)
        Me.Label42.TabIndex = 237
        Me.Label42.Text = "City"
        '
        'TXTDESIGNATION
        '
        Me.TXTDESIGNATION.BackColor = System.Drawing.Color.White
        Me.TXTDESIGNATION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESIGNATION.ForeColor = System.Drawing.Color.Black
        Me.TXTDESIGNATION.Location = New System.Drawing.Point(383, 10)
        Me.TXTDESIGNATION.Name = "TXTDESIGNATION"
        Me.TXTDESIGNATION.ReadOnly = True
        Me.TXTDESIGNATION.Size = New System.Drawing.Size(186, 22)
        Me.TXTDESIGNATION.TabIndex = 221
        Me.TXTDESIGNATION.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(307, 14)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(73, 14)
        Me.Label30.TabIndex = 220
        Me.Label30.Text = "Designation"
        '
        'Roomdetails
        '
        Me.Roomdetails.Controls.Add(Me.BlendPanel3)
        Me.Roomdetails.Location = New System.Drawing.Point(4, 23)
        Me.Roomdetails.Name = "Roomdetails"
        Me.Roomdetails.Padding = New System.Windows.Forms.Padding(3)
        Me.Roomdetails.Size = New System.Drawing.Size(592, 448)
        Me.Roomdetails.TabIndex = 3
        Me.Roomdetails.Text = "Salary Details"
        Me.Roomdetails.UseVisualStyleBackColor = True
        '
        'BlendPanel3
        '
        Me.BlendPanel3.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel3.Controls.Add(Me.GRIDDED)
        Me.BlendPanel3.Controls.Add(Me.GRIDEAR)
        Me.BlendPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel3.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel3.Name = "BlendPanel3"
        Me.BlendPanel3.Size = New System.Drawing.Size(586, 442)
        Me.BlendPanel3.TabIndex = 1
        '
        'GRIDDED
        '
        Me.GRIDDED.AllowUserToAddRows = False
        Me.GRIDDED.AllowUserToDeleteRows = False
        Me.GRIDDED.AllowUserToResizeColumns = False
        Me.GRIDDED.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDDED.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDDED.BackgroundColor = System.Drawing.Color.White
        Me.GRIDDED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDDED.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDDED.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDDED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDDED.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GDEDSRNO, Me.GDEDUCTION, Me.GDEDAMT})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDDED.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDDED.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDDED.Location = New System.Drawing.Point(17, 22)
        Me.GRIDDED.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDDED.MultiSelect = False
        Me.GRIDDED.Name = "GRIDDED"
        Me.GRIDDED.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDDED.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDDED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDDED.Size = New System.Drawing.Size(362, 192)
        Me.GRIDDED.TabIndex = 6
        '
        'GDEDSRNO
        '
        Me.GDEDSRNO.HeaderText = "Sr"
        Me.GDEDSRNO.Name = "GDEDSRNO"
        Me.GDEDSRNO.ReadOnly = True
        Me.GDEDSRNO.Width = 30
        '
        'GDEDUCTION
        '
        Me.GDEDUCTION.HeaderText = "Deduction"
        Me.GDEDUCTION.Name = "GDEDUCTION"
        Me.GDEDUCTION.ReadOnly = True
        Me.GDEDUCTION.Width = 200
        '
        'GDEDAMT
        '
        Me.GDEDAMT.HeaderText = "Amount"
        Me.GDEDAMT.Name = "GDEDAMT"
        Me.GDEDAMT.ReadOnly = True
        '
        'GRIDEAR
        '
        Me.GRIDEAR.AllowUserToAddRows = False
        Me.GRIDEAR.AllowUserToDeleteRows = False
        Me.GRIDEAR.AllowUserToResizeColumns = False
        Me.GRIDEAR.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDEAR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDEAR.BackgroundColor = System.Drawing.Color.White
        Me.GRIDEAR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDEAR.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDEAR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDEAR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDEAR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GEARSRNO, Me.GEARNINGS, Me.GEARAMT})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDEAR.DefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDEAR.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDEAR.Location = New System.Drawing.Point(18, 229)
        Me.GRIDEAR.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDEAR.MultiSelect = False
        Me.GRIDEAR.Name = "GRIDEAR"
        Me.GRIDEAR.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDEAR.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDEAR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDEAR.Size = New System.Drawing.Size(361, 192)
        Me.GRIDEAR.TabIndex = 5
        '
        'GEARSRNO
        '
        Me.GEARSRNO.HeaderText = "Sr"
        Me.GEARSRNO.Name = "GEARSRNO"
        Me.GEARSRNO.ReadOnly = True
        Me.GEARSRNO.Width = 30
        '
        'GEARNINGS
        '
        Me.GEARNINGS.HeaderText = "Earnings"
        Me.GEARNINGS.Name = "GEARNINGS"
        Me.GEARNINGS.ReadOnly = True
        Me.GEARNINGS.Width = 200
        '
        'GEARAMT
        '
        Me.GEARAMT.HeaderText = "Amount"
        Me.GEARAMT.Name = "GEARAMT"
        Me.GEARAMT.ReadOnly = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(15, 13)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(203, 14)
        Me.Label21.TabIndex = 232
        Me.Label21.Text = "Double Click on an Employee to Edit"
        '
        'EmployeeDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(982, 546)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "EmployeeDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Employee Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Details.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Roomdetails.ResumeLayout(False)
        Me.BlendPanel3.ResumeLayout(False)
        CType(Me.GRIDDED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDEAR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Details As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents TXTDEPARTMENT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TXTEMPNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtaltno As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcountry As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents txtstate As System.Windows.Forms.TextBox
    Friend WithEvents TXTCONTACTNO As System.Windows.Forms.TextBox
    Friend WithEvents txtzipcode As System.Windows.Forms.TextBox
    Friend WithEvents txtmobile As System.Windows.Forms.TextBox
    Friend WithEvents txtcity As System.Windows.Forms.TextBox
    Friend WithEvents txtarea As System.Windows.Forms.TextBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TXTRESINO As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TXTDESIGNATION As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Roomdetails As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel3 As VbPowerPack.BlendPanel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TXTSALMODE As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTACNO As System.Windows.Forms.TextBox
    Friend WithEvents txtpanno As System.Windows.Forms.TextBox
    Friend WithEvents TXTPFNO As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PBIMG As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GRIDEAR As System.Windows.Forms.DataGridView
    Friend WithEvents GEARSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEARNINGS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEARAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GRIDDED As System.Windows.Forms.DataGridView
    Friend WithEvents GDEDSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDEDUCTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDEDAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTOURLOCATION As System.Windows.Forms.TextBox
    Friend WithEvents TXTFILENAME As System.Windows.Forms.TextBox
    Friend WithEvents txtimgpath As System.Windows.Forms.TextBox
End Class
