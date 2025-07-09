<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotGridreport
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
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GJOBBERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHORTPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHORTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREJPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREJMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCEPTEDPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCEPTEDMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHRINKAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHRINKAGEPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Location = New System.Drawing.Point(534, 545)
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
        Me.CMDPRINT.Location = New System.Drawing.Point(503, 545)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 4
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 545)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 5
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(18, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1204, 527)
        Me.gridbilldetails.TabIndex = 5
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GJOBBERNAME, Me.GLOTNO, Me.GITEMNAME, Me.GDESIGN, Me.GTOTALPCS, Me.GTOTALMTRS, Me.GSHORTPCS, Me.GSHORTMTRS, Me.GCHECKPCS, Me.GCHECKMTRS, Me.GREJPCS, Me.GREJMTRS, Me.GACCEPTEDPCS, Me.GACCEPTEDMTRS, Me.GRECDPCS, Me.GRECDMTRS, Me.GBALPCS, Me.GBALMTRS, Me.GSHRINKAGE, Me.GSHRINKAGEPER, Me.GRATE, Me.GPARTYNAME, Me.GLRNO, Me.GRECDDATE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GJOBBERNAME
        '
        Me.GJOBBERNAME.Caption = "Jobber Name"
        Me.GJOBBERNAME.FieldName = "JOBBERNAME"
        Me.GJOBBERNAME.Name = "GJOBBERNAME"
        Me.GJOBBERNAME.Visible = True
        Me.GJOBBERNAME.VisibleIndex = 0
        Me.GJOBBERNAME.Width = 200
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 1
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 2
        Me.GITEMNAME.Width = 120
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 3
        Me.GDESIGN.Width = 120
        '
        'GTOTALPCS
        '
        Me.GTOTALPCS.Caption = "Total Pcs"
        Me.GTOTALPCS.DisplayFormat.FormatString = "0"
        Me.GTOTALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALPCS.FieldName = "TOTALPCS"
        Me.GTOTALPCS.Name = "GTOTALPCS"
        Me.GTOTALPCS.Visible = True
        Me.GTOTALPCS.VisibleIndex = 4
        Me.GTOTALPCS.Width = 85
        '
        'GTOTALMTRS
        '
        Me.GTOTALMTRS.Caption = "Total Mtrs"
        Me.GTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMTRS.FieldName = "TOTALMTRS"
        Me.GTOTALMTRS.Name = "GTOTALMTRS"
        Me.GTOTALMTRS.Visible = True
        Me.GTOTALMTRS.VisibleIndex = 5
        Me.GTOTALMTRS.Width = 85
        '
        'GSHORTPCS
        '
        Me.GSHORTPCS.Caption = "Short Pcs"
        Me.GSHORTPCS.DisplayFormat.FormatString = "0"
        Me.GSHORTPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHORTPCS.FieldName = "SHORTPCS"
        Me.GSHORTPCS.Name = "GSHORTPCS"
        Me.GSHORTPCS.Visible = True
        Me.GSHORTPCS.VisibleIndex = 6
        Me.GSHORTPCS.Width = 85
        '
        'GSHORTMTRS
        '
        Me.GSHORTMTRS.Caption = "Short Mtrs"
        Me.GSHORTMTRS.DisplayFormat.FormatString = "0.00"
        Me.GSHORTMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHORTMTRS.FieldName = "SHORTMTRS"
        Me.GSHORTMTRS.Name = "GSHORTMTRS"
        Me.GSHORTMTRS.Visible = True
        Me.GSHORTMTRS.VisibleIndex = 7
        Me.GSHORTMTRS.Width = 85
        '
        'GCHECKPCS
        '
        Me.GCHECKPCS.Caption = "Check Pcs"
        Me.GCHECKPCS.DisplayFormat.FormatString = "0"
        Me.GCHECKPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHECKPCS.FieldName = "CHECKPCS"
        Me.GCHECKPCS.Name = "GCHECKPCS"
        Me.GCHECKPCS.Visible = True
        Me.GCHECKPCS.VisibleIndex = 8
        Me.GCHECKPCS.Width = 85
        '
        'GCHECKMTRS
        '
        Me.GCHECKMTRS.Caption = "Check Mtrs"
        Me.GCHECKMTRS.DisplayFormat.FormatString = "0.00"
        Me.GCHECKMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHECKMTRS.FieldName = "CHECKMTRS"
        Me.GCHECKMTRS.Name = "GCHECKMTRS"
        Me.GCHECKMTRS.Visible = True
        Me.GCHECKMTRS.VisibleIndex = 9
        Me.GCHECKMTRS.Width = 85
        '
        'GREJPCS
        '
        Me.GREJPCS.Caption = "Rej Pcs"
        Me.GREJPCS.DisplayFormat.FormatString = "0"
        Me.GREJPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREJPCS.FieldName = "REJPCS"
        Me.GREJPCS.Name = "GREJPCS"
        Me.GREJPCS.Visible = True
        Me.GREJPCS.VisibleIndex = 10
        Me.GREJPCS.Width = 85
        '
        'GREJMTRS
        '
        Me.GREJMTRS.Caption = "Rej Mtrs"
        Me.GREJMTRS.DisplayFormat.FormatString = "0.00"
        Me.GREJMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREJMTRS.FieldName = "REJMTRS"
        Me.GREJMTRS.Name = "GREJMTRS"
        Me.GREJMTRS.Visible = True
        Me.GREJMTRS.VisibleIndex = 11
        Me.GREJMTRS.Width = 85
        '
        'GACCEPTEDPCS
        '
        Me.GACCEPTEDPCS.Caption = "Accepted Pcs"
        Me.GACCEPTEDPCS.DisplayFormat.FormatString = "0"
        Me.GACCEPTEDPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACCEPTEDPCS.FieldName = "ACCEPTEDPCS"
        Me.GACCEPTEDPCS.Name = "GACCEPTEDPCS"
        Me.GACCEPTEDPCS.Visible = True
        Me.GACCEPTEDPCS.VisibleIndex = 12
        Me.GACCEPTEDPCS.Width = 85
        '
        'GACCEPTEDMTRS
        '
        Me.GACCEPTEDMTRS.Caption = "Accepted Mtrs"
        Me.GACCEPTEDMTRS.DisplayFormat.FormatString = "0.00"
        Me.GACCEPTEDMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACCEPTEDMTRS.FieldName = "ACCEPTEDMTRS"
        Me.GACCEPTEDMTRS.Name = "GACCEPTEDMTRS"
        Me.GACCEPTEDMTRS.Visible = True
        Me.GACCEPTEDMTRS.VisibleIndex = 13
        Me.GACCEPTEDMTRS.Width = 85
        '
        'GRECDPCS
        '
        Me.GRECDPCS.Caption = "Recd Pcs"
        Me.GRECDPCS.DisplayFormat.FormatString = "0"
        Me.GRECDPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECDPCS.FieldName = "RECDPCS"
        Me.GRECDPCS.Name = "GRECDPCS"
        Me.GRECDPCS.Visible = True
        Me.GRECDPCS.VisibleIndex = 14
        Me.GRECDPCS.Width = 85
        '
        'GRECDMTRS
        '
        Me.GRECDMTRS.Caption = "Recd Mtrs"
        Me.GRECDMTRS.DisplayFormat.FormatString = "0.00"
        Me.GRECDMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRECDMTRS.FieldName = "RECDMTRS"
        Me.GRECDMTRS.Name = "GRECDMTRS"
        Me.GRECDMTRS.Visible = True
        Me.GRECDMTRS.VisibleIndex = 15
        Me.GRECDMTRS.Width = 85
        '
        'GBALPCS
        '
        Me.GBALPCS.Caption = "Bal Pcs"
        Me.GBALPCS.DisplayFormat.FormatString = "0"
        Me.GBALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALPCS.FieldName = "BALPCS"
        Me.GBALPCS.Name = "GBALPCS"
        Me.GBALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALPCS.Visible = True
        Me.GBALPCS.VisibleIndex = 16
        Me.GBALPCS.Width = 85
        '
        'GBALMTRS
        '
        Me.GBALMTRS.Caption = "Bal Mtrs"
        Me.GBALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GBALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALMTRS.FieldName = "BALMTRS"
        Me.GBALMTRS.Name = "GBALMTRS"
        Me.GBALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALMTRS.Visible = True
        Me.GBALMTRS.VisibleIndex = 17
        Me.GBALMTRS.Width = 85
        '
        'GSHRINKAGE
        '
        Me.GSHRINKAGE.Caption = "Shirnkage"
        Me.GSHRINKAGE.DisplayFormat.FormatString = "0.00"
        Me.GSHRINKAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHRINKAGE.FieldName = "SHRINKAGE"
        Me.GSHRINKAGE.Name = "GSHRINKAGE"
        Me.GSHRINKAGE.Visible = True
        Me.GSHRINKAGE.VisibleIndex = 18
        Me.GSHRINKAGE.Width = 85
        '
        'GSHRINKAGEPER
        '
        Me.GSHRINKAGEPER.Caption = "Shrink %"
        Me.GSHRINKAGEPER.DisplayFormat.FormatString = "0.00"
        Me.GSHRINKAGEPER.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHRINKAGEPER.FieldName = "SHRINKPER"
        Me.GSHRINKAGEPER.Name = "GSHRINKAGEPER"
        Me.GSHRINKAGEPER.Visible = True
        Me.GSHRINKAGEPER.VisibleIndex = 19
        Me.GSHRINKAGEPER.Width = 85
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "PURRATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 20
        '
        'GPARTYNAME
        '
        Me.GPARTYNAME.Caption = "Party Name"
        Me.GPARTYNAME.FieldName = "PARTYNAME"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.Visible = True
        Me.GPARTYNAME.VisibleIndex = 21
        Me.GPARTYNAME.Width = 200
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "LR No"
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Visible = True
        Me.GLRNO.VisibleIndex = 22
        Me.GLRNO.Width = 100
        '
        'GRECDDATE
        '
        Me.GRECDDATE.Caption = "Lot No Date"
        Me.GRECDDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRECDDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRECDDATE.FieldName = "LOTNODATE"
        Me.GRECDDATE.Name = "GRECDDATE"
        Me.GRECDDATE.Visible = True
        Me.GRECDDATE.VisibleIndex = 23
        Me.GRECDDATE.Width = 80
        '
        'LotGridreport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LotGridreport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lot Grid Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
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
    Friend WithEvents GJOBBERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTEDPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTEDMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHRINKAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHRINKAGEPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDDATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
