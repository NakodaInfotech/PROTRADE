<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebitNote
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
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DebitNote))
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ACTUALINVDATE = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.RBREMOVEADJ = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LBLBILLTOTAL = New System.Windows.Forms.Label()
        Me.TXTBILLREMARKS = New System.Windows.Forms.TextBox()
        Me.TXTADJSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDPAYMENT = New System.Windows.Forms.DataGridView()
        Me.GADJSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpaytype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbillno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gdesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GADJAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GAMTPAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GEXTRAAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRETURN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBALANCE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TXTADJAMT = New System.Windows.Forms.TextBox()
        Me.TXTCHQBAL = New System.Windows.Forms.TextBox()
        Me.CMBPAYTYPE = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CMBBILLNO = New System.Windows.Forms.ComboBox()
        Me.TXTADJTOTAL = New System.Windows.Forms.TextBox()
        Me.TXTNARR = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TXTCHGSSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDCHGS = New System.Windows.Forms.DataGridView()
        Me.ESRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ECHARGES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETAXID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBCHARGES = New System.Windows.Forms.ComboBox()
        Me.TXTCHGSAMT = New System.Windows.Forms.TextBox()
        Me.TXTCHGSPER = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ACKDATE = New System.Windows.Forms.DateTimePicker()
        Me.LBLACKDATE = New System.Windows.Forms.Label()
        Me.TXTACKNO = New System.Windows.Forms.TextBox()
        Me.LBLACKNO = New System.Windows.Forms.Label()
        Me.CMDGETQRCODE = New System.Windows.Forms.Button()
        Me.PBQRCODE = New System.Windows.Forms.PictureBox()
        Me.CMDUPLOADIRN = New System.Windows.Forms.Button()
        Me.LBLIRN = New System.Windows.Forms.Label()
        Me.TXTIRNNO = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TXTINVTOTAL = New System.Windows.Forms.TextBox()
        Me.GRIDBILL = New System.Windows.Forms.DataGridView()
        Me.TXTTOTALWITHGST = New System.Windows.Forms.TextBox()
        Me.CHKTCS = New System.Windows.Forms.CheckBox()
        Me.TXTTCSPER = New System.Windows.Forms.TextBox()
        Me.TXTTCSAMT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTTOTALPCS = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTTOTALMTRS = New System.Windows.Forms.TextBox()
        Me.TXTDISCPER = New System.Windows.Forms.TextBox()
        Me.TXTACTUALINVAMT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTPARTYBILLDATE = New System.Windows.Forms.MaskedTextBox()
        Me.TXTSALEREFNO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CHKGSTR1 = New System.Windows.Forms.CheckBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.CMBAGENT = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DNDATE = New System.Windows.Forms.MaskedTextBox()
        Me.CHKMANUALROUND = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTPARTYBILLNO = New System.Windows.Forms.TextBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.TXTRETURN = New System.Windows.Forms.TextBox()
        Me.TXTEXTRAAMT = New System.Windows.Forms.TextBox()
        Me.TXTAMTREC = New System.Windows.Forms.TextBox()
        Me.PBRECD = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TXTBAL = New System.Windows.Forms.TextBox()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.CHKMANUAL = New System.Windows.Forms.CheckBox()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.txtinwords = New System.Windows.Forms.TextBox()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTSTATECODE = New System.Windows.Forms.TextBox()
        Me.TXTIGSTPER = New System.Windows.Forms.TextBox()
        Me.TXTSGSTPER = New System.Windows.Forms.TextBox()
        Me.TXTCGSTPER = New System.Windows.Forms.TextBox()
        Me.TXTIGSTAMT = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTSGSTAMT = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TXTCGSTAMT = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LBLSACCODE = New System.Windows.Forms.Label()
        Me.TXTSACCODE = New System.Windows.Forms.TextBox()
        Me.CMBSACDESC = New System.Windows.Forms.ComboBox()
        Me.LBLSACDESC = New System.Windows.Forms.Label()
        Me.CMBCREDITLEDGER = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTTAXID = New System.Windows.Forms.TextBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.TXTTOTALTAXAMT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTTOTALOTHERCHGSAMT = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXTCHARGES = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.TXTOTHERCHGSADD = New System.Windows.Forms.TextBox()
        Me.CMBOTHERCHGSCODE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TXTTOTALPURAMT = New System.Windows.Forms.TextBox()
        Me.txtgrandtotal = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtroundoff = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXTSUBTOTAL = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXTDNNO = New System.Windows.Forms.TextBox()
        Me.lblsrno = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLEINV = New System.Windows.Forms.ToolStripButton()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.txtimgpath = New System.Windows.Forms.TextBox()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.RBREMOVEADJ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GRIDPAYMENT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.GRIDCHGS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PBQRCODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBRECD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(284, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(67, 22)
        Me.tstxtbillno.TabIndex = 0
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.ACTUALINVDATE)
        Me.BlendPanel1.Controls.Add(Me.Label19)
        Me.BlendPanel1.Controls.Add(Me.RBREMOVEADJ)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label32)
        Me.BlendPanel1.Controls.Add(Me.TXTINVTOTAL)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILL)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALWITHGST)
        Me.BlendPanel1.Controls.Add(Me.CHKTCS)
        Me.BlendPanel1.Controls.Add(Me.TXTTCSPER)
        Me.BlendPanel1.Controls.Add(Me.TXTTCSAMT)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPCS)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALMTRS)
        Me.BlendPanel1.Controls.Add(Me.TXTDISCPER)
        Me.BlendPanel1.Controls.Add(Me.TXTACTUALINVAMT)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.TXTPARTYBILLDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTSALEREFNO)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.CHKGSTR1)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBAGENT)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.DNDATE)
        Me.BlendPanel1.Controls.Add(Me.CHKMANUALROUND)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTPARTYBILLNO)
        Me.BlendPanel1.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel1.Controls.Add(Me.TXTRETURN)
        Me.BlendPanel1.Controls.Add(Me.TXTEXTRAAMT)
        Me.BlendPanel1.Controls.Add(Me.TXTAMTREC)
        Me.BlendPanel1.Controls.Add(Me.PBRECD)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label39)
        Me.BlendPanel1.Controls.Add(Me.TXTBAL)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CHKMANUAL)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.txtinwords)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.TXTSTATECODE)
        Me.BlendPanel1.Controls.Add(Me.TXTIGSTPER)
        Me.BlendPanel1.Controls.Add(Me.TXTSGSTPER)
        Me.BlendPanel1.Controls.Add(Me.TXTCGSTPER)
        Me.BlendPanel1.Controls.Add(Me.TXTIGSTAMT)
        Me.BlendPanel1.Controls.Add(Me.Label30)
        Me.BlendPanel1.Controls.Add(Me.TXTSGSTAMT)
        Me.BlendPanel1.Controls.Add(Me.Label29)
        Me.BlendPanel1.Controls.Add(Me.TXTCGSTAMT)
        Me.BlendPanel1.Controls.Add(Me.Label28)
        Me.BlendPanel1.Controls.Add(Me.LBLSACCODE)
        Me.BlendPanel1.Controls.Add(Me.TXTSACCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBSACDESC)
        Me.BlendPanel1.Controls.Add(Me.LBLSACDESC)
        Me.BlendPanel1.Controls.Add(Me.CMBCREDITLEDGER)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTTAXID)
        Me.BlendPanel1.Controls.Add(Me.txtremarks)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALTAXAMT)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALOTHERCHGSAMT)
        Me.BlendPanel1.Controls.Add(Me.Label24)
        Me.BlendPanel1.Controls.Add(Me.TXTCHARGES)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTOTHERCHGSADD)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERCHGSCODE)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLNO)
        Me.BlendPanel1.Controls.Add(Me.Label33)
        Me.BlendPanel1.Controls.Add(Me.Label51)
        Me.BlendPanel1.Controls.Add(Me.TXTTOTALPURAMT)
        Me.BlendPanel1.Controls.Add(Me.txtgrandtotal)
        Me.BlendPanel1.Controls.Add(Me.Label36)
        Me.BlendPanel1.Controls.Add(Me.Label38)
        Me.BlendPanel1.Controls.Add(Me.txtroundoff)
        Me.BlendPanel1.Controls.Add(Me.Label25)
        Me.BlendPanel1.Controls.Add(Me.TXTSUBTOTAL)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.TXTDNNO)
        Me.BlendPanel1.Controls.Add(Me.lblsrno)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 25)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 556)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(197, 230)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(262, 19)
        Me.Label18.TabIndex = 1000
        Me.Label18.Text = "This Date will be Used for Calc HSN %"
        '
        'ACTUALINVDATE
        '
        Me.ACTUALINVDATE.AsciiOnly = True
        Me.ACTUALINVDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.ACTUALINVDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ACTUALINVDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.ACTUALINVDATE.Location = New System.Drawing.Point(106, 228)
        Me.ACTUALINVDATE.Mask = "00/00/0000"
        Me.ACTUALINVDATE.Name = "ACTUALINVDATE"
        Me.ACTUALINVDATE.Size = New System.Drawing.Size(90, 23)
        Me.ACTUALINVDATE.TabIndex = 998
        Me.ACTUALINVDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ACTUALINVDATE.ValidatingType = GetType(Date)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(15, 233)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 14)
        Me.Label19.TabIndex = 999
        Me.Label19.Text = "Acutal Inv Date"
        '
        'RBREMOVEADJ
        '
        Me.RBREMOVEADJ.BackColor = System.Drawing.Color.Transparent
        Me.RBREMOVEADJ.Image = Global.PROTRADE.My.Resources.Resources.Forbidden
        Me.RBREMOVEADJ.Location = New System.Drawing.Point(207, 114)
        Me.RBREMOVEADJ.Name = "RBREMOVEADJ"
        Me.RBREMOVEADJ.Size = New System.Drawing.Size(20, 20)
        Me.RBREMOVEADJ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RBREMOVEADJ.TabIndex = 997
        Me.RBREMOVEADJ.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 258)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(548, 260)
        Me.TabControl1.TabIndex = 996
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.LBLBILLTOTAL)
        Me.TabPage1.Controls.Add(Me.TXTBILLREMARKS)
        Me.TabPage1.Controls.Add(Me.TXTADJSRNO)
        Me.TabPage1.Controls.Add(Me.GRIDPAYMENT)
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.TXTADJAMT)
        Me.TabPage1.Controls.Add(Me.TXTCHQBAL)
        Me.TabPage1.Controls.Add(Me.CMBPAYTYPE)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.CMBBILLNO)
        Me.TabPage1.Controls.Add(Me.TXTADJTOTAL)
        Me.TabPage1.Controls.Add(Me.TXTNARR)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(540, 233)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "1. Bill Adjustment"
        '
        'LBLBILLTOTAL
        '
        Me.LBLBILLTOTAL.BackColor = System.Drawing.Color.White
        Me.LBLBILLTOTAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBILLTOTAL.Location = New System.Drawing.Point(134, 27)
        Me.LBLBILLTOTAL.Name = "LBLBILLTOTAL"
        Me.LBLBILLTOTAL.Size = New System.Drawing.Size(103, 16)
        Me.LBLBILLTOTAL.TabIndex = 1010
        Me.LBLBILLTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTBILLREMARKS
        '
        Me.TXTBILLREMARKS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLREMARKS.ForeColor = System.Drawing.Color.DimGray
        Me.TXTBILLREMARKS.Location = New System.Drawing.Point(12, 4)
        Me.TXTBILLREMARKS.Multiline = True
        Me.TXTBILLREMARKS.Name = "TXTBILLREMARKS"
        Me.TXTBILLREMARKS.Size = New System.Drawing.Size(10, 31)
        Me.TXTBILLREMARKS.TabIndex = 1009
        Me.TXTBILLREMARKS.TabStop = False
        Me.TXTBILLREMARKS.Visible = False
        '
        'TXTADJSRNO
        '
        Me.TXTADJSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTADJSRNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADJSRNO.Location = New System.Drawing.Point(7, 46)
        Me.TXTADJSRNO.Name = "TXTADJSRNO"
        Me.TXTADJSRNO.ReadOnly = True
        Me.TXTADJSRNO.Size = New System.Drawing.Size(40, 23)
        Me.TXTADJSRNO.TabIndex = 999
        Me.TXTADJSRNO.TabStop = False
        '
        'GRIDPAYMENT
        '
        Me.GRIDPAYMENT.AllowUserToAddRows = False
        Me.GRIDPAYMENT.AllowUserToDeleteRows = False
        Me.GRIDPAYMENT.AllowUserToResizeColumns = False
        Me.GRIDPAYMENT.AllowUserToResizeRows = False
        DataGridViewCellStyle37.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDPAYMENT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle37
        Me.GRIDPAYMENT.BackgroundColor = System.Drawing.Color.White
        Me.GRIDPAYMENT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDPAYMENT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDPAYMENT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle38
        Me.GRIDPAYMENT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDPAYMENT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GADJSRNO, Me.gpaytype, Me.gbillno, Me.gdesc, Me.GADJAMT, Me.GAMTPAID, Me.GEXTRAAMT, Me.GRETURN, Me.GBALANCE})
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDPAYMENT.DefaultCellStyle = DataGridViewCellStyle40
        Me.GRIDPAYMENT.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDPAYMENT.Location = New System.Drawing.Point(6, 69)
        Me.GRIDPAYMENT.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDPAYMENT.MultiSelect = False
        Me.GRIDPAYMENT.Name = "GRIDPAYMENT"
        Me.GRIDPAYMENT.RowHeadersVisible = False
        DataGridViewCellStyle41.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDPAYMENT.RowsDefaultCellStyle = DataGridViewCellStyle41
        Me.GRIDPAYMENT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDPAYMENT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDPAYMENT.Size = New System.Drawing.Size(525, 112)
        Me.GRIDPAYMENT.TabIndex = 1004
        '
        'GADJSRNO
        '
        Me.GADJSRNO.HeaderText = "Sr."
        Me.GADJSRNO.Name = "GADJSRNO"
        Me.GADJSRNO.ReadOnly = True
        Me.GADJSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GADJSRNO.Width = 40
        '
        'gpaytype
        '
        Me.gpaytype.HeaderText = "Pay Type"
        Me.gpaytype.Name = "gpaytype"
        Me.gpaytype.ReadOnly = True
        Me.gpaytype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gbillno
        '
        Me.gbillno.HeaderText = "Bill No"
        Me.gbillno.Name = "gbillno"
        Me.gbillno.ReadOnly = True
        Me.gbillno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gbillno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gdesc
        '
        Me.gdesc.HeaderText = "Descritpion"
        Me.gdesc.Name = "gdesc"
        Me.gdesc.ReadOnly = True
        Me.gdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gdesc.Width = 150
        '
        'GADJAMT
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.Format = "N2"
        Me.GADJAMT.DefaultCellStyle = DataGridViewCellStyle39
        Me.GADJAMT.HeaderText = "Adj Amt"
        Me.GADJAMT.Name = "GADJAMT"
        Me.GADJAMT.ReadOnly = True
        Me.GADJAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GAMTPAID
        '
        Me.GAMTPAID.HeaderText = "AMTREC"
        Me.GAMTPAID.Name = "GAMTPAID"
        Me.GAMTPAID.Visible = False
        '
        'GEXTRAAMT
        '
        Me.GEXTRAAMT.HeaderText = "EXTRAAMT"
        Me.GEXTRAAMT.Name = "GEXTRAAMT"
        Me.GEXTRAAMT.Visible = False
        '
        'GRETURN
        '
        Me.GRETURN.HeaderText = "RETURN"
        Me.GRETURN.Name = "GRETURN"
        Me.GRETURN.Visible = False
        '
        'GBALANCE
        '
        Me.GBALANCE.HeaderText = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(239, 21)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(157, 15)
        Me.Label31.TabIndex = 1008
        Me.Label31.Text = "Bal (Return Amt - Total Amt)"
        '
        'TXTADJAMT
        '
        Me.TXTADJAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTADJAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADJAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTADJAMT.Location = New System.Drawing.Point(397, 46)
        Me.TXTADJAMT.Name = "TXTADJAMT"
        Me.TXTADJAMT.Size = New System.Drawing.Size(100, 23)
        Me.TXTADJAMT.TabIndex = 1003
        Me.TXTADJAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCHQBAL
        '
        Me.TXTCHQBAL.BackColor = System.Drawing.Color.Linen
        Me.TXTCHQBAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHQBAL.Location = New System.Drawing.Point(397, 17)
        Me.TXTCHQBAL.Name = "TXTCHQBAL"
        Me.TXTCHQBAL.ReadOnly = True
        Me.TXTCHQBAL.Size = New System.Drawing.Size(100, 23)
        Me.TXTCHQBAL.TabIndex = 1007
        Me.TXTCHQBAL.TabStop = False
        Me.TXTCHQBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBPAYTYPE
        '
        Me.CMBPAYTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPAYTYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPAYTYPE.FormattingEnabled = True
        Me.CMBPAYTYPE.Items.AddRange(New Object() {"On Account", "Against Bill", "New Ref"})
        Me.CMBPAYTYPE.Location = New System.Drawing.Point(47, 46)
        Me.CMBPAYTYPE.MaxDropDownItems = 14
        Me.CMBPAYTYPE.Name = "CMBPAYTYPE"
        Me.CMBPAYTYPE.Size = New System.Drawing.Size(100, 23)
        Me.CMBPAYTYPE.TabIndex = 1000
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(337, 189)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 15)
        Me.Label17.TabIndex = 1006
        Me.Label17.Text = "Total Amt"
        '
        'CMBBILLNO
        '
        Me.CMBBILLNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBBILLNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBBILLNO.Enabled = False
        Me.CMBBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBILLNO.FormattingEnabled = True
        Me.CMBBILLNO.Items.AddRange(New Object() {"Advance", "Against Bill", "On Account"})
        Me.CMBBILLNO.Location = New System.Drawing.Point(147, 46)
        Me.CMBBILLNO.MaxDropDownItems = 14
        Me.CMBBILLNO.Name = "CMBBILLNO"
        Me.CMBBILLNO.Size = New System.Drawing.Size(100, 23)
        Me.CMBBILLNO.TabIndex = 1001
        '
        'TXTADJTOTAL
        '
        Me.TXTADJTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTADJTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADJTOTAL.Location = New System.Drawing.Point(397, 185)
        Me.TXTADJTOTAL.Name = "TXTADJTOTAL"
        Me.TXTADJTOTAL.ReadOnly = True
        Me.TXTADJTOTAL.Size = New System.Drawing.Size(100, 23)
        Me.TXTADJTOTAL.TabIndex = 1005
        Me.TXTADJTOTAL.TabStop = False
        Me.TXTADJTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTNARR
        '
        Me.TXTNARR.BackColor = System.Drawing.Color.White
        Me.TXTNARR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNARR.ForeColor = System.Drawing.Color.Black
        Me.TXTNARR.Location = New System.Drawing.Point(247, 46)
        Me.TXTNARR.Name = "TXTNARR"
        Me.TXTNARR.Size = New System.Drawing.Size(150, 23)
        Me.TXTNARR.TabIndex = 1002
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.TXTCHGSSRNO)
        Me.TabPage2.Controls.Add(Me.GRIDCHGS)
        Me.TabPage2.Controls.Add(Me.CMBCHARGES)
        Me.TabPage2.Controls.Add(Me.TXTCHGSAMT)
        Me.TabPage2.Controls.Add(Me.TXTCHGSPER)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(540, 234)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "2. Charges"
        '
        'TXTCHGSSRNO
        '
        Me.TXTCHGSSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTCHGSSRNO.Location = New System.Drawing.Point(6, 6)
        Me.TXTCHGSSRNO.Name = "TXTCHGSSRNO"
        Me.TXTCHGSSRNO.ReadOnly = True
        Me.TXTCHGSSRNO.Size = New System.Drawing.Size(30, 22)
        Me.TXTCHGSSRNO.TabIndex = 840
        Me.TXTCHGSSRNO.TabStop = False
        '
        'GRIDCHGS
        '
        Me.GRIDCHGS.AllowUserToAddRows = False
        Me.GRIDCHGS.AllowUserToDeleteRows = False
        Me.GRIDCHGS.AllowUserToResizeColumns = False
        Me.GRIDCHGS.AllowUserToResizeRows = False
        DataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDCHGS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle42
        Me.GRIDCHGS.BackgroundColor = System.Drawing.Color.White
        Me.GRIDCHGS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDCHGS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDCHGS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle43
        Me.GRIDCHGS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDCHGS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ESRNO, Me.ECHARGES, Me.EPER, Me.EAMT, Me.ETAXID})
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCHGS.DefaultCellStyle = DataGridViewCellStyle47
        Me.GRIDCHGS.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDCHGS.Location = New System.Drawing.Point(5, 28)
        Me.GRIDCHGS.MultiSelect = False
        Me.GRIDCHGS.Name = "GRIDCHGS"
        Me.GRIDCHGS.ReadOnly = True
        Me.GRIDCHGS.RowHeadersVisible = False
        Me.GRIDCHGS.RowHeadersWidth = 30
        Me.GRIDCHGS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDCHGS.RowsDefaultCellStyle = DataGridViewCellStyle48
        Me.GRIDCHGS.RowTemplate.Height = 20
        Me.GRIDCHGS.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDCHGS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDCHGS.Size = New System.Drawing.Size(440, 188)
        Me.GRIDCHGS.TabIndex = 8
        Me.GRIDCHGS.TabStop = False
        '
        'ESRNO
        '
        Me.ESRNO.HeaderText = "Sr."
        Me.ESRNO.Name = "ESRNO"
        Me.ESRNO.ReadOnly = True
        Me.ESRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ESRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ESRNO.Width = 30
        '
        'ECHARGES
        '
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECHARGES.DefaultCellStyle = DataGridViewCellStyle44
        Me.ECHARGES.HeaderText = "Charges"
        Me.ECHARGES.Name = "ECHARGES"
        Me.ECHARGES.ReadOnly = True
        Me.ECHARGES.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ECHARGES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ECHARGES.Width = 225
        '
        'EPER
        '
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EPER.DefaultCellStyle = DataGridViewCellStyle45
        Me.EPER.HeaderText = "Percentage"
        Me.EPER.Name = "EPER"
        Me.EPER.ReadOnly = True
        Me.EPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EPER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EPER.Width = 75
        '
        'EAMT
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle46.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EAMT.DefaultCellStyle = DataGridViewCellStyle46
        Me.EAMT.HeaderText = "Amount"
        Me.EAMT.Name = "EAMT"
        Me.EAMT.ReadOnly = True
        Me.EAMT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EAMT.Width = 80
        '
        'ETAXID
        '
        Me.ETAXID.HeaderText = "TAXID"
        Me.ETAXID.Name = "ETAXID"
        Me.ETAXID.ReadOnly = True
        Me.ETAXID.Visible = False
        '
        'CMBCHARGES
        '
        Me.CMBCHARGES.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCHARGES.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCHARGES.FormattingEnabled = True
        Me.CMBCHARGES.Location = New System.Drawing.Point(35, 6)
        Me.CMBCHARGES.Name = "CMBCHARGES"
        Me.CMBCHARGES.Size = New System.Drawing.Size(225, 22)
        Me.CMBCHARGES.TabIndex = 14
        '
        'TXTCHGSAMT
        '
        Me.TXTCHGSAMT.BackColor = System.Drawing.Color.White
        Me.TXTCHGSAMT.Location = New System.Drawing.Point(335, 6)
        Me.TXTCHGSAMT.Name = "TXTCHGSAMT"
        Me.TXTCHGSAMT.Size = New System.Drawing.Size(80, 22)
        Me.TXTCHGSAMT.TabIndex = 16
        Me.TXTCHGSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCHGSPER
        '
        Me.TXTCHGSPER.BackColor = System.Drawing.Color.White
        Me.TXTCHGSPER.Location = New System.Drawing.Point(260, 6)
        Me.TXTCHGSPER.Name = "TXTCHGSPER"
        Me.TXTCHGSPER.Size = New System.Drawing.Size(75, 22)
        Me.TXTCHGSPER.TabIndex = 15
        Me.TXTCHGSPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.TXTFILENAME)
        Me.TabPage3.Controls.Add(Me.txtimgpath)
        Me.TabPage3.Controls.Add(Me.ACKDATE)
        Me.TabPage3.Controls.Add(Me.LBLACKDATE)
        Me.TabPage3.Controls.Add(Me.TXTACKNO)
        Me.TabPage3.Controls.Add(Me.LBLACKNO)
        Me.TabPage3.Controls.Add(Me.CMDGETQRCODE)
        Me.TabPage3.Controls.Add(Me.PBQRCODE)
        Me.TabPage3.Controls.Add(Me.CMDUPLOADIRN)
        Me.TabPage3.Controls.Add(Me.LBLIRN)
        Me.TabPage3.Controls.Add(Me.TXTIRNNO)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(540, 233)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "3. Additional Details"
        '
        'ACKDATE
        '
        Me.ACKDATE.CustomFormat = "dd/MM/yyyy"
        Me.ACKDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACKDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ACKDATE.Location = New System.Drawing.Point(307, 84)
        Me.ACKDATE.Name = "ACKDATE"
        Me.ACKDATE.Size = New System.Drawing.Size(85, 23)
        Me.ACKDATE.TabIndex = 1019
        '
        'LBLACKDATE
        '
        Me.LBLACKDATE.AutoSize = True
        Me.LBLACKDATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLACKDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLACKDATE.Location = New System.Drawing.Point(250, 88)
        Me.LBLACKDATE.Name = "LBLACKDATE"
        Me.LBLACKDATE.Size = New System.Drawing.Size(54, 15)
        Me.LBLACKDATE.TabIndex = 1020
        Me.LBLACKDATE.Text = "Ack Date"
        Me.LBLACKDATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTACKNO
        '
        Me.TXTACKNO.BackColor = System.Drawing.Color.White
        Me.TXTACKNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACKNO.Location = New System.Drawing.Point(307, 56)
        Me.TXTACKNO.Name = "TXTACKNO"
        Me.TXTACKNO.Size = New System.Drawing.Size(170, 23)
        Me.TXTACKNO.TabIndex = 1017
        Me.TXTACKNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLACKNO
        '
        Me.LBLACKNO.AutoSize = True
        Me.LBLACKNO.BackColor = System.Drawing.Color.Transparent
        Me.LBLACKNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLACKNO.ForeColor = System.Drawing.Color.Black
        Me.LBLACKNO.Location = New System.Drawing.Point(261, 60)
        Me.LBLACKNO.Name = "LBLACKNO"
        Me.LBLACKNO.Size = New System.Drawing.Size(43, 14)
        Me.LBLACKNO.TabIndex = 1018
        Me.LBLACKNO.Text = "Ack No"
        Me.LBLACKNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMDGETQRCODE
        '
        Me.CMDGETQRCODE.BackColor = System.Drawing.Color.Transparent
        Me.CMDGETQRCODE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDGETQRCODE.FlatAppearance.BorderSize = 0
        Me.CMDGETQRCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDGETQRCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDGETQRCODE.Location = New System.Drawing.Point(251, 178)
        Me.CMDGETQRCODE.Name = "CMDGETQRCODE"
        Me.CMDGETQRCODE.Size = New System.Drawing.Size(100, 27)
        Me.CMDGETQRCODE.TabIndex = 1016
        Me.CMDGETQRCODE.Text = "&Get QRCode"
        Me.CMDGETQRCODE.UseVisualStyleBackColor = False
        '
        'PBQRCODE
        '
        Me.PBQRCODE.BackColor = System.Drawing.Color.Transparent
        Me.PBQRCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBQRCODE.Location = New System.Drawing.Point(95, 55)
        Me.PBQRCODE.Name = "PBQRCODE"
        Me.PBQRCODE.Size = New System.Drawing.Size(150, 150)
        Me.PBQRCODE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBQRCODE.TabIndex = 1014
        Me.PBQRCODE.TabStop = False
        '
        'CMDUPLOADIRN
        '
        Me.CMDUPLOADIRN.BackColor = System.Drawing.Color.Transparent
        Me.CMDUPLOADIRN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUPLOADIRN.FlatAppearance.BorderSize = 0
        Me.CMDUPLOADIRN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOADIRN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDUPLOADIRN.Location = New System.Drawing.Point(251, 144)
        Me.CMDUPLOADIRN.Name = "CMDUPLOADIRN"
        Me.CMDUPLOADIRN.Size = New System.Drawing.Size(100, 27)
        Me.CMDUPLOADIRN.TabIndex = 1015
        Me.CMDUPLOADIRN.Text = "&Upload"
        Me.CMDUPLOADIRN.UseVisualStyleBackColor = False
        '
        'LBLIRN
        '
        Me.LBLIRN.AutoSize = True
        Me.LBLIRN.BackColor = System.Drawing.Color.Transparent
        Me.LBLIRN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLIRN.ForeColor = System.Drawing.Color.Black
        Me.LBLIRN.Location = New System.Drawing.Point(63, 32)
        Me.LBLIRN.Name = "LBLIRN"
        Me.LBLIRN.Size = New System.Drawing.Size(26, 14)
        Me.LBLIRN.TabIndex = 1013
        Me.LBLIRN.Text = "IRN"
        Me.LBLIRN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTIRNNO
        '
        Me.TXTIRNNO.BackColor = System.Drawing.Color.White
        Me.TXTIRNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIRNNO.Location = New System.Drawing.Point(95, 28)
        Me.TXTIRNNO.Name = "TXTIRNNO"
        Me.TXTIRNNO.Size = New System.Drawing.Size(382, 22)
        Me.TXTIRNNO.TabIndex = 1012
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(1055, 511)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(34, 15)
        Me.Label32.TabIndex = 995
        Me.Label32.Text = "Total"
        '
        'TXTINVTOTAL
        '
        Me.TXTINVTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTINVTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINVTOTAL.Location = New System.Drawing.Point(1092, 507)
        Me.TXTINVTOTAL.Name = "TXTINVTOTAL"
        Me.TXTINVTOTAL.ReadOnly = True
        Me.TXTINVTOTAL.Size = New System.Drawing.Size(90, 23)
        Me.TXTINVTOTAL.TabIndex = 994
        Me.TXTINVTOTAL.TabStop = False
        Me.TXTINVTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDBILL
        '
        Me.GRIDBILL.AllowUserToAddRows = False
        Me.GRIDBILL.AllowUserToDeleteRows = False
        Me.GRIDBILL.AllowUserToResizeColumns = False
        Me.GRIDBILL.AllowUserToResizeRows = False
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDBILL.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle33
        Me.GRIDBILL.BackgroundColor = System.Drawing.Color.White
        Me.GRIDBILL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDBILL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDBILL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.GRIDBILL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDBILL.DefaultCellStyle = DataGridViewCellStyle35
        Me.GRIDBILL.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDBILL.Location = New System.Drawing.Point(565, 281)
        Me.GRIDBILL.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDBILL.MultiSelect = False
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.RowHeadersVisible = False
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDBILL.RowsDefaultCellStyle = DataGridViewCellStyle36
        Me.GRIDBILL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDBILL.Size = New System.Drawing.Size(669, 213)
        Me.GRIDBILL.TabIndex = 993
        Me.GRIDBILL.TabStop = False
        '
        'TXTTOTALWITHGST
        '
        Me.TXTTOTALWITHGST.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALWITHGST.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALWITHGST.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALWITHGST.Location = New System.Drawing.Point(902, 242)
        Me.TXTTOTALWITHGST.Name = "TXTTOTALWITHGST"
        Me.TXTTOTALWITHGST.ReadOnly = True
        Me.TXTTOTALWITHGST.Size = New System.Drawing.Size(90, 23)
        Me.TXTTOTALWITHGST.TabIndex = 992
        Me.TXTTOTALWITHGST.TabStop = False
        Me.TXTTOTALWITHGST.Text = "0.00"
        Me.TXTTOTALWITHGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTOTALWITHGST.Visible = False
        '
        'CHKTCS
        '
        Me.CHKTCS.AutoSize = True
        Me.CHKTCS.BackColor = System.Drawing.Color.Transparent
        Me.CHKTCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKTCS.Location = New System.Drawing.Point(778, 215)
        Me.CHKTCS.Name = "CHKTCS"
        Me.CHKTCS.Size = New System.Drawing.Size(79, 19)
        Me.CHKTCS.TabIndex = 991
        Me.CHKTCS.Text = "Apply TCS"
        Me.CHKTCS.UseVisualStyleBackColor = False
        '
        'TXTTCSPER
        '
        Me.TXTTCSPER.BackColor = System.Drawing.Color.Linen
        Me.TXTTCSPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTCSPER.ForeColor = System.Drawing.Color.Black
        Me.TXTTCSPER.Location = New System.Drawing.Point(861, 213)
        Me.TXTTCSPER.Name = "TXTTCSPER"
        Me.TXTTCSPER.ReadOnly = True
        Me.TXTTCSPER.Size = New System.Drawing.Size(37, 23)
        Me.TXTTCSPER.TabIndex = 990
        Me.TXTTCSPER.TabStop = False
        Me.TXTTCSPER.Text = "0.00"
        Me.TXTTCSPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTCSAMT
        '
        Me.TXTTCSAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTCSAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTCSAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTTCSAMT.Location = New System.Drawing.Point(902, 213)
        Me.TXTTCSAMT.Name = "TXTTCSAMT"
        Me.TXTTCSAMT.ReadOnly = True
        Me.TXTTCSAMT.Size = New System.Drawing.Size(90, 23)
        Me.TXTTCSAMT.TabIndex = 989
        Me.TXTTCSAMT.TabStop = False
        Me.TXTTCSAMT.Text = "0.00"
        Me.TXTTCSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(1002, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 15)
        Me.Label16.TabIndex = 988
        Me.Label16.Text = "Actual Amt."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(848, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 15)
        Me.Label14.TabIndex = 987
        Me.Label14.Text = "Total Pcs"
        '
        'TXTTOTALPCS
        '
        Me.TXTTOTALPCS.BackColor = System.Drawing.Color.White
        Me.TXTTOTALPCS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPCS.Location = New System.Drawing.Point(902, 69)
        Me.TXTTOTALPCS.Name = "TXTTOTALPCS"
        Me.TXTTOTALPCS.Size = New System.Drawing.Size(91, 23)
        Me.TXTTOTALPCS.TabIndex = 10
        Me.TXTTOTALPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(840, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 15)
        Me.Label15.TabIndex = 985
        Me.Label15.Text = "Total Mtrs"
        '
        'TXTTOTALMTRS
        '
        Me.TXTTOTALMTRS.BackColor = System.Drawing.Color.White
        Me.TXTTOTALMTRS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALMTRS.Location = New System.Drawing.Point(902, 98)
        Me.TXTTOTALMTRS.Name = "TXTTOTALMTRS"
        Me.TXTTOTALMTRS.Size = New System.Drawing.Size(91, 23)
        Me.TXTTOTALMTRS.TabIndex = 11
        Me.TXTTOTALMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDISCPER
        '
        Me.TXTDISCPER.BackColor = System.Drawing.Color.White
        Me.TXTDISCPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISCPER.Location = New System.Drawing.Point(1165, 68)
        Me.TXTDISCPER.Name = "TXTDISCPER"
        Me.TXTDISCPER.Size = New System.Drawing.Size(57, 23)
        Me.TXTDISCPER.TabIndex = 12
        Me.TXTDISCPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTACTUALINVAMT
        '
        Me.TXTACTUALINVAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTACTUALINVAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTACTUALINVAMT.Location = New System.Drawing.Point(1072, 68)
        Me.TXTACTUALINVAMT.Name = "TXTACTUALINVAMT"
        Me.TXTACTUALINVAMT.ReadOnly = True
        Me.TXTACTUALINVAMT.Size = New System.Drawing.Size(91, 23)
        Me.TXTACTUALINVAMT.TabIndex = 952
        Me.TXTACTUALINVAMT.TabStop = False
        Me.TXTACTUALINVAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(190, 203)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(197, 15)
        Me.Label13.TabIndex = 951
        Me.Label13.Text = "(This No will be reflected in GSTR1)"
        '
        'TXTPARTYBILLDATE
        '
        Me.TXTPARTYBILLDATE.AsciiOnly = True
        Me.TXTPARTYBILLDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTPARTYBILLDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.TXTPARTYBILLDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.TXTPARTYBILLDATE.Location = New System.Drawing.Point(592, 55)
        Me.TXTPARTYBILLDATE.Mask = "00/00/0000"
        Me.TXTPARTYBILLDATE.Name = "TXTPARTYBILLDATE"
        Me.TXTPARTYBILLDATE.Size = New System.Drawing.Size(90, 23)
        Me.TXTPARTYBILLDATE.TabIndex = 950
        Me.TXTPARTYBILLDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.TXTPARTYBILLDATE.ValidatingType = GetType(Date)
        '
        'TXTSALEREFNO
        '
        Me.TXTSALEREFNO.BackColor = System.Drawing.Color.White
        Me.TXTSALEREFNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSALEREFNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSALEREFNO.ForeColor = System.Drawing.Color.Black
        Me.TXTSALEREFNO.Location = New System.Drawing.Point(107, 199)
        Me.TXTSALEREFNO.MaxLength = 100
        Me.TXTSALEREFNO.Name = "TXTSALEREFNO"
        Me.TXTSALEREFNO.Size = New System.Drawing.Size(80, 23)
        Me.TXTSALEREFNO.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(39, 203)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 949
        Me.Label11.Text = "Sale Ref No"
        '
        'CHKGSTR1
        '
        Me.CHKGSTR1.AutoSize = True
        Me.CHKGSTR1.BackColor = System.Drawing.Color.Transparent
        Me.CHKGSTR1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGSTR1.Location = New System.Drawing.Point(727, 73)
        Me.CHKGSTR1.Name = "CHKGSTR1"
        Me.CHKGSTR1.Size = New System.Drawing.Size(106, 19)
        Me.CHKGSTR1.TabIndex = 948
        Me.CHKGSTR1.Text = "Show In GSTR1"
        Me.CHKGSTR1.UseVisualStyleBackColor = False
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(177, 10)
        Me.TXTADD.MaxLength = 100
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(48, 22)
        Me.TXTADD.TabIndex = 947
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(177, 10)
        Me.CMBCODE.MaxLength = 100
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(48, 22)
        Me.CMBCODE.TabIndex = 946
        Me.CMBCODE.Visible = False
        '
        'CMBAGENT
        '
        Me.CMBAGENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENT.BackColor = System.Drawing.Color.White
        Me.CMBAGENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENT.FormattingEnabled = True
        Me.CMBAGENT.Items.AddRange(New Object() {""})
        Me.CMBAGENT.Location = New System.Drawing.Point(106, 142)
        Me.CMBAGENT.Name = "CMBAGENT"
        Me.CMBAGENT.Size = New System.Drawing.Size(230, 22)
        Me.CMBAGENT.TabIndex = 944
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(67, 146)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 14)
        Me.Label10.TabIndex = 945
        Me.Label10.Text = "Agent"
        '
        'DNDATE
        '
        Me.DNDATE.AsciiOnly = True
        Me.DNDATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.DNDATE.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.DNDATE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.DNDATE.Location = New System.Drawing.Point(1131, 39)
        Me.DNDATE.Mask = "00/00/0000"
        Me.DNDATE.Name = "DNDATE"
        Me.DNDATE.Size = New System.Drawing.Size(91, 23)
        Me.DNDATE.TabIndex = 2
        Me.DNDATE.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.DNDATE.ValidatingType = GetType(Date)
        '
        'CHKMANUALROUND
        '
        Me.CHKMANUALROUND.AutoSize = True
        Me.CHKMANUALROUND.BackColor = System.Drawing.Color.Transparent
        Me.CHKMANUALROUND.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMANUALROUND.Location = New System.Drawing.Point(1165, 186)
        Me.CHKMANUALROUND.Name = "CHKMANUALROUND"
        Me.CHKMANUALROUND.Size = New System.Drawing.Size(127, 19)
        Me.CHKMANUALROUND.TabIndex = 903
        Me.CHKMANUALROUND.Text = "Manual Round Off"
        Me.CHKMANUALROUND.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(551, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 15)
        Me.Label9.TabIndex = 942
        Me.Label9.Text = "Bill Dt"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(361, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 940
        Me.Label7.Text = "Party Bill"
        '
        'TXTPARTYBILLNO
        '
        Me.TXTPARTYBILLNO.BackColor = System.Drawing.Color.Linen
        Me.TXTPARTYBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPARTYBILLNO.Location = New System.Drawing.Point(420, 55)
        Me.TXTPARTYBILLNO.Name = "TXTPARTYBILLNO"
        Me.TXTPARTYBILLNO.ReadOnly = True
        Me.TXTPARTYBILLNO.Size = New System.Drawing.Size(124, 23)
        Me.TXTPARTYBILLNO.TabIndex = 939
        Me.TXTPARTYBILLNO.TabStop = False
        Me.TXTPARTYBILLNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDVIEW.Location = New System.Drawing.Point(245, 21)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(99, 28)
        Me.CMDVIEW.TabIndex = 4
        Me.CMDVIEW.Text = "&Get Bills"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        Me.CMDVIEW.Visible = False
        '
        'TXTRETURN
        '
        Me.TXTRETURN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRETURN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRETURN.Location = New System.Drawing.Point(950, 16)
        Me.TXTRETURN.Name = "TXTRETURN"
        Me.TXTRETURN.Size = New System.Drawing.Size(29, 22)
        Me.TXTRETURN.TabIndex = 937
        Me.TXTRETURN.TabStop = False
        Me.TXTRETURN.Visible = False
        '
        'TXTEXTRAAMT
        '
        Me.TXTEXTRAAMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTEXTRAAMT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRAAMT.Location = New System.Drawing.Point(966, 16)
        Me.TXTEXTRAAMT.Name = "TXTEXTRAAMT"
        Me.TXTEXTRAAMT.Size = New System.Drawing.Size(29, 22)
        Me.TXTEXTRAAMT.TabIndex = 936
        Me.TXTEXTRAAMT.TabStop = False
        Me.TXTEXTRAAMT.Visible = False
        '
        'TXTAMTREC
        '
        Me.TXTAMTREC.BackColor = System.Drawing.Color.Linen
        Me.TXTAMTREC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTAMTREC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMTREC.ForeColor = System.Drawing.Color.Black
        Me.TXTAMTREC.Location = New System.Drawing.Point(897, 42)
        Me.TXTAMTREC.Name = "TXTAMTREC"
        Me.TXTAMTREC.ReadOnly = True
        Me.TXTAMTREC.Size = New System.Drawing.Size(95, 23)
        Me.TXTAMTREC.TabIndex = 935
        Me.TXTAMTREC.TabStop = False
        Me.TXTAMTREC.Text = "0.00"
        Me.TXTAMTREC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTAMTREC.Visible = False
        '
        'PBRECD
        '
        Me.PBRECD.BackColor = System.Drawing.Color.Transparent
        Me.PBRECD.Image = Global.PROTRADE.My.Resources.Resources.recd
        Me.PBRECD.Location = New System.Drawing.Point(657, 182)
        Me.PBRECD.Name = "PBRECD"
        Me.PBRECD.Size = New System.Drawing.Size(74, 36)
        Me.PBRECD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBRECD.TabIndex = 934
        Me.PBRECD.TabStop = False
        Me.PBRECD.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(998, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 15)
        Me.Label8.TabIndex = 933
        Me.Label8.Text = "Balance Amt"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(17, 531)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(55, 14)
        Me.Label39.TabIndex = 647
        Me.Label39.Text = "In Words"
        '
        'TXTBAL
        '
        Me.TXTBAL.BackColor = System.Drawing.Color.Linen
        Me.TXTBAL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBAL.Location = New System.Drawing.Point(1072, 242)
        Me.TXTBAL.Name = "TXTBAL"
        Me.TXTBAL.ReadOnly = True
        Me.TXTBAL.Size = New System.Drawing.Size(91, 23)
        Me.TXTBAL.TabIndex = 932
        Me.TXTBAL.TabStop = False
        Me.TXTBAL.Text = "0.00"
        Me.TXTBAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.AutoSize = True
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(655, 150)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(89, 27)
        Me.CMDSHOWDETAILS.TabIndex = 931
        Me.CMDSHOWDETAILS.Text = "Show Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'CHKMANUAL
        '
        Me.CHKMANUAL.AutoSize = True
        Me.CHKMANUAL.BackColor = System.Drawing.Color.Transparent
        Me.CHKMANUAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMANUAL.Location = New System.Drawing.Point(727, 98)
        Me.CHKMANUAL.Name = "CHKMANUAL"
        Me.CHKMANUAL.Size = New System.Drawing.Size(92, 19)
        Me.CHKMANUAL.TabIndex = 14
        Me.CHKMANUAL.Text = "Manual GST"
        Me.CHKMANUAL.UseVisualStyleBackColor = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(720, 127)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 929
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'txtinwords
        '
        Me.txtinwords.BackColor = System.Drawing.Color.Linen
        Me.txtinwords.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwords.ForeColor = System.Drawing.Color.DimGray
        Me.txtinwords.Location = New System.Drawing.Point(74, 528)
        Me.txtinwords.Name = "txtinwords"
        Me.txtinwords.ReadOnly = True
        Me.txtinwords.Size = New System.Drawing.Size(470, 22)
        Me.txtinwords.TabIndex = 646
        Me.txtinwords.TabStop = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = CType(resources.GetObject("PBlock.Image"), System.Drawing.Image)
        Me.PBlock.Location = New System.Drawing.Point(654, 84)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 930
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(240, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 14)
        Me.Label12.TabIndex = 928
        Me.Label12.Text = " State"
        '
        'TXTSTATECODE
        '
        Me.TXTSTATECODE.BackColor = System.Drawing.Color.Linen
        Me.TXTSTATECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSTATECODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTATECODE.Location = New System.Drawing.Point(279, 113)
        Me.TXTSTATECODE.MaxLength = 10
        Me.TXTSTATECODE.Name = "TXTSTATECODE"
        Me.TXTSTATECODE.ReadOnly = True
        Me.TXTSTATECODE.Size = New System.Drawing.Size(56, 22)
        Me.TXTSTATECODE.TabIndex = 927
        Me.TXTSTATECODE.TabStop = False
        Me.TXTSTATECODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTIGSTPER
        '
        Me.TXTIGSTPER.BackColor = System.Drawing.Color.Linen
        Me.TXTIGSTPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIGSTPER.ForeColor = System.Drawing.Color.Black
        Me.TXTIGSTPER.Location = New System.Drawing.Point(861, 184)
        Me.TXTIGSTPER.Name = "TXTIGSTPER"
        Me.TXTIGSTPER.ReadOnly = True
        Me.TXTIGSTPER.Size = New System.Drawing.Size(37, 23)
        Me.TXTIGSTPER.TabIndex = 926
        Me.TXTIGSTPER.TabStop = False
        Me.TXTIGSTPER.Text = "0.00"
        Me.TXTIGSTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTSGSTPER
        '
        Me.TXTSGSTPER.BackColor = System.Drawing.Color.Linen
        Me.TXTSGSTPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSGSTPER.ForeColor = System.Drawing.Color.Black
        Me.TXTSGSTPER.Location = New System.Drawing.Point(861, 155)
        Me.TXTSGSTPER.Name = "TXTSGSTPER"
        Me.TXTSGSTPER.ReadOnly = True
        Me.TXTSGSTPER.Size = New System.Drawing.Size(37, 23)
        Me.TXTSGSTPER.TabIndex = 925
        Me.TXTSGSTPER.TabStop = False
        Me.TXTSGSTPER.Text = "0.00"
        Me.TXTSGSTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCGSTPER
        '
        Me.TXTCGSTPER.BackColor = System.Drawing.Color.Linen
        Me.TXTCGSTPER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGSTPER.ForeColor = System.Drawing.Color.Black
        Me.TXTCGSTPER.Location = New System.Drawing.Point(861, 126)
        Me.TXTCGSTPER.Name = "TXTCGSTPER"
        Me.TXTCGSTPER.ReadOnly = True
        Me.TXTCGSTPER.Size = New System.Drawing.Size(37, 23)
        Me.TXTCGSTPER.TabIndex = 924
        Me.TXTCGSTPER.TabStop = False
        Me.TXTCGSTPER.Text = "0.00"
        Me.TXTCGSTPER.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTIGSTAMT
        '
        Me.TXTIGSTAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTIGSTAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTIGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTIGSTAMT.Location = New System.Drawing.Point(902, 184)
        Me.TXTIGSTAMT.Name = "TXTIGSTAMT"
        Me.TXTIGSTAMT.ReadOnly = True
        Me.TXTIGSTAMT.Size = New System.Drawing.Size(90, 23)
        Me.TXTIGSTAMT.TabIndex = 17
        Me.TXTIGSTAMT.TabStop = False
        Me.TXTIGSTAMT.Text = "0.00"
        Me.TXTIGSTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(799, 188)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 15)
        Me.Label30.TabIndex = 922
        Me.Label30.Text = "Total IGST"
        '
        'TXTSGSTAMT
        '
        Me.TXTSGSTAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTSGSTAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTSGSTAMT.Location = New System.Drawing.Point(902, 155)
        Me.TXTSGSTAMT.Name = "TXTSGSTAMT"
        Me.TXTSGSTAMT.ReadOnly = True
        Me.TXTSGSTAMT.Size = New System.Drawing.Size(90, 23)
        Me.TXTSGSTAMT.TabIndex = 16
        Me.TXTSGSTAMT.TabStop = False
        Me.TXTSGSTAMT.Text = "0.00"
        Me.TXTSGSTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(796, 159)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(63, 15)
        Me.Label29.TabIndex = 920
        Me.Label29.Text = "Total SGST"
        '
        'TXTCGSTAMT
        '
        Me.TXTCGSTAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTCGSTAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGSTAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTCGSTAMT.Location = New System.Drawing.Point(902, 126)
        Me.TXTCGSTAMT.Name = "TXTCGSTAMT"
        Me.TXTCGSTAMT.ReadOnly = True
        Me.TXTCGSTAMT.Size = New System.Drawing.Size(90, 23)
        Me.TXTCGSTAMT.TabIndex = 15
        Me.TXTCGSTAMT.TabStop = False
        Me.TXTCGSTAMT.Text = "0.00"
        Me.TXTCGSTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(795, 130)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 15)
        Me.Label28.TabIndex = 918
        Me.Label28.Text = "Total CGST"
        '
        'LBLSACCODE
        '
        Me.LBLSACCODE.AutoSize = True
        Me.LBLSACCODE.BackColor = System.Drawing.Color.Transparent
        Me.LBLSACCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSACCODE.ForeColor = System.Drawing.Color.Black
        Me.LBLSACCODE.Location = New System.Drawing.Point(243, 174)
        Me.LBLSACCODE.Name = "LBLSACCODE"
        Me.LBLSACCODE.Size = New System.Drawing.Size(34, 15)
        Me.LBLSACCODE.TabIndex = 917
        Me.LBLSACCODE.Text = "Code"
        '
        'TXTSACCODE
        '
        Me.TXTSACCODE.BackColor = System.Drawing.Color.Linen
        Me.TXTSACCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSACCODE.Location = New System.Drawing.Point(279, 170)
        Me.TXTSACCODE.Name = "TXTSACCODE"
        Me.TXTSACCODE.ReadOnly = True
        Me.TXTSACCODE.Size = New System.Drawing.Size(57, 23)
        Me.TXTSACCODE.TabIndex = 915
        Me.TXTSACCODE.TabStop = False
        Me.TXTSACCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBSACDESC
        '
        Me.CMBSACDESC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSACDESC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSACDESC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBSACDESC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSACDESC.FormattingEnabled = True
        Me.CMBSACDESC.Location = New System.Drawing.Point(107, 170)
        Me.CMBSACDESC.Name = "CMBSACDESC"
        Me.CMBSACDESC.Size = New System.Drawing.Size(124, 23)
        Me.CMBSACDESC.TabIndex = 6
        '
        'LBLSACDESC
        '
        Me.LBLSACDESC.AutoSize = True
        Me.LBLSACDESC.BackColor = System.Drawing.Color.Transparent
        Me.LBLSACDESC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSACDESC.ForeColor = System.Drawing.Color.Black
        Me.LBLSACDESC.Location = New System.Drawing.Point(52, 174)
        Me.LBLSACDESC.Name = "LBLSACDESC"
        Me.LBLSACDESC.Size = New System.Drawing.Size(58, 14)
        Me.LBLSACDESC.TabIndex = 916
        Me.LBLSACDESC.Text = "HSN Desc"
        Me.LBLSACDESC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBCREDITLEDGER
        '
        Me.CMBCREDITLEDGER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCREDITLEDGER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCREDITLEDGER.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCREDITLEDGER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCREDITLEDGER.FormattingEnabled = True
        Me.CMBCREDITLEDGER.Items.AddRange(New Object() {""})
        Me.CMBCREDITLEDGER.Location = New System.Drawing.Point(420, 84)
        Me.CMBCREDITLEDGER.Name = "CMBCREDITLEDGER"
        Me.CMBCREDITLEDGER.Size = New System.Drawing.Size(229, 23)
        Me.CMBCREDITLEDGER.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(341, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 846
        Me.Label6.Text = "Credit Ledger"
        '
        'TXTTAXID
        '
        Me.TXTTAXID.BackColor = System.Drawing.Color.White
        Me.TXTTAXID.Location = New System.Drawing.Point(196, 10)
        Me.TXTTAXID.Name = "TXTTAXID"
        Me.TXTTAXID.Size = New System.Drawing.Size(10, 22)
        Me.TXTTAXID.TabIndex = 844
        Me.TXTTAXID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTAXID.Visible = False
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(420, 113)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(229, 97)
        Me.txtremarks.TabIndex = 9
        '
        'TXTTOTALTAXAMT
        '
        Me.TXTTOTALTAXAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALTAXAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALTAXAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALTAXAMT.Location = New System.Drawing.Point(163, 10)
        Me.TXTTOTALTAXAMT.Name = "TXTTOTALTAXAMT"
        Me.TXTTOTALTAXAMT.ReadOnly = True
        Me.TXTTOTALTAXAMT.Size = New System.Drawing.Size(76, 23)
        Me.TXTTOTALTAXAMT.TabIndex = 830
        Me.TXTTOTALTAXAMT.TabStop = False
        Me.TXTTOTALTAXAMT.Text = "0.00"
        Me.TXTTOTALTAXAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTOTALTAXAMT.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(172, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 829
        Me.Label3.Text = "TOTALTAX"
        Me.Label3.Visible = False
        '
        'TXTTOTALOTHERCHGSAMT
        '
        Me.TXTTOTALOTHERCHGSAMT.BackColor = System.Drawing.Color.Linen
        Me.TXTTOTALOTHERCHGSAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALOTHERCHGSAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALOTHERCHGSAMT.Location = New System.Drawing.Point(163, 10)
        Me.TXTTOTALOTHERCHGSAMT.Name = "TXTTOTALOTHERCHGSAMT"
        Me.TXTTOTALOTHERCHGSAMT.ReadOnly = True
        Me.TXTTOTALOTHERCHGSAMT.Size = New System.Drawing.Size(76, 23)
        Me.TXTTOTALOTHERCHGSAMT.TabIndex = 828
        Me.TXTTOTALOTHERCHGSAMT.TabStop = False
        Me.TXTTOTALOTHERCHGSAMT.Text = "0.00"
        Me.TXTTOTALOTHERCHGSAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTOTALOTHERCHGSAMT.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(165, 14)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 15)
        Me.Label24.TabIndex = 827
        Me.Label24.Text = "OTHERCHGS"
        Me.Label24.Visible = False
        '
        'TXTCHARGES
        '
        Me.TXTCHARGES.BackColor = System.Drawing.Color.Linen
        Me.TXTCHARGES.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHARGES.ForeColor = System.Drawing.Color.Black
        Me.TXTCHARGES.Location = New System.Drawing.Point(1072, 126)
        Me.TXTCHARGES.Name = "TXTCHARGES"
        Me.TXTCHARGES.ReadOnly = True
        Me.TXTCHARGES.Size = New System.Drawing.Size(91, 23)
        Me.TXTCHARGES.TabIndex = 726
        Me.TXTCHARGES.TabStop = False
        Me.TXTCHARGES.Text = "0.00"
        Me.TXTCHARGES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1021, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 725
        Me.Label1.Text = "Charges"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(722, 525)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 20
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBACCCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBACCCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Items.AddRange(New Object() {""})
        Me.CMBACCCODE.Location = New System.Drawing.Point(164, 10)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(74, 22)
        Me.CMBACCCODE.TabIndex = 705
        Me.CMBACCCODE.Visible = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Items.AddRange(New Object() {""})
        Me.CMBNAME.Location = New System.Drawing.Point(107, 84)
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(229, 23)
        Me.CMBNAME.TabIndex = 3
        '
        'TXTOTHERCHGSADD
        '
        Me.TXTOTHERCHGSADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOTHERCHGSADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTOTHERCHGSADD.Location = New System.Drawing.Point(193, 12)
        Me.TXTOTHERCHGSADD.Multiline = True
        Me.TXTOTHERCHGSADD.Name = "TXTOTHERCHGSADD"
        Me.TXTOTHERCHGSADD.Size = New System.Drawing.Size(17, 18)
        Me.TXTOTHERCHGSADD.TabIndex = 704
        Me.TXTOTHERCHGSADD.Visible = False
        '
        'CMBOTHERCHGSCODE
        '
        Me.CMBOTHERCHGSCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBOTHERCHGSCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERCHGSCODE.FormattingEnabled = True
        Me.CMBOTHERCHGSCODE.Items.AddRange(New Object() {"", "Add", "Sub."})
        Me.CMBOTHERCHGSCODE.Location = New System.Drawing.Point(178, 10)
        Me.CMBOTHERCHGSCODE.Name = "CMBOTHERCHGSCODE"
        Me.CMBOTHERCHGSCODE.Size = New System.Drawing.Size(47, 22)
        Me.CMBOTHERCHGSCODE.TabIndex = 703
        Me.CMBOTHERCHGSCODE.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 702
        Me.Label4.Text = "Bill No"
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.BackColor = System.Drawing.Color.White
        Me.TXTBILLNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.ForeColor = System.Drawing.Color.Black
        Me.TXTBILLNO.Location = New System.Drawing.Point(107, 113)
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.Size = New System.Drawing.Size(99, 23)
        Me.TXTBILLNO.TabIndex = 5
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(32, 88)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(74, 15)
        Me.Label33.TabIndex = 681
        Me.Label33.Text = "Debit Ledger"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(991, 101)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(80, 15)
        Me.Label51.TabIndex = 667
        Me.Label51.Text = "Total Pur Amt"
        '
        'TXTTOTALPURAMT
        '
        Me.TXTTOTALPURAMT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTTOTALPURAMT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALPURAMT.ForeColor = System.Drawing.Color.Black
        Me.TXTTOTALPURAMT.Location = New System.Drawing.Point(1072, 97)
        Me.TXTTOTALPURAMT.Name = "TXTTOTALPURAMT"
        Me.TXTTOTALPURAMT.Size = New System.Drawing.Size(91, 23)
        Me.TXTTOTALPURAMT.TabIndex = 13
        Me.TXTTOTALPURAMT.Text = "0.00"
        Me.TXTTOTALPURAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgrandtotal
        '
        Me.txtgrandtotal.BackColor = System.Drawing.Color.Linen
        Me.txtgrandtotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrandtotal.ForeColor = System.Drawing.Color.Black
        Me.txtgrandtotal.Location = New System.Drawing.Point(1072, 213)
        Me.txtgrandtotal.Name = "txtgrandtotal"
        Me.txtgrandtotal.ReadOnly = True
        Me.txtgrandtotal.Size = New System.Drawing.Size(91, 23)
        Me.txtgrandtotal.TabIndex = 663
        Me.txtgrandtotal.TabStop = False
        Me.txtgrandtotal.Text = "0.00"
        Me.txtgrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(1002, 217)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(71, 15)
        Me.Label36.TabIndex = 662
        Me.Label36.Text = "Grand Total"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(1008, 188)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(62, 15)
        Me.Label38.TabIndex = 661
        Me.Label38.Text = "Round Off"
        '
        'txtroundoff
        '
        Me.txtroundoff.BackColor = System.Drawing.Color.Linen
        Me.txtroundoff.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtroundoff.ForeColor = System.Drawing.Color.Black
        Me.txtroundoff.Location = New System.Drawing.Point(1072, 184)
        Me.txtroundoff.Name = "txtroundoff"
        Me.txtroundoff.ReadOnly = True
        Me.txtroundoff.Size = New System.Drawing.Size(91, 23)
        Me.txtroundoff.TabIndex = 660
        Me.txtroundoff.TabStop = False
        Me.txtroundoff.Text = "0.00"
        Me.txtroundoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(1015, 159)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 15)
        Me.Label25.TabIndex = 657
        Me.Label25.Text = "Sub Total"
        '
        'TXTSUBTOTAL
        '
        Me.TXTSUBTOTAL.BackColor = System.Drawing.Color.Linen
        Me.TXTSUBTOTAL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUBTOTAL.ForeColor = System.Drawing.Color.Black
        Me.TXTSUBTOTAL.Location = New System.Drawing.Point(1072, 155)
        Me.TXTSUBTOTAL.Name = "TXTSUBTOTAL"
        Me.TXTSUBTOTAL.ReadOnly = True
        Me.TXTSUBTOTAL.Size = New System.Drawing.Size(91, 23)
        Me.TXTSUBTOTAL.TabIndex = 656
        Me.TXTSUBTOTAL.TabStop = False
        Me.TXTSUBTOTAL.Text = "0.00"
        Me.TXTSUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(636, 525)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 19
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(550, 525)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 18
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(808, 525)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 21
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(365, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 319
        Me.Label2.Text = "Remarks"
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(107, 55)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(229, 23)
        Me.cmbregister.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(55, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 15)
        Me.Label23.TabIndex = 318
        Me.Label23.Text = "Register"
        '
        'TXTDNNO
        '
        Me.TXTDNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTDNNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDNNO.Location = New System.Drawing.Point(1131, 11)
        Me.TXTDNNO.Name = "TXTDNNO"
        Me.TXTDNNO.ReadOnly = True
        Me.TXTDNNO.Size = New System.Drawing.Size(91, 23)
        Me.TXTDNNO.TabIndex = 1
        Me.TXTDNNO.TabStop = False
        Me.TXTDNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsrno
        '
        Me.lblsrno.BackColor = System.Drawing.Color.Transparent
        Me.lblsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsrno.Location = New System.Drawing.Point(1079, 16)
        Me.lblsrno.Name = "lblsrno"
        Me.lblsrno.Size = New System.Drawing.Size(50, 13)
        Me.lblsrno.TabIndex = 316
        Me.lblsrno.Text = "Sr. No."
        Me.lblsrno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(1098, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 314
        Me.Label5.Text = "Date"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(13, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(113, 25)
        Me.lbl.TabIndex = 313
        Me.lbl.Text = "Debit Note"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.TOOLWHATSAPP, Me.toolStripSeparator, Me.TOOLEINV, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 611
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.PROTRADE.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "&Whatsapp"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLEINV
        '
        Me.TOOLEINV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEINV.Image = Global.PROTRADE.My.Resources.Resources.EINVOICE_LOGO
        Me.TOOLEINV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEINV.Name = "TOOLEINV"
        Me.TOOLEINV.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEINV.Text = "Generate E-Invoice"
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.PROTRADE.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.PROTRADE.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(260, 208)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 1022
        Me.TXTFILENAME.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(270, 210)
        Me.txtimgpath.Multiline = True
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(10, 22)
        Me.txtimgpath.TabIndex = 1021
        Me.txtimgpath.Visible = False
        '
        'DebitNote
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.tstxtbillno)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DebitNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Debit Note"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.RBREMOVEADJ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GRIDPAYMENT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GRIDCHGS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PBQRCODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBRECD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTTOTALTAXAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALOTHERCHGSAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TXTCHARGES As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents TXTOTHERCHGSADD As System.Windows.Forms.TextBox
    Friend WithEvents CMBOTHERCHGSCODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTALPURAMT As System.Windows.Forms.TextBox
    Friend WithEvents txtgrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtroundoff As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TXTSUBTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXTDNNO As System.Windows.Forms.TextBox
    Friend WithEvents lblsrno As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents TXTCHGSPER As System.Windows.Forms.TextBox
    Friend WithEvents TXTCHGSAMT As System.Windows.Forms.TextBox
    Friend WithEvents CMBCHARGES As System.Windows.Forms.ComboBox
    Friend WithEvents TXTCHGSSRNO As System.Windows.Forms.TextBox
    Friend WithEvents GRIDCHGS As System.Windows.Forms.DataGridView
    Friend WithEvents ESRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECHARGES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EPER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETAXID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents TXTTAXID As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMBCREDITLEDGER As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLSACCODE As System.Windows.Forms.Label
    Friend WithEvents TXTSACCODE As System.Windows.Forms.TextBox
    Friend WithEvents CMBSACDESC As System.Windows.Forms.ComboBox
    Friend WithEvents LBLSACDESC As System.Windows.Forms.Label
    Friend WithEvents TXTIGSTPER As System.Windows.Forms.TextBox
    Friend WithEvents TXTSGSTPER As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGSTPER As System.Windows.Forms.TextBox
    Friend WithEvents TXTIGSTAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTSGSTAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TXTCGSTAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTSTATECODE As System.Windows.Forms.TextBox
    Friend WithEvents CHKMANUAL As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtinwords As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTBAL As System.Windows.Forms.TextBox
    Friend WithEvents CMDSHOWDETAILS As System.Windows.Forms.Button
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents PBRECD As System.Windows.Forms.PictureBox
    Friend WithEvents TXTRETURN As System.Windows.Forms.TextBox
    Friend WithEvents TXTEXTRAAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTAMTREC As System.Windows.Forms.TextBox
    Friend WithEvents CMDVIEW As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTPARTYBILLNO As TextBox
    Friend WithEvents CHKMANUALROUND As CheckBox
    Friend WithEvents DNDATE As MaskedTextBox
    Friend WithEvents CMBAGENT As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents CHKGSTR1 As CheckBox
    Friend WithEvents TXTSALEREFNO As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTPARTYBILLDATE As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
    Friend WithEvents TXTDISCPER As TextBox
    Friend WithEvents TXTACTUALINVAMT As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXTTOTALPCS As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTTOTALMTRS As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents CHKTCS As CheckBox
    Friend WithEvents TXTTCSPER As TextBox
    Friend WithEvents TXTTCSAMT As TextBox
    Friend WithEvents TXTTOTALWITHGST As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents TXTINVTOTAL As TextBox
    Friend WithEvents GRIDBILL As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TXTBILLREMARKS As TextBox
    Friend WithEvents TXTADJSRNO As TextBox
    Friend WithEvents GRIDPAYMENT As DataGridView
    Friend WithEvents GADJSRNO As DataGridViewTextBoxColumn
    Friend WithEvents gpaytype As DataGridViewTextBoxColumn
    Friend WithEvents gbillno As DataGridViewTextBoxColumn
    Friend WithEvents gdesc As DataGridViewTextBoxColumn
    Friend WithEvents GADJAMT As DataGridViewTextBoxColumn
    Friend WithEvents GAMTPAID As DataGridViewTextBoxColumn
    Friend WithEvents GEXTRAAMT As DataGridViewTextBoxColumn
    Friend WithEvents GRETURN As DataGridViewTextBoxColumn
    Friend WithEvents GBALANCE As DataGridViewTextBoxColumn
    Friend WithEvents Label31 As Label
    Friend WithEvents TXTADJAMT As TextBox
    Friend WithEvents TXTCHQBAL As TextBox
    Friend WithEvents CMBPAYTYPE As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CMBBILLNO As ComboBox
    Friend WithEvents TXTADJTOTAL As TextBox
    Friend WithEvents TXTNARR As TextBox
    Friend WithEvents LBLBILLTOTAL As Label
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents RBREMOVEADJ As PictureBox
    Friend WithEvents Label18 As Label
    Friend WithEvents ACTUALINVDATE As MaskedTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ACKDATE As DateTimePicker
    Friend WithEvents LBLACKDATE As Label
    Friend WithEvents TXTACKNO As TextBox
    Friend WithEvents LBLACKNO As Label
    Friend WithEvents CMDGETQRCODE As Button
    Friend WithEvents PBQRCODE As PictureBox
    Friend WithEvents CMDUPLOADIRN As Button
    Friend WithEvents LBLIRN As Label
    Friend WithEvents TXTIRNNO As TextBox
    Friend WithEvents TOOLEINV As ToolStripButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TXTFILENAME As TextBox
    Friend WithEvents txtimgpath As TextBox
End Class
