<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectItemSO
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.CMDSHOWSTOCK = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPENDINGQTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCUT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GORDERPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GORDERMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMDOK = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWSTOCK)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(742, 480)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(21, 440)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(261, 28)
        Me.Label7.TabIndex = 563
        Me.Label7.Text = "Press Space to Copy Data from Previous Line" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Press Delete to Remove Data from Cur" & _
            "rent Line"
        '
        'CMDSHOWSTOCK
        '
        Me.CMDSHOWSTOCK.Location = New System.Drawing.Point(475, 440)
        Me.CMDSHOWSTOCK.Name = "CMDSHOWSTOCK"
        Me.CMDSHOWSTOCK.Size = New System.Drawing.Size(80, 28)
        Me.CMDSHOWSTOCK.TabIndex = 3
        Me.CMDSHOWSTOCK.Text = "&Show Stock"
        Me.CMDSHOWSTOCK.UseVisualStyleBackColor = True
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(708, 422)
        Me.gridbilldetails.TabIndex = 0
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCOLOR, Me.GPCS, Me.GMTRS, Me.GPENDINGQTY, Me.GCUT, Me.GORDERPCS, Me.GORDERMTRS})
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
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.OptionsColumn.AllowEdit = False
        Me.GCOLOR.OptionsColumn.ReadOnly = True
        Me.GCOLOR.OptionsColumn.TabStop = False
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 0
        Me.GCOLOR.Width = 120
        '
        'GPCS
        '
        Me.GPCS.Caption = "Total Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "TOTALPCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.OptionsColumn.ReadOnly = True
        Me.GPCS.OptionsColumn.TabStop = False
        Me.GPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 1
        Me.GPCS.Width = 85
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Total Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "TOTALMTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.OptionsColumn.ReadOnly = True
        Me.GMTRS.OptionsColumn.TabStop = False
        Me.GMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 2
        Me.GMTRS.Width = 110
        '
        'GPENDINGQTY
        '
        Me.GPENDINGQTY.Caption = "Pending Qty"
        Me.GPENDINGQTY.FieldName = "PENDINGQTY"
        Me.GPENDINGQTY.Name = "GPENDINGQTY"
        Me.GPENDINGQTY.OptionsColumn.AllowEdit = False
        Me.GPENDINGQTY.OptionsColumn.TabStop = False
        Me.GPENDINGQTY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPENDINGQTY.Visible = True
        Me.GPENDINGQTY.VisibleIndex = 3
        Me.GPENDINGQTY.Width = 95
        '
        'GCUT
        '
        Me.GCUT.Caption = "Cut"
        Me.GCUT.DisplayFormat.FormatString = "0.00"
        Me.GCUT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCUT.FieldName = "CUT"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.Visible = True
        Me.GCUT.VisibleIndex = 4
        '
        'GORDERPCS
        '
        Me.GORDERPCS.Caption = "Order Pcs"
        Me.GORDERPCS.DisplayFormat.FormatString = "0"
        Me.GORDERPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GORDERPCS.FieldName = "ORDERPCS"
        Me.GORDERPCS.Name = "GORDERPCS"
        Me.GORDERPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GORDERPCS.Visible = True
        Me.GORDERPCS.VisibleIndex = 5
        '
        'GORDERMTRS
        '
        Me.GORDERMTRS.Caption = "Order Mtrs"
        Me.GORDERMTRS.DisplayFormat.FormatString = "0.00"
        Me.GORDERMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GORDERMTRS.FieldName = "ORDERMTRS"
        Me.GORDERMTRS.Name = "GORDERMTRS"
        Me.GORDERMTRS.OptionsColumn.TabStop = False
        Me.GORDERMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GORDERMTRS.Visible = True
        Me.GORDERMTRS.VisibleIndex = 6
        Me.GORDERMTRS.Width = 95
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(389, 440)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDOK
        '
        Me.CMDOK.Location = New System.Drawing.Point(303, 440)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 1
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'SelectItemSO
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(742, 480)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectItemSO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Item for Sale Order"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPENDINGQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDSHOWSTOCK As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
