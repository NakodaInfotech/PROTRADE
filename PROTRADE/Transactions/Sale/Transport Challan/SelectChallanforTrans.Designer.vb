<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectChallanforTrans
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
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.GTYPENO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPARTYNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALBALES = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTRANSNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDOK = New System.Windows.Forms.Button
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(779, 562)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(21, 12)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 0
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(21, 29)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(737, 487)
        Me.gridbilldetails.TabIndex = 650
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GTYPENO, Me.GDATE, Me.GPARTYNAME, Me.GTOTALBALES, Me.GPCS, Me.GTOTALMTRS, Me.GCHALLANNO, Me.GTRANSNAME, Me.GCITY, Me.GTOTALAMT})
        Me.gridbill.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 39
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GTYPENO
        '
        Me.GTYPENO.Caption = "Type No"
        Me.GTYPENO.FieldName = "TYPECHALLANNO"
        Me.GTYPENO.Name = "GTYPENO"
        Me.GTYPENO.OptionsColumn.AllowEdit = False
        Me.GTYPENO.OptionsColumn.ReadOnly = True
        Me.GTYPENO.Visible = True
        Me.GTYPENO.VisibleIndex = 1
        Me.GTYPENO.Width = 100
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.OptionsColumn.ReadOnly = True
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        '
        'GPARTYNAME
        '
        Me.GPARTYNAME.Caption = "Party Name"
        Me.GPARTYNAME.FieldName = "NAME"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.OptionsColumn.AllowEdit = False
        Me.GPARTYNAME.Visible = True
        Me.GPARTYNAME.VisibleIndex = 3
        Me.GPARTYNAME.Width = 200
        '
        'GTOTALBALES
        '
        Me.GTOTALBALES.Caption = "Total Package"
        Me.GTOTALBALES.DisplayFormat.FormatString = "0"
        Me.GTOTALBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALBALES.FieldName = "TOTALBALES"
        Me.GTOTALBALES.Name = "GTOTALBALES"
        Me.GTOTALBALES.OptionsColumn.AllowEdit = False
        Me.GTOTALBALES.Visible = True
        Me.GTOTALBALES.VisibleIndex = 4
        Me.GTOTALBALES.Width = 100
        '
        'GPCS
        '
        Me.GPCS.Caption = "Total Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0.00"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "TOTALPCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.OptionsColumn.ReadOnly = True
        Me.GPCS.SummaryItem.FieldName = "TOTALMTRS"
        Me.GPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 5
        Me.GPCS.Width = 85
        '
        'GTOTALMTRS
        '
        Me.GTOTALMTRS.Caption = "Total Mtrs"
        Me.GTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMTRS.FieldName = "TOTALMTRS"
        Me.GTOTALMTRS.Name = "GTOTALMTRS"
        Me.GTOTALMTRS.OptionsColumn.AllowEdit = False
        Me.GTOTALMTRS.SummaryItem.FieldName = "ORDERMTRS"
        Me.GTOTALMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALMTRS.Visible = True
        Me.GTOTALMTRS.VisibleIndex = 6
        Me.GTOTALMTRS.Width = 85
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No"
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.OptionsColumn.AllowEdit = False
        '
        'GTRANSNAME
        '
        Me.GTRANSNAME.Caption = "Trans Name"
        Me.GTRANSNAME.FieldName = "TRANSNAME"
        Me.GTRANSNAME.Name = "GTRANSNAME"
        '
        'GCITY
        '
        Me.GCITY.Caption = "To City"
        Me.GCITY.FieldName = "TOCITY"
        Me.GCITY.Name = "GCITY"
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.Name = "APPROXDATE"
        Me.APPROXDATE.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(392, 522)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDOK
        '
        Me.CMDOK.Location = New System.Drawing.Point(306, 522)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 1
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALAMT.FieldName = "TOTALAMT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        '
        'SelectChallanforTrans
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(779, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectChallanforTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Challan Transport Print"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GTYPENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CHKSELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents GTOTALBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
End Class
