<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBeamStock
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBEAMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBEAMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GENDS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAPLINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWTCUT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1134, 662)
        Me.BlendPanel1.TabIndex = 5
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(11, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1111, 606)
        Me.gridbilldetails.TabIndex = 648
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME, Me.GMILLNAME, Me.GBEAMNO, Me.GBEAMNAME, Me.GENDS, Me.GTAPLINE, Me.GCUT, Me.GWT, Me.GWTCUT, Me.GFROMNO, Me.GFROMSRNO, Me.GTYPE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Caption = ""
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(523, 624)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(437, 624)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 57
        '
        'GNAME
        '
        Me.GNAME.Caption = "Sizer Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.OptionsFilter.AllowAutoFilter = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 200
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.OptionsColumn.AllowEdit = False
        Me.GMILLNAME.OptionsFilter.AllowAutoFilter = False
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 2
        Me.GMILLNAME.Width = 200
        '
        'GBEAMNO
        '
        Me.GBEAMNO.Caption = "Beam No."
        Me.GBEAMNO.FieldName = "BEAMNO"
        Me.GBEAMNO.Name = "GBEAMNO"
        Me.GBEAMNO.OptionsColumn.AllowEdit = False
        Me.GBEAMNO.OptionsFilter.AllowAutoFilter = False
        Me.GBEAMNO.Visible = True
        Me.GBEAMNO.VisibleIndex = 3
        '
        'GBEAMNAME
        '
        Me.GBEAMNAME.Caption = "Beam Name"
        Me.GBEAMNAME.FieldName = "BEAMNAME"
        Me.GBEAMNAME.Name = "GBEAMNAME"
        Me.GBEAMNAME.OptionsColumn.AllowEdit = False
        Me.GBEAMNAME.OptionsFilter.AllowAutoFilter = False
        Me.GBEAMNAME.Visible = True
        Me.GBEAMNAME.VisibleIndex = 4
        Me.GBEAMNAME.Width = 150
        '
        'GENDS
        '
        Me.GENDS.Caption = "Ends"
        Me.GENDS.FieldName = "ENDS"
        Me.GENDS.Name = "GENDS"
        Me.GENDS.OptionsColumn.AllowEdit = False
        Me.GENDS.OptionsFilter.AllowAutoFilter = False
        Me.GENDS.Visible = True
        Me.GENDS.VisibleIndex = 5
        '
        'GTAPLINE
        '
        Me.GTAPLINE.Caption = "Tapline"
        Me.GTAPLINE.FieldName = "TAPLINE"
        Me.GTAPLINE.Name = "GTAPLINE"
        Me.GTAPLINE.OptionsColumn.AllowEdit = False
        Me.GTAPLINE.OptionsFilter.AllowAutoFilter = False
        Me.GTAPLINE.Visible = True
        Me.GTAPLINE.VisibleIndex = 6
        '
        'GCUT
        '
        Me.GCUT.Caption = "Cut"
        Me.GCUT.DisplayFormat.FormatString = "0.00"
        Me.GCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUT.FieldName = "CUT"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.OptionsColumn.AllowEdit = False
        Me.GCUT.OptionsFilter.AllowAutoFilter = False
        Me.GCUT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCUT.Visible = True
        Me.GCUT.VisibleIndex = 7
        '
        'GWT
        '
        Me.GWT.Caption = "Weight"
        Me.GWT.DisplayFormat.FormatString = "0.000"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.OptionsColumn.AllowEdit = False
        Me.GWT.OptionsFilter.AllowAutoFilter = False
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 8
        '
        'GWTCUT
        '
        Me.GWTCUT.Caption = "Wt./Cut"
        Me.GWTCUT.DisplayFormat.FormatString = "0.000"
        Me.GWTCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWTCUT.FieldName = "WTCUT"
        Me.GWTCUT.Name = "GWTCUT"
        Me.GWTCUT.OptionsColumn.AllowEdit = False
        Me.GWTCUT.OptionsFilter.AllowAutoFilter = False
        Me.GWTCUT.Visible = True
        Me.GWTCUT.VisibleIndex = 9
        '
        'GFROMNO
        '
        Me.GFROMNO.Caption = "From No."
        Me.GFROMNO.FieldName = "FROMNO"
        Me.GFROMNO.Name = "GFROMNO"
        Me.GFROMNO.OptionsColumn.AllowEdit = False
        Me.GFROMNO.OptionsFilter.AllowAutoFilter = False
        Me.GFROMNO.Width = 60
        '
        'GFROMSRNO
        '
        Me.GFROMSRNO.Caption = "From SRNO"
        Me.GFROMSRNO.FieldName = "FROMSRNO"
        Me.GFROMSRNO.Name = "GFROMSRNO"
        Me.GFROMSRNO.OptionsColumn.AllowEdit = False
        Me.GFROMSRNO.OptionsFilter.AllowAutoFilter = False
        Me.GFROMSRNO.Width = 60
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.OptionsFilter.AllowAutoFilter = False
        '
        'SelectBeamStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1134, 662)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectBeamStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SelectBeamStock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBEAMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBEAMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAPLINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWTCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
End Class
