<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeductTDS
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.PARTYBILLDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTTDSROUNDOFF = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTJVNO = New System.Windows.Forms.TextBox()
        Me.TXTINITIALS = New System.Windows.Forms.TextBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTREGISTER = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTTDSAMT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTTDSPER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTTAXABLEAMT = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CMBTDS = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXTPARTYBILLNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BILLDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TXTGTOTAL = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTGTOTAL)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.PARTYBILLDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTTDSROUNDOFF)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTJVNO)
        Me.BlendPanel1.Controls.Add(Me.TXTINITIALS)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTREGISTER)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTTDSAMT)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTTDSPER)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTTAXABLEAMT)
        Me.BlendPanel1.Controls.Add(Me.Label36)
        Me.BlendPanel1.Controls.Add(Me.CMBTDS)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.TXTPARTYBILLNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.BILLDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLNO)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(427, 390)
        Me.BlendPanel1.TabIndex = 0
        '
        'PARTYBILLDATE
        '
        Me.PARTYBILLDATE.AsciiOnly = True
        Me.PARTYBILLDATE.BackColor = System.Drawing.Color.Linen
        Me.PARTYBILLDATE.Enabled = False
        Me.PARTYBILLDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PARTYBILLDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.PARTYBILLDATE.Location = New System.Drawing.Point(286, 87)
        Me.PARTYBILLDATE.Mask = "00/00/0000"
        Me.PARTYBILLDATE.Name = "PARTYBILLDATE"
        Me.PARTYBILLDATE.Size = New System.Drawing.Size(95, 23)
        Me.PARTYBILLDATE.TabIndex = 563
        Me.PARTYBILLDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PARTYBILLDATE.ValidatingType = GetType(Date)
        '
        'TXTTDSROUNDOFF
        '
        Me.TXTTDSROUNDOFF.BackColor = System.Drawing.Color.Linen
        Me.TXTTDSROUNDOFF.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTDSROUNDOFF.Location = New System.Drawing.Point(286, 232)
        Me.TXTTDSROUNDOFF.Name = "TXTTDSROUNDOFF"
        Me.TXTTDSROUNDOFF.Size = New System.Drawing.Size(95, 23)
        Me.TXTTDSROUNDOFF.TabIndex = 3
        Me.TXTTDSROUNDOFF.Text = "0.00"
        Me.TXTTDSROUNDOFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(199, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 15)
        Me.Label9.TabIndex = 562
        Me.Label9.Text = "TDS Round Off"
        '
        'TXTJVNO
        '
        Me.TXTJVNO.BackColor = System.Drawing.Color.Linen
        Me.TXTJVNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJVNO.Location = New System.Drawing.Point(255, 0)
        Me.TXTJVNO.Name = "TXTJVNO"
        Me.TXTJVNO.ReadOnly = True
        Me.TXTJVNO.Size = New System.Drawing.Size(23, 23)
        Me.TXTJVNO.TabIndex = 560
        Me.TXTJVNO.TabStop = False
        Me.TXTJVNO.Visible = False
        '
        'TXTINITIALS
        '
        Me.TXTINITIALS.BackColor = System.Drawing.Color.Linen
        Me.TXTINITIALS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINITIALS.Location = New System.Drawing.Point(201, 0)
        Me.TXTINITIALS.Name = "TXTINITIALS"
        Me.TXTINITIALS.ReadOnly = True
        Me.TXTINITIALS.Size = New System.Drawing.Size(23, 23)
        Me.TXTINITIALS.TabIndex = 559
        Me.TXTINITIALS.TabStop = False
        Me.TXTINITIALS.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.Linen
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(122, 0)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(23, 23)
        Me.TXTADD.TabIndex = 558
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.Location = New System.Drawing.Point(96, 116)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(285, 23)
        Me.TXTNAME.TabIndex = 557
        Me.TXTNAME.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(43, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 556
        Me.Label8.Text = "Register"
        '
        'TXTREGISTER
        '
        Me.TXTREGISTER.BackColor = System.Drawing.Color.Linen
        Me.TXTREGISTER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREGISTER.Location = New System.Drawing.Point(96, 29)
        Me.TXTREGISTER.Name = "TXTREGISTER"
        Me.TXTREGISTER.ReadOnly = True
        Me.TXTREGISTER.Size = New System.Drawing.Size(285, 23)
        Me.TXTREGISTER.TabIndex = 555
        Me.TXTREGISTER.TabStop = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(216, 274)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(89, 27)
        Me.cmdclear.TabIndex = 5
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(122, 274)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(89, 27)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(171, 307)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(89, 27)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTTDSAMT
        '
        Me.TXTTDSAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTDSAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTDSAMT.Location = New System.Drawing.Point(286, 203)
        Me.TXTTDSAMT.Name = "TXTTDSAMT"
        Me.TXTTDSAMT.ReadOnly = True
        Me.TXTTDSAMT.Size = New System.Drawing.Size(95, 23)
        Me.TXTTDSAMT.TabIndex = 3
        Me.TXTTDSAMT.TabStop = False
        Me.TXTTDSAMT.Text = "0.00"
        Me.TXTTDSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(212, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 15)
        Me.Label7.TabIndex = 551
        Me.Label7.Text = "TDS Amount"
        '
        'TXTTDSPER
        '
        Me.TXTTDSPER.BackColor = System.Drawing.Color.White
        Me.TXTTDSPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTDSPER.Location = New System.Drawing.Point(96, 232)
        Me.TXTTDSPER.Name = "TXTTDSPER"
        Me.TXTTDSPER.Size = New System.Drawing.Size(95, 23)
        Me.TXTTDSPER.TabIndex = 2
        Me.TXTTDSPER.Text = "0.00"
        Me.TXTTDSPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(58, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 549
        Me.Label4.Text = "Tax %"
        '
        'TXTTAXABLEAMT
        '
        Me.TXTTAXABLEAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTAXABLEAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTAXABLEAMT.Location = New System.Drawing.Point(96, 203)
        Me.TXTTAXABLEAMT.Name = "TXTTAXABLEAMT"
        Me.TXTTAXABLEAMT.ReadOnly = True
        Me.TXTTAXABLEAMT.Size = New System.Drawing.Size(95, 23)
        Me.TXTTAXABLEAMT.TabIndex = 1
        Me.TXTTAXABLEAMT.Text = "0.00"
        Me.TXTTAXABLEAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(25, 207)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(69, 15)
        Me.Label36.TabIndex = 547
        Me.Label36.Text = "Bill Amount"
        '
        'CMBTDS
        '
        Me.CMBTDS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTDS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTDS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTDS.FormattingEnabled = True
        Me.CMBTDS.Location = New System.Drawing.Point(96, 145)
        Me.CMBTDS.MaxDropDownItems = 14
        Me.CMBTDS.Name = "CMBTDS"
        Me.CMBTDS.Size = New System.Drawing.Size(285, 23)
        Me.CMBTDS.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(46, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "TDS A/c"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(56, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "Name"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(198, 91)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 15)
        Me.Label18.TabIndex = 431
        Me.Label18.Text = "Party Bill Date"
        '
        'TXTPARTYBILLNO
        '
        Me.TXTPARTYBILLNO.BackColor = System.Drawing.Color.Linen
        Me.TXTPARTYBILLNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPARTYBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPARTYBILLNO.Location = New System.Drawing.Point(96, 87)
        Me.TXTPARTYBILLNO.Name = "TXTPARTYBILLNO"
        Me.TXTPARTYBILLNO.ReadOnly = True
        Me.TXTPARTYBILLNO.Size = New System.Drawing.Size(95, 23)
        Me.TXTPARTYBILLNO.TabIndex = 428
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "Party Bill No."
        '
        'BILLDATE
        '
        Me.BILLDATE.Enabled = False
        Me.BILLDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BILLDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.BILLDATE.Location = New System.Drawing.Point(286, 58)
        Me.BILLDATE.Name = "BILLDATE"
        Me.BILLDATE.Size = New System.Drawing.Size(95, 23)
        Me.BILLDATE.TabIndex = 414
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.BackColor = System.Drawing.Color.Linen
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.Location = New System.Drawing.Point(96, 58)
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.ReadOnly = True
        Me.TXTBILLNO.Size = New System.Drawing.Size(95, 23)
        Me.TXTBILLNO.TabIndex = 413
        Me.TXTBILLNO.TabStop = False
        Me.TXTBILLNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(252, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 416
        Me.Label6.Text = "Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(47, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 415
        Me.Label5.Text = "Inv. No."
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'TXTGTOTAL
        '
        Me.TXTGTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTGTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGTOTAL.Location = New System.Drawing.Point(96, 174)
        Me.TXTGTOTAL.Name = "TXTGTOTAL"
        Me.TXTGTOTAL.ReadOnly = True
        Me.TXTGTOTAL.Size = New System.Drawing.Size(95, 23)
        Me.TXTGTOTAL.TabIndex = 564
        Me.TXTGTOTAL.Text = "0.00"
        Me.TXTGTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(26, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 15)
        Me.Label10.TabIndex = 565
        Me.Label10.Text = "Grand Total"
        '
        'DeductTDS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(427, 390)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DeductTDS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deduct TDS"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents BILLDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXTPARTYBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBTDS As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTTDSAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTTDSPER As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTTAXABLEAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTREGISTER As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTINITIALS As System.Windows.Forms.TextBox
    Friend WithEvents TXTJVNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTTDSROUNDOFF As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PARTYBILLDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TXTGTOTAL As TextBox
    Friend WithEvents Label10 As Label
End Class
