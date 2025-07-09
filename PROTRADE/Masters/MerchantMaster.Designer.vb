<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MerchantMaster
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label
        Me.TXTPCS = New System.Windows.Forms.TextBox
        Me.GRIDSTORE = New System.Windows.Forms.DataGridView
        Me.GSTOREITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPCS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMBSTOREITEMNAME = New System.Windows.Forms.ComboBox
        Me.TXTMTRS = New System.Windows.Forms.TextBox
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox
        Me.GRIDITEM = New System.Windows.Forms.DataGridView
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmddelete = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDSTORE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.GRIDSTORE)
        Me.BlendPanel1.Controls.Add(Me.CMBSTOREITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel1.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.GRIDITEM)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(729, 296)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(155, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 645
        Me.Label1.Text = "Total"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(255, 226)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(70, 14)
        Me.LBLTOTALMTRS.TabIndex = 644
        Me.LBLTOTALMTRS.Text = "0.00"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.White
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.Location = New System.Drawing.Point(573, 65)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(100, 22)
        Me.TXTPCS.TabIndex = 4
        Me.TXTPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDSTORE
        '
        Me.GRIDSTORE.AllowUserToAddRows = False
        Me.GRIDSTORE.AllowUserToDeleteRows = False
        Me.GRIDSTORE.AllowUserToResizeColumns = False
        Me.GRIDSTORE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSTORE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSTORE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSTORE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSTORE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDSTORE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSTORE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSTORE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSTOREITEMNAME, Me.GPCS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSTORE.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDSTORE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDSTORE.Location = New System.Drawing.Point(373, 87)
        Me.GRIDSTORE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDSTORE.MultiSelect = False
        Me.GRIDSTORE.Name = "GRIDSTORE"
        Me.GRIDSTORE.ReadOnly = True
        Me.GRIDSTORE.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSTORE.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDSTORE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSTORE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSTORE.Size = New System.Drawing.Size(335, 135)
        Me.GRIDSTORE.TabIndex = 642
        '
        'GSTOREITEMNAME
        '
        Me.GSTOREITEMNAME.HeaderText = "Store Item Name"
        Me.GSTOREITEMNAME.Name = "GSTOREITEMNAME"
        Me.GSTOREITEMNAME.ReadOnly = True
        Me.GSTOREITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSTOREITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSTOREITEMNAME.Width = 200
        '
        'GPCS
        '
        Me.GPCS.HeaderText = "Pcs"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.ReadOnly = True
        Me.GPCS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPCS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CMBSTOREITEMNAME
        '
        Me.CMBSTOREITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTOREITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTOREITEMNAME.BackColor = System.Drawing.Color.White
        Me.CMBSTOREITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTOREITEMNAME.FormattingEnabled = True
        Me.CMBSTOREITEMNAME.Location = New System.Drawing.Point(373, 65)
        Me.CMBSTOREITEMNAME.MaxDropDownItems = 14
        Me.CMBSTOREITEMNAME.Name = "CMBSTOREITEMNAME"
        Me.CMBSTOREITEMNAME.Size = New System.Drawing.Size(200, 22)
        Me.CMBSTOREITEMNAME.TabIndex = 3
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(225, 65)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(100, 22)
        Me.TXTMTRS.TabIndex = 2
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(102, 26)
        Me.CMBMERCHANT.MaxDropDownItems = 14
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(241, 22)
        Me.CMBMERCHANT.TabIndex = 0
        '
        'GRIDITEM
        '
        Me.GRIDITEM.AllowUserToAddRows = False
        Me.GRIDITEM.AllowUserToDeleteRows = False
        Me.GRIDITEM.AllowUserToResizeColumns = False
        Me.GRIDITEM.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDITEM.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDITEM.BackgroundColor = System.Drawing.Color.White
        Me.GRIDITEM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDITEM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDITEM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDITEM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDITEM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GITEMNAME, Me.GMTRS})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDITEM.DefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDITEM.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDITEM.Location = New System.Drawing.Point(25, 87)
        Me.GRIDITEM.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDITEM.MultiSelect = False
        Me.GRIDITEM.Name = "GRIDITEM"
        Me.GRIDITEM.ReadOnly = True
        Me.GRIDITEM.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDITEM.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDITEM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDITEM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDITEM.Size = New System.Drawing.Size(335, 135)
        Me.GRIDITEM.TabIndex = 638
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "Item Name"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 200
        '
        'GMTRS
        '
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(287, 261)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 6
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(459, 261)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(25, 65)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(200, 22)
        Me.CMBITEMNAME.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Merchant"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(201, 261)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(373, 261)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 7
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'MerchantMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(729, 296)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MerchantMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Merchant Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDSTORE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMBMERCHANT As System.Windows.Forms.ComboBox
    Friend WithEvents GRIDITEM As System.Windows.Forms.DataGridView
    Friend WithEvents TXTMTRS As System.Windows.Forms.TextBox
    Friend WithEvents GITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTPCS As System.Windows.Forms.TextBox
    Friend WithEvents GRIDSTORE As System.Windows.Forms.DataGridView
    Friend WithEvents CMBSTOREITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents GSTOREITEMNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents LBLTOTALMTRS As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
