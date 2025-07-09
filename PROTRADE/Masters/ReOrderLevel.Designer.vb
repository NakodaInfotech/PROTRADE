<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReOrderLevel
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBPRINT = New System.Windows.Forms.Button()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTSRNO = New System.Windows.Forms.TextBox()
        Me.cmbquality = New System.Windows.Forms.ComboBox()
        Me.cmbcolor = New System.Windows.Forms.ComboBox()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.AutoSize = True
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.TXTQTY)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TXTSRNO)
        Me.BlendPanel1.Controls.Add(Me.cmbquality)
        Me.BlendPanel1.Controls.Add(Me.cmbcolor)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMBPRINT
        '
        Me.CMBPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMBPRINT.FlatAppearance.BorderSize = 0
        Me.CMBPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMBPRINT.Location = New System.Drawing.Point(415, 554)
        Me.CMBPRINT.Name = "CMBPRINT"
        Me.CMBPRINT.Size = New System.Drawing.Size(80, 28)
        Me.CMBPRINT.TabIndex = 718
        Me.CMBPRINT.Text = "&Print"
        Me.CMBPRINT.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(329, 554)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 717
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(16, 35)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(830, 513)
        Me.gridbilldetails.TabIndex = 716
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNO, Me.GITEMNAME, Me.GQUALITY, Me.GDESIGN, Me.GSHADE, Me.GQTY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GNO
        '
        Me.GNO.Caption = "NO"
        Me.GNO.FieldName = "NO"
        Me.GNO.Name = "GNO"
        Me.GNO.Width = 60
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 200
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 1
        Me.GQUALITY.Width = 200
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTALPCS", "")})
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 2
        Me.GDESIGN.Width = 150
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 3
        Me.GSHADE.Width = 150
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.DisplayFormat.FormatString = "0.00"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 4
        Me.GQTY.Width = 80
        '
        'TXTQTY
        '
        Me.TXTQTY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTQTY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQTY.Location = New System.Drawing.Point(733, 12)
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.Size = New System.Drawing.Size(80, 23)
        Me.TXTQTY.TabIndex = 5
        Me.TXTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(991, 12)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTNO.TabIndex = 715
        Me.TXTNO.Text = " "
        Me.TXTNO.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.DropDownWidth = 400
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(1030, 12)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMBCODE.TabIndex = 20
        Me.CMBCODE.Visible = False
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.White
        Me.CMBDESIGNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(433, 12)
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(150, 23)
        Me.CMBDESIGNNO.TabIndex = 3
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(501, 554)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTSRNO
        '
        Me.TXTSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSRNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSRNO.Location = New System.Drawing.Point(877, 12)
        Me.TXTSRNO.Name = "TXTSRNO"
        Me.TXTSRNO.ReadOnly = True
        Me.TXTSRNO.Size = New System.Drawing.Size(59, 23)
        Me.TXTSRNO.TabIndex = 0
        Me.TXTSRNO.TabStop = False
        Me.TXTSRNO.Text = " "
        Me.TXTSRNO.Visible = False
        '
        'cmbquality
        '
        Me.cmbquality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbquality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbquality.BackColor = System.Drawing.Color.White
        Me.cmbquality.DropDownWidth = 400
        Me.cmbquality.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbquality.FormattingEnabled = True
        Me.cmbquality.Location = New System.Drawing.Point(232, 12)
        Me.cmbquality.Name = "cmbquality"
        Me.cmbquality.Size = New System.Drawing.Size(201, 23)
        Me.cmbquality.TabIndex = 2
        '
        'cmbcolor
        '
        Me.cmbcolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcolor.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcolor.FormattingEnabled = True
        Me.cmbcolor.Location = New System.Drawing.Point(583, 12)
        Me.cmbcolor.Name = "cmbcolor"
        Me.cmbcolor.Size = New System.Drawing.Size(150, 23)
        Me.cmbcolor.TabIndex = 4
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.DropDownWidth = 400
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(32, 12)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(200, 23)
        Me.CMBITEMNAME.TabIndex = 1
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ReOrderLevel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ReOrderLevel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Re Order Level"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBPRINT As Button
    Friend WithEvents cmddelete As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTQTY As TextBox
    Friend WithEvents TXTNO As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents CMBDESIGNNO As ComboBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents TXTSRNO As TextBox
    Friend WithEvents cmbquality As ComboBox
    Friend WithEvents cmbcolor As ComboBox
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents EP As ErrorProvider
End Class
