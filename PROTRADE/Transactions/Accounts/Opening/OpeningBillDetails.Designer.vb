<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningBillDetails
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
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.griduserrights = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GYEAR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbformname = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdEDIT = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.griduserdetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDUSERNAME = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gformname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gadd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gedit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gview = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griduserrights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griduserdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDUSERNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdEDIT)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.griduserdetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1028, 529)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(812, 19)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 432
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadd.Location = New System.Drawing.Point(451, 494)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(80, 28)
        Me.cmdadd.TabIndex = 431
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(368, 50)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.griduserrights
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbformname, Me.RepositoryItemCheckEdit1})
        Me.griddetails.Size = New System.Drawing.Size(672, 439)
        Me.griddetails.TabIndex = 430
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.griduserrights})
        '
        'griduserrights
        '
        Me.griduserrights.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griduserrights.Appearance.HeaderPanel.Options.UseFont = True
        Me.griduserrights.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griduserrights.Appearance.Row.Options.UseFont = True
        Me.griduserrights.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GBILLTYPE, Me.GBILLNO, Me.GYEAR, Me.GDATE, Me.GDUEDATE, Me.GAMT})
        Me.griduserrights.GridControl = Me.griddetails
        Me.griduserrights.Name = "griduserrights"
        Me.griduserrights.OptionsBehavior.Editable = False
        Me.griduserrights.OptionsCustomization.AllowColumnMoving = False
        Me.griduserrights.OptionsCustomization.AllowColumnResizing = False
        Me.griduserrights.OptionsCustomization.AllowGroup = False
        Me.griduserrights.OptionsCustomization.AllowQuickHideColumns = False
        Me.griduserrights.OptionsView.ColumnAutoWidth = False
        Me.griduserrights.OptionsView.ShowFooter = True
        Me.griduserrights.OptionsView.ShowGroupPanel = False
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr."
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 60
        '
        'GBILLTYPE
        '
        Me.GBILLTYPE.Caption = "Bill Type"
        Me.GBILLTYPE.FieldName = "TYPE"
        Me.GBILLTYPE.Name = "GBILLTYPE"
        Me.GBILLTYPE.Visible = True
        Me.GBILLTYPE.VisibleIndex = 1
        Me.GBILLTYPE.Width = 90
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 2
        Me.GBILLNO.Width = 90
        '
        'GYEAR
        '
        Me.GYEAR.Caption = "Year"
        Me.GYEAR.FieldName = "YEAR"
        Me.GYEAR.Name = "GYEAR"
        Me.GYEAR.Visible = True
        Me.GYEAR.VisibleIndex = 3
        Me.GYEAR.Width = 90
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 4
        Me.GDATE.Width = 80
        '
        'GDUEDATE
        '
        Me.GDUEDATE.Caption = "Due Date"
        Me.GDUEDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDUEDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDUEDATE.FieldName = "DUEDATE"
        Me.GDUEDATE.Name = "GDUEDATE"
        Me.GDUEDATE.Visible = True
        Me.GDUEDATE.VisibleIndex = 5
        Me.GDUEDATE.Width = 80
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 6
        Me.GAMT.Width = 120
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
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(537, 494)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdEDIT
        '
        Me.cmdEDIT.BackColor = System.Drawing.Color.Transparent
        Me.cmdEDIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEDIT.FlatAppearance.BorderSize = 0
        Me.cmdEDIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEDIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdEDIT.Location = New System.Drawing.Point(896, 19)
        Me.cmdEDIT.Name = "cmdEDIT"
        Me.cmdEDIT.Size = New System.Drawing.Size(80, 28)
        Me.cmdEDIT.TabIndex = 7
        Me.cmdEDIT.Text = "&Edit"
        Me.cmdEDIT.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 8)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(135, 24)
        Me.lbl.TabIndex = 429
        Me.lbl.Text = "Opening Bills"
        '
        'griduserdetails
        '
        Me.griduserdetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griduserdetails.Location = New System.Drawing.Point(23, 50)
        Me.griduserdetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griduserdetails.MainView = Me.GRIDUSERNAME
        Me.griduserdetails.Name = "griduserdetails"
        Me.griduserdetails.Size = New System.Drawing.Size(339, 439)
        Me.griduserdetails.TabIndex = 6
        Me.griduserdetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDUSERNAME})
        '
        'GRIDUSERNAME
        '
        Me.GRIDUSERNAME.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDUSERNAME.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDUSERNAME.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDUSERNAME.Appearance.Row.Options.UseFont = True
        Me.GRIDUSERNAME.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME})
        Me.GRIDUSERNAME.GridControl = Me.griduserdetails
        Me.GRIDUSERNAME.Name = "GRIDUSERNAME"
        Me.GRIDUSERNAME.OptionsBehavior.Editable = False
        Me.GRIDUSERNAME.OptionsCustomization.AllowColumnMoving = False
        Me.GRIDUSERNAME.OptionsCustomization.AllowColumnResizing = False
        Me.GRIDUSERNAME.OptionsCustomization.AllowGroup = False
        Me.GRIDUSERNAME.OptionsCustomization.AllowQuickHideColumns = False
        Me.GRIDUSERNAME.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 150
        '
        'gformname
        '
        Me.gformname.Caption = "Form Name"
        Me.gformname.FieldName = "FormName"
        Me.gformname.ImageIndex = 0
        Me.gformname.Name = "gformname"
        Me.gformname.OptionsColumn.AllowEdit = False
        Me.gformname.Visible = True
        Me.gformname.VisibleIndex = 0
        Me.gformname.Width = 150
        '
        'gadd
        '
        Me.gadd.Caption = "Add"
        Me.gadd.FieldName = "Add"
        Me.gadd.Name = "gadd"
        Me.gadd.OptionsColumn.AllowEdit = False
        Me.gadd.Visible = True
        Me.gadd.VisibleIndex = 1
        Me.gadd.Width = 100
        '
        'gedit
        '
        Me.gedit.Caption = "Edit"
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
        Me.gdelete.FieldName = "Delete"
        Me.gdelete.Name = "gdelete"
        Me.gdelete.OptionsColumn.AllowEdit = False
        Me.gdelete.Visible = True
        Me.gdelete.VisibleIndex = 4
        Me.gdelete.Width = 100
        '
        'OpeningBillDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1028, 529)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "OpeningBillDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Bill Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griduserrights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griduserdetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDUSERNAME, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdEDIT As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents griduserdetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDUSERNAME As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gformname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gadd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gedit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gview As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents griduserrights As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbformname As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GYEAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents GDUEDATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
