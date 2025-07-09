<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GDNGridDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.LBLTYPE = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GTYPECHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gSODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotalpcs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALENOFROM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBBERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONSIGNEE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gagent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHOLD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDPARTYPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GGRIDLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.LBLTYPE)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(600, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 14)
        Me.Label1.TabIndex = 808
        Me.Label1.Text = "Hold for Approval"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(581, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 17)
        Me.Label2.TabIndex = 807
        Me.Label2.Text = "   "
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Location = New System.Drawing.Point(226, 41)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(243, 22)
        Me.CMBTYPE.TabIndex = 0
        Me.CMBTYPE.Visible = False
        '
        'LBLTYPE
        '
        Me.LBLTYPE.AutoSize = True
        Me.LBLTYPE.BackColor = System.Drawing.Color.Transparent
        Me.LBLTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTYPE.Location = New System.Drawing.Point(148, 45)
        Me.LBLTYPE.Name = "LBLTYPE"
        Me.LBLTYPE.Size = New System.Drawing.Size(76, 14)
        Me.LBLTYPE.TabIndex = 797
        Me.LBLTYPE.Text = "Challan Type"
        Me.LBLTYPE.Visible = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 69)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 458)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GTYPECHALLANNO, Me.gsrno, Me.GCHALLANNO, Me.gdate, Me.GNAME, Me.GPACKING, Me.GSONO, Me.gSODATE, Me.GITEMNAME, Me.GBALENO, Me.GGRIDLOTNO, Me.GDESIGNNO, Me.GSHADE, Me.GRATE, Me.GCATEGORY, Me.gtotalpcs, Me.GTOTALMTRS, Me.GTOTALBALES, Me.GBALENOFROM, Me.GJOBBERNAME, Me.GCONSIGNEE, Me.Gagent, Me.GPARTYPONO, Me.GHOLD, Me.GGRIDPARTYPONO, Me.GBARCODE, Me.GTRANSPORT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GTYPECHALLANNO
        '
        Me.GTYPECHALLANNO.Caption = "Challan No"
        Me.GTYPECHALLANNO.FieldName = "TYPECHALLANNO"
        Me.GTYPECHALLANNO.Name = "GTYPECHALLANNO"
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No."
        Me.GCHALLANNO.FieldName = "CHNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 2
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 3
        '
        'GNAME
        '
        Me.GNAME.Caption = "Customer Name"
        Me.GNAME.FieldName = "CMPNAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 200
        '
        'GPACKING
        '
        Me.GPACKING.Caption = "Dispatched To"
        Me.GPACKING.FieldName = "PACKING"
        Me.GPACKING.Name = "GPACKING"
        Me.GPACKING.Visible = True
        Me.GPACKING.VisibleIndex = 5
        Me.GPACKING.Width = 100
        '
        'GSONO
        '
        Me.GSONO.Caption = "SO No."
        Me.GSONO.FieldName = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.Visible = True
        Me.GSONO.VisibleIndex = 6
        Me.GSONO.Width = 60
        '
        'gSODATE
        '
        Me.gSODATE.Caption = "SO Date"
        Me.gSODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gSODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gSODATE.FieldName = "SODATE"
        Me.gSODATE.Name = "gSODATE"
        Me.gSODATE.Visible = True
        Me.gSODATE.VisibleIndex = 7
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 8
        Me.GITEMNAME.Width = 200
        '
        'GBALENO
        '
        Me.GBALENO.Caption = "Bale No"
        Me.GBALENO.FieldName = "BALENO"
        Me.GBALENO.Name = "GBALENO"
        Me.GBALENO.Visible = True
        Me.GBALENO.VisibleIndex = 9
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 11
        Me.GDESIGNNO.Width = 100
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 12
        Me.GSHADE.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 13
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category Name"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 14
        '
        'gtotalpcs
        '
        Me.gtotalpcs.Caption = "Pcs"
        Me.gtotalpcs.DisplayFormat.FormatString = "0"
        Me.gtotalpcs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalpcs.FieldName = "PCS"
        Me.gtotalpcs.Name = "gtotalpcs"
        Me.gtotalpcs.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalpcs.Visible = True
        Me.gtotalpcs.VisibleIndex = 15
        '
        'GTOTALMTRS
        '
        Me.GTOTALMTRS.Caption = "Mtrs"
        Me.GTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMTRS.FieldName = "MTRS"
        Me.GTOTALMTRS.Name = "GTOTALMTRS"
        Me.GTOTALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALMTRS.Visible = True
        Me.GTOTALMTRS.VisibleIndex = 16
        '
        'GTOTALBALES
        '
        Me.GTOTALBALES.Caption = "Total Bales"
        Me.GTOTALBALES.DisplayFormat.FormatString = "0"
        Me.GTOTALBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALBALES.FieldName = "TOTALBALES"
        Me.GTOTALBALES.Name = "GTOTALBALES"
        Me.GTOTALBALES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALBALES.Visible = True
        Me.GTOTALBALES.VisibleIndex = 17
        '
        'GBALENOFROM
        '
        Me.GBALENOFROM.Caption = "Bale No From"
        Me.GBALENOFROM.DisplayFormat.FormatString = "0"
        Me.GBALENOFROM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALENOFROM.FieldName = "BALENOFROM"
        Me.GBALENOFROM.Name = "GBALENOFROM"
        Me.GBALENOFROM.Visible = True
        Me.GBALENOFROM.VisibleIndex = 18
        '
        'GJOBBERNAME
        '
        Me.GJOBBERNAME.Caption = "Jobber Name"
        Me.GJOBBERNAME.FieldName = "JOBBERNAME"
        Me.GJOBBERNAME.Name = "GJOBBERNAME"
        Me.GJOBBERNAME.Visible = True
        Me.GJOBBERNAME.VisibleIndex = 19
        Me.GJOBBERNAME.Width = 150
        '
        'GCONSIGNEE
        '
        Me.GCONSIGNEE.Caption = "Consignee"
        Me.GCONSIGNEE.FieldName = "CONSIGNEE"
        Me.GCONSIGNEE.Name = "GCONSIGNEE"
        Me.GCONSIGNEE.Visible = True
        Me.GCONSIGNEE.VisibleIndex = 20
        Me.GCONSIGNEE.Width = 150
        '
        'Gagent
        '
        Me.Gagent.Caption = "Agent"
        Me.Gagent.FieldName = "AGENT"
        Me.Gagent.Name = "Gagent"
        Me.Gagent.Visible = True
        Me.Gagent.VisibleIndex = 21
        Me.Gagent.Width = 200
        '
        'GPARTYPONO
        '
        Me.GPARTYPONO.Caption = "Party PO No"
        Me.GPARTYPONO.FieldName = "PARTYPONO"
        Me.GPARTYPONO.Name = "GPARTYPONO"
        Me.GPARTYPONO.Visible = True
        Me.GPARTYPONO.VisibleIndex = 22
        '
        'GHOLD
        '
        Me.GHOLD.Caption = "Hold"
        Me.GHOLD.FieldName = "HOLDFORAPPROVAL"
        Me.GHOLD.Name = "GHOLD"
        Me.GHOLD.Visible = True
        Me.GHOLD.VisibleIndex = 23
        '
        'GGRIDPARTYPONO
        '
        Me.GGRIDPARTYPONO.Caption = "Grid Party PO No"
        Me.GGRIDPARTYPONO.FieldName = "GRIDPARTYPONO"
        Me.GGRIDPARTYPONO.Name = "GGRIDPARTYPONO"
        Me.GGRIDPARTYPONO.Visible = True
        Me.GGRIDPARTYPONO.VisibleIndex = 24
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Barcode"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 25
        Me.GBARCODE.Width = 120
        '
        'GTRANSPORT
        '
        Me.GTRANSPORT.Caption = "Transport Name"
        Me.GTRANSPORT.FieldName = "TRANSPORT"
        Me.GTRANSPORT.Name = "GTRANSPORT"
        Me.GTRANSPORT.Visible = True
        Me.GTRANSPORT.VisibleIndex = 26
        Me.GTRANSPORT.Width = 200
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(596, 536)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ToolStripButton2, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(130, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a gdn to Change"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(508, 536)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GGRIDLOTNO
        '
        Me.GGRIDLOTNO.Caption = "Lot No"
        Me.GGRIDLOTNO.FieldName = "GRIDLOTNO"
        Me.GGRIDLOTNO.Name = "GGRIDLOTNO"
        Me.GGRIDLOTNO.Visible = True
        Me.GGRIDLOTNO.VisibleIndex = 10
        '
        'GDNGridDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GDNGridDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GDN Grid Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBTYPE As ComboBox
    Friend WithEvents LBLTYPE As Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GTYPECHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gSODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpcs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALENOFROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBBERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONSIGNEE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gagent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHOLD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDPARTYPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSPORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents cmdok As Button
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDLOTNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
