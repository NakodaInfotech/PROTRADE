<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransfer
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
        Me.LBL = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBALENO = New System.Windows.Forms.TextBox()
        Me.TXTTYPE = New System.Windows.Forms.TextBox()
        Me.TXTFROMSRNO = New System.Windows.Forms.TextBox()
        Me.TXTFROMNO = New System.Windows.Forms.TextBox()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTGODOWN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTCOLOR = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTDESIGNNO = New System.Windows.Forms.TextBox()
        Me.TXTQUALITY = New System.Windows.Forms.TextBox()
        Me.TXTITEM = New System.Windows.Forms.TextBox()
        Me.TXTPIECETYPE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBL
        '
        Me.LBL.AutoSize = True
        Me.LBL.BackColor = System.Drawing.Color.Transparent
        Me.LBL.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBL.Location = New System.Drawing.Point(11, 5)
        Me.LBL.Name = "LBL"
        Me.LBL.Size = New System.Drawing.Size(134, 26)
        Me.LBL.TabIndex = 430
        Me.LBL.Text = "Stock Transfer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(261, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 434
        Me.Label6.Text = "Design"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(230, 268)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(144, 269)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Transfer"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 656
        Me.Label1.Text = "Piecetype"
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.Color.Black
        Me.TXTBARCODE.Location = New System.Drawing.Point(83, 80)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(122, 23)
        Me.TXTBARCODE.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 14)
        Me.Label2.TabIndex = 747
        Me.Label2.Text = "Barcode"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTBALENO)
        Me.BlendPanel1.Controls.Add(Me.TXTTYPE)
        Me.BlendPanel1.Controls.Add(Me.TXTFROMSRNO)
        Me.BlendPanel1.Controls.Add(Me.TXTFROMNO)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTGODOWN)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTCOLOR)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.TXTQUALITY)
        Me.BlendPanel1.Controls.Add(Me.TXTITEM)
        Me.BlendPanel1.Controls.Add(Me.TXTPIECETYPE)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.LBL)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(455, 308)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(255, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 14)
        Me.Label11.TabIndex = 772
        Me.Label11.Text = "Bale No"
        '
        'TXTBALENO
        '
        Me.TXTBALENO.BackColor = System.Drawing.Color.White
        Me.TXTBALENO.ForeColor = System.Drawing.Color.Black
        Me.TXTBALENO.Location = New System.Drawing.Point(306, 80)
        Me.TXTBALENO.Name = "TXTBALENO"
        Me.TXTBALENO.Size = New System.Drawing.Size(122, 23)
        Me.TXTBALENO.TabIndex = 2
        '
        'TXTTYPE
        '
        Me.TXTTYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTTYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTYPE.Enabled = False
        Me.TXTTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTYPE.Location = New System.Drawing.Point(415, 12)
        Me.TXTTYPE.Name = "TXTTYPE"
        Me.TXTTYPE.ReadOnly = True
        Me.TXTTYPE.Size = New System.Drawing.Size(13, 23)
        Me.TXTTYPE.TabIndex = 770
        Me.TXTTYPE.TabStop = False
        Me.TXTTYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTYPE.Visible = False
        '
        'TXTFROMSRNO
        '
        Me.TXTFROMSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTFROMSRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROMSRNO.Enabled = False
        Me.TXTFROMSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROMSRNO.Location = New System.Drawing.Point(392, 12)
        Me.TXTFROMSRNO.Name = "TXTFROMSRNO"
        Me.TXTFROMSRNO.ReadOnly = True
        Me.TXTFROMSRNO.Size = New System.Drawing.Size(13, 23)
        Me.TXTFROMSRNO.TabIndex = 769
        Me.TXTFROMSRNO.TabStop = False
        Me.TXTFROMSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFROMSRNO.Visible = False
        '
        'TXTFROMNO
        '
        Me.TXTFROMNO.BackColor = System.Drawing.Color.Linen
        Me.TXTFROMNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROMNO.Enabled = False
        Me.TXTFROMNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROMNO.Location = New System.Drawing.Point(369, 12)
        Me.TXTFROMNO.Name = "TXTFROMNO"
        Me.TXTFROMNO.ReadOnly = True
        Me.TXTFROMNO.Size = New System.Drawing.Size(13, 23)
        Me.TXTFROMNO.TabIndex = 768
        Me.TXTFROMNO.TabStop = False
        Me.TXTFROMNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFROMNO.Visible = False
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(307, 51)
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(122, 23)
        Me.CMBGODOWN.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(227, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 764
        Me.Label4.Text = "New Godown"
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTMTRS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMTRS.Enabled = False
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(307, 202)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.ReadOnly = True
        Me.TXTMTRS.Size = New System.Drawing.Size(122, 23)
        Me.TXTMTRS.TabIndex = 763
        Me.TXTMTRS.TabStop = False
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(272, 206)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 15)
        Me.Label9.TabIndex = 762
        Me.Label9.Text = "Mtrs"
        '
        'TXTGODOWN
        '
        Me.TXTGODOWN.BackColor = System.Drawing.Color.Linen
        Me.TXTGODOWN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGODOWN.Enabled = False
        Me.TXTGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGODOWN.Location = New System.Drawing.Point(307, 109)
        Me.TXTGODOWN.Name = "TXTGODOWN"
        Me.TXTGODOWN.ReadOnly = True
        Me.TXTGODOWN.Size = New System.Drawing.Size(122, 23)
        Me.TXTGODOWN.TabIndex = 761
        Me.TXTGODOWN.TabStop = False
        Me.TXTGODOWN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(253, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 760
        Me.Label10.Text = "Godown"
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTPCS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPCS.Enabled = False
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(83, 171)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.ReadOnly = True
        Me.TXTPCS.Size = New System.Drawing.Size(122, 23)
        Me.TXTPCS.TabIndex = 757
        Me.TXTPCS.TabStop = False
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(54, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 15)
        Me.Label8.TabIndex = 756
        Me.Label8.Text = "Pcs"
        '
        'TXTCOLOR
        '
        Me.TXTCOLOR.BackColor = System.Drawing.Color.Linen
        Me.TXTCOLOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOLOR.Enabled = False
        Me.TXTCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOLOR.Location = New System.Drawing.Point(307, 171)
        Me.TXTCOLOR.Name = "TXTCOLOR"
        Me.TXTCOLOR.ReadOnly = True
        Me.TXTCOLOR.Size = New System.Drawing.Size(122, 23)
        Me.TXTCOLOR.TabIndex = 755
        Me.TXTCOLOR.TabStop = False
        Me.TXTCOLOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(265, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 15)
        Me.Label7.TabIndex = 754
        Me.Label7.Text = "Shade"
        '
        'TXTDESIGNNO
        '
        Me.TXTDESIGNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTDESIGNNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESIGNNO.Enabled = False
        Me.TXTDESIGNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESIGNNO.Location = New System.Drawing.Point(307, 140)
        Me.TXTDESIGNNO.Name = "TXTDESIGNNO"
        Me.TXTDESIGNNO.ReadOnly = True
        Me.TXTDESIGNNO.Size = New System.Drawing.Size(122, 23)
        Me.TXTDESIGNNO.TabIndex = 753
        Me.TXTDESIGNNO.TabStop = False
        Me.TXTDESIGNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQUALITY
        '
        Me.TXTQUALITY.BackColor = System.Drawing.Color.Linen
        Me.TXTQUALITY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTQUALITY.Enabled = False
        Me.TXTQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUALITY.Location = New System.Drawing.Point(83, 140)
        Me.TXTQUALITY.Name = "TXTQUALITY"
        Me.TXTQUALITY.ReadOnly = True
        Me.TXTQUALITY.Size = New System.Drawing.Size(122, 23)
        Me.TXTQUALITY.TabIndex = 752
        Me.TXTQUALITY.TabStop = False
        Me.TXTQUALITY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTITEM
        '
        Me.TXTITEM.BackColor = System.Drawing.Color.Linen
        Me.TXTITEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTITEM.Enabled = False
        Me.TXTITEM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEM.Location = New System.Drawing.Point(83, 202)
        Me.TXTITEM.Name = "TXTITEM"
        Me.TXTITEM.ReadOnly = True
        Me.TXTITEM.Size = New System.Drawing.Size(122, 23)
        Me.TXTITEM.TabIndex = 751
        Me.TXTITEM.TabStop = False
        Me.TXTITEM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPIECETYPE
        '
        Me.TXTPIECETYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTPIECETYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPIECETYPE.Enabled = False
        Me.TXTPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPIECETYPE.Location = New System.Drawing.Point(83, 109)
        Me.TXTPIECETYPE.Name = "TXTPIECETYPE"
        Me.TXTPIECETYPE.ReadOnly = True
        Me.TXTPIECETYPE.Size = New System.Drawing.Size(122, 23)
        Me.TXTPIECETYPE.TabIndex = 750
        Me.TXTPIECETYPE.TabStop = False
        Me.TXTPIECETYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(32, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 749
        Me.Label5.Text = "Quality"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 748
        Me.Label3.Text = "Item Name"
        '
        'StockTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(455, 308)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LBL As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTBARCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTMTRS As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTGODOWN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTPCS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTCOLOR As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTDESIGNNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTQUALITY As System.Windows.Forms.TextBox
    Friend WithEvents TXTITEM As System.Windows.Forms.TextBox
    Friend WithEvents TXTPIECETYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents TXTTYPE As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROMSRNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROMNO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTBALENO As System.Windows.Forms.TextBox
End Class
