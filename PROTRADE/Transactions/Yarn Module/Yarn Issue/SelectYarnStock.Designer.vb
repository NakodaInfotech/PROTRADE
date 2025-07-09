<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectYarnStock
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
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCONES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBAGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHK = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gchk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GYARNQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.SELECTALL = New System.Windows.Forms.CheckBox()
        CType(Me.CHK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total Wt"
        Me.GTOTALWT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWT.FieldName = "WT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.OptionsColumn.AllowEdit = False
        Me.GTOTALWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 10
        Me.GTOTALWT.Width = 90
        '
        'GTOTALCONES
        '
        Me.GTOTALCONES.Caption = "Cones"
        Me.GTOTALCONES.DisplayFormat.FormatString = "0"
        Me.GTOTALCONES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCONES.FieldName = "CONES"
        Me.GTOTALCONES.Name = "GTOTALCONES"
        Me.GTOTALCONES.OptionsColumn.AllowEdit = False
        Me.GTOTALCONES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALCONES.Visible = True
        Me.GTOTALCONES.VisibleIndex = 8
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 7
        Me.GLRNO.Width = 100
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 6
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.OptionsColumn.AllowEdit = False
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 5
        Me.GCOLOR.Width = 150
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 4
        Me.GDESIGNNO.Width = 130
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "Mill Name"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.OptionsColumn.AllowEdit = False
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 3
        Me.GMILLNAME.Width = 150
        '
        'GBAGS
        '
        Me.GBAGS.Caption = "Box/Pcs"
        Me.GBAGS.DisplayFormat.FormatString = "0"
        Me.GBAGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBAGS.FieldName = "BAGS"
        Me.GBAGS.Name = "GBAGS"
        Me.GBAGS.Visible = True
        Me.GBAGS.VisibleIndex = 9
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 2
        Me.GCATEGORY.Width = 120
        '
        'CHK
        '
        Me.CHK.AutoHeight = False
        Me.CHK.Name = "CHK"
        Me.CHK.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gchk
        '
        Me.gchk.ColumnEdit = Me.CHK
        Me.gchk.FieldName = "CHK"
        Me.gchk.Name = "gchk"
        Me.gchk.Visible = True
        Me.gchk.VisibleIndex = 0
        Me.gchk.Width = 40
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gchk, Me.GYARNQUALITY, Me.GCATEGORY, Me.GMILLNAME, Me.GDESIGNNO, Me.GCOLOR, Me.GLOTNO, Me.GLRNO, Me.GTOTALCONES, Me.GBAGS, Me.GTOTALWT})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GYARNQUALITY
        '
        Me.GYARNQUALITY.Caption = "Yarn Quality"
        Me.GYARNQUALITY.FieldName = "YARNQUALITY"
        Me.GYARNQUALITY.Name = "GYARNQUALITY"
        Me.GYARNQUALITY.OptionsColumn.AllowEdit = False
        Me.GYARNQUALITY.Visible = True
        Me.GYARNQUALITY.VisibleIndex = 1
        Me.GYARNQUALITY.Width = 200
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(19, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHK})
        Me.gridbilldetails.Size = New System.Drawing.Size(1253, 497)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 521)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 257
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 521)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 2
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.SELECTALL)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 561)
        Me.BlendPanel1.TabIndex = 13
        '
        'SELECTALL
        '
        Me.SELECTALL.AutoSize = True
        Me.SELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.SELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SELECTALL.ForeColor = System.Drawing.Color.Black
        Me.SELECTALL.Location = New System.Drawing.Point(47, 37)
        Me.SELECTALL.Name = "SELECTALL"
        Me.SELECTALL.Size = New System.Drawing.Size(15, 14)
        Me.SELECTALL.TabIndex = 258
        Me.SELECTALL.UseVisualStyleBackColor = False
        '
        'SelectYarnStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectYarnStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Yarn Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CHK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GTOTALCONES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBAGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHK As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents gchk As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GYARNQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents SELECTALL As CheckBox
End Class
