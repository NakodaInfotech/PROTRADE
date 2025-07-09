<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmbProductionDetails
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
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLABOUR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACHINENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTITCHES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFRAMES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRUNFRAMES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACTUALPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GJONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 8
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 49)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 480)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GLABOUR, Me.GSHIFT, Me.GMACHINENO, Me.GITEMNAME, Me.GSHADE, Me.GMTRS, Me.GSTITCHES, Me.GFRAMES, Me.GRUNFRAMES, Me.GTOTALPROD, Me.GACTUALPROD, Me.GDIFF, Me.GCHALLANNO, Me.GCHALLANDATE, Me.GREMARKS, Me.GJONO, Me.GJOSRNO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "PRODNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 80
        '
        'GLABOUR
        '
        Me.GLABOUR.Caption = "Labour Name"
        Me.GLABOUR.FieldName = "LABOUR"
        Me.GLABOUR.Name = "GLABOUR"
        Me.GLABOUR.Visible = True
        Me.GLABOUR.VisibleIndex = 2
        Me.GLABOUR.Width = 200
        '
        'GSHIFT
        '
        Me.GSHIFT.Caption = "Shift"
        Me.GSHIFT.FieldName = "SHIFT"
        Me.GSHIFT.Name = "GSHIFT"
        Me.GSHIFT.Visible = True
        Me.GSHIFT.VisibleIndex = 3
        '
        'GMACHINENO
        '
        Me.GMACHINENO.Caption = "Machine No"
        Me.GMACHINENO.FieldName = "MACHINENO"
        Me.GMACHINENO.Name = "GMACHINENO"
        Me.GMACHINENO.Visible = True
        Me.GMACHINENO.VisibleIndex = 4
        Me.GMACHINENO.Width = 150
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 5
        Me.GITEMNAME.Width = 200
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 6
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 7
        '
        'GSTITCHES
        '
        Me.GSTITCHES.Caption = "Stitches"
        Me.GSTITCHES.DisplayFormat.FormatString = "0"
        Me.GSTITCHES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSTITCHES.FieldName = "STITCHES"
        Me.GSTITCHES.Name = "GSTITCHES"
        Me.GSTITCHES.Visible = True
        Me.GSTITCHES.VisibleIndex = 8
        '
        'GFRAMES
        '
        Me.GFRAMES.Caption = "Frames"
        Me.GFRAMES.DisplayFormat.FormatString = "0"
        Me.GFRAMES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFRAMES.FieldName = "FRAMES"
        Me.GFRAMES.Name = "GFRAMES"
        Me.GFRAMES.Visible = True
        Me.GFRAMES.VisibleIndex = 9
        '
        'GRUNFRAMES
        '
        Me.GRUNFRAMES.Caption = "Run Frames"
        Me.GRUNFRAMES.DisplayFormat.FormatString = "0"
        Me.GRUNFRAMES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRUNFRAMES.FieldName = "RUNFRAMES"
        Me.GRUNFRAMES.Name = "GRUNFRAMES"
        Me.GRUNFRAMES.Visible = True
        Me.GRUNFRAMES.VisibleIndex = 10
        Me.GRUNFRAMES.Width = 85
        '
        'GTOTALPROD
        '
        Me.GTOTALPROD.Caption = "Total Prod"
        Me.GTOTALPROD.DisplayFormat.FormatString = "0"
        Me.GTOTALPROD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALPROD.FieldName = "TOTALPROD"
        Me.GTOTALPROD.Name = "GTOTALPROD"
        Me.GTOTALPROD.Visible = True
        Me.GTOTALPROD.VisibleIndex = 11
        Me.GTOTALPROD.Width = 85
        '
        'GACTUALPROD
        '
        Me.GACTUALPROD.Caption = "Actual Prod"
        Me.GACTUALPROD.DisplayFormat.FormatString = "0"
        Me.GACTUALPROD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACTUALPROD.FieldName = "ACTUALPROD"
        Me.GACTUALPROD.Name = "GACTUALPROD"
        Me.GACTUALPROD.Visible = True
        Me.GACTUALPROD.VisibleIndex = 12
        Me.GACTUALPROD.Width = 85
        '
        'GDIFF
        '
        Me.GDIFF.Caption = "Diff"
        Me.GDIFF.DisplayFormat.FormatString = "0"
        Me.GDIFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDIFF.FieldName = "DIFF"
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.Visible = True
        Me.GDIFF.VisibleIndex = 13
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No"
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 14
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Challan Dt"
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        Me.GCHALLANDATE.Visible = True
        Me.GCHALLANDATE.VisibleIndex = 15
        Me.GCHALLANDATE.Width = 85
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 16
        Me.GREMARKS.Width = 200
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 535)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator2})
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PROTRADE.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(534, 535)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GJONO
        '
        Me.GJONO.Caption = "JO No"
        Me.GJONO.FieldName = "JONO"
        Me.GJONO.Name = "GJONO"
        Me.GJONO.Visible = True
        Me.GJONO.VisibleIndex = 17
        '
        'GJOSRNO
        '
        Me.GJOSRNO.Caption = "JO Sr No"
        Me.GJOSRNO.FieldName = "JOSRNO"
        Me.GJOSRNO.Name = "GJOSRNO"
        Me.GJOSRNO.Visible = True
        Me.GJOSRNO.VisibleIndex = 18
        '
        'EmbProductionDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "EmbProductionDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Emb Production Details"
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
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdok As Button
    Friend WithEvents GLABOUR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMACHINENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTITCHES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFRAMES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRUNFRAMES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACTUALPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOSRNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
