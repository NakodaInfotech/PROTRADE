<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BeamRecdDetails
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GBEAMRECNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBEAMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBEAMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWTCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBEAM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdone = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKDONE = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDEDIT = New System.Windows.Forms.Button()
        Me.CMDADD = New System.Windows.Forms.Button()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDEDIT)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 582)
        Me.BlendPanel1.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(600, 284)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 801
        Me.Label10.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(42, 544)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(154, 14)
        Me.Label14.TabIndex = 768
        Me.Label14.Text = "Locked (Used in Next Form)"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(20, 42)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKDONE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 474)
        Me.gridbilldetails.TabIndex = 321
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBEAMRECNO, Me.GDATE, Me.GNAME, Me.GMILLNAME, Me.GCHALLANNO, Me.GBEAMNO, Me.GBEAMNAME, Me.GCUT, Me.GWT, Me.GWTCUT, Me.GNARR, Me.GTOTALBEAM, Me.GTOTALCUT, Me.GTOTALWT, Me.gdone})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowRowSizing = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GBEAMRECNO
        '
        Me.GBEAMRECNO.Caption = "Sr. No."
        Me.GBEAMRECNO.FieldName = "BEAMRECNO"
        Me.GBEAMRECNO.Name = "GBEAMRECNO"
        Me.GBEAMRECNO.OptionsColumn.AllowEdit = False
        Me.GBEAMRECNO.Visible = True
        Me.GBEAMRECNO.VisibleIndex = 0
        Me.GBEAMRECNO.Width = 60
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GNAME
        '
        Me.GNAME.Caption = "Sizer Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 220
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.OptionsColumn.AllowEdit = False
        Me.GMILLNAME.Width = 200
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No."
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.OptionsColumn.AllowEdit = False
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 3
        Me.GCHALLANNO.Width = 80
        '
        'GBEAMNO
        '
        Me.GBEAMNO.Caption = "Beam No."
        Me.GBEAMNO.FieldName = "BEAMNO"
        Me.GBEAMNO.Name = "GBEAMNO"
        Me.GBEAMNO.OptionsColumn.AllowEdit = False
        Me.GBEAMNO.Visible = True
        Me.GBEAMNO.VisibleIndex = 4
        Me.GBEAMNO.Width = 80
        '
        'GBEAMNAME
        '
        Me.GBEAMNAME.Caption = "Beam Name"
        Me.GBEAMNAME.FieldName = "BEAMNAME"
        Me.GBEAMNAME.Name = "GBEAMNAME"
        Me.GBEAMNAME.OptionsColumn.AllowEdit = False
        Me.GBEAMNAME.Visible = True
        Me.GBEAMNAME.VisibleIndex = 5
        Me.GBEAMNAME.Width = 160
        '
        'GCUT
        '
        Me.GCUT.Caption = "Cut"
        Me.GCUT.DisplayFormat.FormatString = "0.000"
        Me.GCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUT.FieldName = "CUT"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.OptionsColumn.AllowEdit = False
        Me.GCUT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCUT.Visible = True
        Me.GCUT.VisibleIndex = 6
        '
        'GWT
        '
        Me.GWT.Caption = "Weight"
        Me.GWT.DisplayFormat.FormatString = "0.000"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.OptionsColumn.AllowEdit = False
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 7
        Me.GWT.Width = 80
        '
        'GWTCUT
        '
        Me.GWTCUT.Caption = "Wt./Cut"
        Me.GWTCUT.DisplayFormat.FormatString = "0.000"
        Me.GWTCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWTCUT.FieldName = "WTCUT"
        Me.GWTCUT.Name = "GWTCUT"
        Me.GWTCUT.OptionsColumn.AllowEdit = False
        Me.GWTCUT.Visible = True
        Me.GWTCUT.VisibleIndex = 8
        '
        'GNARR
        '
        Me.GNARR.Caption = "Narration"
        Me.GNARR.FieldName = "NARR"
        Me.GNARR.Name = "GNARR"
        Me.GNARR.OptionsColumn.AllowEdit = False
        Me.GNARR.Visible = True
        Me.GNARR.VisibleIndex = 9
        Me.GNARR.Width = 250
        '
        'GTOTALBEAM
        '
        Me.GTOTALBEAM.Caption = "Total Beam(s)"
        Me.GTOTALBEAM.FieldName = "TOTALBEAM"
        Me.GTOTALBEAM.Name = "GTOTALBEAM"
        Me.GTOTALBEAM.OptionsColumn.AllowEdit = False
        Me.GTOTALBEAM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GTOTALCUT
        '
        Me.GTOTALCUT.Caption = "Total Cut"
        Me.GTOTALCUT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCUT.FieldName = "TOTALCUT"
        Me.GTOTALCUT.Name = "GTOTALCUT"
        Me.GTOTALCUT.OptionsColumn.AllowEdit = False
        Me.GTOTALCUT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt."
        Me.GTOTALWT.DisplayFormat.FormatString = "0.000"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.OptionsColumn.AllowEdit = False
        Me.GTOTALWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        '
        'gdone
        '
        Me.gdone.Caption = "DONE"
        Me.gdone.ColumnEdit = Me.CHKDONE
        Me.gdone.FieldName = "GRIDDONE"
        Me.gdone.Name = "gdone"
        Me.gdone.OptionsColumn.AllowEdit = False
        '
        'CHKDONE
        '
        Me.CHKDONE.AutoHeight = False
        Me.CHKDONE.Name = "CHKDONE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(20, 543)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 17)
        Me.Label15.TabIndex = 767
        Me.Label15.Text = "   "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.EXCELEXPORT})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 3
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
        'EXCELEXPORT
        '
        Me.EXCELEXPORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXCELEXPORT.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.EXCELEXPORT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXCELEXPORT.Name = "EXCELEXPORT"
        Me.EXCELEXPORT.Size = New System.Drawing.Size(23, 22)
        Me.EXCELEXPORT.Text = "&Print"
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(662, 543)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDEDIT
        '
        Me.CMDEDIT.Location = New System.Drawing.Point(577, 543)
        Me.CMDEDIT.Name = "CMDEDIT"
        Me.CMDEDIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEDIT.TabIndex = 1
        Me.CMDEDIT.Text = "&Edit"
        Me.CMDEDIT.UseVisualStyleBackColor = True
        '
        'CMDADD
        '
        Me.CMDADD.Location = New System.Drawing.Point(492, 543)
        Me.CMDADD.Name = "CMDADD"
        Me.CMDADD.Size = New System.Drawing.Size(80, 28)
        Me.CMDADD.TabIndex = 0
        Me.CMDADD.Text = "&Add New"
        Me.CMDADD.UseVisualStyleBackColor = True
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BeamRecdDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "BeamRecdDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "BeamRecdDetails"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKDONE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label14 As Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GBEAMRECNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBEAMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBEAMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWTCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBEAM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdone As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKDONE As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Label15 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDEDIT As Button
    Friend WithEvents CMDADD As Button
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents EXCELEXPORT As ToolStripButton
    Friend WithEvents Label10 As Label
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
