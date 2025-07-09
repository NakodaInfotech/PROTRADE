<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnWastage
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YarnWastage))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.LBLTOTALCONES = New System.Windows.Forms.Label
        Me.LBLNAME = New System.Windows.Forms.Label
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        Me.CMBOURGODOWN = New System.Windows.Forms.ComboBox
        Me.LBLGODOWN = New System.Windows.Forms.Label
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.cmbcode = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.tooldelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.LBLTOTALWT = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TXTCONES = New System.Windows.Forms.TextBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.TXTLOTNO = New System.Windows.Forms.TextBox
        Me.CMBSHADE = New System.Windows.Forms.ComboBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.TXTNARR = New System.Windows.Forms.TextBox
        Me.TXTWT = New System.Windows.Forms.TextBox
        Me.CMBMILLNAME = New System.Windows.Forms.ComboBox
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox
        Me.TXTSRNO = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.BTNMILL = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.BTNNARRATION = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GRIDWASTAGE = New System.Windows.Forms.DataGridView
        Me.tbupload = New System.Windows.Forms.TabPage
        Me.TXTIMGPATH = New System.Windows.Forms.TextBox
        Me.PBSOFTCOPY = New System.Windows.Forms.PictureBox
        Me.txtuploadname = New System.Windows.Forms.TextBox
        Me.TXTUPLOADSRNO = New System.Windows.Forms.TextBox
        Me.txtuploadremarks = New System.Windows.Forms.TextBox
        Me.gridupload = New System.Windows.Forms.DataGridView
        Me.GUSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GUREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GUNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GUIMGPATH = New System.Windows.Forms.DataGridViewImageColumn
        Me.CMDREMOVE = New System.Windows.Forms.Button
        Me.CMDUPLOAD = New System.Windows.Forms.Button
        Me.CMDVIEW = New System.Windows.Forms.Button
        Me.TextBox18 = New System.Windows.Forms.TextBox
        Me.TextBox19 = New System.Windows.Forms.TextBox
        Me.TextBox20 = New System.Windows.Forms.TextBox
        Me.DTENTRYDATE = New System.Windows.Forms.MaskedTextBox
        Me.TXTWASTAGENO = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblgrndate = New System.Windows.Forms.Label
        Me.PBlock = New System.Windows.Forms.PictureBox
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lbllocked = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMILLNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GSHADE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gwt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCONES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GNARRATION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GOUTWT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GRIDWASTAGE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbupload.SuspendLayout()
        CType(Me.PBSOFTCOPY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridupload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALCONES)
        Me.BlendPanel1.Controls.Add(Me.LBLNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBOURGODOWN)
        Me.BlendPanel1.Controls.Add(Me.LBLGODOWN)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.cmbcode)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALWT)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.DTENTRYDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTWASTAGENO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.lblgrndate)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'LBLTOTALCONES
        '
        Me.LBLTOTALCONES.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALCONES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALCONES.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALCONES.Location = New System.Drawing.Point(957, 464)
        Me.LBLTOTALCONES.Name = "LBLTOTALCONES"
        Me.LBLTOTALCONES.Size = New System.Drawing.Size(58, 15)
        Me.LBLTOTALCONES.TabIndex = 821
        Me.LBLTOTALCONES.Text = "0"
        Me.LBLTOTALCONES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLNAME
        '
        Me.LBLNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBLNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNAME.ForeColor = System.Drawing.Color.Black
        Me.LBLNAME.Location = New System.Drawing.Point(40, 74)
        Me.LBLNAME.Name = "LBLNAME"
        Me.LBLNAME.Size = New System.Drawing.Size(91, 15)
        Me.LBLNAME.TabIndex = 820
        Me.LBLNAME.Text = "Warper Name"
        Me.LBLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(133, 70)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(246, 23)
        Me.CMBNAME.TabIndex = 2
        '
        'CMBOURGODOWN
        '
        Me.CMBOURGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOURGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOURGODOWN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBOURGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOURGODOWN.FormattingEnabled = True
        Me.CMBOURGODOWN.Location = New System.Drawing.Point(133, 41)
        Me.CMBOURGODOWN.MaxDropDownItems = 14
        Me.CMBOURGODOWN.Name = "CMBOURGODOWN"
        Me.CMBOURGODOWN.Size = New System.Drawing.Size(246, 23)
        Me.CMBOURGODOWN.TabIndex = 1
        Me.CMBOURGODOWN.TabStop = False
        Me.CMBOURGODOWN.Visible = False
        '
        'LBLGODOWN
        '
        Me.LBLGODOWN.AutoSize = True
        Me.LBLGODOWN.BackColor = System.Drawing.Color.Transparent
        Me.LBLGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGODOWN.ForeColor = System.Drawing.Color.Black
        Me.LBLGODOWN.Location = New System.Drawing.Point(45, 45)
        Me.LBLGODOWN.Name = "LBLGODOWN"
        Me.LBLGODOWN.Size = New System.Drawing.Size(86, 15)
        Me.LBLGODOWN.TabIndex = 818
        Me.LBLGODOWN.Text = "Godown Name"
        Me.LBLGODOWN.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(481, 28)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(29, 21)
        Me.TXTADD.TabIndex = 806
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'cmbcode
        '
        Me.cmbcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcode.FormattingEnabled = True
        Me.cmbcode.Location = New System.Drawing.Point(516, 28)
        Me.cmbcode.Name = "cmbcode"
        Me.cmbcode.Size = New System.Drawing.Size(25, 23)
        Me.cmbcode.TabIndex = 649
        Me.cmbcode.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(23, 464)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 89)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 16)
        Me.txtremarks.MaxLength = 2000
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(257, 65)
        Me.txtremarks.TabIndex = 0
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(239, 2)
        Me.tstxtbillno.MaxLength = 50
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(61, 22)
        Me.tstxtbillno.TabIndex = 9
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 646
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
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'LBLTOTALWT
        '
        Me.LBLTOTALWT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALWT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALWT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALWT.Location = New System.Drawing.Point(835, 464)
        Me.LBLTOTALWT.Name = "LBLTOTALWT"
        Me.LBLTOTALWT.Size = New System.Drawing.Size(84, 14)
        Me.LBLTOTALWT.TabIndex = 643
        Me.LBLTOTALWT.Text = "0.000"
        Me.LBLTOTALWT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(791, 464)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 635
        Me.Label10.Text = "Total"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tbupload)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(10, 107)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1164, 351)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.TXTCONES)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.Button7)
        Me.TabPage1.Controls.Add(Me.TXTLOTNO)
        Me.TabPage1.Controls.Add(Me.CMBSHADE)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.CMBDESIGN)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.CMBTYPE)
        Me.TabPage1.Controls.Add(Me.TXTNARR)
        Me.TabPage1.Controls.Add(Me.TXTWT)
        Me.TabPage1.Controls.Add(Me.CMBMILLNAME)
        Me.TabPage1.Controls.Add(Me.CMBQUALITY)
        Me.TabPage1.Controls.Add(Me.TXTSRNO)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.BTNMILL)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.BTNNARRATION)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.GRIDWASTAGE)
        Me.TabPage1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1156, 323)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Item Details"
        '
        'TXTCONES
        '
        Me.TXTCONES.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCONES.Location = New System.Drawing.Point(873, 30)
        Me.TXTCONES.MaxLength = 200
        Me.TXTCONES.Name = "TXTCONES"
        Me.TXTCONES.Size = New System.Drawing.Size(80, 22)
        Me.TXTCONES.TabIndex = 7
        Me.TXTCONES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.Black
        Me.Button8.Location = New System.Drawing.Point(875, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(78, 27)
        Me.Button8.TabIndex = 822
        Me.Button8.TabStop = False
        Me.Button8.Text = "Cones"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(734, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 27)
        Me.Button7.TabIndex = 821
        Me.Button7.TabStop = False
        Me.Button7.Text = "Lot No."
        Me.Button7.UseVisualStyleBackColor = False
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.Location = New System.Drawing.Point(733, 30)
        Me.TXTLOTNO.MaxLength = 200
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(80, 22)
        Me.TXTLOTNO.TabIndex = 5
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.BackColor = System.Drawing.Color.White
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(633, 30)
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(100, 22)
        Me.CMBSHADE.TabIndex = 4
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(633, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 27)
        Me.Button5.TabIndex = 684
        Me.Button5.TabStop = False
        Me.Button5.Text = "Shade"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.BackColor = System.Drawing.Color.White
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(533, 30)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(100, 22)
        Me.CMBDESIGN.TabIndex = 3
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(533, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 27)
        Me.Button4.TabIndex = 682
        Me.Button4.TabStop = False
        Me.Button4.Text = "Design"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"Wastage", "Longation", "Shortage"})
        Me.CMBTYPE.Location = New System.Drawing.Point(33, 30)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(100, 22)
        Me.CMBTYPE.TabIndex = 0
        '
        'TXTNARR
        '
        Me.TXTNARR.Location = New System.Drawing.Point(953, 30)
        Me.TXTNARR.MaxLength = 200
        Me.TXTNARR.Name = "TXTNARR"
        Me.TXTNARR.Size = New System.Drawing.Size(180, 22)
        Me.TXTNARR.TabIndex = 8
        '
        'TXTWT
        '
        Me.TXTWT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWT.Location = New System.Drawing.Point(813, 30)
        Me.TXTWT.MaxLength = 10
        Me.TXTWT.Name = "TXTWT"
        Me.TXTWT.Size = New System.Drawing.Size(60, 22)
        Me.TXTWT.TabIndex = 6
        Me.TXTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBMILLNAME
        '
        Me.CMBMILLNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMILLNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMILLNAME.BackColor = System.Drawing.Color.White
        Me.CMBMILLNAME.FormattingEnabled = True
        Me.CMBMILLNAME.Location = New System.Drawing.Point(333, 30)
        Me.CMBMILLNAME.Name = "CMBMILLNAME"
        Me.CMBMILLNAME.Size = New System.Drawing.Size(200, 22)
        Me.CMBMILLNAME.TabIndex = 2
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(133, 30)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(200, 22)
        Me.CMBQUALITY.TabIndex = 1
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Location = New System.Drawing.Point(3, 30)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(30, 22)
        Me.TXTSRNO.TabIndex = 680
        Me.TXTSRNO.TabStop = False
        Me.TXTSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(33, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 27)
        Me.Button2.TabIndex = 671
        Me.Button2.TabStop = False
        Me.Button2.Text = "Type"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'BTNMILL
        '
        Me.BTNMILL.BackColor = System.Drawing.Color.Transparent
        Me.BTNMILL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNMILL.FlatAppearance.BorderSize = 0
        Me.BTNMILL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMILL.ForeColor = System.Drawing.Color.Black
        Me.BTNMILL.Location = New System.Drawing.Point(333, 2)
        Me.BTNMILL.Name = "BTNMILL"
        Me.BTNMILL.Size = New System.Drawing.Size(200, 27)
        Me.BTNMILL.TabIndex = 670
        Me.BTNMILL.TabStop = False
        Me.BTNMILL.Text = "Mill Name"
        Me.BTNMILL.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Black
        Me.Button6.Location = New System.Drawing.Point(814, 2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(60, 27)
        Me.Button6.TabIndex = 664
        Me.Button6.TabStop = False
        Me.Button6.Text = "Wt."
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(133, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 27)
        Me.Button3.TabIndex = 2
        Me.Button3.TabStop = False
        Me.Button3.Text = "Quality"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'BTNNARRATION
        '
        Me.BTNNARRATION.BackColor = System.Drawing.Color.Transparent
        Me.BTNNARRATION.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNNARRATION.FlatAppearance.BorderSize = 0
        Me.BTNNARRATION.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNARRATION.ForeColor = System.Drawing.Color.Black
        Me.BTNNARRATION.Location = New System.Drawing.Point(953, 2)
        Me.BTNNARRATION.Name = "BTNNARRATION"
        Me.BTNNARRATION.Size = New System.Drawing.Size(180, 27)
        Me.BTNNARRATION.TabIndex = 1
        Me.BTNNARRATION.TabStop = False
        Me.BTNNARRATION.Text = "Narration"
        Me.BTNNARRATION.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "Sr."
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GRIDWASTAGE
        '
        Me.GRIDWASTAGE.AllowUserToAddRows = False
        Me.GRIDWASTAGE.AllowUserToDeleteRows = False
        Me.GRIDWASTAGE.AllowUserToResizeColumns = False
        Me.GRIDWASTAGE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDWASTAGE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDWASTAGE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDWASTAGE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDWASTAGE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDWASTAGE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDWASTAGE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDWASTAGE.ColumnHeadersVisible = False
        Me.GRIDWASTAGE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GTYPE, Me.GQUALITY, Me.GMILLNAME, Me.GDESIGN, Me.GSHADE, Me.GLOTNO, Me.Gwt, Me.GCONES, Me.GNARRATION, Me.GOUTWT})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDWASTAGE.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDWASTAGE.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDWASTAGE.Location = New System.Drawing.Point(2, 53)
        Me.GRIDWASTAGE.MultiSelect = False
        Me.GRIDWASTAGE.Name = "GRIDWASTAGE"
        Me.GRIDWASTAGE.ReadOnly = True
        Me.GRIDWASTAGE.RowHeadersVisible = False
        Me.GRIDWASTAGE.RowHeadersWidth = 30
        Me.GRIDWASTAGE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDWASTAGE.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDWASTAGE.RowTemplate.Height = 20
        Me.GRIDWASTAGE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDWASTAGE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDWASTAGE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDWASTAGE.Size = New System.Drawing.Size(1151, 246)
        Me.GRIDWASTAGE.TabIndex = 5
        Me.GRIDWASTAGE.TabStop = False
        '
        'tbupload
        '
        Me.tbupload.BackColor = System.Drawing.Color.Linen
        Me.tbupload.Controls.Add(Me.TXTIMGPATH)
        Me.tbupload.Controls.Add(Me.PBSOFTCOPY)
        Me.tbupload.Controls.Add(Me.txtuploadname)
        Me.tbupload.Controls.Add(Me.TXTUPLOADSRNO)
        Me.tbupload.Controls.Add(Me.txtuploadremarks)
        Me.tbupload.Controls.Add(Me.gridupload)
        Me.tbupload.Controls.Add(Me.CMDREMOVE)
        Me.tbupload.Controls.Add(Me.CMDUPLOAD)
        Me.tbupload.Controls.Add(Me.CMDVIEW)
        Me.tbupload.Controls.Add(Me.TextBox18)
        Me.tbupload.Controls.Add(Me.TextBox19)
        Me.tbupload.Controls.Add(Me.TextBox20)
        Me.tbupload.Location = New System.Drawing.Point(4, 24)
        Me.tbupload.Name = "tbupload"
        Me.tbupload.Padding = New System.Windows.Forms.Padding(3)
        Me.tbupload.Size = New System.Drawing.Size(1257, 323)
        Me.tbupload.TabIndex = 2
        Me.tbupload.Text = "2. Scan Documents"
        '
        'TXTIMGPATH
        '
        Me.TXTIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTIMGPATH.Location = New System.Drawing.Point(724, 51)
        Me.TXTIMGPATH.Name = "TXTIMGPATH"
        Me.TXTIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTIMGPATH.TabIndex = 669
        Me.TXTIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTIMGPATH.Visible = False
        '
        'PBSOFTCOPY
        '
        Me.PBSOFTCOPY.BackColor = System.Drawing.Color.White
        Me.PBSOFTCOPY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBSOFTCOPY.ErrorImage = Nothing
        Me.PBSOFTCOPY.InitialImage = Nothing
        Me.PBSOFTCOPY.Location = New System.Drawing.Point(593, 83)
        Me.PBSOFTCOPY.Name = "PBSOFTCOPY"
        Me.PBSOFTCOPY.Size = New System.Drawing.Size(142, 145)
        Me.PBSOFTCOPY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBSOFTCOPY.TabIndex = 668
        Me.PBSOFTCOPY.TabStop = False
        '
        'txtuploadname
        '
        Me.txtuploadname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadname.Location = New System.Drawing.Point(296, 4)
        Me.txtuploadname.MaxLength = 1000
        Me.txtuploadname.Name = "txtuploadname"
        Me.txtuploadname.Size = New System.Drawing.Size(250, 23)
        Me.txtuploadname.TabIndex = 660
        '
        'TXTUPLOADSRNO
        '
        Me.TXTUPLOADSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTUPLOADSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUPLOADSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTUPLOADSRNO.Location = New System.Drawing.Point(6, 4)
        Me.TXTUPLOADSRNO.Name = "TXTUPLOADSRNO"
        Me.TXTUPLOADSRNO.ReadOnly = True
        Me.TXTUPLOADSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTUPLOADSRNO.TabIndex = 667
        Me.TXTUPLOADSRNO.TabStop = False
        '
        'txtuploadremarks
        '
        Me.txtuploadremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadremarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadremarks.Location = New System.Drawing.Point(46, 4)
        Me.txtuploadremarks.MaxLength = 1000
        Me.txtuploadremarks.Name = "txtuploadremarks"
        Me.txtuploadremarks.Size = New System.Drawing.Size(250, 23)
        Me.txtuploadremarks.TabIndex = 658
        '
        'gridupload
        '
        Me.gridupload.AllowUserToAddRows = False
        Me.gridupload.AllowUserToDeleteRows = False
        Me.gridupload.AllowUserToResizeColumns = False
        Me.gridupload.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        Me.gridupload.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gridupload.BackgroundColor = System.Drawing.Color.White
        Me.gridupload.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridupload.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridupload.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gridupload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridupload.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GUSRNO, Me.GUREMARKS, Me.GUNAME, Me.GUIMGPATH})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridupload.DefaultCellStyle = DataGridViewCellStyle9
        Me.gridupload.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridupload.GridColor = System.Drawing.SystemColors.Control
        Me.gridupload.Location = New System.Drawing.Point(6, 28)
        Me.gridupload.MultiSelect = False
        Me.gridupload.Name = "gridupload"
        Me.gridupload.ReadOnly = True
        Me.gridupload.RowHeadersVisible = False
        Me.gridupload.RowHeadersWidth = 30
        Me.gridupload.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.gridupload.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridupload.RowTemplate.Height = 20
        Me.gridupload.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridupload.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridupload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridupload.Size = New System.Drawing.Size(569, 202)
        Me.gridupload.TabIndex = 661
        Me.gridupload.TabStop = False
        '
        'GUSRNO
        '
        Me.GUSRNO.HeaderText = "Sr."
        Me.GUSRNO.Name = "GUSRNO"
        Me.GUSRNO.ReadOnly = True
        Me.GUSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUSRNO.Width = 40
        '
        'GUREMARKS
        '
        Me.GUREMARKS.HeaderText = "Remarks"
        Me.GUREMARKS.Name = "GUREMARKS"
        Me.GUREMARKS.ReadOnly = True
        Me.GUREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUREMARKS.Width = 250
        '
        'GUNAME
        '
        Me.GUNAME.HeaderText = "Name"
        Me.GUNAME.Name = "GUNAME"
        Me.GUNAME.ReadOnly = True
        Me.GUNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GUNAME.Width = 250
        '
        'GUIMGPATH
        '
        Me.GUIMGPATH.HeaderText = "ImgPath"
        Me.GUIMGPATH.Name = "GUIMGPATH"
        Me.GUIMGPATH.ReadOnly = True
        Me.GUIMGPATH.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GUIMGPATH.Visible = False
        '
        'CMDREMOVE
        '
        Me.CMDREMOVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREMOVE.Location = New System.Drawing.Point(675, 15)
        Me.CMDREMOVE.Name = "CMDREMOVE"
        Me.CMDREMOVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDREMOVE.TabIndex = 662
        Me.CMDREMOVE.Text = "&Remove"
        Me.CMDREMOVE.UseVisualStyleBackColor = True
        '
        'CMDUPLOAD
        '
        Me.CMDUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOAD.Location = New System.Drawing.Point(588, 15)
        Me.CMDUPLOAD.Name = "CMDUPLOAD"
        Me.CMDUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPLOAD.TabIndex = 659
        Me.CMDUPLOAD.Text = "&Upload"
        Me.CMDUPLOAD.UseVisualStyleBackColor = True
        '
        'CMDVIEW
        '
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.Location = New System.Drawing.Point(629, 49)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDVIEW.TabIndex = 663
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = True
        '
        'TextBox18
        '
        Me.TextBox18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBox18.Location = New System.Drawing.Point(724, 52)
        Me.TextBox18.Multiline = True
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(46, 22)
        Me.TextBox18.TabIndex = 666
        Me.TextBox18.Visible = False
        '
        'TextBox19
        '
        Me.TextBox19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBox19.Location = New System.Drawing.Point(724, 52)
        Me.TextBox19.Multiline = True
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(46, 22)
        Me.TextBox19.TabIndex = 665
        Me.TextBox19.Visible = False
        '
        'TextBox20
        '
        Me.TextBox20.BackColor = System.Drawing.Color.White
        Me.TextBox20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox20.ForeColor = System.Drawing.Color.Black
        Me.TextBox20.Location = New System.Drawing.Point(724, 52)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(23, 23)
        Me.TextBox20.TabIndex = 664
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox20.Visible = False
        '
        'DTENTRYDATE
        '
        Me.DTENTRYDATE.AsciiOnly = True
        Me.DTENTRYDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.DTENTRYDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTENTRYDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DTENTRYDATE.Location = New System.Drawing.Point(998, 74)
        Me.DTENTRYDATE.Mask = "00/00/0000"
        Me.DTENTRYDATE.Name = "DTENTRYDATE"
        Me.DTENTRYDATE.Size = New System.Drawing.Size(79, 23)
        Me.DTENTRYDATE.TabIndex = 0
        Me.DTENTRYDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DTENTRYDATE.ValidatingType = GetType(Date)
        '
        'TXTWASTAGENO
        '
        Me.TXTWASTAGENO.BackColor = System.Drawing.Color.Linen
        Me.TXTWASTAGENO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWASTAGENO.Location = New System.Drawing.Point(998, 45)
        Me.TXTWASTAGENO.Name = "TXTWASTAGENO"
        Me.TXTWASTAGENO.ReadOnly = True
        Me.TXTWASTAGENO.Size = New System.Drawing.Size(79, 23)
        Me.TXTWASTAGENO.TabIndex = 633
        Me.TXTWASTAGENO.TabStop = False
        Me.TXTWASTAGENO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(942, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 15)
        Me.Label12.TabIndex = 634
        Me.Label12.Text = "Entry No"
        '
        'lblgrndate
        '
        Me.lblgrndate.AutoSize = True
        Me.lblgrndate.BackColor = System.Drawing.Color.Transparent
        Me.lblgrndate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgrndate.ForeColor = System.Drawing.Color.Black
        Me.lblgrndate.Location = New System.Drawing.Point(964, 78)
        Me.lblgrndate.Name = "lblgrndate"
        Me.lblgrndate.Size = New System.Drawing.Size(32, 15)
        Me.lblgrndate.TabIndex = 632
        Me.lblgrndate.Text = "Date"
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(889, 480)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 453
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(595, 521)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 7
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(509, 521)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 6
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(423, 521)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(681, 521)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(955, 511)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 452
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        'GTYPE
        '
        Me.GTYPE.HeaderText = "Type"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.ReadOnly = True
        Me.GTYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 200
        '
        'GMILLNAME
        '
        Me.GMILLNAME.HeaderText = "Mill Name"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.ReadOnly = True
        Me.GMILLNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMILLNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMILLNAME.Width = 200
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GSHADE
        '
        Me.GSHADE.HeaderText = "Shade"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.ReadOnly = True
        Me.GSHADE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHADE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.ReadOnly = True
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOTNO.Width = 80
        '
        'Gwt
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Gwt.DefaultCellStyle = DataGridViewCellStyle3
        Me.Gwt.HeaderText = "Wt."
        Me.Gwt.MaxInputLength = 50
        Me.Gwt.Name = "Gwt"
        Me.Gwt.ReadOnly = True
        Me.Gwt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gwt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Gwt.Width = 60
        '
        'GCONES
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCONES.DefaultCellStyle = DataGridViewCellStyle4
        Me.GCONES.HeaderText = "Cones"
        Me.GCONES.MaxInputLength = 50
        Me.GCONES.Name = "GCONES"
        Me.GCONES.ReadOnly = True
        Me.GCONES.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCONES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCONES.Width = 80
        '
        'GNARRATION
        '
        Me.GNARRATION.HeaderText = "Narration"
        Me.GNARRATION.MaxInputLength = 200
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.ReadOnly = True
        Me.GNARRATION.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNARRATION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GNARRATION.Width = 180
        '
        'GOUTWT
        '
        Me.GOUTWT.HeaderText = "OUTWT"
        Me.GOUTWT.Name = "GOUTWT"
        Me.GOUTWT.ReadOnly = True
        Me.GOUTWT.Visible = False
        '
        'YarnWastage
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnWastage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Wastage / Longation / Shortage"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GRIDWASTAGE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbupload.ResumeLayout(False)
        Me.tbupload.PerformLayout()
        CType(Me.PBSOFTCOPY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridupload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents LBLNAME As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBOURGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents LBLGODOWN As System.Windows.Forms.Label
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents cmbcode As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LBLTOTALWT As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents BTNMILL As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BTNNARRATION As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GRIDWASTAGE As System.Windows.Forms.DataGridView
    Friend WithEvents tbupload As System.Windows.Forms.TabPage
    Friend WithEvents TXTIMGPATH As System.Windows.Forms.TextBox
    Friend WithEvents PBSOFTCOPY As System.Windows.Forms.PictureBox
    Friend WithEvents txtuploadname As System.Windows.Forms.TextBox
    Friend WithEvents TXTUPLOADSRNO As System.Windows.Forms.TextBox
    Friend WithEvents txtuploadremarks As System.Windows.Forms.TextBox
    Friend WithEvents gridupload As System.Windows.Forms.DataGridView
    Friend WithEvents GUSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUREMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GUIMGPATH As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CMDREMOVE As System.Windows.Forms.Button
    Friend WithEvents CMDUPLOAD As System.Windows.Forms.Button
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents DTENTRYDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TXTWASTAGENO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblgrndate As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTNARR As System.Windows.Forms.TextBox
    Friend WithEvents TXTWT As System.Windows.Forms.TextBox
    Friend WithEvents CMBMILLNAME As System.Windows.Forms.ComboBox
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TXTCONES As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents LBLTOTALCONES As System.Windows.Forms.Label
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GTYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMILLNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GSHADE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gwt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCONES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GNARRATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOUTWT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
