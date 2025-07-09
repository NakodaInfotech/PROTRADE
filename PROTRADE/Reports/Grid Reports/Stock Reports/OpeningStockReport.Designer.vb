<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningStockReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpeningStockReport))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPIECETYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(619, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(535, 550)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 1
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(21, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 14)
        Me.Label14.TabIndex = 649
        Me.Label14.Text = "Type"
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.BackColor = System.Drawing.Color.White
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"INHOUSE", "JOBBERSTOCK"})
        Me.cmbtype.Location = New System.Drawing.Point(55, 30)
        Me.cmbtype.MaxDropDownItems = 14
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(84, 22)
        Me.cmbtype.TabIndex = 0
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 490)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GBARCODE, Me.GLOTNO, Me.GPIECETYPE, Me.GITEM, Me.GQUALITY, Me.GDESIGNNO, Me.GCOLOR, Me.GNAME, Me.GTONAME, Me.GGODOWN, Me.GBILLNO, Me.GCUT, Me.GWT, Me.GPCS, Me.GUNIT, Me.GMTRS, Me.GPURRATE, Me.GPER, Me.GAMT, Me.GOUTPCS, Me.GOUTMTRS, Me.GDONE})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Images = Me.imageList1
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 60
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Bar Code"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 1
        Me.GBARCODE.Width = 110
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOT"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 2
        Me.GLOTNO.Width = 65
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.Caption = "Piece Type"
        Me.GPIECETYPE.FieldName = "PIECETYPE"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.Width = 80
        '
        'GITEM
        '
        Me.GITEM.Caption = "Item"
        Me.GITEM.FieldName = "ITEM"
        Me.GITEM.Name = "GITEM"
        Me.GITEM.Visible = True
        Me.GITEM.VisibleIndex = 3
        Me.GITEM.Width = 110
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 110
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design"
        Me.GDESIGNNO.FieldName = "DESIGN"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 5
        Me.GDESIGNNO.Width = 90
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 6
        Me.GCOLOR.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Purchase Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Width = 200
        '
        'GTONAME
        '
        Me.GTONAME.Caption = "Jobber Name"
        Me.GTONAME.FieldName = "TONAME"
        Me.GTONAME.Name = "GTONAME"
        Me.GTONAME.Visible = True
        Me.GTONAME.VisibleIndex = 7
        Me.GTONAME.Width = 200
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 8
        Me.GGODOWN.Width = 100
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 9
        '
        'GCUT
        '
        Me.GCUT.Caption = "Cut"
        Me.GCUT.DisplayFormat.FormatString = "0.00"
        Me.GCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUT.FieldName = "CUT"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.Width = 50
        '
        'GWT
        '
        Me.GWT.Caption = "WT"
        Me.GWT.DisplayFormat.FormatString = "0.00"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Width = 50
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 10
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs."
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 10
        Me.GMTRS.Width = 80
        '
        'GPURRATE
        '
        Me.GPURRATE.Caption = "Purchase Rate"
        Me.GPURRATE.FieldName = "RATE"
        Me.GPURRATE.Name = "GPURRATE"
        Me.GPURRATE.Visible = True
        Me.GPURRATE.VisibleIndex = 11
        '
        'GPER
        '
        Me.GPER.Caption = "Per"
        Me.GPER.FieldName = "PER"
        Me.GPER.Name = "GPER"
        Me.GPER.Visible = True
        Me.GPER.VisibleIndex = 12
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.FieldName = "AMOUNT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 13
        '
        'GOUTPCS
        '
        Me.GOUTPCS.Caption = "OUTPCS"
        Me.GOUTPCS.FieldName = "OUTPCS"
        Me.GOUTPCS.Name = "GOUTPCS"
        '
        'GOUTMTRS
        '
        Me.GOUTMTRS.Caption = "OUTMTRS"
        Me.GOUTMTRS.FieldName = "OUTMTRS"
        Me.GOUTMTRS.Name = "GOUTMTRS"
        '
        'GDONE
        '
        Me.GDONE.Caption = "Done"
        Me.GDONE.FieldName = "DONE"
        Me.GDONE.Name = "GDONE"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton})
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
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.ImageIndex = 0
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 7
        Me.GDESIGN.Width = 80
        '
        'OpeningStockReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningStockReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Stock Repot"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GPIECETYPE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GITEM As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GTONAME As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCUT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
End Class
