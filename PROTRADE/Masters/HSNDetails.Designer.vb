<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HSNDetails
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDADDNEW = New System.Windows.Forms.Button()
        Me.CMDEDIT = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGST1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGST1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGST1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXPORTCGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXPORTSGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXPORTIGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1239, 25)
        Me.ToolStrip1.TabIndex = 318
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
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1239, 581)
        Me.BlendPanel1.TabIndex = 4
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(536, 541)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 325
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
        Me.CMDADDNEW.Location = New System.Drawing.Point(450, 541)
        Me.CMDADDNEW.Name = "CMDADDNEW"
        Me.CMDADDNEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDADDNEW.TabIndex = 324
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
        Me.CMDEDIT.Location = New System.Drawing.Point(622, 541)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 323
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
        Me.CMDEXIT.Location = New System.Drawing.Point(708, 541)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 322
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(18, 45)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(1223, 490)
        Me.GRIDBILLDETAILS.TabIndex = 315
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GID, Me.GTYPE, Me.GCODE, Me.GITEMDESC, Me.GDATE, Me.GRATE, Me.GCGST, Me.GSGST, Me.GIGST, Me.GRATE1, Me.GCGST1, Me.GSGST1, Me.GIGST1, Me.GEXPORTCGST, Me.GEXPORTSGST, Me.GEXPORTIGST})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GID
        '
        Me.GID.Caption = "ID"
        Me.GID.DisplayFormat.FormatString = "0"
        Me.GID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GID.FieldName = "ID"
        Me.GID.ImageIndex = 1
        Me.GID.Name = "GID"
        Me.GID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.ImageIndex = 0
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 0
        '
        'GCODE
        '
        Me.GCODE.Caption = "HSN Code"
        Me.GCODE.FieldName = "CODE"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.Visible = True
        Me.GCODE.VisibleIndex = 1
        Me.GCODE.Width = 100
        '
        'GITEMDESC
        '
        Me.GITEMDESC.Caption = "Item Description"
        Me.GITEMDESC.FieldName = "ITEMDESC"
        Me.GITEMDESC.Name = "GITEMDESC"
        Me.GITEMDESC.Visible = True
        Me.GITEMDESC.VisibleIndex = 2
        Me.GITEMDESC.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "GRIDRATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 3
        '
        'GCGST
        '
        Me.GCGST.Caption = "CGST"
        Me.GCGST.FieldName = "GRIDCGST"
        Me.GCGST.Name = "GCGST"
        Me.GCGST.Visible = True
        Me.GCGST.VisibleIndex = 5
        '
        'GSGST
        '
        Me.GSGST.Caption = "SGST"
        Me.GSGST.FieldName = "GRIDSGST"
        Me.GSGST.Name = "GSGST"
        Me.GSGST.Visible = True
        Me.GSGST.VisibleIndex = 6
        '
        'GIGST
        '
        Me.GIGST.Caption = "IGST"
        Me.GIGST.FieldName = "GRIDIGST"
        Me.GIGST.Name = "GIGST"
        Me.GIGST.Visible = True
        Me.GIGST.VisibleIndex = 7
        '
        'GRATE1
        '
        Me.GRATE1.Caption = "Rate1"
        Me.GRATE1.DisplayFormat.FormatString = "0.00"
        Me.GRATE1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE1.FieldName = "GRIDRATE1"
        Me.GRATE1.Name = "GRATE1"
        Me.GRATE1.Visible = True
        Me.GRATE1.VisibleIndex = 8
        '
        'GCGST1
        '
        Me.GCGST1.Caption = "CGST1"
        Me.GCGST1.DisplayFormat.FormatString = "0.00"
        Me.GCGST1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGST1.FieldName = "GRIDCGST1"
        Me.GCGST1.Name = "GCGST1"
        Me.GCGST1.Visible = True
        Me.GCGST1.VisibleIndex = 9
        '
        'GSGST1
        '
        Me.GSGST1.Caption = "SGST1"
        Me.GSGST1.DisplayFormat.FormatString = "0.00"
        Me.GSGST1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGST1.FieldName = "GRIDSGST1"
        Me.GSGST1.Name = "GSGST1"
        Me.GSGST1.Visible = True
        Me.GSGST1.VisibleIndex = 10
        '
        'GIGST1
        '
        Me.GIGST1.Caption = "IGST1"
        Me.GIGST1.DisplayFormat.FormatString = "0.00"
        Me.GIGST1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGST1.FieldName = "GRIDIGST1"
        Me.GIGST1.Name = "GIGST1"
        Me.GIGST1.Visible = True
        Me.GIGST1.VisibleIndex = 11
        '
        'GEXPORTCGST
        '
        Me.GEXPORTCGST.Caption = "EXPORTCGST"
        Me.GEXPORTCGST.DisplayFormat.FormatString = "0.00"
        Me.GEXPORTCGST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXPORTCGST.FieldName = "GRIDEXPCGST"
        Me.GEXPORTCGST.Name = "GEXPORTCGST"
        Me.GEXPORTCGST.Visible = True
        Me.GEXPORTCGST.VisibleIndex = 12
        '
        'GEXPORTSGST
        '
        Me.GEXPORTSGST.Caption = "EXPORTSGST"
        Me.GEXPORTSGST.DisplayFormat.FormatString = "0.00"
        Me.GEXPORTSGST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXPORTSGST.FieldName = "GRIDEXPSGST"
        Me.GEXPORTSGST.Name = "GEXPORTSGST"
        Me.GEXPORTSGST.Visible = True
        Me.GEXPORTSGST.VisibleIndex = 13
        '
        'GEXPORTIGST
        '
        Me.GEXPORTIGST.Caption = "EXPORTIGST"
        Me.GEXPORTIGST.DisplayFormat.FormatString = "0.00"
        Me.GEXPORTIGST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXPORTIGST.FieldName = "GRIDEXPIGST"
        Me.GEXPORTIGST.Name = "GEXPORTIGST"
        Me.GEXPORTIGST.Visible = True
        Me.GEXPORTIGST.VisibleIndex = 14
        '
        'GDATE
        '
        Me.GDATE.Caption = "W.e.f."
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "WEFDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 4
        '
        'HSNDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1239, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "HSNDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "HSN Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents CMDADDNEW As System.Windows.Forms.Button
    Friend WithEvents CMDEDIT As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGST1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGST1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGST1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXPORTCGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXPORTSGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXPORTIGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
