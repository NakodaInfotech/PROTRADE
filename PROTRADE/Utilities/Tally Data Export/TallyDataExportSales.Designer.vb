<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TallyDataExportSales
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
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GINVOICENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXEMPTSALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOCALSALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTSALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISGT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOCALSALES12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGST12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGST12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTSALES12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGST12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVOUCHERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREGTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMDSHOW = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.dtto)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOW)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(211, 28)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(87, 23)
        Me.dtto.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(184, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 15)
        Me.Label7.TabIndex = 260
        Me.Label7.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(90, 28)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(87, 23)
        Me.dtfrom.TabIndex = 1
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(32, 30)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(51, 19)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(24, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1186, 478)
        Me.gridbilldetails.TabIndex = 4
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINVOICENO, Me.GDATE, Me.GGSTIN, Me.GNAME, Me.GEXEMPTSALE, Me.GLOCALSALES, Me.GCGST, Me.GSGST, Me.GridColumn4, Me.GIGSTSALES, Me.GISGT, Me.GridColumn7, Me.GLOCALSALES12, Me.GCGST12, Me.GSGST12, Me.GridColumn11, Me.GIGSTSALES12, Me.GIGST12, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GROUNDOFF, Me.GGRANDTOTAL, Me.GVOUCHERNAME, Me.GSTATE, Me.GREGTYPE, Me.GridColumn33})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GINVOICENO
        '
        Me.GINVOICENO.Caption = "BILLNO"
        Me.GINVOICENO.FieldName = "INVNO"
        Me.GINVOICENO.Name = "GINVOICENO"
        Me.GINVOICENO.Visible = True
        Me.GINVOICENO.VisibleIndex = 0
        '
        'GDATE
        '
        Me.GDATE.Caption = "DATE"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 2
        Me.GGSTIN.Width = 120
        '
        'GNAME
        '
        Me.GNAME.Caption = "CUSTOMER NAME"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 250
        '
        'GEXEMPTSALE
        '
        Me.GEXEMPTSALE.Caption = "Exempt Sale"
        Me.GEXEMPTSALE.Name = "GEXEMPTSALE"
        Me.GEXEMPTSALE.Visible = True
        Me.GEXEMPTSALE.VisibleIndex = 4
        Me.GEXEMPTSALE.Width = 30
        '
        'GLOCALSALES
        '
        Me.GLOCALSALES.Caption = "Local Sales 5%"
        Me.GLOCALSALES.FieldName = "LOCALSALES5"
        Me.GLOCALSALES.Name = "GLOCALSALES"
        Me.GLOCALSALES.Visible = True
        Me.GLOCALSALES.VisibleIndex = 5
        Me.GLOCALSALES.Width = 120
        '
        'GCGST
        '
        Me.GCGST.Caption = "CGST"
        Me.GCGST.FieldName = "CGST5"
        Me.GCGST.Name = "GCGST"
        Me.GCGST.Visible = True
        Me.GCGST.VisibleIndex = 6
        '
        'GSGST
        '
        Me.GSGST.Caption = "SGST"
        Me.GSGST.FieldName = "SGST5"
        Me.GSGST.Name = "GSGST"
        Me.GSGST.Visible = True
        Me.GSGST.VisibleIndex = 7
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "9"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 8
        Me.GridColumn4.Width = 30
        '
        'GIGSTSALES
        '
        Me.GIGSTSALES.Caption = "IGST Sales 5%"
        Me.GIGSTSALES.FieldName = "IGSTSALES5"
        Me.GIGSTSALES.Name = "GIGSTSALES"
        Me.GIGSTSALES.Visible = True
        Me.GIGSTSALES.VisibleIndex = 9
        Me.GIGSTSALES.Width = 120
        '
        'GISGT
        '
        Me.GISGT.Caption = "IGST"
        Me.GISGT.FieldName = "IGST5"
        Me.GISGT.Name = "GISGT"
        Me.GISGT.Visible = True
        Me.GISGT.VisibleIndex = 10
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "12"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 11
        Me.GridColumn7.Width = 30
        '
        'GLOCALSALES12
        '
        Me.GLOCALSALES12.Caption = "Local Sales 12%"
        Me.GLOCALSALES12.FieldName = "LOCALSALES12"
        Me.GLOCALSALES12.Name = "GLOCALSALES12"
        Me.GLOCALSALES12.Visible = True
        Me.GLOCALSALES12.VisibleIndex = 12
        '
        'GCGST12
        '
        Me.GCGST12.Caption = "CGST"
        Me.GCGST12.FieldName = "CGST12"
        Me.GCGST12.Name = "GCGST12"
        Me.GCGST12.Visible = True
        Me.GCGST12.VisibleIndex = 13
        '
        'GSGST12
        '
        Me.GSGST12.Caption = "SGST"
        Me.GSGST12.FieldName = "SGST12"
        Me.GSGST12.Name = "GSGST12"
        Me.GSGST12.Visible = True
        Me.GSGST12.VisibleIndex = 14
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "16"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 15
        Me.GridColumn11.Width = 30
        '
        'GIGSTSALES12
        '
        Me.GIGSTSALES12.Caption = "IGST Sales 12%"
        Me.GIGSTSALES12.FieldName = "IGSTSALES12"
        Me.GIGSTSALES12.Name = "GIGSTSALES12"
        Me.GIGSTSALES12.Visible = True
        Me.GIGSTSALES12.VisibleIndex = 16
        '
        'GIGST12
        '
        Me.GIGST12.Caption = "IGST"
        Me.GIGST12.FieldName = "IGST12"
        Me.GIGST12.Name = "GIGST12"
        Me.GIGST12.Visible = True
        Me.GIGST12.VisibleIndex = 17
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "19"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 18
        Me.GridColumn14.Width = 30
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "20"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 19
        Me.GridColumn15.Width = 30
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "21"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 20
        Me.GridColumn16.Width = 30
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "22"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 21
        Me.GridColumn17.Width = 30
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "23"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 22
        Me.GridColumn18.Width = 30
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "24"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 23
        Me.GridColumn19.Width = 30
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "25"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 24
        Me.GridColumn20.Width = 30
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "26"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 25
        Me.GridColumn21.Width = 30
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "27"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 26
        Me.GridColumn22.Width = 30
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "28"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 27
        Me.GridColumn23.Width = 30
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "29"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 28
        Me.GridColumn24.Width = 30
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "30"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 29
        Me.GridColumn25.Width = 30
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "31"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 30
        Me.GridColumn26.Width = 30
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "32"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 31
        Me.GridColumn27.Width = 30
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Round Off"
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 32
        Me.GROUNDOFF.Width = 30
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Net Amount"
        Me.GGRANDTOTAL.FieldName = "GRANDTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 33
        '
        'GVOUCHERNAME
        '
        Me.GVOUCHERNAME.Caption = "Voucher Type Name"
        Me.GVOUCHERNAME.FieldName = "VOUCHERTYPE"
        Me.GVOUCHERNAME.Name = "GVOUCHERNAME"
        Me.GVOUCHERNAME.Visible = True
        Me.GVOUCHERNAME.VisibleIndex = 34
        '
        'GSTATE
        '
        Me.GSTATE.Caption = "State"
        Me.GSTATE.FieldName = "STATENAME"
        Me.GSTATE.Name = "GSTATE"
        Me.GSTATE.Visible = True
        Me.GSTATE.VisibleIndex = 35
        '
        'GREGTYPE
        '
        Me.GREGTYPE.Caption = "Reg Type"
        Me.GREGTYPE.FieldName = "REGTYPE"
        Me.GREGTYPE.Name = "GREGTYPE"
        Me.GREGTYPE.Visible = True
        Me.GREGTYPE.VisibleIndex = 36
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "38"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 37
        Me.GridColumn33.Width = 30
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(577, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLEXCEL, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "&Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CMDSHOW
        '
        Me.CMDSHOW.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOW.FlatAppearance.BorderSize = 0
        Me.CMDSHOW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOW.ForeColor = System.Drawing.Color.Black
        Me.CMDSHOW.Location = New System.Drawing.Point(304, 28)
        Me.CMDSHOW.Name = "CMDSHOW"
        Me.CMDSHOW.Size = New System.Drawing.Size(80, 28)
        Me.CMDSHOW.TabIndex = 3
        Me.CMDSHOW.Text = "&Show Data"
        Me.CMDSHOW.UseVisualStyleBackColor = False
        '
        'TallyDataExportSales
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "TallyDataExportSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tally Data Export (Sales)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GINVOICENO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXEMPTSALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOCALSALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTSALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISGT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOCALSALES12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGST12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGST12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTSALES12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGST12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVOUCHERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREGTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CMDSHOW As Button
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents chkdate As CheckBox
End Class
