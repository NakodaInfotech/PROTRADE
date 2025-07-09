<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignMaster
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBMILL = New System.Windows.Forms.ComboBox()
        Me.TXTCADNO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CHKBLOCKED = New System.Windows.Forms.CheckBox()
        Me.CMBITEM = New System.Windows.Forms.ComboBox()
        Me.LBLITEMNAME = New System.Windows.Forms.Label()
        Me.GRPSHADE = New System.Windows.Forms.GroupBox()
        Me.CMBBASE = New System.Windows.Forms.ComboBox()
        Me.CMBPRINT = New System.Windows.Forms.ComboBox()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDSHADE = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBASE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPRINT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTTOTAL = New System.Windows.Forms.TextBox()
        Me.LBLTOTAL = New System.Windows.Forms.Label()
        Me.TXTEXTRA = New System.Windows.Forms.TextBox()
        Me.LBLEXTRA = New System.Windows.Forms.Label()
        Me.TXTFINISHING = New System.Windows.Forms.TextBox()
        Me.LBLFINISHING = New System.Windows.Forms.Label()
        Me.TXTJOBWORK = New System.Windows.Forms.TextBox()
        Me.LBLJOBWORK = New System.Windows.Forms.Label()
        Me.TXTDYEING = New System.Windows.Forms.TextBox()
        Me.LBLDYEING = New System.Windows.Forms.Label()
        Me.TXTFABRIC = New System.Windows.Forms.TextBox()
        Me.LBLFABRIC = New System.Windows.Forms.Label()
        Me.CMDPHOTOREMOVE = New System.Windows.Forms.Button()
        Me.CMDPHOTOUPLOAD = New System.Windows.Forms.Button()
        Me.CMDPHOTOVIEW = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTPHOTOIMGPATH = New System.Windows.Forms.TextBox()
        Me.PBPHOTO = New System.Windows.Forms.PictureBox()
        Me.TXTWRATE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTSALERATE = New System.Windows.Forms.TextBox()
        Me.LBLSALERATE = New System.Windows.Forms.Label()
        Me.TXTPURRATE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.lbldesign = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BlendPanel1.SuspendLayout()
        Me.GRPSHADE.SuspendLayout()
        CType(Me.GRIDSHADE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(460, 308)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 17
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBMILL)
        Me.BlendPanel1.Controls.Add(Me.TXTCADNO)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CHKBLOCKED)
        Me.BlendPanel1.Controls.Add(Me.CMBITEM)
        Me.BlendPanel1.Controls.Add(Me.LBLITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.GRPSHADE)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTAL)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTAL)
        Me.BlendPanel1.Controls.Add(Me.TXTEXTRA)
        Me.BlendPanel1.Controls.Add(Me.LBLEXTRA)
        Me.BlendPanel1.Controls.Add(Me.TXTFINISHING)
        Me.BlendPanel1.Controls.Add(Me.LBLFINISHING)
        Me.BlendPanel1.Controls.Add(Me.TXTJOBWORK)
        Me.BlendPanel1.Controls.Add(Me.LBLJOBWORK)
        Me.BlendPanel1.Controls.Add(Me.TXTDYEING)
        Me.BlendPanel1.Controls.Add(Me.LBLDYEING)
        Me.BlendPanel1.Controls.Add(Me.TXTFABRIC)
        Me.BlendPanel1.Controls.Add(Me.LBLFABRIC)
        Me.BlendPanel1.Controls.Add(Me.CMDPHOTOREMOVE)
        Me.BlendPanel1.Controls.Add(Me.CMDPHOTOUPLOAD)
        Me.BlendPanel1.Controls.Add(Me.CMDPHOTOVIEW)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTPHOTOIMGPATH)
        Me.BlendPanel1.Controls.Add(Me.PBPHOTO)
        Me.BlendPanel1.Controls.Add(Me.TXTWRATE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTSALERATE)
        Me.BlendPanel1.Controls.Add(Me.LBLSALERATE)
        Me.BlendPanel1.Controls.Add(Me.TXTPURRATE)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lbldesign)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(881, 471)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 494
        Me.Label5.Text = "Mill Name "
        '
        'CMBMILL
        '
        Me.CMBMILL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMILL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMILL.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBMILL.FormattingEnabled = True
        Me.CMBMILL.Location = New System.Drawing.Point(109, 67)
        Me.CMBMILL.Name = "CMBMILL"
        Me.CMBMILL.Size = New System.Drawing.Size(215, 23)
        Me.CMBMILL.TabIndex = 2
        '
        'TXTCADNO
        '
        Me.TXTCADNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCADNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCADNO.Location = New System.Drawing.Point(109, 41)
        Me.TXTCADNO.Name = "TXTCADNO"
        Me.TXTCADNO.Size = New System.Drawing.Size(215, 22)
        Me.TXTCADNO.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 14)
        Me.Label4.TabIndex = 492
        Me.Label4.Text = "CAD No"
        '
        'CHKBLOCKED
        '
        Me.CHKBLOCKED.AutoSize = True
        Me.CHKBLOCKED.BackColor = System.Drawing.Color.Transparent
        Me.CHKBLOCKED.Location = New System.Drawing.Point(347, 16)
        Me.CHKBLOCKED.Name = "CHKBLOCKED"
        Me.CHKBLOCKED.Size = New System.Drawing.Size(69, 19)
        Me.CHKBLOCKED.TabIndex = 19
        Me.CHKBLOCKED.Text = "Blocked"
        Me.CHKBLOCKED.UseVisualStyleBackColor = False
        '
        'CMBITEM
        '
        Me.CMBITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEM.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEM.FormattingEnabled = True
        Me.CMBITEM.Location = New System.Drawing.Point(426, 41)
        Me.CMBITEM.Name = "CMBITEM"
        Me.CMBITEM.Size = New System.Drawing.Size(221, 23)
        Me.CMBITEM.TabIndex = 11
        Me.CMBITEM.Visible = False
        '
        'LBLITEMNAME
        '
        Me.LBLITEMNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLITEMNAME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLITEMNAME.Location = New System.Drawing.Point(344, 41)
        Me.LBLITEMNAME.Name = "LBLITEMNAME"
        Me.LBLITEMNAME.Size = New System.Drawing.Size(79, 22)
        Me.LBLITEMNAME.TabIndex = 490
        Me.LBLITEMNAME.Text = "Item Name"
        Me.LBLITEMNAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBLITEMNAME.Visible = False
        '
        'GRPSHADE
        '
        Me.GRPSHADE.BackColor = System.Drawing.Color.Transparent
        Me.GRPSHADE.Controls.Add(Me.CMBBASE)
        Me.GRPSHADE.Controls.Add(Me.CMBPRINT)
        Me.GRPSHADE.Controls.Add(Me.CMBCOLOR)
        Me.GRPSHADE.Controls.Add(Me.TXTSRNO)
        Me.GRPSHADE.Controls.Add(Me.GRIDSHADE)
        Me.GRPSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRPSHADE.ForeColor = System.Drawing.Color.Black
        Me.GRPSHADE.Location = New System.Drawing.Point(366, 73)
        Me.GRPSHADE.Name = "GRPSHADE"
        Me.GRPSHADE.Size = New System.Drawing.Size(503, 206)
        Me.GRPSHADE.TabIndex = 12
        Me.GRPSHADE.TabStop = False
        Me.GRPSHADE.Text = "Shade Details"
        Me.GRPSHADE.Visible = False
        '
        'CMBBASE
        '
        Me.CMBBASE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBASE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBASE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBBASE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBASE.FormattingEnabled = True
        Me.CMBBASE.Location = New System.Drawing.Point(51, 21)
        Me.CMBBASE.MaxDropDownItems = 14
        Me.CMBBASE.Name = "CMBBASE"
        Me.CMBBASE.Size = New System.Drawing.Size(100, 22)
        Me.CMBBASE.TabIndex = 1
        '
        'CMBPRINT
        '
        Me.CMBPRINT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPRINT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPRINT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRINT.FormattingEnabled = True
        Me.CMBPRINT.Location = New System.Drawing.Point(151, 21)
        Me.CMBPRINT.MaxDropDownItems = 14
        Me.CMBPRINT.Name = "CMBPRINT"
        Me.CMBPRINT.Size = New System.Drawing.Size(100, 22)
        Me.CMBPRINT.TabIndex = 2
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(251, 21)
        Me.CMBCOLOR.MaxDropDownItems = 14
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(200, 22)
        Me.CMBCOLOR.TabIndex = 3
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.Location = New System.Drawing.Point(11, 21)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 22)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        Me.TXTSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDSHADE
        '
        Me.GRIDSHADE.AllowUserToAddRows = False
        Me.GRIDSHADE.AllowUserToDeleteRows = False
        Me.GRIDSHADE.AllowUserToResizeColumns = False
        Me.GRIDSHADE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDSHADE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSHADE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSHADE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSHADE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDSHADE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSHADE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSHADE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GBASE, Me.GPRINT, Me.GCOLOR})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSHADE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDSHADE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDSHADE.Location = New System.Drawing.Point(11, 43)
        Me.GRIDSHADE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDSHADE.MultiSelect = False
        Me.GRIDSHADE.Name = "GRIDSHADE"
        Me.GRIDSHADE.ReadOnly = True
        Me.GRIDSHADE.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSHADE.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDSHADE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSHADE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSHADE.Size = New System.Drawing.Size(487, 158)
        Me.GRIDSHADE.TabIndex = 4
        Me.GRIDSHADE.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 40
        '
        'GBASE
        '
        Me.GBASE.HeaderText = "Base"
        Me.GBASE.Name = "GBASE"
        Me.GBASE.ReadOnly = True
        Me.GBASE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBASE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GPRINT
        '
        Me.GPRINT.HeaderText = "Print"
        Me.GPRINT.Name = "GPRINT"
        Me.GPRINT.ReadOnly = True
        Me.GPRINT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPRINT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GCOLOR
        '
        Me.GCOLOR.HeaderText = "Shade"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.ReadOnly = True
        Me.GCOLOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOLOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCOLOR.Width = 200
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTAL.Location = New System.Drawing.Point(251, 151)
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.ReadOnly = True
        Me.TXTTOTAL.Size = New System.Drawing.Size(73, 22)
        Me.TXTTOTAL.TabIndex = 486
        Me.TXTTOTAL.TabStop = False
        Me.TXTTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTOTAL.Visible = False
        '
        'LBLTOTAL
        '
        Me.LBLTOTAL.AutoSize = True
        Me.LBLTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTAL.Location = New System.Drawing.Point(218, 155)
        Me.LBLTOTAL.Name = "LBLTOTAL"
        Me.LBLTOTAL.Size = New System.Drawing.Size(34, 14)
        Me.LBLTOTAL.TabIndex = 487
        Me.LBLTOTAL.Text = "Total"
        Me.LBLTOTAL.Visible = False
        '
        'TXTEXTRA
        '
        Me.TXTEXTRA.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRA.Location = New System.Drawing.Point(251, 124)
        Me.TXTEXTRA.Name = "TXTEXTRA"
        Me.TXTEXTRA.Size = New System.Drawing.Size(73, 22)
        Me.TXTEXTRA.TabIndex = 6
        Me.TXTEXTRA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTEXTRA.Visible = False
        '
        'LBLEXTRA
        '
        Me.LBLEXTRA.AutoSize = True
        Me.LBLEXTRA.BackColor = System.Drawing.Color.Transparent
        Me.LBLEXTRA.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEXTRA.Location = New System.Drawing.Point(217, 128)
        Me.LBLEXTRA.Name = "LBLEXTRA"
        Me.LBLEXTRA.Size = New System.Drawing.Size(33, 14)
        Me.LBLEXTRA.TabIndex = 485
        Me.LBLEXTRA.Text = "Extra"
        Me.LBLEXTRA.Visible = False
        '
        'TXTFINISHING
        '
        Me.TXTFINISHING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFINISHING.Location = New System.Drawing.Point(251, 96)
        Me.TXTFINISHING.Name = "TXTFINISHING"
        Me.TXTFINISHING.Size = New System.Drawing.Size(73, 22)
        Me.TXTFINISHING.TabIndex = 5
        Me.TXTFINISHING.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFINISHING.Visible = False
        '
        'LBLFINISHING
        '
        Me.LBLFINISHING.AutoSize = True
        Me.LBLFINISHING.BackColor = System.Drawing.Color.Transparent
        Me.LBLFINISHING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFINISHING.Location = New System.Drawing.Point(198, 100)
        Me.LBLFINISHING.Name = "LBLFINISHING"
        Me.LBLFINISHING.Size = New System.Drawing.Size(58, 14)
        Me.LBLFINISHING.TabIndex = 483
        Me.LBLFINISHING.Text = "Finishing"
        Me.LBLFINISHING.Visible = False
        '
        'TXTJOBWORK
        '
        Me.TXTJOBWORK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJOBWORK.Location = New System.Drawing.Point(109, 123)
        Me.TXTJOBWORK.Name = "TXTJOBWORK"
        Me.TXTJOBWORK.Size = New System.Drawing.Size(73, 22)
        Me.TXTJOBWORK.TabIndex = 4
        Me.TXTJOBWORK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTJOBWORK.Visible = False
        '
        'LBLJOBWORK
        '
        Me.LBLJOBWORK.AutoSize = True
        Me.LBLJOBWORK.BackColor = System.Drawing.Color.Transparent
        Me.LBLJOBWORK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLJOBWORK.Location = New System.Drawing.Point(56, 127)
        Me.LBLJOBWORK.Name = "LBLJOBWORK"
        Me.LBLJOBWORK.Size = New System.Drawing.Size(55, 14)
        Me.LBLJOBWORK.TabIndex = 481
        Me.LBLJOBWORK.Text = "Job Work"
        Me.LBLJOBWORK.Visible = False
        '
        'TXTDYEING
        '
        Me.TXTDYEING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDYEING.Location = New System.Drawing.Point(109, 151)
        Me.TXTDYEING.Name = "TXTDYEING"
        Me.TXTDYEING.Size = New System.Drawing.Size(73, 22)
        Me.TXTDYEING.TabIndex = 7
        Me.TXTDYEING.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTDYEING.Visible = False
        '
        'LBLDYEING
        '
        Me.LBLDYEING.AutoSize = True
        Me.LBLDYEING.BackColor = System.Drawing.Color.Transparent
        Me.LBLDYEING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDYEING.Location = New System.Drawing.Point(67, 155)
        Me.LBLDYEING.Name = "LBLDYEING"
        Me.LBLDYEING.Size = New System.Drawing.Size(44, 14)
        Me.LBLDYEING.TabIndex = 479
        Me.LBLDYEING.Text = "Dyeing"
        Me.LBLDYEING.Visible = False
        '
        'TXTFABRIC
        '
        Me.TXTFABRIC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFABRIC.Location = New System.Drawing.Point(109, 95)
        Me.TXTFABRIC.Name = "TXTFABRIC"
        Me.TXTFABRIC.Size = New System.Drawing.Size(73, 22)
        Me.TXTFABRIC.TabIndex = 3
        Me.TXTFABRIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFABRIC.Visible = False
        '
        'LBLFABRIC
        '
        Me.LBLFABRIC.AutoSize = True
        Me.LBLFABRIC.BackColor = System.Drawing.Color.Transparent
        Me.LBLFABRIC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFABRIC.Location = New System.Drawing.Point(44, 99)
        Me.LBLFABRIC.Name = "LBLFABRIC"
        Me.LBLFABRIC.Size = New System.Drawing.Size(68, 14)
        Me.LBLFABRIC.TabIndex = 477
        Me.LBLFABRIC.Text = "Fabric Rate"
        Me.LBLFABRIC.Visible = False
        '
        'CMDPHOTOREMOVE
        '
        Me.CMDPHOTOREMOVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPHOTOREMOVE.Location = New System.Drawing.Point(257, 315)
        Me.CMDPHOTOREMOVE.Name = "CMDPHOTOREMOVE"
        Me.CMDPHOTOREMOVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDPHOTOREMOVE.TabIndex = 14
        Me.CMDPHOTOREMOVE.Text = "Remove"
        Me.CMDPHOTOREMOVE.UseVisualStyleBackColor = True
        '
        'CMDPHOTOUPLOAD
        '
        Me.CMDPHOTOUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPHOTOUPLOAD.Location = New System.Drawing.Point(257, 281)
        Me.CMDPHOTOUPLOAD.Name = "CMDPHOTOUPLOAD"
        Me.CMDPHOTOUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDPHOTOUPLOAD.TabIndex = 13
        Me.CMDPHOTOUPLOAD.Text = "Upload"
        Me.CMDPHOTOUPLOAD.UseVisualStyleBackColor = True
        '
        'CMDPHOTOVIEW
        '
        Me.CMDPHOTOVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPHOTOVIEW.Location = New System.Drawing.Point(257, 349)
        Me.CMDPHOTOVIEW.Name = "CMDPHOTOVIEW"
        Me.CMDPHOTOVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDPHOTOVIEW.TabIndex = 15
        Me.CMDPHOTOVIEW.Text = "View"
        Me.CMDPHOTOVIEW.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(254, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 474
        Me.Label3.Text = "Photograph"
        '
        'TXTPHOTOIMGPATH
        '
        Me.TXTPHOTOIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTPHOTOIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPHOTOIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTPHOTOIMGPATH.Location = New System.Drawing.Point(574, 3)
        Me.TXTPHOTOIMGPATH.Name = "TXTPHOTOIMGPATH"
        Me.TXTPHOTOIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTPHOTOIMGPATH.TabIndex = 475
        Me.TXTPHOTOIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPHOTOIMGPATH.Visible = False
        '
        'PBPHOTO
        '
        Me.PBPHOTO.BackColor = System.Drawing.Color.White
        Me.PBPHOTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBPHOTO.ErrorImage = Nothing
        Me.PBPHOTO.InitialImage = Nothing
        Me.PBPHOTO.Location = New System.Drawing.Point(106, 232)
        Me.PBPHOTO.Name = "PBPHOTO"
        Me.PBPHOTO.Size = New System.Drawing.Size(142, 145)
        Me.PBPHOTO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPHOTO.TabIndex = 473
        Me.PBPHOTO.TabStop = False
        '
        'TXTWRATE
        '
        Me.TXTWRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWRATE.Location = New System.Drawing.Point(251, 179)
        Me.TXTWRATE.Name = "TXTWRATE"
        Me.TXTWRATE.Size = New System.Drawing.Size(73, 22)
        Me.TXTWRATE.TabIndex = 9
        Me.TXTWRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(203, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 352
        Me.Label2.Text = "W. Rate"
        '
        'TXTSALERATE
        '
        Me.TXTSALERATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALERATE.Location = New System.Drawing.Point(109, 207)
        Me.TXTSALERATE.Name = "TXTSALERATE"
        Me.TXTSALERATE.Size = New System.Drawing.Size(73, 22)
        Me.TXTSALERATE.TabIndex = 10
        Me.TXTSALERATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLSALERATE
        '
        Me.LBLSALERATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLSALERATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSALERATE.Location = New System.Drawing.Point(32, 211)
        Me.LBLSALERATE.Name = "LBLSALERATE"
        Me.LBLSALERATE.Size = New System.Drawing.Size(75, 14)
        Me.LBLSALERATE.TabIndex = 350
        Me.LBLSALERATE.Text = "Sale Rate"
        Me.LBLSALERATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTPURRATE
        '
        Me.TXTPURRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPURRATE.Location = New System.Drawing.Point(109, 179)
        Me.TXTPURRATE.Name = "TXTPURRATE"
        Me.TXTPURRATE.Size = New System.Drawing.Size(73, 22)
        Me.TXTPURRATE.TabIndex = 8
        Me.TXTPURRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(58, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 348
        Me.Label7.Text = "Pur Rate"
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(109, 12)
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(215, 23)
        Me.CMBDESIGNNO.TabIndex = 0
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(374, 308)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 16
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(41, 377)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(305, 82)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(7, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(292, 56)
        Me.txtremarks.TabIndex = 0
        '
        'lbldesign
        '
        Me.lbldesign.AutoSize = True
        Me.lbldesign.BackColor = System.Drawing.Color.Transparent
        Me.lbldesign.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldesign.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldesign.Location = New System.Drawing.Point(67, 16)
        Me.lbldesign.Name = "lbldesign"
        Me.lbldesign.Size = New System.Drawing.Size(45, 14)
        Me.lbldesign.TabIndex = 149
        Me.lbldesign.Text = "Design"
        Me.lbldesign.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(546, 308)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 18
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DesignMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(881, 471)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GRPSHADE.ResumeLayout(False)
        Me.GRPSHADE.PerformLayout()
        CType(Me.GRIDSHADE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents lbldesign As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CMBDESIGNNO As System.Windows.Forms.ComboBox
    Friend WithEvents TXTPURRATE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTWRATE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTSALERATE As System.Windows.Forms.TextBox
    Friend WithEvents LBLSALERATE As System.Windows.Forms.Label
    Friend WithEvents CMDPHOTOREMOVE As System.Windows.Forms.Button
    Friend WithEvents CMDPHOTOUPLOAD As System.Windows.Forms.Button
    Friend WithEvents CMDPHOTOVIEW As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTPHOTOIMGPATH As System.Windows.Forms.TextBox
    Friend WithEvents PBPHOTO As System.Windows.Forms.PictureBox
    Friend WithEvents TXTTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents LBLTOTAL As System.Windows.Forms.Label
    Friend WithEvents TXTEXTRA As System.Windows.Forms.TextBox
    Friend WithEvents LBLEXTRA As System.Windows.Forms.Label
    Friend WithEvents TXTFINISHING As System.Windows.Forms.TextBox
    Friend WithEvents LBLFINISHING As System.Windows.Forms.Label
    Friend WithEvents TXTJOBWORK As System.Windows.Forms.TextBox
    Friend WithEvents LBLJOBWORK As System.Windows.Forms.Label
    Friend WithEvents TXTDYEING As System.Windows.Forms.TextBox
    Friend WithEvents LBLDYEING As System.Windows.Forms.Label
    Friend WithEvents TXTFABRIC As System.Windows.Forms.TextBox
    Friend WithEvents LBLFABRIC As System.Windows.Forms.Label
    Friend WithEvents GRPSHADE As System.Windows.Forms.GroupBox
    Friend WithEvents CMBCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDSHADE As System.Windows.Forms.DataGridView
    Friend WithEvents CMBITEM As System.Windows.Forms.ComboBox
    Friend WithEvents LBLITEMNAME As System.Windows.Forms.Label
    Friend WithEvents CHKBLOCKED As System.Windows.Forms.CheckBox
    Friend WithEvents TXTCADNO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CMBBASE As ComboBox
    Friend WithEvents CMBPRINT As ComboBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GBASE As DataGridViewTextBoxColumn
    Friend WithEvents GPRINT As DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As DataGridViewTextBoxColumn
    Friend WithEvents CMBMILL As ComboBox
    Friend WithEvents Label5 As Label
End Class
