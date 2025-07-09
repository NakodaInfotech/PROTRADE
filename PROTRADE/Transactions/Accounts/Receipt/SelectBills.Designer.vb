<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBills
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
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridrec = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridrec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(741, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(113, 7)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 211
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(22, 31)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridrec
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.griddetails.Size = New System.Drawing.Size(696, 509)
        Me.griddetails.TabIndex = 210
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridrec})
        '
        'gridrec
        '
        Me.gridrec.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridrec.Appearance.Row.Options.UseFont = True
        Me.gridrec.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.gsrno, Me.GBILLNO, Me.GDATE, Me.GREFNO, Me.GNAME, Me.gtotal, Me.GBALAMT, Me.GTYPE, Me.GDISPUTE})
        Me.gridrec.GridControl = Me.griddetails
        Me.gridrec.Name = "gridrec"
        Me.gridrec.OptionsCustomization.AllowColumnMoving = False
        Me.gridrec.OptionsCustomization.AllowGroup = False
        Me.gridrec.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridrec.OptionsView.ColumnAutoWidth = False
        Me.gridrec.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridrec.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Width = 30
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.ImageIndex = 1
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 90
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No."
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.ImageIndex = 0
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.OptionsColumn.AllowEdit = False
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 1
        Me.GBILLNO.Width = 100
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 90
        '
        'GREFNO
        '
        Me.GREFNO.Caption = "Ref No"
        Me.GREFNO.FieldName = "REFNO"
        Me.GREFNO.Name = "GREFNO"
        Me.GREFNO.OptionsColumn.AllowEdit = False
        Me.GREFNO.Visible = True
        Me.GREFNO.VisibleIndex = 3
        Me.GREFNO.Width = 95
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Width = 150
        '
        'gtotal
        '
        Me.gtotal.Caption = "Total"
        Me.gtotal.DisplayFormat.FormatString = "0.00"
        Me.gtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotal.FieldName = "BILLAMT"
        Me.gtotal.Name = "gtotal"
        Me.gtotal.OptionsColumn.AllowEdit = False
        Me.gtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "")})
        Me.gtotal.Visible = True
        Me.gtotal.VisibleIndex = 4
        Me.gtotal.Width = 120
        '
        'GBALAMT
        '
        Me.GBALAMT.Caption = "Bal Amt"
        Me.GBALAMT.FieldName = "BALAMT"
        Me.GBALAMT.Name = "GBALAMT"
        Me.GBALAMT.OptionsColumn.AllowEdit = False
        Me.GBALAMT.Visible = True
        Me.GBALAMT.VisibleIndex = 5
        Me.GBALAMT.Width = 120
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        '
        'GDISPUTE
        '
        Me.GDISPUTE.Caption = "DISPUTE"
        Me.GDISPUTE.FieldName = "DISPUTE"
        Me.GDISPUTE.Name = "GDISPUTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(18, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 23)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "Select Bills"
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(373, 546)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 3
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(287, 546)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Ok"
        Me.cmdok.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'SelectBills
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(741, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectBills"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Bills"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridrec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridrec As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CHKSELECTALL As CheckBox
    Friend WithEvents GDISPUTE As DevExpress.XtraGrid.Columns.GridColumn
End Class
