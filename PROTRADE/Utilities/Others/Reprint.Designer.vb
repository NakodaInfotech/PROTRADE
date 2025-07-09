<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reprint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reprint))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcopies = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdprint = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTPIECETYPE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTSHADE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTGODOWN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTQUALITY = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTDESIGN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.CHKBARCODE = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.LBLDESC = New System.Windows.Forms.Label()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTSTAMPING = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTRACK = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTBALENO = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTUNIT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTCUT = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "Barcode"
        '
        'txtbarcode
        '
        Me.txtbarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbarcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarcode.Location = New System.Drawing.Point(82, 32)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(129, 22)
        Me.txtbarcode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(241, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 14)
        Me.Label9.TabIndex = 405
        Me.Label9.Text = "Copies"
        '
        'txtcopies
        '
        Me.txtcopies.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcopies.Location = New System.Drawing.Point(282, 32)
        Me.txtcopies.Name = "txtcopies"
        Me.txtcopies.Size = New System.Drawing.Size(44, 22)
        Me.txtcopies.TabIndex = 1
        Me.txtcopies.Text = "1"
        Me.txtcopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(7, 6)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(60, 19)
        Me.lbl.TabIndex = 404
        Me.lbl.Text = "Labels"
        '
        'cmdcancel
        '
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(224, 306)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 5
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'cmdprint
        '
        Me.cmdprint.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdprint.ForeColor = System.Drawing.Color.Black
        Me.cmdprint.Location = New System.Drawing.Point(138, 306)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(80, 28)
        Me.cmdprint.TabIndex = 4
        Me.cmdprint.Text = "&Print"
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 409
        Me.Label1.Text = "Piece Type"
        '
        'TXTPIECETYPE
        '
        Me.TXTPIECETYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTPIECETYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPIECETYPE.Location = New System.Drawing.Point(82, 60)
        Me.TXTPIECETYPE.Name = "TXTPIECETYPE"
        Me.TXTPIECETYPE.ReadOnly = True
        Me.TXTPIECETYPE.Size = New System.Drawing.Size(129, 22)
        Me.TXTPIECETYPE.TabIndex = 408
        Me.TXTPIECETYPE.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 14)
        Me.Label3.TabIndex = 411
        Me.Label3.Text = "Item Name"
        '
        'TXTITEMNAME
        '
        Me.TXTITEMNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTITEMNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMNAME.Location = New System.Drawing.Point(82, 88)
        Me.TXTITEMNAME.Name = "TXTITEMNAME"
        Me.TXTITEMNAME.ReadOnly = True
        Me.TXTITEMNAME.Size = New System.Drawing.Size(129, 22)
        Me.TXTITEMNAME.TabIndex = 410
        Me.TXTITEMNAME.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(243, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 413
        Me.Label4.Text = "Shade"
        '
        'TXTSHADE
        '
        Me.TXTSHADE.BackColor = System.Drawing.Color.Linen
        Me.TXTSHADE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHADE.Location = New System.Drawing.Point(282, 60)
        Me.TXTSHADE.Name = "TXTSHADE"
        Me.TXTSHADE.ReadOnly = True
        Me.TXTSHADE.Size = New System.Drawing.Size(129, 22)
        Me.TXTSHADE.TabIndex = 412
        Me.TXTSHADE.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(232, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 14)
        Me.Label5.TabIndex = 415
        Me.Label5.Text = "Godown"
        '
        'TXTGODOWN
        '
        Me.TXTGODOWN.BackColor = System.Drawing.Color.Linen
        Me.TXTGODOWN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGODOWN.Location = New System.Drawing.Point(282, 88)
        Me.TXTGODOWN.Name = "TXTGODOWN"
        Me.TXTGODOWN.ReadOnly = True
        Me.TXTGODOWN.Size = New System.Drawing.Size(129, 22)
        Me.TXTGODOWN.TabIndex = 414
        Me.TXTGODOWN.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 417
        Me.Label6.Text = "Quality"
        '
        'TXTQUALITY
        '
        Me.TXTQUALITY.BackColor = System.Drawing.Color.Linen
        Me.TXTQUALITY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUALITY.Location = New System.Drawing.Point(82, 116)
        Me.TXTQUALITY.Name = "TXTQUALITY"
        Me.TXTQUALITY.ReadOnly = True
        Me.TXTQUALITY.Size = New System.Drawing.Size(129, 22)
        Me.TXTQUALITY.TabIndex = 416
        Me.TXTQUALITY.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(36, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 419
        Me.Label7.Text = "Design"
        '
        'TXTDESIGN
        '
        Me.TXTDESIGN.BackColor = System.Drawing.Color.Linen
        Me.TXTDESIGN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESIGN.Location = New System.Drawing.Point(82, 144)
        Me.TXTDESIGN.Name = "TXTDESIGN"
        Me.TXTDESIGN.ReadOnly = True
        Me.TXTDESIGN.Size = New System.Drawing.Size(129, 22)
        Me.TXTDESIGN.TabIndex = 418
        Me.TXTDESIGN.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(250, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 14)
        Me.Label8.TabIndex = 421
        Me.Label8.Text = "Mtrs"
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTMTRS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(282, 116)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.ReadOnly = True
        Me.TXTMTRS.Size = New System.Drawing.Size(129, 22)
        Me.TXTMTRS.TabIndex = 420
        Me.TXTMTRS.TabStop = False
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHKBARCODE
        '
        Me.CHKBARCODE.AutoSize = True
        Me.CHKBARCODE.BackColor = System.Drawing.Color.Transparent
        Me.CHKBARCODE.Location = New System.Drawing.Point(168, 282)
        Me.CHKBARCODE.Name = "CHKBARCODE"
        Me.CHKBARCODE.Size = New System.Drawing.Size(125, 18)
        Me.CHKBARCODE.TabIndex = 3
        Me.CHKBARCODE.Text = "Whole Sale Barcode"
        Me.CHKBARCODE.UseVisualStyleBackColor = False
        Me.CHKBARCODE.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 176)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 14)
        Me.Label10.TabIndex = 673
        Me.Label10.Text = "Lot No"
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.Linen
        Me.TXTLOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(82, 172)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.ReadOnly = True
        Me.TXTLOTNO.Size = New System.Drawing.Size(129, 22)
        Me.TXTLOTNO.TabIndex = 672
        Me.TXTLOTNO.TabStop = False
        '
        'LBLDESC
        '
        Me.LBLDESC.AutoSize = True
        Me.LBLDESC.BackColor = System.Drawing.Color.Transparent
        Me.LBLDESC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDESC.Location = New System.Drawing.Point(250, 148)
        Me.LBLDESC.Name = "LBLDESC"
        Me.LBLDESC.Size = New System.Drawing.Size(30, 14)
        Me.LBLDESC.TabIndex = 675
        Me.LBLDESC.Text = "Desc"
        '
        'TXTDESC
        '
        Me.TXTDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(282, 144)
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(129, 22)
        Me.TXTDESC.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(226, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 14)
        Me.Label11.TabIndex = 677
        Me.Label11.Text = "Stamping"
        '
        'TXTSTAMPING
        '
        Me.TXTSTAMPING.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSTAMPING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTAMPING.Location = New System.Drawing.Point(282, 172)
        Me.TXTSTAMPING.Name = "TXTSTAMPING"
        Me.TXTSTAMPING.Size = New System.Drawing.Size(129, 22)
        Me.TXTSTAMPING.TabIndex = 676
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(49, 204)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 14)
        Me.Label12.TabIndex = 679
        Me.Label12.Text = "Rack"
        '
        'TXTRACK
        '
        Me.TXTRACK.BackColor = System.Drawing.Color.Linen
        Me.TXTRACK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRACK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRACK.Location = New System.Drawing.Point(82, 200)
        Me.TXTRACK.Name = "TXTRACK"
        Me.TXTRACK.ReadOnly = True
        Me.TXTRACK.Size = New System.Drawing.Size(129, 22)
        Me.TXTRACK.TabIndex = 678
        Me.TXTRACK.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(231, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 14)
        Me.Label13.TabIndex = 681
        Me.Label13.Text = "Bale No."
        '
        'TXTBALENO
        '
        Me.TXTBALENO.BackColor = System.Drawing.Color.Linen
        Me.TXTBALENO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBALENO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALENO.Location = New System.Drawing.Point(282, 200)
        Me.TXTBALENO.Name = "TXTBALENO"
        Me.TXTBALENO.ReadOnly = True
        Me.TXTBALENO.Size = New System.Drawing.Size(129, 22)
        Me.TXTBALENO.TabIndex = 680
        Me.TXTBALENO.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(51, 232)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 14)
        Me.Label14.TabIndex = 683
        Me.Label14.Text = "Unit"
        '
        'TXTUNIT
        '
        Me.TXTUNIT.BackColor = System.Drawing.Color.Linen
        Me.TXTUNIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUNIT.Location = New System.Drawing.Point(82, 228)
        Me.TXTUNIT.Name = "TXTUNIT"
        Me.TXTUNIT.ReadOnly = True
        Me.TXTUNIT.Size = New System.Drawing.Size(129, 22)
        Me.TXTUNIT.TabIndex = 682
        Me.TXTUNIT.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(257, 232)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 14)
        Me.Label15.TabIndex = 685
        Me.Label15.Text = "Cut"
        '
        'TXTCUT
        '
        Me.TXTCUT.BackColor = System.Drawing.Color.Linen
        Me.TXTCUT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCUT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUT.Location = New System.Drawing.Point(282, 228)
        Me.TXTCUT.Name = "TXTCUT"
        Me.TXTCUT.ReadOnly = True
        Me.TXTCUT.Size = New System.Drawing.Size(129, 22)
        Me.TXTCUT.TabIndex = 684
        Me.TXTCUT.TabStop = False
        '
        'Reprint
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(438, 346)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TXTCUT)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTUNIT)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TXTBALENO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTRACK)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTSTAMPING)
        Me.Controls.Add(Me.LBLDESC)
        Me.Controls.Add(Me.TXTDESC)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTLOTNO)
        Me.Controls.Add(Me.CHKBARCODE)
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
        Me.Controls.Add(Me.cmdprint)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtbarcode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtcopies)
        Me.Controls.Add(Me.lbl)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Reprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Label Print"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcopies As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTPIECETYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTITEMNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTSHADE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTGODOWN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTQUALITY As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTDESIGN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTMTRS As System.Windows.Forms.TextBox
    Friend WithEvents CHKBARCODE As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents LBLDESC As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTSTAMPING As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTRACK As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXTBALENO As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXTUNIT As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTCUT As TextBox
End Class
