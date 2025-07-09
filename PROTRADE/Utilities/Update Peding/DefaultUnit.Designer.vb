<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefaultUnit
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
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKSELECTUNIT = New System.Windows.Forms.CheckBox()
        Me.gridbilldetailsunit = New DevExpress.XtraGrid.GridControl()
        Me.gridbillunit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHKCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetailsunit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbillunit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTUNIT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetailsunit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(310, 402)
        Me.BlendPanel1.TabIndex = 4
        '
        'CHKSELECTUNIT
        '
        Me.CHKSELECTUNIT.AutoSize = True
        Me.CHKSELECTUNIT.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTUNIT.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTUNIT.Location = New System.Drawing.Point(24, 16)
        Me.CHKSELECTUNIT.Name = "CHKSELECTUNIT"
        Me.CHKSELECTUNIT.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTUNIT.TabIndex = 4
        Me.CHKSELECTUNIT.Text = "Select All"
        Me.CHKSELECTUNIT.UseVisualStyleBackColor = False
        '
        'gridbilldetailsunit
        '
        Me.gridbilldetailsunit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetailsunit.Location = New System.Drawing.Point(18, 37)
        Me.gridbilldetailsunit.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetailsunit.MainView = Me.gridbillunit
        Me.gridbilldetailsunit.Name = "gridbilldetailsunit"
        Me.gridbilldetailsunit.Size = New System.Drawing.Size(286, 319)
        Me.gridbilldetailsunit.TabIndex = 5
        Me.gridbilldetailsunit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbillunit})
        '
        'gridbillunit
        '
        Me.gridbillunit.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbillunit.Appearance.Row.Options.UseFont = True
        Me.gridbillunit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHKCOLOR, Me.GUNIT})
        Me.gridbillunit.GridControl = Me.gridbilldetailsunit
        Me.gridbillunit.Name = "gridbillunit"
        Me.gridbillunit.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbillunit.OptionsView.ColumnAutoWidth = False
        Me.gridbillunit.OptionsView.ShowAutoFilterRow = True
        Me.gridbillunit.OptionsView.ShowGroupPanel = False
        '
        'GCHKCOLOR
        '
        Me.GCHKCOLOR.ColumnEdit = Me.RepositoryItemCheckEdit3
        Me.GCHKCOLOR.FieldName = "CHK"
        Me.GCHKCOLOR.Name = "GCHKCOLOR"
        Me.GCHKCOLOR.OptionsColumn.ShowCaption = False
        Me.GCHKCOLOR.Visible = True
        Me.GCHKCOLOR.VisibleIndex = 0
        Me.GCHKCOLOR.Width = 35
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.ImageIndex = 0
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 1
        Me.GUNIT.Width = 200
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(73, 362)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "Update"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(159, 362)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'DefaultUnit
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(310, 402)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DefaultUnit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Default Unit for Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetailsunit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbillunit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents CHKSELECTUNIT As CheckBox
    Private WithEvents gridbilldetailsunit As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbillunit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHKCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
