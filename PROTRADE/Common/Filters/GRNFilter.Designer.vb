<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GRNFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RDBPENDING = New System.Windows.Forms.RadioButton
        Me.RDBMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDSHADE = New System.Windows.Forms.RadioButton
        Me.RDQUALITY = New System.Windows.Forms.RadioButton
        Me.RDJOBBER = New System.Windows.Forms.RadioButton
        Me.RDITEM = New System.Windows.Forms.RadioButton
        Me.RDBDESIGN = New System.Windows.Forms.RadioButton
        Me.RDBPARTY = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMBJOBBER = New System.Windows.Forms.ComboBox
        Me.cmbacccode = New System.Windows.Forms.ComboBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CMBSHADE = New System.Windows.Forms.ComboBox
        Me.TXTTEMP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdshow = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label6)
        Me.BlendPanel2.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel2.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.Label10)
        Me.BlendPanel2.Controls.Add(Me.CMBJOBBER)
        Me.BlendPanel2.Controls.Add(Me.cmbacccode)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.CMBDESIGN)
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
        Me.BlendPanel2.Size = New System.Drawing.Size(349, 495)
        Me.BlendPanel2.TabIndex = 443
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Location = New System.Drawing.Point(88, 226)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(77, 19)
        Me.CHKSUMMARY.TabIndex = 741
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(88, 74)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBITEMNAME.TabIndex = 739
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
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
        Me.CMBCODE.Location = New System.Drawing.Point(43, 466)
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
        Me.txtDeliveryadd.Location = New System.Drawing.Point(40, 466)
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
        Me.GroupBox3.Controls.Add(Me.RDBMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDSHADE)
        Me.GroupBox3.Controls.Add(Me.RDQUALITY)
        Me.GroupBox3.Controls.Add(Me.RDJOBBER)
        Me.GroupBox3.Controls.Add(Me.RDITEM)
        Me.GroupBox3.Controls.Add(Me.RDBDESIGN)
        Me.GroupBox3.Controls.Add(Me.RDBPARTY)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(30, 240)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 128)
        Me.GroupBox3.TabIndex = 657
        Me.GroupBox3.TabStop = False
        '
        'RDBPENDING
        '
        Me.RDBPENDING.AutoSize = True
        Me.RDBPENDING.Location = New System.Drawing.Point(156, 91)
        Me.RDBPENDING.Name = "RDBPENDING"
        Me.RDBPENDING.Size = New System.Drawing.Size(129, 18)
        Me.RDBPENDING.TabIndex = 8
        Me.RDBPENDING.Text = "Pending GRN Check"
        Me.RDBPENDING.UseVisualStyleBackColor = True
        '
        'RDBMONTHLY
        '
        Me.RDBMONTHLY.AutoSize = True
        Me.RDBMONTHLY.Location = New System.Drawing.Point(26, 91)
        Me.RDBMONTHLY.Name = "RDBMONTHLY"
        Me.RDBMONTHLY.Size = New System.Drawing.Size(69, 18)
        Me.RDBMONTHLY.TabIndex = 7
        Me.RDBMONTHLY.Text = "Monthly"
        Me.RDBMONTHLY.UseVisualStyleBackColor = True
        '
        'RDSHADE
        '
        Me.RDSHADE.AutoSize = True
        Me.RDSHADE.Location = New System.Drawing.Point(156, 67)
        Me.RDSHADE.Name = "RDSHADE"
        Me.RDSHADE.Size = New System.Drawing.Size(90, 18)
        Me.RDSHADE.TabIndex = 6
        Me.RDSHADE.Text = "Shade Wise"
        Me.RDSHADE.UseVisualStyleBackColor = True
        '
        'RDQUALITY
        '
        Me.RDQUALITY.AutoSize = True
        Me.RDQUALITY.Location = New System.Drawing.Point(156, 19)
        Me.RDQUALITY.Name = "RDQUALITY"
        Me.RDQUALITY.Size = New System.Drawing.Size(95, 18)
        Me.RDQUALITY.TabIndex = 5
        Me.RDQUALITY.Text = "Quality Wise"
        Me.RDQUALITY.UseVisualStyleBackColor = True
        '
        'RDJOBBER
        '
        Me.RDJOBBER.AutoSize = True
        Me.RDJOBBER.Location = New System.Drawing.Point(26, 43)
        Me.RDJOBBER.Name = "RDJOBBER"
        Me.RDJOBBER.Size = New System.Drawing.Size(92, 18)
        Me.RDJOBBER.TabIndex = 4
        Me.RDJOBBER.Text = "Jobber Wise"
        Me.RDJOBBER.UseVisualStyleBackColor = True
        '
        'RDITEM
        '
        Me.RDITEM.AutoSize = True
        Me.RDITEM.Location = New System.Drawing.Point(26, 67)
        Me.RDITEM.Name = "RDITEM"
        Me.RDITEM.Size = New System.Drawing.Size(81, 18)
        Me.RDITEM.TabIndex = 3
        Me.RDITEM.Text = "Item Wise"
        Me.RDITEM.UseVisualStyleBackColor = True
        '
        'RDBDESIGN
        '
        Me.RDBDESIGN.AutoSize = True
        Me.RDBDESIGN.Location = New System.Drawing.Point(156, 43)
        Me.RDBDESIGN.Name = "RDBDESIGN"
        Me.RDBDESIGN.Size = New System.Drawing.Size(94, 18)
        Me.RDBDESIGN.TabIndex = 1
        Me.RDBDESIGN.Text = "Design Wise"
        Me.RDBDESIGN.UseVisualStyleBackColor = True
        '
        'RDBPARTY
        '
        Me.RDBPARTY.AutoSize = True
        Me.RDBPARTY.Checked = True
        Me.RDBPARTY.Location = New System.Drawing.Point(26, 19)
        Me.RDBPARTY.Name = "RDBPARTY"
        Me.RDBPARTY.Size = New System.Drawing.Size(82, 18)
        Me.RDBPARTY.TabIndex = 0
        Me.RDBPARTY.TabStop = True
        Me.RDBPARTY.Text = "Party Wise"
        Me.RDBPARTY.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(43, 50)
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
        Me.CMBJOBBER.Location = New System.Drawing.Point(88, 46)
        Me.CMBJOBBER.MaxDropDownItems = 14
        Me.CMBJOBBER.Name = "CMBJOBBER"
        Me.CMBJOBBER.Size = New System.Drawing.Size(230, 22)
        Me.CMBJOBBER.TabIndex = 651
        '
        'cmbacccode
        '
        Me.cmbacccode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbacccode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbacccode.BackColor = System.Drawing.Color.White
        Me.cmbacccode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbacccode.FormattingEnabled = True
        Me.cmbacccode.Location = New System.Drawing.Point(42, 466)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(42, 467)
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
        Me.Label4.Location = New System.Drawing.Point(45, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 14)
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
        Me.CMBSHADE.Location = New System.Drawing.Point(88, 158)
        Me.CMBSHADE.MaxDropDownItems = 14
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(230, 22)
        Me.CMBSHADE.TabIndex = 647
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(39, 469)
        Me.TXTTEMP.Name = "TXTTEMP"
        Me.TXTTEMP.Size = New System.Drawing.Size(30, 23)
        Me.TXTTEMP.TabIndex = 646
        Me.TXTTEMP.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(41, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 639
        Me.Label3.Text = "Design"
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.BackColor = System.Drawing.Color.White
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(88, 130)
        Me.CMBDESIGN.MaxDropDownItems = 14
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(230, 22)
        Me.CMBDESIGN.TabIndex = 638
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(43, 380)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 443
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
        Me.GroupBox1.Location = New System.Drawing.Point(35, 383)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 55)
        Me.GroupBox1.TabIndex = 444
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
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(88, 102)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(230, 22)
        Me.CMBQUALITY.TabIndex = 438
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(40, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 439
        Me.Label2.Text = "Quality"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(88, 18)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBNAME.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(47, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 14)
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
        Me.cmdshow.Location = New System.Drawing.Point(83, 453)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 30)
        Me.cmdshow.TabIndex = 7
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
        Me.cmdexit.Location = New System.Drawing.Point(177, 453)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 30)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(55, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 14)
        Me.Label6.TabIndex = 743
        Me.Label6.Text = "Type"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.White
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Location = New System.Drawing.Point(88, 186)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(230, 22)
        Me.CMBTYPE.TabIndex = 742
        '
        'GRNFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(349, 495)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GRNFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GRN Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
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
    Friend WithEvents RDITEM As System.Windows.Forms.RadioButton
    Friend WithEvents RDBDESIGN As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTY As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBJOBBER As System.Windows.Forms.ComboBox
    Friend WithEvents cmbacccode As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
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
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents RDJOBBER As System.Windows.Forms.RadioButton
    Friend WithEvents RDSHADE As System.Windows.Forms.RadioButton
    Friend WithEvents RDQUALITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
End Class
