<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Adv_Receivable_settlement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Adv_Receivable_settlement))
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKAGAINSTBILL = New System.Windows.Forms.CheckBox()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridADVREC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbillinitials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gamt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpaytype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gacc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.greg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gregabbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdshowdtls = New System.Windows.Forms.Button()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridADVREC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(25, 30)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(113, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "lbl_header"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKAGAINSTBILL)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdtls)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1007, 602)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKAGAINSTBILL
        '
        Me.CHKAGAINSTBILL.AutoSize = True
        Me.CHKAGAINSTBILL.BackColor = System.Drawing.Color.Transparent
        Me.CHKAGAINSTBILL.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CHKAGAINSTBILL.Location = New System.Drawing.Point(658, 64)
        Me.CHKAGAINSTBILL.Name = "CHKAGAINSTBILL"
        Me.CHKAGAINSTBILL.Size = New System.Drawing.Size(89, 18)
        Me.CHKAGAINSTBILL.TabIndex = 450
        Me.CHKAGAINSTBILL.Text = "Against Bill"
        Me.CHKAGAINSTBILL.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(12, 99)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridADVREC
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(980, 465)
        Me.griddetails.TabIndex = 449
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridADVREC})
        '
        'gridADVREC
        '
        Me.gridADVREC.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridADVREC.Appearance.Row.Options.UseFont = True
        Me.gridADVREC.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridADVREC.Appearance.ViewCaption.Options.UseFont = True
        Me.gridADVREC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gdate, Me.gbillinitials, Me.gamt, Me.gpaytype, Me.gacc, Me.GNAME, Me.GGROUPNAME, Me.gno, Me.greg, Me.gregabbr})
        Me.gridADVREC.GridControl = Me.griddetails
        Me.gridADVREC.Images = Me.imageList1
        Me.gridADVREC.Name = "gridADVREC"
        Me.gridADVREC.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridADVREC.OptionsBehavior.Editable = False
        Me.gridADVREC.OptionsCustomization.AllowColumnMoving = False
        Me.gridADVREC.OptionsCustomization.AllowColumnResizing = False
        Me.gridADVREC.OptionsCustomization.AllowGroup = False
        Me.gridADVREC.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridADVREC.OptionsMenu.EnableColumnMenu = False
        Me.gridADVREC.OptionsView.AllowCellMerge = True
        Me.gridADVREC.OptionsView.ColumnAutoWidth = False
        Me.gridADVREC.OptionsView.ShowAutoFilterRow = True
        Me.gridADVREC.OptionsView.ShowFooter = True
        Me.gridADVREC.OptionsView.ShowGroupPanel = False
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "Date"
        Me.gdate.Name = "gdate"
        Me.gdate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 0
        '
        'gbillinitials
        '
        Me.gbillinitials.Caption = "Bill No."
        Me.gbillinitials.FieldName = "Bill No."
        Me.gbillinitials.ImageIndex = 1
        Me.gbillinitials.Name = "gbillinitials"
        Me.gbillinitials.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gbillinitials.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gbillinitials.OptionsColumn.AllowMove = False
        Me.gbillinitials.Visible = True
        Me.gbillinitials.VisibleIndex = 1
        '
        'gamt
        '
        Me.gamt.Caption = "Amount"
        Me.gamt.DisplayFormat.FormatString = "0.00"
        Me.gamt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gamt.FieldName = "Amount"
        Me.gamt.Name = "gamt"
        Me.gamt.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gamt.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gamt.OptionsColumn.AllowMove = False
        Me.gamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gamt.Visible = True
        Me.gamt.VisibleIndex = 2
        Me.gamt.Width = 90
        '
        'gpaytype
        '
        Me.gpaytype.Caption = "Pay Type"
        Me.gpaytype.DisplayFormat.FormatString = "0.00"
        Me.gpaytype.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gpaytype.FieldName = "Pay Type"
        Me.gpaytype.Name = "gpaytype"
        Me.gpaytype.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gpaytype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gpaytype.OptionsColumn.AllowMove = False
        Me.gpaytype.Visible = True
        Me.gpaytype.VisibleIndex = 3
        Me.gpaytype.Width = 100
        '
        'gacc
        '
        Me.gacc.Caption = "Account"
        Me.gacc.FieldName = "Account"
        Me.gacc.ImageIndex = 0
        Me.gacc.Name = "gacc"
        Me.gacc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gacc.Visible = True
        Me.gacc.VisibleIndex = 4
        Me.gacc.Width = 225
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 5
        Me.GNAME.Width = 225
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.OptionsColumn.AllowEdit = False
        Me.GGROUPNAME.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 6
        Me.GGROUPNAME.Width = 140
        '
        'gno
        '
        Me.gno.Caption = "No"
        Me.gno.FieldName = "No"
        Me.gno.Name = "gno"
        '
        'greg
        '
        Me.greg.Caption = "Reg Id"
        Me.greg.FieldName = "Reg Id"
        Me.greg.Name = "greg"
        Me.greg.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'gregabbr
        '
        Me.gregabbr.Caption = "Reg Name"
        Me.gregabbr.FieldName = "Reg Name"
        Me.gregabbr.Name = "gregabbr"
        Me.gregabbr.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.gregabbr.Width = 200
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'cmdshowdtls
        '
        Me.cmdshowdtls.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdtls.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdtls.FlatAppearance.BorderSize = 0
        Me.cmdshowdtls.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdtls.Location = New System.Drawing.Point(564, 59)
        Me.cmdshowdtls.Name = "cmdshowdtls"
        Me.cmdshowdtls.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdtls.TabIndex = 4
        Me.cmdshowdtls.Text = "&Show Details"
        Me.cmdshowdtls.UseVisualStyleBackColor = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(78, 65)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(192, 21)
        Me.cmbname.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(37, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 329
        Me.Label2.Text = "Name"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(421, 569)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "O&k"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(343, 64)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(87, 22)
        Me.dtfrom.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(305, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 14)
        Me.Label1.TabIndex = 326
        Me.Label1.Text = "From"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkdate.Location = New System.Drawing.Point(308, 33)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 1
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(442, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 14)
        Me.Label5.TabIndex = 324
        Me.Label5.Text = "To"
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(468, 64)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 22)
        Me.dtto.TabIndex = 3
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(507, 569)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1007, 25)
        Me.ToolStrip1.TabIndex = 431
        Me.ToolStrip1.Text = "v"
        '
        'ExcelExport
        '
        Me.ExcelExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExcelExport.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.ExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExcelExport.Name = "ExcelExport"
        Me.ExcelExport.Size = New System.Drawing.Size(23, 22)
        Me.ExcelExport.Text = "&Export to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Adv_Receivable_settlement
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1007, 602)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Adv_Receivable_settlement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridADVREC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmdshowdtls As System.Windows.Forms.Button
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridADVREC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gbillinitials As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gamt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpaytype As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gacc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents greg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gregabbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKAGAINSTBILL As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ExcelExport As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
