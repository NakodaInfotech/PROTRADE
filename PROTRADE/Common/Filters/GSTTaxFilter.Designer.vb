<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GSTTaxFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBSTATE = New System.Windows.Forms.ComboBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.txtDeliveryadd = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBGSTR2MATCHREPORT = New System.Windows.Forms.RadioButton()
        Me.RBGSTHSNPURDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBGSTHSNDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBITC4 = New System.Windows.Forms.RadioButton()
        Me.RBGSTPURHSNSUMM = New System.Windows.Forms.RadioButton()
        Me.RBGSTSTATEPURSUMM = New System.Windows.Forms.RadioButton()
        Me.RBGSTSTATESALESUMM = New System.Windows.Forms.RadioButton()
        Me.RBGSTPARTYSALESUMM = New System.Windows.Forms.RadioButton()
        Me.RBGSTPARTYPURSUMM = New System.Windows.Forms.RadioButton()
        Me.RBGSTDNDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBGSTCNDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBGSTR1 = New System.Windows.Forms.RadioButton()
        Me.RBGSTPURCHASEDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBGSTSALEDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBGSTSUMMARY = New System.Windows.Forms.RadioButton()
        Me.cmbacccode = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBREGISTER = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.CMBNAME)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.CMBSTATE)
        Me.BlendPanel2.Controls.Add(Me.CMBCODE)
        Me.BlendPanel2.Controls.Add(Me.txtDeliveryadd)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmbacccode)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBREGISTER)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(764, 478)
        Me.BlendPanel2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(97, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 746
        Me.Label2.Text = "Party Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.White
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(167, 72)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(314, 22)
        Me.CMBNAME.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(95, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 744
        Me.Label3.Text = "State Name"
        '
        'CMBSTATE
        '
        Me.CMBSTATE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTATE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTATE.BackColor = System.Drawing.Color.White
        Me.CMBSTATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTATE.FormattingEnabled = True
        Me.CMBSTATE.Items.AddRange(New Object() {""})
        Me.CMBSTATE.Location = New System.Drawing.Point(167, 44)
        Me.CMBSTATE.Name = "CMBSTATE"
        Me.CMBSTATE.Size = New System.Drawing.Size(314, 22)
        Me.CMBSTATE.TabIndex = 2
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Items.AddRange(New Object() {"C/R", "O/R"})
        Me.CMBCODE.Location = New System.Drawing.Point(867, 12)
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
        Me.txtDeliveryadd.Location = New System.Drawing.Point(865, 12)
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
        Me.GroupBox3.Controls.Add(Me.RBGSTR2MATCHREPORT)
        Me.GroupBox3.Controls.Add(Me.RBGSTHSNPURDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBGSTHSNDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBITC4)
        Me.GroupBox3.Controls.Add(Me.RBGSTPURHSNSUMM)
        Me.GroupBox3.Controls.Add(Me.RBGSTSTATEPURSUMM)
        Me.GroupBox3.Controls.Add(Me.RBGSTSTATESALESUMM)
        Me.GroupBox3.Controls.Add(Me.RBGSTPARTYSALESUMM)
        Me.GroupBox3.Controls.Add(Me.RBGSTPARTYPURSUMM)
        Me.GroupBox3.Controls.Add(Me.RBGSTDNDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBGSTCNDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBGSTR1)
        Me.GroupBox3.Controls.Add(Me.RBGSTPURCHASEDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBGSTSALEDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBGSTSUMMARY)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(48, 108)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(669, 241)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'RBGSTR2MATCHREPORT
        '
        Me.RBGSTR2MATCHREPORT.AutoSize = True
        Me.RBGSTR2MATCHREPORT.Location = New System.Drawing.Point(18, 183)
        Me.RBGSTR2MATCHREPORT.Name = "RBGSTR2MATCHREPORT"
        Me.RBGSTR2MATCHREPORT.Size = New System.Drawing.Size(128, 18)
        Me.RBGSTR2MATCHREPORT.TabIndex = 2
        Me.RBGSTR2MATCHREPORT.Text = "GSTR2 Match Report"
        Me.RBGSTR2MATCHREPORT.UseVisualStyleBackColor = True
        '
        'RBGSTHSNPURDETAILS
        '
        Me.RBGSTHSNPURDETAILS.AutoSize = True
        Me.RBGSTHSNPURDETAILS.Location = New System.Drawing.Point(226, 45)
        Me.RBGSTHSNPURDETAILS.Name = "RBGSTHSNPURDETAILS"
        Me.RBGSTHSNPURDETAILS.Size = New System.Drawing.Size(181, 18)
        Me.RBGSTHSNPURDETAILS.TabIndex = 8
        Me.RBGSTHSNPURDETAILS.Text = "GST HSN Wise Purchase Details"
        Me.RBGSTHSNPURDETAILS.UseVisualStyleBackColor = True
        '
        'RBGSTHSNDETAILS
        '
        Me.RBGSTHSNDETAILS.AutoSize = True
        Me.RBGSTHSNDETAILS.Location = New System.Drawing.Point(226, 69)
        Me.RBGSTHSNDETAILS.Name = "RBGSTHSNDETAILS"
        Me.RBGSTHSNDETAILS.Size = New System.Drawing.Size(158, 18)
        Me.RBGSTHSNDETAILS.TabIndex = 9
        Me.RBGSTHSNDETAILS.Text = "GST HSN Wise Sale Details"
        Me.RBGSTHSNDETAILS.UseVisualStyleBackColor = True
        '
        'RBITC4
        '
        Me.RBITC4.AutoSize = True
        Me.RBITC4.Location = New System.Drawing.Point(226, 93)
        Me.RBITC4.Name = "RBITC4"
        Me.RBITC4.Size = New System.Drawing.Size(50, 18)
        Me.RBITC4.TabIndex = 10
        Me.RBITC4.Text = "ITC-4"
        Me.RBITC4.UseVisualStyleBackColor = True
        '
        'RBGSTPURHSNSUMM
        '
        Me.RBGSTPURHSNSUMM.AutoSize = True
        Me.RBGSTPURHSNSUMM.Location = New System.Drawing.Point(226, 21)
        Me.RBGSTPURHSNSUMM.Name = "RBGSTPURHSNSUMM"
        Me.RBGSTPURHSNSUMM.Size = New System.Drawing.Size(166, 18)
        Me.RBGSTPURHSNSUMM.TabIndex = 7
        Me.RBGSTPURHSNSUMM.Text = "GST Purchase HSN Summary"
        Me.RBGSTPURHSNSUMM.UseVisualStyleBackColor = True
        '
        'RBGSTSTATEPURSUMM
        '
        Me.RBGSTSTATEPURSUMM.AutoSize = True
        Me.RBGSTSTATEPURSUMM.Location = New System.Drawing.Point(432, 93)
        Me.RBGSTSTATEPURSUMM.Name = "RBGSTSTATEPURSUMM"
        Me.RBGSTSTATEPURSUMM.Size = New System.Drawing.Size(199, 18)
        Me.RBGSTSTATEPURSUMM.TabIndex = 14
        Me.RBGSTSTATEPURSUMM.Text = "GST State Wise Purchase Summary"
        Me.RBGSTSTATEPURSUMM.UseVisualStyleBackColor = True
        '
        'RBGSTSTATESALESUMM
        '
        Me.RBGSTSTATESALESUMM.AutoSize = True
        Me.RBGSTSTATESALESUMM.Location = New System.Drawing.Point(432, 69)
        Me.RBGSTSTATESALESUMM.Name = "RBGSTSTATESALESUMM"
        Me.RBGSTSTATESALESUMM.Size = New System.Drawing.Size(176, 18)
        Me.RBGSTSTATESALESUMM.TabIndex = 13
        Me.RBGSTSTATESALESUMM.Text = "GST State Wise Sale Summary"
        Me.RBGSTSTATESALESUMM.UseVisualStyleBackColor = True
        '
        'RBGSTPARTYSALESUMM
        '
        Me.RBGSTPARTYSALESUMM.AutoSize = True
        Me.RBGSTPARTYSALESUMM.Location = New System.Drawing.Point(432, 21)
        Me.RBGSTPARTYSALESUMM.Name = "RBGSTPARTYSALESUMM"
        Me.RBGSTPARTYSALESUMM.Size = New System.Drawing.Size(175, 18)
        Me.RBGSTPARTYSALESUMM.TabIndex = 11
        Me.RBGSTPARTYSALESUMM.Text = "GST Party Wise Sale Summary"
        Me.RBGSTPARTYSALESUMM.UseVisualStyleBackColor = True
        '
        'RBGSTPARTYPURSUMM
        '
        Me.RBGSTPARTYPURSUMM.AutoSize = True
        Me.RBGSTPARTYPURSUMM.Location = New System.Drawing.Point(432, 45)
        Me.RBGSTPARTYPURSUMM.Name = "RBGSTPARTYPURSUMM"
        Me.RBGSTPARTYPURSUMM.Size = New System.Drawing.Size(198, 18)
        Me.RBGSTPARTYPURSUMM.TabIndex = 12
        Me.RBGSTPARTYPURSUMM.Text = "GST Party Wise Purchase Summary"
        Me.RBGSTPARTYPURSUMM.UseVisualStyleBackColor = True
        '
        'RBGSTDNDETAILS
        '
        Me.RBGSTDNDETAILS.AutoSize = True
        Me.RBGSTDNDETAILS.Location = New System.Drawing.Point(18, 93)
        Me.RBGSTDNDETAILS.Name = "RBGSTDNDETAILS"
        Me.RBGSTDNDETAILS.Size = New System.Drawing.Size(138, 18)
        Me.RBGSTDNDETAILS.TabIndex = 6
        Me.RBGSTDNDETAILS.Text = "GST Debit Note Details"
        Me.RBGSTDNDETAILS.UseVisualStyleBackColor = True
        '
        'RBGSTCNDETAILS
        '
        Me.RBGSTCNDETAILS.AutoSize = True
        Me.RBGSTCNDETAILS.Location = New System.Drawing.Point(18, 69)
        Me.RBGSTCNDETAILS.Name = "RBGSTCNDETAILS"
        Me.RBGSTCNDETAILS.Size = New System.Drawing.Size(141, 18)
        Me.RBGSTCNDETAILS.TabIndex = 5
        Me.RBGSTCNDETAILS.Text = "GST Credit Note Details"
        Me.RBGSTCNDETAILS.UseVisualStyleBackColor = True
        '
        'RBGSTR1
        '
        Me.RBGSTR1.AutoSize = True
        Me.RBGSTR1.Location = New System.Drawing.Point(18, 159)
        Me.RBGSTR1.Name = "RBGSTR1"
        Me.RBGSTR1.Size = New System.Drawing.Size(68, 18)
        Me.RBGSTR1.TabIndex = 1
        Me.RBGSTR1.Text = "GSTR - 1"
        Me.RBGSTR1.UseVisualStyleBackColor = True
        '
        'RBGSTPURCHASEDETAILS
        '
        Me.RBGSTPURCHASEDETAILS.AutoSize = True
        Me.RBGSTPURCHASEDETAILS.Location = New System.Drawing.Point(18, 45)
        Me.RBGSTPURCHASEDETAILS.Name = "RBGSTPURCHASEDETAILS"
        Me.RBGSTPURCHASEDETAILS.Size = New System.Drawing.Size(129, 18)
        Me.RBGSTPURCHASEDETAILS.TabIndex = 4
        Me.RBGSTPURCHASEDETAILS.Text = "GST Purchase Details"
        Me.RBGSTPURCHASEDETAILS.UseVisualStyleBackColor = True
        '
        'RBGSTSALEDETAILS
        '
        Me.RBGSTSALEDETAILS.AutoSize = True
        Me.RBGSTSALEDETAILS.Location = New System.Drawing.Point(18, 21)
        Me.RBGSTSALEDETAILS.Name = "RBGSTSALEDETAILS"
        Me.RBGSTSALEDETAILS.Size = New System.Drawing.Size(106, 18)
        Me.RBGSTSALEDETAILS.TabIndex = 3
        Me.RBGSTSALEDETAILS.Text = "GST Sale Details"
        Me.RBGSTSALEDETAILS.UseVisualStyleBackColor = True
        '
        'RBGSTSUMMARY
        '
        Me.RBGSTSUMMARY.AutoSize = True
        Me.RBGSTSUMMARY.Location = New System.Drawing.Point(18, 135)
        Me.RBGSTSUMMARY.Name = "RBGSTSUMMARY"
        Me.RBGSTSUMMARY.Size = New System.Drawing.Size(119, 18)
        Me.RBGSTSUMMARY.TabIndex = 0
        Me.RBGSTSUMMARY.Text = "GST Summary (3B)"
        Me.RBGSTSUMMARY.UseVisualStyleBackColor = True
        '
        'cmbacccode
        '
        Me.cmbacccode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbacccode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbacccode.BackColor = System.Drawing.Color.White
        Me.cmbacccode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbacccode.FormattingEnabled = True
        Me.cmbacccode.Location = New System.Drawing.Point(867, 12)
        Me.cmbacccode.MaxDropDownItems = 14
        Me.cmbacccode.Name = "cmbacccode"
        Me.cmbacccode.Size = New System.Drawing.Size(30, 22)
        Me.cmbacccode.TabIndex = 650
        Me.cmbacccode.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(867, 13)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(30, 20)
        Me.txtadd.TabIndex = 649
        Me.txtadd.Visible = False
        '
        'TXTTEMP
        '
        Me.TXTTEMP.Location = New System.Drawing.Point(864, 15)
        Me.TXTTEMP.Name = "TXTTEMP"
        Me.TXTTEMP.Size = New System.Drawing.Size(30, 20)
        Me.TXTTEMP.TabIndex = 646
        Me.TXTTEMP.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(53, 352)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 5
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
        Me.GroupBox1.Location = New System.Drawing.Point(48, 355)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 6
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
        'CMBREGISTER
        '
        Me.CMBREGISTER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBREGISTER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBREGISTER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBREGISTER.FormattingEnabled = True
        Me.CMBREGISTER.Location = New System.Drawing.Point(167, 16)
        Me.CMBREGISTER.MaxDropDownItems = 14
        Me.CMBREGISTER.Name = "CMBREGISTER"
        Me.CMBREGISTER.Size = New System.Drawing.Size(230, 22)
        Me.CMBREGISTER.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(113, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 14)
        Me.Label9.TabIndex = 419
        Me.Label9.Text = "Register"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(367, 379)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
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
        Me.cmdexit.Location = New System.Drawing.Point(461, 379)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'GSTTaxFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 478)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Name = "GSTTaxFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GST Tax Filter"
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
    Friend WithEvents RBGSTSALEDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents cmbacccode As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBREGISTER As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents RBGSTPURCHASEDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTR1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBSTATE As System.Windows.Forms.ComboBox
    Friend WithEvents RBGSTSTATEPURSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTSTATESALESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTPARTYSALESUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTPARTYPURSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTDNDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents RBGSTCNDETAILS As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents RBGPUR As RadioButton
    Friend WithEvents RBGSTPURHSNSUMM As RadioButton
    Friend WithEvents RBITC4 As RadioButton
    Friend WithEvents RBGSTHSNPURDETAILS As RadioButton
    Friend WithEvents RBGSTHSNDETAILS As RadioButton
    Friend WithEvents RBGSTR2MATCHREPORT As RadioButton
End Class
