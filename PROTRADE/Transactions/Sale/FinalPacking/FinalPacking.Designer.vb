<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinalPacking
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FinalPacking))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTBARCODE = New System.Windows.Forms.TextBox
        Me.PBlock = New System.Windows.Forms.PictureBox
        Me.lbllocked = New System.Windows.Forms.Label
        Me.LBLTOTALITEMMTRS = New System.Windows.Forms.Label
        Me.TXTPCSMTRS = New System.Windows.Forms.TextBox
        Me.GRIDITEMDESC = New System.Windows.Forms.DataGridView
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GITEMMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GRIDFP = New System.Windows.Forms.DataGridView
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMERCHANTNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPCSMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GBARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GOUTPCS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GOUTMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTMTRS = New System.Windows.Forms.TextBox
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox
        Me.TXTSRNO = New System.Windows.Forms.TextBox
        Me.TXTPCS = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lbltotalqty = New System.Windows.Forms.Label
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.TXTFPNO = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblgrndate = New System.Windows.Forms.Label
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.tooldelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.FPDATE = New System.Windows.Forms.MaskedTextBox
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDITEMDESC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.FPDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALITEMMTRS)
        Me.BlendPanel1.Controls.Add(Me.TXTPCSMTRS)
        Me.BlendPanel1.Controls.Add(Me.GRIDITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.GRIDFP)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.lbltotalqty)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTFPNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.lblgrndate)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(859, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBARCODE.Location = New System.Drawing.Point(402, 37)
        Me.TXTBARCODE.Multiline = True
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.ReadOnly = True
        Me.TXTBARCODE.Size = New System.Drawing.Size(10, 19)
        Me.TXTBARCODE.TabIndex = 669
        Me.TXTBARCODE.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.PROTRADE.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(499, 44)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 448
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(565, 46)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 447
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'LBLTOTALITEMMTRS
        '
        Me.LBLTOTALITEMMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALITEMMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALITEMMTRS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALITEMMTRS.Location = New System.Drawing.Point(714, 494)
        Me.LBLTOTALITEMMTRS.Name = "LBLTOTALITEMMTRS"
        Me.LBLTOTALITEMMTRS.Size = New System.Drawing.Size(83, 15)
        Me.LBLTOTALITEMMTRS.TabIndex = 659
        Me.LBLTOTALITEMMTRS.Text = "0"
        Me.LBLTOTALITEMMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTPCSMTRS
        '
        Me.TXTPCSMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTPCSMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCSMTRS.Location = New System.Drawing.Point(319, 98)
        Me.TXTPCSMTRS.Name = "TXTPCSMTRS"
        Me.TXTPCSMTRS.ReadOnly = True
        Me.TXTPCSMTRS.Size = New System.Drawing.Size(80, 23)
        Me.TXTPCSMTRS.TabIndex = 658
        Me.TXTPCSMTRS.TabStop = False
        Me.TXTPCSMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDITEMDESC
        '
        Me.GRIDITEMDESC.AllowUserToAddRows = False
        Me.GRIDITEMDESC.AllowUserToDeleteRows = False
        Me.GRIDITEMDESC.AllowUserToResizeColumns = False
        Me.GRIDITEMDESC.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDITEMDESC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDITEMDESC.BackgroundColor = System.Drawing.Color.White
        Me.GRIDITEMDESC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDITEMDESC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDITEMDESC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDITEMDESC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDITEMDESC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GITEMNAME, Me.GITEMMTRS})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDITEMDESC.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDITEMDESC.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDITEMDESC.Location = New System.Drawing.Point(515, 121)
        Me.GRIDITEMDESC.MultiSelect = False
        Me.GRIDITEMDESC.Name = "GRIDITEMDESC"
        Me.GRIDITEMDESC.ReadOnly = True
        Me.GRIDITEMDESC.RowHeadersVisible = False
        Me.GRIDITEMDESC.RowHeadersWidth = 30
        Me.GRIDITEMDESC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDITEMDESC.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDITEMDESC.RowTemplate.Height = 20
        Me.GRIDITEMDESC.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDITEMDESC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDITEMDESC.Size = New System.Drawing.Size(314, 370)
        Me.GRIDITEMDESC.TabIndex = 657
        Me.GRIDITEMDESC.TabStop = False
        '
        'GITEMNAME
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GITEMNAME.DefaultCellStyle = DataGridViewCellStyle3
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 200
        '
        'GITEMMTRS
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GITEMMTRS.DefaultCellStyle = DataGridViewCellStyle4
        Me.GITEMMTRS.HeaderText = "Mtrs."
        Me.GITEMMTRS.Name = "GITEMMTRS"
        Me.GITEMMTRS.ReadOnly = True
        Me.GITEMMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMMTRS.Width = 80
        '
        'GRIDFP
        '
        Me.GRIDFP.AllowUserToAddRows = False
        Me.GRIDFP.AllowUserToDeleteRows = False
        Me.GRIDFP.AllowUserToResizeColumns = False
        Me.GRIDFP.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDFP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDFP.BackgroundColor = System.Drawing.Color.White
        Me.GRIDFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDFP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDFP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDFP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDFP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.GMERCHANTNAME, Me.GPCS, Me.GPCSMTRS, Me.GMTRS, Me.GBARCODE, Me.GOUTPCS, Me.GOUTMTRS})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDFP.DefaultCellStyle = DataGridViewCellStyle12
        Me.GRIDFP.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDFP.Location = New System.Drawing.Point(29, 121)
        Me.GRIDFP.MultiSelect = False
        Me.GRIDFP.Name = "GRIDFP"
        Me.GRIDFP.ReadOnly = True
        Me.GRIDFP.RowHeadersVisible = False
        Me.GRIDFP.RowHeadersWidth = 30
        Me.GRIDFP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDFP.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GRIDFP.RowTemplate.Height = 20
        Me.GRIDFP.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDFP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDFP.Size = New System.Drawing.Size(480, 370)
        Me.GRIDFP.TabIndex = 13
        Me.GRIDFP.TabStop = False
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
        'GMERCHANTNAME
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GMERCHANTNAME.DefaultCellStyle = DataGridViewCellStyle9
        Me.GMERCHANTNAME.HeaderText = "Merchant Name"
        Me.GMERCHANTNAME.Name = "GMERCHANTNAME"
        Me.GMERCHANTNAME.ReadOnly = True
        Me.GMERCHANTNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMERCHANTNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMERCHANTNAME.Width = 200
        '
        'GPCS
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.NullValue = Nothing
        Me.GPCS.DefaultCellStyle = DataGridViewCellStyle10
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.ReadOnly = True
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCS.Width = 60
        '
        'GPCSMTRS
        '
        Me.GPCSMTRS.HeaderText = "Mtr/Pcs"
        Me.GPCSMTRS.Name = "GPCSMTRS"
        Me.GPCSMTRS.ReadOnly = True
        Me.GPCSMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCSMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPCSMTRS.Width = 80
        '
        'GMTRS
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle11
        Me.GMTRS.HeaderText = "Mtrs."
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 80
        '
        'GBARCODE
        '
        Me.GBARCODE.HeaderText = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.ReadOnly = True
        Me.GBARCODE.Visible = False
        '
        'GOUTPCS
        '
        Me.GOUTPCS.HeaderText = "OUTPCS"
        Me.GOUTPCS.Name = "GOUTPCS"
        Me.GOUTPCS.ReadOnly = True
        Me.GOUTPCS.Visible = False
        '
        'GOUTMTRS
        '
        Me.GOUTMTRS.HeaderText = "OUTMTRS"
        Me.GOUTMTRS.Name = "GOUTMTRS"
        Me.GOUTMTRS.ReadOnly = True
        Me.GOUTMTRS.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(46, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 656
        Me.Label1.Text = "Godown"
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.Linen
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(399, 98)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.ReadOnly = True
        Me.TXTMTRS.Size = New System.Drawing.Size(80, 23)
        Me.TXTMTRS.TabIndex = 4
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(100, 69)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(239, 23)
        Me.CMBGODOWN.TabIndex = 1
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBMERCHANT.DropDownWidth = 400
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(59, 98)
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(200, 23)
        Me.CMBMERCHANT.TabIndex = 2
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(29, 98)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(259, 98)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(60, 23)
        Me.TXTPCS.TabIndex = 3
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(229, 494)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 15)
        Me.Label10.TabIndex = 635
        Me.Label10.Text = "Total"
        '
        'lbltotalqty
        '
        Me.lbltotalqty.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalqty.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalqty.ForeColor = System.Drawing.Color.Black
        Me.lbltotalqty.Location = New System.Drawing.Point(260, 494)
        Me.lbltotalqty.Name = "lbltotalqty"
        Me.lbltotalqty.Size = New System.Drawing.Size(83, 15)
        Me.lbltotalqty.TabIndex = 634
        Me.lbltotalqty.Text = "0"
        Me.lbltotalqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALMTRS.ForeColor = System.Drawing.Color.Black
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(399, 494)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(83, 15)
        Me.LBLTOTALMTRS.TabIndex = 642
        Me.LBLTOTALMTRS.Text = "0"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(432, 522)
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
        Me.cmdclear.Location = New System.Drawing.Point(346, 522)
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
        Me.cmdok.Location = New System.Drawing.Point(260, 522)
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
        Me.cmdexit.Location = New System.Drawing.Point(518, 522)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTFPNO
        '
        Me.TXTFPNO.BackColor = System.Drawing.Color.Linen
        Me.TXTFPNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFPNO.Location = New System.Drawing.Point(744, 40)
        Me.TXTFPNO.Name = "TXTFPNO"
        Me.TXTFPNO.ReadOnly = True
        Me.TXTFPNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTFPNO.TabIndex = 627
        Me.TXTFPNO.TabStop = False
        Me.TXTFPNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(704, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 630
        Me.Label12.Text = "Sr. No"
        '
        'lblgrndate
        '
        Me.lblgrndate.AutoSize = True
        Me.lblgrndate.BackColor = System.Drawing.Color.Transparent
        Me.lblgrndate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgrndate.ForeColor = System.Drawing.Color.Black
        Me.lblgrndate.Location = New System.Drawing.Point(709, 73)
        Me.lblgrndate.Name = "lblgrndate"
        Me.lblgrndate.Size = New System.Drawing.Size(32, 15)
        Me.lblgrndate.TabIndex = 622
        Me.lblgrndate.Text = "Date"
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(239, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(54, 22)
        Me.tstxtbillno.TabIndex = 13
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(11, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 26)
        Me.Label2.TabIndex = 430
        Me.Label2.Text = "Final Packing"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(859, 25)
        Me.ToolStrip1.TabIndex = 14
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
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'FPDATE
        '
        Me.FPDATE.AsciiOnly = True
        Me.FPDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.FPDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.FPDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.FPDATE.Location = New System.Drawing.Point(744, 69)
        Me.FPDATE.Mask = "00/00/0000"
        Me.FPDATE.Name = "FPDATE"
        Me.FPDATE.Size = New System.Drawing.Size(88, 23)
        Me.FPDATE.TabIndex = 0
        Me.FPDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.FPDATE.ValidatingType = GetType(Date)
        '
        'FinalPacking
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(859, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FinalPacking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Final Packing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDITEMDESC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBGODOWN As System.Windows.Forms.ComboBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTFPNO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblgrndate As System.Windows.Forms.Label
    Friend WithEvents GRIDFP As System.Windows.Forms.DataGridView
    Friend WithEvents CMBMERCHANT As System.Windows.Forms.ComboBox
    Friend WithEvents TXTSRNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTPCS As System.Windows.Forms.TextBox
    Friend WithEvents TXTMTRS As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbltotalqty As System.Windows.Forms.Label
    Friend WithEvents LBLTOTALMTRS As System.Windows.Forms.Label
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GRIDITEMDESC As System.Windows.Forms.DataGridView
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GITEMMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTPCSMTRS As System.Windows.Forms.TextBox
    Friend WithEvents LBLTOTALITEMMTRS As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents TXTBARCODE As System.Windows.Forms.TextBox
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMERCHANTNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPCSMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBARCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOUTPCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GOUTMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FPDATE As System.Windows.Forms.MaskedTextBox
End Class
