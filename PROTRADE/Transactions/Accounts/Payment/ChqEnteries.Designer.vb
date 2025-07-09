<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChqEnteries
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChqEnteries))
        Me.CMDDELETE = New System.Windows.Forms.Button
        Me.CMDOK = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TXTENTERYNO = New System.Windows.Forms.TextBox
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.LBLTOTALAMT = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.DTENTERYDATE = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.GRIDISSUE = New System.Windows.Forms.DataGridView
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GACCNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPARTYNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCHQNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCHQDATE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GCHQAMT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBANKNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtsrno = New System.Windows.Forms.TextBox
        Me.TXTBANKNAME = New System.Windows.Forms.TextBox
        Me.DTCHQDATE = New System.Windows.Forms.DateTimePicker
        Me.TXTCHQNO = New System.Windows.Forms.TextBox
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.cmbaccname = New System.Windows.Forms.ComboBox
        Me.txtamt = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.tooldelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtinwords = New System.Windows.Forms.TextBox
        Me.GroupBox5.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDISSUE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(751, 483)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 12
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(579, 483)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 10
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(837, 483)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 13
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(786, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 632
        Me.Label9.Text = "Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(626, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 634
        Me.Label12.Text = "Sr. No"
        '
        'TXTENTERYNO
        '
        Me.TXTENTERYNO.BackColor = System.Drawing.Color.Linen
        Me.TXTENTERYNO.Enabled = False
        Me.TXTENTERYNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTERYNO.Location = New System.Drawing.Point(665, 35)
        Me.TXTENTERYNO.Name = "TXTENTERYNO"
        Me.TXTENTERYNO.ReadOnly = True
        Me.TXTENTERYNO.Size = New System.Drawing.Size(87, 23)
        Me.TXTENTERYNO.TabIndex = 633
        Me.TXTENTERYNO.TabStop = False
        Me.TXTENTERYNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(665, 483)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 11
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'LBLTOTALAMT
        '
        Me.LBLTOTALAMT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALAMT.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALAMT.Location = New System.Drawing.Point(611, 459)
        Me.LBLTOTALAMT.Name = "LBLTOTALAMT"
        Me.LBLTOTALAMT.Size = New System.Drawing.Size(96, 15)
        Me.LBLTOTALAMT.TabIndex = 681
        Me.LBLTOTALAMT.Text = "0"
        Me.LBLTOTALAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(542, 460)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 682
        Me.Label10.Text = "Total"
        '
        'DTENTERYDATE
        '
        Me.DTENTERYDATE.AsciiOnly = True
        Me.DTENTERYDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.DTENTERYDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTENTERYDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DTENTERYDATE.Location = New System.Drawing.Point(819, 31)
        Me.DTENTERYDATE.Mask = "00/00/0000"
        Me.DTENTERYDATE.Name = "DTENTERYDATE"
        Me.DTENTERYDATE.Size = New System.Drawing.Size(88, 23)
        Me.DTENTERYDATE.TabIndex = 1
        Me.DTENTERYDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DTENTERYDATE.ValidatingType = GetType(Date)
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(30, 460)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(382, 54)
        Me.GroupBox5.TabIndex = 9
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(8, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(368, 31)
        Me.txtremarks.TabIndex = 0
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.GRIDISSUE)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.txtsrno)
        Me.BlendPanel1.Controls.Add(Me.TXTBANKNAME)
        Me.BlendPanel1.Controls.Add(Me.DTCHQDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTCHQNO)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.cmbaccname)
        Me.BlendPanel1.Controls.Add(Me.txtamt)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.DTENTERYDATE)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALAMT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.TXTENTERYNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.ForeColor = System.Drawing.Color.Transparent
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(939, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(491, 31)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(82, 22)
        Me.CMBACCCODE.TabIndex = 705
        Me.CMBACCCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(375, 26)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(10, 31)
        Me.txtadd.TabIndex = 704
        Me.txtadd.TabStop = False
        Me.txtadd.Visible = False
        '
        'GRIDISSUE
        '
        Me.GRIDISSUE.AllowUserToAddRows = False
        Me.GRIDISSUE.AllowUserToDeleteRows = False
        Me.GRIDISSUE.AllowUserToResizeColumns = False
        Me.GRIDISSUE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.GRIDISSUE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDISSUE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDISSUE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDISSUE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDISSUE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDISSUE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDISSUE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GACCNAME, Me.GPARTYNAME, Me.GCHQNO, Me.GCHQDATE, Me.GCHQAMT, Me.GBANKNAME})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDISSUE.DefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDISSUE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDISSUE.Location = New System.Drawing.Point(8, 85)
        Me.GRIDISSUE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDISSUE.Name = "GRIDISSUE"
        Me.GRIDISSUE.ReadOnly = True
        Me.GRIDISSUE.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDISSUE.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDISSUE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDISSUE.Size = New System.Drawing.Size(920, 367)
        Me.GRIDISSUE.TabIndex = 703
        Me.GRIDISSUE.TabStop = False
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
        'GACCNAME
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GACCNAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.GACCNAME.HeaderText = "Bank Name"
        Me.GACCNAME.Name = "GACCNAME"
        Me.GACCNAME.ReadOnly = True
        Me.GACCNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GACCNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GACCNAME.Width = 200
        '
        'GPARTYNAME
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GPARTYNAME.DefaultCellStyle = DataGridViewCellStyle4
        Me.GPARTYNAME.HeaderText = "Party Name"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.ReadOnly = True
        Me.GPARTYNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPARTYNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPARTYNAME.Width = 200
        '
        'GCHQNO
        '
        Me.GCHQNO.HeaderText = "Chq No"
        Me.GCHQNO.Name = "GCHQNO"
        Me.GCHQNO.ReadOnly = True
        Me.GCHQNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCHQNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCHQNO.Width = 80
        '
        'GCHQDATE
        '
        Me.GCHQDATE.HeaderText = "Chq Date"
        Me.GCHQDATE.Name = "GCHQDATE"
        Me.GCHQDATE.ReadOnly = True
        Me.GCHQDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCHQDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCHQDATE.Width = 80
        '
        'GCHQAMT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCHQAMT.DefaultCellStyle = DataGridViewCellStyle5
        Me.GCHQAMT.HeaderText = "Amt."
        Me.GCHQAMT.Name = "GCHQAMT"
        Me.GCHQAMT.ReadOnly = True
        Me.GCHQAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCHQAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GBANKNAME
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GBANKNAME.DefaultCellStyle = DataGridViewCellStyle6
        Me.GBANKNAME.HeaderText = "Bank Name"
        Me.GBANKNAME.Name = "GBANKNAME"
        Me.GBANKNAME.ReadOnly = True
        Me.GBANKNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GBANKNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GBANKNAME.Width = 200
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(241, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(74, 22)
        Me.tstxtbillno.TabIndex = 14
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(44, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 702
        Me.Label1.Text = "Add Cheque Entries "
        Me.Label1.Visible = False
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(10, 64)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(39, 22)
        Me.txtsrno.TabIndex = 1
        Me.txtsrno.TabStop = False
        '
        'TXTBANKNAME
        '
        Me.TXTBANKNAME.BackColor = System.Drawing.Color.White
        Me.TXTBANKNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBANKNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTBANKNAME.Location = New System.Drawing.Point(708, 64)
        Me.TXTBANKNAME.Name = "TXTBANKNAME"
        Me.TXTBANKNAME.Size = New System.Drawing.Size(199, 22)
        Me.TXTBANKNAME.TabIndex = 7
        '
        'DTCHQDATE
        '
        Me.DTCHQDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTCHQDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTCHQDATE.Location = New System.Drawing.Point(528, 64)
        Me.DTCHQDATE.Name = "DTCHQDATE"
        Me.DTCHQDATE.Size = New System.Drawing.Size(80, 22)
        Me.DTCHQDATE.TabIndex = 5
        '
        'TXTCHQNO
        '
        Me.TXTCHQNO.BackColor = System.Drawing.Color.White
        Me.TXTCHQNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHQNO.Location = New System.Drawing.Point(447, 64)
        Me.TXTCHQNO.MaxLength = 6
        Me.TXTCHQNO.Name = "TXTCHQNO"
        Me.TXTCHQNO.Size = New System.Drawing.Size(82, 22)
        Me.TXTCHQNO.TabIndex = 4
        Me.TXTCHQNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(247, 64)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(200, 22)
        Me.cmbname.TabIndex = 3
        '
        'cmbaccname
        '
        Me.cmbaccname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbaccname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbaccname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbaccname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbaccname.FormattingEnabled = True
        Me.cmbaccname.Location = New System.Drawing.Point(47, 64)
        Me.cmbaccname.MaxDropDownItems = 14
        Me.cmbaccname.Name = "cmbaccname"
        Me.cmbaccname.Size = New System.Drawing.Size(201, 22)
        Me.cmbaccname.TabIndex = 2
        '
        'txtamt
        '
        Me.txtamt.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtamt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamt.ForeColor = System.Drawing.Color.Black
        Me.txtamt.Location = New System.Drawing.Point(607, 64)
        Me.txtamt.Name = "txtamt"
        Me.txtamt.Size = New System.Drawing.Size(102, 22)
        Me.txtamt.TabIndex = 6
        Me.txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(939, 25)
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
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.ForeColor = System.Drawing.SystemColors.WindowText
        Me.toolprevious.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.ForeColor = System.Drawing.SystemColors.WindowText
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtinwords)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(30, 522)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(563, 45)
        Me.GroupBox3.TabIndex = 706
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "In Words"
        '
        'txtinwords
        '
        Me.txtinwords.BackColor = System.Drawing.Color.Linen
        Me.txtinwords.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwords.ForeColor = System.Drawing.Color.Black
        Me.txtinwords.Location = New System.Drawing.Point(6, 17)
        Me.txtinwords.Multiline = True
        Me.txtinwords.Name = "txtinwords"
        Me.txtinwords.ReadOnly = True
        Me.txtinwords.Size = New System.Drawing.Size(553, 22)
        Me.txtinwords.TabIndex = 15
        Me.txtinwords.TabStop = False
        '
        'ChqEnteries
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(939, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ChqEnteries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Chq Enteries"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDISSUE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTENTERYNO As System.Windows.Forms.TextBox
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents LBLTOTALAMT As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DTENTERYDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents TXTBANKNAME As System.Windows.Forms.TextBox
    Friend WithEvents DTCHQDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTCHQNO As System.Windows.Forms.TextBox
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmbaccname As System.Windows.Forms.ComboBox
    Friend WithEvents txtamt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents GRIDISSUE As System.Windows.Forms.DataGridView
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GACCNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPARTYNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCHQNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCHQDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCHQAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBANKNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtinwords As System.Windows.Forms.TextBox
End Class
