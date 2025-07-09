<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LiftingDetails
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
        Me.GLIFTDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBBERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GMDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMATDESNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.RBLIFTED = New System.Windows.Forms.RadioButton()
        Me.RBUNLIFTED = New System.Windows.Forms.RadioButton()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GLIFTDATE
        '
        Me.GLIFTDATE.Caption = "Lift Date"
        Me.GLIFTDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GLIFTDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GLIFTDATE.FieldName = "LIFTDATE"
        Me.GLIFTDATE.Name = "GLIFTDATE"
        Me.GLIFTDATE.Visible = True
        Me.GLIFTDATE.VisibleIndex = 9
        Me.GLIFTDATE.Width = 95
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
        Me.GBAGS.VisibleIndex = 8
        Me.GBAGS.Width = 55
        '
        'GJOBBERNAME
        '
        Me.GJOBBERNAME.Caption = "Jobber Name"
        Me.GJOBBERNAME.FieldName = "JOBBERNAME"
        Me.GJOBBERNAME.Name = "GJOBBERNAME"
        Me.GJOBBERNAME.OptionsColumn.AllowEdit = False
        Me.GJOBBERNAME.Visible = True
        Me.GJOBBERNAME.VisibleIndex = 7
        Me.GJOBBERNAME.Width = 160
        '
        'GOURGODOWN
        '
        Me.GOURGODOWN.Caption = "Our Godown"
        Me.GOURGODOWN.FieldName = "OURGODOWN"
        Me.GOURGODOWN.Name = "GOURGODOWN"
        Me.GOURGODOWN.OptionsColumn.AllowEdit = False
        Me.GOURGODOWN.Visible = True
        Me.GOURGODOWN.VisibleIndex = 6
        Me.GOURGODOWN.Width = 110
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Trans Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        Me.GTRANSNAME.OptionsColumn.AllowEdit = False
        Me.GTRANSNAME.Width = 140
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Ware House"
        Me.GGODOWN.FieldName = "WAREHOUSE"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 5
        Me.GGODOWN.Width = 100
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality Name"
        Me.GQUALITY.FieldName = "QUALITYNAME"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 120
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.OptionsColumn.AllowEdit = False
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 3
        Me.GMILLNAME.Width = 210
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR/DO No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.OptionsColumn.AllowEdit = False
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 2
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
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
        'GMATDESNO
        '
        Me.GMATDESNO.Caption = "Sr. No"
        Me.GMATDESNO.FieldName = "SRNO"
        Me.GMATDESNO.Name = "GMATDESNO"
        Me.GMATDESNO.OptionsColumn.AllowEdit = False
        Me.GMATDESNO.Visible = True
        Me.GMATDESNO.VisibleIndex = 0
        Me.GMATDESNO.Width = 60
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GMATDESNO, Me.GGRIDSRNO, Me.GMDDATE, Me.GLRNO, Me.GMILLNAME, Me.GQUALITY, Me.GGODOWN, Me.GTRANSNAME, Me.GOURGODOWN, Me.GJOBBERNAME, Me.GBAGS, Me.GLIFTDATE})
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
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "GRIDSRNO"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(11, 35)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1112, 481)
        Me.gridbilldetails.TabIndex = 655
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'RBLIFTED
        '
        Me.RBLIFTED.AutoSize = True
        Me.RBLIFTED.BackColor = System.Drawing.Color.Transparent
        Me.RBLIFTED.Location = New System.Drawing.Point(87, 10)
        Me.RBLIFTED.Name = "RBLIFTED"
        Me.RBLIFTED.Size = New System.Drawing.Size(55, 19)
        Me.RBLIFTED.TabIndex = 798
        Me.RBLIFTED.Text = "Lifted"
        Me.RBLIFTED.UseVisualStyleBackColor = False
        '
        'RBUNLIFTED
        '
        Me.RBUNLIFTED.AutoSize = True
        Me.RBUNLIFTED.BackColor = System.Drawing.Color.Transparent
        Me.RBUNLIFTED.Checked = True
        Me.RBUNLIFTED.Location = New System.Drawing.Point(12, 10)
        Me.RBUNLIFTED.Name = "RBUNLIFTED"
        Me.RBUNLIFTED.Size = New System.Drawing.Size(69, 19)
        Me.RBUNLIFTED.TabIndex = 797
        Me.RBUNLIFTED.TabStop = True
        Me.RBUNLIFTED.Text = "Unlifted"
        Me.RBUNLIFTED.UseVisualStyleBackColor = False
        '
        'CMDDELETE
        '
        Me.CMDDELETE.BackColor = System.Drawing.Color.Transparent
        Me.CMDDELETE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDELETE.FlatAppearance.BorderSize = 0
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(485, 522)
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
        Me.CMDOK.Location = New System.Drawing.Point(400, 522)
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
        Me.CMDREFRESH.Location = New System.Drawing.Point(570, 522)
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
        Me.cmdcancel.Location = New System.Drawing.Point(655, 522)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 795
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RBLIFTED)
        Me.BlendPanel1.Controls.Add(Me.RBUNLIFTED)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 10
        '
        'LiftingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "LiftingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lifting Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GLIFTDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBBERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GMDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATDESNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents RBLIFTED As RadioButton
    Friend WithEvents RBUNLIFTED As RadioButton
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdcancel As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
