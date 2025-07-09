<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TDSDeductedReport
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
        Me.CMBCOMPANYTYPE = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.RBDEDUCTED = New System.Windows.Forms.RadioButton()
        Me.RBNOTDEDUCTED = New System.Windows.Forms.RadioButton()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYBILLDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTDSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lblto = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.lblfrom = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.lblto)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.lblfrom)
        Me.BlendPanel1.Controls.Add(Me.CMBCOMPANYTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label37)
        Me.BlendPanel1.Controls.Add(Me.RBDEDUCTED)
        Me.BlendPanel1.Controls.Add(Me.RBNOTDEDUCTED)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(767, 592)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBCOMPANYTYPE
        '
        Me.CMBCOMPANYTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOMPANYTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOMPANYTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOMPANYTYPE.FormattingEnabled = True
        Me.CMBCOMPANYTYPE.Items.AddRange(New Object() {"", "COMPANY", "NONCOMPANY"})
        Me.CMBCOMPANYTYPE.Location = New System.Drawing.Point(396, 44)
        Me.CMBCOMPANYTYPE.Name = "CMBCOMPANYTYPE"
        Me.CMBCOMPANYTYPE.Size = New System.Drawing.Size(240, 23)
        Me.CMBCOMPANYTYPE.TabIndex = 553
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(308, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 554
        Me.Label1.Text = "Company Type"
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(396, 15)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(240, 23)
        Me.cmbregister.TabIndex = 0
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(342, 19)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(51, 15)
        Me.Label37.TabIndex = 552
        Me.Label37.Text = "Register"
        '
        'RBDEDUCTED
        '
        Me.RBDEDUCTED.AutoSize = True
        Me.RBDEDUCTED.BackColor = System.Drawing.Color.Transparent
        Me.RBDEDUCTED.Location = New System.Drawing.Point(157, 16)
        Me.RBDEDUCTED.Name = "RBDEDUCTED"
        Me.RBDEDUCTED.Size = New System.Drawing.Size(99, 19)
        Me.RBDEDUCTED.TabIndex = 3
        Me.RBDEDUCTED.Text = "TDS Deducted"
        Me.RBDEDUCTED.UseVisualStyleBackColor = False
        '
        'RBNOTDEDUCTED
        '
        Me.RBNOTDEDUCTED.AutoSize = True
        Me.RBNOTDEDUCTED.BackColor = System.Drawing.Color.Transparent
        Me.RBNOTDEDUCTED.Checked = True
        Me.RBNOTDEDUCTED.Location = New System.Drawing.Point(19, 16)
        Me.RBNOTDEDUCTED.Name = "RBNOTDEDUCTED"
        Me.RBNOTDEDUCTED.Size = New System.Drawing.Size(121, 19)
        Me.RBNOTDEDUCTED.TabIndex = 2
        Me.RBNOTDEDUCTED.TabStop = True
        Me.RBNOTDEDUCTED.Text = "TDS Not Deducted"
        Me.RBNOTDEDUCTED.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Location = New System.Drawing.Point(642, 12)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 1
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
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
        Me.CMDPRINT.Location = New System.Drawing.Point(728, 16)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 3
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(22, 73)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(730, 466)
        Me.gridbilldetails.TabIndex = 5
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GBILLNO, Me.GNAME, Me.GPARTYBILLNO, Me.GPARTYBILLDATE, Me.GGRANDTOTAL, Me.GTDSAMT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Entry No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 0
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 250
        '
        'GPARTYBILLNO
        '
        Me.GPARTYBILLNO.Caption = "Party Bill No"
        Me.GPARTYBILLNO.FieldName = "PARTYBILLNO"
        Me.GPARTYBILLNO.Name = "GPARTYBILLNO"
        Me.GPARTYBILLNO.Visible = True
        Me.GPARTYBILLNO.VisibleIndex = 2
        Me.GPARTYBILLNO.Width = 100
        '
        'GPARTYBILLDATE
        '
        Me.GPARTYBILLDATE.Caption = "Date"
        Me.GPARTYBILLDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPARTYBILLDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPARTYBILLDATE.FieldName = "PARTYBILLDATE"
        Me.GPARTYBILLDATE.Name = "GPARTYBILLDATE"
        Me.GPARTYBILLDATE.Visible = True
        Me.GPARTYBILLDATE.VisibleIndex = 3
        Me.GPARTYBILLDATE.Width = 80
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRANDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRANDTOTAL.FieldName = "GRANDTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 4
        Me.GGRANDTOTAL.Width = 100
        '
        'GTDSAMT
        '
        Me.GTDSAMT.Caption = "TDS Amt"
        Me.GTDSAMT.DisplayFormat.FormatString = "0.00"
        Me.GTDSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTDSAMT.FieldName = "TDSAMT"
        Me.GTDSAMT.Name = "GTDSAMT"
        Me.GTDSAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTDSAMT.Visible = True
        Me.GTDSAMT.VisibleIndex = 5
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(347, 555)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 4
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.Location = New System.Drawing.Point(19, 43)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 555
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.CustomFormat = "dd/MM/yyyy"
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(219, 41)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 558
        '
        'lblto
        '
        Me.lblto.AutoSize = True
        Me.lblto.BackColor = System.Drawing.Color.Transparent
        Me.lblto.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblto.Location = New System.Drawing.Point(197, 45)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(19, 14)
        Me.lblto.TabIndex = 559
        Me.lblto.Text = "To"
        '
        'dtfrom
        '
        Me.dtfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(109, 41)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(84, 22)
        Me.dtfrom.TabIndex = 557
        '
        'lblfrom
        '
        Me.lblfrom.AutoSize = True
        Me.lblfrom.BackColor = System.Drawing.Color.Transparent
        Me.lblfrom.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfrom.Location = New System.Drawing.Point(71, 45)
        Me.lblfrom.Name = "lblfrom"
        Me.lblfrom.Size = New System.Drawing.Size(34, 14)
        Me.lblfrom.TabIndex = 556
        Me.lblfrom.Text = "From"
        '
        'TDSDeductedReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(767, 592)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TDSDeductedReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TDS Deducted / Not Deducted Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents RBDEDUCTED As System.Windows.Forms.RadioButton
    Friend WithEvents RBNOTDEDUCTED As System.Windows.Forms.RadioButton
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYBILLDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTDSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CMBCOMPANYTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents lblto As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents lblfrom As Label
End Class
