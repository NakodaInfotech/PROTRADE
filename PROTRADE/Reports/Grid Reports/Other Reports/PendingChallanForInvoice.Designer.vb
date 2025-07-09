<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingChallanForInvoice
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELIVERYAT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GHOLDFORAPPROVAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.BlendPanel2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1046, 554)
        Me.BlendPanel1.TabIndex = 0
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel2.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel2.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Controls.Add(Me.ToolStrip2)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1046, 554)
        Me.BlendPanel2.TabIndex = 257
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(389, 514)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(88, 28)
        Me.CMDSHOWDETAILS.TabIndex = 657
        Me.CMDSHOWDETAILS.Text = "&Show Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(483, 514)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(88, 28)
        Me.CMDREFRESH.TabIndex = 656
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 37)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1034, 468)
        Me.gridbilldetails.TabIndex = 652
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GCHALLAN, Me.GNAME, Me.GDELIVERYAT, Me.GTOTALPCS, Me.GMTRS, Me.GGODOWN, Me.GTOTALBALES, Me.GTOTALAMT, Me.GHOLDFORAPPROVAL})
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
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 80
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
        Me.gdate.Width = 80
        '
        'GCHALLAN
        '
        Me.GCHALLAN.Caption = "Party Challan No"
        Me.GCHALLAN.FieldName = "CHALLANNO"
        Me.GCHALLAN.Name = "GCHALLAN"
        Me.GCHALLAN.Visible = True
        Me.GCHALLAN.VisibleIndex = 2
        Me.GCHALLAN.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Supplier Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 220
        '
        'GDELIVERYAT
        '
        Me.GDELIVERYAT.Caption = "Dispatch To"
        Me.GDELIVERYAT.FieldName = "DELIVERYAT"
        Me.GDELIVERYAT.Name = "GDELIVERYAT"
        Me.GDELIVERYAT.Visible = True
        Me.GDELIVERYAT.VisibleIndex = 4
        Me.GDELIVERYAT.Width = 200
        '
        'GTOTALPCS
        '
        Me.GTOTALPCS.Caption = "Total Pcs."
        Me.GTOTALPCS.DisplayFormat.FormatString = "0"
        Me.GTOTALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALPCS.FieldName = "TOTALPCS"
        Me.GTOTALPCS.Name = "GTOTALPCS"
        Me.GTOTALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALPCS.Visible = True
        Me.GTOTALPCS.VisibleIndex = 5
        Me.GTOTALPCS.Width = 80
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
        Me.GMTRS.VisibleIndex = 6
        Me.GMTRS.Width = 80
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 7
        Me.GGODOWN.Width = 220
        '
        'GTOTALBALES
        '
        Me.GTOTALBALES.Caption = "Total Bales"
        Me.GTOTALBALES.DisplayFormat.FormatString = "0.00"
        Me.GTOTALBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALBALES.FieldName = "TOTALBALES"
        Me.GTOTALBALES.Name = "GTOTALBALES"
        Me.GTOTALBALES.Visible = True
        Me.GTOTALBALES.VisibleIndex = 9
        Me.GTOTALBALES.Width = 80
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amount"
        Me.GTOTALAMT.FieldName = "TOTALAMT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 8
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(577, 514)
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
        Me.ToolStrip2.Size = New System.Drawing.Size(1046, 25)
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
        'GHOLDFORAPPROVAL
        '
        Me.GHOLDFORAPPROVAL.Caption = "Hold"
        Me.GHOLDFORAPPROVAL.FieldName = "HOLDFORAPPROVAL"
        Me.GHOLDFORAPPROVAL.Name = "GHOLDFORAPPROVAL"
        Me.GHOLDFORAPPROVAL.Visible = True
        Me.GHOLDFORAPPROVAL.VisibleIndex = 10
        '
        'PendingChallanForInvoice
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1046, 554)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PendingChallanForInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pending Challan For Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDSHOWDETAILS As Button
    Friend WithEvents GDELIVERYAT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHOLDFORAPPROVAL As DevExpress.XtraGrid.Columns.GridColumn
End Class
