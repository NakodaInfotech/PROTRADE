<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnPurchaseOrderDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YarnPurchaseOrderDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBROKER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCRDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMOBILENUMBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMAIL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLGRIDDETAILS = New System.Windows.Forms.ToolStripLabel()
        Me.lbl = New System.Windows.Forms.Label()
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
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 5
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(298, 0)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(50, 22)
        Me.TXTFROM.TabIndex = 798
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(353, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 801
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(263, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 800
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(374, 0)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(52, 22)
        Me.TXTTO.TabIndex = 799
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(464, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 797
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(509, 3)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 796
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 534)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 445
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 534)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 444
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(21, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(1201, 473)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.gsrno, Me.gdate, Me.GDUEDATE, Me.GTRANSNAME, Me.GBROKER, Me.GTYPE, Me.GDISCOUNT, Me.GREFNO, Me.GDELDAYS, Me.GCRDAYS, Me.GNAME, Me.GORDERNO, Me.GBAGS, Me.GWT, Me.GCONES, Me.GMOBILENUMBER, Me.GMAIL, Me.GREMARKS})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
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
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "PONO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        Me.gsrno.Width = 50
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "PODATE"
        Me.gdate.Name = "gdate"
        Me.gdate.OptionsColumn.AllowEdit = False
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        Me.gdate.Width = 70
        '
        'GDUEDATE
        '
        Me.GDUEDATE.Caption = "Due Date"
        Me.GDUEDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDUEDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDUEDATE.FieldName = "DUEDATE"
        Me.GDUEDATE.Name = "GDUEDATE"
        Me.GDUEDATE.OptionsColumn.AllowEdit = False
        Me.GDUEDATE.Visible = True
        Me.GDUEDATE.VisibleIndex = 3
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Transport Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        Me.GTRANSNAME.OptionsColumn.AllowEdit = False
        Me.GTRANSNAME.Visible = True
        Me.GTRANSNAME.VisibleIndex = 4
        '
        'GBROKER
        '
        Me.GBROKER.Caption = "Broker"
        Me.GBROKER.FieldName = "BROKER"
        Me.GBROKER.Name = "GBROKER"
        Me.GBROKER.OptionsColumn.AllowEdit = False
        Me.GBROKER.Visible = True
        Me.GBROKER.VisibleIndex = 5
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "ORDERTYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 6
        '
        'GDISCOUNT
        '
        Me.GDISCOUNT.Caption = "Discount"
        Me.GDISCOUNT.FieldName = "DISCOUNT"
        Me.GDISCOUNT.Name = "GDISCOUNT"
        Me.GDISCOUNT.OptionsColumn.AllowEdit = False
        Me.GDISCOUNT.Visible = True
        Me.GDISCOUNT.VisibleIndex = 7
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Order No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.OptionsColumn.AllowEdit = False
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 8
        '
        'GDELDAYS
        '
        Me.GDELDAYS.Caption = "Del Days"
        Me.GDELDAYS.FieldName = "DELDAYS"
        Me.GDELDAYS.Name = "GDELDAYS"
        Me.GDELDAYS.OptionsColumn.AllowEdit = False
        Me.GDELDAYS.Visible = True
        Me.GDELDAYS.VisibleIndex = 9
        '
        'GCRDAYS
        '
        Me.GCRDAYS.Caption = "Cr Days"
        Me.GCRDAYS.FieldName = "CRDAYS"
        Me.GCRDAYS.Name = "GCRDAYS"
        Me.GCRDAYS.OptionsColumn.AllowEdit = False
        Me.GCRDAYS.Visible = True
        Me.GCRDAYS.VisibleIndex = 10
        '
        'GNAME
        '
        Me.GNAME.Caption = "Supplier Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 11
        Me.GNAME.Width = 200
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No"
        Me.GORDERNO.FieldName = "REFNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.OptionsColumn.AllowEdit = False
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 12
        '
        'GBAGS
        '
        Me.GBAGS.Caption = "Bags"
        Me.GBAGS.DisplayFormat.FormatString = "0"
        Me.GBAGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBAGS.FieldName = "BAGS"
        Me.GBAGS.Name = "GBAGS"
        Me.GBAGS.OptionsColumn.AllowEdit = False
        Me.GBAGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBAGS.Visible = True
        Me.GBAGS.VisibleIndex = 13
        Me.GBAGS.Width = 60
        '
        'GWT
        '
        Me.GWT.Caption = "Wt"
        Me.GWT.DisplayFormat.FormatString = "0.00"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.OptionsColumn.AllowEdit = False
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 14
        '
        'GCONES
        '
        Me.GCONES.Caption = "Cones"
        Me.GCONES.DisplayFormat.FormatString = "0.00"
        Me.GCONES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCONES.FieldName = "CONES"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.OptionsColumn.AllowEdit = False
        Me.GCONES.Visible = True
        Me.GCONES.VisibleIndex = 15
        '
        'GMOBILENUMBER
        '
        Me.GMOBILENUMBER.Caption = "Mobile Number"
        Me.GMOBILENUMBER.FieldName = "MOBILENO"
        Me.GMOBILENUMBER.Name = "GMOBILENUMBER"
        Me.GMOBILENUMBER.OptionsColumn.AllowEdit = False
        Me.GMOBILENUMBER.Visible = True
        Me.GMOBILENUMBER.VisibleIndex = 16
        '
        'GMAIL
        '
        Me.GMAIL.Caption = "G-Mail"
        Me.GMAIL.FieldName = "EMAIL"
        Me.GMAIL.Name = "GMAIL"
        Me.GMAIL.OptionsColumn.AllowEdit = False
        Me.GMAIL.Visible = True
        Me.GMAIL.VisibleIndex = 17
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.TOOLMAIL, Me.PRINTTOOL, Me.TOOLGRIDDETAILS})
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
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
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.PROTRADE.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Challan Directly"
        '
        'PRINTTOOL
        '
        Me.PRINTTOOL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRINTTOOL.Image = CType(resources.GetObject("PRINTTOOL.Image"), System.Drawing.Image)
        Me.PRINTTOOL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PRINTTOOL.Name = "PRINTTOOL"
        Me.PRINTTOOL.Size = New System.Drawing.Size(23, 22)
        Me.PRINTTOOL.Text = "&Print"
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
        Me.lbl.Size = New System.Drawing.Size(128, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a P.O. to Change"
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'YarnPurchaseOrderDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnPurchaseOrderDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Purchase Order Details"
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
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents GCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents PRINTTOOL As ToolStripButton
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TOOLGRIDDETAILS As ToolStripLabel
    Friend WithEvents GDUEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBROKER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISCOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCRDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMOBILENUMBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMAIL As DevExpress.XtraGrid.Columns.GridColumn
End Class
