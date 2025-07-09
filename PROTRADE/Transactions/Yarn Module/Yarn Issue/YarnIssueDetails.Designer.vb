<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YarnIssueDetails
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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gwt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYARN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACHINENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 21
        Me.GREMARKS.Width = 180
        '
        'GLRDATE
        '
        Me.GLRDATE.Caption = "L.R. Date"
        Me.GLRDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GLRDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GLRDATE.FieldName = "LRDATE"
        Me.GLRDATE.Name = "GLRDATE"
        Me.GLRDATE.Visible = True
        Me.GLRDATE.VisibleIndex = 20
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "L.R. No."
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 19
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Transport Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        Me.GTRANSNAME.Visible = True
        Me.GTRANSNAME.VisibleIndex = 18
        Me.GTRANSNAME.Width = 150
        '
        'GTOTALCONES
        '
        Me.GTOTALCONES.Caption = "Total Cones"
        Me.GTOTALCONES.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCONES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCONES.FieldName = "TOTALCONES"
        Me.GTOTALCONES.Name = "GTOTALCONES"
        Me.GTOTALCONES.Visible = True
        Me.GTOTALCONES.VisibleIndex = 17
        '
        'GCONES
        '
        Me.GCONES.Caption = "Cones"
        Me.GCONES.FieldName = "CONES"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCONES.Visible = True
        Me.GCONES.VisibleIndex = 16
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt."
        Me.GTOTALWT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 15
        Me.GTOTALWT.Width = 60
        '
        'gwt
        '
        Me.gwt.Caption = "Wt."
        Me.gwt.FieldName = "WT"
        Me.gwt.Name = "gwt"
        Me.gwt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gwt.Visible = True
        Me.gwt.VisibleIndex = 14
        '
        'GTOTALBAGS
        '
        Me.GTOTALBAGS.Caption = "Total Bags"
        Me.GTOTALBAGS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALBAGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALBAGS.FieldName = "TOTALBAGS"
        Me.GTOTALBAGS.Name = "GTOTALBAGS"
        Me.GTOTALBAGS.Visible = True
        Me.GTOTALBAGS.VisibleIndex = 13
        Me.GTOTALBAGS.Width = 60
        '
        'GBAGS
        '
        Me.GBAGS.Caption = "Bags"
        Me.GBAGS.FieldName = "QTY"
        Me.GBAGS.Name = "GBAGS"
        Me.GBAGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBAGS.Visible = True
        Me.GBAGS.VisibleIndex = 12
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 11
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGNNO"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 9
        '
        'GYARN
        '
        Me.GYARN.Caption = "Yarn Quality"
        Me.GYARN.FieldName = "YARNQUALITY"
        Me.GYARN.Name = "GYARN"
        Me.GYARN.Visible = True
        Me.GYARN.VisibleIndex = 8
        Me.GYARN.Width = 80
        '
        'GMILL
        '
        Me.GMILL.Caption = "Mill Name"
        Me.GMILL.FieldName = "MILLNAME"
        Me.GMILL.Name = "GMILL"
        Me.GMILL.Visible = True
        Me.GMILL.VisibleIndex = 7
        Me.GMILL.Width = 80
        '
        'GPROCESS
        '
        Me.GPROCESS.Caption = "Process Name"
        Me.GPROCESS.FieldName = "PROCESS"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.Visible = True
        Me.GPROCESS.VisibleIndex = 6
        Me.GPROCESS.Width = 100
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
        'GMACHINENO
        '
        Me.GMACHINENO.Caption = "Machine No"
        Me.GMACHINENO.FieldName = "MACHINE"
        Me.GMACHINENO.Name = "GMACHINENO"
        Me.GMACHINENO.Visible = True
        Me.GMACHINENO.VisibleIndex = 4
        Me.GMACHINENO.Width = 120
        '
        'GNAME
        '
        Me.GNAME.Caption = "Jobber Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 180
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 2
        Me.GGODOWN.Width = 140
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 55
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GGODOWN, Me.GNAME, Me.GMACHINENO, Me.GCHALLAN, Me.GPROCESS, Me.GMILL, Me.GYARN, Me.GDESIGN, Me.GCOLOR, Me.GLOTNO, Me.GBAGS, Me.GTOTALBAGS, Me.gwt, Me.GTOTALWT, Me.GCONES, Me.GTOTALCONES, Me.GTRANSNAME, Me.GLRNO, Me.GLRDATE, Me.GREMARKS})
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
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 10
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 510)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
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
        Me.cmdok.Location = New System.Drawing.Point(534, 544)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 650
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
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
        Me.BlendPanel1.TabIndex = 8
        '
        'YarnIssueDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "YarnIssueDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Yarn Issue Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gwt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYARN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMACHINENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
