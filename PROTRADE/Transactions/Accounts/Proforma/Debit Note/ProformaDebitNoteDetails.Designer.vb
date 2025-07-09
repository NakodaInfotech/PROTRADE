<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProformaDebitNoteDetails
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
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridDN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYBILLDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAGENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNITEMDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALEREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCREDITNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTR1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdprint = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmdprint)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(23, 64)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridDN
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1199, 480)
        Me.griddetails.TabIndex = 1
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridDN})
        '
        'gridDN
        '
        Me.gridDN.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDN.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridDN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDN.Appearance.Row.Options.UseFont = True
        Me.gridDN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GBILLNO, Me.GNAME, Me.GGSTIN, Me.GPARTYBILLNO, Me.GPARTYBILLDATE, Me.GAGENT, Me.GSTATENAME, Me.GSTATECODE, Me.GHSNITEMDESC, Me.GHSNCODE, Me.GSALEREFNO, Me.GCREDITNAME, Me.GBILLAMT, Me.GCHGS, Me.GSUBTOTAL, Me.GTOTALCGSTAMT, Me.GTOTALSGSTAMT, Me.GTOTALIGSTAMT, Me.GROUNDOFF, Me.GAMT, Me.GREMARKS, Me.GGSTR1})
        Me.gridDN.GridControl = Me.griddetails
        Me.gridDN.Name = "gridDN"
        Me.gridDN.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridDN.OptionsBehavior.Editable = False
        Me.gridDN.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridDN.OptionsSelection.MultiSelect = True
        Me.gridDN.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridDN.OptionsView.ColumnAutoWidth = False
        Me.gridDN.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridDN.OptionsView.ShowAutoFilterRow = True
        Me.gridDN.OptionsView.ShowFooter = True
        Me.gridDN.OptionsView.ShowGroupPanel = False
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
        Me.GDATE.Width = 80
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.ImageIndex = 1
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 3
        Me.GBILLNO.Width = 90
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
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 5
        Me.GGSTIN.Width = 100
        '
        'GPARTYBILLNO
        '
        Me.GPARTYBILLNO.Caption = "Party Bill No"
        Me.GPARTYBILLNO.FieldName = "PARTYBILLNO"
        Me.GPARTYBILLNO.Name = "GPARTYBILLNO"
        Me.GPARTYBILLNO.Visible = True
        Me.GPARTYBILLNO.VisibleIndex = 6
        '
        'GPARTYBILLDATE
        '
        Me.GPARTYBILLDATE.Caption = "Bill Date"
        Me.GPARTYBILLDATE.FieldName = "PARTYBILLDATE"
        Me.GPARTYBILLDATE.Name = "GPARTYBILLDATE"
        Me.GPARTYBILLDATE.Visible = True
        Me.GPARTYBILLDATE.VisibleIndex = 7
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
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 8
        Me.GSTATENAME.Width = 80
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 10
        Me.GSTATECODE.Width = 40
        '
        'GHSNITEMDESC
        '
        Me.GHSNITEMDESC.Caption = "Service Desc."
        Me.GHSNITEMDESC.FieldName = "HSNITEMDESC"
        Me.GHSNITEMDESC.Name = "GHSNITEMDESC"
        Me.GHSNITEMDESC.Visible = True
        Me.GHSNITEMDESC.VisibleIndex = 11
        Me.GHSNITEMDESC.Width = 80
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "SAC Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 12
        Me.GHSNCODE.Width = 60
        '
        'GSALEREFNO
        '
        Me.GSALEREFNO.Caption = "Sale Ref No"
        Me.GSALEREFNO.FieldName = "SALEREFNO"
        Me.GSALEREFNO.Name = "GSALEREFNO"
        Me.GSALEREFNO.Visible = True
        Me.GSALEREFNO.VisibleIndex = 13
        '
        'GCREDITNAME
        '
        Me.GCREDITNAME.Caption = "Credit Name"
        Me.GCREDITNAME.FieldName = "CREDITNAME"
        Me.GCREDITNAME.Name = "GCREDITNAME"
        Me.GCREDITNAME.Visible = True
        Me.GCREDITNAME.VisibleIndex = 14
        Me.GCREDITNAME.Width = 150
        '
        'GBILLAMT
        '
        Me.GBILLAMT.Caption = "Bill Amt."
        Me.GBILLAMT.FieldName = "BILLAMT"
        Me.GBILLAMT.Name = "GBILLAMT"
        Me.GBILLAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBILLAMT.Visible = True
        Me.GBILLAMT.VisibleIndex = 15
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
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.Caption = "Sub Total"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 17
        Me.GSUBTOTAL.Width = 80
        '
        'GTOTALCGSTAMT
        '
        Me.GTOTALCGSTAMT.Caption = "Total CGST Amt."
        Me.GTOTALCGSTAMT.FieldName = "TOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Name = "GTOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALCGSTAMT.Visible = True
        Me.GTOTALCGSTAMT.VisibleIndex = 18
        Me.GTOTALCGSTAMT.Width = 80
        '
        'GTOTALSGSTAMT
        '
        Me.GTOTALSGSTAMT.Caption = "Total SGST Amt."
        Me.GTOTALSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALSGSTAMT.FieldName = "TOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Name = "GTOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALSGSTAMT.Visible = True
        Me.GTOTALSGSTAMT.VisibleIndex = 19
        Me.GTOTALSGSTAMT.Width = 80
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
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Roundoff"
        Me.GROUNDOFF.DisplayFormat.FormatString = "0.00"
        Me.GROUNDOFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 21
        Me.GROUNDOFF.Width = 80
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
        Me.GAMT.Width = 120
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 23
        Me.GREMARKS.Width = 310
        '
        'GGSTR1
        '
        Me.GGSTR1.Caption = "GSTR 1"
        Me.GGSTR1.FieldName = "GSTR1"
        Me.GGSTR1.Name = "GGSTR1"
        Me.GGSTR1.Visible = True
        Me.GGSTR1.VisibleIndex = 24
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(503, 548)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
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
        Me.cmdcancel.Location = New System.Drawing.Point(589, 548)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 3
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
        Me.cmbregister.Location = New System.Drawing.Point(848, 35)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(267, 23)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(797, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 321
        Me.Label1.Text = "Register"
        '
        'cmdprint
        '
        Me.cmdprint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdprint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdprint.Location = New System.Drawing.Point(23, 395)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(63, 24)
        Me.cmdprint.TabIndex = 320
        Me.cmdprint.Text = "&Print"
        Me.cmdprint.UseVisualStyleBackColor = True
        Me.cmdprint.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(27, 41)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(161, 15)
        Me.lbl.TabIndex = 319
        Me.lbl.Text = "Select a Debit Note to Change"
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'ProformaDebitNoteDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProformaDebitNoteDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Proforma Debit Note Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridDN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYBILLDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAGENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNITEMDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSALEREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCREDITNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents cmbregister As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdprint As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
End Class
