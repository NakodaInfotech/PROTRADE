<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogMaster
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
        Me.CMDADD = New System.Windows.Forms.Button()
        Me.TXTPHOTOIMGPATH = New System.Windows.Forms.TextBox()
        Me.CMDPHOTOREMOVE = New System.Windows.Forms.Button()
        Me.CMDPHOTOUPLOAD = New System.Windows.Forms.Button()
        Me.CMDPHOTOVIEW = New System.Windows.Forms.Button()
        Me.PBPHOTO = New System.Windows.Forms.PictureBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHK = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIMGPATH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPHOTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.TXTNO = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Controls.Add(Me.TXTPHOTOIMGPATH)
        Me.BlendPanel1.Controls.Add(Me.CMDPHOTOREMOVE)
        Me.BlendPanel1.Controls.Add(Me.CMDPHOTOUPLOAD)
        Me.BlendPanel1.Controls.Add(Me.CMDPHOTOVIEW)
        Me.BlendPanel1.Controls.Add(Me.PBPHOTO)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel1.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.txtsrno)
        Me.BlendPanel1.Controls.Add(Me.TXTNO)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 600)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDADD
        '
        Me.CMDADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADD.Location = New System.Drawing.Point(703, 30)
        Me.CMDADD.Name = "CMDADD"
        Me.CMDADD.Size = New System.Drawing.Size(80, 28)
        Me.CMDADD.TabIndex = 4
        Me.CMDADD.Text = "&Add"
        Me.CMDADD.UseVisualStyleBackColor = True
        '
        'TXTPHOTOIMGPATH
        '
        Me.TXTPHOTOIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTPHOTOIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPHOTOIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTPHOTOIMGPATH.Location = New System.Drawing.Point(675, 12)
        Me.TXTPHOTOIMGPATH.Name = "TXTPHOTOIMGPATH"
        Me.TXTPHOTOIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTPHOTOIMGPATH.TabIndex = 778
        Me.TXTPHOTOIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPHOTOIMGPATH.Visible = False
        '
        'CMDPHOTOREMOVE
        '
        Me.CMDPHOTOREMOVE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPHOTOREMOVE.Location = New System.Drawing.Point(1013, 142)
        Me.CMDPHOTOREMOVE.Name = "CMDPHOTOREMOVE"
        Me.CMDPHOTOREMOVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDPHOTOREMOVE.TabIndex = 775
        Me.CMDPHOTOREMOVE.Text = "&Remove"
        Me.CMDPHOTOREMOVE.UseVisualStyleBackColor = True
        '
        'CMDPHOTOUPLOAD
        '
        Me.CMDPHOTOUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPHOTOUPLOAD.Location = New System.Drawing.Point(1013, 108)
        Me.CMDPHOTOUPLOAD.Name = "CMDPHOTOUPLOAD"
        Me.CMDPHOTOUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDPHOTOUPLOAD.TabIndex = 3
        Me.CMDPHOTOUPLOAD.Text = "&Upload"
        Me.CMDPHOTOUPLOAD.UseVisualStyleBackColor = True
        '
        'CMDPHOTOVIEW
        '
        Me.CMDPHOTOVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPHOTOVIEW.Location = New System.Drawing.Point(1013, 176)
        Me.CMDPHOTOVIEW.Name = "CMDPHOTOVIEW"
        Me.CMDPHOTOVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDPHOTOVIEW.TabIndex = 776
        Me.CMDPHOTOVIEW.Text = "&View"
        Me.CMDPHOTOVIEW.UseVisualStyleBackColor = True
        '
        'PBPHOTO
        '
        Me.PBPHOTO.BackColor = System.Drawing.Color.White
        Me.PBPHOTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBPHOTO.ErrorImage = Nothing
        Me.PBPHOTO.InitialImage = Nothing
        Me.PBPHOTO.Location = New System.Drawing.Point(862, 59)
        Me.PBPHOTO.Name = "PBPHOTO"
        Me.PBPHOTO.Size = New System.Drawing.Size(142, 145)
        Me.PBPHOTO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPHOTO.TabIndex = 777
        Me.PBPHOTO.TabStop = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(10, 59)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHK})
        Me.gridbilldetails.Size = New System.Drawing.Size(846, 498)
        Me.gridbilldetails.TabIndex = 773
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GSRNO, Me.GNO, Me.GITEMNAME, Me.GDESIGNNO, Me.GSHADE, Me.GIMGPATH, Me.GPHOTO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowColumnResizing = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsCustomization.AllowRowSizing = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowGroupPanel = False
        Me.gridbill.RowHeight = 100
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
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 3
        Me.GDESIGNNO.Width = 250
        '
        'GSHADE
        '
        Me.GSHADE.Caption = "Shade"
        Me.GSHADE.FieldName = "SHADE"
        Me.GSHADE.Name = "GSHADE"
        Me.GSHADE.OptionsColumn.AllowEdit = False
        Me.GSHADE.Visible = True
        Me.GSHADE.VisibleIndex = 4
        Me.GSHADE.Width = 100
        '
        'GIMGPATH
        '
        Me.GIMGPATH.Caption = "Img Path"
        Me.GIMGPATH.FieldName = "IMGPATH"
        Me.GIMGPATH.Name = "GIMGPATH"
        '
        'GPHOTO
        '
        Me.GPHOTO.Caption = "Photo"
        Me.GPHOTO.FieldName = "PHOTO"
        Me.GPHOTO.Name = "GPHOTO"
        Me.GPHOTO.Visible = True
        Me.GPHOTO.VisibleIndex = 5
        Me.GPHOTO.Width = 120
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.BackColor = System.Drawing.Color.White
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(346, 35)
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(250, 23)
        Me.CMBDESIGNNO.TabIndex = 1
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(376, 563)
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
        Me.CMBCOLOR.Location = New System.Drawing.Point(596, 35)
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(101, 23)
        Me.CMBCOLOR.TabIndex = 2
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'CatalogMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 600)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CatalogMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = ""
        Me.Text = "Catalog Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBDESIGNNO As ComboBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents CMBCOLOR As ComboBox
    Friend WithEvents CMBMERCHANT As ComboBox
    Friend WithEvents txtsrno As TextBox
    Friend WithEvents TXTNO As TextBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHK As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIMGPATH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPHOTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDPHOTOREMOVE As Button
    Friend WithEvents CMDPHOTOUPLOAD As Button
    Friend WithEvents CMDPHOTOVIEW As Button
    Friend WithEvents PBPHOTO As PictureBox
    Friend WithEvents TXTPHOTOIMGPATH As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents CMDADD As Button
End Class
