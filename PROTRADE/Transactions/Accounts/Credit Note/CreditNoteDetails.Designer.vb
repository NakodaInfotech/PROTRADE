<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreditNoteDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditNoteDetails))
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridCN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAGENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNITEMDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEBITNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELIVERYAT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRCM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNOGSTR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridCN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(410, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 14)
        Me.Label4.TabIndex = 799
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(451, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 798
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(300, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 14)
        Me.Label9.TabIndex = 795
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(202, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 14)
        Me.Label10.TabIndex = 794
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(321, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(57, 22)
        Me.TXTTO.TabIndex = 793
        Me.TXTTO.TabStop = False
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(237, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 792
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(17, 63)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridCN
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1205, 480)
        Me.griddetails.TabIndex = 326
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridCN})
        '
        'gridCN
        '
        Me.gridCN.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridCN.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridCN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridCN.Appearance.Row.Options.UseFont = True
        Me.gridCN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GBILLNO, Me.GNAME, Me.GAGENT, Me.GGSTIN, Me.GSTATENAME, Me.GSTATECODE, Me.GPARTYREFNO, Me.GHSNITEMDESC, Me.GHSNCODE, Me.GDEBITNAME, Me.GDELIVERYAT, Me.GRCM, Me.GBILLAMT, Me.GCHGS, Me.GSUBTOTAL, Me.GCGSTAMT, Me.GSGSTAMT, Me.GTOTALIGSTAMT, Me.GROUNDOFF, Me.GAMT, Me.GREMARKS, Me.GNOGSTR1, Me.GGROUPNAME})
        Me.gridCN.GridControl = Me.griddetails
        Me.gridCN.Images = Me.imageList1
        Me.gridCN.Name = "gridCN"
        Me.gridCN.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridCN.OptionsBehavior.Editable = False
        Me.gridCN.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridCN.OptionsSelection.MultiSelect = True
        Me.gridCN.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridCN.OptionsView.ColumnAutoWidth = False
        Me.gridCN.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridCN.OptionsView.ShowAutoFilterRow = True
        Me.gridCN.OptionsView.ShowFooter = True
        Me.gridCN.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr. No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 80
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.ImageIndex = 1
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 3
        Me.GBILLNO.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 250
        '
        'GAGENT
        '
        Me.GAGENT.Caption = "Agent"
        Me.GAGENT.FieldName = "AGENT"
        Me.GAGENT.Name = "GAGENT"
        Me.GAGENT.Visible = True
        Me.GAGENT.VisibleIndex = 9
        Me.GAGENT.Width = 120
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 5
        Me.GGSTIN.Width = 100
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 6
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 7
        Me.GSTATECODE.Width = 40
        '
        'GPARTYREFNO
        '
        Me.GPARTYREFNO.Caption = "Party Ref. No."
        Me.GPARTYREFNO.FieldName = "PARTYREFNO"
        Me.GPARTYREFNO.Name = "GPARTYREFNO"
        Me.GPARTYREFNO.Visible = True
        Me.GPARTYREFNO.VisibleIndex = 8
        '
        'GHSNITEMDESC
        '
        Me.GHSNITEMDESC.Caption = "Service Desc."
        Me.GHSNITEMDESC.FieldName = "HSNITEMDESC"
        Me.GHSNITEMDESC.Name = "GHSNITEMDESC"
        Me.GHSNITEMDESC.Visible = True
        Me.GHSNITEMDESC.VisibleIndex = 10
        Me.GHSNITEMDESC.Width = 80
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "SAC Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 11
        Me.GHSNCODE.Width = 60
        '
        'GDEBITNAME
        '
        Me.GDEBITNAME.Caption = "Debit Name"
        Me.GDEBITNAME.FieldName = "DEBITNAME"
        Me.GDEBITNAME.Name = "GDEBITNAME"
        Me.GDEBITNAME.Visible = True
        Me.GDEBITNAME.VisibleIndex = 12
        Me.GDEBITNAME.Width = 150
        '
        'GDELIVERYAT
        '
        Me.GDELIVERYAT.Caption = "Delivery At"
        Me.GDELIVERYAT.FieldName = "DELIVERYAT"
        Me.GDELIVERYAT.Name = "GDELIVERYAT"
        Me.GDELIVERYAT.Visible = True
        Me.GDELIVERYAT.VisibleIndex = 13
        Me.GDELIVERYAT.Width = 150
        '
        'GRCM
        '
        Me.GRCM.Caption = "RCM"
        Me.GRCM.FieldName = "RCM"
        Me.GRCM.Name = "GRCM"
        Me.GRCM.Visible = True
        Me.GRCM.VisibleIndex = 14
        Me.GRCM.Width = 40
        '
        'GBILLAMT
        '
        Me.GBILLAMT.Caption = "Bill Amt."
        Me.GBILLAMT.DisplayFormat.FormatString = "0.00"
        Me.GBILLAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBILLAMT.FieldName = "BILLAMT"
        Me.GBILLAMT.Name = "GBILLAMT"
        Me.GBILLAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBILLAMT.Visible = True
        Me.GBILLAMT.VisibleIndex = 15
        Me.GBILLAMT.Width = 80
        '
        'GCHGS
        '
        Me.GCHGS.Caption = "Charges"
        Me.GCHGS.DisplayFormat.FormatString = "0.00"
        Me.GCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHGS.FieldName = "CHGS"
        Me.GCHGS.Name = "GCHGS"
        Me.GCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCHGS.Visible = True
        Me.GCHGS.VisibleIndex = 16
        Me.GCHGS.Width = 80
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.Caption = "GSUBTOTAL"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 17
        Me.GSUBTOTAL.Width = 80
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "Total CGST Amt."
        Me.GCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMT.FieldName = "TOTALCGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 18
        Me.GCGSTAMT.Width = 80
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "Total SGST Amt."
        Me.GSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMT.FieldName = "TOTALSGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 19
        Me.GSGSTAMT.Width = 80
        '
        'GTOTALIGSTAMT
        '
        Me.GTOTALIGSTAMT.Caption = "Total IGST Amt."
        Me.GTOTALIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALIGSTAMT.FieldName = "TOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Name = "GTOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALIGSTAMT.Visible = True
        Me.GTOTALIGSTAMT.VisibleIndex = 20
        Me.GTOTALIGSTAMT.Width = 80
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Round Off"
        Me.GROUNDOFF.DisplayFormat.FormatString = "0.00"
        Me.GROUNDOFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 21
        Me.GROUNDOFF.Width = 70
        '
        'GAMT
        '
        Me.GAMT.Caption = "Total"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 22
        Me.GAMT.Width = 100
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 23
        Me.GREMARKS.Width = 275
        '
        'GNOGSTR1
        '
        Me.GNOGSTR1.Caption = "No Gstr1"
        Me.GNOGSTR1.FieldName = "NOGSTR1"
        Me.GNOGSTR1.Name = "GNOGSTR1"
        Me.GNOGSTR1.Visible = True
        Me.GNOGSTR1.VisibleIndex = 25
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 549)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 1
        Me.CMDOK.Text = "&Edit"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 549)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 2
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(1006, 33)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(216, 23)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(950, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 321
        Me.Label1.Text = "Register"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2, Me.TOOLMAIL, Me.TOOLWHATSAPP, Me.PrintToolStripButton, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.PROTRADE.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Credit Note Directly"
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.PROTRADE.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "Whatsapp Cedit Note Directly"
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(21, 41)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(165, 15)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select a Credit Note to Change"
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Graoup Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 24
        Me.GGROUPNAME.Width = 100
        '
        'CreditNoteDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CreditNoteDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Credit Note Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridCN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridCN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GDEBITNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNITEMDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRCM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAGENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNOGSTR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
    Friend WithEvents GDELIVERYAT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
