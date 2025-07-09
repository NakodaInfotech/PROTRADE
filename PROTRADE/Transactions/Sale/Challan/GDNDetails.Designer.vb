<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GDNDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GDNDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKHIDEPCS = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CHKWHITELABEL = New System.Windows.Forms.CheckBox()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.LBLTYPE = New System.Windows.Forms.Label()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
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
        Me.GTRANSPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMULTISONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLGRIDDETAILS = New System.Windows.Forms.ToolStripLabel()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKHIDEPCS)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CHKWHITELABEL)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.LBLTYPE)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKHIDEPCS
        '
        Me.CHKHIDEPCS.AutoSize = True
        Me.CHKHIDEPCS.BackColor = System.Drawing.SystemColors.Control
        Me.CHKHIDEPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKHIDEPCS.Location = New System.Drawing.Point(644, 2)
        Me.CHKHIDEPCS.Name = "CHKHIDEPCS"
        Me.CHKHIDEPCS.Size = New System.Drawing.Size(115, 19)
        Me.CHKHIDEPCS.TabIndex = 807
        Me.CHKHIDEPCS.Text = "Hide Pcs Details"
        Me.CHKHIDEPCS.UseVisualStyleBackColor = False
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
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 807
        Me.Label2.Text = "   "
        '
        'CHKWHITELABEL
        '
        Me.CHKWHITELABEL.AutoSize = True
        Me.CHKWHITELABEL.BackColor = System.Drawing.SystemColors.Control
        Me.CHKWHITELABEL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKWHITELABEL.Location = New System.Drawing.Point(522, 3)
        Me.CHKWHITELABEL.Name = "CHKWHITELABEL"
        Me.CHKWHITELABEL.Size = New System.Drawing.Size(99, 19)
        Me.CHKWHITELABEL.TabIndex = 806
        Me.CHKWHITELABEL.Text = "Blank Header"
        Me.CHKWHITELABEL.UseVisualStyleBackColor = False
        Me.CHKWHITELABEL.Visible = False
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
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(298, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(50, 22)
        Me.TXTFROM.TabIndex = 790
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(442, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 795
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(487, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 792
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(353, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 794
        Me.Label9.Text = "To"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 69)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 475)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GTYPECHALLANNO, Me.gsrno, Me.GCHALLANNO, Me.gdate, Me.GNAME, Me.GPACKING, Me.GSONO, Me.gSODATE, Me.GITEMNAME, Me.GBALENO, Me.GDESIGNNO, Me.GSHADE, Me.GCATEGORY, Me.gtotalpcs, Me.GTOTALMTRS, Me.GTOTALBALES, Me.GBALENOFROM, Me.GJOBBERNAME, Me.GCONSIGNEE, Me.Gagent, Me.GPARTYPONO, Me.GHOLD, Me.GGRIDPARTYPONO, Me.GTRANSPORT, Me.GCITYNAME, Me.GMULTISONO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Caption = ""
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GTYPECHALLANNO
        '
        Me.GTYPECHALLANNO.Caption = "Challan No"
        Me.GTYPECHALLANNO.FieldName = "TYPECHALLANNO"
        Me.GTYPECHALLANNO.Name = "GTYPECHALLANNO"
        Me.GTYPECHALLANNO.OptionsColumn.AllowEdit = False
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No."
        Me.GCHALLANNO.FieldName = "CHNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.OptionsColumn.AllowEdit = False
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
        Me.gdate.OptionsColumn.AllowEdit = False
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 3
        '
        'GNAME
        '
        Me.GNAME.Caption = "Customer Name"
        Me.GNAME.FieldName = "CMPNAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 200
        '
        'GPACKING
        '
        Me.GPACKING.Caption = "Dispatched To"
        Me.GPACKING.FieldName = "PACKING"
        Me.GPACKING.Name = "GPACKING"
        Me.GPACKING.OptionsColumn.AllowEdit = False
        Me.GPACKING.Visible = True
        Me.GPACKING.VisibleIndex = 5
        Me.GPACKING.Width = 100
        '
        'GSONO
        '
        Me.GSONO.Caption = "SO No."
        Me.GSONO.FieldName = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.OptionsColumn.AllowEdit = False
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
        Me.gSODATE.OptionsColumn.AllowEdit = False
        Me.gSODATE.Visible = True
        Me.gSODATE.VisibleIndex = 7
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 8
        Me.GITEMNAME.Width = 200
        '
        'GBALENO
        '
        Me.GBALENO.Caption = "Bale No"
        Me.GBALENO.FieldName = "BALENO"
        Me.GBALENO.Name = "GBALENO"
        Me.GBALENO.OptionsColumn.AllowEdit = False
        Me.GBALENO.Visible = True
        Me.GBALENO.VisibleIndex = 9
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 10
        Me.GDESIGNNO.Width = 100
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.OptionsColumn.AllowEdit = False
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 11
        Me.GSHADE.Width = 100
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category Name"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.OptionsColumn.AllowEdit = False
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 12
        '
        'gtotalpcs
        '
        Me.gtotalpcs.Caption = "Pcs"
        Me.gtotalpcs.DisplayFormat.FormatString = "0"
        Me.gtotalpcs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotalpcs.FieldName = "PCS"
        Me.gtotalpcs.Name = "gtotalpcs"
        Me.gtotalpcs.OptionsColumn.AllowEdit = False
        Me.gtotalpcs.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotalpcs.Visible = True
        Me.gtotalpcs.VisibleIndex = 13
        '
        'GTOTALMTRS
        '
        Me.GTOTALMTRS.Caption = "Mtrs"
        Me.GTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMTRS.FieldName = "MTRS"
        Me.GTOTALMTRS.Name = "GTOTALMTRS"
        Me.GTOTALMTRS.OptionsColumn.AllowEdit = False
        Me.GTOTALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALMTRS.Visible = True
        Me.GTOTALMTRS.VisibleIndex = 14
        '
        'GTOTALBALES
        '
        Me.GTOTALBALES.Caption = "Total Bales"
        Me.GTOTALBALES.DisplayFormat.FormatString = "0"
        Me.GTOTALBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALBALES.FieldName = "TOTALBALES"
        Me.GTOTALBALES.Name = "GTOTALBALES"
        Me.GTOTALBALES.OptionsColumn.AllowEdit = False
        Me.GTOTALBALES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALBALES.Visible = True
        Me.GTOTALBALES.VisibleIndex = 15
        '
        'GBALENOFROM
        '
        Me.GBALENOFROM.Caption = "Bale No From"
        Me.GBALENOFROM.DisplayFormat.FormatString = "0"
        Me.GBALENOFROM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALENOFROM.FieldName = "BALENOFROM"
        Me.GBALENOFROM.Name = "GBALENOFROM"
        Me.GBALENOFROM.OptionsColumn.AllowEdit = False
        Me.GBALENOFROM.Visible = True
        Me.GBALENOFROM.VisibleIndex = 16
        '
        'GJOBBERNAME
        '
        Me.GJOBBERNAME.Caption = "Jobber Name"
        Me.GJOBBERNAME.FieldName = "JOBBERNAME"
        Me.GJOBBERNAME.Name = "GJOBBERNAME"
        Me.GJOBBERNAME.OptionsColumn.AllowEdit = False
        Me.GJOBBERNAME.Visible = True
        Me.GJOBBERNAME.VisibleIndex = 17
        Me.GJOBBERNAME.Width = 150
        '
        'GCONSIGNEE
        '
        Me.GCONSIGNEE.Caption = "Consignee"
        Me.GCONSIGNEE.FieldName = "CONSIGNEE"
        Me.GCONSIGNEE.Name = "GCONSIGNEE"
        Me.GCONSIGNEE.OptionsColumn.AllowEdit = False
        Me.GCONSIGNEE.Visible = True
        Me.GCONSIGNEE.VisibleIndex = 18
        Me.GCONSIGNEE.Width = 150
        '
        'Gagent
        '
        Me.Gagent.Caption = "Agent"
        Me.Gagent.FieldName = "AGENT"
        Me.Gagent.Name = "Gagent"
        Me.Gagent.OptionsColumn.AllowEdit = False
        Me.Gagent.Visible = True
        Me.Gagent.VisibleIndex = 19
        Me.Gagent.Width = 200
        '
        'GPARTYPONO
        '
        Me.GPARTYPONO.Caption = "Party PO No"
        Me.GPARTYPONO.FieldName = "PARTYPONO"
        Me.GPARTYPONO.Name = "GPARTYPONO"
        Me.GPARTYPONO.OptionsColumn.AllowEdit = False
        Me.GPARTYPONO.Visible = True
        Me.GPARTYPONO.VisibleIndex = 20
        '
        'GHOLD
        '
        Me.GHOLD.Caption = "Hold"
        Me.GHOLD.FieldName = "HOLDFORAPPROVAL"
        Me.GHOLD.Name = "GHOLD"
        Me.GHOLD.OptionsColumn.AllowEdit = False
        Me.GHOLD.Visible = True
        Me.GHOLD.VisibleIndex = 21
        '
        'GGRIDPARTYPONO
        '
        Me.GGRIDPARTYPONO.Caption = "Grid Party PO No"
        Me.GGRIDPARTYPONO.FieldName = "GRIDPARTYPONO"
        Me.GGRIDPARTYPONO.Name = "GGRIDPARTYPONO"
        Me.GGRIDPARTYPONO.OptionsColumn.AllowEdit = False
        Me.GGRIDPARTYPONO.Visible = True
        Me.GGRIDPARTYPONO.VisibleIndex = 22
        '
        'GTRANSPORT
        '
        Me.GTRANSPORT.Caption = "Transport Name"
        Me.GTRANSPORT.FieldName = "TRANSPORT"
        Me.GTRANSPORT.Name = "GTRANSPORT"
        Me.GTRANSPORT.OptionsColumn.AllowEdit = False
        Me.GTRANSPORT.Visible = True
        Me.GTRANSPORT.VisibleIndex = 23
        Me.GTRANSPORT.Width = 200
        '
        'GCITYNAME
        '
        Me.GCITYNAME.Caption = "City Name"
        Me.GCITYNAME.FieldName = "CITYNAME"
        Me.GCITYNAME.Name = "GCITYNAME"
        '
        'GMULTISONO
        '
        Me.GMULTISONO.Caption = "SO No"
        Me.GMULTISONO.FieldName = "MULTISONO"
        Me.GMULTISONO.Name = "GMULTISONO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(263, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 793
        Me.Label10.Text = "From"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(621, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(374, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(52, 22)
        Me.TXTTO.TabIndex = 791
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ToolStripButton2, Me.TOOLMAIL, Me.TOOLWHATSAPP, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.TOOLGRIDDETAILS})
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
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.PROTRADE.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Challan Directly"
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.PROTRADE.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "Whatsapp Challan Directly"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLGRIDDETAILS
        '
        Me.TOOLGRIDDETAILS.Name = "TOOLGRIDDETAILS"
        Me.TOOLGRIDDETAILS.Size = New System.Drawing.Size(67, 22)
        Me.TOOLGRIDDETAILS.Text = "Grid Details"
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
        Me.cmdok.Location = New System.Drawing.Point(533, 550)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'GDNDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GDNDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Challan Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GCONSIGNEE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gagent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gSODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotalpcs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBBERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTCOPIES As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPECHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents LBLTYPE As System.Windows.Forms.Label
    Friend WithEvents TOOLMAIL As System.Windows.Forms.ToolStripButton
    Friend WithEvents GPACKING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKWHITELABEL As System.Windows.Forms.CheckBox
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALENOFROM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GHOLD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents GGRIDPARTYPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSPORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLGRIDDETAILS As ToolStripLabel
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents GCITYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMULTISONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKHIDEPCS As CheckBox
End Class
