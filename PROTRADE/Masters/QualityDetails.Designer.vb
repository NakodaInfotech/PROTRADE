<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QualityDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDADDNEW = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDEDIT = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GQUALITYID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPICK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSELVEDGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.BlendPanel2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(896, 623)
        Me.BlendPanel1.TabIndex = 1
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel2.Controls.Add(Me.CMDADDNEW)
        Me.BlendPanel2.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel2.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel2.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel2.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(896, 623)
        Me.BlendPanel2.TabIndex = 333
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(357, 534)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 335
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
        Me.CMDADDNEW.Location = New System.Drawing.Point(271, 534)
        Me.CMDADDNEW.Name = "CMDADDNEW"
        Me.CMDADDNEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDADDNEW.TabIndex = 334
        Me.CMDADDNEW.Text = "&Add New"
        Me.CMDADDNEW.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(529, 534)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 332
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'CMDEDIT
        '
        Me.CMDEDIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEDIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEDIT.FlatAppearance.BorderSize = 0
        Me.CMDEDIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEDIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEDIT.Location = New System.Drawing.Point(443, 534)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 333
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(896, 25)
        Me.ToolStrip1.TabIndex = 328
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Export to Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(3, 29)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(890, 499)
        Me.GRIDBILLDETAILS.TabIndex = 327
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GQUALITYID, Me.GQUALITYNAME, Me.GPROCESS, Me.GREED, Me.GPICK, Me.GCOUNT, Me.GWIDTH, Me.GWARP, Me.GWEFT, Me.GSELVEDGE, Me.GREMARKS})
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
        'GQUALITYID
        '
        Me.GQUALITYID.Caption = "Quality ID"
        Me.GQUALITYID.FieldName = "QUALITYID"
        Me.GQUALITYID.Name = "GQUALITYID"
        Me.GQUALITYID.Visible = True
        Me.GQUALITYID.VisibleIndex = 0
        '
        'GQUALITYNAME
        '
        Me.GQUALITYNAME.Caption = "Quality Name"
        Me.GQUALITYNAME.FieldName = "QUALITY"
        Me.GQUALITYNAME.Name = "GQUALITYNAME"
        Me.GQUALITYNAME.Visible = True
        Me.GQUALITYNAME.VisibleIndex = 1
        Me.GQUALITYNAME.Width = 200
        '
        'GPROCESS
        '
        Me.GPROCESS.Caption = "Process"
        Me.GPROCESS.FieldName = "PROCESS"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.Visible = True
        Me.GPROCESS.VisibleIndex = 2
        Me.GPROCESS.Width = 200
        '
        'GREED
        '
        Me.GREED.Caption = "REED"
        Me.GREED.FieldName = "REED"
        Me.GREED.Name = "GREED"
        Me.GREED.Visible = True
        Me.GREED.VisibleIndex = 3
        Me.GREED.Width = 85
        '
        'GPICK
        '
        Me.GPICK.Caption = "GPICK"
        Me.GPICK.FieldName = "PICK"
        Me.GPICK.Name = "GPICK"
        Me.GPICK.Visible = True
        Me.GPICK.VisibleIndex = 4
        Me.GPICK.Width = 85
        '
        'GCOUNT
        '
        Me.GCOUNT.Caption = "COUNT"
        Me.GCOUNT.FieldName = "COUNT"
        Me.GCOUNT.Name = "GCOUNT"
        Me.GCOUNT.Visible = True
        Me.GCOUNT.VisibleIndex = 5
        Me.GCOUNT.Width = 85
        '
        'GWIDTH
        '
        Me.GWIDTH.Caption = "WIDTH"
        Me.GWIDTH.FieldName = "WIDTH"
        Me.GWIDTH.Name = "GWIDTH"
        Me.GWIDTH.Visible = True
        Me.GWIDTH.VisibleIndex = 6
        Me.GWIDTH.Width = 85
        '
        'GWARP
        '
        Me.GWARP.Caption = "WARP"
        Me.GWARP.FieldName = "WARP"
        Me.GWARP.Name = "GWARP"
        Me.GWARP.Visible = True
        Me.GWARP.VisibleIndex = 7
        Me.GWARP.Width = 85
        '
        'GWEFT
        '
        Me.GWEFT.Caption = "WEFT"
        Me.GWEFT.FieldName = "WEFT"
        Me.GWEFT.Name = "GWEFT"
        Me.GWEFT.Visible = True
        Me.GWEFT.VisibleIndex = 8
        Me.GWEFT.Width = 85
        '
        'GSELVEDGE
        '
        Me.GSELVEDGE.Caption = "SELVEDGE"
        Me.GSELVEDGE.FieldName = "SELVEDGE"
        Me.GSELVEDGE.Name = "GSELVEDGE"
        Me.GSELVEDGE.Visible = True
        Me.GSELVEDGE.VisibleIndex = 10
        Me.GSELVEDGE.Width = 200
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "REMARKS"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 9
        Me.GREMARKS.Width = 200
        '
        'QualityDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(896, 623)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "QualityDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Quality Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents CMDADDNEW As Button
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDEDIT As Button
    Friend WithEvents GQUALITYID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPICK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSELVEDGE As DevExpress.XtraGrid.Columns.GridColumn
End Class
