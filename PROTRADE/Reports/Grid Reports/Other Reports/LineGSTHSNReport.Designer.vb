<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LineGSTHSNReport
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
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GINVINITIALS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGATAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Location = New System.Drawing.Point(586, 12)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 3
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
        Me.CMDPRINT.Location = New System.Drawing.Point(672, 20)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 4
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(18, 47)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1154, 480)
        Me.gridbilldetails.TabIndex = 5
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINVINITIALS, Me.GDATE, Me.GNAME, Me.GGSTIN, Me.GSTATENAME, Me.GSTATECODE, Me.GCITYNAME, Me.GPCS, Me.GMTRS, Me.GHSNCODE, Me.GGSTPER, Me.GTAXABLEAMT, Me.CGSTAMT, Me.GSGATAMT, Me.GIGSTAMT, Me.GTOTALAMT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(552, 533)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 5
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(30, 17)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(51, 19)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(265, 15)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(88, 23)
        Me.dtto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(237, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 15)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(126, 15)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(88, 23)
        Me.dtfrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(85, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 15)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'GINVINITIALS
        '
        Me.GINVINITIALS.Caption = "Invoice No"
        Me.GINVINITIALS.FieldName = "INVNO"
        Me.GINVINITIALS.Name = "GINVINITIALS"
        Me.GINVINITIALS.Visible = True
        Me.GINVINITIALS.VisibleIndex = 0
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 3
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State Name"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 4
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "State Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 5
        '
        'GCITYNAME
        '
        Me.GCITYNAME.Caption = "City Name"
        Me.GCITYNAME.FieldName = "CITYNAME"
        Me.GCITYNAME.Name = "GCITYNAME"
        Me.GCITYNAME.Visible = True
        Me.GCITYNAME.VisibleIndex = 6
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PCS", "{0:0}")})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 7
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MTRS", "{0:0.00}")})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 8
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 9
        '
        'GGSTPER
        '
        Me.GGSTPER.Caption = "Per"
        Me.GGSTPER.DisplayFormat.FormatString = "0.00"
        Me.GGSTPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGSTPER.FieldName = "GSTPER"
        Me.GGSTPER.Name = "GGSTPER"
        Me.GGSTPER.Visible = True
        Me.GGSTPER.VisibleIndex = 10
        '
        'GTAXABLEAMT
        '
        Me.GTAXABLEAMT.Caption = "Taxable Amt"
        Me.GTAXABLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXABLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXABLEAMT.FieldName = "TAXABLEAMT"
        Me.GTAXABLEAMT.Name = "GTAXABLEAMT"
        Me.GTAXABLEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TAXABLEAMT", "{0:0.00}")})
        Me.GTAXABLEAMT.Visible = True
        Me.GTAXABLEAMT.VisibleIndex = 11
        '
        'CGSTAMT
        '
        Me.CGSTAMT.Caption = "CGST Amt"
        Me.CGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.CGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CGSTAMT.FieldName = "CGSTAMT"
        Me.CGSTAMT.Name = "CGSTAMT"
        Me.CGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CGSTAMT", "{0:0.00}")})
        Me.CGSTAMT.Visible = True
        Me.CGSTAMT.VisibleIndex = 12
        '
        'GSGATAMT
        '
        Me.GSGATAMT.Caption = "SGST Amt"
        Me.GSGATAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGATAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGATAMT.FieldName = "SGSTAMT"
        Me.GSGATAMT.Name = "GSGATAMT"
        Me.GSGATAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SGSTAMT", "{0:0.00}")})
        Me.GSGATAMT.Visible = True
        Me.GSGATAMT.VisibleIndex = 13
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt"
        Me.GIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IGSTAMT", "{0:0.00}")})
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 14
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALAMT.FieldName = "TOTALAMT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTALAMT", "{0:0.00}")})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 15
        '
        'LineGSTHSNReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LineGSTHSNReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GST HSN Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents CMDPRINT As Button
    Friend WithEvents cmdcancel As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents GINVINITIALS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGATAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
End Class
