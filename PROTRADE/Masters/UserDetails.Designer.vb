<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.griduserdetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDUSERNAME = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gusername = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.griduserrights = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gformname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbformname = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.gadd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gedit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gview = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griduserdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDUSERNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griduserrights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.griduserdetails)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(866, 528)
        Me.BlendPanel1.TabIndex = 0
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(439, 491)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(358, 491)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 7
        Me.cmdok.Text = "&Edit"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 8)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(117, 24)
        Me.lbl.TabIndex = 429
        Me.lbl.Text = "User Rights"
        '
        'griduserdetails
        '
        Me.griduserdetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griduserdetails.Location = New System.Drawing.Point(25, 43)
        Me.griduserdetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griduserdetails.MainView = Me.GRIDUSERNAME
        Me.griduserdetails.Name = "griduserdetails"
        Me.griduserdetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit2})
        Me.griduserdetails.Size = New System.Drawing.Size(173, 439)
        Me.griduserdetails.TabIndex = 6
        Me.griduserdetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDUSERNAME})
        '
        'GRIDUSERNAME
        '
        Me.GRIDUSERNAME.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDUSERNAME.Appearance.Row.Options.UseFont = True
        Me.GRIDUSERNAME.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gusername})
        Me.GRIDUSERNAME.GridControl = Me.griduserdetails
        Me.GRIDUSERNAME.Images = Me.imageList1
        Me.GRIDUSERNAME.Name = "GRIDUSERNAME"
        Me.GRIDUSERNAME.OptionsCustomization.AllowGroup = False
        Me.GRIDUSERNAME.OptionsView.ShowGroupPanel = False
        '
        'gusername
        '
        Me.gusername.Caption = "User Name"
        Me.gusername.ColumnEdit = Me.RepositoryItemComboBox1
        Me.gusername.FieldName = "UserName"
        Me.gusername.ImageIndex = 0
        Me.gusername.Name = "gusername"
        Me.gusername.Visible = True
        Me.gusername.VisibleIndex = 0
        Me.gusername.Width = 150
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.DropDownRows = 10
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.RepositoryItemComboBox1.ValidateOnEnterKey = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(204, 43)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.griduserrights
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbformname, Me.RepositoryItemCheckEdit1})
        Me.griddetails.Size = New System.Drawing.Size(638, 439)
        Me.griddetails.TabIndex = 5
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.griduserrights})
        '
        'griduserrights
        '
        Me.griduserrights.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griduserrights.Appearance.Row.Options.UseFont = True
        Me.griduserrights.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gformname, Me.gadd, Me.gedit, Me.gview, Me.gdelete})
        Me.griduserrights.GridControl = Me.griddetails
        Me.griduserrights.Images = Me.imageList1
        Me.griduserrights.Name = "griduserrights"
        Me.griduserrights.OptionsCustomization.AllowGroup = False
        Me.griduserrights.OptionsView.ShowGroupPanel = False
        '
        'gformname
        '
        Me.gformname.Caption = "Form Name"
        Me.gformname.ColumnEdit = Me.cmbformname
        Me.gformname.FieldName = "FormName"
        Me.gformname.ImageIndex = 0
        Me.gformname.Name = "gformname"
        Me.gformname.OptionsColumn.AllowEdit = False
        Me.gformname.Visible = True
        Me.gformname.VisibleIndex = 0
        Me.gformname.Width = 150
        '
        'cmbformname
        '
        Me.cmbformname.AutoHeight = False
        Me.cmbformname.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbformname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbformname.DropDownRows = 10
        Me.cmbformname.Name = "cmbformname"
        Me.cmbformname.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbformname.ValidateOnEnterKey = True
        '
        'gadd
        '
        Me.gadd.Caption = "Add"
        Me.gadd.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gadd.FieldName = "Add"
        Me.gadd.Name = "gadd"
        Me.gadd.OptionsColumn.AllowEdit = False
        Me.gadd.Visible = True
        Me.gadd.VisibleIndex = 1
        Me.gadd.Width = 100
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gedit
        '
        Me.gedit.Caption = "Edit"
        Me.gedit.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gedit.FieldName = "Edit"
        Me.gedit.Name = "gedit"
        Me.gedit.OptionsColumn.AllowEdit = False
        Me.gedit.Visible = True
        Me.gedit.VisibleIndex = 2
        Me.gedit.Width = 100
        '
        'gview
        '
        Me.gview.Caption = "View"
        Me.gview.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gview.FieldName = "View"
        Me.gview.Name = "gview"
        Me.gview.OptionsColumn.AllowEdit = False
        Me.gview.Visible = True
        Me.gview.VisibleIndex = 3
        Me.gview.Width = 100
        '
        'gdelete
        '
        Me.gdelete.Caption = "Delete"
        Me.gdelete.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.gdelete.FieldName = "Delete"
        Me.gdelete.Name = "gdelete"
        Me.gdelete.OptionsColumn.AllowEdit = False
        Me.gdelete.Visible = True
        Me.gdelete.VisibleIndex = 4
        Me.gdelete.Width = 100
        '
        'UserDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(866, 528)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "UserDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Details"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griduserdetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDUSERNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griduserrights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griduserdetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDUSERNAME As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gusername As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents griduserrights As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gformname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbformname As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gadd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents gedit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gview As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
End Class
