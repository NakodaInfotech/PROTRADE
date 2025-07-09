<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cmpmaster
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXTOURLOCATION = New System.Windows.Forms.TextBox()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.txtimgpath = New System.Windows.Forms.TextBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.cmdremove = New System.Windows.Forms.Button()
        Me.cmdupload = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PBIMG = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtinvfooter = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtinvinitials = New System.Windows.Forms.TextBox()
        Me.txtdisplayedname = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rbpropautho = New System.Windows.Forms.RadioButton()
        Me.rbpartner = New System.Windows.Forms.RadioButton()
        Me.rbautho = New System.Windows.Forms.RadioButton()
        Me.rbprop = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.cmdback = New System.Windows.Forms.Button()
        Me.cmdnext = New System.Windows.Forms.Button()
        Me.cmdleave = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtwebsite = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtfax = New System.Windows.Forms.TextBox()
        Me.txttel1 = New System.Windows.Forms.TextBox()
        Me.txtzipcode = New System.Windows.Forms.TextBox()
        Me.cmbcountry = New System.Windows.Forms.ComboBox()
        Me.cmbstate = New System.Windows.Forms.ComboBox()
        Me.cmbcity = New System.Windows.Forms.ComboBox()
        Me.txtadd2 = New System.Windows.Forms.TextBox()
        Me.txtadd1 = New System.Windows.Forms.TextBox()
        Me.txtlegalname = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtcmpname = New System.Windows.Forms.TextBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(616, 537)
        Me.BlendPanel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TXTOURLOCATION)
        Me.GroupBox1.Controls.Add(Me.TXTFILENAME)
        Me.GroupBox1.Controls.Add(Me.txtimgpath)
        Me.GroupBox1.Controls.Add(Me.CMDVIEW)
        Me.GroupBox1.Controls.Add(Me.cmdremove)
        Me.GroupBox1.Controls.Add(Me.cmdupload)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.PBIMG)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtinvfooter)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtinvinitials)
        Me.GroupBox1.Controls.Add(Me.txtdisplayedname)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.rbpropautho)
        Me.GroupBox1.Controls.Add(Me.rbpartner)
        Me.GroupBox1.Controls.Add(Me.rbautho)
        Me.GroupBox1.Controls.Add(Me.rbprop)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmdedit)
        Me.GroupBox1.Controls.Add(Me.cmdback)
        Me.GroupBox1.Controls.Add(Me.cmdnext)
        Me.GroupBox1.Controls.Add(Me.cmdleave)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtwebsite)
        Me.GroupBox1.Controls.Add(Me.txtemail)
        Me.GroupBox1.Controls.Add(Me.txtfax)
        Me.GroupBox1.Controls.Add(Me.txttel1)
        Me.GroupBox1.Controls.Add(Me.txtzipcode)
        Me.GroupBox1.Controls.Add(Me.cmbcountry)
        Me.GroupBox1.Controls.Add(Me.cmbstate)
        Me.GroupBox1.Controls.Add(Me.cmbcity)
        Me.GroupBox1.Controls.Add(Me.txtadd2)
        Me.GroupBox1.Controls.Add(Me.txtadd1)
        Me.GroupBox1.Controls.Add(Me.txtlegalname)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtcmpname)
        Me.GroupBox1.Controls.Add(Me.lblgroup)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Green
        Me.GroupBox1.Location = New System.Drawing.Point(18, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(586, 492)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Information"
        '
        'TXTOURLOCATION
        '
        Me.TXTOURLOCATION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOURLOCATION.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTOURLOCATION.Location = New System.Drawing.Point(512, 50)
        Me.TXTOURLOCATION.Multiline = True
        Me.TXTOURLOCATION.Name = "TXTOURLOCATION"
        Me.TXTOURLOCATION.Size = New System.Drawing.Size(45, 22)
        Me.TXTOURLOCATION.TabIndex = 547
        Me.TXTOURLOCATION.Visible = False
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(518, 27)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(45, 22)
        Me.TXTFILENAME.TabIndex = 546
        Me.TXTFILENAME.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(488, 125)
        Me.txtimgpath.Multiline = True
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(45, 22)
        Me.txtimgpath.TabIndex = 545
        Me.txtimgpath.Visible = False
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.Black
        Me.CMDVIEW.Location = New System.Drawing.Point(464, 327)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDVIEW.TabIndex = 544
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'cmdremove
        '
        Me.cmdremove.BackColor = System.Drawing.Color.Transparent
        Me.cmdremove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdremove.FlatAppearance.BorderSize = 0
        Me.cmdremove.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdremove.ForeColor = System.Drawing.Color.Black
        Me.cmdremove.Location = New System.Drawing.Point(464, 294)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(80, 28)
        Me.cmdremove.TabIndex = 541
        Me.cmdremove.Text = "&Remove"
        Me.cmdremove.UseVisualStyleBackColor = False
        '
        'cmdupload
        '
        Me.cmdupload.BackColor = System.Drawing.Color.Transparent
        Me.cmdupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdupload.FlatAppearance.BorderSize = 0
        Me.cmdupload.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupload.ForeColor = System.Drawing.Color.Black
        Me.cmdupload.Location = New System.Drawing.Point(464, 171)
        Me.cmdupload.Name = "cmdupload"
        Me.cmdupload.Size = New System.Drawing.Size(80, 28)
        Me.cmdupload.TabIndex = 540
        Me.cmdupload.Text = "&Upload"
        Me.cmdupload.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(475, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 14)
        Me.Label18.TabIndex = 543
        Me.Label18.Text = "Cmp Logo"
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.Transparent
        Me.PBIMG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBIMG.ErrorImage = Nothing
        Me.PBIMG.InitialImage = Nothing
        Me.PBIMG.Location = New System.Drawing.Point(448, 208)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(115, 77)
        Me.PBIMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBIMG.TabIndex = 542
        Me.PBIMG.TabStop = False
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Green
        Me.Label17.Location = New System.Drawing.Point(305, 169)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(148, 32)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "Enter Invoice Footer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (e.g.  For Abc Industries)"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Green
        Me.Label15.Location = New System.Drawing.Point(108, 169)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 32)
        Me.Label15.TabIndex = 172
        Me.Label15.Text = "Enter Invoice Initials" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (e.g.  IND/09-10/)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(237, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "* Inv Footer"
        '
        'txtinvfooter
        '
        Me.txtinvfooter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtinvfooter.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvfooter.Location = New System.Drawing.Point(308, 147)
        Me.txtinvfooter.MaxLength = 50
        Me.txtinvfooter.Name = "txtinvfooter"
        Me.txtinvfooter.Size = New System.Drawing.Size(117, 22)
        Me.txtinvfooter.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(19, 151)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 14)
        Me.Label20.TabIndex = 169
        Me.Label20.Text = "Invoice Initials"
        '
        'txtinvinitials
        '
        Me.txtinvinitials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtinvinitials.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvinitials.Location = New System.Drawing.Point(111, 147)
        Me.txtinvinitials.MaxLength = 50
        Me.txtinvinitials.Name = "txtinvinitials"
        Me.txtinvinitials.Size = New System.Drawing.Size(117, 22)
        Me.txtinvinitials.TabIndex = 7
        '
        'txtdisplayedname
        '
        Me.txtdisplayedname.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtdisplayedname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdisplayedname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisplayedname.Location = New System.Drawing.Point(111, 121)
        Me.txtdisplayedname.MaxLength = 100
        Me.txtdisplayedname.Name = "txtdisplayedname"
        Me.txtdisplayedname.Size = New System.Drawing.Size(314, 22)
        Me.txtdisplayedname.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(2, 125)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 14)
        Me.Label19.TabIndex = 166
        Me.Label19.Text = "* Displayed Name"
        '
        'rbpropautho
        '
        Me.rbpropautho.AutoSize = True
        Me.rbpropautho.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpropautho.ForeColor = System.Drawing.Color.Black
        Me.rbpropautho.Location = New System.Drawing.Point(298, 94)
        Me.rbpropautho.Name = "rbpropautho"
        Me.rbpropautho.Size = New System.Drawing.Size(159, 18)
        Me.rbpropautho.TabIndex = 5
        Me.rbpropautho.Text = "Proprietor/Authorised Sign."
        Me.rbpropautho.UseVisualStyleBackColor = True
        '
        'rbpartner
        '
        Me.rbpartner.AutoSize = True
        Me.rbpartner.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpartner.ForeColor = System.Drawing.Color.Black
        Me.rbpartner.Location = New System.Drawing.Point(233, 94)
        Me.rbpartner.Name = "rbpartner"
        Me.rbpartner.Size = New System.Drawing.Size(61, 18)
        Me.rbpartner.TabIndex = 4
        Me.rbpartner.Text = "Partner"
        Me.rbpartner.UseVisualStyleBackColor = True
        '
        'rbautho
        '
        Me.rbautho.AutoSize = True
        Me.rbautho.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbautho.ForeColor = System.Drawing.Color.Black
        Me.rbautho.Location = New System.Drawing.Point(123, 94)
        Me.rbautho.Name = "rbautho"
        Me.rbautho.Size = New System.Drawing.Size(105, 18)
        Me.rbautho.TabIndex = 3
        Me.rbautho.Text = "Authorised Sign."
        Me.rbautho.UseVisualStyleBackColor = True
        '
        'rbprop
        '
        Me.rbprop.AutoSize = True
        Me.rbprop.Checked = True
        Me.rbprop.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbprop.ForeColor = System.Drawing.Color.Black
        Me.rbprop.Location = New System.Drawing.Point(46, 94)
        Me.rbprop.Name = "rbprop"
        Me.rbprop.Size = New System.Drawing.Size(74, 18)
        Me.rbprop.TabIndex = 2
        Me.rbprop.TabStop = True
        Me.rbprop.Text = "Proprietor"
        Me.rbprop.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(48, 235)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 14)
        Me.Label16.TabIndex = 162
        Me.Label16.Text = "Address 2"
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(136, 456)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(67, 24)
        Me.cmdedit.TabIndex = 161
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'cmdback
        '
        Me.cmdback.Enabled = False
        Me.cmdback.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdback.Location = New System.Drawing.Point(252, 456)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(80, 24)
        Me.cmdback.TabIndex = 20
        Me.cmdback.Text = "< &Back"
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmdnext
        '
        Me.cmdnext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdnext.Location = New System.Drawing.Point(338, 456)
        Me.cmdnext.Name = "cmdnext"
        Me.cmdnext.Size = New System.Drawing.Size(80, 24)
        Me.cmdnext.TabIndex = 19
        Me.cmdnext.Text = "&Next >"
        Me.cmdnext.UseVisualStyleBackColor = True
        '
        'cmdleave
        '
        Me.cmdleave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdleave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdleave.Location = New System.Drawing.Point(50, 456)
        Me.cmdleave.Name = "cmdleave"
        Me.cmdleave.Size = New System.Drawing.Size(80, 24)
        Me.cmdleave.TabIndex = 20
        Me.cmdleave.Text = "&Leave.."
        Me.cmdleave.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Green
        Me.Label14.Location = New System.Drawing.Point(108, 426)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(317, 20)
        Me.Label14.TabIndex = 155
        Me.Label14.Text = "Enter Website. (e.g.  www.abc.com, www.xyz.com..., etc. )"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(108, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(317, 36)
        Me.Label13.TabIndex = 154
        Me.Label13.Text = "Enter E-mail Address                                                             " &
    "    (e.g.  abc@gmail.com, xyz@yahoo.com..., etc. )"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(108, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(284, 26)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "Enter Chairman's / Proprietor's / Partner's Name."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(52, 407)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 14)
        Me.Label12.TabIndex = 152
        Me.Label12.Text = "Web Site"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(19, 345)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 14)
        Me.Label11.TabIndex = 151
        Me.Label11.Text = "E-mail Address"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(42, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 14)
        Me.Label10.TabIndex = 150
        Me.Label10.Text = "Telephone"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(253, 263)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 14)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = "Zip Code"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(282, 318)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 14)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Fax"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(251, 291)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "* Country"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(64, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "* State"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(39, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 14)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "* Address 1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(73, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 14)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "* City"
        '
        'txtwebsite
        '
        Me.txtwebsite.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtwebsite.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtwebsite.Location = New System.Drawing.Point(111, 403)
        Me.txtwebsite.Name = "txtwebsite"
        Me.txtwebsite.Size = New System.Drawing.Size(314, 22)
        Me.txtwebsite.TabIndex = 18
        '
        'txtemail
        '
        Me.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtemail.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(111, 341)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(314, 22)
        Me.txtemail.TabIndex = 17
        '
        'txtfax
        '
        Me.txtfax.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.Location = New System.Drawing.Point(308, 314)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(117, 22)
        Me.txtfax.TabIndex = 16
        '
        'txttel1
        '
        Me.txttel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttel1.Location = New System.Drawing.Point(111, 314)
        Me.txttel1.MaxLength = 50
        Me.txttel1.Name = "txttel1"
        Me.txttel1.Size = New System.Drawing.Size(117, 22)
        Me.txttel1.TabIndex = 15
        '
        'txtzipcode
        '
        Me.txtzipcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtzipcode.Location = New System.Drawing.Point(308, 259)
        Me.txtzipcode.Name = "txtzipcode"
        Me.txtzipcode.Size = New System.Drawing.Size(117, 22)
        Me.txtzipcode.TabIndex = 12
        '
        'cmbcountry
        '
        Me.cmbcountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcountry.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbcountry.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcountry.FormattingEnabled = True
        Me.cmbcountry.Location = New System.Drawing.Point(308, 286)
        Me.cmbcountry.MaxDropDownItems = 14
        Me.cmbcountry.Name = "cmbcountry"
        Me.cmbcountry.Size = New System.Drawing.Size(117, 22)
        Me.cmbcountry.TabIndex = 14
        '
        'cmbstate
        '
        Me.cmbstate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbstate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbstate.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbstate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstate.FormattingEnabled = True
        Me.cmbstate.Location = New System.Drawing.Point(111, 286)
        Me.cmbstate.MaxDropDownItems = 14
        Me.cmbstate.Name = "cmbstate"
        Me.cmbstate.Size = New System.Drawing.Size(117, 22)
        Me.cmbstate.TabIndex = 13
        '
        'cmbcity
        '
        Me.cmbcity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcity.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbcity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcity.FormattingEnabled = True
        Me.cmbcity.Location = New System.Drawing.Point(111, 258)
        Me.cmbcity.MaxDropDownItems = 14
        Me.cmbcity.Name = "cmbcity"
        Me.cmbcity.Size = New System.Drawing.Size(117, 22)
        Me.cmbcity.TabIndex = 11
        '
        'txtadd2
        '
        Me.txtadd2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd2.Location = New System.Drawing.Point(111, 231)
        Me.txtadd2.Name = "txtadd2"
        Me.txtadd2.Size = New System.Drawing.Size(314, 22)
        Me.txtadd2.TabIndex = 10
        '
        'txtadd1
        '
        Me.txtadd1.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtadd1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd1.Location = New System.Drawing.Point(111, 204)
        Me.txtadd1.Name = "txtadd1"
        Me.txtadd1.Size = New System.Drawing.Size(314, 22)
        Me.txtadd1.TabIndex = 9
        '
        'txtlegalname
        '
        Me.txtlegalname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlegalname.Location = New System.Drawing.Point(111, 50)
        Me.txtlegalname.MaxLength = 100
        Me.txtlegalname.Name = "txtlegalname"
        Me.txtlegalname.Size = New System.Drawing.Size(314, 22)
        Me.txtlegalname.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(4, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Concerned Person"
        '
        'txtcmpname
        '
        Me.txtcmpname.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtcmpname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcmpname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmpname.Location = New System.Drawing.Point(111, 23)
        Me.txtcmpname.MaxLength = 100
        Me.txtcmpname.Name = "txtcmpname"
        Me.txtcmpname.Size = New System.Drawing.Size(314, 22)
        Me.txtcmpname.TabIndex = 0
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(8, 27)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(94, 14)
        Me.lblgroup.TabIndex = 91
        Me.lblgroup.Text = "* Company Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(23, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(210, 18)
        Me.lbl.TabIndex = 160
        Me.lbl.Text = "Enter Your Company Information"
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Cmpmaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 537)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "Cmpmaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company Master"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdback As System.Windows.Forms.Button
    Friend WithEvents cmdnext As System.Windows.Forms.Button
    Friend WithEvents cmdleave As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Public WithEvents txtcmpname As System.Windows.Forms.TextBox
    Public WithEvents txtinvinitials As System.Windows.Forms.TextBox
    Public WithEvents txtdisplayedname As System.Windows.Forms.TextBox
    Public WithEvents rbpropautho As System.Windows.Forms.RadioButton
    Public WithEvents rbpartner As System.Windows.Forms.RadioButton
    Public WithEvents rbautho As System.Windows.Forms.RadioButton
    Public WithEvents rbprop As System.Windows.Forms.RadioButton
    Public WithEvents txtwebsite As System.Windows.Forms.TextBox
    Public WithEvents txtemail As System.Windows.Forms.TextBox
    Public WithEvents txtfax As System.Windows.Forms.TextBox
    Public WithEvents txttel1 As System.Windows.Forms.TextBox
    Public WithEvents txtzipcode As System.Windows.Forms.TextBox
    Public WithEvents cmbcountry As System.Windows.Forms.ComboBox
    Public WithEvents cmbstate As System.Windows.Forms.ComboBox
    Public WithEvents cmbcity As System.Windows.Forms.ComboBox
    Public WithEvents txtadd2 As System.Windows.Forms.TextBox
    Public WithEvents txtadd1 As System.Windows.Forms.TextBox
    Public WithEvents txtlegalname As System.Windows.Forms.TextBox
    Public WithEvents txtinvfooter As System.Windows.Forms.TextBox
    Friend WithEvents TXTOURLOCATION As TextBox
    Friend WithEvents TXTFILENAME As TextBox
    Friend WithEvents txtimgpath As TextBox
    Friend WithEvents CMDVIEW As Button
    Friend WithEvents cmdremove As Button
    Friend WithEvents cmdupload As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents PBIMG As PictureBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
