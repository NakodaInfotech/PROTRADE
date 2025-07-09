<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InHouseChecking
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InHouseChecking))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LBLTO = New System.Windows.Forms.Label()
        Me.TXTSHRINKAGEPER = New System.Windows.Forms.TextBox()
        Me.LBLFROM = New System.Windows.Forms.Label()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.CHECKINGDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTTYPE = New System.Windows.Forms.TextBox()
        Me.TXTTOTALPCS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTTOTALGREYMTRS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTMATRECNO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTCHECKEDBY = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.LBLSHORTAGE = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTGODOWN = New System.Windows.Forms.TextBox()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMDSELECTLOT = New System.Windows.Forms.Button()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTOTALWT = New System.Windows.Forms.TextBox()
        Me.TXTTOTALDIFF = New System.Windows.Forms.TextBox()
        Me.TXTTOTALCHECKEDMTRS = New System.Windows.Forms.TextBox()
        Me.TXTTOTALRECDMTRS = New System.Windows.Forms.TextBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.GRIDCHECKING = New System.Windows.Forms.DataGridView()
        Me.TXTCHECKINGNO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGREYMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRECDMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GINBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gdesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPIECETYPE = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GDIFF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNIT = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOLOR = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRACK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSHELF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDONE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDCHECKING, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.LBLTO)
        Me.BlendPanel1.Controls.Add(Me.TXTSHRINKAGEPER)
        Me.BlendPanel1.Controls.Add(Me.LBLFROM)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.CHECKINGDATE)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.TXTTYPE)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALGREYMTRS)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTMATRECNO)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTCHECKEDBY)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.LBLSHORTAGE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTGODOWN)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTLOT)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALWT)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALDIFF)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALCHECKEDMTRS)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALRECDMTRS)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.GRIDCHECKING)
        Me.BlendPanel1.Controls.Add(Me.TXTCHECKINGNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTTO
        '
        Me.TXTTO.BackColor = System.Drawing.Color.White
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTTO.Location = New System.Drawing.Point(994, 0)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(41, 23)
        Me.TXTTO.TabIndex = 724
        Me.TXTTO.Text = " "
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(802, 560)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 14)
        Me.Label15.TabIndex = 713
        Me.Label15.Text = "Srinkage %"
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.SystemColors.Control
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.ForeColor = System.Drawing.Color.Black
        Me.LBLTO.Location = New System.Drawing.Point(974, 4)
        Me.LBLTO.Name = "LBLTO"
        Me.LBLTO.Size = New System.Drawing.Size(19, 15)
        Me.LBLTO.TabIndex = 723
        Me.LBLTO.Text = "To"
        '
        'TXTSHRINKAGEPER
        '
        Me.TXTSHRINKAGEPER.BackColor = System.Drawing.Color.Linen
        Me.TXTSHRINKAGEPER.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTSHRINKAGEPER.Location = New System.Drawing.Point(869, 556)
        Me.TXTSHRINKAGEPER.Name = "TXTSHRINKAGEPER"
        Me.TXTSHRINKAGEPER.ReadOnly = True
        Me.TXTSHRINKAGEPER.Size = New System.Drawing.Size(86, 22)
        Me.TXTSHRINKAGEPER.TabIndex = 712
        Me.TXTSHRINKAGEPER.TabStop = False
        Me.TXTSHRINKAGEPER.Text = "0.00"
        Me.TXTSHRINKAGEPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLFROM
        '
        Me.LBLFROM.AutoSize = True
        Me.LBLFROM.BackColor = System.Drawing.SystemColors.Control
        Me.LBLFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFROM.ForeColor = System.Drawing.Color.Black
        Me.LBLFROM.Location = New System.Drawing.Point(818, 4)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(113, 15)
        Me.LBLFROM.TabIndex = 722
        Me.LBLFROM.Text = "Print Barcode From"
        '
        'TXTFROM
        '
        Me.TXTFROM.BackColor = System.Drawing.Color.White
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFROM.Location = New System.Drawing.Point(930, 0)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(41, 23)
        Me.TXTFROM.TabIndex = 721
        Me.TXTFROM.Text = " "
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHECKINGDATE
        '
        Me.CHECKINGDATE.AsciiOnly = True
        Me.CHECKINGDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CHECKINGDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.CHECKINGDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.CHECKINGDATE.Location = New System.Drawing.Point(1024, 89)
        Me.CHECKINGDATE.Mask = "00/00/0000"
        Me.CHECKINGDATE.Name = "CHECKINGDATE"
        Me.CHECKINGDATE.Size = New System.Drawing.Size(82, 23)
        Me.CHECKINGDATE.TabIndex = 0
        Me.CHECKINGDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.CHECKINGDATE.ValidatingType = GetType(Date)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(655, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 14)
        Me.Label14.TabIndex = 711
        Me.Label14.Text = "Type"
        '
        'TXTTYPE
        '
        Me.TXTTYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTTYPE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTYPE.Location = New System.Drawing.Point(688, 33)
        Me.TXTTYPE.Name = "TXTTYPE"
        Me.TXTTYPE.ReadOnly = True
        Me.TXTTYPE.Size = New System.Drawing.Size(68, 22)
        Me.TXTTYPE.TabIndex = 710
        Me.TXTTYPE.TabStop = False
        Me.TXTTYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALPCS
        '
        Me.TXTTOTALPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTOTALPCS.Location = New System.Drawing.Point(1063, 528)
        Me.TXTTOTALPCS.Name = "TXTTOTALPCS"
        Me.TXTTOTALPCS.ReadOnly = True
        Me.TXTTOTALPCS.Size = New System.Drawing.Size(86, 22)
        Me.TXTTOTALPCS.TabIndex = 709
        Me.TXTTOTALPCS.TabStop = False
        Me.TXTTOTALPCS.Text = "0"
        Me.TXTTOTALPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(1008, 532)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 14)
        Me.Label13.TabIndex = 708
        Me.Label13.Text = "Total Pcs"
        '
        'TXTTOTALGREYMTRS
        '
        Me.TXTTOTALGREYMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALGREYMTRS.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTOTALGREYMTRS.Location = New System.Drawing.Point(869, 472)
        Me.TXTTOTALGREYMTRS.Name = "TXTTOTALGREYMTRS"
        Me.TXTTOTALGREYMTRS.ReadOnly = True
        Me.TXTTOTALGREYMTRS.Size = New System.Drawing.Size(86, 22)
        Me.TXTTOTALGREYMTRS.TabIndex = 707
        Me.TXTTOTALGREYMTRS.TabStop = False
        Me.TXTTOTALGREYMTRS.Text = "0.00"
        Me.TXTTOTALGREYMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(780, 476)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 14)
        Me.Label11.TabIndex = 706
        Me.Label11.Text = "Total Grey Mtrs"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(1010, 504)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 705
        Me.Label8.Text = "Total Wt"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(759, 532)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 14)
        Me.Label7.TabIndex = 704
        Me.Label7.Text = "Total Checked Mtrs"
        '
        'TXTMATRECNO
        '
        Me.TXTMATRECNO.BackColor = System.Drawing.Color.Linen
        Me.TXTMATRECNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTMATRECNO.Location = New System.Drawing.Point(688, 61)
        Me.TXTMATRECNO.Name = "TXTMATRECNO"
        Me.TXTMATRECNO.ReadOnly = True
        Me.TXTMATRECNO.Size = New System.Drawing.Size(68, 22)
        Me.TXTMATRECNO.TabIndex = 702
        Me.TXTMATRECNO.TabStop = False
        Me.TXTMATRECNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(608, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 14)
        Me.Label6.TabIndex = 703
        Me.Label6.Text = "Rec / GRN No"
        '
        'TXTCHECKEDBY
        '
        Me.TXTCHECKEDBY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCHECKEDBY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTCHECKEDBY.Location = New System.Drawing.Point(509, 89)
        Me.TXTCHECKEDBY.MaxLength = 100
        Me.TXTCHECKEDBY.Name = "TXTCHECKEDBY"
        Me.TXTCHECKEDBY.Size = New System.Drawing.Size(247, 22)
        Me.TXTCHECKEDBY.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(440, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 701
        Me.Label5.Text = "Checked By"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(31, 470)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(239, 97)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 13)
        Me.txtremarks.MaxLength = 200
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(228, 78)
        Me.txtremarks.TabIndex = 0
        '
        'LBLSHORTAGE
        '
        Me.LBLSHORTAGE.BackColor = System.Drawing.Color.Transparent
        Me.LBLSHORTAGE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.LBLSHORTAGE.ForeColor = System.Drawing.Color.Black
        Me.LBLSHORTAGE.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LBLSHORTAGE.Location = New System.Drawing.Point(960, 476)
        Me.LBLSHORTAGE.Name = "LBLSHORTAGE"
        Me.LBLSHORTAGE.Size = New System.Drawing.Size(102, 14)
        Me.LBLSHORTAGE.TabIndex = 699
        Me.LBLSHORTAGE.Text = "Shortage"
        Me.LBLSHORTAGE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(50, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 698
        Me.Label3.Text = "Godown"
        '
        'TXTGODOWN
        '
        Me.TXTGODOWN.BackColor = System.Drawing.Color.Linen
        Me.TXTGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTGODOWN.Location = New System.Drawing.Point(104, 89)
        Me.TXTGODOWN.Name = "TXTGODOWN"
        Me.TXTGODOWN.ReadOnly = True
        Me.TXTGODOWN.Size = New System.Drawing.Size(212, 22)
        Me.TXTGODOWN.TabIndex = 697
        Me.TXTGODOWN.TabStop = False
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTNAME.Location = New System.Drawing.Point(104, 61)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.ReadOnly = True
        Me.TXTNAME.Size = New System.Drawing.Size(212, 22)
        Me.TXTNAME.TabIndex = 656
        Me.TXTNAME.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(63, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 14)
        Me.Label1.TabIndex = 657
        Me.Label1.Text = "Name"
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.Linen
        Me.TXTLOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTLOTNO.Location = New System.Drawing.Point(509, 61)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.ReadOnly = True
        Me.TXTLOTNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTLOTNO.TabIndex = 0
        Me.TXTLOTNO.TabStop = False
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(410, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Lot / Challan No."
        '
        'CMDSELECTLOT
        '
        Me.CMDSELECTLOT.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTLOT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTLOT.FlatAppearance.BorderSize = 0
        Me.CMDSELECTLOT.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.CMDSELECTLOT.ForeColor = System.Drawing.Color.Black
        Me.CMDSELECTLOT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CMDSELECTLOT.Location = New System.Drawing.Point(466, 494)
        Me.CMDSELECTLOT.Name = "CMDSELECTLOT"
        Me.CMDSELECTLOT.Size = New System.Drawing.Size(80, 28)
        Me.CMDSELECTLOT.TabIndex = 1
        Me.CMDSELECTLOT.Text = "Select &Entry"
        Me.CMDSELECTLOT.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmddelete.Location = New System.Drawing.Point(509, 528)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 6
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdclear.Location = New System.Drawing.Point(638, 494)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 5
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdok.Location = New System.Drawing.Point(552, 494)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdexit.Location = New System.Drawing.Point(595, 528)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PBlock.Location = New System.Drawing.Point(284, 494)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(50, 50)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 446
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(778, 504)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 14)
        Me.Label10.TabIndex = 655
        Me.Label10.Text = "Total Recd Mtrs"
        '
        'TXTTOTALWT
        '
        Me.TXTTOTALWT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALWT.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTOTALWT.Location = New System.Drawing.Point(1063, 500)
        Me.TXTTOTALWT.Name = "TXTTOTALWT"
        Me.TXTTOTALWT.ReadOnly = True
        Me.TXTTOTALWT.Size = New System.Drawing.Size(86, 22)
        Me.TXTTOTALWT.TabIndex = 22
        Me.TXTTOTALWT.TabStop = False
        Me.TXTTOTALWT.Text = "0.00"
        Me.TXTTOTALWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALDIFF
        '
        Me.TXTTOTALDIFF.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALDIFF.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTOTALDIFF.Location = New System.Drawing.Point(1063, 472)
        Me.TXTTOTALDIFF.Name = "TXTTOTALDIFF"
        Me.TXTTOTALDIFF.ReadOnly = True
        Me.TXTTOTALDIFF.Size = New System.Drawing.Size(86, 22)
        Me.TXTTOTALDIFF.TabIndex = 21
        Me.TXTTOTALDIFF.TabStop = False
        Me.TXTTOTALDIFF.Text = "0.00"
        Me.TXTTOTALDIFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALCHECKEDMTRS
        '
        Me.TXTTOTALCHECKEDMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALCHECKEDMTRS.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTOTALCHECKEDMTRS.Location = New System.Drawing.Point(869, 528)
        Me.TXTTOTALCHECKEDMTRS.Name = "TXTTOTALCHECKEDMTRS"
        Me.TXTTOTALCHECKEDMTRS.ReadOnly = True
        Me.TXTTOTALCHECKEDMTRS.Size = New System.Drawing.Size(86, 22)
        Me.TXTTOTALCHECKEDMTRS.TabIndex = 20
        Me.TXTTOTALCHECKEDMTRS.TabStop = False
        Me.TXTTOTALCHECKEDMTRS.Text = "0.00"
        Me.TXTTOTALCHECKEDMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALRECDMTRS
        '
        Me.TXTTOTALRECDMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALRECDMTRS.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTTOTALRECDMTRS.Location = New System.Drawing.Point(869, 500)
        Me.TXTTOTALRECDMTRS.Name = "TXTTOTALRECDMTRS"
        Me.TXTTOTALRECDMTRS.ReadOnly = True
        Me.TXTTOTALRECDMTRS.Size = New System.Drawing.Size(86, 22)
        Me.TXTTOTALRECDMTRS.TabIndex = 19
        Me.TXTTOTALRECDMTRS.TabStop = False
        Me.TXTTOTALRECDMTRS.Text = "0.00"
        Me.TXTTOTALRECDMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbllocked.Location = New System.Drawing.Point(340, 494)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 17
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'GRIDCHECKING
        '
        Me.GRIDCHECKING.AllowUserToAddRows = False
        Me.GRIDCHECKING.AllowUserToDeleteRows = False
        Me.GRIDCHECKING.AllowUserToResizeColumns = False
        Me.GRIDCHECKING.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCHECKING.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDCHECKING.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCHECKING.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCHECKING.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDCHECKING.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDCHECKING.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCHECKING.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GGREYMTRS, Me.GRECDMTRS, Me.GMTRS, Me.GINBARCODE, Me.Gdesc, Me.GPIECETYPE, Me.GDIFF, Me.GUNIT, Me.GWT, Me.GITEMNAME, Me.GQUALITY, Me.GDESIGN, Me.GCOLOR, Me.GBARCODE, Me.GRACK, Me.GSHELF, Me.GDONE, Me.GOUTPCS, Me.GOUTMTRS})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCHECKING.DefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDCHECKING.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCHECKING.Location = New System.Drawing.Point(8, 119)
        Me.GRIDCHECKING.MultiSelect = False
        Me.GRIDCHECKING.Name = "GRIDCHECKING"
        Me.GRIDCHECKING.RowHeadersVisible = False
        Me.GRIDCHECKING.RowHeadersWidth = 30
        Me.GRIDCHECKING.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCHECKING.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDCHECKING.RowTemplate.Height = 20
        Me.GRIDCHECKING.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCHECKING.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCHECKING.Size = New System.Drawing.Size(1264, 345)
        Me.GRIDCHECKING.TabIndex = 2
        '
        'TXTCHECKINGNO
        '
        Me.TXTCHECKINGNO.BackColor = System.Drawing.Color.Linen
        Me.TXTCHECKINGNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.TXTCHECKINGNO.Location = New System.Drawing.Point(1024, 61)
        Me.TXTCHECKINGNO.Name = "TXTCHECKINGNO"
        Me.TXTCHECKINGNO.ReadOnly = True
        Me.TXTCHECKINGNO.Size = New System.Drawing.Size(82, 22)
        Me.TXTCHECKINGNO.TabIndex = 627
        Me.TXTCHECKINGNO.TabStop = False
        Me.TXTCHECKINGNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(984, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 14)
        Me.Label12.TabIndex = 630
        Me.Label12.Text = "Sr. No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(937, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 14)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Checking Date"
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.tstxtbillno.Location = New System.Drawing.Point(241, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(62, 22)
        Me.tstxtbillno.TabIndex = 9
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "In House Checking"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.toolprevious.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.toolnext.Image = Global.PROTRADE.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 30
        '
        'GGREYMTRS
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GGREYMTRS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GGREYMTRS.HeaderText = "G Mtrs"
        Me.GGREYMTRS.Name = "GGREYMTRS"
        Me.GGREYMTRS.ReadOnly = True
        Me.GGREYMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGREYMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGREYMTRS.Width = 75
        '
        'GRECDMTRS
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GRECDMTRS.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRECDMTRS.HeaderText = "Rec Mtrs"
        Me.GRECDMTRS.Name = "GRECDMTRS"
        Me.GRECDMTRS.ReadOnly = True
        Me.GRECDMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRECDMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRECDMTRS.Width = 75
        '
        'GMTRS
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle5
        Me.GMTRS.HeaderText = "Chk Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 75
        '
        'GINBARCODE
        '
        Me.GINBARCODE.HeaderText = "In Barcode"
        Me.GINBARCODE.Name = "GINBARCODE"
        Me.GINBARCODE.ReadOnly = True
        Me.GINBARCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GINBARCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GINBARCODE.Width = 120
        '
        'Gdesc
        '
        Me.Gdesc.HeaderText = "Description"
        Me.Gdesc.MaxInputLength = 200
        Me.Gdesc.Name = "Gdesc"
        Me.Gdesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gdesc.Width = 120
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.HeaderText = "Grade"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.ReadOnly = True
        Me.GPIECETYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'GDIFF
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GDIFF.DefaultCellStyle = DataGridViewCellStyle6
        Me.GDIFF.HeaderText = "Diff."
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.ReadOnly = True
        Me.GDIFF.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDIFF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDIFF.Width = 60
        '
        'GUNIT
        '
        Me.GUNIT.HeaderText = "Unit"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GUNIT.Width = 60
        '
        'GWT
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle7.Format = "N2"
        Me.GWT.DefaultCellStyle = DataGridViewCellStyle7
        Me.GWT.HeaderText = "Wt"
        Me.GWT.Name = "GWT"
        Me.GWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWT.Width = 60
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 160
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 110
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGN.Width = 85
        '
        'GCOLOR
        '
        Me.GCOLOR.HeaderText = "Shade"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOLOR.Width = 85
        '
        'GBARCODE
        '
        Me.GBARCODE.HeaderText = "Barcode"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.ReadOnly = True
        Me.GBARCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBARCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBARCODE.Width = 90
        '
        'GRACK
        '
        Me.GRACK.HeaderText = "Rack"
        Me.GRACK.Name = "GRACK"
        Me.GRACK.ReadOnly = True
        Me.GRACK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRACK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRACK.Visible = False
        '
        'GSHELF
        '
        Me.GSHELF.HeaderText = "Shelf"
        Me.GSHELF.Name = "GSHELF"
        Me.GSHELF.ReadOnly = True
        Me.GSHELF.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHELF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSHELF.Visible = False
        '
        'GDONE
        '
        Me.GDONE.HeaderText = "DONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDONE.Visible = False
        '
        'GOUTPCS
        '
        Me.GOUTPCS.HeaderText = "OUTPCS"
        Me.GOUTPCS.Name = "GOUTPCS"
        Me.GOUTPCS.Visible = False
        '
        'GOUTMTRS
        '
        Me.GOUTMTRS.HeaderText = "OUTMTRS"
        Me.GOUTMTRS.Name = "GOUTMTRS"
        Me.GOUTMTRS.Visible = False
        '
        'InHouseChecking
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "InHouseChecking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "In House Checking"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDCHECKING, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDSELECTLOT As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALWT As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALDIFF As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALCHECKEDMTRS As System.Windows.Forms.TextBox
    Friend WithEvents TXTTOTALRECDMTRS As System.Windows.Forms.TextBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents GRIDCHECKING As System.Windows.Forms.DataGridView
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTCHECKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTGODOWN As System.Windows.Forms.TextBox
    Friend WithEvents LBLSHORTAGE As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents TXTCHECKEDBY As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTMATRECNO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALGREYMTRS As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALPCS As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTTYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CHECKINGDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTSHRINKAGEPER As TextBox
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents LBLTO As Label
    Friend WithEvents LBLFROM As Label
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents GGREYMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GRECDMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GINBARCODE As DataGridViewTextBoxColumn
    Friend WithEvents Gdesc As DataGridViewTextBoxColumn
    Friend WithEvents GPIECETYPE As DataGridViewComboBoxColumn
    Friend WithEvents GDIFF As DataGridViewTextBoxColumn
    Friend WithEvents GUNIT As DataGridViewComboBoxColumn
    Friend WithEvents GWT As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As DataGridViewComboBoxColumn
    Friend WithEvents GBARCODE As DataGridViewTextBoxColumn
    Friend WithEvents GRACK As DataGridViewTextBoxColumn
    Friend WithEvents GSHELF As DataGridViewTextBoxColumn
    Friend WithEvents GDONE As DataGridViewTextBoxColumn
    Friend WithEvents GOUTPCS As DataGridViewTextBoxColumn
    Friend WithEvents GOUTMTRS As DataGridViewTextBoxColumn
End Class
