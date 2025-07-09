<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpeningStock))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtpcs = New System.Windows.Forms.TextBox()
        Me.cmbmerchant = New System.Windows.Forms.ComboBox()
        Me.txtcut = New System.Windows.Forms.TextBox()
        Me.cmbcolor = New System.Windows.Forms.ComboBox()
        Me.cmbpiecetype = New System.Windows.Forms.ComboBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.txtMtrs = New System.Windows.Forms.TextBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTYARDS = New System.Windows.Forms.TextBox()
        Me.TXTSEARCHBARCODE = New System.Windows.Forms.TextBox()
        Me.LBLBARCODE = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.LBLTO = New System.Windows.Forms.Label()
        Me.LBLFROM = New System.Windows.Forms.Label()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.CHKPRINT = New System.Windows.Forms.CheckBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.cmbdyeing = New System.Windows.Forms.ComboBox()
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CMBPER = New System.Windows.Forms.ComboBox()
        Me.CMBRACK = New System.Windows.Forms.ComboBox()
        Me.CMBSHELF = New System.Windows.Forms.ComboBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.TXTAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.cmbtoname = New System.Windows.Forms.ComboBox()
        Me.cmbgodown = New System.Windows.Forms.ComboBox()
        Me.TXTWT = New System.Windows.Forms.TextBox()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.gridstock = New System.Windows.Forms.DataGridView()
        Me.cmbquality = New System.Windows.Forms.ComboBox()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.openingdate = New System.Windows.Forms.DateTimePicker()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpiecetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMERCHANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gQuality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcolor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gProcess = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gtoname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBILLNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGODOWN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gMtrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRACK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSHELF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMOUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gdone = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gOutpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.goutmtrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridstock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpcs
        '
        Me.txtpcs.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtpcs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpcs.Location = New System.Drawing.Point(1149, 0)
        Me.txtpcs.Name = "txtpcs"
        Me.txtpcs.Size = New System.Drawing.Size(60, 22)
        Me.txtpcs.TabIndex = 14
        Me.txtpcs.Text = "1"
        Me.txtpcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbmerchant.DropDownWidth = 400
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(183, 0)
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(133, 22)
        Me.cmbmerchant.TabIndex = 3
        '
        'txtcut
        '
        Me.txtcut.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcut.Location = New System.Drawing.Point(990, 0)
        Me.txtcut.Name = "txtcut"
        Me.txtcut.Size = New System.Drawing.Size(40, 22)
        Me.txtcut.TabIndex = 11
        Me.txtcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbcolor
        '
        Me.cmbcolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcolor.FormattingEnabled = True
        Me.cmbcolor.Location = New System.Drawing.Point(516, 0)
        Me.cmbcolor.Name = "cmbcolor"
        Me.cmbcolor.Size = New System.Drawing.Size(80, 22)
        Me.cmbcolor.TabIndex = 6
        '
        'cmbpiecetype
        '
        Me.cmbpiecetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbpiecetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbpiecetype.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbpiecetype.DropDownWidth = 400
        Me.cmbpiecetype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpiecetype.FormattingEnabled = True
        Me.cmbpiecetype.Location = New System.Drawing.Point(103, 0)
        Me.cmbpiecetype.Name = "cmbpiecetype"
        Me.cmbpiecetype.Size = New System.Drawing.Size(80, 22)
        Me.cmbpiecetype.TabIndex = 2
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(3, 0)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(40, 22)
        Me.txtsrno.TabIndex = 0
        Me.txtsrno.TabStop = False
        Me.txtsrno.Text = " "
        '
        'txtMtrs
        '
        Me.txtMtrs.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtMtrs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMtrs.Location = New System.Drawing.Point(1209, 0)
        Me.txtMtrs.Name = "txtMtrs"
        Me.txtMtrs.Size = New System.Drawing.Size(80, 22)
        Me.txtMtrs.TabIndex = 15
        Me.txtMtrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTYARDS)
        Me.BlendPanel1.Controls.Add(Me.TXTSEARCHBARCODE)
        Me.BlendPanel1.Controls.Add(Me.LBLBARCODE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.LBLTO)
        Me.BlendPanel1.Controls.Add(Me.LBLFROM)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.CHKPRINT)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.cmbdyeing)
        Me.BlendPanel1.Controls.Add(Me.CMBPROCESS)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.Panel1)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.openingdate)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 599)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTYARDS
        '
        Me.TXTYARDS.BackColor = System.Drawing.Color.White
        Me.TXTYARDS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTYARDS.Location = New System.Drawing.Point(1142, 16)
        Me.TXTYARDS.Name = "TXTYARDS"
        Me.TXTYARDS.Size = New System.Drawing.Size(80, 22)
        Me.TXTYARDS.TabIndex = 0
        Me.TXTYARDS.TabStop = False
        Me.TXTYARDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTYARDS.Visible = False
        '
        'TXTSEARCHBARCODE
        '
        Me.TXTSEARCHBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTSEARCHBARCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTSEARCHBARCODE.Location = New System.Drawing.Point(930, 15)
        Me.TXTSEARCHBARCODE.Name = "TXTSEARCHBARCODE"
        Me.TXTSEARCHBARCODE.Size = New System.Drawing.Size(122, 22)
        Me.TXTSEARCHBARCODE.TabIndex = 759
        '
        'LBLBARCODE
        '
        Me.LBLBARCODE.AutoSize = True
        Me.LBLBARCODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLBARCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBARCODE.ForeColor = System.Drawing.Color.Black
        Me.LBLBARCODE.Location = New System.Drawing.Point(837, 20)
        Me.LBLBARCODE.Name = "LBLBARCODE"
        Me.LBLBARCODE.Size = New System.Drawing.Size(92, 15)
        Me.LBLBARCODE.TabIndex = 722
        Me.LBLBARCODE.Text = "Search Barcode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 530)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(696, 60)
        Me.Label1.TabIndex = 721
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'TXTTO
        '
        Me.TXTTO.BackColor = System.Drawing.Color.White
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTTO.Location = New System.Drawing.Point(683, 16)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(41, 23)
        Me.TXTTO.TabIndex = 720
        Me.TXTTO.Text = " "
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.Transparent
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.ForeColor = System.Drawing.Color.Black
        Me.LBLTO.Location = New System.Drawing.Point(663, 20)
        Me.LBLTO.Name = "LBLTO"
        Me.LBLTO.Size = New System.Drawing.Size(19, 15)
        Me.LBLTO.TabIndex = 719
        Me.LBLTO.Text = "To"
        '
        'LBLFROM
        '
        Me.LBLFROM.AutoSize = True
        Me.LBLFROM.BackColor = System.Drawing.Color.Transparent
        Me.LBLFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFROM.ForeColor = System.Drawing.Color.Black
        Me.LBLFROM.Location = New System.Drawing.Point(507, 20)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(113, 15)
        Me.LBLFROM.TabIndex = 718
        Me.LBLFROM.Text = "Print Barcode From"
        '
        'TXTFROM
        '
        Me.TXTFROM.BackColor = System.Drawing.Color.White
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFROM.Location = New System.Drawing.Point(619, 16)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(41, 23)
        Me.TXTFROM.TabIndex = 717
        Me.TXTFROM.Text = " "
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHKPRINT
        '
        Me.CHKPRINT.AutoSize = True
        Me.CHKPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CHKPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPRINT.Location = New System.Drawing.Point(270, 18)
        Me.CHKPRINT.Name = "CHKPRINT"
        Me.CHKPRINT.Size = New System.Drawing.Size(134, 19)
        Me.CHKPRINT.TabIndex = 716
        Me.CHKPRINT.Text = "Print Each Bar Code"
        Me.CHKPRINT.UseVisualStyleBackColor = False
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(289, 16)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTNO.TabIndex = 715
        Me.TXTNO.Text = " "
        Me.TXTNO.Visible = False
        '
        'cmbdyeing
        '
        Me.cmbdyeing.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdyeing.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdyeing.FormattingEnabled = True
        Me.cmbdyeing.Location = New System.Drawing.Point(739, 17)
        Me.cmbdyeing.Name = "cmbdyeing"
        Me.cmbdyeing.Size = New System.Drawing.Size(80, 22)
        Me.cmbdyeing.TabIndex = 12
        Me.cmbdyeing.Visible = False
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROCESS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROCESS.DropDownWidth = 400
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Location = New System.Drawing.Point(840, 13)
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(40, 22)
        Me.CMBPROCESS.TabIndex = 714
        Me.CMBPROCESS.Visible = False
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBARCODE.Location = New System.Drawing.Point(881, 16)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(111, 22)
        Me.TXTBARCODE.TabIndex = 713
        Me.TXTBARCODE.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Date :"
        Me.Label6.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.DropDownWidth = 400
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(436, 16)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMBCODE.TabIndex = 20
        Me.CMBCODE.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Linen
        Me.Panel1.Controls.Add(Me.CMBPER)
        Me.Panel1.Controls.Add(Me.CMBRACK)
        Me.Panel1.Controls.Add(Me.CMBSHELF)
        Me.Panel1.Controls.Add(Me.TXTREMARKS)
        Me.Panel1.Controls.Add(Me.TXTAMOUNT)
        Me.Panel1.Controls.Add(Me.TXTRATE)
        Me.Panel1.Controls.Add(Me.TXTBILLNO)
        Me.Panel1.Controls.Add(Me.CMBDESIGNNO)
        Me.Panel1.Controls.Add(Me.cmbtoname)
        Me.Panel1.Controls.Add(Me.cmbgodown)
        Me.Panel1.Controls.Add(Me.TXTWT)
        Me.Panel1.Controls.Add(Me.TXTLOTNO)
        Me.Panel1.Controls.Add(Me.gridstock)
        Me.Panel1.Controls.Add(Me.cmbquality)
        Me.Panel1.Controls.Add(Me.txtpcs)
        Me.Panel1.Controls.Add(Me.cmbname)
        Me.Panel1.Controls.Add(Me.cmbcolor)
        Me.Panel1.Controls.Add(Me.cmbpiecetype)
        Me.Panel1.Controls.Add(Me.txtMtrs)
        Me.Panel1.Controls.Add(Me.cmbunit)
        Me.Panel1.Controls.Add(Me.txtcut)
        Me.Panel1.Controls.Add(Me.txtsrno)
        Me.Panel1.Controls.Add(Me.cmbmerchant)
        Me.Panel1.Location = New System.Drawing.Point(13, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1209, 482)
        Me.Panel1.TabIndex = 0
        '
        'CMBPER
        '
        Me.CMBPER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPER.FormattingEnabled = True
        Me.CMBPER.Items.AddRange(New Object() {"Mtrs", "Qty"})
        Me.CMBPER.Location = New System.Drawing.Point(1289, 0)
        Me.CMBPER.Name = "CMBPER"
        Me.CMBPER.Size = New System.Drawing.Size(60, 22)
        Me.CMBPER.TabIndex = 16
        '
        'CMBRACK
        '
        Me.CMBRACK.FormattingEnabled = True
        Me.CMBRACK.Location = New System.Drawing.Point(1349, 0)
        Me.CMBRACK.Name = "CMBRACK"
        Me.CMBRACK.Size = New System.Drawing.Size(80, 22)
        Me.CMBRACK.TabIndex = 17
        '
        'CMBSHELF
        '
        Me.CMBSHELF.FormattingEnabled = True
        Me.CMBSHELF.Location = New System.Drawing.Point(1428, 0)
        Me.CMBSHELF.Name = "CMBSHELF"
        Me.CMBSHELF.Size = New System.Drawing.Size(80, 22)
        Me.CMBSHELF.TabIndex = 21
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.BackColor = System.Drawing.Color.White
        Me.TXTREMARKS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREMARKS.Location = New System.Drawing.Point(1668, 0)
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(120, 22)
        Me.TXTREMARKS.TabIndex = 20
        '
        'TXTAMOUNT
        '
        Me.TXTAMOUNT.BackColor = System.Drawing.Color.Linen
        Me.TXTAMOUNT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMOUNT.Location = New System.Drawing.Point(1588, 0)
        Me.TXTAMOUNT.Name = "TXTAMOUNT"
        Me.TXTAMOUNT.ReadOnly = True
        Me.TXTAMOUNT.Size = New System.Drawing.Size(80, 22)
        Me.TXTAMOUNT.TabIndex = 19
        Me.TXTAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.White
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(1508, 0)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(81, 22)
        Me.TXTRATE.TabIndex = 18
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.Location = New System.Drawing.Point(838, 0)
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.Size = New System.Drawing.Size(62, 22)
        Me.TXTBILLNO.TabIndex = 9
        Me.TXTBILLNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.White
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(435, 0)
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(81, 22)
        Me.CMBDESIGNNO.TabIndex = 5
        '
        'cmbtoname
        '
        Me.cmbtoname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtoname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtoname.DropDownWidth = 400
        Me.cmbtoname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtoname.FormattingEnabled = True
        Me.cmbtoname.Location = New System.Drawing.Point(714, 0)
        Me.cmbtoname.Name = "cmbtoname"
        Me.cmbtoname.Size = New System.Drawing.Size(124, 22)
        Me.cmbtoname.TabIndex = 8
        '
        'cmbgodown
        '
        Me.cmbgodown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgodown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgodown.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbgodown.DropDownWidth = 400
        Me.cmbgodown.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgodown.FormattingEnabled = True
        Me.cmbgodown.Location = New System.Drawing.Point(900, 0)
        Me.cmbgodown.Name = "cmbgodown"
        Me.cmbgodown.Size = New System.Drawing.Size(90, 22)
        Me.cmbgodown.TabIndex = 10
        '
        'TXTWT
        '
        Me.TXTWT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWT.Location = New System.Drawing.Point(1029, 0)
        Me.TXTWT.Name = "TXTWT"
        Me.TXTWT.Size = New System.Drawing.Size(60, 22)
        Me.TXTWT.TabIndex = 12
        Me.TXTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.White
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(43, 0)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(60, 22)
        Me.TXTLOTNO.TabIndex = 1
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridstock
        '
        Me.gridstock.AllowUserToAddRows = False
        Me.gridstock.AllowUserToDeleteRows = False
        Me.gridstock.AllowUserToResizeColumns = False
        Me.gridstock.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridstock.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridstock.BackgroundColor = System.Drawing.Color.White
        Me.gridstock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridstock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridstock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridstock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GNO, Me.GLOTNO, Me.gpiecetype, Me.GMERCHANT, Me.gQuality, Me.GDESIGN, Me.gcolor, Me.gProcess, Me.gname, Me.gtoname, Me.GBILLNO, Me.GGODOWN, Me.GCUT, Me.GWT, Me.Gunit, Me.Gpcs, Me.gMtrs, Me.GPer, Me.GRACK, Me.GSHELF, Me.GRATE, Me.GAMOUNT, Me.GREMARKS, Me.gBarcode, Me.gdone, Me.gOutpcs, Me.goutmtrs})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridstock.DefaultCellStyle = DataGridViewCellStyle11
        Me.gridstock.GridColor = System.Drawing.SystemColors.Control
        Me.gridstock.Location = New System.Drawing.Point(3, 22)
        Me.gridstock.MultiSelect = False
        Me.gridstock.Name = "gridstock"
        Me.gridstock.ReadOnly = True
        Me.gridstock.RowHeadersVisible = False
        Me.gridstock.RowHeadersWidth = 30
        Me.gridstock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        Me.gridstock.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gridstock.RowTemplate.Height = 20
        Me.gridstock.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridstock.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridstock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridstock.Size = New System.Drawing.Size(1913, 439)
        Me.gridstock.TabIndex = 16
        Me.gridstock.TabStop = False
        '
        'cmbquality
        '
        Me.cmbquality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbquality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbquality.BackColor = System.Drawing.Color.White
        Me.cmbquality.DropDownWidth = 400
        Me.cmbquality.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbquality.FormattingEnabled = True
        Me.cmbquality.Location = New System.Drawing.Point(315, 0)
        Me.cmbquality.Name = "cmbquality"
        Me.cmbquality.Size = New System.Drawing.Size(120, 22)
        Me.cmbquality.TabIndex = 4
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.DropDownWidth = 400
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(596, 0)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(119, 22)
        Me.cmbname.TabIndex = 7
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(1089, 0)
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(60, 22)
        Me.cmbunit.TabIndex = 13
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtadd.Location = New System.Drawing.Point(845, 13)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(30, 22)
        Me.txtadd.TabIndex = 15
        Me.txtadd.Text = " "
        Me.txtadd.Visible = False
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.DropDownWidth = 400
        Me.cmbtype.Enabled = False
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"INHOUSE", "JOBBERSTOCK"})
        Me.cmbtype.Location = New System.Drawing.Point(150, 16)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(99, 23)
        Me.cmbtype.TabIndex = 1
        '
        'openingdate
        '
        Me.openingdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.openingdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.openingdate.Location = New System.Drawing.Point(55, 16)
        Me.openingdate.Name = "openingdate"
        Me.openingdate.Size = New System.Drawing.Size(88, 23)
        Me.openingdate.TabIndex = 0
        Me.openingdate.Value = New Date(2013, 4, 1, 8, 54, 0, 0)
        Me.openingdate.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(1035, 530)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
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
        Me.gsrno.Width = 40
        '
        'GNO
        '
        Me.GNO.HeaderText = "NO"
        Me.GNO.Name = "GNO"
        Me.GNO.ReadOnly = True
        Me.GNO.Visible = False
        '
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No."
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.ReadOnly = True
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.GLOTNO.Width = 60
        '
        'gpiecetype
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gpiecetype.DefaultCellStyle = DataGridViewCellStyle3
        Me.gpiecetype.HeaderText = "Piece Type"
        Me.gpiecetype.Name = "gpiecetype"
        Me.gpiecetype.ReadOnly = True
        Me.gpiecetype.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gpiecetype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gpiecetype.Width = 80
        '
        'GMERCHANT
        '
        Me.GMERCHANT.HeaderText = "Item Name"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.ReadOnly = True
        Me.GMERCHANT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMERCHANT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMERCHANT.Width = 133
        '
        'gQuality
        '
        Me.gQuality.HeaderText = "Quality"
        Me.gQuality.Name = "gQuality"
        Me.gQuality.ReadOnly = True
        Me.gQuality.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gQuality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gQuality.Width = 120
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGN.Width = 80
        '
        'gcolor
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = Nothing
        Me.gcolor.DefaultCellStyle = DataGridViewCellStyle4
        Me.gcolor.HeaderText = "Shade"
        Me.gcolor.Name = "gcolor"
        Me.gcolor.ReadOnly = True
        Me.gcolor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gcolor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gcolor.Width = 80
        '
        'gProcess
        '
        Me.gProcess.HeaderText = "Process"
        Me.gProcess.Name = "gProcess"
        Me.gProcess.ReadOnly = True
        Me.gProcess.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gProcess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gProcess.Visible = False
        '
        'gname
        '
        Me.gname.HeaderText = "Purchase Name"
        Me.gname.Name = "gname"
        Me.gname.ReadOnly = True
        Me.gname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gname.Width = 119
        '
        'gtoname
        '
        Me.gtoname.HeaderText = "Jobber Name"
        Me.gtoname.Name = "gtoname"
        Me.gtoname.ReadOnly = True
        Me.gtoname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gtoname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gtoname.Width = 124
        '
        'GBILLNO
        '
        Me.GBILLNO.HeaderText = "Bill No"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.ReadOnly = True
        Me.GBILLNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBILLNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBILLNO.Width = 60
        '
        'GGODOWN
        '
        Me.GGODOWN.HeaderText = "Godown"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.ReadOnly = True
        Me.GGODOWN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGODOWN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGODOWN.Width = 90
        '
        'GCUT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCUT.DefaultCellStyle = DataGridViewCellStyle5
        Me.GCUT.HeaderText = "Cut"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.ReadOnly = True
        Me.GCUT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUT.Width = 40
        '
        'GWT
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWT.DefaultCellStyle = DataGridViewCellStyle6
        Me.GWT.HeaderText = "Wt"
        Me.GWT.Name = "GWT"
        Me.GWT.ReadOnly = True
        Me.GWT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GWT.Width = 60
        '
        'Gunit
        '
        Me.Gunit.HeaderText = "Unit"
        Me.Gunit.Name = "Gunit"
        Me.Gunit.ReadOnly = True
        Me.Gunit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gunit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gunit.Width = 60
        '
        'Gpcs
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Gpcs.DefaultCellStyle = DataGridViewCellStyle7
        Me.Gpcs.HeaderText = "Pcs"
        Me.Gpcs.Name = "Gpcs"
        Me.Gpcs.ReadOnly = True
        Me.Gpcs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gpcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gpcs.Width = 60
        '
        'gMtrs
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gMtrs.DefaultCellStyle = DataGridViewCellStyle8
        Me.gMtrs.HeaderText = "Mtrs"
        Me.gMtrs.Name = "gMtrs"
        Me.gMtrs.ReadOnly = True
        Me.gMtrs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gMtrs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gMtrs.Width = 80
        '
        'GPer
        '
        Me.GPer.HeaderText = "Per"
        Me.GPer.Name = "GPer"
        Me.GPer.ReadOnly = True
        Me.GPer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GPer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPer.Width = 60
        '
        'GRACK
        '
        Me.GRACK.HeaderText = "Rack"
        Me.GRACK.Name = "GRACK"
        Me.GRACK.ReadOnly = True
        Me.GRACK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRACK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRACK.Width = 80
        '
        'GSHELF
        '
        Me.GSHELF.HeaderText = "Shelf"
        Me.GSHELF.Name = "GSHELF"
        Me.GSHELF.ReadOnly = True
        Me.GSHELF.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHELF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSHELF.Width = 80
        '
        'GRATE
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GRATE.DefaultCellStyle = DataGridViewCellStyle9
        Me.GRATE.HeaderText = "Rate"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.ReadOnly = True
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 80
        '
        'GAMOUNT
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GAMOUNT.DefaultCellStyle = DataGridViewCellStyle10
        Me.GAMOUNT.HeaderText = "Amount"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.ReadOnly = True
        Me.GAMOUNT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GAMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GAMOUNT.Width = 80
        '
        'GREMARKS
        '
        Me.GREMARKS.HeaderText = "Remarks"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.ReadOnly = True
        Me.GREMARKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREMARKS.Width = 120
        '
        'gBarcode
        '
        Me.gBarcode.HeaderText = "Barcode"
        Me.gBarcode.Name = "gBarcode"
        Me.gBarcode.ReadOnly = True
        Me.gBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gBarcode.Width = 135
        '
        'gdone
        '
        Me.gdone.HeaderText = "done"
        Me.gdone.Name = "gdone"
        Me.gdone.ReadOnly = True
        Me.gdone.Visible = False
        '
        'gOutpcs
        '
        Me.gOutpcs.HeaderText = "Outpcs"
        Me.gOutpcs.Name = "gOutpcs"
        Me.gOutpcs.ReadOnly = True
        Me.gOutpcs.Visible = False
        '
        'goutmtrs
        '
        Me.goutmtrs.HeaderText = "Out Mtrs"
        Me.goutmtrs.Name = "goutmtrs"
        Me.goutmtrs.ReadOnly = True
        Me.goutmtrs.Visible = False
        '
        'OpeningStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1234, 599)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridstock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtpcs As System.Windows.Forms.TextBox
    Friend WithEvents cmbmerchant As System.Windows.Forms.ComboBox
    Friend WithEvents txtcut As System.Windows.Forms.TextBox
    Friend WithEvents cmbcolor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpiecetype As System.Windows.Forms.ComboBox
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents txtMtrs As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbquality As System.Windows.Forms.ComboBox
    Friend WithEvents gridstock As System.Windows.Forms.DataGridView
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents openingdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTWT As System.Windows.Forms.TextBox
    Friend WithEvents cmbgodown As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtoname As System.Windows.Forms.ComboBox
    Friend WithEvents TXTBARCODE As System.Windows.Forms.TextBox
    Friend WithEvents CMBDESIGNNO As System.Windows.Forms.ComboBox
    Friend WithEvents CMBPROCESS As System.Windows.Forms.ComboBox
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents CHKPRINT As System.Windows.Forms.CheckBox
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents LBLTO As System.Windows.Forms.Label
    Friend WithEvents LBLFROM As System.Windows.Forms.Label
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents cmbdyeing As System.Windows.Forms.ComboBox
    Friend WithEvents TXTAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents TXTBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBLBARCODE As System.Windows.Forms.Label
    Friend WithEvents CMBRACK As System.Windows.Forms.ComboBox
    Friend WithEvents CMBSHELF As System.Windows.Forms.ComboBox
    Friend WithEvents TXTSEARCHBARCODE As System.Windows.Forms.TextBox
    Friend WithEvents CMBPER As System.Windows.Forms.ComboBox
    Friend WithEvents TXTYARDS As TextBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents GNO As DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As DataGridViewTextBoxColumn
    Friend WithEvents gpiecetype As DataGridViewTextBoxColumn
    Friend WithEvents GMERCHANT As DataGridViewTextBoxColumn
    Friend WithEvents gQuality As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewTextBoxColumn
    Friend WithEvents gcolor As DataGridViewTextBoxColumn
    Friend WithEvents gProcess As DataGridViewTextBoxColumn
    Friend WithEvents gname As DataGridViewTextBoxColumn
    Friend WithEvents gtoname As DataGridViewTextBoxColumn
    Friend WithEvents GBILLNO As DataGridViewTextBoxColumn
    Friend WithEvents GGODOWN As DataGridViewTextBoxColumn
    Friend WithEvents GCUT As DataGridViewTextBoxColumn
    Friend WithEvents GWT As DataGridViewTextBoxColumn
    Friend WithEvents Gunit As DataGridViewTextBoxColumn
    Friend WithEvents Gpcs As DataGridViewTextBoxColumn
    Friend WithEvents gMtrs As DataGridViewTextBoxColumn
    Friend WithEvents GPer As DataGridViewTextBoxColumn
    Friend WithEvents GRACK As DataGridViewTextBoxColumn
    Friend WithEvents GSHELF As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GAMOUNT As DataGridViewTextBoxColumn
    Friend WithEvents GREMARKS As DataGridViewTextBoxColumn
    Friend WithEvents gBarcode As DataGridViewTextBoxColumn
    Friend WithEvents gdone As DataGridViewCheckBoxColumn
    Friend WithEvents gOutpcs As DataGridViewTextBoxColumn
    Friend WithEvents goutmtrs As DataGridViewTextBoxColumn
End Class
