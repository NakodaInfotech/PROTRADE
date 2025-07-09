<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFormSummary
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBTYPE = New System.Windows.Forms.ComboBox
        Me.RBRECEIVED = New System.Windows.Forms.RadioButton
        Me.RBPENDING = New System.Windows.Forms.RadioButton
        Me.RBALL = New System.Windows.Forms.RadioButton
        Me.griddetails = New DevExpress.XtraGrid.GridControl
        Me.gridregister = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSTATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCSTNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVATNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMOUNT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdshowdetails = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.TXTTOTAL = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.lblto = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.lblfrom = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lblname = New System.Windows.Forms.Label
        Me.CMBFORM = New System.Windows.Forms.ComboBox
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.RBRECEIVED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.RBALL)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.cmdshowdetails)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTAL)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.CMBFORM)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(881, 562)
        Me.BlendPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(257, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 737
        Me.Label1.Text = "Type"
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"", "PURCHASE", "SALE"})
        Me.CMBTYPE.Location = New System.Drawing.Point(290, 63)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(107, 22)
        Me.CMBTYPE.TabIndex = 736
        '
        'RBRECEIVED
        '
        Me.RBRECEIVED.AutoSize = True
        Me.RBRECEIVED.BackColor = System.Drawing.Color.Transparent
        Me.RBRECEIVED.Location = New System.Drawing.Point(709, 72)
        Me.RBRECEIVED.Name = "RBRECEIVED"
        Me.RBRECEIVED.Size = New System.Drawing.Size(110, 19)
        Me.RBRECEIVED.TabIndex = 450
        Me.RBRECEIVED.Text = "&Received Forms"
        Me.RBRECEIVED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(709, 51)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(106, 19)
        Me.RBPENDING.TabIndex = 449
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "&Pending Forms"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.BackColor = System.Drawing.Color.Transparent
        Me.RBALL.Location = New System.Drawing.Point(709, 30)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(72, 19)
        Me.RBALL.TabIndex = 448
        Me.RBALL.Text = "Show A&ll"
        Me.RBALL.UseVisualStyleBackColor = False
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(25, 94)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridregister
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(831, 430)
        Me.griddetails.TabIndex = 447
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridregister})
        '
        'gridregister
        '
        Me.gridregister.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.Row.Options.UseFont = True
        Me.gridregister.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridregister.Appearance.ViewCaption.Options.UseFont = True
        Me.gridregister.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gname, Me.GSTATE, Me.GCSTNO, Me.GVATNO, Me.GAMOUNT})
        Me.gridregister.GridControl = Me.griddetails
        Me.gridregister.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridregister.Name = "gridregister"
        Me.gridregister.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridregister.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridregister.OptionsBehavior.Editable = False
        Me.gridregister.OptionsMenu.EnableColumnMenu = False
        Me.gridregister.OptionsView.ColumnAutoWidth = False
        Me.gridregister.OptionsView.ShowAutoFilterRow = True
        Me.gridregister.OptionsView.ShowFooter = True
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "NAME"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 0
        Me.gname.Width = 300
        '
        'GSTATE
        '
        Me.GSTATE.Caption = "State"
        Me.GSTATE.FieldName = "STATENAME"
        Me.GSTATE.Name = "GSTATE"
        Me.GSTATE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GSTATE.Visible = True
        Me.GSTATE.VisibleIndex = 1
        Me.GSTATE.Width = 120
        '
        'GCSTNO
        '
        Me.GCSTNO.Caption = "C.S.T. / TIN No"
        Me.GCSTNO.FieldName = "CSTNO"
        Me.GCSTNO.Name = "GCSTNO"
        Me.GCSTNO.Visible = True
        Me.GCSTNO.VisibleIndex = 2
        Me.GCSTNO.Width = 120
        '
        'GVATNO
        '
        Me.GVATNO.Caption = "V.A.T. No"
        Me.GVATNO.FieldName = "VATNO"
        Me.GVATNO.Name = "GVATNO"
        Me.GVATNO.Visible = True
        Me.GVATNO.VisibleIndex = 3
        Me.GVATNO.Width = 120
        '
        'GAMOUNT
        '
        Me.GAMOUNT.Caption = "Amount"
        Me.GAMOUNT.DisplayFormat.FormatString = "0.00"
        Me.GAMOUNT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMOUNT.FieldName = "AMOUNT"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GAMOUNT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMOUNT.Visible = True
        Me.GAMOUNT.VisibleIndex = 4
        Me.GAMOUNT.Width = 120
        '
        'cmdshowdetails
        '
        Me.cmdshowdetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowdetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowdetails.FlatAppearance.BorderSize = 0
        Me.cmdshowdetails.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowdetails.ForeColor = System.Drawing.Color.Black
        Me.cmdshowdetails.Location = New System.Drawing.Point(604, 57)
        Me.cmdshowdetails.Name = "cmdshowdetails"
        Me.cmdshowdetails.Size = New System.Drawing.Size(88, 28)
        Me.cmdshowdetails.TabIndex = 4
        Me.cmdshowdetails.Text = "&Show Details"
        Me.cmdshowdetails.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(357, 529)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(443, 529)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.BackColor = System.Drawing.Color.White
        Me.TXTTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTAL.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTAL.Location = New System.Drawing.Point(712, 530)
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.ReadOnly = True
        Me.TXTTOTAL.Size = New System.Drawing.Size(100, 22)
        Me.TXTTOTAL.TabIndex = 442
        Me.TXTTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(677, 534)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 14)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "Total"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(420, 39)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 1
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(511, 63)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(84, 22)
        Me.dtto.TabIndex = 3
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(487, 67)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 432
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(510, 37)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(85, 22)
        Me.dtfrom.TabIndex = 2
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(472, 40)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 1
        Me.lblfrom.Text = "From"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcelExport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(881, 25)
        Me.ToolStrip1.TabIndex = 430
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
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(227, 42)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(61, 14)
        Me.lblname.TabIndex = 429
        Me.lblname.Text = "Form Type"
        '
        'CMBFORM
        '
        Me.CMBFORM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFORM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFORM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFORM.FormattingEnabled = True
        Me.CMBFORM.Location = New System.Drawing.Point(290, 38)
        Me.CMBFORM.MaxDropDownItems = 14
        Me.CMBFORM.Name = "CMBFORM"
        Me.CMBFORM.Size = New System.Drawing.Size(107, 22)
        Me.CMBFORM.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(21, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(152, 24)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Form Summary"
        '
        'CFormSummary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(881, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CFormSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form Summary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridregister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridregister As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GAMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdshowdetails As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblto As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfrom As System.Windows.Forms.Label
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents CMBFORM As System.Windows.Forms.ComboBox
    Friend WithEvents GCSTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVATNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBRECEIVED As System.Windows.Forms.RadioButton
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBTYPE As System.Windows.Forms.ComboBox
End Class
