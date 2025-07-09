<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SampleNote
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleNote))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.LBLDOCKETNO = New System.Windows.Forms.Label()
        Me.TXTDOCKETNO = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLDELETE = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPREVIOUS = New System.Windows.Forms.ToolStripButton()
        Me.Toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SODATE = New System.Windows.Forms.MaskedTextBox()
        Me.SMPDATE = New System.Windows.Forms.MaskedTextBox()
        Me.CMDSELECTSO = New System.Windows.Forms.Button()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdEXIT = New System.Windows.Forms.Button()
        Me.CMBSHIPTO = New System.Windows.Forms.ComboBox()
        Me.CMBPARTYNAME = New System.Windows.Forms.ComboBox()
        Me.TXTSONO = New System.Windows.Forms.TextBox()
        Me.TXTMODEOFSHIPMENT = New System.Windows.Forms.TextBox()
        Me.TXTSMPNO = New System.Windows.Forms.TextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tbitem = New System.Windows.Forms.TabPage()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.TXTGRIDREMARKS = New System.Windows.Forms.TextBox()
        Me.GRIDSMP = New System.Windows.Forms.DataGridView()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.LBLMODEOFSHIPMENT = New System.Windows.Forms.Label()
        Me.LBLDATE = New System.Windows.Forms.Label()
        Me.LBLSRNO = New System.Windows.Forms.Label()
        Me.LBLSODATE = New System.Windows.Forms.Label()
        Me.LBLSONO = New System.Windows.Forms.Label()
        Me.lblShipTo = New System.Windows.Forms.Label()
        Me.lblpartyname = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GGRIDREMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GSOSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbitem.SuspendLayout()
        CType(Me.GRIDSMP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.LBLDOCKETNO)
        Me.BlendPanel1.Controls.Add(Me.TXTDOCKETNO)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.SODATE)
        Me.BlendPanel1.Controls.Add(Me.SMPDATE)
        Me.BlendPanel1.Controls.Add(Me.CMDSELECTSO)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdOK)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMBSHIPTO)
        Me.BlendPanel1.Controls.Add(Me.CMBPARTYNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTSONO)
        Me.BlendPanel1.Controls.Add(Me.TXTMODEOFSHIPMENT)
        Me.BlendPanel1.Controls.Add(Me.TXTSMPNO)
        Me.BlendPanel1.Controls.Add(Me.TabControl2)
        Me.BlendPanel1.Controls.Add(Me.LBLMODEOFSHIPMENT)
        Me.BlendPanel1.Controls.Add(Me.LBLDATE)
        Me.BlendPanel1.Controls.Add(Me.LBLSRNO)
        Me.BlendPanel1.Controls.Add(Me.LBLSODATE)
        Me.BlendPanel1.Controls.Add(Me.LBLSONO)
        Me.BlendPanel1.Controls.Add(Me.lblShipTo)
        Me.BlendPanel1.Controls.Add(Me.lblpartyname)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(868, 520)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(449, 99)
        Me.TXTADD.MaxLength = 100
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(75, 23)
        Me.TXTADD.TabIndex = 739
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(449, 69)
        Me.CMBCODE.MaxLength = 100
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(75, 23)
        Me.CMBCODE.TabIndex = 738
        Me.CMBCODE.Visible = False
        '
        'LBLDOCKETNO
        '
        Me.LBLDOCKETNO.AutoSize = True
        Me.LBLDOCKETNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLDOCKETNO.Location = New System.Drawing.Point(616, 130)
        Me.LBLDOCKETNO.Name = "LBLDOCKETNO"
        Me.LBLDOCKETNO.Size = New System.Drawing.Size(62, 15)
        Me.LBLDOCKETNO.TabIndex = 737
        Me.LBLDOCKETNO.Text = "Docket No"
        '
        'TXTDOCKETNO
        '
        Me.TXTDOCKETNO.Location = New System.Drawing.Point(680, 127)
        Me.TXTDOCKETNO.MaxLength = 50
        Me.TXTDOCKETNO.Name = "TXTDOCKETNO"
        Me.TXTDOCKETNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTDOCKETNO.TabIndex = 5
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(25, 375)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(236, 107)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 16)
        Me.txtremarks.MaxLength = 200
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(225, 85)
        Me.txtremarks.TabIndex = 0
        Me.txtremarks.TabStop = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(243, 2)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(61, 22)
        Me.tstxtbillno.TabIndex = 12
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.TOOLDELETE, Me.ToolStripSeparator2, Me.ToolPREVIOUS, Me.Toolnext, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(868, 25)
        Me.ToolStrip1.TabIndex = 32
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
        'ToolPREVIOUS
        '
        Me.ToolPREVIOUS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolPREVIOUS.Image = CType(resources.GetObject("ToolPREVIOUS.Image"), System.Drawing.Image)
        Me.ToolPREVIOUS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPREVIOUS.Name = "ToolPREVIOUS"
        Me.ToolPREVIOUS.Size = New System.Drawing.Size(73, 22)
        Me.ToolPREVIOUS.Text = "Previous"
        '
        'Toolnext
        '
        Me.Toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Toolnext.Image = CType(resources.GetObject("Toolnext.Image"), System.Drawing.Image)
        Me.Toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolnext.Name = "Toolnext"
        Me.Toolnext.Size = New System.Drawing.Size(51, 22)
        Me.Toolnext.Text = "Next"
        Me.Toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'SODATE
        '
        Me.SODATE.AsciiOnly = True
        Me.SODATE.BackColor = System.Drawing.Color.Linen
        Me.SODATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.SODATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.SODATE.Location = New System.Drawing.Point(285, 69)
        Me.SODATE.Mask = "00/00/0000"
        Me.SODATE.Name = "SODATE"
        Me.SODATE.ReadOnly = True
        Me.SODATE.Size = New System.Drawing.Size(88, 23)
        Me.SODATE.TabIndex = 31
        Me.SODATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.SODATE.ValidatingType = GetType(Date)
        '
        'SMPDATE
        '
        Me.SMPDATE.AsciiOnly = True
        Me.SMPDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.SMPDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.SMPDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.SMPDATE.Location = New System.Drawing.Point(680, 69)
        Me.SMPDATE.Mask = "00/00/0000"
        Me.SMPDATE.Name = "SMPDATE"
        Me.SMPDATE.Size = New System.Drawing.Size(88, 23)
        Me.SMPDATE.TabIndex = 0
        Me.SMPDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.SMPDATE.ValidatingType = GetType(Date)
        '
        'CMDSELECTSO
        '
        Me.CMDSELECTSO.Location = New System.Drawing.Point(309, 391)
        Me.CMDSELECTSO.Name = "CMDSELECTSO"
        Me.CMDSELECTSO.Size = New System.Drawing.Size(80, 28)
        Me.CMDSELECTSO.TabIndex = 2
        Me.CMDSELECTSO.Text = "&Select  SO"
        Me.CMDSELECTSO.UseVisualStyleBackColor = True
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(358, 425)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 10
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.Transparent
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOK.FlatAppearance.BorderSize = 0
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.Black
        Me.cmdOK.Location = New System.Drawing.Point(393, 391)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 28)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "&Save"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(479, 391)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 9
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdEXIT
        '
        Me.cmdEXIT.BackColor = System.Drawing.Color.Transparent
        Me.cmdEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEXIT.FlatAppearance.BorderSize = 0
        Me.cmdEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEXIT.ForeColor = System.Drawing.Color.Black
        Me.cmdEXIT.Location = New System.Drawing.Point(444, 425)
        Me.cmdEXIT.Name = "cmdEXIT"
        Me.cmdEXIT.Size = New System.Drawing.Size(80, 28)
        Me.cmdEXIT.TabIndex = 11
        Me.cmdEXIT.Text = "E&xit"
        Me.cmdEXIT.UseVisualStyleBackColor = False
        '
        'CMBSHIPTO
        '
        Me.CMBSHIPTO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHIPTO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHIPTO.FormattingEnabled = True
        Me.CMBSHIPTO.Location = New System.Drawing.Point(680, 98)
        Me.CMBSHIPTO.MaxLength = 100
        Me.CMBSHIPTO.Name = "CMBSHIPTO"
        Me.CMBSHIPTO.Size = New System.Drawing.Size(161, 23)
        Me.CMBSHIPTO.TabIndex = 4
        '
        'CMBPARTYNAME
        '
        Me.CMBPARTYNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPARTYNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPARTYNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPARTYNAME.FormattingEnabled = True
        Me.CMBPARTYNAME.Location = New System.Drawing.Point(133, 40)
        Me.CMBPARTYNAME.MaxLength = 100
        Me.CMBPARTYNAME.Name = "CMBPARTYNAME"
        Me.CMBPARTYNAME.Size = New System.Drawing.Size(240, 23)
        Me.CMBPARTYNAME.TabIndex = 1
        '
        'TXTSONO
        '
        Me.TXTSONO.BackColor = System.Drawing.Color.Linen
        Me.TXTSONO.Location = New System.Drawing.Point(133, 69)
        Me.TXTSONO.Name = "TXTSONO"
        Me.TXTSONO.ReadOnly = True
        Me.TXTSONO.Size = New System.Drawing.Size(88, 23)
        Me.TXTSONO.TabIndex = 22
        '
        'TXTMODEOFSHIPMENT
        '
        Me.TXTMODEOFSHIPMENT.Location = New System.Drawing.Point(133, 98)
        Me.TXTMODEOFSHIPMENT.MaxLength = 100
        Me.TXTMODEOFSHIPMENT.Name = "TXTMODEOFSHIPMENT"
        Me.TXTMODEOFSHIPMENT.Size = New System.Drawing.Size(240, 23)
        Me.TXTMODEOFSHIPMENT.TabIndex = 3
        '
        'TXTSMPNO
        '
        Me.TXTSMPNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSMPNO.Location = New System.Drawing.Point(680, 40)
        Me.TXTSMPNO.Name = "TXTSMPNO"
        Me.TXTSMPNO.ReadOnly = True
        Me.TXTSMPNO.Size = New System.Drawing.Size(88, 23)
        Me.TXTSMPNO.TabIndex = 18
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tbitem)
        Me.TabControl2.Location = New System.Drawing.Point(18, 146)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(832, 223)
        Me.TabControl2.TabIndex = 6
        '
        'tbitem
        '
        Me.tbitem.BackColor = System.Drawing.Color.Linen
        Me.tbitem.Controls.Add(Me.TXTDESC)
        Me.tbitem.Controls.Add(Me.TXTGRIDREMARKS)
        Me.tbitem.Controls.Add(Me.GRIDSMP)
        Me.tbitem.Controls.Add(Me.CMBITEMNAME)
        Me.tbitem.Controls.Add(Me.TXTSRNO)
        Me.tbitem.Location = New System.Drawing.Point(4, 24)
        Me.tbitem.Name = "tbitem"
        Me.tbitem.Padding = New System.Windows.Forms.Padding(3)
        Me.tbitem.Size = New System.Drawing.Size(824, 195)
        Me.tbitem.TabIndex = 0
        Me.tbitem.Text = "Item Details"
        '
        'TXTDESC
        '
        Me.TXTDESC.BackColor = System.Drawing.Color.White
        Me.TXTDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(186, 2)
        Me.TXTDESC.MaxLength = 200
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(300, 23)
        Me.TXTDESC.TabIndex = 1
        '
        'TXTGRIDREMARKS
        '
        Me.TXTGRIDREMARKS.BackColor = System.Drawing.Color.White
        Me.TXTGRIDREMARKS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGRIDREMARKS.Location = New System.Drawing.Point(486, 2)
        Me.TXTGRIDREMARKS.MaxLength = 200
        Me.TXTGRIDREMARKS.Name = "TXTGRIDREMARKS"
        Me.TXTGRIDREMARKS.Size = New System.Drawing.Size(300, 23)
        Me.TXTGRIDREMARKS.TabIndex = 2
        '
        'GRIDSMP
        '
        Me.GRIDSMP.AllowUserToAddRows = False
        Me.GRIDSMP.AllowUserToDeleteRows = False
        Me.GRIDSMP.AllowUserToResizeColumns = False
        Me.GRIDSMP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSMP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDSMP.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSMP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSMP.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDSMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSMP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.gitemname, Me.GDESCRIPTION, Me.GGRIDREMARKS, Me.GSONO, Me.GSOSRNO})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSMP.DefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDSMP.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSMP.Location = New System.Drawing.Point(0, 25)
        Me.GRIDSMP.MultiSelect = False
        Me.GRIDSMP.Name = "GRIDSMP"
        Me.GRIDSMP.RowHeadersVisible = False
        Me.GRIDSMP.RowHeadersWidth = 30
        Me.GRIDSMP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSMP.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDSMP.RowTemplate.Height = 20
        Me.GRIDSMP.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSMP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDSMP.Size = New System.Drawing.Size(819, 166)
        Me.GRIDSMP.TabIndex = 0
        Me.GRIDSMP.TabStop = False
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.DropDownWidth = 400
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(33, 2)
        Me.CMBITEMNAME.MaxLength = 100
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(153, 23)
        Me.CMBITEMNAME.TabIndex = 0
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(3, 2)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        '
        'LBLMODEOFSHIPMENT
        '
        Me.LBLMODEOFSHIPMENT.AutoSize = True
        Me.LBLMODEOFSHIPMENT.BackColor = System.Drawing.Color.Transparent
        Me.LBLMODEOFSHIPMENT.Location = New System.Drawing.Point(22, 102)
        Me.LBLMODEOFSHIPMENT.Name = "LBLMODEOFSHIPMENT"
        Me.LBLMODEOFSHIPMENT.Size = New System.Drawing.Size(108, 15)
        Me.LBLMODEOFSHIPMENT.TabIndex = 6
        Me.LBLMODEOFSHIPMENT.Text = "Mode Of Shipment"
        '
        'LBLDATE
        '
        Me.LBLDATE.AutoSize = True
        Me.LBLDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLDATE.Location = New System.Drawing.Point(645, 73)
        Me.LBLDATE.Name = "LBLDATE"
        Me.LBLDATE.Size = New System.Drawing.Size(32, 15)
        Me.LBLDATE.TabIndex = 5
        Me.LBLDATE.Text = "Date"
        '
        'LBLSRNO
        '
        Me.LBLSRNO.AutoSize = True
        Me.LBLSRNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSRNO.Location = New System.Drawing.Point(641, 44)
        Me.LBLSRNO.Name = "LBLSRNO"
        Me.LBLSRNO.Size = New System.Drawing.Size(36, 15)
        Me.LBLSRNO.TabIndex = 4
        Me.LBLSRNO.Text = "Sr No"
        '
        'LBLSODATE
        '
        Me.LBLSODATE.AutoSize = True
        Me.LBLSODATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLSODATE.Location = New System.Drawing.Point(235, 73)
        Me.LBLSODATE.Name = "LBLSODATE"
        Me.LBLSODATE.Size = New System.Drawing.Size(48, 15)
        Me.LBLSODATE.TabIndex = 3
        Me.LBLSODATE.Text = "So Date"
        '
        'LBLSONO
        '
        Me.LBLSONO.AutoSize = True
        Me.LBLSONO.BackColor = System.Drawing.Color.Transparent
        Me.LBLSONO.Location = New System.Drawing.Point(92, 73)
        Me.LBLSONO.Name = "LBLSONO"
        Me.LBLSONO.Size = New System.Drawing.Size(38, 15)
        Me.LBLSONO.TabIndex = 2
        Me.LBLSONO.Text = "So No"
        '
        'lblShipTo
        '
        Me.lblShipTo.AutoSize = True
        Me.lblShipTo.BackColor = System.Drawing.Color.Transparent
        Me.lblShipTo.Location = New System.Drawing.Point(631, 102)
        Me.lblShipTo.Name = "lblShipTo"
        Me.lblShipTo.Size = New System.Drawing.Size(46, 15)
        Me.lblShipTo.TabIndex = 1
        Me.lblShipTo.Text = "Ship To"
        '
        'lblpartyname
        '
        Me.lblpartyname.AutoSize = True
        Me.lblpartyname.BackColor = System.Drawing.Color.Transparent
        Me.lblpartyname.Location = New System.Drawing.Point(60, 44)
        Me.lblpartyname.Name = "lblpartyname"
        Me.lblpartyname.Size = New System.Drawing.Size(70, 15)
        Me.lblpartyname.TabIndex = 0
        Me.lblpartyname.Text = "Party Name"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 35
        '
        'gitemname
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gitemname.DefaultCellStyle = DataGridViewCellStyle3
        Me.gitemname.HeaderText = "Item Name"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.ReadOnly = True
        Me.gitemname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gitemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gitemname.Width = 150
        '
        'GDESCRIPTION
        '
        Me.GDESCRIPTION.HeaderText = "Description"
        Me.GDESCRIPTION.Name = "GDESCRIPTION"
        Me.GDESCRIPTION.ReadOnly = True
        Me.GDESCRIPTION.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESCRIPTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESCRIPTION.Width = 300
        '
        'GGRIDREMARKS
        '
        Me.GGRIDREMARKS.HeaderText = "Grid Remarks"
        Me.GGRIDREMARKS.Name = "GGRIDREMARKS"
        Me.GGRIDREMARKS.ReadOnly = True
        Me.GGRIDREMARKS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GGRIDREMARKS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GGRIDREMARKS.Width = 300
        '
        'GSONO
        '
        Me.GSONO.HeaderText = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.Visible = False
        '
        'GSOSRNO
        '
        Me.GSOSRNO.HeaderText = "SOSRNO"
        Me.GSOSRNO.Name = "GSOSRNO"
        Me.GSOSRNO.Visible = False
        '
        'SampleNote
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(868, 520)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SampleNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sample Note"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tbitem.ResumeLayout(False)
        Me.tbitem.PerformLayout()
        CType(Me.GRIDSMP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents LBLMODEOFSHIPMENT As Label
    Friend WithEvents LBLDATE As Label
    Friend WithEvents LBLSRNO As Label
    Friend WithEvents LBLSODATE As Label
    Friend WithEvents LBLSONO As Label
    Friend WithEvents lblShipTo As Label
    Friend WithEvents lblpartyname As Label
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents tbitem As TabPage
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents CMBSHIPTO As ComboBox
    Friend WithEvents CMBPARTYNAME As ComboBox
    Friend WithEvents TXTSONO As TextBox
    Friend WithEvents TXTMODEOFSHIPMENT As TextBox
    Friend WithEvents TXTSMPNO As TextBox
    Friend WithEvents TXTGRIDREMARKS As TextBox
    Friend WithEvents GRIDSMP As DataGridView
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdclear As Button
    Friend WithEvents cmdEXIT As Button
    Friend WithEvents CMDSELECTSO As Button
    Friend WithEvents SODATE As MaskedTextBox
    Friend WithEvents SMPDATE As MaskedTextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents TOOLDELETE As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolPREVIOUS As ToolStripButton
    Friend WithEvents Toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents LBLDOCKETNO As Label
    Friend WithEvents TXTDOCKETNO As TextBox
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents TXTDESC As TextBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents gitemname As DataGridViewTextBoxColumn
    Friend WithEvents GDESCRIPTION As DataGridViewTextBoxColumn
    Friend WithEvents GGRIDREMARKS As DataGridViewTextBoxColumn
    Friend WithEvents GSONO As DataGridViewTextBoxColumn
    Friend WithEvents GSOSRNO As DataGridViewTextBoxColumn
End Class
