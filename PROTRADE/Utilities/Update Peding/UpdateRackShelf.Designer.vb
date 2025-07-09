<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateRackShelf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateRackShelf))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.DTUPDATEDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTENTRYNO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBSHELF = New System.Windows.Forms.ComboBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPIECETYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKDONE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CMBRACK = New System.Windows.Forms.ComboBox()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.DTUPDATEDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTENTRYNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBSHELF)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMBRACK)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(241, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(56, 22)
        Me.tstxtbillno.TabIndex = 772
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 771
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtremarks)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(560, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(276, 68)
        Me.GroupBox1.TabIndex = 770
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(8, 18)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(261, 44)
        Me.txtremarks.TabIndex = 0
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(620, 548)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 769
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
        Me.cmdclear.Location = New System.Drawing.Point(534, 548)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 768
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'DTUPDATEDATE
        '
        Me.DTUPDATEDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTUPDATEDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTUPDATEDATE.Location = New System.Drawing.Point(1043, 64)
        Me.DTUPDATEDATE.Name = "DTUPDATEDATE"
        Me.DTUPDATEDATE.Size = New System.Drawing.Size(91, 23)
        Me.DTUPDATEDATE.TabIndex = 764
        '
        'TXTENTRYNO
        '
        Me.TXTENTRYNO.BackColor = System.Drawing.Color.Linen
        Me.TXTENTRYNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTRYNO.Location = New System.Drawing.Point(1043, 35)
        Me.TXTENTRYNO.Name = "TXTENTRYNO"
        Me.TXTENTRYNO.ReadOnly = True
        Me.TXTENTRYNO.Size = New System.Drawing.Size(91, 23)
        Me.TXTENTRYNO.TabIndex = 766
        Me.TXTENTRYNO.TabStop = False
        Me.TXTENTRYNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(1001, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 767
        Me.Label12.Text = "Sr. No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1008, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 765
        Me.Label9.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 14)
        Me.Label2.TabIndex = 763
        Me.Label2.Text = "Shelf"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 14)
        Me.Label1.TabIndex = 762
        Me.Label1.Text = "Rack"
        '
        'CMBSHELF
        '
        Me.CMBSHELF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSHELF.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSHELF.BackColor = System.Drawing.Color.White
        Me.CMBSHELF.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHELF.FormattingEnabled = True
        Me.CMBSHELF.Location = New System.Drawing.Point(70, 64)
        Me.CMBSHELF.Name = "CMBSHELF"
        Me.CMBSHELF.Size = New System.Drawing.Size(187, 23)
        Me.CMBSHELF.TabIndex = 1
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 106)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKDONE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1210, 431)
        Me.gridbilldetails.TabIndex = 761
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GITEMCODE, Me.GCATEGORY, Me.GITEMNAME, Me.GQUALITY, Me.GDESIGNNO, Me.GCOLOR, Me.GGODOWN, Me.GPCS, Me.GUNIT, Me.GMTRS, Me.GPIECETYPE, Me.GLOTNO, Me.GBALENO, Me.GCHALLANNO, Me.GBARCODE, Me.GTYPE})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsBehavior.ReadOnly = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowColumnResizing = False
        Me.gridbill.OptionsCustomization.AllowFilter = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsCustomization.AllowSort = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 35
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.OptionsColumn.AllowEdit = False
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.OptionsColumn.AllowEdit = False
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 200
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 2
        Me.GQUALITY.Width = 150
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 3
        Me.GDESIGNNO.Width = 150
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.OptionsColumn.AllowEdit = False
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 4
        Me.GCOLOR.Width = 150
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 5
        Me.GGODOWN.Width = 150
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 6
        Me.GPCS.Width = 80
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 7
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs."
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 8
        Me.GMTRS.Width = 90
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.Caption = "Piece Type"
        Me.GPIECETYPE.FieldName = "PIECETYPE"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.OptionsColumn.AllowEdit = False
        Me.GPIECETYPE.Visible = True
        Me.GPIECETYPE.VisibleIndex = 9
        Me.GPIECETYPE.Width = 90
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 10
        '
        'GBALENO
        '
        Me.GBALENO.Caption = "Bale No"
        Me.GBALENO.FieldName = "BALENO"
        Me.GBALENO.Name = "GBALENO"
        Me.GBALENO.Visible = True
        Me.GBALENO.VisibleIndex = 11
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No"
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.OptionsColumn.AllowEdit = False
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 12
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Barcode"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.OptionsColumn.AllowEdit = False
        Me.GBARCODE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 13
        Me.GBARCODE.Width = 130
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        '
        'CHKDONE
        '
        Me.CHKDONE.AutoHeight = False
        Me.CHKDONE.Name = "CHKDONE"
        '
        'CMBRACK
        '
        Me.CMBRACK.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBRACK.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBRACK.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBRACK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRACK.FormattingEnabled = True
        Me.CMBRACK.Location = New System.Drawing.Point(70, 35)
        Me.CMBRACK.Name = "CMBRACK"
        Me.CMBRACK.Size = New System.Drawing.Size(187, 23)
        Me.CMBRACK.TabIndex = 0
        '
        'CMDSAVE
        '
        Me.CMDSAVE.BackColor = System.Drawing.Color.Transparent
        Me.CMDSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSAVE.FlatAppearance.BorderSize = 0
        Me.CMDSAVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSAVE.ForeColor = System.Drawing.Color.Black
        Me.CMDSAVE.Location = New System.Drawing.Point(448, 548)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 3
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(290, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 14)
        Me.Label11.TabIndex = 759
        Me.Label11.Text = "Barcode"
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBARCODE.Location = New System.Drawing.Point(342, 35)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(166, 23)
        Me.TXTBARCODE.TabIndex = 2
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(706, 548)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'UpdateRackShelf
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UpdateRackShelf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Rack & Shelf"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPIECETYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKDONE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTBARCODE As TextBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CMBSHELF As ComboBox
    Friend WithEvents CMBRACK As ComboBox
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DTUPDATEDATE As DateTimePicker
    Friend WithEvents TXTENTRYNO As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmddelete As Button
    Friend WithEvents cmdclear As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents SaveToolStripButton As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents tooldelete As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents toolprevious As ToolStripButton
    Friend WithEvents toolnext As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tstxtbillno As TextBox
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALENO As DevExpress.XtraGrid.Columns.GridColumn
End Class
