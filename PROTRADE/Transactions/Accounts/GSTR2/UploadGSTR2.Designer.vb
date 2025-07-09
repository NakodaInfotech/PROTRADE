<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadGSTR2
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDUPLOAD = New System.Windows.Forms.Button()
        Me.GPCNDN = New System.Windows.Forms.GroupBox()
        Me.TXTCNENTRIES = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTTOTALCNDNENTRIES = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTCNDNSTART = New System.Windows.Forms.TextBox()
        Me.TXTDNENTRIES = New System.Windows.Forms.TextBox()
        Me.TXTCNDNEND = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CMDCNDNUPLOAD = New System.Windows.Forms.Button()
        Me.TXTCNDNPATH = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTCNDNSHEETNAME = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GPB2B = New System.Windows.Forms.GroupBox()
        Me.TXTPURENTRIES = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTTOTALB2BENTRIES = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTB2BSTART = New System.Windows.Forms.TextBox()
        Me.TXTNPENTRIES = New System.Windows.Forms.TextBox()
        Me.TXTB2BEND = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMDB2BUPLOAD = New System.Windows.Forms.Button()
        Me.TXTB2BPATH = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTB2BSHEETNAME = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LBLDYEINGTYPE = New System.Windows.Forms.Label()
        Me.CMBMONTH = New System.Windows.Forms.ComboBox()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CMDREPORT = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        Me.GPCNDN.SuspendLayout()
        Me.GPB2B.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREPORT)
        Me.BlendPanel1.Controls.Add(Me.CMDUPLOAD)
        Me.BlendPanel1.Controls.Add(Me.GPCNDN)
        Me.BlendPanel1.Controls.Add(Me.GPB2B)
        Me.BlendPanel1.Controls.Add(Me.LBLDYEINGTYPE)
        Me.BlendPanel1.Controls.Add(Me.CMBMONTH)
        Me.BlendPanel1.Controls.Add(Me.TXTFILENAME)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(937, 391)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDUPLOAD
        '
        Me.CMDUPLOAD.BackColor = System.Drawing.Color.Transparent
        Me.CMDUPLOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUPLOAD.FlatAppearance.BorderSize = 0
        Me.CMDUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOAD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDUPLOAD.Location = New System.Drawing.Point(341, 321)
        Me.CMDUPLOAD.Name = "CMDUPLOAD"
        Me.CMDUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPLOAD.TabIndex = 686
        Me.CMDUPLOAD.Text = "&Upload"
        Me.CMDUPLOAD.UseVisualStyleBackColor = False
        '
        'GPCNDN
        '
        Me.GPCNDN.BackColor = System.Drawing.Color.LemonChiffon
        Me.GPCNDN.Controls.Add(Me.TXTCNENTRIES)
        Me.GPCNDN.Controls.Add(Me.Label8)
        Me.GPCNDN.Controls.Add(Me.Label9)
        Me.GPCNDN.Controls.Add(Me.TXTTOTALCNDNENTRIES)
        Me.GPCNDN.Controls.Add(Me.Label10)
        Me.GPCNDN.Controls.Add(Me.Label11)
        Me.GPCNDN.Controls.Add(Me.TXTCNDNSTART)
        Me.GPCNDN.Controls.Add(Me.TXTDNENTRIES)
        Me.GPCNDN.Controls.Add(Me.TXTCNDNEND)
        Me.GPCNDN.Controls.Add(Me.Label12)
        Me.GPCNDN.Controls.Add(Me.CMDCNDNUPLOAD)
        Me.GPCNDN.Controls.Add(Me.TXTCNDNPATH)
        Me.GPCNDN.Controls.Add(Me.Label13)
        Me.GPCNDN.Controls.Add(Me.TXTCNDNSHEETNAME)
        Me.GPCNDN.Controls.Add(Me.Label14)
        Me.GPCNDN.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPCNDN.ForeColor = System.Drawing.Color.Red
        Me.GPCNDN.Location = New System.Drawing.Point(460, 73)
        Me.GPCNDN.Name = "GPCNDN"
        Me.GPCNDN.Size = New System.Drawing.Size(419, 232)
        Me.GPCNDN.TabIndex = 685
        Me.GPCNDN.TabStop = False
        Me.GPCNDN.Text = "CNDN"
        '
        'TXTCNENTRIES
        '
        Me.TXTCNENTRIES.BackColor = System.Drawing.Color.Linen
        Me.TXTCNENTRIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCNENTRIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCNENTRIES.Location = New System.Drawing.Point(104, 30)
        Me.TXTCNENTRIES.Name = "TXTCNENTRIES"
        Me.TXTCNENTRIES.ReadOnly = True
        Me.TXTCNENTRIES.Size = New System.Drawing.Size(64, 22)
        Me.TXTCNENTRIES.TabIndex = 678
        Me.TXTCNENTRIES.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(29, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 683
        Me.Label8.Text = "Total Entries"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Starting Row No"
        '
        'TXTTOTALCNDNENTRIES
        '
        Me.TXTTOTALCNDNENTRIES.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCNDNENTRIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALCNDNENTRIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTTOTALCNDNENTRIES.Location = New System.Drawing.Point(104, 58)
        Me.TXTTOTALCNDNENTRIES.Name = "TXTTOTALCNDNENTRIES"
        Me.TXTTOTALCNDNENTRIES.ReadOnly = True
        Me.TXTTOTALCNDNENTRIES.Size = New System.Drawing.Size(64, 22)
        Me.TXTTOTALCNDNENTRIES.TabIndex = 682
        Me.TXTTOTALCNDNENTRIES.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(29, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 15)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "Last Row No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(253, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 15)
        Me.Label11.TabIndex = 681
        Me.Label11.Text = "DN Entries"
        '
        'TXTCNDNSTART
        '
        Me.TXTCNDNSTART.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCNDNSTART.Location = New System.Drawing.Point(104, 106)
        Me.TXTCNDNSTART.Name = "TXTCNDNSTART"
        Me.TXTCNDNSTART.Size = New System.Drawing.Size(64, 23)
        Me.TXTCNDNSTART.TabIndex = 0
        '
        'TXTDNENTRIES
        '
        Me.TXTDNENTRIES.BackColor = System.Drawing.Color.Linen
        Me.TXTDNENTRIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDNENTRIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTDNENTRIES.Location = New System.Drawing.Point(320, 30)
        Me.TXTDNENTRIES.Name = "TXTDNENTRIES"
        Me.TXTDNENTRIES.ReadOnly = True
        Me.TXTDNENTRIES.Size = New System.Drawing.Size(64, 22)
        Me.TXTDNENTRIES.TabIndex = 680
        Me.TXTDNENTRIES.TabStop = False
        '
        'TXTCNDNEND
        '
        Me.TXTCNDNEND.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCNDNEND.Location = New System.Drawing.Point(104, 135)
        Me.TXTCNDNEND.Name = "TXTCNDNEND"
        Me.TXTCNDNEND.Size = New System.Drawing.Size(64, 23)
        Me.TXTCNDNEND.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(39, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 15)
        Me.Label12.TabIndex = 679
        Me.Label12.Text = "CN Entries"
        '
        'CMDCNDNUPLOAD
        '
        Me.CMDCNDNUPLOAD.BackColor = System.Drawing.Color.Transparent
        Me.CMDCNDNUPLOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCNDNUPLOAD.FlatAppearance.BorderSize = 0
        Me.CMDCNDNUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCNDNUPLOAD.ForeColor = System.Drawing.Color.Black
        Me.CMDCNDNUPLOAD.Location = New System.Drawing.Point(304, 130)
        Me.CMDCNDNUPLOAD.Name = "CMDCNDNUPLOAD"
        Me.CMDCNDNUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDCNDNUPLOAD.TabIndex = 7
        Me.CMDCNDNUPLOAD.Text = "Select File"
        Me.CMDCNDNUPLOAD.UseVisualStyleBackColor = False
        '
        'TXTCNDNPATH
        '
        Me.TXTCNDNPATH.BackColor = System.Drawing.Color.Linen
        Me.TXTCNDNPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCNDNPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCNDNPATH.Location = New System.Drawing.Point(104, 192)
        Me.TXTCNDNPATH.Name = "TXTCNDNPATH"
        Me.TXTCNDNPATH.ReadOnly = True
        Me.TXTCNDNPATH.Size = New System.Drawing.Size(280, 22)
        Me.TXTCNDNPATH.TabIndex = 571
        Me.TXTCNDNPATH.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(69, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 15)
        Me.Label13.TabIndex = 574
        Me.Label13.Text = "Path"
        '
        'TXTCNDNSHEETNAME
        '
        Me.TXTCNDNSHEETNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCNDNSHEETNAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCNDNSHEETNAME.Location = New System.Drawing.Point(104, 164)
        Me.TXTCNDNSHEETNAME.Name = "TXTCNDNSHEETNAME"
        Me.TXTCNDNSHEETNAME.Size = New System.Drawing.Size(280, 22)
        Me.TXTCNDNSHEETNAME.TabIndex = 6
        Me.TXTCNDNSHEETNAME.Text = "Sheet1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(31, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 15)
        Me.Label14.TabIndex = 576
        Me.Label14.Text = "Sheet Name"
        '
        'GPB2B
        '
        Me.GPB2B.BackColor = System.Drawing.Color.LightGreen
        Me.GPB2B.Controls.Add(Me.TXTPURENTRIES)
        Me.GPB2B.Controls.Add(Me.Label5)
        Me.GPB2B.Controls.Add(Me.Label2)
        Me.GPB2B.Controls.Add(Me.TXTTOTALB2BENTRIES)
        Me.GPB2B.Controls.Add(Me.Label1)
        Me.GPB2B.Controls.Add(Me.Label4)
        Me.GPB2B.Controls.Add(Me.TXTB2BSTART)
        Me.GPB2B.Controls.Add(Me.TXTNPENTRIES)
        Me.GPB2B.Controls.Add(Me.TXTB2BEND)
        Me.GPB2B.Controls.Add(Me.Label3)
        Me.GPB2B.Controls.Add(Me.CMDB2BUPLOAD)
        Me.GPB2B.Controls.Add(Me.TXTB2BPATH)
        Me.GPB2B.Controls.Add(Me.Label6)
        Me.GPB2B.Controls.Add(Me.TXTB2BSHEETNAME)
        Me.GPB2B.Controls.Add(Me.Label7)
        Me.GPB2B.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPB2B.ForeColor = System.Drawing.Color.Red
        Me.GPB2B.Location = New System.Drawing.Point(35, 73)
        Me.GPB2B.Name = "GPB2B"
        Me.GPB2B.Size = New System.Drawing.Size(419, 232)
        Me.GPB2B.TabIndex = 684
        Me.GPB2B.TabStop = False
        Me.GPB2B.Text = "B2B"
        '
        'TXTPURENTRIES
        '
        Me.TXTPURENTRIES.BackColor = System.Drawing.Color.Linen
        Me.TXTPURENTRIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURENTRIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTPURENTRIES.Location = New System.Drawing.Point(104, 30)
        Me.TXTPURENTRIES.Name = "TXTPURENTRIES"
        Me.TXTPURENTRIES.ReadOnly = True
        Me.TXTPURENTRIES.Size = New System.Drawing.Size(64, 22)
        Me.TXTPURENTRIES.TabIndex = 678
        Me.TXTPURENTRIES.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(30, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 683
        Me.Label5.Text = "Total Entries"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Starting Row No"
        '
        'TXTTOTALB2BENTRIES
        '
        Me.TXTTOTALB2BENTRIES.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALB2BENTRIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALB2BENTRIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTTOTALB2BENTRIES.Location = New System.Drawing.Point(104, 58)
        Me.TXTTOTALB2BENTRIES.Name = "TXTTOTALB2BENTRIES"
        Me.TXTTOTALB2BENTRIES.ReadOnly = True
        Me.TXTTOTALB2BENTRIES.Size = New System.Drawing.Size(64, 22)
        Me.TXTTOTALB2BENTRIES.TabIndex = 682
        Me.TXTTOTALB2BENTRIES.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Last Row No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(198, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 15)
        Me.Label4.TabIndex = 681
        Me.Label4.Text = "Non Purchase Entries"
        '
        'TXTB2BSTART
        '
        Me.TXTB2BSTART.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB2BSTART.Location = New System.Drawing.Point(104, 106)
        Me.TXTB2BSTART.Name = "TXTB2BSTART"
        Me.TXTB2BSTART.Size = New System.Drawing.Size(64, 23)
        Me.TXTB2BSTART.TabIndex = 0
        '
        'TXTNPENTRIES
        '
        Me.TXTNPENTRIES.BackColor = System.Drawing.Color.Linen
        Me.TXTNPENTRIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNPENTRIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNPENTRIES.Location = New System.Drawing.Point(320, 30)
        Me.TXTNPENTRIES.Name = "TXTNPENTRIES"
        Me.TXTNPENTRIES.ReadOnly = True
        Me.TXTNPENTRIES.Size = New System.Drawing.Size(64, 22)
        Me.TXTNPENTRIES.TabIndex = 680
        Me.TXTNPENTRIES.TabStop = False
        '
        'TXTB2BEND
        '
        Me.TXTB2BEND.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB2BEND.Location = New System.Drawing.Point(104, 135)
        Me.TXTB2BEND.Name = "TXTB2BEND"
        Me.TXTB2BEND.Size = New System.Drawing.Size(64, 23)
        Me.TXTB2BEND.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 679
        Me.Label3.Text = "Purchase Entries"
        '
        'CMDB2BUPLOAD
        '
        Me.CMDB2BUPLOAD.BackColor = System.Drawing.Color.Transparent
        Me.CMDB2BUPLOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDB2BUPLOAD.FlatAppearance.BorderSize = 0
        Me.CMDB2BUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDB2BUPLOAD.ForeColor = System.Drawing.Color.Black
        Me.CMDB2BUPLOAD.Location = New System.Drawing.Point(304, 130)
        Me.CMDB2BUPLOAD.Name = "CMDB2BUPLOAD"
        Me.CMDB2BUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDB2BUPLOAD.TabIndex = 7
        Me.CMDB2BUPLOAD.Text = "Select File"
        Me.CMDB2BUPLOAD.UseVisualStyleBackColor = False
        '
        'TXTB2BPATH
        '
        Me.TXTB2BPATH.BackColor = System.Drawing.Color.Linen
        Me.TXTB2BPATH.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB2BPATH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTB2BPATH.Location = New System.Drawing.Point(104, 192)
        Me.TXTB2BPATH.Name = "TXTB2BPATH"
        Me.TXTB2BPATH.ReadOnly = True
        Me.TXTB2BPATH.Size = New System.Drawing.Size(280, 22)
        Me.TXTB2BPATH.TabIndex = 571
        Me.TXTB2BPATH.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(69, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 574
        Me.Label6.Text = "Path"
        '
        'TXTB2BSHEETNAME
        '
        Me.TXTB2BSHEETNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB2BSHEETNAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTB2BSHEETNAME.Location = New System.Drawing.Point(104, 164)
        Me.TXTB2BSHEETNAME.Name = "TXTB2BSHEETNAME"
        Me.TXTB2BSHEETNAME.Size = New System.Drawing.Size(280, 22)
        Me.TXTB2BSHEETNAME.TabIndex = 6
        Me.TXTB2BSHEETNAME.Text = "Sheet1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(31, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 15)
        Me.Label7.TabIndex = 576
        Me.Label7.Text = "Sheet Name"
        '
        'LBLDYEINGTYPE
        '
        Me.LBLDYEINGTYPE.AutoSize = True
        Me.LBLDYEINGTYPE.BackColor = System.Drawing.Color.Transparent
        Me.LBLDYEINGTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDYEINGTYPE.ForeColor = System.Drawing.Color.Black
        Me.LBLDYEINGTYPE.Location = New System.Drawing.Point(60, 32)
        Me.LBLDYEINGTYPE.Name = "LBLDYEINGTYPE"
        Me.LBLDYEINGTYPE.Size = New System.Drawing.Size(43, 15)
        Me.LBLDYEINGTYPE.TabIndex = 676
        Me.LBLDYEINGTYPE.Text = "Month"
        '
        'CMBMONTH
        '
        Me.CMBMONTH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMONTH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMONTH.BackColor = System.Drawing.Color.White
        Me.CMBMONTH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBMONTH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMONTH.FormattingEnabled = True
        Me.CMBMONTH.Items.AddRange(New Object() {"APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER", "JANUARY", "FEBRUARY", "MARCH"})
        Me.CMBMONTH.Location = New System.Drawing.Point(107, 29)
        Me.CMBMONTH.MaxDropDownItems = 14
        Me.CMBMONTH.Name = "CMBMONTH"
        Me.CMBMONTH.Size = New System.Drawing.Size(131, 23)
        Me.CMBMONTH.TabIndex = 675
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(14, 4)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 572
        Me.TXTFILENAME.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXIT.Location = New System.Drawing.Point(516, 321)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 9
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CMDREPORT
        '
        Me.CMDREPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDREPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREPORT.FlatAppearance.BorderSize = 0
        Me.CMDREPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREPORT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREPORT.Location = New System.Drawing.Point(427, 321)
        Me.CMDREPORT.Name = "CMDREPORT"
        Me.CMDREPORT.Size = New System.Drawing.Size(83, 28)
        Me.CMDREPORT.TabIndex = 687
        Me.CMDREPORT.Text = "&Show Report"
        Me.CMDREPORT.UseVisualStyleBackColor = False
        '
        'UploadGSTR2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(937, 391)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UploadGSTR2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Upload GSTR-2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPCNDN.ResumeLayout(False)
        Me.GPCNDN.PerformLayout()
        Me.GPB2B.ResumeLayout(False)
        Me.GPB2B.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTB2BSHEETNAME As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTFILENAME As TextBox
    Friend WithEvents TXTB2BPATH As TextBox
    Friend WithEvents TXTB2BEND As TextBox
    Friend WithEvents TXTB2BSTART As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents LBLDYEINGTYPE As Label
    Friend WithEvents CMBMONTH As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTTOTALB2BENTRIES As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTNPENTRIES As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTPURENTRIES As TextBox
    Friend WithEvents GPCNDN As GroupBox
    Friend WithEvents TXTCNENTRIES As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTTOTALCNDNENTRIES As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTCNDNSTART As TextBox
    Friend WithEvents TXTDNENTRIES As TextBox
    Friend WithEvents TXTCNDNEND As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTCNDNPATH As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXTCNDNSHEETNAME As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents GPB2B As GroupBox
    Friend WithEvents CMDCNDNUPLOAD As Button
    Friend WithEvents CMDB2BUPLOAD As Button
    Friend WithEvents CMDUPLOAD As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CMDREPORT As Button
End Class
