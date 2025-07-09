<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemExcelDetails
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
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPLAYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWARP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSELDVEDGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUPPERLIMIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOWERLIMIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREORDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGREYWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 6
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.Black
        Me.cmdadd.Location = New System.Drawing.Point(425, 547)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(80, 28)
        Me.cmdadd.TabIndex = 504
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.Black
        Me.cmdedit.Location = New System.Drawing.Point(597, 547)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(80, 28)
        Me.cmdedit.TabIndex = 503
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSAVE.Location = New System.Drawing.Point(511, 547)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 502
        Me.CMDSAVE.Text = "&Refresh"
        Me.CMDSAVE.UseVisualStyleBackColor = True
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
        Me.CMDPRINT.Location = New System.Drawing.Point(395, 551)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 501
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 14)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1208, 526)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMID, Me.GNAME, Me.GDISPLAYNAME, Me.GCODE, Me.GCATEGORY, Me.GHSNCODE, Me.GWEFT, Me.GWARP, Me.GSELDVEDGE, Me.GUPPERLIMIT, Me.GLOWERLIMIT, Me.GREORDER, Me.GWIDTH, Me.GGREYWIDTH, Me.GTRANSRATE, Me.GCHECKRATE, Me.GPACKRATE, Me.GDESIGNRATE, Me.GREMARKS, Me.GUNIT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GITEMID
        '
        Me.GITEMID.Caption = "ID"
        Me.GITEMID.FieldName = "ID"
        Me.GITEMID.Name = "GITEMID"
        '
        'GNAME
        '
        Me.GNAME.Caption = "Item Name"
        Me.GNAME.FieldName = "ITEMNAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 150
        '
        'GDISPLAYNAME
        '
        Me.GDISPLAYNAME.Caption = "Display Name"
        Me.GDISPLAYNAME.FieldName = "DISPLAYNAME"
        Me.GDISPLAYNAME.Name = "GDISPLAYNAME"
        Me.GDISPLAYNAME.Visible = True
        Me.GDISPLAYNAME.VisibleIndex = 1
        '
        'GCODE
        '
        Me.GCODE.Caption = "Code"
        Me.GCODE.FieldName = "ITEMCODE"
        Me.GCODE.Name = "GCODE"
        Me.GCODE.Visible = True
        Me.GCODE.VisibleIndex = 2
        Me.GCODE.Width = 100
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 3
        Me.GCATEGORY.Width = 100
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 5
        '
        'GWEFT
        '
        Me.GWEFT.Caption = "Weft"
        Me.GWEFT.FieldName = "WEFT"
        Me.GWEFT.Name = "GWEFT"
        Me.GWEFT.Visible = True
        Me.GWEFT.VisibleIndex = 4
        '
        'GWARP
        '
        Me.GWARP.Caption = "Warp"
        Me.GWARP.FieldName = "WARP"
        Me.GWARP.Name = "GWARP"
        Me.GWARP.Visible = True
        Me.GWARP.VisibleIndex = 6
        '
        'GSELDVEDGE
        '
        Me.GSELDVEDGE.Caption = "Selvedge"
        Me.GSELDVEDGE.FieldName = "SELVEDGE"
        Me.GSELDVEDGE.Name = "GSELDVEDGE"
        Me.GSELDVEDGE.Visible = True
        Me.GSELDVEDGE.VisibleIndex = 7
        '
        'GUPPERLIMIT
        '
        Me.GUPPERLIMIT.Caption = "Upper Limit"
        Me.GUPPERLIMIT.FieldName = "UPPER"
        Me.GUPPERLIMIT.Name = "GUPPERLIMIT"
        Me.GUPPERLIMIT.Visible = True
        Me.GUPPERLIMIT.VisibleIndex = 8
        '
        'GLOWERLIMIT
        '
        Me.GLOWERLIMIT.Caption = "Lower Limit"
        Me.GLOWERLIMIT.FieldName = "LOWER"
        Me.GLOWERLIMIT.Name = "GLOWERLIMIT"
        Me.GLOWERLIMIT.Visible = True
        Me.GLOWERLIMIT.VisibleIndex = 9
        '
        'GREORDER
        '
        Me.GREORDER.Caption = "Re-Order"
        Me.GREORDER.FieldName = "REORDER"
        Me.GREORDER.Name = "GREORDER"
        Me.GREORDER.Visible = True
        Me.GREORDER.VisibleIndex = 10
        '
        'GWIDTH
        '
        Me.GWIDTH.Caption = "Width"
        Me.GWIDTH.FieldName = "WIDTH"
        Me.GWIDTH.Name = "GWIDTH"
        Me.GWIDTH.Visible = True
        Me.GWIDTH.VisibleIndex = 11
        '
        'GGREYWIDTH
        '
        Me.GGREYWIDTH.Caption = "Grey Width"
        Me.GGREYWIDTH.FieldName = "GREYWIDTH"
        Me.GGREYWIDTH.Name = "GGREYWIDTH"
        Me.GGREYWIDTH.Visible = True
        Me.GGREYWIDTH.VisibleIndex = 12
        '
        'GTRANSRATE
        '
        Me.GTRANSRATE.Caption = "Trans Rate"
        Me.GTRANSRATE.FieldName = "TRANSPORTRATE"
        Me.GTRANSRATE.Name = "GTRANSRATE"
        Me.GTRANSRATE.Visible = True
        Me.GTRANSRATE.VisibleIndex = 13
        '
        'GCHECKRATE
        '
        Me.GCHECKRATE.Caption = "Check Rate"
        Me.GCHECKRATE.FieldName = "CHECKRATE"
        Me.GCHECKRATE.Name = "GCHECKRATE"
        Me.GCHECKRATE.Visible = True
        Me.GCHECKRATE.VisibleIndex = 14
        '
        'GPACKRATE
        '
        Me.GPACKRATE.Caption = "Pack Rate"
        Me.GPACKRATE.FieldName = "PACKRATE"
        Me.GPACKRATE.Name = "GPACKRATE"
        Me.GPACKRATE.Visible = True
        Me.GPACKRATE.VisibleIndex = 15
        '
        'GDESIGNRATE
        '
        Me.GDESIGNRATE.Caption = "Design Rate"
        Me.GDESIGNRATE.FieldName = "DESIGNRATE"
        Me.GDESIGNRATE.Name = "GDESIGNRATE"
        Me.GDESIGNRATE.Visible = True
        Me.GDESIGNRATE.VisibleIndex = 16
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks "
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 17
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(683, 547)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "&Exit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 18
        '
        'ItemExcelDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ItemExcelDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ItemExcelDetails"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdadd As Button
    Friend WithEvents cmdedit As Button
    Friend WithEvents CMDSAVE As Button
    Friend WithEvents CMDPRINT As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPLAYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As Button
    Friend WithEvents GWEFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWARP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSELDVEDGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUPPERLIMIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOWERLIMIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREORDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGREYWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
End Class
