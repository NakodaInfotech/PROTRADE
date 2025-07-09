<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningProgramMaster
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpeningProgramMaster))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.CHKURGENT = New System.Windows.Forms.CheckBox()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.CARDRECDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXTGRNTYPE = New System.Windows.Forms.TextBox()
        Me.TXTGRNNO = New System.Windows.Forms.TextBox()
        Me.TXTTOTALPCS = New System.Windows.Forms.TextBox()
        Me.CMBLOTNO = New System.Windows.Forms.ComboBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.GRIDLOT = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGNNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GTOTALPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCOLOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GURGENT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPROGISSDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSTATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUTRECDDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GFINISHCUTTING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GINWARDDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRNNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRNTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRECDPCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LBLTOTALPCS = New System.Windows.Forms.Label()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.PROGRAMDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTPROGRAMNO = New System.Windows.Forms.TextBox()
        Me.LBLSRNO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.PRINTTOOLSTRIP = New System.Windows.Forms.ToolStripButton()
        Me.TOOLDELETE = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLPREVIOUS = New System.Windows.Forms.ToolStripButton()
        Me.TOOLNEXT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.GRIDLOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.CHKURGENT)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.CARDRECDATE)
        Me.BlendPanel1.Controls.Add(Me.Label24)
        Me.BlendPanel1.Controls.Add(Me.TXTGRNTYPE)
        Me.BlendPanel1.Controls.Add(Me.TXTGRNNO)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.CMBLOTNO)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.GRIDLOT)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.PROGRAMDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTPROGRAMNO)
        Me.BlendPanel1.Controls.Add(Me.LBLSRNO)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 556)
        Me.BlendPanel1.TabIndex = 614
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.Linen
        Me.TXTBARCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBARCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBARCODE.Location = New System.Drawing.Point(821, 16)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.ReadOnly = True
        Me.TXTBARCODE.Size = New System.Drawing.Size(80, 23)
        Me.TXTBARCODE.TabIndex = 695
        Me.TXTBARCODE.TabStop = False
        Me.TXTBARCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTBARCODE.Visible = False
        '
        'CHKURGENT
        '
        Me.CHKURGENT.AutoSize = True
        Me.CHKURGENT.BackColor = System.Drawing.Color.Transparent
        Me.CHKURGENT.Location = New System.Drawing.Point(614, 49)
        Me.CHKURGENT.Name = "CHKURGENT"
        Me.CHKURGENT.Size = New System.Drawing.Size(62, 19)
        Me.CHKURGENT.TabIndex = 8
        Me.CHKURGENT.Text = "Urgent"
        Me.CHKURGENT.UseVisualStyleBackColor = False
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.White
        Me.CMBDESIGNNO.Enabled = False
        Me.CMBDESIGNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(330, 47)
        Me.CMBDESIGNNO.MaxDropDownItems = 14
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(90, 23)
        Me.CMBDESIGNNO.TabIndex = 6
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Enabled = False
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(140, 47)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(190, 23)
        Me.CMBITEMNAME.TabIndex = 5
        '
        'CARDRECDATE
        '
        Me.CARDRECDATE.AsciiOnly = True
        Me.CARDRECDATE.BackColor = System.Drawing.Color.White
        Me.CARDRECDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.CARDRECDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.CARDRECDATE.Location = New System.Drawing.Point(441, 15)
        Me.CARDRECDATE.Mask = "00/00/0000"
        Me.CARDRECDATE.Name = "CARDRECDATE"
        Me.CARDRECDATE.Size = New System.Drawing.Size(76, 23)
        Me.CARDRECDATE.TabIndex = 3
        Me.CARDRECDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.CARDRECDATE.ValidatingType = GetType(Date)
        Me.CARDRECDATE.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(359, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(80, 15)
        Me.Label24.TabIndex = 694
        Me.Label24.Text = "Card Rec Date"
        Me.Label24.Visible = False
        '
        'TXTGRNTYPE
        '
        Me.TXTGRNTYPE.BackColor = System.Drawing.Color.Linen
        Me.TXTGRNTYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGRNTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGRNTYPE.Location = New System.Drawing.Point(800, 464)
        Me.TXTGRNTYPE.Name = "TXTGRNTYPE"
        Me.TXTGRNTYPE.ReadOnly = True
        Me.TXTGRNTYPE.Size = New System.Drawing.Size(37, 23)
        Me.TXTGRNTYPE.TabIndex = 692
        Me.TXTGRNTYPE.TabStop = False
        Me.TXTGRNTYPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTGRNTYPE.Visible = False
        '
        'TXTGRNNO
        '
        Me.TXTGRNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTGRNNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGRNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGRNNO.Location = New System.Drawing.Point(907, 16)
        Me.TXTGRNNO.Name = "TXTGRNNO"
        Me.TXTGRNNO.ReadOnly = True
        Me.TXTGRNNO.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRNNO.TabIndex = 691
        Me.TXTGRNNO.TabStop = False
        Me.TXTGRNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTGRNNO.Visible = False
        '
        'TXTTOTALPCS
        '
        Me.TXTTOTALPCS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPCS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPCS.Location = New System.Drawing.Point(420, 47)
        Me.TXTTOTALPCS.Name = "TXTTOTALPCS"
        Me.TXTTOTALPCS.ReadOnly = True
        Me.TXTTOTALPCS.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALPCS.TabIndex = 690
        Me.TXTTOTALPCS.TabStop = False
        Me.TXTTOTALPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBLOTNO
        '
        Me.CMBLOTNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLOTNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLOTNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBLOTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLOTNO.FormattingEnabled = True
        Me.CMBLOTNO.Location = New System.Drawing.Point(60, 47)
        Me.CMBLOTNO.MaxDropDownItems = 14
        Me.CMBLOTNO.Name = "CMBLOTNO"
        Me.CMBLOTNO.Size = New System.Drawing.Size(80, 23)
        Me.CMBLOTNO.TabIndex = 4
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.Location = New System.Drawing.Point(20, 47)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTSRNO.TabIndex = 687
        Me.TXTSRNO.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(30, 403)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(289, 122)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.BackColor = System.Drawing.Color.White
        Me.txtremarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 15)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(277, 101)
        Me.txtremarks.TabIndex = 0
        '
        'GRIDLOT
        '
        Me.GRIDLOT.AllowUserToAddRows = False
        Me.GRIDLOT.AllowUserToDeleteRows = False
        Me.GRIDLOT.AllowUserToResizeColumns = False
        Me.GRIDLOT.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDLOT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDLOT.BackgroundColor = System.Drawing.Color.White
        Me.GRIDLOT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDLOT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDLOT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDLOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDLOT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GLOTNO, Me.GITEMNAME, Me.GDESIGNNO, Me.GTOTALPCS, Me.GCOLOR, Me.GURGENT, Me.GPCS, Me.GPROGISSDATE, Me.GSTATUS, Me.GCUTRECDDATE, Me.GFINISHCUTTING, Me.GINWARDDATE, Me.GGRNNO, Me.GGRNTYPE, Me.GRECDPCS, Me.GBARCODE})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDLOT.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDLOT.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDLOT.Location = New System.Drawing.Point(20, 70)
        Me.GRIDLOT.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDLOT.MultiSelect = False
        Me.GRIDLOT.Name = "GRIDLOT"
        Me.GRIDLOT.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDLOT.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDLOT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDLOT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDLOT.Size = New System.Drawing.Size(1203, 328)
        Me.GRIDLOT.TabIndex = 5
        Me.GRIDLOT.TabStop = False
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
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.ReadOnly = True
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOTNO.Width = 80
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 190
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.HeaderText = "Design No"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.ReadOnly = True
        Me.GDESIGNNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGNNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGNNO.Width = 90
        '
        'GTOTALPCS
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GTOTALPCS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GTOTALPCS.HeaderText = "Total Pcs"
        Me.GTOTALPCS.Name = "GTOTALPCS"
        Me.GTOTALPCS.ReadOnly = True
        Me.GTOTALPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GTOTALPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GTOTALPCS.Width = 80
        '
        'GCOLOR
        '
        Me.GCOLOR.HeaderText = "Color"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.ReadOnly = True
        Me.GCOLOR.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCOLOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCOLOR.Width = 110
        '
        'GURGENT
        '
        Me.GURGENT.HeaderText = "Urgent"
        Me.GURGENT.Name = "GURGENT"
        Me.GURGENT.Width = 70
        '
        'GPCS
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPCS.DefaultCellStyle = DataGridViewCellStyle4
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.ReadOnly = True
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCS.Width = 70
        '
        'GPROGISSDATE
        '
        Me.GPROGISSDATE.HeaderText = "Prog Iss Date"
        Me.GPROGISSDATE.Name = "GPROGISSDATE"
        Me.GPROGISSDATE.ReadOnly = True
        Me.GPROGISSDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPROGISSDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPROGISSDATE.Visible = False
        Me.GPROGISSDATE.Width = 90
        '
        'GSTATUS
        '
        Me.GSTATUS.HeaderText = "Status"
        Me.GSTATUS.Name = "GSTATUS"
        Me.GSTATUS.ReadOnly = True
        Me.GSTATUS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSTATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSTATUS.Visible = False
        Me.GSTATUS.Width = 80
        '
        'GCUTRECDDATE
        '
        Me.GCUTRECDDATE.HeaderText = "Prod Cutting"
        Me.GCUTRECDDATE.Name = "GCUTRECDDATE"
        Me.GCUTRECDDATE.ReadOnly = True
        Me.GCUTRECDDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUTRECDDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUTRECDDATE.Visible = False
        Me.GCUTRECDDATE.Width = 90
        '
        'GFINISHCUTTING
        '
        Me.GFINISHCUTTING.HeaderText = "Finish Cutting"
        Me.GFINISHCUTTING.Name = "GFINISHCUTTING"
        Me.GFINISHCUTTING.ReadOnly = True
        Me.GFINISHCUTTING.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GFINISHCUTTING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GFINISHCUTTING.Visible = False
        Me.GFINISHCUTTING.Width = 90
        '
        'GINWARDDATE
        '
        Me.GINWARDDATE.HeaderText = "Inward Date"
        Me.GINWARDDATE.Name = "GINWARDDATE"
        Me.GINWARDDATE.ReadOnly = True
        Me.GINWARDDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GINWARDDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GINWARDDATE.Visible = False
        Me.GINWARDDATE.Width = 90
        '
        'GGRNNO
        '
        Me.GGRNNO.HeaderText = "GRN No"
        Me.GGRNNO.Name = "GGRNNO"
        Me.GGRNNO.ReadOnly = True
        Me.GGRNNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRNNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRNNO.Width = 80
        '
        'GGRNTYPE
        '
        Me.GGRNTYPE.HeaderText = "GRNTYPE"
        Me.GGRNTYPE.Name = "GGRNTYPE"
        Me.GGRNTYPE.Visible = False
        '
        'GRECDPCS
        '
        Me.GRECDPCS.HeaderText = "Recd Pcs"
        Me.GRECDPCS.Name = "GRECDPCS"
        Me.GRECDPCS.ReadOnly = True
        Me.GRECDPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRECDPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRECDPCS.Visible = False
        '
        'GBARCODE
        '
        Me.GBARCODE.HeaderText = "Barcode"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GBARCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBARCODE.Visible = False
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.Linen
        Me.TXTADD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(798, 439)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.ReadOnly = True
        Me.TXTADD.Size = New System.Drawing.Size(65, 23)
        Me.TXTADD.TabIndex = 686
        Me.TXTADD.TabStop = False
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(835, 440)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(28, 22)
        Me.CMBCODE.TabIndex = 685
        Me.CMBCODE.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(569, 436)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 682
        Me.Label10.Text = "Total"
        '
        'LBLTOTALPCS
        '
        Me.LBLTOTALPCS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALPCS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALPCS.Location = New System.Drawing.Point(606, 436)
        Me.LBLTOTALPCS.Name = "LBLTOTALPCS"
        Me.LBLTOTALPCS.Size = New System.Drawing.Size(74, 15)
        Me.LBLTOTALPCS.TabIndex = 681
        Me.LBLTOTALPCS.Text = "0"
        Me.LBLTOTALPCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(441, 465)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 12
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(25, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 14)
        Me.Label7.TabIndex = 658
        Me.Label7.Text = "Dyeing Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(100, 16)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(245, 22)
        Me.CMBNAME.TabIndex = 2
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(500, 47)
        Me.CMBCOLOR.MaxDropDownItems = 14
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(110, 23)
        Me.CMBCOLOR.TabIndex = 7
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(680, 47)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(70, 23)
        Me.TXTPCS.TabIndex = 9
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PROGRAMDATE
        '
        Me.PROGRAMDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PROGRAMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PROGRAMDATE.Location = New System.Drawing.Point(1117, 43)
        Me.PROGRAMDATE.Name = "PROGRAMDATE"
        Me.PROGRAMDATE.Size = New System.Drawing.Size(87, 23)
        Me.PROGRAMDATE.TabIndex = 1
        Me.PROGRAMDATE.TabStop = False
        '
        'TXTPROGRAMNO
        '
        Me.TXTPROGRAMNO.BackColor = System.Drawing.Color.Linen
        Me.TXTPROGRAMNO.Enabled = False
        Me.TXTPROGRAMNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPROGRAMNO.Location = New System.Drawing.Point(1117, 15)
        Me.TXTPROGRAMNO.Name = "TXTPROGRAMNO"
        Me.TXTPROGRAMNO.ReadOnly = True
        Me.TXTPROGRAMNO.Size = New System.Drawing.Size(87, 23)
        Me.TXTPROGRAMNO.TabIndex = 0
        Me.TXTPROGRAMNO.TabStop = False
        Me.TXTPROGRAMNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLSRNO
        '
        Me.LBLSRNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSRNO.ForeColor = System.Drawing.Color.Black
        Me.LBLSRNO.Location = New System.Drawing.Point(1013, 18)
        Me.LBLSRNO.Name = "LBLSRNO"
        Me.LBLSRNO.Size = New System.Drawing.Size(101, 15)
        Me.LBLSRNO.TabIndex = 634
        Me.LBLSRNO.Text = "Sr. No"
        Me.LBLSRNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1082, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 632
        Me.Label9.Text = "Date"
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(613, 465)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 14
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(354, 465)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 11
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(527, 465)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 13
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.ToolStripButton2, Me.PRINTTOOLSTRIP, Me.TOOLDELETE, Me.ToolStripSeparator2, Me.TOOLPREVIOUS, Me.TOOLNEXT, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 615
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&Save"
        '
        'PRINTTOOLSTRIP
        '
        Me.PRINTTOOLSTRIP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRINTTOOLSTRIP.Image = CType(resources.GetObject("PRINTTOOLSTRIP.Image"), System.Drawing.Image)
        Me.PRINTTOOLSTRIP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PRINTTOOLSTRIP.Name = "PRINTTOOLSTRIP"
        Me.PRINTTOOLSTRIP.Size = New System.Drawing.Size(23, 22)
        Me.PRINTTOOLSTRIP.Text = "&Print"
        '
        'TOOLDELETE
        '
        Me.TOOLDELETE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLDELETE.Image = CType(resources.GetObject("TOOLDELETE.Image"), System.Drawing.Image)
        Me.TOOLDELETE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDELETE.Name = "TOOLDELETE"
        Me.TOOLDELETE.Size = New System.Drawing.Size(23, 22)
        Me.TOOLDELETE.Text = "&Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLPREVIOUS
        '
        Me.TOOLPREVIOUS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOOLPREVIOUS.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.TOOLPREVIOUS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPREVIOUS.Name = "TOOLPREVIOUS"
        Me.TOOLPREVIOUS.Size = New System.Drawing.Size(68, 22)
        Me.TOOLPREVIOUS.Text = "Previous"
        '
        'TOOLNEXT
        '
        Me.TOOLNEXT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOOLNEXT.Image = Global.PROTRADE.My.Resources.Resources.POINT04
        Me.TOOLNEXT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLNEXT.Name = "TOOLNEXT"
        Me.TOOLNEXT.Size = New System.Drawing.Size(50, 22)
        Me.TOOLNEXT.Text = "Next"
        Me.TOOLNEXT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(235, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(78, 22)
        Me.tstxtbillno.TabIndex = 735
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpeningProgramMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningProgramMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Program Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.GRIDLOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTBARCODE As TextBox
    Friend WithEvents CHKURGENT As CheckBox
    Friend WithEvents CMBDESIGNNO As ComboBox
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents CARDRECDATE As MaskedTextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TXTGRNTYPE As TextBox
    Friend WithEvents TXTGRNNO As TextBox
    Friend WithEvents TXTTOTALPCS As TextBox
    Friend WithEvents CMBLOTNO As ComboBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents GRIDLOT As DataGridView
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGNNO As DataGridViewTextBoxColumn
    Friend WithEvents GTOTALPCS As DataGridViewTextBoxColumn
    Friend WithEvents GCOLOR As DataGridViewTextBoxColumn
    Friend WithEvents GURGENT As DataGridViewCheckBoxColumn
    Friend WithEvents GPCS As DataGridViewTextBoxColumn
    Friend WithEvents GPROGISSDATE As DataGridViewTextBoxColumn
    Friend WithEvents GSTATUS As DataGridViewTextBoxColumn
    Friend WithEvents GCUTRECDDATE As DataGridViewTextBoxColumn
    Friend WithEvents GFINISHCUTTING As DataGridViewTextBoxColumn
    Friend WithEvents GINWARDDATE As DataGridViewTextBoxColumn
    Friend WithEvents GGRNNO As DataGridViewTextBoxColumn
    Friend WithEvents GGRNTYPE As DataGridViewTextBoxColumn
    Friend WithEvents GRECDPCS As DataGridViewTextBoxColumn
    Friend WithEvents GBARCODE As DataGridViewTextBoxColumn
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LBLTOTALPCS As Label
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents CMBCOLOR As ComboBox
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents PROGRAMDATE As DateTimePicker
    Friend WithEvents TXTPROGRAMNO As TextBox
    Friend WithEvents LBLSRNO As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents PRINTTOOLSTRIP As ToolStripButton
    Friend WithEvents TOOLDELETE As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TOOLPREVIOUS As ToolStripButton
    Friend WithEvents TOOLNEXT As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents EP As ErrorProvider
End Class
