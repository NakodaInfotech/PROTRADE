<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectStockGDN
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridwo = New System.Windows.Forms.DataGridView()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTCUT = New System.Windows.Forms.TextBox()
        Me.TXTPCS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.LBLTOTALMTRS = New System.Windows.Forms.Label()
        Me.LBLTOTALPCS = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LBLBALENO = New System.Windows.Forms.Label()
        Me.CMBBALENO = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBLOTNO = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.LBLITEM = New System.Windows.Forms.Label()
        Me.CHKItem = New System.Windows.Forms.CheckBox()
        Me.CLB_Item = New System.Windows.Forms.CheckedListBox()
        Me.LBLNEWSHADE = New System.Windows.Forms.Label()
        Me.LBLNEWDESIGN = New System.Windows.Forms.Label()
        Me.LBLNEWQUALITY = New System.Windows.Forms.Label()
        Me.CMBSHADE = New System.Windows.Forms.ComboBox()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.CHKShade = New System.Windows.Forms.CheckBox()
        Me.LBLSHADE = New System.Windows.Forms.Label()
        Me.CLB_Shade = New System.Windows.Forms.CheckedListBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.CMDCLEARSEARCH = New System.Windows.Forms.Button()
        Me.CMDSEARCH = New System.Windows.Forms.Button()
        Me.chkDesign = New System.Windows.Forms.CheckBox()
        Me.LBLDESIGN = New System.Windows.Forms.Label()
        Me.CLB_Design = New System.Windows.Forms.CheckedListBox()
        Me.chkQuality = New System.Windows.Forms.CheckBox()
        Me.LBLQUALITY = New System.Windows.Forms.Label()
        Me.CLB_Quality = New System.Windows.Forms.CheckedListBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmbselect = New System.Windows.Forms.ComboBox()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        CType(Me.gridwo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(757, 21)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(71, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select Stock"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 629)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 15
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridwo
        '
        Me.gridwo.AllowUserToAddRows = False
        Me.gridwo.AllowUserToDeleteRows = False
        Me.gridwo.AllowUserToResizeColumns = False
        Me.gridwo.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridwo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridwo.BackgroundColor = System.Drawing.Color.White
        Me.gridwo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridwo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridwo.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridwo.GridColor = System.Drawing.SystemColors.Control
        Me.gridwo.Location = New System.Drawing.Point(17, 168)
        Me.gridwo.Margin = New System.Windows.Forms.Padding(2)
        Me.gridwo.MultiSelect = False
        Me.gridwo.Name = "gridwo"
        Me.gridwo.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridwo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridwo.RowHeadersVisible = False
        Me.gridwo.RowHeadersWidth = 30
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.gridwo.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridwo.RowTemplate.Height = 20
        Me.gridwo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridwo.Size = New System.Drawing.Size(1207, 456)
        Me.gridwo.TabIndex = 14
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTCUT)
        Me.BlendPanel1.Controls.Add(Me.TXTPCS)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBUNIT)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.LBLTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.LBLBALENO)
        Me.BlendPanel1.Controls.Add(Me.CMBBALENO)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBPIECETYPE)
        Me.BlendPanel1.Controls.Add(Me.LBLITEM)
        Me.BlendPanel1.Controls.Add(Me.CHKItem)
        Me.BlendPanel1.Controls.Add(Me.CLB_Item)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWSHADE)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWDESIGN)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CHKShade)
        Me.BlendPanel1.Controls.Add(Me.LBLSHADE)
        Me.BlendPanel1.Controls.Add(Me.CLB_Shade)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEARSEARCH)
        Me.BlendPanel1.Controls.Add(Me.CMDSEARCH)
        Me.BlendPanel1.Controls.Add(Me.chkDesign)
        Me.BlendPanel1.Controls.Add(Me.LBLDESIGN)
        Me.BlendPanel1.Controls.Add(Me.CLB_Design)
        Me.BlendPanel1.Controls.Add(Me.chkQuality)
        Me.BlendPanel1.Controls.Add(Me.LBLQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CLB_Quality)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmbselect)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridwo)
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Controls.Add(Me.txtsearch)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 661)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(806, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 14)
        Me.Label11.TabIndex = 729
        Me.Label11.Text = "Barcode"
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBARCODE.Location = New System.Drawing.Point(859, 83)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(195, 23)
        Me.TXTBARCODE.TabIndex = 728
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(1156, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 14)
        Me.Label6.TabIndex = 560
        Me.Label6.Text = "Cut"
        '
        'TXTCUT
        '
        Me.TXTCUT.BackColor = System.Drawing.Color.White
        Me.TXTCUT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUT.Location = New System.Drawing.Point(1156, 134)
        Me.TXTCUT.Name = "TXTCUT"
        Me.TXTCUT.Size = New System.Drawing.Size(50, 22)
        Me.TXTCUT.TabIndex = 559
        Me.TXTCUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPCS
        '
        Me.TXTPCS.BackColor = System.Drawing.Color.White
        Me.TXTPCS.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPCS.ForeColor = System.Drawing.Color.Black
        Me.TXTPCS.Location = New System.Drawing.Point(991, 11)
        Me.TXTPCS.Name = "TXTPCS"
        Me.TXTPCS.Size = New System.Drawing.Size(80, 21)
        Me.TXTPCS.TabIndex = 558
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(1054, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 14)
        Me.Label5.TabIndex = 557
        Me.Label5.Text = "Unit"
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(1057, 135)
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(93, 21)
        Me.CMBUNIT.TabIndex = 556
        '
        'LBLTOTALMTRS
        '
        Me.LBLTOTALMTRS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALMTRS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLTOTALMTRS.Location = New System.Drawing.Point(1013, 632)
        Me.LBLTOTALMTRS.Name = "LBLTOTALMTRS"
        Me.LBLTOTALMTRS.Size = New System.Drawing.Size(86, 14)
        Me.LBLTOTALMTRS.TabIndex = 555
        Me.LBLTOTALMTRS.Text = "0"
        Me.LBLTOTALMTRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLTOTALPCS
        '
        Me.LBLTOTALPCS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTALPCS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLTOTALPCS.Location = New System.Drawing.Point(964, 632)
        Me.LBLTOTALPCS.Name = "LBLTOTALPCS"
        Me.LBLTOTALPCS.Size = New System.Drawing.Size(43, 14)
        Me.LBLTOTALPCS.TabIndex = 554
        Me.LBLTOTALPCS.Text = "0"
        Me.LBLTOTALPCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(915, 632)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 14)
        Me.Label4.TabIndex = 553
        Me.Label4.Text = "Total : "
        '
        'LBLBALENO
        '
        Me.LBLBALENO.AutoSize = True
        Me.LBLBALENO.BackColor = System.Drawing.Color.Transparent
        Me.LBLBALENO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBALENO.ForeColor = System.Drawing.Color.Red
        Me.LBLBALENO.Location = New System.Drawing.Point(955, 118)
        Me.LBLBALENO.Name = "LBLBALENO"
        Me.LBLBALENO.Size = New System.Drawing.Size(50, 14)
        Me.LBLBALENO.TabIndex = 552
        Me.LBLBALENO.Text = "Bale No"
        '
        'CMBBALENO
        '
        Me.CMBBALENO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBALENO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBALENO.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBALENO.FormattingEnabled = True
        Me.CMBBALENO.Location = New System.Drawing.Point(958, 135)
        Me.CMBBALENO.Name = "CMBBALENO"
        Me.CMBBALENO.Size = New System.Drawing.Size(93, 21)
        Me.CMBBALENO.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(856, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 550
        Me.Label2.Text = "Lot No"
        '
        'CMBLOTNO
        '
        Me.CMBLOTNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLOTNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLOTNO.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLOTNO.FormattingEnabled = True
        Me.CMBLOTNO.Location = New System.Drawing.Point(859, 135)
        Me.CMBLOTNO.Name = "CMBLOTNO"
        Me.CMBLOTNO.Size = New System.Drawing.Size(93, 21)
        Me.CMBLOTNO.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(760, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 548
        Me.Label1.Text = "Piece Type"
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(760, 135)
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(93, 21)
        Me.CMBPIECETYPE.TabIndex = 9
        '
        'LBLITEM
        '
        Me.LBLITEM.AutoSize = True
        Me.LBLITEM.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLITEM.ForeColor = System.Drawing.Color.Red
        Me.LBLITEM.Location = New System.Drawing.Point(502, 12)
        Me.LBLITEM.Name = "LBLITEM"
        Me.LBLITEM.Size = New System.Drawing.Size(31, 15)
        Me.LBLITEM.TabIndex = 546
        Me.LBLITEM.Text = "Item"
        Me.LBLITEM.Visible = False
        '
        'CHKItem
        '
        Me.CHKItem.AutoSize = True
        Me.CHKItem.BackColor = System.Drawing.Color.Transparent
        Me.CHKItem.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKItem.Location = New System.Drawing.Point(502, 30)
        Me.CHKItem.Name = "CHKItem"
        Me.CHKItem.Size = New System.Drawing.Size(76, 19)
        Me.CHKItem.TabIndex = 545
        Me.CHKItem.TabStop = False
        Me.CHKItem.Text = "Select All"
        Me.CHKItem.UseVisualStyleBackColor = False
        Me.CHKItem.Visible = False
        '
        'CLB_Item
        '
        Me.CLB_Item.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_Item.FormattingEnabled = True
        Me.CLB_Item.Location = New System.Drawing.Point(502, 50)
        Me.CLB_Item.Name = "CLB_Item"
        Me.CLB_Item.ScrollAlwaysVisible = True
        Me.CLB_Item.Size = New System.Drawing.Size(247, 106)
        Me.CLB_Item.TabIndex = 5
        Me.CLB_Item.TabStop = False
        Me.CLB_Item.Visible = False
        '
        'LBLNEWSHADE
        '
        Me.LBLNEWSHADE.AutoSize = True
        Me.LBLNEWSHADE.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWSHADE.ForeColor = System.Drawing.Color.Red
        Me.LBLNEWSHADE.Location = New System.Drawing.Point(712, 182)
        Me.LBLNEWSHADE.Name = "LBLNEWSHADE"
        Me.LBLNEWSHADE.Size = New System.Drawing.Size(41, 14)
        Me.LBLNEWSHADE.TabIndex = 543
        Me.LBLNEWSHADE.Text = "Shade"
        Me.LBLNEWSHADE.Visible = False
        '
        'LBLNEWDESIGN
        '
        Me.LBLNEWDESIGN.AutoSize = True
        Me.LBLNEWDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWDESIGN.ForeColor = System.Drawing.Color.Red
        Me.LBLNEWDESIGN.Location = New System.Drawing.Point(595, 182)
        Me.LBLNEWDESIGN.Name = "LBLNEWDESIGN"
        Me.LBLNEWDESIGN.Size = New System.Drawing.Size(45, 14)
        Me.LBLNEWDESIGN.TabIndex = 542
        Me.LBLNEWDESIGN.Text = "Design"
        Me.LBLNEWDESIGN.Visible = False
        '
        'LBLNEWQUALITY
        '
        Me.LBLNEWQUALITY.AutoSize = True
        Me.LBLNEWQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWQUALITY.ForeColor = System.Drawing.Color.Red
        Me.LBLNEWQUALITY.Location = New System.Drawing.Point(450, 182)
        Me.LBLNEWQUALITY.Name = "LBLNEWQUALITY"
        Me.LBLNEWQUALITY.Size = New System.Drawing.Size(46, 14)
        Me.LBLNEWQUALITY.TabIndex = 541
        Me.LBLNEWQUALITY.Text = "Quality"
        Me.LBLNEWQUALITY.Visible = False
        '
        'CMBSHADE
        '
        Me.CMBSHADE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Items.AddRange(New Object() {"", "Quality", "Design", "Shade"})
        Me.CMBSHADE.Location = New System.Drawing.Point(711, 199)
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(107, 21)
        Me.CMBSHADE.TabIndex = 8
        Me.CMBSHADE.Visible = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Items.AddRange(New Object() {"", "Quality", "Design", "Shade"})
        Me.CMBDESIGN.Location = New System.Drawing.Point(595, 199)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(110, 21)
        Me.CMBDESIGN.TabIndex = 7
        Me.CMBDESIGN.Visible = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Items.AddRange(New Object() {"", "Quality", "Design", "Shade"})
        Me.CMBQUALITY.Location = New System.Drawing.Point(450, 199)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(139, 21)
        Me.CMBQUALITY.TabIndex = 6
        Me.CMBQUALITY.Visible = False
        '
        'CHKShade
        '
        Me.CHKShade.AutoSize = True
        Me.CHKShade.BackColor = System.Drawing.Color.Transparent
        Me.CHKShade.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKShade.Location = New System.Drawing.Point(388, 30)
        Me.CHKShade.Name = "CHKShade"
        Me.CHKShade.Size = New System.Drawing.Size(76, 19)
        Me.CHKShade.TabIndex = 535
        Me.CHKShade.TabStop = False
        Me.CHKShade.Text = "Select All"
        Me.CHKShade.UseVisualStyleBackColor = False
        '
        'LBLSHADE
        '
        Me.LBLSHADE.AutoSize = True
        Me.LBLSHADE.BackColor = System.Drawing.Color.Transparent
        Me.LBLSHADE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSHADE.ForeColor = System.Drawing.Color.Red
        Me.LBLSHADE.Location = New System.Drawing.Point(388, 12)
        Me.LBLSHADE.Name = "LBLSHADE"
        Me.LBLSHADE.Size = New System.Drawing.Size(40, 15)
        Me.LBLSHADE.TabIndex = 537
        Me.LBLSHADE.Text = "Shade"
        '
        'CLB_Shade
        '
        Me.CLB_Shade.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_Shade.FormattingEnabled = True
        Me.CLB_Shade.Location = New System.Drawing.Point(388, 50)
        Me.CLB_Shade.Name = "CLB_Shade"
        Me.CLB_Shade.ScrollAlwaysVisible = True
        Me.CLB_Shade.Size = New System.Drawing.Size(108, 106)
        Me.CLB_Shade.TabIndex = 4
        Me.CLB_Shade.TabStop = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(908, 15)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(77, 18)
        Me.chkall.TabIndex = 13
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'CMDCLEARSEARCH
        '
        Me.CMDCLEARSEARCH.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEARSEARCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEARSEARCH.FlatAppearance.BorderSize = 0
        Me.CMDCLEARSEARCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEARSEARCH.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEARSEARCH.Location = New System.Drawing.Point(1077, 33)
        Me.CMDCLEARSEARCH.Name = "CMDCLEARSEARCH"
        Me.CMDCLEARSEARCH.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEARSEARCH.TabIndex = 3
        Me.CMDCLEARSEARCH.TabStop = False
        Me.CMDCLEARSEARCH.Text = "&Clear"
        Me.CMDCLEARSEARCH.UseVisualStyleBackColor = False
        '
        'CMDSEARCH
        '
        Me.CMDSEARCH.BackColor = System.Drawing.Color.Transparent
        Me.CMDSEARCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSEARCH.FlatAppearance.BorderSize = 0
        Me.CMDSEARCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSEARCH.ForeColor = System.Drawing.Color.Black
        Me.CMDSEARCH.Location = New System.Drawing.Point(991, 33)
        Me.CMDSEARCH.Name = "CMDSEARCH"
        Me.CMDSEARCH.Size = New System.Drawing.Size(80, 28)
        Me.CMDSEARCH.TabIndex = 12
        Me.CMDSEARCH.Text = "&Search"
        Me.CMDSEARCH.UseVisualStyleBackColor = False
        '
        'chkDesign
        '
        Me.chkDesign.AutoSize = True
        Me.chkDesign.BackColor = System.Drawing.Color.Transparent
        Me.chkDesign.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDesign.Location = New System.Drawing.Point(274, 30)
        Me.chkDesign.Name = "chkDesign"
        Me.chkDesign.Size = New System.Drawing.Size(76, 19)
        Me.chkDesign.TabIndex = 524
        Me.chkDesign.TabStop = False
        Me.chkDesign.Text = "Select All"
        Me.chkDesign.UseVisualStyleBackColor = False
        '
        'LBLDESIGN
        '
        Me.LBLDESIGN.AutoSize = True
        Me.LBLDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.LBLDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDESIGN.ForeColor = System.Drawing.Color.Red
        Me.LBLDESIGN.Location = New System.Drawing.Point(274, 12)
        Me.LBLDESIGN.Name = "LBLDESIGN"
        Me.LBLDESIGN.Size = New System.Drawing.Size(44, 15)
        Me.LBLDESIGN.TabIndex = 533
        Me.LBLDESIGN.Text = "Design"
        '
        'CLB_Design
        '
        Me.CLB_Design.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_Design.FormattingEnabled = True
        Me.CLB_Design.Location = New System.Drawing.Point(274, 50)
        Me.CLB_Design.Name = "CLB_Design"
        Me.CLB_Design.ScrollAlwaysVisible = True
        Me.CLB_Design.Size = New System.Drawing.Size(108, 106)
        Me.CLB_Design.TabIndex = 3
        Me.CLB_Design.TabStop = False
        '
        'chkQuality
        '
        Me.chkQuality.AutoSize = True
        Me.chkQuality.BackColor = System.Drawing.Color.Transparent
        Me.chkQuality.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkQuality.Location = New System.Drawing.Point(21, 30)
        Me.chkQuality.Name = "chkQuality"
        Me.chkQuality.Size = New System.Drawing.Size(76, 19)
        Me.chkQuality.TabIndex = 523
        Me.chkQuality.TabStop = False
        Me.chkQuality.Text = "Select All"
        Me.chkQuality.UseVisualStyleBackColor = False
        '
        'LBLQUALITY
        '
        Me.LBLQUALITY.AutoSize = True
        Me.LBLQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.LBLQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLQUALITY.ForeColor = System.Drawing.Color.Red
        Me.LBLQUALITY.Location = New System.Drawing.Point(21, 12)
        Me.LBLQUALITY.Name = "LBLQUALITY"
        Me.LBLQUALITY.Size = New System.Drawing.Size(48, 15)
        Me.LBLQUALITY.TabIndex = 532
        Me.LBLQUALITY.Text = "Quality"
        '
        'CLB_Quality
        '
        Me.CLB_Quality.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_Quality.FormattingEnabled = True
        Me.CLB_Quality.Location = New System.Drawing.Point(21, 50)
        Me.CLB_Quality.Name = "CLB_Quality"
        Me.CLB_Quality.ScrollAlwaysVisible = True
        Me.CLB_Quality.Size = New System.Drawing.Size(247, 106)
        Me.CLB_Quality.TabIndex = 2
        Me.CLB_Quality.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 629)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 16
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"", "Item", "Quality", "Design", "Shade"})
        Me.cmbselect.Location = New System.Drawing.Point(760, 39)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(72, 21)
        Me.cmbselect.TabIndex = 0
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(554, -3)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(137, 20)
        Me.txttempname.TabIndex = 254
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.White
        Me.txtsearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.Black
        Me.txtsearch.Location = New System.Drawing.Point(832, 39)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(153, 21)
        Me.txtsearch.TabIndex = 1
        '
        'SelectStockGDN
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 661)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectStockGDN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridwo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents gridwo As System.Windows.Forms.DataGridView
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents CHKShade As System.Windows.Forms.CheckBox
    Friend WithEvents LBLSHADE As System.Windows.Forms.Label
    Friend WithEvents CLB_Shade As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents CMDCLEARSEARCH As System.Windows.Forms.Button
    Friend WithEvents CMDSEARCH As System.Windows.Forms.Button
    Friend WithEvents chkDesign As System.Windows.Forms.CheckBox
    Friend WithEvents LBLDESIGN As System.Windows.Forms.Label
    Friend WithEvents CLB_Design As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkQuality As System.Windows.Forms.CheckBox
    Friend WithEvents LBLQUALITY As System.Windows.Forms.Label
    Friend WithEvents CLB_Quality As System.Windows.Forms.CheckedListBox
    Friend WithEvents LBLNEWSHADE As System.Windows.Forms.Label
    Friend WithEvents LBLNEWDESIGN As System.Windows.Forms.Label
    Friend WithEvents LBLNEWQUALITY As System.Windows.Forms.Label
    Private WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Private WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Private WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents LBLITEM As System.Windows.Forms.Label
    Friend WithEvents CHKItem As System.Windows.Forms.CheckBox
    Friend WithEvents CLB_Item As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents CMBPIECETYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents CMBLOTNO As System.Windows.Forms.ComboBox
    Friend WithEvents LBLBALENO As Label
    Private WithEvents CMBBALENO As ComboBox
    Friend WithEvents LBLTOTALMTRS As Label
    Friend WithEvents LBLTOTALPCS As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Private WithEvents CMBUNIT As ComboBox
    Friend WithEvents TXTPCS As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTCUT As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTBARCODE As TextBox
End Class
