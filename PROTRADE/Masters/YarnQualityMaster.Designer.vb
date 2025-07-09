<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnQualityMaster
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBHSNCODE = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBYARNQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTDENIER = New System.Windows.Forms.TextBox()
        Me.GPSTORES = New System.Windows.Forms.GroupBox()
        Me.TXTSTOREQTY = New System.Windows.Forms.TextBox()
        Me.CMBSTOREITEM = New System.Windows.Forms.ComboBox()
        Me.TXTSSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDSTORES = New System.Windows.Forms.DataGridView()
        Me.SSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SSTOREITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTBOXWT = New System.Windows.Forms.TextBox()
        Me.GRPCOMPOSITION = New System.Windows.Forms.GroupBox()
        Me.TXTTOTALPER = New System.Windows.Forms.TextBox()
        Me.CMBYARNCONPOSITION = New System.Windows.Forms.ComboBox()
        Me.TXTPER = New System.Windows.Forms.TextBox()
        Me.GRIDCOMP = New System.Windows.Forms.DataGridView()
        Me.GYARNQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.LBLCODE = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GPSTORES.SuspendLayout()
        CType(Me.GRIDSTORES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRPCOMPOSITION.SuspendLayout()
        CType(Me.GRIDCOMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMBYARNQUALITY)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTDENIER)
        Me.BlendPanel1.Controls.Add(Me.GPSTORES)
        Me.BlendPanel1.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel1.Controls.Add(Me.lblcategory)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTBOXWT)
        Me.BlendPanel1.Controls.Add(Me.GRPCOMPOSITION)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.LBLCODE)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.txtname)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(965, 386)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBHSNCODE
        '
        Me.CMBHSNCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHSNCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBHSNCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBHSNCODE.FormattingEnabled = True
        Me.CMBHSNCODE.Location = New System.Drawing.Point(111, 227)
        Me.CMBHSNCODE.MaxDropDownItems = 14
        Me.CMBHSNCODE.Name = "CMBHSNCODE"
        Me.CMBHSNCODE.Size = New System.Drawing.Size(73, 23)
        Me.CMBHSNCODE.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(47, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 362
        Me.Label9.Text = "Effect Into"
        '
        'CMBYARNQUALITY
        '
        Me.CMBYARNQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBYARNQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBYARNQUALITY.FormattingEnabled = True
        Me.CMBYARNQUALITY.Location = New System.Drawing.Point(111, 67)
        Me.CMBYARNQUALITY.Name = "CMBYARNQUALITY"
        Me.CMBYARNQUALITY.Size = New System.Drawing.Size(233, 23)
        Me.CMBYARNQUALITY.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(242, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 14)
        Me.Label5.TabIndex = 359
        Me.Label5.Text = "Rate"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.White
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(277, 227)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(67, 22)
        Me.TXTRATE.TabIndex = 7
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 356
        Me.Label3.Text = "HSN Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(230, 204)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 313
        Me.Label2.Text = "Denier"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTDENIER
        '
        Me.TXTDENIER.BackColor = System.Drawing.Color.White
        Me.TXTDENIER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDENIER.Location = New System.Drawing.Point(277, 200)
        Me.TXTDENIER.Name = "TXTDENIER"
        Me.TXTDENIER.Size = New System.Drawing.Size(67, 22)
        Me.TXTDENIER.TabIndex = 5
        Me.TXTDENIER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GPSTORES
        '
        Me.GPSTORES.BackColor = System.Drawing.Color.Transparent
        Me.GPSTORES.Controls.Add(Me.TXTSTOREQTY)
        Me.GPSTORES.Controls.Add(Me.CMBSTOREITEM)
        Me.GPSTORES.Controls.Add(Me.TXTSSRNO)
        Me.GPSTORES.Controls.Add(Me.GRIDSTORES)
        Me.GPSTORES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPSTORES.ForeColor = System.Drawing.Color.Black
        Me.GPSTORES.Location = New System.Drawing.Point(653, 29)
        Me.GPSTORES.Name = "GPSTORES"
        Me.GPSTORES.Size = New System.Drawing.Size(292, 206)
        Me.GPSTORES.TabIndex = 10
        Me.GPSTORES.TabStop = False
        Me.GPSTORES.Text = "Stores Details"
        '
        'TXTSTOREQTY
        '
        Me.TXTSTOREQTY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTOREQTY.Location = New System.Drawing.Point(211, 21)
        Me.TXTSTOREQTY.Name = "TXTSTOREQTY"
        Me.TXTSTOREQTY.Size = New System.Drawing.Size(40, 22)
        Me.TXTSTOREQTY.TabIndex = 1
        Me.TXTSTOREQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBSTOREITEM
        '
        Me.CMBSTOREITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTOREITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTOREITEM.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSTOREITEM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTOREITEM.FormattingEnabled = True
        Me.CMBSTOREITEM.Location = New System.Drawing.Point(51, 21)
        Me.CMBSTOREITEM.MaxDropDownItems = 14
        Me.CMBSTOREITEM.Name = "CMBSTOREITEM"
        Me.CMBSTOREITEM.Size = New System.Drawing.Size(160, 22)
        Me.CMBSTOREITEM.TabIndex = 0
        '
        'TXTSSRNO
        '
        Me.TXTSSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSSRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSSRNO.Location = New System.Drawing.Point(11, 21)
        Me.TXTSSRNO.Name = "TXTSSRNO"
        Me.TXTSSRNO.ReadOnly = True
        Me.TXTSSRNO.Size = New System.Drawing.Size(40, 22)
        Me.TXTSSRNO.TabIndex = 0
        Me.TXTSSRNO.TabStop = False
        Me.TXTSSRNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDSTORES
        '
        Me.GRIDSTORES.AllowUserToAddRows = False
        Me.GRIDSTORES.AllowUserToDeleteRows = False
        Me.GRIDSTORES.AllowUserToResizeColumns = False
        Me.GRIDSTORES.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDSTORES.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDSTORES.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSTORES.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSTORES.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDSTORES.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.GRIDSTORES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSTORES.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SSRNO, Me.SSTOREITEM, Me.SQTY})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSTORES.DefaultCellStyle = DataGridViewCellStyle12
        Me.GRIDSTORES.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDSTORES.Location = New System.Drawing.Point(11, 43)
        Me.GRIDSTORES.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDSTORES.MultiSelect = False
        Me.GRIDSTORES.Name = "GRIDSTORES"
        Me.GRIDSTORES.ReadOnly = True
        Me.GRIDSTORES.RowHeadersVisible = False
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSTORES.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GRIDSTORES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSTORES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSTORES.Size = New System.Drawing.Size(270, 158)
        Me.GRIDSTORES.TabIndex = 2
        '
        'SSRNO
        '
        Me.SSRNO.HeaderText = "Sr"
        Me.SSRNO.Name = "SSRNO"
        Me.SSRNO.ReadOnly = True
        Me.SSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SSRNO.Width = 40
        '
        'SSTOREITEM
        '
        Me.SSTOREITEM.HeaderText = "Store Item Name"
        Me.SSTOREITEM.Name = "SSTOREITEM"
        Me.SSTOREITEM.ReadOnly = True
        Me.SSTOREITEM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SSTOREITEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SSTOREITEM.Width = 160
        '
        'SQTY
        '
        Me.SQTY.HeaderText = "Qty"
        Me.SQTY.Name = "SQTY"
        Me.SQTY.ReadOnly = True
        Me.SQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SQTY.Width = 40
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(111, 95)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(233, 22)
        Me.CMBCATEGORY.TabIndex = 2
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.Transparent
        Me.lblcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(56, 99)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(53, 14)
        Me.lblcategory.TabIndex = 311
        Me.lblcategory.Text = "Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(14, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 14)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Wt Per Box/Tube"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTBOXWT
        '
        Me.TXTBOXWT.BackColor = System.Drawing.Color.White
        Me.TXTBOXWT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOXWT.Location = New System.Drawing.Point(111, 199)
        Me.TXTBOXWT.Name = "TXTBOXWT"
        Me.TXTBOXWT.Size = New System.Drawing.Size(73, 22)
        Me.TXTBOXWT.TabIndex = 4
        Me.TXTBOXWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRPCOMPOSITION
        '
        Me.GRPCOMPOSITION.BackColor = System.Drawing.Color.Transparent
        Me.GRPCOMPOSITION.Controls.Add(Me.TXTTOTALPER)
        Me.GRPCOMPOSITION.Controls.Add(Me.CMBYARNCONPOSITION)
        Me.GRPCOMPOSITION.Controls.Add(Me.TXTPER)
        Me.GRPCOMPOSITION.Controls.Add(Me.GRIDCOMP)
        Me.GRPCOMPOSITION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRPCOMPOSITION.ForeColor = System.Drawing.Color.Black
        Me.GRPCOMPOSITION.Location = New System.Drawing.Point(355, 29)
        Me.GRPCOMPOSITION.Name = "GRPCOMPOSITION"
        Me.GRPCOMPOSITION.Size = New System.Drawing.Size(292, 173)
        Me.GRPCOMPOSITION.TabIndex = 9
        Me.GRPCOMPOSITION.TabStop = False
        Me.GRPCOMPOSITION.Text = "Yarn Composition"
        '
        'TXTTOTALPER
        '
        Me.TXTTOTALPER.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPER.Location = New System.Drawing.Point(211, 146)
        Me.TXTTOTALPER.Name = "TXTTOTALPER"
        Me.TXTTOTALPER.ReadOnly = True
        Me.TXTTOTALPER.Size = New System.Drawing.Size(40, 22)
        Me.TXTTOTALPER.TabIndex = 355
        Me.TXTTOTALPER.TabStop = False
        Me.TXTTOTALPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBYARNCONPOSITION
        '
        Me.CMBYARNCONPOSITION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBYARNCONPOSITION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBYARNCONPOSITION.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBYARNCONPOSITION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBYARNCONPOSITION.FormattingEnabled = True
        Me.CMBYARNCONPOSITION.Location = New System.Drawing.Point(11, 21)
        Me.CMBYARNCONPOSITION.MaxDropDownItems = 14
        Me.CMBYARNCONPOSITION.Name = "CMBYARNCONPOSITION"
        Me.CMBYARNCONPOSITION.Size = New System.Drawing.Size(200, 22)
        Me.CMBYARNCONPOSITION.TabIndex = 0
        '
        'TXTPER
        '
        Me.TXTPER.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPER.Location = New System.Drawing.Point(211, 21)
        Me.TXTPER.Name = "TXTPER"
        Me.TXTPER.Size = New System.Drawing.Size(40, 22)
        Me.TXTPER.TabIndex = 1
        Me.TXTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDCOMP
        '
        Me.GRIDCOMP.AllowUserToAddRows = False
        Me.GRIDCOMP.AllowUserToDeleteRows = False
        Me.GRIDCOMP.AllowUserToResizeColumns = False
        Me.GRIDCOMP.AllowUserToResizeRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDCOMP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.GRIDCOMP.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCOMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCOMP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDCOMP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.GRIDCOMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCOMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GYARNQUALITY, Me.GPER})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCOMP.DefaultCellStyle = DataGridViewCellStyle17
        Me.GRIDCOMP.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDCOMP.Location = New System.Drawing.Point(11, 43)
        Me.GRIDCOMP.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDCOMP.MultiSelect = False
        Me.GRIDCOMP.Name = "GRIDCOMP"
        Me.GRIDCOMP.ReadOnly = True
        Me.GRIDCOMP.RowHeadersVisible = False
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCOMP.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.GRIDCOMP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDCOMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCOMP.Size = New System.Drawing.Size(270, 100)
        Me.GRIDCOMP.TabIndex = 2
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.HeaderText = "Yarn Quality"
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.ReadOnly = True
        Me.GYARNQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GYARNQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GYARNQUALITY.Width = 200
        '
        'GPER
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPER.DefaultCellStyle = DataGridViewCellStyle16
        Me.GPER.HeaderText = "%"
        Me.GPER.Name = "GPER"
        Me.GPER.ReadOnly = True
        Me.GPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPER.Width = 40
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(254, 346)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 12
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'LBLCODE
        '
        Me.LBLCODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLCODE.Location = New System.Drawing.Point(30, 124)
        Me.LBLCODE.Name = "LBLCODE"
        Me.LBLCODE.Size = New System.Drawing.Size(79, 22)
        Me.LBLCODE.TabIndex = 154
        Me.LBLCODE.Text = "Remark"
        Me.LBLCODE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(111, 124)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(233, 69)
        Me.txtremarks.TabIndex = 3
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(340, 346)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 13
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(168, 346)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 11
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(12, 39)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 152
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'lblgroup
        '
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(30, 39)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(79, 22)
        Me.lblgroup.TabIndex = 149
        Me.lblgroup.Text = "Name"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(111, 39)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(233, 22)
        Me.txtname.TabIndex = 0
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(426, 346)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'YarnQualityMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(965, 386)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnQualityMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Quality Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPSTORES.ResumeLayout(False)
        Me.GPSTORES.PerformLayout()
        CType(Me.GRIDSTORES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRPCOMPOSITION.ResumeLayout(False)
        Me.GRPCOMPOSITION.PerformLayout()
        CType(Me.GRIDCOMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents LBLCODE As System.Windows.Forms.Label
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents GRPCOMPOSITION As System.Windows.Forms.GroupBox
    Friend WithEvents TXTTOTALPER As System.Windows.Forms.TextBox
    Friend WithEvents CMBYARNCONPOSITION As System.Windows.Forms.ComboBox
    Friend WithEvents TXTPER As System.Windows.Forms.TextBox
    Friend WithEvents GRIDCOMP As System.Windows.Forms.DataGridView
    Friend WithEvents GYARNQUALITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTBOXWT As TextBox
    Friend WithEvents CMBCATEGORY As ComboBox
    Friend WithEvents lblcategory As Label
    Friend WithEvents GPSTORES As GroupBox
    Friend WithEvents TXTSTOREQTY As TextBox
    Friend WithEvents CMBSTOREITEM As ComboBox
    Friend WithEvents TXTSSRNO As TextBox
    Friend WithEvents GRIDSTORES As DataGridView
    Friend WithEvents SSRNO As DataGridViewTextBoxColumn
    Friend WithEvents SSTOREITEM As DataGridViewTextBoxColumn
    Friend WithEvents SQTY As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTDENIER As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTRATE As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CMBYARNQUALITY As ComboBox
    Friend WithEvents CMBHSNCODE As ComboBox
End Class
