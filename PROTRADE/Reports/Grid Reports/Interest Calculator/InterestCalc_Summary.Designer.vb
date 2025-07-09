<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterestCalc_Summary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterestCalc_Summary))
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKALL = New System.Windows.Forms.CheckBox()
        Me.cmbgroup = New System.Windows.Forms.ComboBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.GRIDNAMEDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDNAMEREGISTER = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNDEBIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNCREDIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNNETTBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNINTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNTOPAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNTOREC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNCLOSINGDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSINGCR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETTINT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDSFORM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIDEINT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALINT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbldrcrclosing = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbln = New System.Windows.Forms.Label()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GBILL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAPPDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gduedate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEBIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCREDIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETTBALANCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOPAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOREC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TXTDAYS = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTPERCENT = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.RBPASSDATE = New System.Windows.Forms.RadioButton()
        Me.RBBILLDATE = New System.Windows.Forms.RadioButton()
        Me.RBDUEDATE = New System.Windows.Forms.RadioButton()
        Me.CHKDATE = New System.Windows.Forms.CheckBox()
        Me.CHKDN = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdshowdetails = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDNAMEDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDNAMEREGISTER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Controls.Add(Me.cmbgroup)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.GRIDNAMEDETAILS)
        Me.BlendPanel1.Controls.Add(Me.lbldrcrclosing)
        Me.BlendPanel1.Controls.Add(Me.txttotal)
        Me.BlendPanel1.Controls.Add(Me.lbln)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.TXTDAYS)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTPERCENT)
        Me.BlendPanel1.Controls.Add(Me.Label28)
        Me.BlendPanel1.Controls.Add(Me.RBPASSDATE)
        Me.BlendPanel1.Controls.Add(Me.RBBILLDATE)
        Me.BlendPanel1.Controls.Add(Me.RBDUEDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKDN)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKALL
        '
        Me.CHKALL.AutoSize = True
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKALL.Location = New System.Drawing.Point(675, 35)
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.Size = New System.Drawing.Size(95, 18)
        Me.CHKALL.TabIndex = 768
        Me.CHKALL.Text = "Calculate All"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'cmbgroup
        '
        Me.cmbgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbgroup.FormattingEnabled = True
        Me.cmbgroup.Location = New System.Drawing.Point(872, 33)
        Me.cmbgroup.MaxDropDownItems = 14
        Me.cmbgroup.Name = "cmbgroup"
        Me.cmbgroup.Size = New System.Drawing.Size(161, 22)
        Me.cmbgroup.TabIndex = 5
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.Location = New System.Drawing.Point(831, 37)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(40, 14)
        Me.lblgroup.TabIndex = 767
        Me.lblgroup.Text = "Group"
        '
        'GRIDNAMEDETAILS
        '
        Me.GRIDNAMEDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDNAMEDETAILS.Location = New System.Drawing.Point(16, 91)
        Me.GRIDNAMEDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDNAMEDETAILS.MainView = Me.GRIDNAMEREGISTER
        Me.GRIDNAMEDETAILS.Name = "GRIDNAMEDETAILS"
        Me.GRIDNAMEDETAILS.Size = New System.Drawing.Size(1206, 447)
        Me.GRIDNAMEDETAILS.TabIndex = 765
        Me.GRIDNAMEDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDNAMEREGISTER})
        '
        'GRIDNAMEREGISTER
        '
        Me.GRIDNAMEREGISTER.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDNAMEREGISTER.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDNAMEREGISTER.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.GRIDNAMEREGISTER.Appearance.Row.Options.UseFont = True
        Me.GRIDNAMEREGISTER.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDNAMEREGISTER.Appearance.ViewCaption.Options.UseFont = True
        Me.GRIDNAMEREGISTER.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNNAME, Me.GNDEBIT, Me.GNCREDIT, Me.GNNETTBAL, Me.GNINTPER, Me.GNTOPAY, Me.GNTOREC, Me.GNCLOSINGDR, Me.GCLOSINGCR, Me.GTDS, Me.GTDSAMT, Me.GNETTINT, Me.GPANNO, Me.GTDSFORM, Me.GGROUPNAME, Me.GSIDEINT, Me.GTOTALINT})
        Me.GRIDNAMEREGISTER.GridControl = Me.GRIDNAMEDETAILS
        Me.GRIDNAMEREGISTER.Name = "GRIDNAMEREGISTER"
        Me.GRIDNAMEREGISTER.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDNAMEREGISTER.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDNAMEREGISTER.OptionsBehavior.Editable = False
        Me.GRIDNAMEREGISTER.OptionsMenu.EnableColumnMenu = False
        Me.GRIDNAMEREGISTER.OptionsView.ColumnAutoWidth = False
        Me.GRIDNAMEREGISTER.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDNAMEREGISTER.OptionsView.ShowAutoFilterRow = True
        Me.GRIDNAMEREGISTER.OptionsView.ShowFooter = True
        Me.GRIDNAMEREGISTER.OptionsView.ShowGroupPanel = False
        '
        'GNNAME
        '
        Me.GNNAME.Caption = "Name"
        Me.GNNAME.FieldName = "NAME"
        Me.GNNAME.Name = "GNNAME"
        Me.GNNAME.OptionsColumn.AllowEdit = False
        Me.GNNAME.Visible = True
        Me.GNNAME.VisibleIndex = 0
        Me.GNNAME.Width = 250
        '
        'GNDEBIT
        '
        Me.GNDEBIT.Caption = "Debit"
        Me.GNDEBIT.DisplayFormat.FormatString = "0.00"
        Me.GNDEBIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNDEBIT.FieldName = "DEBIT"
        Me.GNDEBIT.Name = "GNDEBIT"
        Me.GNDEBIT.OptionsColumn.AllowEdit = False
        Me.GNDEBIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNDEBIT.Visible = True
        Me.GNDEBIT.VisibleIndex = 1
        Me.GNDEBIT.Width = 110
        '
        'GNCREDIT
        '
        Me.GNCREDIT.Caption = "Credit"
        Me.GNCREDIT.DisplayFormat.FormatString = "0.00"
        Me.GNCREDIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNCREDIT.FieldName = "CREDIT"
        Me.GNCREDIT.Name = "GNCREDIT"
        Me.GNCREDIT.OptionsColumn.AllowEdit = False
        Me.GNCREDIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNCREDIT.Visible = True
        Me.GNCREDIT.VisibleIndex = 2
        Me.GNCREDIT.Width = 110
        '
        'GNNETTBAL
        '
        Me.GNNETTBAL.Caption = "Nett Balance"
        Me.GNNETTBAL.DisplayFormat.FormatString = "0.00"
        Me.GNNETTBAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNNETTBAL.FieldName = "NETTBALANCE"
        Me.GNNETTBAL.Name = "GNNETTBAL"
        Me.GNNETTBAL.OptionsColumn.AllowEdit = False
        Me.GNNETTBAL.Visible = True
        Me.GNNETTBAL.VisibleIndex = 3
        Me.GNNETTBAL.Width = 110
        '
        'GNINTPER
        '
        Me.GNINTPER.Caption = "Int %"
        Me.GNINTPER.DisplayFormat.FormatString = "0.00"
        Me.GNINTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNINTPER.FieldName = "INTPER"
        Me.GNINTPER.Name = "GNINTPER"
        Me.GNINTPER.Visible = True
        Me.GNINTPER.VisibleIndex = 4
        Me.GNINTPER.Width = 50
        '
        'GNTOPAY
        '
        Me.GNTOPAY.Caption = "To Pay"
        Me.GNTOPAY.DisplayFormat.FormatString = "0.00"
        Me.GNTOPAY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNTOPAY.FieldName = "TOPAY"
        Me.GNTOPAY.Name = "GNTOPAY"
        Me.GNTOPAY.OptionsColumn.AllowEdit = False
        Me.GNTOPAY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOPAY", "{0:0.00}")})
        Me.GNTOPAY.Visible = True
        Me.GNTOPAY.VisibleIndex = 5
        Me.GNTOPAY.Width = 110
        '
        'GNTOREC
        '
        Me.GNTOREC.Caption = "To Rec"
        Me.GNTOREC.DisplayFormat.FormatString = "0.00"
        Me.GNTOREC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNTOREC.FieldName = "TOREC"
        Me.GNTOREC.Name = "GNTOREC"
        Me.GNTOREC.OptionsColumn.AllowEdit = False
        Me.GNTOREC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOREC", "{0:0.00}")})
        Me.GNTOREC.Visible = True
        Me.GNTOREC.VisibleIndex = 6
        Me.GNTOREC.Width = 110
        '
        'GNCLOSINGDR
        '
        Me.GNCLOSINGDR.Caption = "Int (Debit)"
        Me.GNCLOSINGDR.DisplayFormat.FormatString = "0.00"
        Me.GNCLOSINGDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNCLOSINGDR.FieldName = "INTDR"
        Me.GNCLOSINGDR.Name = "GNCLOSINGDR"
        Me.GNCLOSINGDR.OptionsColumn.AllowEdit = False
        Me.GNCLOSINGDR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNCLOSINGDR.Visible = True
        Me.GNCLOSINGDR.VisibleIndex = 7
        Me.GNCLOSINGDR.Width = 110
        '
        'GCLOSINGCR
        '
        Me.GCLOSINGCR.Caption = "Int (Credit)"
        Me.GCLOSINGCR.DisplayFormat.FormatString = "0.00"
        Me.GCLOSINGCR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLOSINGCR.FieldName = "INTCR"
        Me.GCLOSINGCR.Name = "GCLOSINGCR"
        Me.GCLOSINGCR.OptionsColumn.AllowEdit = False
        Me.GCLOSINGCR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCLOSINGCR.Visible = True
        Me.GCLOSINGCR.VisibleIndex = 8
        Me.GCLOSINGCR.Width = 110
        '
        'GTDS
        '
        Me.GTDS.Caption = "TDS %"
        Me.GTDS.FieldName = "TDSPER"
        Me.GTDS.Name = "GTDS"
        Me.GTDS.Visible = True
        Me.GTDS.VisibleIndex = 9
        Me.GTDS.Width = 60
        '
        'GTDSAMT
        '
        Me.GTDSAMT.Caption = "TDS Amt"
        Me.GTDSAMT.DisplayFormat.FormatString = "0.00"
        Me.GTDSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDSAMT.FieldName = "TDSAMT"
        Me.GTDSAMT.Name = "GTDSAMT"
        Me.GTDSAMT.Visible = True
        Me.GTDSAMT.VisibleIndex = 10
        Me.GTDSAMT.Width = 100
        '
        'GNETTINT
        '
        Me.GNETTINT.Caption = "Nett Int"
        Me.GNETTINT.DisplayFormat.FormatString = "0.00"
        Me.GNETTINT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTINT.FieldName = "NETTINT"
        Me.GNETTINT.Name = "GNETTINT"
        Me.GNETTINT.Visible = True
        Me.GNETTINT.VisibleIndex = 11
        Me.GNETTINT.Width = 110
        '
        'GPANNO
        '
        Me.GPANNO.Caption = "Pan No"
        Me.GPANNO.FieldName = "PANNO"
        Me.GPANNO.Name = "GPANNO"
        Me.GPANNO.Visible = True
        Me.GPANNO.VisibleIndex = 12
        Me.GPANNO.Width = 100
        '
        'GTDSFORM
        '
        Me.GTDSFORM.Caption = "TDS Form"
        Me.GTDSFORM.FieldName = "TDSFORM"
        Me.GTDSFORM.Name = "GTDSFORM"
        Me.GTDSFORM.Visible = True
        Me.GTDSFORM.VisibleIndex = 13
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 14
        '
        'GSIDEINT
        '
        Me.GSIDEINT.Caption = "Side Int"
        Me.GSIDEINT.FieldName = "SIDEINT"
        Me.GSIDEINT.Name = "GSIDEINT"
        Me.GSIDEINT.Visible = True
        Me.GSIDEINT.VisibleIndex = 15
        Me.GSIDEINT.Width = 110
        '
        'GTOTALINT
        '
        Me.GTOTALINT.Caption = "Total Int"
        Me.GTOTALINT.FieldName = "TOTALINT"
        Me.GTOTALINT.Name = "GTOTALINT"
        Me.GTOTALINT.Visible = True
        Me.GTOTALINT.VisibleIndex = 16
        Me.GTOTALINT.Width = 110
        '
        'lbldrcrclosing
        '
        Me.lbldrcrclosing.AutoSize = True
        Me.lbldrcrclosing.BackColor = System.Drawing.Color.Transparent
        Me.lbldrcrclosing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldrcrclosing.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbldrcrclosing.Location = New System.Drawing.Point(222, 529)
        Me.lbldrcrclosing.Name = "lbldrcrclosing"
        Me.lbldrcrclosing.Size = New System.Drawing.Size(0, 14)
        Me.lbldrcrclosing.TabIndex = 764
        Me.lbldrcrclosing.Visible = False
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.ForeColor = System.Drawing.Color.Black
        Me.txttotal.Location = New System.Drawing.Point(94, 548)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(100, 22)
        Me.txttotal.TabIndex = 763
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txttotal.Visible = False
        '
        'lbln
        '
        Me.lbln.AutoSize = True
        Me.lbln.BackColor = System.Drawing.Color.Transparent
        Me.lbln.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbln.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbln.Location = New System.Drawing.Point(12, 552)
        Me.lbln.Name = "lbln"
        Me.lbln.Size = New System.Drawing.Size(80, 14)
        Me.lbln.TabIndex = 762
        Me.lbln.Text = "Int Closing Bal."
        Me.lbln.Visible = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(1039, 28)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(98, 77)
        Me.griddetails.TabIndex = 761
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        Me.griddetails.Visible = False
        '
        'gridregister
        '
        Me.gridregister.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBILL, Me.GBILLINITIALS, Me.GTYPE, Me.GREGTYPE, Me.GNAME, Me.GDATE, Me.GAPPDATE, Me.gduedate, Me.GBALES, Me.GDEBIT, Me.GCREDIT, Me.GNETTBALANCE, Me.GDAYS, Me.GTOPAY, Me.GTOREC})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsMenu.EnableColumnMenu = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.OptionsView.ShowAutoFilterRow = True
        Me.gridregister.OptionsView.ShowFooter = True
        '
        'GBILL
        '
        Me.GBILL.Caption = "BILL"
        Me.GBILL.FieldName = "SRNO"
        Me.GBILL.Name = "GBILL"
        '
        'GBILLINITIALS
        '
        Me.GBILLINITIALS.Caption = "Bill No"
        Me.GBILLINITIALS.FieldName = "BILLINITIALS"
        Me.GBILLINITIALS.Name = "GBILLINITIALS"
        Me.GBILLINITIALS.Visible = True
        Me.GBILLINITIALS.VisibleIndex = 0
        Me.GBILLINITIALS.Width = 80
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 1
        Me.GTYPE.Width = 130
        '
        'GREGTYPE
        '
        Me.GREGTYPE.Caption = "REGTYPE"
        Me.GREGTYPE.FieldName = "REGTYPE"
        Me.GREGTYPE.Name = "GREGTYPE"
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Width = 200
        '
        'GDATE
        '
        Me.GDATE.Caption = "Bill Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 90
        '
        'GAPPDATE
        '
        Me.GAPPDATE.Caption = "Passing Date"
        Me.GAPPDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GAPPDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GAPPDATE.FieldName = "APPDATE"
        Me.GAPPDATE.Name = "GAPPDATE"
        Me.GAPPDATE.Visible = True
        Me.GAPPDATE.VisibleIndex = 3
        Me.GAPPDATE.Width = 90
        '
        'gduedate
        '
        Me.gduedate.Caption = "Due Date"
        Me.gduedate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gduedate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gduedate.FieldName = "DUEDATE"
        Me.gduedate.Name = "gduedate"
        Me.gduedate.Visible = True
        Me.gduedate.VisibleIndex = 4
        Me.gduedate.Width = 90
        '
        'GBALES
        '
        Me.GBALES.Caption = "Bales"
        Me.GBALES.DisplayFormat.FormatString = "0"
        Me.GBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALES.FieldName = "TOTALBALES"
        Me.GBALES.Name = "GBALES"
        Me.GBALES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALES.Visible = True
        Me.GBALES.VisibleIndex = 5
        Me.GBALES.Width = 60
        '
        'GDEBIT
        '
        Me.GDEBIT.Caption = "Debit"
        Me.GDEBIT.DisplayFormat.FormatString = "0.00"
        Me.GDEBIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDEBIT.FieldName = "DEBIT"
        Me.GDEBIT.Name = "GDEBIT"
        Me.GDEBIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDEBIT.Visible = True
        Me.GDEBIT.VisibleIndex = 6
        Me.GDEBIT.Width = 120
        '
        'GCREDIT
        '
        Me.GCREDIT.Caption = "Credit"
        Me.GCREDIT.DisplayFormat.FormatString = "0.00"
        Me.GCREDIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCREDIT.FieldName = "CREDIT"
        Me.GCREDIT.Name = "GCREDIT"
        Me.GCREDIT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCREDIT.Visible = True
        Me.GCREDIT.VisibleIndex = 7
        Me.GCREDIT.Width = 120
        '
        'GNETTBALANCE
        '
        Me.GNETTBALANCE.Caption = "Nett Balance"
        Me.GNETTBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GNETTBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTBALANCE.FieldName = "NETTBALANCE"
        Me.GNETTBALANCE.Name = "GNETTBALANCE"
        Me.GNETTBALANCE.Visible = True
        Me.GNETTBALANCE.VisibleIndex = 8
        Me.GNETTBALANCE.Width = 120
        '
        'GDAYS
        '
        Me.GDAYS.Caption = "Days"
        Me.GDAYS.DisplayFormat.FormatString = "0"
        Me.GDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDAYS.FieldName = "DAYS"
        Me.GDAYS.Name = "GDAYS"
        Me.GDAYS.Visible = True
        Me.GDAYS.VisibleIndex = 9
        Me.GDAYS.Width = 50
        '
        'GTOPAY
        '
        Me.GTOPAY.Caption = "To Pay"
        Me.GTOPAY.DisplayFormat.FormatString = "0.00"
        Me.GTOPAY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOPAY.FieldName = "TOPAY"
        Me.GTOPAY.Name = "GTOPAY"
        Me.GTOPAY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOPAY.Visible = True
        Me.GTOPAY.VisibleIndex = 10
        Me.GTOPAY.Width = 120
        '
        'GTOREC
        '
        Me.GTOREC.Caption = "To Rec"
        Me.GTOREC.DisplayFormat.FormatString = "0.00"
        Me.GTOREC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOREC.FieldName = "TOREC"
        Me.GTOREC.Name = "GTOREC"
        Me.GTOREC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOREC.Visible = True
        Me.GTOREC.VisibleIndex = 11
        Me.GTOREC.Width = 120
        '
        'TXTDAYS
        '
        Me.TXTDAYS.BackColor = System.Drawing.Color.White
        Me.TXTDAYS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDAYS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDAYS.Location = New System.Drawing.Point(627, 59)
        Me.TXTDAYS.Name = "TXTDAYS"
        Me.TXTDAYS.Size = New System.Drawing.Size(37, 22)
        Me.TXTDAYS.TabIndex = 4
        Me.TXTDAYS.Text = "360"
        Me.TXTDAYS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(592, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 757
        Me.Label1.Text = "Days"
        '
        'TXTPERCENT
        '
        Me.TXTPERCENT.BackColor = System.Drawing.Color.White
        Me.TXTPERCENT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPERCENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPERCENT.Location = New System.Drawing.Point(627, 33)
        Me.TXTPERCENT.Name = "TXTPERCENT"
        Me.TXTPERCENT.Size = New System.Drawing.Size(37, 22)
        Me.TXTPERCENT.TabIndex = 3
        Me.TXTPERCENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(609, 37)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 14)
        Me.Label28.TabIndex = 755
        Me.Label28.Text = "%"
        '
        'RBPASSDATE
        '
        Me.RBPASSDATE.AutoSize = True
        Me.RBPASSDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBPASSDATE.Location = New System.Drawing.Point(394, 61)
        Me.RBPASSDATE.Name = "RBPASSDATE"
        Me.RBPASSDATE.Size = New System.Drawing.Size(79, 19)
        Me.RBPASSDATE.TabIndex = 496
        Me.RBPASSDATE.Text = "Pass Date"
        Me.RBPASSDATE.UseVisualStyleBackColor = False
        Me.RBPASSDATE.Visible = False
        '
        'RBBILLDATE
        '
        Me.RBBILLDATE.AutoSize = True
        Me.RBBILLDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBBILLDATE.Checked = True
        Me.RBBILLDATE.Location = New System.Drawing.Point(297, 61)
        Me.RBBILLDATE.Name = "RBBILLDATE"
        Me.RBBILLDATE.Size = New System.Drawing.Size(72, 19)
        Me.RBBILLDATE.TabIndex = 2
        Me.RBBILLDATE.TabStop = True
        Me.RBBILLDATE.Text = "Bill Date"
        Me.RBBILLDATE.UseVisualStyleBackColor = False
        '
        'RBDUEDATE
        '
        Me.RBDUEDATE.AutoSize = True
        Me.RBDUEDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBDUEDATE.Location = New System.Drawing.Point(297, 35)
        Me.RBDUEDATE.Name = "RBDUEDATE"
        Me.RBDUEDATE.Size = New System.Drawing.Size(74, 19)
        Me.RBDUEDATE.TabIndex = 1
        Me.RBDUEDATE.Text = "Due Date"
        Me.RBDUEDATE.UseVisualStyleBackColor = False
        '
        'CHKDATE
        '
        Me.CHKDATE.AutoSize = True
        Me.CHKDATE.BackColor = System.Drawing.Color.Transparent
        Me.CHKDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDATE.Location = New System.Drawing.Point(394, 35)
        Me.CHKDATE.Name = "CHKDATE"
        Me.CHKDATE.Size = New System.Drawing.Size(52, 18)
        Me.CHKDATE.TabIndex = 0
        Me.CHKDATE.Text = "Date"
        Me.CHKDATE.UseVisualStyleBackColor = False
        '
        'CHKDN
        '
        Me.CHKDN.AutoSize = True
        Me.CHKDN.BackColor = System.Drawing.Color.Transparent
        Me.CHKDN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDN.Location = New System.Drawing.Point(872, 63)
        Me.CHKDN.Name = "CHKDN"
        Me.CHKDN.Size = New System.Drawing.Size(129, 18)
        Me.CHKDN.TabIndex = 492
        Me.CHKDN.Text = "Include Debit Note"
        Me.CHKDN.UseVisualStyleBackColor = False
        Me.CHKDN.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLPRINT, Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 489
        Me.ToolStrip1.Text = "v"
        '
        'TOOLPRINT
        '
        Me.TOOLPRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLPRINT.Image = CType(resources.GetObject("TOOLPRINT.Image"), System.Drawing.Image)
        Me.TOOLPRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRINT.Name = "TOOLPRINT"
        Me.TOOLPRINT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLPRINT.Text = "&Print"
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(687, 58)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 6
        Me.cmdshowdetails.Text = "&Show Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(534, 545)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 7
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(504, 59)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(79, 22)
        Me.dtto.TabIndex = 2
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(480, 63)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 432
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(503, 33)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(80, 22)
        Me.dtfrom.TabIndex = 1
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(465, 37)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(5, 29)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(146, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Interest Report"
        '
        'InterestCalc_Summary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "InterestCalc_Summary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Interest Calculator Summary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDNAMEDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDNAMEREGISTER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTDAYS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTPERCENT As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents RBPASSDATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBBILLDATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBDUEDATE As System.Windows.Forms.RadioButton
    Friend WithEvents CHKDATE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKDN As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lbldrcrclosing As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbln As System.Windows.Forms.Label
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GBILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAPPDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gduedate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCREDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOREC As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDNAMEDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDNAMEREGISTER As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNDEBIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNCREDIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNNETTBAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNINTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNTOPAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNTOREC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNCLOSINGDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLOSINGCR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbgroup As System.Windows.Forms.ComboBox
    Friend WithEvents lblgroup As System.Windows.Forms.Label
    Friend WithEvents TOOLPRINT As System.Windows.Forms.ToolStripButton
    Friend WithEvents GTDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDSFORM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKALL As System.Windows.Forms.CheckBox
    Friend WithEvents GTDSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTINT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIDEINT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALINT As DevExpress.XtraGrid.Columns.GridColumn
End Class
