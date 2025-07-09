<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPackingMaterial
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBUNIT = New System.Windows.Forms.ComboBox()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.CMBSTOREITEMNAME = New System.Windows.Forms.ComboBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSTOREITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.BlendPanel2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(564, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.CMBUNIT)
        Me.BlendPanel2.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel2.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel2.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel2.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel2.Controls.Add(Me.TXTQTY)
        Me.BlendPanel2.Controls.Add(Me.CMBSTOREITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(564, 581)
        Me.BlendPanel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(408, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 674
        Me.Label1.Text = "Unit"
        '
        'CMBUNIT
        '
        Me.CMBUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUNIT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBUNIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUNIT.FormattingEnabled = True
        Me.CMBUNIT.Location = New System.Drawing.Point(440, 11)
        Me.CMBUNIT.MaxDropDownItems = 14
        Me.CMBUNIT.Name = "CMBUNIT"
        Me.CMBUNIT.Size = New System.Drawing.Size(89, 23)
        Me.CMBUNIT.TabIndex = 1
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(165, 541)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 6
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(79, 541)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 5
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(337, 541)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 8
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Location = New System.Drawing.Point(251, 541)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 7
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'TXTQTY
        '
        Me.TXTQTY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQTY.ForeColor = System.Drawing.Color.Black
        Me.TXTQTY.Location = New System.Drawing.Point(348, 48)
        Me.TXTQTY.MaxLength = 10
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.Size = New System.Drawing.Size(100, 23)
        Me.TXTQTY.TabIndex = 3
        Me.TXTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBSTOREITEMNAME
        '
        Me.CMBSTOREITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTOREITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTOREITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSTOREITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTOREITEMNAME.FormattingEnabled = True
        Me.CMBSTOREITEMNAME.Location = New System.Drawing.Point(48, 48)
        Me.CMBSTOREITEMNAME.MaxDropDownItems = 14
        Me.CMBSTOREITEMNAME.MaxLength = 200
        Me.CMBSTOREITEMNAME.Name = "CMBSTOREITEMNAME"
        Me.CMBSTOREITEMNAME.Size = New System.Drawing.Size(300, 23)
        Me.CMBSTOREITEMNAME.TabIndex = 2
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(32, 72)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(460, 463)
        Me.gridbilldetails.TabIndex = 4
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSTOREITEMNAME, Me.GQTY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowColumnResizing = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSTOREITEMNAME
        '
        Me.GSTOREITEMNAME.Caption = "Store Item Name"
        Me.GSTOREITEMNAME.FieldName = "STOREITEMNAME"
        Me.GSTOREITEMNAME.Name = "GSTOREITEMNAME"
        Me.GSTOREITEMNAME.Visible = True
        Me.GSTOREITEMNAME.VisibleIndex = 0
        Me.GSTOREITEMNAME.Width = 300
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.DisplayFormat.FormatString = "0.00"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 1
        Me.GQTY.Width = 100
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 15)
        Me.Label8.TabIndex = 637
        Me.Label8.Text = "Item Name"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(97, 11)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(300, 23)
        Me.CMBITEMNAME.TabIndex = 0
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ItemPackingMaterial
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(564, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemPackingMaterial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Item Packing Material"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents CMBUNIT As ComboBox
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents TXTQTY As TextBox
    Friend WithEvents CMBSTOREITEMNAME As ComboBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSTOREITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents EP As ErrorProvider
End Class
