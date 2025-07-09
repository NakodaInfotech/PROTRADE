<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignMasterDetail
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
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDADDNEW = New System.Windows.Forms.Button()
        Me.CMDEDIT = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALERATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFABRIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDYEING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBWORK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINISHING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCADNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(383, 542)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 331
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'CMDADDNEW
        '
        Me.CMDADDNEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDADDNEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDADDNEW.FlatAppearance.BorderSize = 0
        Me.CMDADDNEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADDNEW.ForeColor = System.Drawing.Color.Black
        Me.CMDADDNEW.Location = New System.Drawing.Point(297, 542)
        Me.CMDADDNEW.Name = "CMDADDNEW"
        Me.CMDADDNEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDADDNEW.TabIndex = 330
        Me.CMDADDNEW.Text = "&Add New"
        Me.CMDADDNEW.UseVisualStyleBackColor = False
        '
        'CMDEDIT
        '
        Me.CMDEDIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEDIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEDIT.FlatAppearance.BorderSize = 0
        Me.CMDEDIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEDIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEDIT.Location = New System.Drawing.Point(469, 542)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 329
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(555, 542)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 328
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(12, 37)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(982, 499)
        Me.GRIDBILLDETAILS.TabIndex = 326
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GPURRATE, Me.GSALERATE, Me.GWRATE, Me.GITEMNAME, Me.GFABRIC, Me.GDYEING, Me.GJOBWORK, Me.GFINISHING, Me.GEXTRA, Me.GTOTAL, Me.GCADNO, Me.GMILLNAME})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Design No"
        Me.GNAME.FieldName = "DESIGNNO"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 150
        '
        'GPURRATE
        '
        Me.GPURRATE.Caption = "Purchase Rate"
        Me.GPURRATE.DisplayFormat.FormatString = "0.00"
        Me.GPURRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURRATE.FieldName = "PURRATE"
        Me.GPURRATE.Name = "GPURRATE"
        Me.GPURRATE.Visible = True
        Me.GPURRATE.VisibleIndex = 3
        Me.GPURRATE.Width = 100
        '
        'GSALERATE
        '
        Me.GSALERATE.Caption = "Sale Rate"
        Me.GSALERATE.DisplayFormat.FormatString = "0.00"
        Me.GSALERATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSALERATE.FieldName = "SALERATE"
        Me.GSALERATE.Name = "GSALERATE"
        Me.GSALERATE.Visible = True
        Me.GSALERATE.VisibleIndex = 4
        Me.GSALERATE.Width = 100
        '
        'GWRATE
        '
        Me.GWRATE.Caption = "W. Rate"
        Me.GWRATE.DisplayFormat.FormatString = "0.00"
        Me.GWRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWRATE.FieldName = "WRATE"
        Me.GWRATE.Name = "GWRATE"
        Me.GWRATE.Visible = True
        Me.GWRATE.VisibleIndex = 5
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Width = 200
        '
        'GFABRIC
        '
        Me.GFABRIC.Caption = "Fabric"
        Me.GFABRIC.DisplayFormat.FormatString = "0.00"
        Me.GFABRIC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFABRIC.FieldName = "FABRIC"
        Me.GFABRIC.Name = "GFABRIC"
        '
        'GDYEING
        '
        Me.GDYEING.Caption = "Dyeing"
        Me.GDYEING.DisplayFormat.FormatString = "0.00"
        Me.GDYEING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDYEING.FieldName = "DYEING"
        Me.GDYEING.Name = "GDYEING"
        '
        'GJOBWORK
        '
        Me.GJOBWORK.Caption = "Job Work"
        Me.GJOBWORK.DisplayFormat.FormatString = "0.00"
        Me.GJOBWORK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GJOBWORK.FieldName = "JOBWORK"
        Me.GJOBWORK.Name = "GJOBWORK"
        '
        'GFINISHING
        '
        Me.GFINISHING.Caption = "Finishing"
        Me.GFINISHING.DisplayFormat.FormatString = "0.00"
        Me.GFINISHING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFINISHING.FieldName = "FINISHING"
        Me.GFINISHING.Name = "GFINISHING"
        '
        'GEXTRA
        '
        Me.GEXTRA.Caption = "Extra"
        Me.GEXTRA.DisplayFormat.FormatString = "0.00"
        Me.GEXTRA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRA.FieldName = "EXTRA"
        Me.GEXTRA.Name = "GEXTRA"
        '
        'GTOTAL
        '
        Me.GTOTAL.Caption = "Total"
        Me.GTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTAL.FieldName = "TOTAL"
        Me.GTOTAL.Name = "GTOTAL"
        '
        'GCADNO
        '
        Me.GCADNO.Caption = "CAD No"
        Me.GCADNO.FieldName = "CADNO"
        Me.GCADNO.Name = "GCADNO"
        Me.GCADNO.Visible = True
        Me.GCADNO.VisibleIndex = 1
        Me.GCADNO.Width = 100
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1006, 25)
        Me.ToolStrip1.TabIndex = 327
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDADDNEW)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1006, 581)
        Me.BlendPanel1.TabIndex = 332
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 2
        '
        'DesignMasterDetail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1006, 581)
        Me.Controls.Add(Me.GRIDBILLDETAILS)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignMasterDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Master Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents CMDADDNEW As System.Windows.Forms.Button
    Friend WithEvents CMDEDIT As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSALERATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GFABRIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDYEING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBWORK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINISHING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCADNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
