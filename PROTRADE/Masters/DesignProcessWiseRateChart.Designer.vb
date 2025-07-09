<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignProcessWiseRateChart
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
        Me.components = New System.ComponentModel.Container
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDDELETE = New System.Windows.Forms.Button
        Me.TXTRATE = New System.Windows.Forms.TextBox
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPROCESS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TXTNO = New System.Windows.Forms.TextBox
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.CMBPROCESS)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(503, 679)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(125, 628)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 674
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(297, 628)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 676
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Location = New System.Drawing.Point(211, 628)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 675
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.ForeColor = System.Drawing.Color.Black
        Me.TXTRATE.Location = New System.Drawing.Point(346, 13)
        Me.TXTRATE.MaxLength = 10
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(100, 23)
        Me.TXTRATE.TabIndex = 5
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROCESS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROCESS.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Location = New System.Drawing.Point(196, 13)
        Me.CMBPROCESS.MaxDropDownItems = 14
        Me.CMBPROCESS.MaxLength = 200
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(150, 23)
        Me.CMBPROCESS.TabIndex = 2
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(27, 37)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(448, 585)
        Me.gridbilldetails.TabIndex = 6
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GID, Me.GDESIGN, Me.GPROCESS, Me.GRATE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowColumnResizing = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 0
        Me.GDESIGN.Width = 150
        '
        'GPROCESS
        '
        Me.GPROCESS.Caption = "Process"
        Me.GPROCESS.FieldName = "PROCESS"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.Visible = True
        Me.GPROCESS.VisibleIndex = 1
        Me.GPROCESS.Width = 150
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 2
        Me.GRATE.Width = 100
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ForeColor = System.Drawing.Color.Black
        Me.TXTNO.Location = New System.Drawing.Point(452, 0)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.Size = New System.Drawing.Size(50, 23)
        Me.TXTNO.TabIndex = 672
        Me.TXTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTNO.Visible = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(46, 13)
        Me.CMBDESIGN.MaxDropDownItems = 14
        Me.CMBDESIGN.MaxLength = 200
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(150, 23)
        Me.CMBDESIGN.TabIndex = 1
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'GID
        '
        Me.GID.Caption = "ID"
        Me.GID.FieldName = "ID"
        Me.GID.Name = "GID"
        '
        'Design_ProcessWiseRateChart
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(503, 679)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Design_ProcessWiseRateChart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Wise Process Wise Rate Chart"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents CMBPROCESS As System.Windows.Forms.ComboBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents GID As DevExpress.XtraGrid.Columns.GridColumn
End Class
