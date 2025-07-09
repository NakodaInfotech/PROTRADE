<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorTagging
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
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.CMBPRINT = New System.Windows.Forms.Button()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TXTPARTYCOLOR = New System.Windows.Forms.TextBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
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
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBPRINT)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.TXTPARTYCOLOR)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.txtsrno)
        Me.BlendPanel1.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(696, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.DropDownWidth = 400
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(32, 18)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(200, 23)
        Me.CMBNAME.TabIndex = 0
        '
        'CMBPRINT
        '
        Me.CMBPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMBPRINT.FlatAppearance.BorderSize = 0
        Me.CMBPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMBPRINT.Location = New System.Drawing.Point(308, 541)
        Me.CMBPRINT.Name = "CMBPRINT"
        Me.CMBPRINT.Size = New System.Drawing.Size(80, 28)
        Me.CMBPRINT.TabIndex = 5
        Me.CMBPRINT.Text = "&Print"
        Me.CMBPRINT.UseVisualStyleBackColor = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(222, 541)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(16, 41)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(654, 494)
        Me.gridbilldetails.TabIndex = 3
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNO, Me.GNAME, Me.GPCOLOR, Me.GCOLOR})
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
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 200
        '
        'GPCOLOR
        '
        Me.GPCOLOR.Caption = "Party Color"
        Me.GPCOLOR.FieldName = "PARTYCOLOR"
        Me.GPCOLOR.Name = "GPCOLOR"
        Me.GPCOLOR.Visible = True
        Me.GPCOLOR.VisibleIndex = 1
        Me.GPCOLOR.Width = 200
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 2
        Me.GCOLOR.Width = 200
        '
        'TXTPARTYCOLOR
        '
        Me.TXTPARTYCOLOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPARTYCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPARTYCOLOR.Location = New System.Drawing.Point(232, 18)
        Me.TXTPARTYCOLOR.Name = "TXTPARTYCOLOR"
        Me.TXTPARTYCOLOR.Size = New System.Drawing.Size(200, 23)
        Me.TXTPARTYCOLOR.TabIndex = 1
        '
        'TXTNO
        '
        Me.TXTNO.BackColor = System.Drawing.Color.White
        Me.TXTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTNO.Location = New System.Drawing.Point(637, 12)
        Me.TXTNO.Name = "TXTNO"
        Me.TXTNO.ReadOnly = True
        Me.TXTNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTNO.TabIndex = 715
        Me.TXTNO.Text = " "
        Me.TXTNO.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(394, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(637, 3)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(59, 23)
        Me.txtsrno.TabIndex = 0
        Me.txtsrno.TabStop = False
        Me.txtsrno.Text = " "
        Me.txtsrno.Visible = False
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCOLOR.DropDownWidth = 400
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(432, 18)
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(200, 23)
        Me.CMBCOLOR.TabIndex = 2
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.DropDownWidth = 400
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(152, 0)
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMBCODE.TabIndex = 717
        Me.CMBCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtadd.Location = New System.Drawing.Point(198, 0)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.ReadOnly = True
        Me.txtadd.Size = New System.Drawing.Size(30, 22)
        Me.txtadd.TabIndex = 716
        Me.txtadd.Text = " "
        Me.txtadd.Visible = False
        '
        'ColorTagging
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(696, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ColorTagging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Color Tagging"
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
    Friend WithEvents TXTPARTYCOLOR As TextBox
    Friend WithEvents TXTNO As TextBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents txtsrno As TextBox
    Friend WithEvents CMBCOLOR As ComboBox
    Friend WithEvents EP As ErrorProvider
    Private WithEvents GNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GPCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents txtadd As TextBox
End Class
