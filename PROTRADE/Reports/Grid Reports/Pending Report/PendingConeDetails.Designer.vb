<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingConeDetails
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
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RBENTERED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.APPROXDATE.Name = "APPROXDATE"
        '
        'GCONES
        '
        Me.GCONES.Caption = "Cones"
        Me.GCONES.DisplayFormat.FormatString = "0"
        Me.GCONES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCONES.FieldName = "CONES"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.Visible = True
        Me.GCONES.VisibleIndex = 7
        '
        'GWT
        '
        Me.GWT.Caption = "Wt"
        Me.GWT.DisplayFormat.FormatString = "0.00"
        Me.GWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 6
        '
        'GBAGS
        '
        Me.GBAGS.Caption = "Bags"
        Me.GBAGS.DisplayFormat.FormatString = "0"
        Me.GBAGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBAGS.FieldName = "BAGS"
        Me.GBAGS.Name = "GBAGS"
        Me.GBAGS.OptionsColumn.AllowEdit = False
        Me.GBAGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBAGS.Visible = True
        Me.GBAGS.VisibleIndex = 5
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR/DO No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.OptionsColumn.AllowEdit = False
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 3
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 200
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.OptionsColumn.AllowEdit = False
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 2
        Me.GMILLNAME.Width = 230
        '
        'GMDDATE
        '
        Me.GMDDATE.Caption = "Date"
        Me.GMDDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GMDDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GMDDATE.FieldName = "DATE"
        Me.GMDDATE.Name = "GMDDATE"
        Me.GMDDATE.OptionsColumn.AllowEdit = False
        Me.GMDDATE.Visible = True
        Me.GMDDATE.VisibleIndex = 1
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "GRIDSRNO"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'GGRNNO
        '
        Me.GGRNNO.Caption = "Sr. No"
        Me.GGRNNO.FieldName = "SRNO"
        Me.GGRNNO.Name = "GGRNNO"
        Me.GGRNNO.OptionsColumn.AllowEdit = False
        Me.GGRNNO.Visible = True
        Me.GGRNNO.VisibleIndex = 0
        Me.GGRNNO.Width = 60
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGRNNO, Me.GGRIDSRNO, Me.GMDDATE, Me.GMILLNAME, Me.GQUALITY, Me.GLRNO, Me.GBAGS, Me.GWT, Me.GCONES})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(24, 35)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(916, 481)
        Me.gridbilldetails.TabIndex = 655
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'RBENTERED
        '
        Me.RBENTERED.AutoSize = True
        Me.RBENTERED.BackColor = System.Drawing.Color.Transparent
        Me.RBENTERED.Location = New System.Drawing.Point(99, 10)
        Me.RBENTERED.Name = "RBENTERED"
        Me.RBENTERED.Size = New System.Drawing.Size(66, 19)
        Me.RBENTERED.TabIndex = 798
        Me.RBENTERED.Text = "Entered"
        Me.RBENTERED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(24, 10)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 797
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(400, 522)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 796
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(315, 522)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 793
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(485, 522)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 794
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
        Me.cmdcancel.Location = New System.Drawing.Point(570, 522)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 795
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RBENTERED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(961, 581)
        Me.BlendPanel1.TabIndex = 11
        '
        'PendingConeDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(961, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PendingConeDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PendingConeDetails"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RBENTERED As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
