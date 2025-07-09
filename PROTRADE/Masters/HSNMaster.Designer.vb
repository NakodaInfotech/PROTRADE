<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HSNMaster
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.WEFDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTGRIDEXPORTIGST = New System.Windows.Forms.TextBox()
        Me.TXTGRIDEXPORTSGST = New System.Windows.Forms.TextBox()
        Me.TXTGRIDEXPORTCGST = New System.Windows.Forms.TextBox()
        Me.TXTGRIDRATE1 = New System.Windows.Forms.TextBox()
        Me.TXTGRIDIGST1 = New System.Windows.Forms.TextBox()
        Me.TXTGRIDSGST1 = New System.Windows.Forms.TextBox()
        Me.TXTGRIDCGST1 = New System.Windows.Forms.TextBox()
        Me.TXTGRIDRATE = New System.Windows.Forms.TextBox()
        Me.TXTGRIDIGST = New System.Windows.Forms.TextBox()
        Me.TXTGRIDSGST = New System.Windows.Forms.TextBox()
        Me.TXTGRIDCGST = New System.Windows.Forms.TextBox()
        Me.GRIDHSN = New System.Windows.Forms.DataGridView()
        Me.GDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCGST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSGST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GIGST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRATE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCGST1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSGST1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GIGST1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXPCGST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXPSGST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXPIGST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTEXPORTIGST = New System.Windows.Forms.TextBox()
        Me.TXTEXPORTSGST = New System.Windows.Forms.TextBox()
        Me.TXTEXPORTCGST = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTRATE1 = New System.Windows.Forms.TextBox()
        Me.TXTIGST1 = New System.Windows.Forms.TextBox()
        Me.TXTSGST1 = New System.Windows.Forms.TextBox()
        Me.TXTCGST1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.TXTIGST = New System.Windows.Forms.TextBox()
        Me.TXTSGST = New System.Windows.Forms.TextBox()
        Me.TXTCGST = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.TXTITEMDESC = New System.Windows.Forms.TextBox()
        Me.LBLITEMDESC = New System.Windows.Forms.Label()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTHSNNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDHSN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.WEFDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDEXPORTIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDEXPORTSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDEXPORTCGST)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDRATE1)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDIGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDSGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDCGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTGRIDCGST)
        Me.BlendPanel1.Controls.Add(Me.GRIDHSN)
        Me.BlendPanel1.Controls.Add(Me.TXTEXPORTIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTEXPORTSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTEXPORTCGST)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE1)
        Me.BlendPanel1.Controls.Add(Me.TXTIGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTSGST1)
        Me.BlendPanel1.Controls.Add(Me.TXTCGST1)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.TXTIGST)
        Me.BlendPanel1.Controls.Add(Me.TXTSGST)
        Me.BlendPanel1.Controls.Add(Me.TXTCGST)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTDESC)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.LBLITEMDESC)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTHSNNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1035, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'WEFDATE
        '
        Me.WEFDATE.AsciiOnly = True
        Me.WEFDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.WEFDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.WEFDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.WEFDATE.Location = New System.Drawing.Point(51, 184)
        Me.WEFDATE.Mask = "00/00/0000"
        Me.WEFDATE.Name = "WEFDATE"
        Me.WEFDATE.Size = New System.Drawing.Size(90, 23)
        Me.WEFDATE.TabIndex = 15
        Me.WEFDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.WEFDATE.ValidatingType = GetType(Date)
        '
        'TXTGRIDEXPORTIGST
        '
        Me.TXTGRIDEXPORTIGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDEXPORTIGST.Location = New System.Drawing.Point(881, 184)
        Me.TXTGRIDEXPORTIGST.Name = "TXTGRIDEXPORTIGST"
        Me.TXTGRIDEXPORTIGST.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRIDEXPORTIGST.TabIndex = 26
        Me.TXTGRIDEXPORTIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDEXPORTSGST
        '
        Me.TXTGRIDEXPORTSGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDEXPORTSGST.Location = New System.Drawing.Point(801, 184)
        Me.TXTGRIDEXPORTSGST.Name = "TXTGRIDEXPORTSGST"
        Me.TXTGRIDEXPORTSGST.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRIDEXPORTSGST.TabIndex = 25
        Me.TXTGRIDEXPORTSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDEXPORTCGST
        '
        Me.TXTGRIDEXPORTCGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDEXPORTCGST.Location = New System.Drawing.Point(721, 184)
        Me.TXTGRIDEXPORTCGST.Name = "TXTGRIDEXPORTCGST"
        Me.TXTGRIDEXPORTCGST.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRIDEXPORTCGST.TabIndex = 24
        Me.TXTGRIDEXPORTCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDRATE1
        '
        Me.TXTGRIDRATE1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDRATE1.Location = New System.Drawing.Point(431, 184)
        Me.TXTGRIDRATE1.Name = "TXTGRIDRATE1"
        Me.TXTGRIDRATE1.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRIDRATE1.TabIndex = 20
        Me.TXTGRIDRATE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDIGST1
        '
        Me.TXTGRIDIGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDIGST1.Location = New System.Drawing.Point(651, 184)
        Me.TXTGRIDIGST1.Name = "TXTGRIDIGST1"
        Me.TXTGRIDIGST1.Size = New System.Drawing.Size(70, 23)
        Me.TXTGRIDIGST1.TabIndex = 23
        Me.TXTGRIDIGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDSGST1
        '
        Me.TXTGRIDSGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDSGST1.Location = New System.Drawing.Point(581, 184)
        Me.TXTGRIDSGST1.Name = "TXTGRIDSGST1"
        Me.TXTGRIDSGST1.Size = New System.Drawing.Size(70, 23)
        Me.TXTGRIDSGST1.TabIndex = 22
        Me.TXTGRIDSGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDCGST1
        '
        Me.TXTGRIDCGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDCGST1.Location = New System.Drawing.Point(511, 184)
        Me.TXTGRIDCGST1.Name = "TXTGRIDCGST1"
        Me.TXTGRIDCGST1.Size = New System.Drawing.Size(70, 23)
        Me.TXTGRIDCGST1.TabIndex = 21
        Me.TXTGRIDCGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDRATE
        '
        Me.TXTGRIDRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDRATE.Location = New System.Drawing.Point(141, 184)
        Me.TXTGRIDRATE.Name = "TXTGRIDRATE"
        Me.TXTGRIDRATE.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRIDRATE.TabIndex = 16
        Me.TXTGRIDRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDIGST
        '
        Me.TXTGRIDIGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDIGST.Location = New System.Drawing.Point(361, 184)
        Me.TXTGRIDIGST.Name = "TXTGRIDIGST"
        Me.TXTGRIDIGST.Size = New System.Drawing.Size(70, 23)
        Me.TXTGRIDIGST.TabIndex = 19
        Me.TXTGRIDIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDSGST
        '
        Me.TXTGRIDSGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDSGST.Location = New System.Drawing.Point(291, 184)
        Me.TXTGRIDSGST.Name = "TXTGRIDSGST"
        Me.TXTGRIDSGST.Size = New System.Drawing.Size(70, 23)
        Me.TXTGRIDSGST.TabIndex = 18
        Me.TXTGRIDSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTGRIDCGST
        '
        Me.TXTGRIDCGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDCGST.Location = New System.Drawing.Point(221, 184)
        Me.TXTGRIDCGST.Name = "TXTGRIDCGST"
        Me.TXTGRIDCGST.Size = New System.Drawing.Size(70, 23)
        Me.TXTGRIDCGST.TabIndex = 17
        Me.TXTGRIDCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDHSN
        '
        Me.GRIDHSN.AllowUserToAddRows = False
        Me.GRIDHSN.AllowUserToDeleteRows = False
        Me.GRIDHSN.AllowUserToResizeColumns = False
        Me.GRIDHSN.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.GRIDHSN.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDHSN.BackgroundColor = System.Drawing.Color.White
        Me.GRIDHSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDHSN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDHSN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDHSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDHSN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GDATE, Me.GRATE, Me.GCGST, Me.GSGST, Me.GIGST, Me.GRATE1, Me.GCGST1, Me.GSGST1, Me.GIGST1, Me.GEXPCGST, Me.GEXPSGST, Me.GEXPIGST})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDHSN.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDHSN.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDHSN.Location = New System.Drawing.Point(51, 207)
        Me.GRIDHSN.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDHSN.MultiSelect = False
        Me.GRIDHSN.Name = "GRIDHSN"
        Me.GRIDHSN.ReadOnly = True
        Me.GRIDHSN.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDHSN.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDHSN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDHSN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDHSN.Size = New System.Drawing.Size(949, 312)
        Me.GRIDHSN.TabIndex = 27
        '
        'GDATE
        '
        Me.GDATE.HeaderText = "Date"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.ReadOnly = True
        Me.GDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDATE.Width = 90
        '
        'GRATE
        '
        Me.GRATE.HeaderText = "Rate"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.ReadOnly = True
        Me.GRATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE.Width = 80
        '
        'GCGST
        '
        Me.GCGST.HeaderText = "CGST %"
        Me.GCGST.Name = "GCGST"
        Me.GCGST.ReadOnly = True
        Me.GCGST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCGST.Width = 70
        '
        'GSGST
        '
        Me.GSGST.HeaderText = "SGST %"
        Me.GSGST.Name = "GSGST"
        Me.GSGST.ReadOnly = True
        Me.GSGST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSGST.Width = 70
        '
        'GIGST
        '
        Me.GIGST.HeaderText = "IGST %"
        Me.GIGST.Name = "GIGST"
        Me.GIGST.ReadOnly = True
        Me.GIGST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GIGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GIGST.Width = 70
        '
        'GRATE1
        '
        Me.GRATE1.HeaderText = "Rate >"
        Me.GRATE1.Name = "GRATE1"
        Me.GRATE1.ReadOnly = True
        Me.GRATE1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRATE1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GRATE1.Width = 80
        '
        'GCGST1
        '
        Me.GCGST1.HeaderText = "CGST %"
        Me.GCGST1.Name = "GCGST1"
        Me.GCGST1.ReadOnly = True
        Me.GCGST1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCGST1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCGST1.Width = 70
        '
        'GSGST1
        '
        Me.GSGST1.HeaderText = "SGST %"
        Me.GSGST1.Name = "GSGST1"
        Me.GSGST1.ReadOnly = True
        Me.GSGST1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSGST1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSGST1.Width = 70
        '
        'GIGST1
        '
        Me.GIGST1.HeaderText = "IGST %"
        Me.GIGST1.Name = "GIGST1"
        Me.GIGST1.ReadOnly = True
        Me.GIGST1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GIGST1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GIGST1.Width = 70
        '
        'GEXPCGST
        '
        Me.GEXPCGST.HeaderText = "Exp CGST %"
        Me.GEXPCGST.Name = "GEXPCGST"
        Me.GEXPCGST.ReadOnly = True
        Me.GEXPCGST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GEXPCGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GEXPCGST.Width = 80
        '
        'GEXPSGST
        '
        Me.GEXPSGST.HeaderText = "Exp SGST %"
        Me.GEXPSGST.Name = "GEXPSGST"
        Me.GEXPSGST.ReadOnly = True
        Me.GEXPSGST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GEXPSGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GEXPSGST.Width = 80
        '
        'GEXPIGST
        '
        Me.GEXPIGST.HeaderText = "Exp IGST %"
        Me.GEXPIGST.Name = "GEXPIGST"
        Me.GEXPIGST.ReadOnly = True
        Me.GEXPIGST.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GEXPIGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GEXPIGST.Width = 80
        '
        'TXTEXPORTIGST
        '
        Me.TXTEXPORTIGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXPORTIGST.Location = New System.Drawing.Point(940, 121)
        Me.TXTEXPORTIGST.Name = "TXTEXPORTIGST"
        Me.TXTEXPORTIGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTEXPORTIGST.TabIndex = 14
        Me.TXTEXPORTIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTEXPORTIGST.Visible = False
        '
        'TXTEXPORTSGST
        '
        Me.TXTEXPORTSGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXPORTSGST.Location = New System.Drawing.Point(940, 92)
        Me.TXTEXPORTSGST.Name = "TXTEXPORTSGST"
        Me.TXTEXPORTSGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTEXPORTSGST.TabIndex = 13
        Me.TXTEXPORTSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTEXPORTSGST.Visible = False
        '
        'TXTEXPORTCGST
        '
        Me.TXTEXPORTCGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXPORTCGST.Location = New System.Drawing.Point(940, 64)
        Me.TXTEXPORTCGST.Name = "TXTEXPORTCGST"
        Me.TXTEXPORTCGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTEXPORTCGST.TabIndex = 12
        Me.TXTEXPORTCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTEXPORTCGST.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(857, 124)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 15)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Export IGST %"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(856, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 15)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Export SGST %"
        Me.Label15.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(855, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 15)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Export CGST %"
        Me.Label16.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(678, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Rate > Then"
        Me.Label9.Visible = False
        '
        'TXTRATE1
        '
        Me.TXTRATE1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE1.Location = New System.Drawing.Point(749, 31)
        Me.TXTRATE1.Name = "TXTRATE1"
        Me.TXTRATE1.Size = New System.Drawing.Size(60, 23)
        Me.TXTRATE1.TabIndex = 8
        Me.TXTRATE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTRATE1.Visible = False
        '
        'TXTIGST1
        '
        Me.TXTIGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTIGST1.Location = New System.Drawing.Point(749, 118)
        Me.TXTIGST1.Name = "TXTIGST1"
        Me.TXTIGST1.Size = New System.Drawing.Size(60, 23)
        Me.TXTIGST1.TabIndex = 11
        Me.TXTIGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTIGST1.Visible = False
        '
        'TXTSGST1
        '
        Me.TXTSGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSGST1.Location = New System.Drawing.Point(749, 89)
        Me.TXTSGST1.Name = "TXTSGST1"
        Me.TXTSGST1.Size = New System.Drawing.Size(60, 23)
        Me.TXTSGST1.TabIndex = 10
        Me.TXTSGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTSGST1.Visible = False
        '
        'TXTCGST1
        '
        Me.TXTCGST1.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCGST1.Location = New System.Drawing.Point(749, 61)
        Me.TXTCGST1.Name = "TXTCGST1"
        Me.TXTCGST1.Size = New System.Drawing.Size(60, 23)
        Me.TXTCGST1.TabIndex = 9
        Me.TXTCGST1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCGST1.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(704, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "IGST %"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(702, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "SGST %"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(701, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 15)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "CGST %"
        Me.Label12.Visible = False
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Location = New System.Drawing.Point(587, 31)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(60, 23)
        Me.TXTRATE.TabIndex = 4
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTRATE.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(516, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Rate > Then"
        Me.Label4.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(606, 541)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 31
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Location = New System.Drawing.Point(520, 541)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 30
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(434, 541)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 29
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(348, 541)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 28
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'TXTIGST
        '
        Me.TXTIGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTIGST.Location = New System.Drawing.Point(587, 118)
        Me.TXTIGST.Name = "TXTIGST"
        Me.TXTIGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTIGST.TabIndex = 7
        Me.TXTIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTIGST.Visible = False
        '
        'TXTSGST
        '
        Me.TXTSGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSGST.Location = New System.Drawing.Point(587, 89)
        Me.TXTSGST.Name = "TXTSGST"
        Me.TXTSGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTSGST.TabIndex = 6
        Me.TXTSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTSGST.Visible = False
        '
        'TXTCGST
        '
        Me.TXTCGST.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCGST.Location = New System.Drawing.Point(587, 60)
        Me.TXTCGST.Name = "TXTCGST"
        Me.TXTCGST.Size = New System.Drawing.Size(60, 23)
        Me.TXTCGST.TabIndex = 5
        Me.TXTCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTCGST.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(542, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "IGST %"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(540, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "SGST %"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(539, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "CGST %"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(67, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Description"
        '
        'TXTDESC
        '
        Me.TXTDESC.BackColor = System.Drawing.Color.White
        Me.TXTDESC.Location = New System.Drawing.Point(139, 114)
        Me.TXTDESC.MaxLength = 500
        Me.TXTDESC.Multiline = True
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(365, 47)
        Me.TXTDESC.TabIndex = 3
        '
        'TXTITEMDESC
        '
        Me.TXTITEMDESC.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTITEMDESC.Location = New System.Drawing.Point(139, 85)
        Me.TXTITEMDESC.MaxLength = 100
        Me.TXTITEMDESC.Name = "TXTITEMDESC"
        Me.TXTITEMDESC.Size = New System.Drawing.Size(365, 23)
        Me.TXTITEMDESC.TabIndex = 2
        '
        'LBLITEMDESC
        '
        Me.LBLITEMDESC.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEMDESC.Location = New System.Drawing.Point(15, 89)
        Me.LBLITEMDESC.Name = "LBLITEMDESC"
        Me.LBLITEMDESC.Size = New System.Drawing.Size(122, 15)
        Me.LBLITEMDESC.TabIndex = 6
        Me.LBLITEMDESC.Text = "Item Description"
        Me.LBLITEMDESC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"Goods", "Services"})
        Me.CMBTYPE.Location = New System.Drawing.Point(139, 27)
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(105, 23)
        Me.CMBTYPE.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(47, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "HSN / SAC Code"
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTHSNCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHSNCODE.Location = New System.Drawing.Point(139, 56)
        Me.TXTHSNCODE.MaxLength = 10
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.Size = New System.Drawing.Size(105, 23)
        Me.TXTHSNCODE.TabIndex = 1
        Me.TXTHSNCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(106, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type"
        '
        'TXTHSNNO
        '
        Me.TXTHSNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTHSNNO.Location = New System.Drawing.Point(303, 3)
        Me.TXTHSNNO.Name = "TXTHSNNO"
        Me.TXTHSNNO.Size = New System.Drawing.Size(105, 23)
        Me.TXTHSNNO.TabIndex = 0
        Me.TXTHSNNO.TabStop = False
        Me.TXTHSNNO.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(257, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "HSN ID"
        Me.Label1.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'HSNMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1035, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "HSNMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HSN Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDHSN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTHSNCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTHSNNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTIGST As System.Windows.Forms.TextBox
    Friend WithEvents TXTSGST As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGST As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents TXTITEMDESC As System.Windows.Forms.TextBox
    Friend WithEvents LBLITEMDESC As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents TXTRATE1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTIGST1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTSGST1 As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGST1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTEXPORTIGST As TextBox
    Friend WithEvents TXTEXPORTSGST As TextBox
    Friend WithEvents TXTEXPORTCGST As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents GRIDHSN As DataGridView
    Friend WithEvents TXTGRIDEXPORTIGST As TextBox
    Friend WithEvents TXTGRIDEXPORTSGST As TextBox
    Friend WithEvents TXTGRIDEXPORTCGST As TextBox
    Friend WithEvents TXTGRIDRATE1 As TextBox
    Friend WithEvents TXTGRIDIGST1 As TextBox
    Friend WithEvents TXTGRIDSGST1 As TextBox
    Friend WithEvents TXTGRIDCGST1 As TextBox
    Friend WithEvents TXTGRIDRATE As TextBox
    Friend WithEvents TXTGRIDIGST As TextBox
    Friend WithEvents TXTGRIDSGST As TextBox
    Friend WithEvents TXTGRIDCGST As TextBox
    Friend WithEvents WEFDATE As MaskedTextBox
    Friend WithEvents GDATE As DataGridViewTextBoxColumn
    Friend WithEvents GRATE As DataGridViewTextBoxColumn
    Friend WithEvents GCGST As DataGridViewTextBoxColumn
    Friend WithEvents GSGST As DataGridViewTextBoxColumn
    Friend WithEvents GIGST As DataGridViewTextBoxColumn
    Friend WithEvents GRATE1 As DataGridViewTextBoxColumn
    Friend WithEvents GCGST1 As DataGridViewTextBoxColumn
    Friend WithEvents GSGST1 As DataGridViewTextBoxColumn
    Friend WithEvents GIGST1 As DataGridViewTextBoxColumn
    Friend WithEvents GEXPCGST As DataGridViewTextBoxColumn
    Friend WithEvents GEXPSGST As DataGridViewTextBoxColumn
    Friend WithEvents GEXPIGST As DataGridViewTextBoxColumn
End Class
