<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgeingReport
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
        Me.TXTCOL5 = New System.Windows.Forms.TextBox()
        Me.TXTCOL4 = New System.Windows.Forms.TextBox()
        Me.TXTCOL3 = New System.Windows.Forms.TextBox()
        Me.TXTCOL2 = New System.Windows.Forms.TextBox()
        Me.TXTCOL1 = New System.Windows.Forms.TextBox()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.RBPAYABLE = New System.Windows.Forms.RadioButton()
        Me.RBREC = New System.Windows.Forms.RadioButton()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GONACCOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOL1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOL2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOL3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOL4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOL5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOL6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CMBAGENT = New System.Windows.Forms.ComboBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.CMBAGENT)
        Me.BlendPanel1.Controls.Add(Me.TXTCOL5)
        Me.BlendPanel1.Controls.Add(Me.TXTCOL4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOL3)
        Me.BlendPanel1.Controls.Add(Me.TXTCOL2)
        Me.BlendPanel1.Controls.Add(Me.TXTCOL1)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.RBPAYABLE)
        Me.BlendPanel1.Controls.Add(Me.RBREC)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTCOL5
        '
        Me.TXTCOL5.Location = New System.Drawing.Point(987, 12)
        Me.TXTCOL5.Name = "TXTCOL5"
        Me.TXTCOL5.Size = New System.Drawing.Size(71, 23)
        Me.TXTCOL5.TabIndex = 9
        '
        'TXTCOL4
        '
        Me.TXTCOL4.Location = New System.Drawing.Point(910, 12)
        Me.TXTCOL4.Name = "TXTCOL4"
        Me.TXTCOL4.Size = New System.Drawing.Size(71, 23)
        Me.TXTCOL4.TabIndex = 8
        '
        'TXTCOL3
        '
        Me.TXTCOL3.Location = New System.Drawing.Point(833, 12)
        Me.TXTCOL3.Name = "TXTCOL3"
        Me.TXTCOL3.Size = New System.Drawing.Size(71, 23)
        Me.TXTCOL3.TabIndex = 7
        '
        'TXTCOL2
        '
        Me.TXTCOL2.Location = New System.Drawing.Point(756, 12)
        Me.TXTCOL2.Name = "TXTCOL2"
        Me.TXTCOL2.Size = New System.Drawing.Size(71, 23)
        Me.TXTCOL2.TabIndex = 6
        '
        'TXTCOL1
        '
        Me.TXTCOL1.Location = New System.Drawing.Point(679, 12)
        Me.TXTCOL1.Name = "TXTCOL1"
        Me.TXTCOL1.Size = New System.Drawing.Size(71, 23)
        Me.TXTCOL1.TabIndex = 5
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.Black
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(1064, 9)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(88, 28)
        Me.CMDSHOWDETAILS.TabIndex = 10
        Me.CMDSHOWDETAILS.Text = "&Show Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'RBPAYABLE
        '
        Me.RBPAYABLE.AutoSize = True
        Me.RBPAYABLE.BackColor = System.Drawing.Color.Transparent
        Me.RBPAYABLE.Location = New System.Drawing.Point(110, 14)
        Me.RBPAYABLE.Name = "RBPAYABLE"
        Me.RBPAYABLE.Size = New System.Drawing.Size(71, 19)
        Me.RBPAYABLE.TabIndex = 1
        Me.RBPAYABLE.Text = "Payables"
        Me.RBPAYABLE.UseVisualStyleBackColor = False
        '
        'RBREC
        '
        Me.RBREC.AutoSize = True
        Me.RBREC.BackColor = System.Drawing.Color.Transparent
        Me.RBREC.Checked = True
        Me.RBREC.Location = New System.Drawing.Point(16, 14)
        Me.RBREC.Name = "RBREC"
        Me.RBREC.Size = New System.Drawing.Size(85, 19)
        Me.RBREC.TabIndex = 0
        Me.RBREC.TabStop = True
        Me.RBREC.Text = "Receivables"
        Me.RBREC.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(204, 14)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(68, 19)
        Me.chkdate.TabIndex = 2
        Me.chkdate.Text = "Till Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(274, 12)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 23)
        Me.dtto.TabIndex = 4
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.BackgroundImage = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.CMDPRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDPRINT.Location = New System.Drawing.Point(1158, 13)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 11
        Me.CMDPRINT.TabStop = False
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(16, 47)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1220, 476)
        Me.gridbilldetails.TabIndex = 13
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME, Me.GGROUPNAME, Me.GTOTALAMT, Me.GONACCOUNT, Me.GCOL1, Me.GCOL2, Me.GCOL3, Me.GCOL4, Me.GCOL5, Me.GCOL6})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 180
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 1
        Me.GGROUPNAME.Width = 150
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALAMT.FieldName = "BALANCE"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BALANCE", "{0:0.00}")})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 2
        Me.GTOTALAMT.Width = 120
        '
        'GONACCOUNT
        '
        Me.GONACCOUNT.Caption = "On Account"
        Me.GONACCOUNT.DisplayFormat.FormatString = "0.00"
        Me.GONACCOUNT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GONACCOUNT.FieldName = "ONACCOUNT"
        Me.GONACCOUNT.Name = "GONACCOUNT"
        Me.GONACCOUNT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GONACCOUNT.Visible = True
        Me.GONACCOUNT.VisibleIndex = 3
        Me.GONACCOUNT.Width = 120
        '
        'GCOL1
        '
        Me.GCOL1.Caption = "COL1"
        Me.GCOL1.DisplayFormat.FormatString = "0.00"
        Me.GCOL1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOL1.FieldName = "COL1"
        Me.GCOL1.Name = "GCOL1"
        Me.GCOL1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COL1", "{0:0.00}")})
        Me.GCOL1.Width = 100
        '
        'GCOL2
        '
        Me.GCOL2.Caption = "COL2"
        Me.GCOL2.DisplayFormat.FormatString = "0.00"
        Me.GCOL2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOL2.FieldName = "COL2"
        Me.GCOL2.Name = "GCOL2"
        Me.GCOL2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COL2", "{0:0.00}")})
        Me.GCOL2.Width = 100
        '
        'GCOL3
        '
        Me.GCOL3.Caption = "COL3"
        Me.GCOL3.DisplayFormat.FormatString = "0.00"
        Me.GCOL3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOL3.FieldName = "COL3"
        Me.GCOL3.Name = "GCOL3"
        Me.GCOL3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COL3", "{0:0.00}")})
        Me.GCOL3.Width = 100
        '
        'GCOL4
        '
        Me.GCOL4.Caption = "COL4"
        Me.GCOL4.DisplayFormat.FormatString = "0.00"
        Me.GCOL4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOL4.FieldName = "COL4"
        Me.GCOL4.Name = "GCOL4"
        Me.GCOL4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COL4", "{0:0.00}")})
        Me.GCOL4.Width = 100
        '
        'GCOL5
        '
        Me.GCOL5.Caption = "COL5"
        Me.GCOL5.DisplayFormat.FormatString = "0.00"
        Me.GCOL5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOL5.FieldName = "COL5"
        Me.GCOL5.Name = "GCOL5"
        Me.GCOL5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COL5", "{0:0.00}")})
        Me.GCOL5.Width = 100
        '
        'GCOL6
        '
        Me.GCOL6.Caption = "COL6"
        Me.GCOL6.FieldName = "COL6"
        Me.GCOL6.Name = "GCOL6"
        Me.GCOL6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCOL6.Width = 100
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(493, 529)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 12
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(373, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 15)
        Me.Label15.TabIndex = 927
        Me.Label15.Text = "Agent"
        '
        'CMBAGENT
        '
        Me.CMBAGENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENT.BackColor = System.Drawing.Color.White
        Me.CMBAGENT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENT.FormattingEnabled = True
        Me.CMBAGENT.Location = New System.Drawing.Point(414, 12)
        Me.CMBAGENT.MaxDropDownItems = 14
        Me.CMBAGENT.Name = "CMBAGENT"
        Me.CMBAGENT.Size = New System.Drawing.Size(239, 23)
        Me.CMBAGENT.TabIndex = 926
        '
        'AgeingReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AgeingReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ageing Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDPRINT As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As Button
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents RBPAYABLE As RadioButton
    Friend WithEvents RBREC As RadioButton
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDSHOWDETAILS As Button
    Friend WithEvents TXTCOL5 As TextBox
    Friend WithEvents TXTCOL4 As TextBox
    Friend WithEvents TXTCOL3 As TextBox
    Friend WithEvents TXTCOL2 As TextBox
    Friend WithEvents TXTCOL1 As TextBox
    Friend WithEvents GCOL1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOL2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOL3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOL4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOL5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GONACCOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOL6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label15 As Label
    Friend WithEvents CMBAGENT As ComboBox
End Class
