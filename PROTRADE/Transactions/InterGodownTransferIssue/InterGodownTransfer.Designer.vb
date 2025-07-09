<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterGodownTransfer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterGodownTransfer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTISSUEBY = New System.Windows.Forms.TextBox()
        Me.LBLISSUEBY = New System.Windows.Forms.Label()
        Me.CMBFROMGODOWN = New System.Windows.Forms.ComboBox()
        Me.LBLTYPE = New System.Windows.Forms.Label()
        Me.TXTREFRENCE = New System.Windows.Forms.TextBox()
        Me.LBLREFRENCE = New System.Windows.Forms.Label()
        Me.TXTDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label()
        Me.LBLTOTALPCS = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.CMBTRANSPORTNAME = New System.Windows.Forms.ComboBox()
        Me.TXTGODOWNNO = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TXTBALENO = New System.Windows.Forms.TextBox()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.TXTMTRS = New System.Windows.Forms.TextBox()
        Me.cmbcolor = New System.Windows.Forms.ComboBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.GRIDJO = New System.Windows.Forms.DataGridView()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.CMDSELECTSTOCK = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBTOGODOWN = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.TOOLSMS = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPIECETYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMERCHANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBALENO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GUNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GOUTMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFROMTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GRIDJO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTISSUEBY)
        Me.BlendPanel1.Controls.Add(Me.LBLISSUEBY)
        Me.BlendPanel1.Controls.Add(Me.CMBFROMGODOWN)
        Me.BlendPanel1.Controls.Add(Me.LBLTYPE)
        Me.BlendPanel1.Controls.Add(Me.TXTREFRENCE)
        Me.BlendPanel1.Controls.Add(Me.LBLREFRENCE)
        Me.BlendPanel1.Controls.Add(Me.TXTDATE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.CMBTRANSPORTNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTGODOWNNO)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTSTOCK)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBTOGODOWN)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(801, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 15)
        Me.Label4.TabIndex = 757
        Me.Label4.Text = "Sr. No."
        '
        'TXTISSUEBY
        '
        Me.TXTISSUEBY.BackColor = System.Drawing.Color.White
        Me.TXTISSUEBY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTISSUEBY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTISSUEBY.Location = New System.Drawing.Point(511, 72)
        Me.TXTISSUEBY.MaxLength = 10
        Me.TXTISSUEBY.Name = "TXTISSUEBY"
        Me.TXTISSUEBY.Size = New System.Drawing.Size(144, 23)
        Me.TXTISSUEBY.TabIndex = 6
        Me.TXTISSUEBY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLISSUEBY
        '
        Me.LBLISSUEBY.BackColor = System.Drawing.Color.Transparent
        Me.LBLISSUEBY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLISSUEBY.ForeColor = System.Drawing.Color.Black
        Me.LBLISSUEBY.Location = New System.Drawing.Point(454, 76)
        Me.LBLISSUEBY.Name = "LBLISSUEBY"
        Me.LBLISSUEBY.Size = New System.Drawing.Size(55, 15)
        Me.LBLISSUEBY.TabIndex = 756
        Me.LBLISSUEBY.Text = "Issue By"
        Me.LBLISSUEBY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBFROMGODOWN
        '
        Me.CMBFROMGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFROMGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFROMGODOWN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFROMGODOWN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFROMGODOWN.FormattingEnabled = True
        Me.CMBFROMGODOWN.Location = New System.Drawing.Point(132, 44)
        Me.CMBFROMGODOWN.MaxDropDownItems = 14
        Me.CMBFROMGODOWN.Name = "CMBFROMGODOWN"
        Me.CMBFROMGODOWN.Size = New System.Drawing.Size(243, 22)
        Me.CMBFROMGODOWN.TabIndex = 2
        '
        'LBLTYPE
        '
        Me.LBLTYPE.AutoSize = True
        Me.LBLTYPE.BackColor = System.Drawing.Color.Transparent
        Me.LBLTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTYPE.Location = New System.Drawing.Point(48, 48)
        Me.LBLTYPE.Name = "LBLTYPE"
        Me.LBLTYPE.Size = New System.Drawing.Size(82, 14)
        Me.LBLTYPE.TabIndex = 754
        Me.LBLTYPE.Text = "From Godown"
        '
        'TXTREFRENCE
        '
        Me.TXTREFRENCE.BackColor = System.Drawing.Color.White
        Me.TXTREFRENCE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTREFRENCE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREFRENCE.Location = New System.Drawing.Point(511, 44)
        Me.TXTREFRENCE.MaxLength = 10
        Me.TXTREFRENCE.Name = "TXTREFRENCE"
        Me.TXTREFRENCE.Size = New System.Drawing.Size(144, 23)
        Me.TXTREFRENCE.TabIndex = 5
        Me.TXTREFRENCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLREFRENCE
        '
        Me.LBLREFRENCE.BackColor = System.Drawing.Color.Transparent
        Me.LBLREFRENCE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLREFRENCE.ForeColor = System.Drawing.Color.Black
        Me.LBLREFRENCE.Location = New System.Drawing.Point(441, 48)
        Me.LBLREFRENCE.Name = "LBLREFRENCE"
        Me.LBLREFRENCE.Size = New System.Drawing.Size(68, 15)
        Me.LBLREFRENCE.TabIndex = 673
        Me.LBLREFRENCE.Text = "Refrence No"
        Me.LBLREFRENCE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTDATE
        '
        Me.TXTDATE.AsciiOnly = True
        Me.TXTDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TXTDATE.Location = New System.Drawing.Point(845, 72)
        Me.TXTDATE.Mask = "00/00/0000"
        Me.TXTDATE.Name = "TXTDATE"
        Me.TXTDATE.Size = New System.Drawing.Size(82, 23)
        Me.TXTDATE.TabIndex = 1
        Me.TXTDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.TXTDATE.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(796, 412)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 15)
        Me.Label2.TabIndex = 748
        Me.Label2.Text = "Total"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(458, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 14)
        Me.Label11.TabIndex = 745
        Me.Label11.Text = "Barcode"
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBARCODE.Location = New System.Drawing.Point(511, 101)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(144, 23)
        Me.TXTBARCODE.TabIndex = 7
        '
        'TXTADD
        '
        Me.TXTADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTADD.Location = New System.Drawing.Point(664, 21)
        Me.TXTADD.Multiline = True
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(35, 22)
        Me.TXTADD.TabIndex = 0
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.White
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(707, 20)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(56, 23)
        Me.CMBCODE.TabIndex = 742
        Me.CMBCODE.Visible = False
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALMTRS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(909, 412)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(66, 15)
        Me.LBLTOTALMTRS.TabIndex = 659
        Me.LBLTOTALMTRS.Text = "0"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALPCS
        '
        Me.LBLTOTALPCS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALPCS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALPCS.Location = New System.Drawing.Point(838, 412)
        Me.LBLTOTALPCS.Name = "LBLTOTALPCS"
        Me.LBLTOTALPCS.Size = New System.Drawing.Size(74, 15)
        Me.LBLTOTALPCS.TabIndex = 655
        Me.LBLTOTALPCS.Text = "0"
        Me.LBLTOTALPCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(36, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 15)
        Me.Label3.TabIndex = 727
        Me.Label3.Text = "Transport Name"
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = CType(resources.GetObject("PBlock.Image"), System.Drawing.Image)
        Me.PBlock.Location = New System.Drawing.Point(707, 449)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 446
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'CMBTRANSPORTNAME
        '
        Me.CMBTRANSPORTNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTRANSPORTNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTRANSPORTNAME.BackColor = System.Drawing.Color.White
        Me.CMBTRANSPORTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTRANSPORTNAME.FormattingEnabled = True
        Me.CMBTRANSPORTNAME.Location = New System.Drawing.Point(132, 101)
        Me.CMBTRANSPORTNAME.MaxDropDownItems = 14
        Me.CMBTRANSPORTNAME.Name = "CMBTRANSPORTNAME"
        Me.CMBTRANSPORTNAME.Size = New System.Drawing.Size(243, 23)
        Me.CMBTRANSPORTNAME.TabIndex = 4
        '
        'TXTGODOWNNO
        '
        Me.TXTGODOWNNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGODOWNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGODOWNNO.Location = New System.Drawing.Point(845, 44)
        Me.TXTGODOWNNO.Name = "TXTGODOWNNO"
        Me.TXTGODOWNNO.ReadOnly = True
        Me.TXTGODOWNNO.Size = New System.Drawing.Size(82, 23)
        Me.TXTGODOWNNO.TabIndex = 0
        Me.TXTGODOWNNO.TabStop = False
        Me.TXTGODOWNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(811, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Date"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 134)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1119, 275)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.TXTBALENO)
        Me.TabPage1.Controls.Add(Me.TXTLOTNO)
        Me.TabPage1.Controls.Add(Me.CMBDESIGN)
        Me.TabPage1.Controls.Add(Me.TXTPCS)
        Me.TabPage1.Controls.Add(Me.TXTMTRS)
        Me.TabPage1.Controls.Add(Me.cmbcolor)
        Me.TabPage1.Controls.Add(Me.CMBQUALITY)
        Me.TabPage1.Controls.Add(Me.cmbitemname)
        Me.TabPage1.Controls.Add(Me.CMBPIECETYPE)
        Me.TabPage1.Controls.Add(Me.txtsrno)
        Me.TabPage1.Controls.Add(Me.GRIDJO)
        Me.TabPage1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1111, 247)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Item Details"
        '
        'TXTBALENO
        '
        Me.TXTBALENO.BackColor = System.Drawing.Color.White
        Me.TXTBALENO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALENO.Location = New System.Drawing.Point(534, 0)
        Me.TXTBALENO.Name = "TXTBALENO"
        Me.TXTBALENO.Size = New System.Drawing.Size(100, 23)
        Me.TXTBALENO.TabIndex = 9
        Me.TXTBALENO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.White
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(434, 0)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(100, 23)
        Me.TXTLOTNO.TabIndex = 8
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(634, 0)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(100, 23)
        Me.CMBDESIGN.TabIndex = 4
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.White
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(834, 0)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(50, 23)
        Me.TXTPCS.TabIndex = 6
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(884, 0)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(70, 23)
        Me.TXTMTRS.TabIndex = 7
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbcolor
        '
        Me.cmbcolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcolor.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcolor.FormattingEnabled = True
        Me.cmbcolor.Location = New System.Drawing.Point(734, 0)
        Me.cmbcolor.Name = "cmbcolor"
        Me.cmbcolor.Size = New System.Drawing.Size(100, 23)
        Me.cmbcolor.TabIndex = 5
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(294, 0)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(140, 23)
        Me.CMBQUALITY.TabIndex = 3
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbitemname.DropDownWidth = 400
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(144, 0)
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(150, 23)
        Me.cmbitemname.TabIndex = 2
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPIECETYPE.DropDownWidth = 400
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(44, 0)
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(100, 23)
        Me.CMBPIECETYPE.TabIndex = 1
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(4, 0)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(40, 23)
        Me.txtsrno.TabIndex = 0
        '
        'GRIDJO
        '
        Me.GRIDJO.AllowUserToAddRows = False
        Me.GRIDJO.AllowUserToDeleteRows = False
        Me.GRIDJO.AllowUserToResizeColumns = False
        Me.GRIDJO.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDJO.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDJO.BackgroundColor = System.Drawing.Color.White
        Me.GRIDJO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDJO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDJO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDJO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDJO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GPIECETYPE, Me.GMERCHANT, Me.GQUALITY, Me.GLOTNO, Me.GBALENO, Me.GDESIGN, Me.GCOLOR, Me.GPCS, Me.GUNIT, Me.GMTRS, Me.GBARCODE, Me.GOUTPCS, Me.GOUTMTRS, Me.GFROMNO, Me.GFROMSRNO, Me.GFROMTYPE})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDJO.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDJO.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDJO.Location = New System.Drawing.Point(4, 22)
        Me.GRIDJO.MultiSelect = False
        Me.GRIDJO.Name = "GRIDJO"
        Me.GRIDJO.RowHeadersVisible = False
        Me.GRIDJO.RowHeadersWidth = 30
        Me.GRIDJO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDJO.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDJO.RowTemplate.Height = 20
        Me.GRIDJO.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDJO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDJO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDJO.Size = New System.Drawing.Size(1104, 222)
        Me.GRIDJO.TabIndex = 0
        Me.GRIDJO.TabStop = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(402, 497)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(82, 27)
        Me.cmddelete.TabIndex = 11
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'CMDSELECTSTOCK
        '
        Me.CMDSELECTSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CMDSELECTSTOCK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSELECTSTOCK.FlatAppearance.BorderSize = 0
        Me.CMDSELECTSTOCK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSELECTSTOCK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSELECTSTOCK.Location = New System.Drawing.Point(361, 464)
        Me.CMDSELECTSTOCK.Name = "CMDSELECTSTOCK"
        Me.CMDSELECTSTOCK.Size = New System.Drawing.Size(82, 27)
        Me.CMDSELECTSTOCK.TabIndex = 9
        Me.CMDSELECTSTOCK.Text = "Select S&tock"
        Me.CMDSELECTSTOCK.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(25, 428)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 116)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 21)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(253, 87)
        Me.txtremarks.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Location = New System.Drawing.Point(537, 464)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(82, 27)
        Me.cmdclear.TabIndex = 10
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
        Me.cmdok.Location = New System.Drawing.Point(449, 464)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(82, 27)
        Me.cmdok.TabIndex = 8
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
        Me.cmdexit.Location = New System.Drawing.Point(488, 497)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(82, 27)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(261, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(74, 22)
        Me.tstxtbillno.TabIndex = 15
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(773, 480)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 445
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkchange.Location = New System.Drawing.Point(794, 23)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 441
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(63, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 434
        Me.Label6.Text = "To Godown"
        '
        'CMBTOGODOWN
        '
        Me.CMBTOGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTOGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTOGODOWN.BackColor = System.Drawing.Color.White
        Me.CMBTOGODOWN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTOGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTOGODOWN.FormattingEnabled = True
        Me.CMBTOGODOWN.Location = New System.Drawing.Point(132, 72)
        Me.CMBTOGODOWN.MaxDropDownItems = 14
        Me.CMBTOGODOWN.Name = "CMBTOGODOWN"
        Me.CMBTOGODOWN.Size = New System.Drawing.Size(243, 23)
        Me.CMBTOGODOWN.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.TOOLSMS, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 610
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
        'TOOLSMS
        '
        Me.TOOLSMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLSMS.Image = CType(resources.GetObject("TOOLSMS.Image"), System.Drawing.Image)
        Me.TOOLSMS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLSMS.Name = "TOOLSMS"
        Me.TOOLSMS.Size = New System.Drawing.Size(23, 22)
        Me.TOOLSMS.Text = "&SMS"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = CType(resources.GetObject("toolprevious.Image"), System.Drawing.Image)
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = CType(resources.GetObject("toolnext.Image"), System.Drawing.Image)
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
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.HeaderText = "Piece Type"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.ReadOnly = True
        Me.GPIECETYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPIECETYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GMERCHANT
        '
        Me.GMERCHANT.HeaderText = "Item Name"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.ReadOnly = True
        Me.GMERCHANT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMERCHANT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMERCHANT.Width = 150
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 140
        '
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'GBALENO
        '
        Me.GBALENO.HeaderText = "Bale No"
        Me.GBALENO.Name = "GBALENO"
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design No"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCOLOR
        '
        Me.GCOLOR.HeaderText = "Shade"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOLOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GPCS
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPCS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCS.Width = 50
        '
        'GUNIT
        '
        Me.GUNIT.HeaderText = "Unit"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.ReadOnly = True
        Me.GUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GUNIT.Visible = False
        '
        'GMTRS
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle4
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 70
        '
        'GBARCODE
        '
        Me.GBARCODE.HeaderText = "Barcode"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.ReadOnly = True
        Me.GBARCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBARCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBARCODE.Width = 120
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
        Me.GOUTMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GOUTMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GOUTMTRS.Visible = False
        '
        'GFROMNO
        '
        Me.GFROMNO.HeaderText = "FROMNO"
        Me.GFROMNO.Name = "GFROMNO"
        Me.GFROMNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GFROMNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GFROMNO.Visible = False
        '
        'GFROMSRNO
        '
        Me.GFROMSRNO.HeaderText = "FROMSRNO"
        Me.GFROMSRNO.Name = "GFROMSRNO"
        Me.GFROMSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GFROMSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GFROMSRNO.Visible = False
        '
        'GFROMTYPE
        '
        Me.GFROMTYPE.HeaderText = "FROMTYPE"
        Me.GFROMTYPE.Name = "GFROMTYPE"
        Me.GFROMTYPE.Visible = False
        '
        'InterGodownTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "InterGodownTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Inter Godown Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GRIDJO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTISSUEBY As TextBox
    Friend WithEvents LBLISSUEBY As Label
    Friend WithEvents CMBFROMGODOWN As ComboBox
    Friend WithEvents LBLTYPE As Label
    Friend WithEvents TXTREFRENCE As TextBox
    Friend WithEvents LBLREFRENCE As Label
    Friend WithEvents TXTDATE As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTBARCODE As TextBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents LBLTOTALMTRS As Label
    Friend WithEvents LBLTOTALPCS As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PBlock As PictureBox
    Friend WithEvents CMBTRANSPORTNAME As ComboBox
    Friend WithEvents TXTGODOWNNO As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents CMBDESIGN As ComboBox
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents TXTMTRS As TextBox
    Friend WithEvents cmbcolor As ComboBox
    Friend WithEvents CMBQUALITY As ComboBox
    Friend WithEvents cmbitemname As ComboBox
    Friend WithEvents CMBPIECETYPE As ComboBox
    Friend WithEvents txtsrno As TextBox
    Friend WithEvents GRIDJO As DataGridView
    Friend WithEvents cmddelete As Button
    Friend WithEvents CMDSELECTSTOCK As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents cmdclear As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents lbllocked As Label
    Friend WithEvents chkchange As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CMBTOGODOWN As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents TOOLSMS As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents toolprevious As ToolStripButton
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents TXTBALENO As TextBox
    Friend WithEvents TXTLOTNO As TextBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GPIECETYPE As DataGridViewTextBoxColumn
    Friend WithEvents GMERCHANT As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As DataGridViewTextBoxColumn
    Friend WithEvents GBALENO As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As DataGridViewTextBoxColumn
    Friend WithEvents GPCS As DataGridViewTextBoxColumn
    Friend WithEvents GUNIT As DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GBARCODE As DataGridViewTextBoxColumn
    Friend WithEvents GOUTPCS As DataGridViewTextBoxColumn
    Friend WithEvents GOUTMTRS As DataGridViewTextBoxColumn
    Friend WithEvents GFROMNO As DataGridViewTextBoxColumn
    Friend WithEvents GFROMSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GFROMTYPE As DataGridViewTextBoxColumn
End Class
