<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectGRNforDO
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
        Me.cmdok = New System.Windows.Forms.Button()
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GTRANSPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(537, 527)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 4
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.APPROXDATE.Name = "APPROXDATE"
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 11
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "GRIDSRNO"
        Me.GGRIDSRNO.FieldName = "SRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'GGRIDTYPE
        '
        Me.GGRIDTYPE.Caption = "GRIDTYPE"
        Me.GGRIDTYPE.FieldName = "GRIDTYPE"
        Me.GGRIDTYPE.Name = "GGRIDTYPE"
        Me.GGRIDTYPE.OptionsColumn.AllowEdit = False
        Me.GGRIDTYPE.OptionsColumn.ReadOnly = True
        '
        'GLRDATE
        '
        Me.GLRDATE.Caption = "LR/DO Date"
        Me.GLRDATE.FieldName = "LRDATE"
        Me.GLRDATE.Name = "GLRDATE"
        Me.GLRDATE.OptionsColumn.AllowEdit = False
        Me.GLRDATE.OptionsColumn.ReadOnly = True
        Me.GLRDATE.Visible = True
        Me.GLRDATE.VisibleIndex = 10
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR/DO No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.OptionsColumn.AllowEdit = False
        Me.GLRNO.OptionsColumn.ReadOnly = True
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 9
        '
        'GCONES
        '
        Me.GCONES.Caption = "Cones"
        Me.GCONES.DisplayFormat.FormatString = "0"
        Me.GCONES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCONES.FieldName = "CONES"
        Me.GCONES.Name = "GCONES"
        Me.GCONES.OptionsColumn.AllowEdit = False
        Me.GCONES.Visible = True
        Me.GCONES.VisibleIndex = 8
        Me.GCONES.Width = 60
        '
        'TOTALWT
        '
        Me.TOTALWT.Caption = "Wt"
        Me.TOTALWT.FieldName = "WT"
        Me.TOTALWT.Name = "TOTALWT"
        Me.TOTALWT.OptionsColumn.AllowEdit = False
        Me.TOTALWT.OptionsColumn.ReadOnly = True
        Me.TOTALWT.Visible = True
        Me.TOTALWT.VisibleIndex = 7
        Me.TOTALWT.Width = 65
        '
        'GTOTALBAGS
        '
        Me.GTOTALBAGS.Caption = "Bags"
        Me.GTOTALBAGS.FieldName = "BAGS"
        Me.GTOTALBAGS.Name = "GTOTALBAGS"
        Me.GTOTALBAGS.OptionsColumn.AllowEdit = False
        Me.GTOTALBAGS.OptionsColumn.ReadOnly = True
        Me.GTOTALBAGS.Visible = True
        Me.GTOTALBAGS.VisibleIndex = 6
        Me.GTOTALBAGS.Width = 60
        '
        'GCOUNT
        '
        Me.GCOUNT.Caption = "Count"
        Me.GCOUNT.FieldName = "COUNT"
        Me.GCOUNT.Name = "GCOUNT"
        Me.GCOUNT.OptionsColumn.AllowEdit = False
        Me.GCOUNT.OptionsColumn.ReadOnly = True
        Me.GCOUNT.Width = 60
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(623, 527)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.OptionsColumn.ReadOnly = True
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 5
        Me.GQUALITY.Width = 110
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.OptionsColumn.AllowEdit = False
        Me.GMILLNAME.OptionsColumn.ReadOnly = True
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 4
        Me.GMILLNAME.Width = 250
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.OptionsColumn.ReadOnly = True
        Me.GGODOWN.Width = 120
        '
        'GPARTYNAME
        '
        Me.GPARTYNAME.Caption = "Name"
        Me.GPARTYNAME.FieldName = "NAME"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.OptionsColumn.AllowEdit = False
        Me.GPARTYNAME.OptionsColumn.ReadOnly = True
        Me.GPARTYNAME.Visible = True
        Me.GPARTYNAME.VisibleIndex = 3
        Me.GPARTYNAME.Width = 250
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.OptionsColumn.ReadOnly = True
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'GGRNNO
        '
        Me.GGRNNO.Caption = "Sr No."
        Me.GGRNNO.FieldName = "NO"
        Me.GGRNNO.Name = "GGRNNO"
        Me.GGRNNO.OptionsColumn.AllowEdit = False
        Me.GGRNNO.OptionsColumn.ReadOnly = True
        Me.GGRNNO.Visible = True
        Me.GGRNNO.VisibleIndex = 1
        Me.GGRNNO.Width = 50
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GGRNNO, Me.GDATE, Me.GPARTYNAME, Me.GGODOWN, Me.GMILLNAME, Me.GTRANSPORT, Me.GQUALITY, Me.GCOUNT, Me.GTOTALBAGS, Me.TOTALWT, Me.GCONES, Me.GLRNO, Me.GLRDATE, Me.GGRIDTYPE, Me.GGRIDSRNO, Me.GCOLOR})
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
        'GTRANSPORT
        '
        Me.GTRANSPORT.Caption = "Transport"
        Me.GTRANSPORT.FieldName = "TRANSPORT"
        Me.GTRANSPORT.Name = "GTRANSPORT"
        Me.GTRANSPORT.OptionsColumn.AllowEdit = False
        Me.GTRANSPORT.OptionsColumn.ReadOnly = True
        Me.GTRANSPORT.Width = 150
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(10, 33)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1221, 488)
        Me.gridbilldetails.TabIndex = 649
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SaddleBrown
        Me.Label1.Location = New System.Drawing.Point(24, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 26)
        Me.Label1.TabIndex = 650
        Me.Label1.Text = "Select Stock"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 3
        '
        'SelectGRNforDO
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SelectGRNforDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SelectGRNforDO"
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

    Friend WithEvents cmdok As Button
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GTRANSPORT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label1 As Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
