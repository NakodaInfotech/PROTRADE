<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ITC4GridReport
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TBMFGTOJW = New System.Windows.Forms.TabPage()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJWTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGOODSTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGOODSDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TBJWTOMFG = New System.Windows.Forms.TabPage()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.gridbilldetails1 = New DevExpress.XtraGrid.GridControl()
        Me.gridbill1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GGSTIN1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNATUREOFTRANS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGOODSDESC1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUOM1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALQTY1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXABLEAMT1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERSTATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERINVNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERINVDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TBMFGTOJW.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TBJWTOMFG.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.gridbilldetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel2.Controls.Add(Me.TabControl1)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Controls.Add(Me.ToolStrip2)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1184, 561)
        Me.BlendPanel2.TabIndex = 258
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(494, 520)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 659
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TBMFGTOJW)
        Me.TabControl1.Controls.Add(Me.TBJWTOMFG)
        Me.TabControl1.Location = New System.Drawing.Point(12, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1160, 480)
        Me.TabControl1.TabIndex = 657
        '
        'TBMFGTOJW
        '
        Me.TBMFGTOJW.Controls.Add(Me.gridbilldetails)
        Me.TBMFGTOJW.Location = New System.Drawing.Point(4, 24)
        Me.TBMFGTOJW.Name = "TBMFGTOJW"
        Me.TBMFGTOJW.Padding = New System.Windows.Forms.Padding(3)
        Me.TBMFGTOJW.Size = New System.Drawing.Size(1152, 452)
        Me.TBMFGTOJW.TabIndex = 0
        Me.TBMFGTOJW.Text = "MFG TO JW"
        Me.TBMFGTOJW.UseVisualStyleBackColor = True
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(6, 3)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1140, 443)
        Me.gridbilldetails.TabIndex = 652
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGSTIN, Me.GSTATE, Me.GJWTYPE, Me.GCHALLANNO, Me.GCHALLANDATE, Me.GGOODSTYPE, Me.GGOODSDESC, Me.GUOM, Me.GTOTALQTY, Me.GITEMNAME, Me.GTAXABLEAMT, Me.GIGST, Me.GCGST, Me.GSGST, Me.GCESS})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "Gstin"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 8
        '
        'GSTATE
        '
        Me.GSTATE.Caption = "State Name"
        Me.GSTATE.FieldName = "STATE"
        Me.GSTATE.ImageIndex = 0
        Me.GSTATE.Name = "GSTATE"
        Me.GSTATE.Visible = True
        Me.GSTATE.VisibleIndex = 2
        Me.GSTATE.Width = 220
        '
        'GJWTYPE
        '
        Me.GJWTYPE.Caption = "Jwtype"
        Me.GJWTYPE.FieldName = "JWTYPE"
        Me.GJWTYPE.Name = "GJWTYPE"
        Me.GJWTYPE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJWTYPE.Visible = True
        Me.GJWTYPE.VisibleIndex = 3
        Me.GJWTYPE.Width = 80
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Party Challan No"
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 1
        Me.GCHALLANNO.Width = 80
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Date"
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 0
        Me.GCHALLANDATE.Width = 80
        '
        'GGOODSTYPE
        '
        Me.GGOODSTYPE.Caption = "Goods Type"
        Me.GGOODSTYPE.FieldName = "GOODSTYPE"
        Me.GGOODSTYPE.Name = "GGOODSTYPE"
        Me.GGOODSTYPE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGOODSTYPE.Visible = True
        Me.GGOODSTYPE.VisibleIndex = 4
        Me.GGOODSTYPE.Width = 80
        '
        'GGOODSDESC
        '
        Me.GGOODSDESC.Caption = "Goods Desc"
        Me.GGOODSDESC.FieldName = "GOODSDESC"
        Me.GGOODSDESC.Name = "GGOODSDESC"
        Me.GGOODSDESC.Visible = True
        Me.GGOODSDESC.VisibleIndex = 5
        Me.GGOODSDESC.Width = 220
        '
        'GUOM
        '
        Me.GUOM.Caption = "Uom"
        Me.GUOM.FieldName = "UOM"
        Me.GUOM.Name = "GUOM"
        Me.GUOM.Visible = True
        Me.GUOM.VisibleIndex = 7
        Me.GUOM.Width = 80
        '
        'GTOTALQTY
        '
        Me.GTOTALQTY.Caption = "Total Qty"
        Me.GTOTALQTY.DisplayFormat.FormatString = "0.00"
        Me.GTOTALQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALQTY.FieldName = "TOTALQTY"
        Me.GTOTALQTY.Name = "GTOTALQTY"
        Me.GTOTALQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALQTY.Visible = True
        Me.GTOTALQTY.VisibleIndex = 6
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 9
        '
        'GTAXABLEAMT
        '
        Me.GTAXABLEAMT.Caption = "Taxable Amt"
        Me.GTAXABLEAMT.FieldName = "TAXABLEAMT"
        Me.GTAXABLEAMT.Name = "GTAXABLEAMT"
        Me.GTAXABLEAMT.Visible = True
        Me.GTAXABLEAMT.VisibleIndex = 10
        '
        'GIGST
        '
        Me.GIGST.Caption = "Igst"
        Me.GIGST.FieldName = "IGST"
        Me.GIGST.Name = "GIGST"
        Me.GIGST.Visible = True
        Me.GIGST.VisibleIndex = 11
        '
        'GCGST
        '
        Me.GCGST.Caption = "Cgst"
        Me.GCGST.FieldName = "CGST"
        Me.GCGST.Name = "GCGST"
        Me.GCGST.Visible = True
        Me.GCGST.VisibleIndex = 12
        '
        'GSGST
        '
        Me.GSGST.Caption = "Sgst"
        Me.GSGST.FieldName = "SGST"
        Me.GSGST.Name = "GSGST"
        Me.GSGST.Visible = True
        Me.GSGST.VisibleIndex = 13
        '
        'GCESS
        '
        Me.GCESS.Caption = "Cess"
        Me.GCESS.FieldName = "CESS"
        Me.GCESS.Name = "GCESS"
        Me.GCESS.Visible = True
        Me.GCESS.VisibleIndex = 14
        '
        'TBJWTOMFG
        '
        Me.TBJWTOMFG.Controls.Add(Me.gridbilldetails1)
        Me.TBJWTOMFG.Location = New System.Drawing.Point(4, 24)
        Me.TBJWTOMFG.Name = "TBJWTOMFG"
        Me.TBJWTOMFG.Padding = New System.Windows.Forms.Padding(3)
        Me.TBJWTOMFG.Size = New System.Drawing.Size(1152, 452)
        Me.TBJWTOMFG.TabIndex = 1
        Me.TBJWTOMFG.Text = "JW TO MFG"
        Me.TBJWTOMFG.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(580, 519)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 651
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip2.TabIndex = 255
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'gridbilldetails1
        '
        Me.gridbilldetails1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails1.Location = New System.Drawing.Point(6, 5)
        Me.gridbilldetails1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails1.MainView = Me.gridbill1
        Me.gridbilldetails1.Name = "gridbilldetails1"
        Me.gridbilldetails1.Size = New System.Drawing.Size(1140, 443)
        Me.gridbilldetails1.TabIndex = 653
        Me.gridbilldetails1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill1})
        '
        'gridbill1
        '
        Me.gridbill1.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill1.Appearance.Row.Options.UseFont = True
        Me.gridbill1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGSTIN1, Me.GSTATE1, Me.GCHALLANNO1, Me.GCHALLANDATE1, Me.GNATUREOFTRANS, Me.GOTHERCHNO, Me.GOTHERDATE, Me.GOTHERCGSTIN, Me.GOTHERSTATE, Me.GOTHERINVNO, Me.GOTHERINVDATE, Me.GGOODSDESC1, Me.GUOM1, Me.GTOTALQTY1, Me.GTAXABLEAMT1})
        Me.gridbill1.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill1.GridControl = Me.gridbilldetails1
        Me.gridbill1.Name = "gridbill1"
        Me.gridbill1.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill1.OptionsBehavior.Editable = False
        Me.gridbill1.OptionsView.ColumnAutoWidth = False
        Me.gridbill1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill1.OptionsView.ShowAutoFilterRow = True
        Me.gridbill1.OptionsView.ShowFooter = True
        '
        'GGSTIN1
        '
        Me.GGSTIN1.Caption = "Gstin"
        Me.GGSTIN1.FieldName = "GSTIN"
        Me.GGSTIN1.Name = "GGSTIN1"
        Me.GGSTIN1.Visible = True
        Me.GGSTIN1.VisibleIndex = 8
        '
        'GSTATE1
        '
        Me.GSTATE1.Caption = "State Name"
        Me.GSTATE1.FieldName = "STATE"
        Me.GSTATE1.ImageIndex = 0
        Me.GSTATE1.Name = "GSTATE1"
        Me.GSTATE1.Visible = True
        Me.GSTATE1.VisibleIndex = 2
        Me.GSTATE1.Width = 220
        '
        'GNATUREOFTRANS
        '
        Me.GNATUREOFTRANS.Caption = "Nature Of Trans"
        Me.GNATUREOFTRANS.FieldName = "NATUREOFTRANS"
        Me.GNATUREOFTRANS.Name = "GNATUREOFTRANS"
        Me.GNATUREOFTRANS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNATUREOFTRANS.Visible = True
        Me.GNATUREOFTRANS.VisibleIndex = 3
        Me.GNATUREOFTRANS.Width = 80
        '
        'GCHALLANNO1
        '
        Me.GCHALLANNO1.Caption = "Party Challan No"
        Me.GCHALLANNO1.FieldName = "CHALLANNO"
        Me.GCHALLANNO1.Name = "GCHALLANNO1"
        Me.GCHALLANNO1.Visible = True
        Me.GCHALLANNO1.VisibleIndex = 1
        Me.GCHALLANNO1.Width = 80
        '
        'GCHALLANDATE1
        '
        Me.GCHALLANDATE1.Caption = "Date"
        Me.GCHALLANDATE1.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE1.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE1.Name = "GCHALLANDATE1"
        Me.GCHALLANDATE1.Visible = True
        Me.GCHALLANDATE1.VisibleIndex = 0
        Me.GCHALLANDATE1.Width = 80
        '
        'GOTHERCHNO
        '
        Me.GOTHERCHNO.Caption = "Other ChNo"
        Me.GOTHERCHNO.FieldName = "OTHERCHNO"
        Me.GOTHERCHNO.Name = "GOTHERCHNO"
        Me.GOTHERCHNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOTHERCHNO.Visible = True
        Me.GOTHERCHNO.VisibleIndex = 4
        Me.GOTHERCHNO.Width = 80
        '
        'GGOODSDESC1
        '
        Me.GGOODSDESC1.Caption = "Goods Desc"
        Me.GGOODSDESC1.FieldName = "GOODSDESC"
        Me.GGOODSDESC1.Name = "GGOODSDESC1"
        Me.GGOODSDESC1.Visible = True
        Me.GGOODSDESC1.VisibleIndex = 5
        Me.GGOODSDESC1.Width = 220
        '
        'GUOM1
        '
        Me.GUOM1.Caption = "Uom"
        Me.GUOM1.FieldName = "UOM"
        Me.GUOM1.Name = "GUOM1"
        Me.GUOM1.Visible = True
        Me.GUOM1.VisibleIndex = 7
        Me.GUOM1.Width = 80
        '
        'GTOTALQTY1
        '
        Me.GTOTALQTY1.Caption = "Total Qty"
        Me.GTOTALQTY1.DisplayFormat.FormatString = "0.00"
        Me.GTOTALQTY1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALQTY1.FieldName = "TOTALQTY"
        Me.GTOTALQTY1.Name = "GTOTALQTY1"
        Me.GTOTALQTY1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALQTY1.Visible = True
        Me.GTOTALQTY1.VisibleIndex = 6
        '
        'GOTHERDATE
        '
        Me.GOTHERDATE.Caption = "Other Date"
        Me.GOTHERDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GOTHERDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GOTHERDATE.FieldName = "OTHERDATE"
        Me.GOTHERDATE.Name = "GOTHERDATE"
        Me.GOTHERDATE.Visible = True
        Me.GOTHERDATE.VisibleIndex = 9
        '
        'GTAXABLEAMT1
        '
        Me.GTAXABLEAMT1.Caption = "Taxable Amt"
        Me.GTAXABLEAMT1.FieldName = "TAXABLEAMT"
        Me.GTAXABLEAMT1.Name = "GTAXABLEAMT1"
        Me.GTAXABLEAMT1.Visible = True
        Me.GTAXABLEAMT1.VisibleIndex = 10
        '
        'GOTHERCGSTIN
        '
        Me.GOTHERCGSTIN.Caption = "Other CGSTIN"
        Me.GOTHERCGSTIN.FieldName = "OTHERCGSTIN"
        Me.GOTHERCGSTIN.Name = "GOTHERCGSTIN"
        Me.GOTHERCGSTIN.Visible = True
        Me.GOTHERCGSTIN.VisibleIndex = 11
        '
        'GOTHERSTATE
        '
        Me.GOTHERSTATE.Caption = "Other State"
        Me.GOTHERSTATE.FieldName = "OTHERSTATE"
        Me.GOTHERSTATE.Name = "GOTHERSTATE"
        Me.GOTHERSTATE.Visible = True
        Me.GOTHERSTATE.VisibleIndex = 12
        '
        'GOTHERINVNO
        '
        Me.GOTHERINVNO.Caption = "Other Inv No."
        Me.GOTHERINVNO.FieldName = "OTHERINVNO"
        Me.GOTHERINVNO.Name = "GOTHERINVNO"
        Me.GOTHERINVNO.Visible = True
        Me.GOTHERINVNO.VisibleIndex = 13
        '
        'GOTHERINVDATE
        '
        Me.GOTHERINVDATE.Caption = "Other Inv Date"
        Me.GOTHERINVDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GOTHERINVDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GOTHERINVDATE.FieldName = "OTHERINVDATE"
        Me.GOTHERINVDATE.Name = "GOTHERINVDATE"
        Me.GOTHERINVDATE.Visible = True
        Me.GOTHERINVDATE.VisibleIndex = 14
        '
        'ITC4GridReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ITC4GridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ITC4 Grid Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TBMFGTOJW.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TBJWTOMFG.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.gridbilldetails1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TBMFGTOJW As TabPage
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJWTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGOODSTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGOODSDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TBJWTOMFG As TabPage
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCESS As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetails1 As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GGSTIN1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNATUREOFTRANS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO1 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCHALLANDATE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGOODSDESC1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUOM1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALQTY1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMT1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERINVNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERINVDATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
