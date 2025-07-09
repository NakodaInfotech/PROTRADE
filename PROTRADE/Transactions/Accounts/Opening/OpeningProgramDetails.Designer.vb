<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningProgramDetails
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCARDRECDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCADNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGREYWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GURGENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROGISSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRODCUTTING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINISHCUTTING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINWARDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 9
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(20, 50)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1202, 490)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GCARDRECDATE, Me.GNAME, Me.GQUALITY, Me.GDESIGNNO, Me.GCADNO, Me.GGREYWIDTH, Me.GWIDTH, Me.GMILLNAME, Me.GSHADE, Me.GURGENT, Me.GPCS, Me.GLOTNO, Me.GPROGISSDATE, Me.GSTATUS, Me.GPRODCUTTING, Me.GFINISHCUTTING, Me.GINWARDDATE, Me.GRECDPCS, Me.GBARCODE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No."
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
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
        'GCARDRECDATE
        '
        Me.GCARDRECDATE.Caption = "Card Rec Date"
        Me.GCARDRECDATE.FieldName = "CARDRECDATE"
        Me.GCARDRECDATE.Name = "GCARDRECDATE"
        Me.GCARDRECDATE.Visible = True
        Me.GCARDRECDATE.VisibleIndex = 2
        Me.GCARDRECDATE.Width = 85
        '
        'GNAME
        '
        Me.GNAME.Caption = "Dyeing Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 250
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Item Name"
        Me.GQUALITY.FieldName = "ITEMNAME"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 220
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 5
        Me.GDESIGNNO.Width = 100
        '
        'GCADNO
        '
        Me.GCADNO.Caption = "CAD No"
        Me.GCADNO.FieldName = "CADNO"
        Me.GCADNO.Name = "GCADNO"
        Me.GCADNO.Visible = True
        Me.GCADNO.VisibleIndex = 6
        '
        'GGREYWIDTH
        '
        Me.GGREYWIDTH.Caption = "Grey Width"
        Me.GGREYWIDTH.FieldName = "GREYWIDTH"
        Me.GGREYWIDTH.Name = "GGREYWIDTH"
        Me.GGREYWIDTH.Visible = True
        Me.GGREYWIDTH.VisibleIndex = 7
        '
        'GWIDTH
        '
        Me.GWIDTH.Caption = "Finish Width"
        Me.GWIDTH.FieldName = "WIDTH"
        Me.GWIDTH.Name = "GWIDTH"
        Me.GWIDTH.Visible = True
        Me.GWIDTH.VisibleIndex = 8
        '
        'GMILLNAME
        '
        Me.GMILLNAME.Caption = "MILL NAME"
        Me.GMILLNAME.FieldName = "MILLNAME"
        Me.GMILLNAME.Name = "GMILLNAME"
        Me.GMILLNAME.Visible = True
        Me.GMILLNAME.VisibleIndex = 9
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Color"
        Me.GSHADE.FieldName = "COLOR"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 10
        Me.GSHADE.Width = 100
        '
        'GURGENT
        '
        Me.GURGENT.Caption = "Urgent"
        Me.GURGENT.FieldName = "URGENT"
        Me.GURGENT.Name = "GURGENT"
        Me.GURGENT.Visible = True
        Me.GURGENT.VisibleIndex = 11
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 12
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 13
        '
        'GPROGISSDATE
        '
        Me.GPROGISSDATE.Caption = "Prog Iss Date"
        Me.GPROGISSDATE.FieldName = "PROGISSDATE"
        Me.GPROGISSDATE.Name = "GPROGISSDATE"
        Me.GPROGISSDATE.Visible = True
        Me.GPROGISSDATE.VisibleIndex = 14
        Me.GPROGISSDATE.Width = 100
        '
        'GSTATUS
        '
        Me.GSTATUS.Caption = "Status"
        Me.GSTATUS.FieldName = "STATUS"
        Me.GSTATUS.Name = "GSTATUS"
        Me.GSTATUS.Visible = True
        Me.GSTATUS.VisibleIndex = 15
        Me.GSTATUS.Width = 100
        '
        'GPRODCUTTING
        '
        Me.GPRODCUTTING.Caption = "Prod Cutting"
        Me.GPRODCUTTING.FieldName = "PRODCUTTING"
        Me.GPRODCUTTING.Name = "GPRODCUTTING"
        Me.GPRODCUTTING.Visible = True
        Me.GPRODCUTTING.VisibleIndex = 16
        Me.GPRODCUTTING.Width = 100
        '
        'GFINISHCUTTING
        '
        Me.GFINISHCUTTING.Caption = "Finish Cutting"
        Me.GFINISHCUTTING.FieldName = "FINISHCUTTING"
        Me.GFINISHCUTTING.Name = "GFINISHCUTTING"
        Me.GFINISHCUTTING.Visible = True
        Me.GFINISHCUTTING.VisibleIndex = 17
        Me.GFINISHCUTTING.Width = 100
        '
        'GINWARDDATE
        '
        Me.GINWARDDATE.Caption = "Inward Date"
        Me.GINWARDDATE.FieldName = "INWARDDATE"
        Me.GINWARDDATE.Name = "GINWARDDATE"
        Me.GINWARDDATE.Visible = True
        Me.GINWARDDATE.VisibleIndex = 18
        Me.GINWARDDATE.Width = 100
        '
        'GRECDPCS
        '
        Me.GRECDPCS.Caption = "Recd Pcs"
        Me.GRECDPCS.FieldName = "RECDPCS"
        Me.GRECDPCS.Name = "GRECDPCS"
        Me.GRECDPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECDPCS.Visible = True
        Me.GRECDPCS.VisibleIndex = 19
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Barcode"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 20
        Me.GBARCODE.Width = 120
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 546)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.EXCELEXPORT, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
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
        'EXCELEXPORT
        '
        Me.EXCELEXPORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXCELEXPORT.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.EXCELEXPORT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXCELEXPORT.Name = "EXCELEXPORT"
        Me.EXCELEXPORT.Size = New System.Drawing.Size(23, 22)
        Me.EXCELEXPORT.Text = "&Print"
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
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(159, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Packing Slip to Change"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(534, 546)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'OpeningProgramDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningProgramDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Program Details"
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
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCARDRECDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCADNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGREYWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GURGENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROGISSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRODCUTTING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINISHCUTTING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINWARDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents EXCELEXPORT As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents cmdok As Button
End Class
