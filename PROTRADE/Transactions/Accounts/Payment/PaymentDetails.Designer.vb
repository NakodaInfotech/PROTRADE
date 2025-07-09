<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PaymentDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.gridpayment = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gregisterid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gchq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbankname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gremarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAGENTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYBANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIFSC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBRANCH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBANKCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExcelExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.CHQPRINTTOOL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.gchqno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridpayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(370, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 807
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(411, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 806
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(270, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 795
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(180, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 794
        Me.Label10.Text = "From"
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(215, 2)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(50, 22)
        Me.TXTFROM.TabIndex = 792
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(291, 2)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(52, 22)
        Me.TXTTO.TabIndex = 793
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(509, 555)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 323
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(595, 557)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 322
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(781, 40)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(227, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(725, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 319
        Me.Label1.Text = "Register"
        '
        'griddetails
        '
        Me.griddetails.Location = New System.Drawing.Point(18, 69)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.gridpayment
        Me.griddetails.Name = "griddetails"
        Me.griddetails.Size = New System.Drawing.Size(1154, 480)
        Me.griddetails.TabIndex = 1
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridpayment})
        '
        'gridpayment
        '
        Me.gridpayment.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridpayment.Appearance.Row.Options.UseFont = True
        Me.gridpayment.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.gname, Me.gdate, Me.gtotal, Me.gregisterid, Me.gchq, Me.gbankname, Me.GBILLREMARKS, Me.gremarks, Me.GAGENTNAME, Me.GPARTYBANK, Me.GACCTYPE, Me.GACCNO, Me.GIFSC, Me.GBRANCH, Me.GBANKCITY})
        Me.gridpayment.GridControl = Me.griddetails
        Me.gridpayment.Images = Me.imageList1
        Me.gridpayment.Name = "gridpayment"
        Me.gridpayment.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridpayment.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridpayment.OptionsBehavior.Editable = False
        Me.gridpayment.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridpayment.OptionsSelection.MultiSelect = True
        Me.gridpayment.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridpayment.OptionsView.ColumnAutoWidth = False
        Me.gridpayment.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridpayment.OptionsView.ShowAutoFilterRow = True
        Me.gridpayment.OptionsView.ShowFooter = True
        Me.gridpayment.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr. No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 50
        '
        'gname
        '
        Me.gname.Caption = "Name"
        Me.gname.FieldName = "Name"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 2
        Me.gname.Width = 210
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "Date"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 3
        '
        'gtotal
        '
        Me.gtotal.Caption = "Total"
        Me.gtotal.DisplayFormat.FormatString = "0.00"
        Me.gtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gtotal.FieldName = "Total"
        Me.gtotal.Name = "gtotal"
        Me.gtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.gtotal.Visible = True
        Me.gtotal.VisibleIndex = 4
        Me.gtotal.Width = 90
        '
        'gregisterid
        '
        Me.gregisterid.Caption = "Registerid"
        Me.gregisterid.FieldName = "Registerid"
        Me.gregisterid.Name = "gregisterid"
        '
        'gchq
        '
        Me.gchq.Caption = "Chq. No."
        Me.gchq.FieldName = "Chq. No."
        Me.gchq.Name = "gchq"
        Me.gchq.Visible = True
        Me.gchq.VisibleIndex = 5
        '
        'gbankname
        '
        Me.gbankname.Caption = "Bank Name"
        Me.gbankname.FieldName = "BankName"
        Me.gbankname.Name = "gbankname"
        Me.gbankname.Visible = True
        Me.gbankname.VisibleIndex = 6
        Me.gbankname.Width = 200
        '
        'GBILLREMARKS
        '
        Me.GBILLREMARKS.Caption = "Against Bill Nos"
        Me.GBILLREMARKS.FieldName = "BILLREMARKS"
        Me.GBILLREMARKS.Name = "GBILLREMARKS"
        Me.GBILLREMARKS.Visible = True
        Me.GBILLREMARKS.VisibleIndex = 7
        Me.GBILLREMARKS.Width = 220
        '
        'gremarks
        '
        Me.gremarks.Caption = "Remarks"
        Me.gremarks.FieldName = "Remarks"
        Me.gremarks.Name = "gremarks"
        Me.gremarks.Visible = True
        Me.gremarks.VisibleIndex = 8
        Me.gremarks.Width = 183
        '
        'GAGENTNAME
        '
        Me.GAGENTNAME.Caption = "Agent Name"
        Me.GAGENTNAME.FieldName = "AGENTNAME"
        Me.GAGENTNAME.Name = "GAGENTNAME"
        Me.GAGENTNAME.Visible = True
        Me.GAGENTNAME.VisibleIndex = 9
        Me.GAGENTNAME.Width = 200
        '
        'GPARTYBANK
        '
        Me.GPARTYBANK.Caption = "Party Bank"
        Me.GPARTYBANK.FieldName = "PARTYBANK"
        Me.GPARTYBANK.Name = "GPARTYBANK"
        Me.GPARTYBANK.Visible = True
        Me.GPARTYBANK.VisibleIndex = 10
        '
        'GACCTYPE
        '
        Me.GACCTYPE.Caption = "A/C Type"
        Me.GACCTYPE.FieldName = "ACCTYPE"
        Me.GACCTYPE.Name = "GACCTYPE"
        Me.GACCTYPE.Visible = True
        Me.GACCTYPE.VisibleIndex = 11
        '
        'GACCNO
        '
        Me.GACCNO.Caption = "Acc No"
        Me.GACCNO.FieldName = "ACCOUNTNO"
        Me.GACCNO.Name = "GACCNO"
        Me.GACCNO.Visible = True
        Me.GACCNO.VisibleIndex = 12
        '
        'GIFSC
        '
        Me.GIFSC.Caption = "IFSC Code"
        Me.GIFSC.FieldName = "IFSCCODE"
        Me.GIFSC.Name = "GIFSC"
        Me.GIFSC.Visible = True
        Me.GIFSC.VisibleIndex = 13
        '
        'GBRANCH
        '
        Me.GBRANCH.Caption = "Branch"
        Me.GBRANCH.FieldName = "BRANCH"
        Me.GBRANCH.Name = "GBRANCH"
        Me.GBRANCH.Visible = True
        Me.GBRANCH.VisibleIndex = 14
        '
        'GBANKCITY
        '
        Me.GBANKCITY.Caption = "City"
        Me.GBANKCITY.FieldName = "BANKCITY"
        Me.GBANKCITY.Name = "GBANKCITY"
        Me.GBANKCITY.Visible = True
        Me.GBANKCITY.VisibleIndex = 15
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ExcelExport, Me.ToolStripSeparator2, Me.TOOLMAIL, Me.TOOLWHATSAPP, Me.CHQPRINTTOOL, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.PROTRADE.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Credit Note Directly"
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.PROTRADE.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "Whatsapp Cedit Note Directly"
        '
        'CHQPRINTTOOL
        '
        Me.CHQPRINTTOOL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CHQPRINTTOOL.Image = CType(resources.GetObject("CHQPRINTTOOL.Image"), System.Drawing.Image)
        Me.CHQPRINTTOOL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CHQPRINTTOOL.Name = "CHQPRINTTOOL"
        Me.CHQPRINTTOOL.Size = New System.Drawing.Size(23, 22)
        Me.CHQPRINTTOOL.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(15, 48)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(156, 14)
        Me.lbl.TabIndex = 312
        Me.lbl.Text = "Select a Payment to Change"
        '
        'gchqno
        '
        Me.gchqno.Caption = "Chq. No."
        Me.gchqno.Name = "gchqno"
        Me.gchqno.Visible = True
        Me.gchqno.VisibleIndex = 4
        Me.gchqno.Width = 100
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'PaymentDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "PaymentDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payment Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridpayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gridpayment As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gregisterid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gremarks As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents gchqno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gchq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gbankname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExcelExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GBILLREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents CHQPRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GAGENTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYBANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIFSC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBRANCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBANKCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
End Class
