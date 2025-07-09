<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeBarcode
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTDESIGN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTQUALITY = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTGODOWN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTSHADE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTPIECETYPE = New System.Windows.Forms.TextBox()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcopies = New System.Windows.Forms.TextBox()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.TXTFROMNO = New System.Windows.Forms.TextBox()
        Me.TXTFROMSRNO = New System.Windows.Forms.TextBox()
        Me.TXTTYPE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTSTAMPING = New System.Windows.Forms.TextBox()
        Me.LBLDESC = New System.Windows.Forms.Label()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.CHKBARCODE = New System.Windows.Forms.CheckBox()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTUNIT = New System.Windows.Forms.TextBox()
        Me.GRIDCHANGEBARCODE = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPIECETYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPRINTDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSHADE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CMDSELECTSTOCK = New System.Windows.Forms.Button()
        CType(Me.GRIDCHANGEBARCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1007, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 442
        Me.Label8.Text = "Mtrs"
        Me.Label8.Visible = False
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTMTRS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(1041, 182)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.ReadOnly = True
        Me.TXTMTRS.Size = New System.Drawing.Size(129, 23)
        Me.TXTMTRS.TabIndex = 441
        Me.TXTMTRS.TabStop = False
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTMTRS.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(978, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 440
        Me.Label7.Text = "Old Design"
        Me.Label7.Visible = False
        '
        'TXTDESIGN
        '
        Me.TXTDESIGN.BackColor = System.Drawing.Color.Linen
        Me.TXTDESIGN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESIGN.Location = New System.Drawing.Point(1041, 96)
        Me.TXTDESIGN.Name = "TXTDESIGN"
        Me.TXTDESIGN.ReadOnly = True
        Me.TXTDESIGN.Size = New System.Drawing.Size(129, 23)
        Me.TXTDESIGN.TabIndex = 439
        Me.TXTDESIGN.TabStop = False
        Me.TXTDESIGN.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(976, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 14)
        Me.Label6.TabIndex = 438
        Me.Label6.Text = "Old Quality"
        Me.Label6.Visible = False
        '
        'TXTQUALITY
        '
        Me.TXTQUALITY.BackColor = System.Drawing.Color.Linen
        Me.TXTQUALITY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUALITY.Location = New System.Drawing.Point(1041, 68)
        Me.TXTQUALITY.Name = "TXTQUALITY"
        Me.TXTQUALITY.ReadOnly = True
        Me.TXTQUALITY.Size = New System.Drawing.Size(129, 23)
        Me.TXTQUALITY.TabIndex = 437
        Me.TXTQUALITY.TabStop = False
        Me.TXTQUALITY.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 436
        Me.Label5.Text = "Godown"
        '
        'TXTGODOWN
        '
        Me.TXTGODOWN.BackColor = System.Drawing.Color.Linen
        Me.TXTGODOWN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGODOWN.Location = New System.Drawing.Point(109, 155)
        Me.TXTGODOWN.Name = "TXTGODOWN"
        Me.TXTGODOWN.ReadOnly = True
        Me.TXTGODOWN.Size = New System.Drawing.Size(195, 23)
        Me.TXTGODOWN.TabIndex = 435
        Me.TXTGODOWN.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(981, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 434
        Me.Label4.Text = "Old Shade"
        Me.Label4.Visible = False
        '
        'TXTSHADE
        '
        Me.TXTSHADE.BackColor = System.Drawing.Color.Linen
        Me.TXTSHADE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSHADE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHADE.Location = New System.Drawing.Point(1041, 124)
        Me.TXTSHADE.Name = "TXTSHADE"
        Me.TXTSHADE.ReadOnly = True
        Me.TXTSHADE.Size = New System.Drawing.Size(129, 23)
        Me.TXTSHADE.TabIndex = 433
        Me.TXTSHADE.TabStop = False
        Me.TXTSHADE.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(955, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 14)
        Me.Label3.TabIndex = 432
        Me.Label3.Text = "Old Item Name"
        Me.Label3.Visible = False
        '
        'TXTITEMNAME
        '
        Me.TXTITEMNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTITEMNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMNAME.Location = New System.Drawing.Point(1041, 40)
        Me.TXTITEMNAME.Name = "TXTITEMNAME"
        Me.TXTITEMNAME.ReadOnly = True
        Me.TXTITEMNAME.Size = New System.Drawing.Size(129, 23)
        Me.TXTITEMNAME.TabIndex = 431
        Me.TXTITEMNAME.TabStop = False
        Me.TXTITEMNAME.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(980, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "Piece Type"
        Me.Label1.Visible = False
        '
        'TXTPIECETYPE
        '
        Me.TXTPIECETYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTPIECETYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPIECETYPE.Location = New System.Drawing.Point(1041, 12)
        Me.TXTPIECETYPE.Name = "TXTPIECETYPE"
        Me.TXTPIECETYPE.ReadOnly = True
        Me.TXTPIECETYPE.Size = New System.Drawing.Size(129, 23)
        Me.TXTPIECETYPE.TabIndex = 429
        Me.TXTPIECETYPE.TabStop = False
        Me.TXTPIECETYPE.Visible = False
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSAVE.ForeColor = System.Drawing.Color.Black
        Me.CMDSAVE.Location = New System.Drawing.Point(491, 541)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 13
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'cmdcancel
        '
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(663, 541)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 15
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 428
        Me.Label2.Text = "Barcode"
        '
        'txtbarcode
        '
        Me.txtbarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbarcode.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcode.Location = New System.Drawing.Point(109, 43)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(195, 23)
        Me.txtbarcode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(35, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 427
        Me.Label9.Text = "New Design"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(6, 17)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(138, 19)
        Me.lbl.TabIndex = 426
        Me.lbl.Text = "Change Barcode"
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(109, 127)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(195, 23)
        Me.CMBDESIGN.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(535, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 15)
        Me.Label10.TabIndex = 445
        Me.Label10.Text = "Copies"
        '
        'txtcopies
        '
        Me.txtcopies.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcopies.Location = New System.Drawing.Point(581, 16)
        Me.txtcopies.Name = "txtcopies"
        Me.txtcopies.Size = New System.Drawing.Size(44, 23)
        Me.txtcopies.TabIndex = 9
        Me.txtcopies.Text = "1"
        Me.txtcopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(109, 71)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(195, 23)
        Me.CMBITEMNAME.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 15)
        Me.Label11.TabIndex = 447
        Me.Label11.Text = "New Item Name"
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(109, 99)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(195, 23)
        Me.CMBQUALITY.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 15)
        Me.Label12.TabIndex = 449
        Me.Label12.Text = "New Quality"
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(430, 71)
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(195, 23)
        Me.CMBSHADE.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(361, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 451
        Me.Label13.Text = "New Shade"
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(447, 12)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(28, 23)
        Me.TXTLOTNO.TabIndex = 452
        Me.TXTLOTNO.TabStop = False
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTLOTNO.Visible = False
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(577, 541)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 14
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'TXTFROMNO
        '
        Me.TXTFROMNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROMNO.Location = New System.Drawing.Point(413, 12)
        Me.TXTFROMNO.Name = "TXTFROMNO"
        Me.TXTFROMNO.Size = New System.Drawing.Size(28, 23)
        Me.TXTFROMNO.TabIndex = 453
        Me.TXTFROMNO.TabStop = False
        Me.TXTFROMNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFROMNO.Visible = False
        '
        'TXTFROMSRNO
        '
        Me.TXTFROMSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROMSRNO.Location = New System.Drawing.Point(379, 14)
        Me.TXTFROMSRNO.Name = "TXTFROMSRNO"
        Me.TXTFROMSRNO.Size = New System.Drawing.Size(28, 23)
        Me.TXTFROMSRNO.TabIndex = 454
        Me.TXTFROMSRNO.TabStop = False
        Me.TXTFROMSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFROMSRNO.Visible = False
        '
        'TXTTYPE
        '
        Me.TXTTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTYPE.Location = New System.Drawing.Point(346, 12)
        Me.TXTTYPE.Name = "TXTTYPE"
        Me.TXTTYPE.Size = New System.Drawing.Size(28, 23)
        Me.TXTTYPE.TabIndex = 455
        Me.TXTTYPE.TabStop = False
        Me.TXTTYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTYPE.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(370, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 15)
        Me.Label14.TabIndex = 681
        Me.Label14.Text = "Stamping"
        '
        'TXTSTAMPING
        '
        Me.TXTSTAMPING.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSTAMPING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTAMPING.Location = New System.Drawing.Point(430, 127)
        Me.TXTSTAMPING.Name = "TXTSTAMPING"
        Me.TXTSTAMPING.Size = New System.Drawing.Size(195, 23)
        Me.TXTSTAMPING.TabIndex = 7
        '
        'LBLDESC
        '
        Me.LBLDESC.AutoSize = True
        Me.LBLDESC.BackColor = System.Drawing.Color.Transparent
        Me.LBLDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDESC.Location = New System.Drawing.Point(395, 159)
        Me.LBLDESC.Name = "LBLDESC"
        Me.LBLDESC.Size = New System.Drawing.Size(33, 15)
        Me.LBLDESC.TabIndex = 679
        Me.LBLDESC.Text = "Desc"
        Me.LBLDESC.Visible = False
        '
        'TXTDESC
        '
        Me.TXTDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(430, 155)
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(195, 23)
        Me.TXTDESC.TabIndex = 8
        Me.TXTDESC.Visible = False
        '
        'CHKBARCODE
        '
        Me.CHKBARCODE.AutoSize = True
        Me.CHKBARCODE.BackColor = System.Drawing.Color.Transparent
        Me.CHKBARCODE.Location = New System.Drawing.Point(641, 45)
        Me.CHKBARCODE.Name = "CHKBARCODE"
        Me.CHKBARCODE.Size = New System.Drawing.Size(136, 19)
        Me.CHKBARCODE.TabIndex = 10
        Me.CHKBARCODE.Text = "Whole Sale Barcode"
        Me.CHKBARCODE.UseVisualStyleBackColor = False
        Me.CHKBARCODE.Visible = False
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(430, 99)
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(195, 23)
        Me.CMBUNIT.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(371, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 15)
        Me.Label15.TabIndex = 685
        Me.Label15.Text = "New Unit"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(990, 157)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 14)
        Me.Label16.TabIndex = 684
        Me.Label16.Text = "Old Unit"
        Me.Label16.Visible = False
        '
        'TXTUNIT
        '
        Me.TXTUNIT.BackColor = System.Drawing.Color.Linen
        Me.TXTUNIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTUNIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUNIT.Location = New System.Drawing.Point(1041, 153)
        Me.TXTUNIT.Name = "TXTUNIT"
        Me.TXTUNIT.ReadOnly = True
        Me.TXTUNIT.Size = New System.Drawing.Size(129, 23)
        Me.TXTUNIT.TabIndex = 683
        Me.TXTUNIT.TabStop = False
        Me.TXTUNIT.Visible = False
        '
        'GRIDCHANGEBARCODE
        '
        Me.GRIDCHANGEBARCODE.AllowUserToAddRows = False
        Me.GRIDCHANGEBARCODE.AllowUserToDeleteRows = False
        Me.GRIDCHANGEBARCODE.AllowUserToResizeColumns = False
        Me.GRIDCHANGEBARCODE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCHANGEBARCODE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCHANGEBARCODE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCHANGEBARCODE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCHANGEBARCODE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDCHANGEBARCODE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCHANGEBARCODE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCHANGEBARCODE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GPIECETYPE, Me.GITEMNAME, Me.GQUALITY, Me.GPRINTDESC, Me.GDESIGN, Me.GSHADE, Me.GUNIT, Me.GLOTNO, Me.GCUT, Me.GMTRS, Me.GBARCODE, Me.GFROMNO, Me.GFROMSRNO, Me.GFROMTYPE})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCHANGEBARCODE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDCHANGEBARCODE.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCHANGEBARCODE.Location = New System.Drawing.Point(18, 203)
        Me.GRIDCHANGEBARCODE.MultiSelect = False
        Me.GRIDCHANGEBARCODE.Name = "GRIDCHANGEBARCODE"
        Me.GRIDCHANGEBARCODE.RowHeadersVisible = False
        Me.GRIDCHANGEBARCODE.RowHeadersWidth = 30
        Me.GRIDCHANGEBARCODE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCHANGEBARCODE.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDCHANGEBARCODE.RowTemplate.Height = 20
        Me.GRIDCHANGEBARCODE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCHANGEBARCODE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDCHANGEBARCODE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDCHANGEBARCODE.Size = New System.Drawing.Size(1199, 333)
        Me.GRIDCHANGEBARCODE.TabIndex = 11
        Me.GRIDCHANGEBARCODE.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 30
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.HeaderText = "Piece Type"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.ReadOnly = True
        Me.GPIECETYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPIECETYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 180
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 130
        '
        'GPRINTDESC
        '
        Me.GPRINTDESC.HeaderText = "Description"
        Me.GPRINTDESC.Name = "GPRINTDESC"
        Me.GPRINTDESC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPRINTDESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPRINTDESC.Width = 130
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGN.Width = 150
        '
        'GSHADE
        '
        Me.GSHADE.HeaderText = "Shade"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.ReadOnly = True
        Me.GSHADE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHADE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSHADE.Width = 150
        '
        'GUNIT
        '
        Me.GUNIT.HeaderText = "Unit"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.ReadOnly = True
        Me.GUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUNIT.Visible = False
        '
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.ReadOnly = True
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCUT
        '
        Me.GCUT.HeaderText = "Cut"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.ReadOnly = True
        Me.GCUT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUT.Visible = False
        Me.GCUT.Width = 80
        '
        'GMTRS
        '
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 80
        '
        'GBARCODE
        '
        Me.GBARCODE.HeaderText = "Barcode"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.ReadOnly = True
        Me.GBARCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBARCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBARCODE.Width = 110
        '
        'GFROMNO
        '
        Me.GFROMNO.HeaderText = "FROMNO"
        Me.GFROMNO.Name = "GFROMNO"
        Me.GFROMNO.Visible = False
        '
        'GFROMSRNO
        '
        Me.GFROMSRNO.HeaderText = "FROMSRNO"
        Me.GFROMSRNO.Name = "GFROMSRNO"
        Me.GFROMSRNO.Visible = False
        '
        'GFROMTYPE
        '
        Me.GFROMTYPE.HeaderText = "FROMTYPE"
        Me.GFROMTYPE.Name = "GFROMTYPE"
        Me.GFROMTYPE.Visible = False
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(430, 43)
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(195, 23)
        Me.CMBPIECETYPE.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(339, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 15)
        Me.Label17.TabIndex = 688
        Me.Label17.Text = "New Piece Type"
        '
        'CMDSELECTSTOCK
        '
        Me.CMDSELECTSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTSTOCK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTSTOCK.FlatAppearance.BorderSize = 0
        Me.CMDSELECTSTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTSTOCK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSELECTSTOCK.Location = New System.Drawing.Point(404, 542)
        Me.CMDSELECTSTOCK.Name = "CMDSELECTSTOCK"
        Me.CMDSELECTSTOCK.Size = New System.Drawing.Size(81, 27)
        Me.CMDSELECTSTOCK.TabIndex = 12
        Me.CMDSELECTSTOCK.Text = "Select Stock"
        Me.CMDSELECTSTOCK.UseVisualStyleBackColor = False
        '
        'ChangeBarcode
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.CMDSELECTSTOCK)
        Me.Controls.Add(Me.CMBPIECETYPE)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GRIDCHANGEBARCODE)
        Me.Controls.Add(Me.CMBUNIT)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXTUNIT)
        Me.Controls.Add(Me.CHKBARCODE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTSTAMPING)
        Me.Controls.Add(Me.LBLDESC)
        Me.Controls.Add(Me.TXTDESC)
        Me.Controls.Add(Me.TXTTYPE)
        Me.Controls.Add(Me.TXTFROMSRNO)
        Me.Controls.Add(Me.TXTFROMNO)
        Me.Controls.Add(Me.CMDCLEAR)
        Me.Controls.Add(Me.TXTLOTNO)
        Me.Controls.Add(Me.CMBSHADE)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CMBQUALITY)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CMBITEMNAME)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtcopies)
        Me.Controls.Add(Me.CMBDESIGN)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTMTRS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTDESIGN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTQUALITY)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTGODOWN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTSHADE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTITEMNAME)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTPIECETYPE)
        Me.Controls.Add(Me.CMDSAVE)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtbarcode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbl)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ChangeBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Change Barcode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GRIDCHANGEBARCODE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTMTRS As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTDESIGN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTQUALITY As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTGODOWN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTSHADE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTITEMNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTPIECETYPE As System.Windows.Forms.TextBox
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtcopies As System.Windows.Forms.TextBox
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents TXTFROMNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROMSRNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTTYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTSTAMPING As System.Windows.Forms.TextBox
    Friend WithEvents LBLDESC As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents CHKBARCODE As System.Windows.Forms.CheckBox
    Friend WithEvents CMBUNIT As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TXTUNIT As TextBox
    Friend WithEvents GRIDCHANGEBARCODE As DataGridView
    Friend WithEvents CMBPIECETYPE As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GPIECETYPE As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GPRINTDESC As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewTextBoxColumn
    Friend WithEvents GSHADE As DataGridViewTextBoxColumn
    Friend WithEvents GUNIT As DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As DataGridViewTextBoxColumn
    Friend WithEvents GCUT As DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GBARCODE As DataGridViewTextBoxColumn
    Friend WithEvents GFROMNO As DataGridViewTextBoxColumn
    Friend WithEvents GFROMSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GFROMTYPE As DataGridViewTextBoxColumn
    Friend WithEvents CMDSELECTSTOCK As Button
End Class
