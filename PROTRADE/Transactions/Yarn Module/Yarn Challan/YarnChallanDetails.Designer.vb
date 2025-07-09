<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnChallanDetails
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
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTONAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYARN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gmill = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gwt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGREYFINISH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 7
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 542)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 651
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
        Me.cmdok.Location = New System.Drawing.Point(534, 542)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 650
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 33)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 503)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GNAME, Me.GPONO, Me.GPODATE, Me.GCHALLAN, Me.GCHALLANDATE, Me.GTONAME, Me.GYARN, Me.gmill, Me.gcolor, Me.GDESIGN, Me.GLOTNO, Me.GLOTDATE, Me.GGODOWN, Me.GQTY, Me.GTOTALQTY, Me.gwt, Me.GTOTALWT, Me.GCONES, Me.GTOTALCONES, Me.GTRANSNAME, Me.GLRNO, Me.GREMARKS, Me.GGREYFINISH})
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
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "YARNNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 55
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "YARNDATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        '
        'GNAME
        '
        Me.GNAME.Caption = "Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 180
        '
        'GPONO
        '
        Me.GPONO.Caption = "PO No."
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 3
        '
        'GPODATE
        '
        Me.GPODATE.Caption = "PO Date"
        Me.GPODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPODATE.FieldName = "PODATE"
        Me.GPODATE.Name = "GPODATE"
        Me.GPODATE.Visible = True
        Me.GPODATE.VisibleIndex = 4
        '
        'GCHALLAN
        '
        Me.GCHALLAN.Caption = "Challan No"
        Me.GCHALLAN.FieldName = "CHALLANNO"
        Me.GCHALLAN.Name = "GCHALLAN"
        Me.GCHALLAN.Visible = True
        Me.GCHALLAN.VisibleIndex = 5
        Me.GCHALLAN.Width = 70
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Challan Dt."
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 6
        '
        'GTONAME
        '
        Me.GTONAME.Caption = "To Name"
        Me.GTONAME.FieldName = "TONAME"
        Me.GTONAME.Name = "GTONAME"
        Me.GTONAME.Visible = True
        Me.GTONAME.VisibleIndex = 7
        Me.GTONAME.Width = 100
        '
        'GYARN
        '
        Me.GYARN.Caption = "Yarn Quality"
        Me.GYARN.FieldName = "YARNQUALITY"
        Me.GYARN.Name = "GYARN"
        Me.GYARN.Visible = True
        Me.GYARN.VisibleIndex = 8
        Me.GYARN.Width = 100
        '
        'gmill
        '
        Me.gmill.Caption = "Mill Name"
        Me.gmill.FieldName = "MILLNAME"
        Me.gmill.Name = "gmill"
        Me.gmill.Visible = True
        Me.gmill.VisibleIndex = 9
        Me.gmill.Width = 100
        '
        'gcolor
        '
        Me.gcolor.Caption = "Color"
        Me.gcolor.FieldName = "COLOR"
        Me.gcolor.Name = "gcolor"
        Me.gcolor.Visible = True
        Me.gcolor.VisibleIndex = 10
        Me.gcolor.Width = 80
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGNNO"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 11
        Me.GDESIGN.Width = 80
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 12
        '
        'GLOTDATE
        '
        Me.GLOTDATE.Caption = "Lot Date"
        Me.GLOTDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GLOTDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GLOTDATE.FieldName = "LOTDATE"
        Me.GLOTDATE.Name = "GLOTDATE"
        Me.GLOTDATE.Visible = True
        Me.GLOTDATE.VisibleIndex = 13
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 14
        Me.GGODOWN.Width = 140
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty."
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 15
        '
        'GTOTALQTY
        '
        Me.GTOTALQTY.Caption = "Total Bags"
        Me.GTOTALQTY.DisplayFormat.FormatString = "0.00"
        Me.GTOTALQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALQTY.FieldName = "TOTALQTY"
        Me.GTOTALQTY.Name = "GTOTALQTY"
        Me.GTOTALQTY.Visible = True
        Me.GTOTALQTY.VisibleIndex = 16
        Me.GTOTALQTY.Width = 60
        '
        'gwt
        '
        Me.gwt.Caption = "Wt."
        Me.gwt.FieldName = "WT"
        Me.gwt.Name = "gwt"
        Me.gwt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gwt.Visible = True
        Me.gwt.VisibleIndex = 17
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt."
        Me.GTOTALWT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 18
        Me.GTOTALWT.Width = 60
        '
        'GCONES
        '
        Me.GCONES.Caption = "Cones"
        Me.GCONES.FieldName = "CONES"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCONES.Visible = True
        Me.GCONES.VisibleIndex = 19
        '
        'GTOTALCONES
        '
        Me.GTOTALCONES.Caption = "Total Cones"
        Me.GTOTALCONES.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCONES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCONES.FieldName = "TOTALCONES"
        Me.GTOTALCONES.Name = "GTOTALCONES"
        Me.GTOTALCONES.Visible = True
        Me.GTOTALCONES.VisibleIndex = 20
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Transport Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        Me.GTRANSNAME.Visible = True
        Me.GTRANSNAME.VisibleIndex = 21
        Me.GTRANSNAME.Width = 150
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR No."
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 22
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 23
        Me.GREMARKS.Width = 180
        '
        'GGREYFINISH
        '
        Me.GGREYFINISH.Caption = "Grey/Finish"
        Me.GGREYFINISH.FieldName = "GREYFINISH"
        Me.GGREYFINISH.Name = "GGREYFINISH"
        Me.GGREYFINISH.Visible = True
        Me.GGREYFINISH.VisibleIndex = 24
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.TOOLREFRESH, Me.PrintToolStripButton, Me.ToolStripSeparator1})
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
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.PROTRADE.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
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
        'YarnChallanDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnChallanDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Challan Details"
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
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTONAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYARN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gmill As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gwt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGREYFINISH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
