<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SampleBarcode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.CHKPRINTSELECTED = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHK = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.TXTBARCODE = New System.Windows.Forms.TextBox()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.LBLTO = New System.Windows.Forms.Label()
        Me.LBLFROM = New System.Windows.Forms.Label()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.CHKPRINT = New System.Windows.Forms.CheckBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CHKPRINTSELECTED)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.TXTREMARKS)
        Me.BlendPanel1.Controls.Add(Me.TXTBARCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel1.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.txtsrno)
        Me.BlendPanel1.Controls.Add(Me.LBLTO)
        Me.BlendPanel1.Controls.Add(Me.LBLFROM)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.CHKPRINT)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMDPRINT.Location = New System.Drawing.Point(928, 3)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(91, 28)
        Me.CMDPRINT.TabIndex = 777
        Me.CMDPRINT.Text = "&Print Barcode"
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.Location = New System.Drawing.Point(56, 12)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(76, 19)
        Me.CHKSELECTALL.TabIndex = 776
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(646, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 774
        Me.Label1.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.BackColor = System.Drawing.Color.White
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTCOPIES.Location = New System.Drawing.Point(693, 8)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(41, 23)
        Me.TXTCOPIES.TabIndex = 775
        Me.TXTCOPIES.Text = " 1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.White
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(346, 35)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(200, 23)
        Me.CMBQUALITY.TabIndex = 1
        '
        'CHKPRINTSELECTED
        '
        Me.CHKPRINTSELECTED.AutoSize = True
        Me.CHKPRINTSELECTED.BackColor = System.Drawing.Color.Transparent
        Me.CHKPRINTSELECTED.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPRINTSELECTED.Location = New System.Drawing.Point(772, 10)
        Me.CHKPRINTSELECTED.Name = "CHKPRINTSELECTED"
        Me.CHKPRINTSELECTED.Size = New System.Drawing.Size(150, 19)
        Me.CHKPRINTSELECTED.TabIndex = 773
        Me.CHKPRINTSELECTED.Text = "Print Selected BarCode"
        Me.CHKPRINTSELECTED.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(11, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHK})
        Me.gridbilldetails.Size = New System.Drawing.Size(1220, 498)
        Me.gridbilldetails.TabIndex = 772
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GSRNO, Me.GNO, Me.GITEMNAME, Me.GQUALITY, Me.GDESIGNNO, Me.GSHADE, Me.GREMARKS, Me.GBARCODE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHK
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'CHK
        '
        Me.CHK.AutoHeight = False
        Me.CHK.Name = "CHK"
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 40
        '
        'GNO
        '
        Me.GNO.Caption = "NO"
        Me.GNO.FieldName = "NO"
        Me.GNO.Name = "GNO"
        Me.GNO.OptionsColumn.AllowEdit = False
        Me.GNO.Width = 60
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 2
        Me.GITEMNAME.Width = 250
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality Name"
        Me.GQUALITY.FieldName = "QUALITYNAME"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 3
        Me.GQUALITY.Width = 200
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 4
        Me.GDESIGNNO.Width = 250
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.OptionsColumn.AllowEdit = False
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 5
        Me.GSHADE.Width = 100
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 6
        Me.GREMARKS.Width = 200
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Barcode"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.OptionsColumn.AllowEdit = False
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 7
        Me.GBARCODE.Width = 100
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.Location = New System.Drawing.Point(897, 35)
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(200, 23)
        Me.TXTREMARKS.TabIndex = 4
        '
        'TXTBARCODE
        '
        Me.TXTBARCODE.BackColor = System.Drawing.Color.White
        Me.TXTBARCODE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TXTBARCODE.Location = New System.Drawing.Point(1069, 6)
        Me.TXTBARCODE.Name = "TXTBARCODE"
        Me.TXTBARCODE.Size = New System.Drawing.Size(133, 23)
        Me.TXTBARCODE.TabIndex = 10
        Me.TXTBARCODE.Visible = False
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.White
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(546, 35)
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(250, 23)
        Me.CMBDESIGNNO.TabIndex = 2
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(577, 563)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(796, 35)
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(101, 23)
        Me.CMBCOLOR.TabIndex = 3
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBMERCHANT.DropDownWidth = 400
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(96, 35)
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(250, 23)
        Me.CMBMERCHANT.TabIndex = 0
        '
        'TXTTO
        '
        Me.TXTTO.BackColor = System.Drawing.Color.White
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTTO.Location = New System.Drawing.Point(556, 7)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(41, 23)
        Me.TXTTO.TabIndex = 9
        Me.TXTTO.Text = " "
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(56, 35)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(40, 23)
        Me.txtsrno.TabIndex = 0
        Me.txtsrno.TabStop = False
        Me.txtsrno.Text = " "
        '
        'LBLTO
        '
        Me.LBLTO.AutoSize = True
        Me.LBLTO.BackColor = System.Drawing.Color.Transparent
        Me.LBLTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTO.ForeColor = System.Drawing.Color.Black
        Me.LBLTO.Location = New System.Drawing.Point(536, 11)
        Me.LBLTO.Name = "LBLTO"
        Me.LBLTO.Size = New System.Drawing.Size(19, 15)
        Me.LBLTO.TabIndex = 769
        Me.LBLTO.Text = "To"
        '
        'LBLFROM
        '
        Me.LBLFROM.AutoSize = True
        Me.LBLFROM.BackColor = System.Drawing.Color.Transparent
        Me.LBLFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFROM.ForeColor = System.Drawing.Color.Black
        Me.LBLFROM.Location = New System.Drawing.Point(380, 11)
        Me.LBLFROM.Name = "LBLFROM"
        Me.LBLFROM.Size = New System.Drawing.Size(113, 15)
        Me.LBLFROM.TabIndex = 7
        Me.LBLFROM.Text = "Print Barcode From"
        '
        'TXTFROM
        '
        Me.TXTFROM.BackColor = System.Drawing.Color.White
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFROM.Location = New System.Drawing.Point(492, 7)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(41, 23)
        Me.TXTFROM.TabIndex = 8
        Me.TXTFROM.Text = " "
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHKPRINT
        '
        Me.CHKPRINT.AutoSize = True
        Me.CHKPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CHKPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPRINT.Location = New System.Drawing.Point(107, 9)
        Me.CHKPRINT.Name = "CHKPRINT"
        Me.CHKPRINT.Size = New System.Drawing.Size(134, 19)
        Me.CHKPRINT.TabIndex = 6
        Me.CHKPRINT.Text = "Print Each Bar Code"
        Me.CHKPRINT.UseVisualStyleBackColor = False
        Me.CHKPRINT.Visible = False
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(266, 7)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTNO.TabIndex = 7
        Me.TXTNO.Text = " "
        Me.TXTNO.Visible = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'SampleBarcode
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SampleBarcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sample Barcode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBDESIGNNO As ComboBox
    Friend WithEvents CMBCOLOR As ComboBox
    Friend WithEvents CMBMERCHANT As ComboBox
    Friend WithEvents txtsrno As TextBox
    Friend WithEvents TXTREMARKS As TextBox
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents LBLTO As Label
    Friend WithEvents LBLFROM As Label
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents CHKPRINT As CheckBox
    Friend WithEvents TXTNO As TextBox
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents cmdexit As Button
    Friend WithEvents TXTBARCODE As TextBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKPRINTSELECTED As CheckBox
    Friend WithEvents CHK As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CMBQUALITY As ComboBox
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents CHKSELECTALL As CheckBox
    Friend WithEvents CMDPRINT As Button
End Class
