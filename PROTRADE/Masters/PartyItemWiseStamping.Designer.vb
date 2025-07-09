<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartyItemWiseStamping
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
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTADD = New System.Windows.Forms.TextBox
        Me.CMBCODE = New System.Windows.Forms.ComboBox
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDDELETE = New System.Windows.Forms.Button
        Me.TXTSTAMPING = New System.Windows.Forms.TextBox
        Me.CMBITEM = New System.Windows.Forms.ComboBox
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPARTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTAMPING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.TXTNO = New System.Windows.Forms.TextBox
        Me.CMBNAME = New System.Windows.Forms.ComboBox
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.TXTSTAMPING)
        Me.BlendPanel1.Controls.Add(Me.CMBITEM)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(784, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'TXTADD
        '
        Me.TXTADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTADD.Location = New System.Drawing.Point(12, 155)
        Me.TXTADD.Multiline = True
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(35, 22)
        Me.TXTADD.TabIndex = 744
        Me.TXTADD.TabStop = False
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.BackColor = System.Drawing.Color.White
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(12, 135)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(56, 23)
        Me.CMBCODE.TabIndex = 743
        Me.CMBCODE.Visible = False
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(266, 541)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 674
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(438, 541)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 676
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Location = New System.Drawing.Point(352, 541)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 675
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'TXTSTAMPING
        '
        Me.TXTSTAMPING.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSTAMPING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTAMPING.ForeColor = System.Drawing.Color.Black
        Me.TXTSTAMPING.Location = New System.Drawing.Point(539, 13)
        Me.TXTSTAMPING.MaxLength = 10
        Me.TXTSTAMPING.Name = "TXTSTAMPING"
        Me.TXTSTAMPING.Size = New System.Drawing.Size(190, 23)
        Me.TXTSTAMPING.TabIndex = 5
        '
        'CMBITEM
        '
        Me.CMBITEM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEM.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEM.FormattingEnabled = True
        Me.CMBITEM.Location = New System.Drawing.Point(339, 13)
        Me.CMBITEM.MaxDropDownItems = 14
        Me.CMBITEM.MaxLength = 200
        Me.CMBITEM.Name = "CMBITEM"
        Me.CMBITEM.Size = New System.Drawing.Size(200, 23)
        Me.CMBITEM.TabIndex = 2
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(20, 37)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(745, 498)
        Me.gridbilldetails.TabIndex = 6
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GID, Me.GPARTY, Me.GITEM, Me.GSTAMPING})
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
        'GID
        '
        Me.GID.Caption = "ID"
        Me.GID.FieldName = "ID"
        Me.GID.Name = "GID"
        '
        'GPARTY
        '
        Me.GPARTY.Caption = "Party Name"
        Me.GPARTY.FieldName = "NAME"
        Me.GPARTY.Name = "GPARTY"
        Me.GPARTY.Visible = True
        Me.GPARTY.VisibleIndex = 0
        Me.GPARTY.Width = 300
        '
        'GITEM
        '
        Me.GITEM.Caption = "Item Name"
        Me.GITEM.FieldName = "ITEM"
        Me.GITEM.Name = "GITEM"
        Me.GITEM.Visible = True
        Me.GITEM.VisibleIndex = 1
        Me.GITEM.Width = 200
        '
        'GSTAMPING
        '
        Me.GSTAMPING.Caption = "Stamping"
        Me.GSTAMPING.FieldName = "STAMPING"
        Me.GSTAMPING.Name = "GSTAMPING"
        Me.GSTAMPING.Visible = True
        Me.GSTAMPING.VisibleIndex = 2
        Me.GSTAMPING.Width = 190
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
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(39, 13)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.MaxLength = 200
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(300, 23)
        Me.CMBNAME.TabIndex = 1
        '
        'PartyItemWiseStamping
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(784, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PartyItemWiseStamping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Party Wise Item Wise Stamping"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDDELETE As System.Windows.Forms.Button
    Friend WithEvents TXTSTAMPING As System.Windows.Forms.TextBox
    Friend WithEvents CMBITEM As System.Windows.Forms.ComboBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTNO As System.Windows.Forms.TextBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents GSTAMPING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
End Class
