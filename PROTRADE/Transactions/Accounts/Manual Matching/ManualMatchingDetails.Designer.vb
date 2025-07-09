<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualMatchingDetails
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
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDMATCH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALADJ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDMATCH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 550)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.Text = "&Edit"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 550)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(15, 35)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.GRIDMATCH
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1215, 509)
        Me.griddetails.TabIndex = 1
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDMATCH})
        '
        'GRIDMATCH
        '
        Me.GRIDMATCH.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDMATCH.Appearance.Row.Options.UseFont = True
        Me.GRIDMATCH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.gname, Me.gdate, Me.GTYPE, Me.GBILLNO, Me.GREGNAME, Me.GBILLINITIALS, Me.GBILLAMT, Me.GBALAMT, Me.GTOTALBAL, Me.GTOTALADJ, Me.GREMARKS})
        Me.GRIDMATCH.GridControl = Me.griddetails
        Me.GRIDMATCH.Name = "GRIDMATCH"
        Me.GRIDMATCH.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDMATCH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDMATCH.OptionsBehavior.Editable = False
        Me.GRIDMATCH.OptionsView.ColumnAutoWidth = False
        Me.GRIDMATCH.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDMATCH.OptionsView.ShowAutoFilterRow = True
        Me.GRIDMATCH.OptionsView.ShowFooter = True
        Me.GRIDMATCH.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr. No"
        Me.GSRNO.FieldName = "MATCHNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 50
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 1
        Me.gname.Width = 210
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 3
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 4
        '
        'GREGNAME
        '
        Me.GREGNAME.Caption = "Reg Name"
        Me.GREGNAME.FieldName = "REGNAME"
        Me.GREGNAME.Name = "GREGNAME"
        Me.GREGNAME.Visible = True
        Me.GREGNAME.VisibleIndex = 5
        Me.GREGNAME.Width = 120
        '
        'GBILLINITIALS
        '
        Me.GBILLINITIALS.Caption = "Bill Initials"
        Me.GBILLINITIALS.FieldName = "BILLINITIALS"
        Me.GBILLINITIALS.Name = "GBILLINITIALS"
        Me.GBILLINITIALS.Visible = True
        Me.GBILLINITIALS.VisibleIndex = 6
        Me.GBILLINITIALS.Width = 120
        '
        'GBILLAMT
        '
        Me.GBILLAMT.Caption = "Bill Amt"
        Me.GBILLAMT.DisplayFormat.FormatString = "0.00"
        Me.GBILLAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBILLAMT.FieldName = "BILLAMT"
        Me.GBILLAMT.Name = "GBILLAMT"
        Me.GBILLAMT.Visible = True
        Me.GBILLAMT.VisibleIndex = 7
        Me.GBILLAMT.Width = 80
        '
        'GBALAMT
        '
        Me.GBALAMT.Caption = "Bal Amt"
        Me.GBALAMT.DisplayFormat.FormatString = "0.00"
        Me.GBALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALAMT.FieldName = "BALAMT"
        Me.GBALAMT.Name = "GBALAMT"
        Me.GBALAMT.Visible = True
        Me.GBALAMT.VisibleIndex = 8
        Me.GBALAMT.Width = 80
        '
        'GTOTALBAL
        '
        Me.GTOTALBAL.Caption = "Total Bal"
        Me.GTOTALBAL.DisplayFormat.FormatString = "0.00"
        Me.GTOTALBAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALBAL.FieldName = "TOTALBAL"
        Me.GTOTALBAL.Name = "GTOTALBAL"
        Me.GTOTALBAL.Visible = True
        Me.GTOTALBAL.VisibleIndex = 9
        Me.GTOTALBAL.Width = 80
        '
        'GTOTALADJ
        '
        Me.GTOTALADJ.Caption = "Total Adj"
        Me.GTOTALADJ.DisplayFormat.FormatString = "0.00"
        Me.GTOTALADJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALADJ.FieldName = "TOTALPAID"
        Me.GTOTALADJ.Name = "GTOTALADJ"
        Me.GTOTALADJ.Visible = True
        Me.GTOTALADJ.VisibleIndex = 10
        Me.GTOTALADJ.Width = 80
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 11
        Me.GREMARKS.Width = 120
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(56, 22)
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
        'ManualMatchingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ManualMatchingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Manual Matching Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDMATCH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDMATCH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALADJ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
End Class
