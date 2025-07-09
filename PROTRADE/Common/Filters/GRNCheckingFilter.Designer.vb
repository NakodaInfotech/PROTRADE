<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GRNCheckingFilter
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
        Me.RDBSHADEMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDBQUALITYPARTY = New System.Windows.Forms.RadioButton
        Me.RDBQUALITYMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDBPARTYQUALITY = New System.Windows.Forms.RadioButton
        Me.RDBPARTYDESIGN = New System.Windows.Forms.RadioButton
        Me.RDBPARTYMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDBMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDBLOTWISE = New System.Windows.Forms.RadioButton
        Me.RDBITEMMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDBDESIGNMONTHLY = New System.Windows.Forms.RadioButton
        Me.RDBDESIGNPARTY = New System.Windows.Forms.RadioButton
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
        Me.RDBJOBBERMONTHLY = New System.Windows.Forms.RadioButton
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
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
        Me.BlendPanel2.Size = New System.Drawing.Size(659, 482)
        Me.BlendPanel2.TabIndex = 444
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Location = New System.Drawing.Point(97, 109)
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
        Me.CMBITEMNAME.Location = New System.Drawing.Point(97, 74)
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
        Me.Label5.Location = New System.Drawing.Point(28, 78)
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
        Me.CMBCODE.Location = New System.Drawing.Point(22, 109)
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
        Me.txtDeliveryadd.Location = New System.Drawing.Point(19, 109)
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
        Me.GroupBox3.Controls.Add(Me.RDBJOBBERMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBSHADEMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBQUALITYPARTY)
        Me.GroupBox3.Controls.Add(Me.RDBQUALITYMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYQUALITY)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYDESIGN)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBLOTWISE)
        Me.GroupBox3.Controls.Add(Me.RDBITEMMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBDESIGNMONTHLY)
        Me.GroupBox3.Controls.Add(Me.RDBDESIGNPARTY)
        Me.GroupBox3.Controls.Add(Me.RDSHADE)
        Me.GroupBox3.Controls.Add(Me.RDQUALITY)
        Me.GroupBox3.Controls.Add(Me.RDJOBBER)
        Me.GroupBox3.Controls.Add(Me.RDITEM)
        Me.GroupBox3.Controls.Add(Me.RDBDESIGN)
        Me.GroupBox3.Controls.Add(Me.RDBPARTY)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(35, 127)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(588, 273)
        Me.GroupBox3.TabIndex = 657
        Me.GroupBox3.TabStop = False
        '
        'RDBSHADEMONTHLY
        '
        Me.RDBSHADEMONTHLY.AutoSize = True
        Me.RDBSHADEMONTHLY.Location = New System.Drawing.Point(23, 162)
        Me.RDBSHADEMONTHLY.Name = "RDBSHADEMONTHLY"
        Me.RDBSHADEMONTHLY.Size = New System.Drawing.Size(145, 18)
        Me.RDBSHADEMONTHLY.TabIndex = 18
        Me.RDBSHADEMONTHLY.Text = "Shade Wise (Monthly)"
        Me.RDBSHADEMONTHLY.UseVisualStyleBackColor = True
        '
        'RDBQUALITYPARTY
        '
        Me.RDBQUALITYPARTY.AutoSize = True
        Me.RDBQUALITYPARTY.Location = New System.Drawing.Point(415, 43)
        Me.RDBQUALITYPARTY.Name = "RDBQUALITYPARTY"
        Me.RDBQUALITYPARTY.Size = New System.Drawing.Size(131, 18)
        Me.RDBQUALITYPARTY.TabIndex = 16
        Me.RDBQUALITYPARTY.Text = "Quality - Party Wise"
        Me.RDBQUALITYPARTY.UseVisualStyleBackColor = True
        '
        'RDBQUALITYMONTHLY
        '
        Me.RDBQUALITYMONTHLY.AutoSize = True
        Me.RDBQUALITYMONTHLY.Location = New System.Drawing.Point(415, 67)
        Me.RDBQUALITYMONTHLY.Name = "RDBQUALITYMONTHLY"
        Me.RDBQUALITYMONTHLY.Size = New System.Drawing.Size(150, 18)
        Me.RDBQUALITYMONTHLY.TabIndex = 15
        Me.RDBQUALITYMONTHLY.Text = "Quality Wise (Monthly)"
        Me.RDBQUALITYMONTHLY.UseVisualStyleBackColor = True
        '
        'RDBPARTYQUALITY
        '
        Me.RDBPARTYQUALITY.AutoSize = True
        Me.RDBPARTYQUALITY.Location = New System.Drawing.Point(23, 67)
        Me.RDBPARTYQUALITY.Name = "RDBPARTYQUALITY"
        Me.RDBPARTYQUALITY.Size = New System.Drawing.Size(131, 18)
        Me.RDBPARTYQUALITY.TabIndex = 14
        Me.RDBPARTYQUALITY.Text = "Party - Quality Wise"
        Me.RDBPARTYQUALITY.UseVisualStyleBackColor = True
        '
        'RDBPARTYDESIGN
        '
        Me.RDBPARTYDESIGN.AutoSize = True
        Me.RDBPARTYDESIGN.Location = New System.Drawing.Point(23, 43)
        Me.RDBPARTYDESIGN.Name = "RDBPARTYDESIGN"
        Me.RDBPARTYDESIGN.Size = New System.Drawing.Size(130, 18)
        Me.RDBPARTYDESIGN.TabIndex = 13
        Me.RDBPARTYDESIGN.Text = "Party - Design Wise"
        Me.RDBPARTYDESIGN.UseVisualStyleBackColor = True
        '
        'RDBPARTYMONTHLY
        '
        Me.RDBPARTYMONTHLY.AutoSize = True
        Me.RDBPARTYMONTHLY.Location = New System.Drawing.Point(23, 91)
        Me.RDBPARTYMONTHLY.Name = "RDBPARTYMONTHLY"
        Me.RDBPARTYMONTHLY.Size = New System.Drawing.Size(137, 18)
        Me.RDBPARTYMONTHLY.TabIndex = 12
        Me.RDBPARTYMONTHLY.Text = "Party Wise (Monthly)"
        Me.RDBPARTYMONTHLY.UseVisualStyleBackColor = True
        '
        'RDBMONTHLY
        '
        Me.RDBMONTHLY.AutoSize = True
        Me.RDBMONTHLY.Location = New System.Drawing.Point(23, 233)
        Me.RDBMONTHLY.Name = "RDBMONTHLY"
        Me.RDBMONTHLY.Size = New System.Drawing.Size(91, 18)
        Me.RDBMONTHLY.TabIndex = 11
        Me.RDBMONTHLY.Text = "Month Wise"
        Me.RDBMONTHLY.UseVisualStyleBackColor = True
        '
        'RDBLOTWISE
        '
        Me.RDBLOTWISE.AutoSize = True
        Me.RDBLOTWISE.Location = New System.Drawing.Point(23, 209)
        Me.RDBLOTWISE.Name = "RDBLOTWISE"
        Me.RDBLOTWISE.Size = New System.Drawing.Size(72, 18)
        Me.RDBLOTWISE.TabIndex = 10
        Me.RDBLOTWISE.Text = "Lot Wise"
        Me.RDBLOTWISE.UseVisualStyleBackColor = True
        '
        'RDBITEMMONTHLY
        '
        Me.RDBITEMMONTHLY.AutoSize = True
        Me.RDBITEMMONTHLY.Location = New System.Drawing.Point(205, 162)
        Me.RDBITEMMONTHLY.Name = "RDBITEMMONTHLY"
        Me.RDBITEMMONTHLY.Size = New System.Drawing.Size(136, 18)
        Me.RDBITEMMONTHLY.TabIndex = 9
        Me.RDBITEMMONTHLY.Text = "Item Wise (Monthly)"
        Me.RDBITEMMONTHLY.UseVisualStyleBackColor = True
        '
        'RDBDESIGNMONTHLY
        '
        Me.RDBDESIGNMONTHLY.AutoSize = True
        Me.RDBDESIGNMONTHLY.Location = New System.Drawing.Point(205, 67)
        Me.RDBDESIGNMONTHLY.Name = "RDBDESIGNMONTHLY"
        Me.RDBDESIGNMONTHLY.Size = New System.Drawing.Size(149, 18)
        Me.RDBDESIGNMONTHLY.TabIndex = 8
        Me.RDBDESIGNMONTHLY.Text = "Design Wise (Monthly)"
        Me.RDBDESIGNMONTHLY.UseVisualStyleBackColor = True
        '
        'RDBDESIGNPARTY
        '
        Me.RDBDESIGNPARTY.AutoSize = True
        Me.RDBDESIGNPARTY.Location = New System.Drawing.Point(205, 43)
        Me.RDBDESIGNPARTY.Name = "RDBDESIGNPARTY"
        Me.RDBDESIGNPARTY.Size = New System.Drawing.Size(130, 18)
        Me.RDBDESIGNPARTY.TabIndex = 7
        Me.RDBDESIGNPARTY.Text = "Design - Party Wise"
        Me.RDBDESIGNPARTY.UseVisualStyleBackColor = True
        '
        'RDSHADE
        '
        Me.RDSHADE.AutoSize = True
        Me.RDSHADE.Location = New System.Drawing.Point(23, 138)
        Me.RDSHADE.Name = "RDSHADE"
        Me.RDSHADE.Size = New System.Drawing.Size(90, 18)
        Me.RDSHADE.TabIndex = 6
        Me.RDSHADE.Text = "Shade Wise"
        Me.RDSHADE.UseVisualStyleBackColor = True
        '
        'RDQUALITY
        '
        Me.RDQUALITY.AutoSize = True
        Me.RDQUALITY.Location = New System.Drawing.Point(415, 19)
        Me.RDQUALITY.Name = "RDQUALITY"
        Me.RDQUALITY.Size = New System.Drawing.Size(95, 18)
        Me.RDQUALITY.TabIndex = 5
        Me.RDQUALITY.Text = "Quality Wise"
        Me.RDQUALITY.UseVisualStyleBackColor = True
        '
        'RDJOBBER
        '
        Me.RDJOBBER.AutoSize = True
        Me.RDJOBBER.Location = New System.Drawing.Point(415, 138)
        Me.RDJOBBER.Name = "RDJOBBER"
        Me.RDJOBBER.Size = New System.Drawing.Size(92, 18)
        Me.RDJOBBER.TabIndex = 4
        Me.RDJOBBER.Text = "Jobber Wise"
        Me.RDJOBBER.UseVisualStyleBackColor = True
        '
        'RDITEM
        '
        Me.RDITEM.AutoSize = True
        Me.RDITEM.Location = New System.Drawing.Point(205, 138)
        Me.RDITEM.Name = "RDITEM"
        Me.RDITEM.Size = New System.Drawing.Size(81, 18)
        Me.RDITEM.TabIndex = 3
        Me.RDITEM.Text = "Item Wise"
        Me.RDITEM.UseVisualStyleBackColor = True
        '
        'RDBDESIGN
        '
        Me.RDBDESIGN.AutoSize = True
        Me.RDBDESIGN.Location = New System.Drawing.Point(205, 19)
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
        Me.RDBPARTY.Location = New System.Drawing.Point(23, 19)
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
        Me.Label10.Location = New System.Drawing.Point(52, 50)
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
        Me.CMBJOBBER.Location = New System.Drawing.Point(97, 46)
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
        Me.cmbacccode.Location = New System.Drawing.Point(21, 109)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(21, 110)
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
        Me.Label4.Location = New System.Drawing.Point(347, 78)
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
        Me.CMBSHADE.Location = New System.Drawing.Point(390, 74)
        Me.CMBSHADE.MaxDropDownItems = 14
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(230, 22)
        Me.CMBSHADE.TabIndex = 647
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(18, 112)
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
        Me.Label3.Location = New System.Drawing.Point(343, 50)
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
        Me.CMBDESIGN.Location = New System.Drawing.Point(390, 46)
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
        Me.chkdate.Location = New System.Drawing.Point(47, 403)
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
        Me.GroupBox1.Location = New System.Drawing.Point(39, 406)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
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
        Me.CMBQUALITY.Location = New System.Drawing.Point(390, 18)
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
        Me.Label2.Location = New System.Drawing.Point(342, 22)
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
        Me.CMBNAME.Location = New System.Drawing.Point(97, 18)
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
        Me.Label9.Location = New System.Drawing.Point(56, 22)
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
        Me.cmdshow.Location = New System.Drawing.Point(378, 431)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(87, 28)
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
        Me.cmdexit.Location = New System.Drawing.Point(470, 431)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(87, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RDBJOBBERMONTHLY
        '
        Me.RDBJOBBERMONTHLY.AutoSize = True
        Me.RDBJOBBERMONTHLY.Location = New System.Drawing.Point(415, 162)
        Me.RDBJOBBERMONTHLY.Name = "RDBJOBBERMONTHLY"
        Me.RDBJOBBERMONTHLY.Size = New System.Drawing.Size(147, 18)
        Me.RDBJOBBERMONTHLY.TabIndex = 19
        Me.RDBJOBBERMONTHLY.Text = "Jobber Wise (Monthly)"
        Me.RDBJOBBERMONTHLY.UseVisualStyleBackColor = True
        '
        'GRNCheckingFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(659, 482)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GRNCheckingFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GRN Checking Filter"
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
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtDeliveryadd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RDSHADE As System.Windows.Forms.RadioButton
    Friend WithEvents RDQUALITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDJOBBER As System.Windows.Forms.RadioButton
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
    Friend WithEvents RDBDESIGNPARTY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBDESIGNMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBITEMMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBLOTWISE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTYMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTYDESIGN As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTYQUALITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBQUALITYPARTY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBQUALITYMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBSHADEMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBJOBBERMONTHLY As System.Windows.Forms.RadioButton
End Class
