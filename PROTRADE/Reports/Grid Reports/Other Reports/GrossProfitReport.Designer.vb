<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GrossProfitReport
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
        Me.CMDEXPORT = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSALEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPURAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROSSPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDEXPORT)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1174, 581)
        Me.BlendPanel1.TabIndex = 13
        '
        'CMDEXPORT
        '
        Me.CMDEXPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXPORT.FlatAppearance.BorderSize = 0
        Me.CMDEXPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXPORT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXPORT.Location = New System.Drawing.Point(632, 533)
        Me.CMDEXPORT.Name = "CMDEXPORT"
        Me.CMDEXPORT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXPORT.TabIndex = 805
        Me.CMDEXPORT.Text = "Export"
        Me.CMDEXPORT.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(462, 533)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 802
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(547, 533)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 803
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(22, 34)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.gridbilldetails.Size = New System.Drawing.Size(1130, 489)
        Me.gridbilldetails.TabIndex = 257
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINITIALS, Me.GDATE, Me.GNAME, Me.GSALEAMT, Me.GPURNAME, Me.GPURINITIALS, Me.GPURAMT, Me.GGROSSAMT, Me.GGROSSPER})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GINITIALS
        '
        Me.GINITIALS.Caption = "Invoice No"
        Me.GINITIALS.FieldName = "INITIALS"
        Me.GINITIALS.Name = "GINITIALS"
        Me.GINITIALS.OptionsColumn.AllowEdit = False
        Me.GINITIALS.Visible = True
        Me.GINITIALS.VisibleIndex = 0
        Me.GINITIALS.Width = 100
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 220
        '
        'GSALEAMT
        '
        Me.GSALEAMT.Caption = "Sale Amt"
        Me.GSALEAMT.DisplayFormat.FormatString = "0.00"
        Me.GSALEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSALEAMT.FieldName = "SALEAMT"
        Me.GSALEAMT.Name = "GSALEAMT"
        Me.GSALEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSALEAMT.Visible = True
        Me.GSALEAMT.VisibleIndex = 3
        Me.GSALEAMT.Width = 100
        '
        'GPURNAME
        '
        Me.GPURNAME.Caption = "Pur Name"
        Me.GPURNAME.FieldName = "PURNAME"
        Me.GPURNAME.Name = "GPURNAME"
        Me.GPURNAME.Visible = True
        Me.GPURNAME.VisibleIndex = 4
        Me.GPURNAME.Width = 220
        '
        'GPURINITIALS
        '
        Me.GPURINITIALS.Caption = "Pur Bill No"
        Me.GPURINITIALS.FieldName = "PURINITIALS"
        Me.GPURINITIALS.Name = "GPURINITIALS"
        Me.GPURINITIALS.Visible = True
        Me.GPURINITIALS.VisibleIndex = 5
        Me.GPURINITIALS.Width = 100
        '
        'GPURAMT
        '
        Me.GPURAMT.Caption = "Pur Amt"
        Me.GPURAMT.DisplayFormat.FormatString = "0.00"
        Me.GPURAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPURAMT.FieldName = "PURAMT"
        Me.GPURAMT.Name = "GPURAMT"
        Me.GPURAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPURAMT.Visible = True
        Me.GPURAMT.VisibleIndex = 6
        Me.GPURAMT.Width = 100
        '
        'GGROSSAMT
        '
        Me.GGROSSAMT.Caption = "Gross Amt"
        Me.GGROSSAMT.DisplayFormat.FormatString = "0.00"
        Me.GGROSSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSAMT.FieldName = "GROSSAMT"
        Me.GGROSSAMT.Name = "GGROSSAMT"
        Me.GGROSSAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGROSSAMT.Visible = True
        Me.GGROSSAMT.VisibleIndex = 7
        Me.GGROSSAMT.Width = 85
        '
        'GGROSSPER
        '
        Me.GGROSSPER.Caption = "Gross %"
        Me.GGROSSPER.DisplayFormat.FormatString = "0.00"
        Me.GGROSSPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSPER.FieldName = "GROSSPER"
        Me.GGROSSPER.Name = "GGROSSPER"
        Me.GGROSSPER.Visible = True
        Me.GGROSSPER.VisibleIndex = 8
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GrossProfitReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1174, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GrossProfitReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Gross Profit Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXPORT As Button
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdcancel As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSALEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPURAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
