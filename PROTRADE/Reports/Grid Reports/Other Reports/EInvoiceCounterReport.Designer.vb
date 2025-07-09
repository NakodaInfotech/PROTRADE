<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EInvoiceCounterReport
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
        Me.CMDEXPORT = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GENTRYNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOKENNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCREATED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GERRORMSG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDEXPORT)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 16
        '
        'CMDEXPORT
        '
        Me.CMDEXPORT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXPORT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXPORT.FlatAppearance.BorderSize = 0
        Me.CMDEXPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXPORT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXPORT.Location = New System.Drawing.Point(563, 533)
        Me.CMDEXPORT.Name = "CMDEXPORT"
        Me.CMDEXPORT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXPORT.TabIndex = 805
        Me.CMDEXPORT.Text = "Export"
        Me.CMDEXPORT.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(393, 533)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 802
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(478, 533)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 803
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(10, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT})
        Me.gridbilldetails.Size = New System.Drawing.Size(1226, 515)
        Me.gridbilldetails.TabIndex = 257
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GENTRYNO, Me.GTYPE, Me.GTOKENNO, Me.GIRNNO, Me.GSTATUS, Me.GCREATED, Me.GERRORMSG})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "COUNTERID"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SRNO", "{0}")})
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 60
        '
        'GENTRYNO
        '
        Me.GENTRYNO.Caption = "Entry No"
        Me.GENTRYNO.FieldName = "ENTRYNO"
        Me.GENTRYNO.Name = "GENTRYNO"
        Me.GENTRYNO.OptionsColumn.AllowEdit = False
        Me.GENTRYNO.Visible = True
        Me.GENTRYNO.VisibleIndex = 1
        Me.GENTRYNO.Width = 100
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "ENTRYTYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 2
        Me.GTYPE.Width = 100
        '
        'GTOKENNO
        '
        Me.GTOKENNO.Caption = "Token No"
        Me.GTOKENNO.FieldName = "TOKENNO"
        Me.GTOKENNO.Name = "GTOKENNO"
        Me.GTOKENNO.OptionsColumn.AllowEdit = False
        Me.GTOKENNO.Visible = True
        Me.GTOKENNO.VisibleIndex = 3
        Me.GTOKENNO.Width = 350
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "IRN No"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 4
        Me.GIRNNO.Width = 350
        '
        'GSTATUS
        '
        Me.GSTATUS.Caption = "Status"
        Me.GSTATUS.FieldName = "STATUS"
        Me.GSTATUS.Name = "GSTATUS"
        Me.GSTATUS.Visible = True
        Me.GSTATUS.VisibleIndex = 5
        Me.GSTATUS.Width = 120
        '
        'GCREATED
        '
        Me.GCREATED.Caption = "Created"
        Me.GCREATED.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCREATED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCREATED.FieldName = "CREATED"
        Me.GCREATED.Name = "GCREATED"
        Me.GCREATED.Visible = True
        Me.GCREATED.VisibleIndex = 6
        Me.GCREATED.Width = 100
        '
        'GERRORMSG
        '
        Me.GERRORMSG.Caption = "Error Msg"
        Me.GERRORMSG.FieldName = "ERRORMESSAGE"
        Me.GERRORMSG.Name = "GERRORMSG"
        Me.GERRORMSG.Visible = True
        Me.GERRORMSG.VisibleIndex = 7
        Me.GERRORMSG.Width = 500
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'EInvoiceCounterReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "EInvoiceCounterReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "E-Invoice Counter Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXPORT As Button
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents cmdcancel As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GENTRYNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOKENNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCREATED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GERRORMSG As DevExpress.XtraGrid.Columns.GridColumn
End Class
