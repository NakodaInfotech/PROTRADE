<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BeamMaster
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBHSNCODE = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GPGRID = New System.Windows.Forms.GroupBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDBEAM = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GYARNQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSHADE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GENDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GWTPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBGRIDQUALITY = New System.Windows.Forms.ComboBox()
        Me.LBLTOTAL = New System.Windows.Forms.Label()
        Me.TXTGRIDENDS = New System.Windows.Forms.TextBox()
        Me.TXTTOTALWT = New System.Windows.Forms.TextBox()
        Me.TXTTOTALENDS = New System.Windows.Forms.TextBox()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.TXTGRIDWT = New System.Windows.Forms.TextBox()
        Me.GPQUALITY = New System.Windows.Forms.GroupBox()
        Me.LBLYARN = New System.Windows.Forms.Label()
        Me.LBLENDS = New System.Windows.Forms.Label()
        Me.TXTENDS = New System.Windows.Forms.TextBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.LBLWT = New System.Windows.Forms.Label()
        Me.TXTWT = New System.Windows.Forms.TextBox()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTWTTL = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTTL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTBEAMDESC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.GPGRID.SuspendLayout()
        CType(Me.GRIDBEAM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPQUALITY.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBHSNCODE)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.GPGRID)
        Me.BlendPanel1.Controls.Add(Me.GPQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTWTTL)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTTL)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTBEAMDESC)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(641, 446)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBHSNCODE
        '
        Me.CMBHSNCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHSNCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBHSNCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBHSNCODE.FormattingEnabled = True
        Me.CMBHSNCODE.Location = New System.Drawing.Point(118, 46)
        Me.CMBHSNCODE.MaxDropDownItems = 14
        Me.CMBHSNCODE.Name = "CMBHSNCODE"
        Me.CMBHSNCODE.Size = New System.Drawing.Size(73, 23)
        Me.CMBHSNCODE.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(115, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(157, 14)
        Me.Label16.TabIndex = 696
        Me.Label16.Text = "Press 'F1' To Select HSN/SAC"
        '
        'GPGRID
        '
        Me.GPGRID.BackColor = System.Drawing.Color.Transparent
        Me.GPGRID.Controls.Add(Me.TXTSRNO)
        Me.GPGRID.Controls.Add(Me.GRIDBEAM)
        Me.GPGRID.Controls.Add(Me.CMBGRIDQUALITY)
        Me.GPGRID.Controls.Add(Me.LBLTOTAL)
        Me.GPGRID.Controls.Add(Me.TXTGRIDENDS)
        Me.GPGRID.Controls.Add(Me.TXTTOTALWT)
        Me.GPGRID.Controls.Add(Me.TXTTOTALENDS)
        Me.GPGRID.Controls.Add(Me.CMBSHADE)
        Me.GPGRID.Controls.Add(Me.TXTGRIDWT)
        Me.GPGRID.Location = New System.Drawing.Point(20, 181)
        Me.GPGRID.Name = "GPGRID"
        Me.GPGRID.Size = New System.Drawing.Size(601, 217)
        Me.GPGRID.TabIndex = 5
        Me.GPGRID.TabStop = False
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Location = New System.Drawing.Point(4, 10)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'GRIDBEAM
        '
        Me.GRIDBEAM.AllowUserToAddRows = False
        Me.GRIDBEAM.AllowUserToDeleteRows = False
        Me.GRIDBEAM.AllowUserToResizeColumns = False
        Me.GRIDBEAM.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDBEAM.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GRIDBEAM.BackgroundColor = System.Drawing.Color.White
        Me.GRIDBEAM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDBEAM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDBEAM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.GRIDBEAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDBEAM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GYARNQUALITY, Me.GSHADE, Me.GENDS, Me.GWTPER})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDBEAM.DefaultCellStyle = DataGridViewCellStyle17
        Me.GRIDBEAM.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDBEAM.Location = New System.Drawing.Point(3, 33)
        Me.GRIDBEAM.MultiSelect = False
        Me.GRIDBEAM.Name = "GRIDBEAM"
        Me.GRIDBEAM.ReadOnly = True
        Me.GRIDBEAM.RowHeadersVisible = False
        Me.GRIDBEAM.RowHeadersWidth = 30
        Me.GRIDBEAM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDBEAM.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.GRIDBEAM.RowTemplate.Height = 20
        Me.GRIDBEAM.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDBEAM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDBEAM.Size = New System.Drawing.Size(593, 150)
        Me.GRIDBEAM.TabIndex = 4
        Me.GRIDBEAM.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 30
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
        'GSHADE
        '
        Me.GSHADE.HeaderText = "Shade"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.ReadOnly = True
        Me.GSHADE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSHADE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSHADE.Width = 150
        '
        'GENDS
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GENDS.DefaultCellStyle = DataGridViewCellStyle15
        Me.GENDS.HeaderText = "Ends"
        Me.GENDS.Name = "GENDS"
        Me.GENDS.ReadOnly = True
        Me.GENDS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GENDS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GENDS.Width = 80
        '
        'GWTPER
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GWTPER.DefaultCellStyle = DataGridViewCellStyle16
        Me.GWTPER.HeaderText = "Wt/100 Mtrs"
        Me.GWTPER.Name = "GWTPER"
        Me.GWTPER.ReadOnly = True
        Me.GWTPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GWTPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CMBGRIDQUALITY
        '
        Me.CMBGRIDQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGRIDQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGRIDQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBGRIDQUALITY.FormattingEnabled = True
        Me.CMBGRIDQUALITY.Location = New System.Drawing.Point(34, 10)
        Me.CMBGRIDQUALITY.Name = "CMBGRIDQUALITY"
        Me.CMBGRIDQUALITY.Size = New System.Drawing.Size(200, 23)
        Me.CMBGRIDQUALITY.TabIndex = 0
        '
        'LBLTOTAL
        '
        Me.LBLTOTAL.AutoSize = True
        Me.LBLTOTAL.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTAL.Location = New System.Drawing.Point(348, 190)
        Me.LBLTOTAL.Name = "LBLTOTAL"
        Me.LBLTOTAL.Size = New System.Drawing.Size(34, 15)
        Me.LBLTOTAL.TabIndex = 1
        Me.LBLTOTAL.Text = "Total"
        '
        'TXTGRIDENDS
        '
        Me.TXTGRIDENDS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDENDS.Location = New System.Drawing.Point(384, 10)
        Me.TXTGRIDENDS.Name = "TXTGRIDENDS"
        Me.TXTGRIDENDS.Size = New System.Drawing.Size(80, 23)
        Me.TXTGRIDENDS.TabIndex = 2
        Me.TXTGRIDENDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALWT
        '
        Me.TXTTOTALWT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALWT.Location = New System.Drawing.Point(464, 186)
        Me.TXTTOTALWT.Name = "TXTTOTALWT"
        Me.TXTTOTALWT.ReadOnly = True
        Me.TXTTOTALWT.Size = New System.Drawing.Size(100, 23)
        Me.TXTTOTALWT.TabIndex = 3
        Me.TXTTOTALWT.TabStop = False
        Me.TXTTOTALWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTOTALENDS
        '
        Me.TXTTOTALENDS.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALENDS.Location = New System.Drawing.Point(384, 186)
        Me.TXTTOTALENDS.Name = "TXTTOTALENDS"
        Me.TXTTOTALENDS.ReadOnly = True
        Me.TXTTOTALENDS.Size = New System.Drawing.Size(80, 23)
        Me.TXTTOTALENDS.TabIndex = 2
        Me.TXTTOTALENDS.TabStop = False
        Me.TXTTOTALENDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBSHADE
        '
        Me.CMBSHADE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHADE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(234, 10)
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(150, 23)
        Me.CMBSHADE.TabIndex = 1
        '
        'TXTGRIDWT
        '
        Me.TXTGRIDWT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGRIDWT.Location = New System.Drawing.Point(464, 10)
        Me.TXTGRIDWT.Name = "TXTGRIDWT"
        Me.TXTGRIDWT.Size = New System.Drawing.Size(100, 23)
        Me.TXTGRIDWT.TabIndex = 3
        Me.TXTGRIDWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GPQUALITY
        '
        Me.GPQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.GPQUALITY.Controls.Add(Me.LBLYARN)
        Me.GPQUALITY.Controls.Add(Me.LBLENDS)
        Me.GPQUALITY.Controls.Add(Me.TXTENDS)
        Me.GPQUALITY.Controls.Add(Me.CMBQUALITY)
        Me.GPQUALITY.Controls.Add(Me.LBLWT)
        Me.GPQUALITY.Controls.Add(Me.TXTWT)
        Me.GPQUALITY.Location = New System.Drawing.Point(34, 101)
        Me.GPQUALITY.Name = "GPQUALITY"
        Me.GPQUALITY.Size = New System.Drawing.Size(349, 74)
        Me.GPQUALITY.TabIndex = 4
        Me.GPQUALITY.TabStop = False
        Me.GPQUALITY.Visible = False
        '
        'LBLYARN
        '
        Me.LBLYARN.AutoSize = True
        Me.LBLYARN.BackColor = System.Drawing.Color.Transparent
        Me.LBLYARN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLYARN.Location = New System.Drawing.Point(8, 18)
        Me.LBLYARN.Name = "LBLYARN"
        Me.LBLYARN.Size = New System.Drawing.Size(75, 15)
        Me.LBLYARN.TabIndex = 0
        Me.LBLYARN.Text = "Yarn Quality"
        '
        'LBLENDS
        '
        Me.LBLENDS.AutoSize = True
        Me.LBLENDS.BackColor = System.Drawing.Color.Transparent
        Me.LBLENDS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLENDS.Location = New System.Drawing.Point(50, 48)
        Me.LBLENDS.Name = "LBLENDS"
        Me.LBLENDS.Size = New System.Drawing.Size(33, 15)
        Me.LBLENDS.TabIndex = 1
        Me.LBLENDS.Text = "Ends"
        '
        'TXTENDS
        '
        Me.TXTENDS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTENDS.Location = New System.Drawing.Point(84, 44)
        Me.TXTENDS.Name = "TXTENDS"
        Me.TXTENDS.Size = New System.Drawing.Size(46, 23)
        Me.TXTENDS.TabIndex = 1
        Me.TXTENDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(84, 15)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(255, 23)
        Me.CMBQUALITY.TabIndex = 0
        '
        'LBLWT
        '
        Me.LBLWT.AutoSize = True
        Me.LBLWT.BackColor = System.Drawing.Color.Transparent
        Me.LBLWT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWT.Location = New System.Drawing.Point(208, 48)
        Me.LBLWT.Name = "LBLWT"
        Me.LBLWT.Size = New System.Drawing.Size(84, 15)
        Me.LBLWT.TabIndex = 2
        Me.LBLWT.Text = "Wt./100 Mtrs."
        '
        'TXTWT
        '
        Me.TXTWT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWT.Location = New System.Drawing.Point(293, 44)
        Me.TXTWT.Name = "TXTWT"
        Me.TXTWT.Size = New System.Drawing.Size(46, 23)
        Me.TXTWT.TabIndex = 2
        Me.TXTWT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Location = New System.Drawing.Point(237, 406)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 9
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "HSN / SAC Code"
        '
        'TXTWTTL
        '
        Me.TXTWTTL.BackColor = System.Drawing.Color.White
        Me.TXTWTTL.Location = New System.Drawing.Point(327, 46)
        Me.TXTWTTL.Name = "TXTWTTL"
        Me.TXTWTTL.Size = New System.Drawing.Size(46, 23)
        Me.TXTWTTL.TabIndex = 3
        Me.TXTWTTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(284, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Wt./TL"
        '
        'TXTTL
        '
        Me.TXTTL.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTTL.Location = New System.Drawing.Point(224, 46)
        Me.TXTTL.Name = "TXTTL"
        Me.TXTTL.Size = New System.Drawing.Size(46, 23)
        Me.TXTTL.TabIndex = 2
        Me.TXTTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(204, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "TL"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(323, 406)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 10
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(151, 406)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(409, 406)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 11
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTBEAMDESC
        '
        Me.TXTBEAMDESC.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTBEAMDESC.Location = New System.Drawing.Point(118, 17)
        Me.TXTBEAMDESC.Name = "TXTBEAMDESC"
        Me.TXTBEAMDESC.Size = New System.Drawing.Size(255, 23)
        Me.TXTBEAMDESC.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(46, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Beam Name"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'BeamMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(641, 446)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BeamMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Beam Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPGRID.ResumeLayout(False)
        Me.GPGRID.PerformLayout()
        CType(Me.GRIDBEAM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPQUALITY.ResumeLayout(False)
        Me.GPQUALITY.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTBEAMDESC As System.Windows.Forms.TextBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTTL As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTENDS As System.Windows.Forms.TextBox
    Friend WithEvents LBLENDS As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents LBLYARN As System.Windows.Forms.Label
    Friend WithEvents TXTWT As System.Windows.Forms.TextBox
    Friend WithEvents LBLWT As System.Windows.Forms.Label
    Friend WithEvents TXTWTTL As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTGRIDWT As TextBox
    Friend WithEvents CMBSHADE As ComboBox
    Friend WithEvents TXTGRIDENDS As TextBox
    Friend WithEvents CMBGRIDQUALITY As ComboBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents GRIDBEAM As DataGridView
    Friend WithEvents LBLTOTAL As Label
    Friend WithEvents TXTTOTALWT As TextBox
    Friend WithEvents TXTTOTALENDS As TextBox
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents GPGRID As GroupBox
    Friend WithEvents GPQUALITY As GroupBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GYARNQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents GSHADE As DataGridViewTextBoxColumn
    Friend WithEvents GENDS As DataGridViewTextBoxColumn
    Friend WithEvents GWTPER As DataGridViewTextBoxColumn
    Friend WithEvents Label16 As Label
    Friend WithEvents CMBHSNCODE As ComboBox
End Class
