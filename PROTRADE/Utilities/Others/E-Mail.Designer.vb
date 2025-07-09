<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E_Mail
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
        Me.CHKSSL = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTSMTPPORT = New System.Windows.Forms.TextBox()
        Me.CMDBROWSE5 = New System.Windows.Forms.Button()
        Me.CMDBROWSE4 = New System.Windows.Forms.Button()
        Me.CMDBROWSE3 = New System.Windows.Forms.Button()
        Me.CMDBROWSE2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTATTACHMENT5 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTATTACHMENT4 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTATTACHMENT3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTATTACHMENT2 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEMAILID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDBROWSE1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtsubject = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTATTACHMENT1 = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtmailbody = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbfirstadd = New System.Windows.Forms.ComboBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PBIMG = New System.Windows.Forms.PictureBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PBIMG)
        Me.BlendPanel1.Controls.Add(Me.CHKSSL)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.TXTSMTPPORT)
        Me.BlendPanel1.Controls.Add(Me.CMDBROWSE5)
        Me.BlendPanel1.Controls.Add(Me.CMDBROWSE4)
        Me.BlendPanel1.Controls.Add(Me.CMDBROWSE3)
        Me.BlendPanel1.Controls.Add(Me.CMDBROWSE2)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.TXTATTACHMENT5)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTATTACHMENT4)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTATTACHMENT3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTATTACHMENT2)
        Me.BlendPanel1.Controls.Add(Me.GroupBox4)
        Me.BlendPanel1.Controls.Add(Me.CMDBROWSE1)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txtsubject)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTATTACHMENT1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmbfirstadd)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKSSL
        '
        Me.CHKSSL.AutoSize = True
        Me.CHKSSL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSSL.Checked = True
        Me.CHKSSL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSSL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSSL.Location = New System.Drawing.Point(246, 73)
        Me.CHKSSL.Name = "CHKSSL"
        Me.CHKSSL.Size = New System.Drawing.Size(84, 18)
        Me.CHKSSL.TabIndex = 716
        Me.CHKSSL.Text = "Enable SSL"
        Me.CHKSSL.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(75, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 14)
        Me.Label12.TabIndex = 715
        Me.Label12.Text = "SMTP Port No."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTSMTPPORT
        '
        Me.TXTSMTPPORT.Location = New System.Drawing.Point(158, 70)
        Me.TXTSMTPPORT.Name = "TXTSMTPPORT"
        Me.TXTSMTPPORT.Size = New System.Drawing.Size(80, 22)
        Me.TXTSMTPPORT.TabIndex = 714
        Me.TXTSMTPPORT.Text = "587"
        Me.TXTSMTPPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDBROWSE5
        '
        Me.CMDBROWSE5.Location = New System.Drawing.Point(429, 310)
        Me.CMDBROWSE5.Name = "CMDBROWSE5"
        Me.CMDBROWSE5.Size = New System.Drawing.Size(24, 22)
        Me.CMDBROWSE5.TabIndex = 667
        Me.CMDBROWSE5.Text = "..."
        Me.CMDBROWSE5.UseVisualStyleBackColor = True
        '
        'CMDBROWSE4
        '
        Me.CMDBROWSE4.Location = New System.Drawing.Point(429, 282)
        Me.CMDBROWSE4.Name = "CMDBROWSE4"
        Me.CMDBROWSE4.Size = New System.Drawing.Size(24, 22)
        Me.CMDBROWSE4.TabIndex = 666
        Me.CMDBROWSE4.Text = "..."
        Me.CMDBROWSE4.UseVisualStyleBackColor = True
        '
        'CMDBROWSE3
        '
        Me.CMDBROWSE3.Location = New System.Drawing.Point(429, 254)
        Me.CMDBROWSE3.Name = "CMDBROWSE3"
        Me.CMDBROWSE3.Size = New System.Drawing.Size(24, 22)
        Me.CMDBROWSE3.TabIndex = 665
        Me.CMDBROWSE3.Text = "..."
        Me.CMDBROWSE3.UseVisualStyleBackColor = True
        '
        'CMDBROWSE2
        '
        Me.CMDBROWSE2.Location = New System.Drawing.Point(429, 226)
        Me.CMDBROWSE2.Name = "CMDBROWSE2"
        Me.CMDBROWSE2.Size = New System.Drawing.Size(24, 22)
        Me.CMDBROWSE2.TabIndex = 664
        Me.CMDBROWSE2.Text = "..."
        Me.CMDBROWSE2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 314)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 14)
        Me.Label11.TabIndex = 663
        Me.Label11.Text = "Attachement"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTATTACHMENT5
        '
        Me.TXTATTACHMENT5.BackColor = System.Drawing.Color.White
        Me.TXTATTACHMENT5.ForeColor = System.Drawing.Color.DimGray
        Me.TXTATTACHMENT5.Location = New System.Drawing.Point(92, 310)
        Me.TXTATTACHMENT5.Name = "TXTATTACHMENT5"
        Me.TXTATTACHMENT5.Size = New System.Drawing.Size(331, 22)
        Me.TXTATTACHMENT5.TabIndex = 662
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 286)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 14)
        Me.Label10.TabIndex = 661
        Me.Label10.Text = "Attachement"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTATTACHMENT4
        '
        Me.TXTATTACHMENT4.BackColor = System.Drawing.Color.White
        Me.TXTATTACHMENT4.ForeColor = System.Drawing.Color.DimGray
        Me.TXTATTACHMENT4.Location = New System.Drawing.Point(92, 282)
        Me.TXTATTACHMENT4.Name = "TXTATTACHMENT4"
        Me.TXTATTACHMENT4.Size = New System.Drawing.Size(331, 22)
        Me.TXTATTACHMENT4.TabIndex = 660
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 14)
        Me.Label9.TabIndex = 659
        Me.Label9.Text = "Attachement"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTATTACHMENT3
        '
        Me.TXTATTACHMENT3.BackColor = System.Drawing.Color.White
        Me.TXTATTACHMENT3.ForeColor = System.Drawing.Color.DimGray
        Me.TXTATTACHMENT3.Location = New System.Drawing.Point(92, 254)
        Me.TXTATTACHMENT3.Name = "TXTATTACHMENT3"
        Me.TXTATTACHMENT3.Size = New System.Drawing.Size(331, 22)
        Me.TXTATTACHMENT3.TabIndex = 658
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 657
        Me.Label5.Text = "Attachement"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTATTACHMENT2
        '
        Me.TXTATTACHMENT2.BackColor = System.Drawing.Color.White
        Me.TXTATTACHMENT2.ForeColor = System.Drawing.Color.DimGray
        Me.TXTATTACHMENT2.Location = New System.Drawing.Point(92, 226)
        Me.TXTATTACHMENT2.Name = "TXTATTACHMENT2"
        Me.TXTATTACHMENT2.Size = New System.Drawing.Size(331, 22)
        Me.TXTATTACHMENT2.TabIndex = 656
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CHKSELECTALL)
        Me.GroupBox4.Controls.Add(Me.gridbilldetails)
        Me.GroupBox4.Location = New System.Drawing.Point(478, 18)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(729, 498)
        Me.GroupBox4.TabIndex = 655
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selection"
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(18, 22)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 2
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 43)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(698, 456)
        Me.gridbilldetails.TabIndex = 3
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME, Me.GCITY, Me.GEMAILID, Me.GGROUPNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 35
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 200
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.OptionsColumn.AllowEdit = False
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 2
        Me.GCITY.Width = 90
        '
        'GEMAILID
        '
        Me.GEMAILID.Caption = "Email Id"
        Me.GEMAILID.FieldName = "EMAILID"
        Me.GEMAILID.Name = "GEMAILID"
        Me.GEMAILID.Visible = True
        Me.GEMAILID.VisibleIndex = 3
        Me.GEMAILID.Width = 230
        '
        'GGROUPNAME
        '
        Me.GGROUPNAME.Caption = "Group Name"
        Me.GGROUPNAME.FieldName = "GROUPNAME"
        Me.GGROUPNAME.Name = "GGROUPNAME"
        Me.GGROUPNAME.Visible = True
        Me.GGROUPNAME.VisibleIndex = 4
        Me.GGROUPNAME.Width = 100
        '
        'CMDBROWSE1
        '
        Me.CMDBROWSE1.Location = New System.Drawing.Point(429, 198)
        Me.CMDBROWSE1.Name = "CMDBROWSE1"
        Me.CMDBROWSE1.Size = New System.Drawing.Size(24, 22)
        Me.CMDBROWSE1.TabIndex = 4
        Me.CMDBROWSE1.Text = "..."
        Me.CMDBROWSE1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "Attachement"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsubject
        '
        Me.txtsubject.BackColor = System.Drawing.Color.White
        Me.txtsubject.ForeColor = System.Drawing.Color.DimGray
        Me.txtsubject.Location = New System.Drawing.Point(92, 170)
        Me.txtsubject.Name = "txtsubject"
        Me.txtsubject.Size = New System.Drawing.Size(331, 22)
        Me.txtsubject.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Subject"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTATTACHMENT1
        '
        Me.TXTATTACHMENT1.BackColor = System.Drawing.Color.White
        Me.TXTATTACHMENT1.ForeColor = System.Drawing.Color.DimGray
        Me.TXTATTACHMENT1.Location = New System.Drawing.Point(92, 198)
        Me.TXTATTACHMENT1.Name = "TXTATTACHMENT1"
        Me.TXTATTACHMENT1.Size = New System.Drawing.Size(331, 22)
        Me.TXTATTACHMENT1.TabIndex = 3
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtmailbody)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 355)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(439, 154)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Email - Message (Pls. Type the Message in the Box below)"
        '
        'txtmailbody
        '
        Me.txtmailbody.ForeColor = System.Drawing.Color.Black
        Me.txtmailbody.Location = New System.Drawing.Point(8, 18)
        Me.txtmailbody.Multiline = True
        Me.txtmailbody.Name = "txtmailbody"
        Me.txtmailbody.Size = New System.Drawing.Size(425, 128)
        Me.txtmailbody.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 516)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 1)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmbfirstadd
        '
        Me.cmbfirstadd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbfirstadd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbfirstadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfirstadd.FormattingEnabled = True
        Me.cmbfirstadd.Location = New System.Drawing.Point(158, 42)
        Me.cmbfirstadd.MaxDropDownItems = 14
        Me.cmbfirstadd.Name = "cmbfirstadd"
        Me.cmbfirstadd.Size = New System.Drawing.Size(265, 22)
        Me.cmbfirstadd.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 522)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 7
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(13, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 23)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "E-Mail"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(534, 522)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 6
        Me.cmdok.Text = "&Send Mail"
        Me.cmdok.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Email Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Black
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(454, 1)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(82, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "For Example"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "noreply.PROTRADE@gmail.com"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PBIMG
        '
        Me.PBIMG.BackColor = System.Drawing.Color.Transparent
        Me.PBIMG.ErrorImage = Nothing
        Me.PBIMG.InitialImage = Nothing
        Me.PBIMG.Location = New System.Drawing.Point(410, 3)
        Me.PBIMG.Name = "PBIMG"
        Me.PBIMG.Size = New System.Drawing.Size(62, 33)
        Me.PBIMG.TabIndex = 717
        Me.PBIMG.TabStop = False
        Me.PBIMG.Visible = False
        '
        'E_Mail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "E_Mail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "EMail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBIMG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmailbody As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbfirstadd As System.Windows.Forms.ComboBox
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTATTACHMENT1 As System.Windows.Forms.TextBox
    Friend WithEvents txtsubject As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMDBROWSE1 As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CHKSELECTALL As System.Windows.Forms.CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEMAILID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDBROWSE5 As System.Windows.Forms.Button
    Friend WithEvents CMDBROWSE4 As System.Windows.Forms.Button
    Friend WithEvents CMDBROWSE3 As System.Windows.Forms.Button
    Friend WithEvents CMDBROWSE2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTATTACHMENT5 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTATTACHMENT4 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTATTACHMENT3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTATTACHMENT2 As System.Windows.Forms.TextBox
    Friend WithEvents CHKSSL As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTSMTPPORT As System.Windows.Forms.TextBox
    Friend WithEvents GGROUPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PBIMG As PictureBox
End Class
