<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPriceList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemPriceList))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTRATEPER = New System.Windows.Forms.TextBox()
        Me.CMBRATETYPE = New System.Windows.Forms.ComboBox()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTRATEPER)
        Me.BlendPanel1.Controls.Add(Me.CMBRATETYPE)
        Me.BlendPanel1.Controls.Add(Me.cmbcategory)
        Me.BlendPanel1.Controls.Add(Me.lblcategory)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1084, 581)
        Me.BlendPanel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(351, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 14)
        Me.Label1.TabIndex = 330
        Me.Label1.Text = "Rate"
        '
        'TXTRATEPER
        '
        Me.TXTRATEPER.Location = New System.Drawing.Point(463, 31)
        Me.TXTRATEPER.Name = "TXTRATEPER"
        Me.TXTRATEPER.Size = New System.Drawing.Size(74, 23)
        Me.TXTRATEPER.TabIndex = 329
        '
        'CMBRATETYPE
        '
        Me.CMBRATETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBRATETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBRATETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBRATETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRATETYPE.FormattingEnabled = True
        Me.CMBRATETYPE.Items.AddRange(New Object() {"", "RATE2", "RATE3", "RATE4", "RATE5", "RATE6", "RATE7", "RATE8", "RATE9", "RATE10"})
        Me.CMBRATETYPE.Location = New System.Drawing.Point(385, 31)
        Me.CMBRATETYPE.MaxDropDownItems = 14
        Me.CMBRATETYPE.Name = "CMBRATETYPE"
        Me.CMBRATETYPE.Size = New System.Drawing.Size(76, 22)
        Me.CMBRATETYPE.TabIndex = 328
        '
        'cmbcategory
        '
        Me.cmbcategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(103, 31)
        Me.cmbcategory.MaxDropDownItems = 14
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(207, 22)
        Me.cmbcategory.TabIndex = 326
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.Transparent
        Me.lblcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(47, 35)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(53, 14)
        Me.lblcategory.TabIndex = 327
        Me.lblcategory.Text = "Category"
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(502, 541)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 325
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(416, 541)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(588, 541)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 322
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(12, 59)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(1060, 476)
        Me.GRIDBILLDETAILS.TabIndex = 315
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GRATE1, Me.GRATE2, Me.GRATE3, Me.GRATE4, Me.GRATE5, Me.GRATE6, Me.GRATE7, Me.GRATE8, Me.GRATE9, Me.GRATE10})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsCustomization.AllowColumnMoving = False
        Me.GRIDBILL.OptionsCustomization.AllowGroup = False
        Me.GRIDBILL.OptionsCustomization.AllowQuickHideColumns = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Item Name"
        Me.GNAME.FieldName = "ITEMNAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.OptionsColumn.AllowFocus = False
        Me.GNAME.OptionsColumn.ReadOnly = True
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 160
        '
        'GRATE1
        '
        Me.GRATE1.Caption = "RATE1"
        Me.GRATE1.FieldName = "RATE1"
        Me.GRATE1.Name = "GRATE1"
        Me.GRATE1.Visible = True
        Me.GRATE1.VisibleIndex = 1
        Me.GRATE1.Width = 85
        '
        'GRATE2
        '
        Me.GRATE2.Caption = "RATE2"
        Me.GRATE2.FieldName = "RATE2"
        Me.GRATE2.Name = "GRATE2"
        Me.GRATE2.Visible = True
        Me.GRATE2.VisibleIndex = 2
        Me.GRATE2.Width = 85
        '
        'GRATE3
        '
        Me.GRATE3.Caption = "RATE3"
        Me.GRATE3.FieldName = "RATE3"
        Me.GRATE3.Name = "GRATE3"
        Me.GRATE3.Visible = True
        Me.GRATE3.VisibleIndex = 3
        Me.GRATE3.Width = 85
        '
        'GRATE4
        '
        Me.GRATE4.Caption = "RATE4"
        Me.GRATE4.FieldName = "RATE4"
        Me.GRATE4.Name = "GRATE4"
        Me.GRATE4.Visible = True
        Me.GRATE4.VisibleIndex = 4
        Me.GRATE4.Width = 85
        '
        'GRATE5
        '
        Me.GRATE5.Caption = "RATE5"
        Me.GRATE5.FieldName = "RATE5"
        Me.GRATE5.Name = "GRATE5"
        Me.GRATE5.Visible = True
        Me.GRATE5.VisibleIndex = 5
        Me.GRATE5.Width = 85
        '
        'GRATE6
        '
        Me.GRATE6.Caption = "RATE6"
        Me.GRATE6.FieldName = "RATE6"
        Me.GRATE6.Name = "GRATE6"
        Me.GRATE6.Visible = True
        Me.GRATE6.VisibleIndex = 6
        Me.GRATE6.Width = 85
        '
        'GRATE7
        '
        Me.GRATE7.Caption = "RATE7"
        Me.GRATE7.FieldName = "RATE7"
        Me.GRATE7.Name = "GRATE7"
        Me.GRATE7.Visible = True
        Me.GRATE7.VisibleIndex = 7
        Me.GRATE7.Width = 85
        '
        'GRATE8
        '
        Me.GRATE8.Caption = "RATE8"
        Me.GRATE8.FieldName = "RATE8"
        Me.GRATE8.Name = "GRATE8"
        Me.GRATE8.Visible = True
        Me.GRATE8.VisibleIndex = 8
        Me.GRATE8.Width = 85
        '
        'GRATE9
        '
        Me.GRATE9.Caption = "RATE9"
        Me.GRATE9.FieldName = "RATE9"
        Me.GRATE9.Name = "GRATE9"
        Me.GRATE9.Visible = True
        Me.GRATE9.VisibleIndex = 9
        Me.GRATE9.Width = 85
        '
        'GRATE10
        '
        Me.GRATE10.Caption = "RATE10"
        Me.GRATE10.FieldName = "RATE10"
        Me.GRATE10.Name = "GRATE10"
        Me.GRATE10.Visible = True
        Me.GRATE10.VisibleIndex = 10
        Me.GRATE10.Width = 85
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1084, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
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
        'ItemPriceList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1084, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemPriceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Item Price List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GRATE2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbcategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents TXTRATEPER As System.Windows.Forms.TextBox
    Friend WithEvents CMBRATETYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripButton As ToolStripButton
End Class
