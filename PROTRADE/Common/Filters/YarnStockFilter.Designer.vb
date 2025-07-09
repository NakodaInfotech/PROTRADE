<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnStockFilter
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
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBMILLNAME = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBYARNQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBSHADEDETAIL = New System.Windows.Forms.RadioButton()
        Me.RDBMILLDETAIL = New System.Windows.Forms.RadioButton()
        Me.RDBYARNDESIGNDETAIL = New System.Windows.Forms.RadioButton()
        Me.RBYARNQUALITYDETAIL = New System.Windows.Forms.RadioButton()
        Me.RBSTOCKONHAND = New System.Windows.Forms.RadioButton()
        Me.RBMILLSUMM = New System.Windows.Forms.RadioButton()
        Me.RBSHADESUMM = New System.Windows.Forms.RadioButton()
        Me.RBYARNQUALITYSUMM = New System.Windows.Forms.RadioButton()
        Me.RBDESIGNSUMM = New System.Windows.Forms.RadioButton()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RDBFINISHDETAIL = New System.Windows.Forms.RadioButton()
        Me.RDBFINISHSUMM = New System.Windows.Forms.RadioButton()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.TXTADD)
        Me.BlendPanel2.Controls.Add(Me.CMBMILLNAME)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBNAME)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.CMBYARNQUALITY)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(441, 492)
        Me.BlendPanel2.TabIndex = 0
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(106, 185)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(230, 22)
        Me.CMBCATEGORY.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(52, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 758
        Me.Label5.Text = "Category"
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(401, 125)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 756
        Me.CMBCODE.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(387, 124)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(30, 23)
        Me.TXTADD.TabIndex = 755
        Me.TXTADD.Visible = False
        '
        'CMBMILLNAME
        '
        Me.CMBMILLNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMILLNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMILLNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMILLNAME.FormattingEnabled = True
        Me.CMBMILLNAME.Location = New System.Drawing.Point(106, 73)
        Me.CMBMILLNAME.MaxDropDownItems = 14
        Me.CMBMILLNAME.Name = "CMBMILLNAME"
        Me.CMBMILLNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBMILLNAME.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(43, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 14)
        Me.Label9.TabIndex = 754
        Me.Label9.Text = "Mill Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(78, 389)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 2
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
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(12, -2)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 1
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
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(106, 157)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBNAME.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(37, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 14)
        Me.Label8.TabIndex = 752
        Me.Label8.Text = "Party Name"
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(106, 129)
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
        Me.Label6.Location = New System.Drawing.Point(70, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 14)
        Me.Label6.TabIndex = 750
        Me.Label6.Text = "Color"
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(106, 101)
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
        Me.Label4.Location = New System.Drawing.Point(62, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 748
        Me.Label4.Text = "Design"
        '
        'CMBYARNQUALITY
        '
        Me.CMBYARNQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBYARNQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBYARNQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBYARNQUALITY.FormattingEnabled = True
        Me.CMBYARNQUALITY.Location = New System.Drawing.Point(106, 45)
        Me.CMBYARNQUALITY.MaxDropDownItems = 14
        Me.CMBYARNQUALITY.Name = "CMBYARNQUALITY"
        Me.CMBYARNQUALITY.Size = New System.Drawing.Size(230, 22)
        Me.CMBYARNQUALITY.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(36, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 746
        Me.Label3.Text = "Yarn Quality"
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(106, 17)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(230, 22)
        Me.CMBGODOWN.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(54, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 744
        Me.Label2.Text = "Godown"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBFINISHSUMM)
        Me.GroupBox3.Controls.Add(Me.RDBFINISHDETAIL)
        Me.GroupBox3.Controls.Add(Me.RDBSHADEDETAIL)
        Me.GroupBox3.Controls.Add(Me.RDBMILLDETAIL)
        Me.GroupBox3.Controls.Add(Me.RDBYARNDESIGNDETAIL)
        Me.GroupBox3.Controls.Add(Me.RBYARNQUALITYDETAIL)
        Me.GroupBox3.Controls.Add(Me.RBSTOCKONHAND)
        Me.GroupBox3.Controls.Add(Me.RBMILLSUMM)
        Me.GroupBox3.Controls.Add(Me.RBSHADESUMM)
        Me.GroupBox3.Controls.Add(Me.RBYARNQUALITYSUMM)
        Me.GroupBox3.Controls.Add(Me.RBDESIGNSUMM)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(29, 215)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(382, 166)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'RDBSHADEDETAIL
        '
        Me.RDBSHADEDETAIL.AutoSize = True
        Me.RDBSHADEDETAIL.Location = New System.Drawing.Point(20, 93)
        Me.RDBSHADEDETAIL.Name = "RDBSHADEDETAIL"
        Me.RDBSHADEDETAIL.Size = New System.Drawing.Size(168, 18)
        Me.RDBSHADEDETAIL.TabIndex = 3
        Me.RDBSHADEDETAIL.Text = "Yarn Shade Wise Detail Stock"
        Me.RDBSHADEDETAIL.UseVisualStyleBackColor = True
        '
        'RDBMILLDETAIL
        '
        Me.RDBMILLDETAIL.AutoSize = True
        Me.RDBMILLDETAIL.Location = New System.Drawing.Point(20, 45)
        Me.RDBMILLDETAIL.Name = "RDBMILLDETAIL"
        Me.RDBMILLDETAIL.Size = New System.Drawing.Size(157, 18)
        Me.RDBMILLDETAIL.TabIndex = 1
        Me.RDBMILLDETAIL.Text = "Yarn Mill Wise Detail Stock"
        Me.RDBMILLDETAIL.UseVisualStyleBackColor = True
        '
        'RDBYARNDESIGNDETAIL
        '
        Me.RDBYARNDESIGNDETAIL.AutoSize = True
        Me.RDBYARNDESIGNDETAIL.Location = New System.Drawing.Point(20, 69)
        Me.RDBYARNDESIGNDETAIL.Name = "RDBYARNDESIGNDETAIL"
        Me.RDBYARNDESIGNDETAIL.Size = New System.Drawing.Size(171, 18)
        Me.RDBYARNDESIGNDETAIL.TabIndex = 2
        Me.RDBYARNDESIGNDETAIL.Text = "Yarn Design Wise Detail Stock"
        Me.RDBYARNDESIGNDETAIL.UseVisualStyleBackColor = True
        '
        'RBYARNQUALITYDETAIL
        '
        Me.RBYARNQUALITYDETAIL.AutoSize = True
        Me.RBYARNQUALITYDETAIL.Checked = True
        Me.RBYARNQUALITYDETAIL.Location = New System.Drawing.Point(20, 21)
        Me.RBYARNQUALITYDETAIL.Name = "RBYARNQUALITYDETAIL"
        Me.RBYARNQUALITYDETAIL.Size = New System.Drawing.Size(173, 18)
        Me.RBYARNQUALITYDETAIL.TabIndex = 0
        Me.RBYARNQUALITYDETAIL.TabStop = True
        Me.RBYARNQUALITYDETAIL.Text = "Yarn Quality Wise Detail Stock"
        Me.RBYARNQUALITYDETAIL.UseVisualStyleBackColor = True
        '
        'RBSTOCKONHAND
        '
        Me.RBSTOCKONHAND.AutoSize = True
        Me.RBSTOCKONHAND.Location = New System.Drawing.Point(224, 141)
        Me.RBSTOCKONHAND.Name = "RBSTOCKONHAND"
        Me.RBSTOCKONHAND.Size = New System.Drawing.Size(96, 18)
        Me.RBSTOCKONHAND.TabIndex = 10
        Me.RBSTOCKONHAND.Text = "Stock On Hand"
        Me.RBSTOCKONHAND.UseVisualStyleBackColor = True
        '
        'RBMILLSUMM
        '
        Me.RBMILLSUMM.AutoSize = True
        Me.RBMILLSUMM.Location = New System.Drawing.Point(224, 45)
        Me.RBMILLSUMM.Name = "RBMILLSUMM"
        Me.RBMILLSUMM.Size = New System.Drawing.Size(101, 18)
        Me.RBMILLSUMM.TabIndex = 6
        Me.RBMILLSUMM.Text = "Mill Wise Stock"
        Me.RBMILLSUMM.UseVisualStyleBackColor = True
        '
        'RBSHADESUMM
        '
        Me.RBSHADESUMM.AutoSize = True
        Me.RBSHADESUMM.Location = New System.Drawing.Point(224, 93)
        Me.RBSHADESUMM.Name = "RBSHADESUMM"
        Me.RBSHADESUMM.Size = New System.Drawing.Size(112, 18)
        Me.RBSHADESUMM.TabIndex = 8
        Me.RBSHADESUMM.Text = "Shade Wise Stock"
        Me.RBSHADESUMM.UseVisualStyleBackColor = True
        '
        'RBYARNQUALITYSUMM
        '
        Me.RBYARNQUALITYSUMM.AutoSize = True
        Me.RBYARNQUALITYSUMM.Location = New System.Drawing.Point(224, 21)
        Me.RBYARNQUALITYSUMM.Name = "RBYARNQUALITYSUMM"
        Me.RBYARNQUALITYSUMM.Size = New System.Drawing.Size(141, 18)
        Me.RBYARNQUALITYSUMM.TabIndex = 5
        Me.RBYARNQUALITYSUMM.Text = "Yarn Quality Wise Stock"
        Me.RBYARNQUALITYSUMM.UseVisualStyleBackColor = True
        '
        'RBDESIGNSUMM
        '
        Me.RBDESIGNSUMM.AutoSize = True
        Me.RBDESIGNSUMM.Location = New System.Drawing.Point(224, 69)
        Me.RBDESIGNSUMM.Name = "RBDESIGNSUMM"
        Me.RBDESIGNSUMM.Size = New System.Drawing.Size(115, 18)
        Me.RBDESIGNSUMM.TabIndex = 7
        Me.RBDESIGNSUMM.Text = "Design Wise Stock"
        Me.RBDESIGNSUMM.UseVisualStyleBackColor = True
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(127, 455)
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
        Me.cmdexit.Location = New System.Drawing.Point(221, 455)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RDBFINISHDETAIL
        '
        Me.RDBFINISHDETAIL.AutoSize = True
        Me.RDBFINISHDETAIL.Location = New System.Drawing.Point(20, 117)
        Me.RDBFINISHDETAIL.Name = "RDBFINISHDETAIL"
        Me.RDBFINISHDETAIL.Size = New System.Drawing.Size(136, 18)
        Me.RDBFINISHDETAIL.TabIndex = 4
        Me.RDBFINISHDETAIL.Text = "Finish Box Detail Stock"
        Me.RDBFINISHDETAIL.UseVisualStyleBackColor = True
        '
        'RDBFINISHSUMM
        '
        Me.RDBFINISHSUMM.AutoSize = True
        Me.RDBFINISHSUMM.Location = New System.Drawing.Point(224, 117)
        Me.RDBFINISHSUMM.Name = "RDBFINISHSUMM"
        Me.RDBFINISHSUMM.Size = New System.Drawing.Size(104, 18)
        Me.RDBFINISHSUMM.TabIndex = 9
        Me.RDBFINISHSUMM.Text = "Finish Box Stock"
        Me.RDBFINISHSUMM.UseVisualStyleBackColor = True
        '
        'YarnStockFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(441, 492)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnStockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Stock Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMBMILLNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBYARNQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBMILLSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBSHADESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBYARNQUALITYSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBDESIGNSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents RBSTOCKONHAND As System.Windows.Forms.RadioButton
    Friend WithEvents RBYARNQUALITYDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBSHADEDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMILLDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBYARNDESIGNDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents CMBCATEGORY As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents RDBFINISHSUMM As RadioButton
    Friend WithEvents RDBFINISHDETAIL As RadioButton
End Class
