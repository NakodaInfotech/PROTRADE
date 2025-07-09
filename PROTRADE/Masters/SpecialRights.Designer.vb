<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialRights
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
        Me.CHKMERGEPARAMETER = New System.Windows.Forms.CheckBox()
        Me.CHKSTOCKADJUSTMENT = New System.Windows.Forms.CheckBox()
        Me.CHKLOCKPENDING = New System.Windows.Forms.CheckBox()
        Me.CHKBILLCHECKDISPUTE = New System.Windows.Forms.CheckBox()
        Me.CHKCHALLANSO = New System.Windows.Forms.CheckBox()
        Me.GBDASHBOARD = New System.Windows.Forms.GroupBox()
        Me.CHKMONTHLY = New System.Windows.Forms.CheckBox()
        Me.CHKSTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKPENDINGSO = New System.Windows.Forms.CheckBox()
        Me.CHKPENDINGPO = New System.Windows.Forms.CheckBox()
        Me.CHKPAYOUTSTANDING = New System.Windows.Forms.CheckBox()
        Me.CHKRECOUTSTANDING = New System.Windows.Forms.CheckBox()
        Me.CHKDASHBOARD = New System.Windows.Forms.CheckBox()
        Me.GBHEADER = New System.Windows.Forms.GroupBox()
        Me.CHKGRNCHECK = New System.Windows.Forms.CheckBox()
        Me.CHKSALEORDER = New System.Windows.Forms.CheckBox()
        Me.CHKSALE = New System.Windows.Forms.CheckBox()
        Me.CHKPURCHASE = New System.Windows.Forms.CheckBox()
        Me.CHKISSUEPACK = New System.Windows.Forms.CheckBox()
        Me.CHKRECPACK = New System.Windows.Forms.CheckBox()
        Me.CHKJOBIN = New System.Windows.Forms.CheckBox()
        Me.CHKGDN = New System.Windows.Forms.CheckBox()
        Me.CHKMATREC = New System.Windows.Forms.CheckBox()
        Me.CHKPO = New System.Windows.Forms.CheckBox()
        Me.CHKJOBOUT = New System.Windows.Forms.CheckBox()
        Me.CHKINHOUSECHECK = New System.Windows.Forms.CheckBox()
        Me.CHKGRN = New System.Windows.Forms.CheckBox()
        Me.CHKHOME = New System.Windows.Forms.CheckBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBUSER = New System.Windows.Forms.ComboBox()
        Me.CMDSAVE = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CHKSAMTRDIFF = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GBDASHBOARD.SuspendLayout()
        Me.GBHEADER.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSAMTRDIFF)
        Me.BlendPanel1.Controls.Add(Me.CHKMERGEPARAMETER)
        Me.BlendPanel1.Controls.Add(Me.CHKSTOCKADJUSTMENT)
        Me.BlendPanel1.Controls.Add(Me.CHKLOCKPENDING)
        Me.BlendPanel1.Controls.Add(Me.CHKBILLCHECKDISPUTE)
        Me.BlendPanel1.Controls.Add(Me.CHKCHALLANSO)
        Me.BlendPanel1.Controls.Add(Me.GBDASHBOARD)
        Me.BlendPanel1.Controls.Add(Me.CHKDASHBOARD)
        Me.BlendPanel1.Controls.Add(Me.GBHEADER)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.CMBUSER)
        Me.BlendPanel1.Controls.Add(Me.CMDSAVE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(681, 408)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKMERGEPARAMETER
        '
        Me.CHKMERGEPARAMETER.AutoSize = True
        Me.CHKMERGEPARAMETER.BackColor = System.Drawing.Color.Transparent
        Me.CHKMERGEPARAMETER.Checked = True
        Me.CHKMERGEPARAMETER.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKMERGEPARAMETER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMERGEPARAMETER.Location = New System.Drawing.Point(330, 284)
        Me.CHKMERGEPARAMETER.Name = "CHKMERGEPARAMETER"
        Me.CHKMERGEPARAMETER.Size = New System.Drawing.Size(154, 19)
        Me.CHKMERGEPARAMETER.TabIndex = 631
        Me.CHKMERGEPARAMETER.Text = "Allow Merge Parameter"
        Me.CHKMERGEPARAMETER.UseVisualStyleBackColor = False
        '
        'CHKSTOCKADJUSTMENT
        '
        Me.CHKSTOCKADJUSTMENT.AutoSize = True
        Me.CHKSTOCKADJUSTMENT.BackColor = System.Drawing.Color.Transparent
        Me.CHKSTOCKADJUSTMENT.Checked = True
        Me.CHKSTOCKADJUSTMENT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSTOCKADJUSTMENT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSTOCKADJUSTMENT.Location = New System.Drawing.Point(330, 259)
        Me.CHKSTOCKADJUSTMENT.Name = "CHKSTOCKADJUSTMENT"
        Me.CHKSTOCKADJUSTMENT.Size = New System.Drawing.Size(154, 19)
        Me.CHKSTOCKADJUSTMENT.TabIndex = 627
        Me.CHKSTOCKADJUSTMENT.Text = "Allow Stock Adjustment"
        Me.CHKSTOCKADJUSTMENT.UseVisualStyleBackColor = False
        '
        'CHKLOCKPENDING
        '
        Me.CHKLOCKPENDING.AutoSize = True
        Me.CHKLOCKPENDING.BackColor = System.Drawing.Color.Transparent
        Me.CHKLOCKPENDING.Checked = True
        Me.CHKLOCKPENDING.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKLOCKPENDING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLOCKPENDING.Location = New System.Drawing.Point(331, 234)
        Me.CHKLOCKPENDING.Name = "CHKLOCKPENDING"
        Me.CHKLOCKPENDING.Size = New System.Drawing.Size(264, 19)
        Me.CHKLOCKPENDING.TabIndex = 624
        Me.CHKLOCKPENDING.Text = "Allow Shrinkage Calc / Lock Pending Entries"
        Me.CHKLOCKPENDING.UseVisualStyleBackColor = False
        '
        'CHKBILLCHECKDISPUTE
        '
        Me.CHKBILLCHECKDISPUTE.AutoSize = True
        Me.CHKBILLCHECKDISPUTE.BackColor = System.Drawing.Color.Transparent
        Me.CHKBILLCHECKDISPUTE.Checked = True
        Me.CHKBILLCHECKDISPUTE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKBILLCHECKDISPUTE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKBILLCHECKDISPUTE.Location = New System.Drawing.Point(36, 300)
        Me.CHKBILLCHECKDISPUTE.Name = "CHKBILLCHECKDISPUTE"
        Me.CHKBILLCHECKDISPUTE.Size = New System.Drawing.Size(171, 19)
        Me.CHKBILLCHECKDISPUTE.TabIndex = 623
        Me.CHKBILLCHECKDISPUTE.Text = "Allow Bill Check && Dispute"
        Me.CHKBILLCHECKDISPUTE.UseVisualStyleBackColor = False
        '
        'CHKCHALLANSO
        '
        Me.CHKCHALLANSO.AutoSize = True
        Me.CHKCHALLANSO.BackColor = System.Drawing.Color.Transparent
        Me.CHKCHALLANSO.Checked = True
        Me.CHKCHALLANSO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKCHALLANSO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCHALLANSO.Location = New System.Drawing.Point(36, 275)
        Me.CHKCHALLANSO.Name = "CHKCHALLANSO"
        Me.CHKCHALLANSO.Size = New System.Drawing.Size(212, 19)
        Me.CHKCHALLANSO.TabIndex = 4
        Me.CHKCHALLANSO.Text = "Allow Challan Without Sale Order"
        Me.CHKCHALLANSO.UseVisualStyleBackColor = False
        '
        'GBDASHBOARD
        '
        Me.GBDASHBOARD.BackColor = System.Drawing.Color.Transparent
        Me.GBDASHBOARD.Controls.Add(Me.CHKMONTHLY)
        Me.GBDASHBOARD.Controls.Add(Me.CHKSTOCK)
        Me.GBDASHBOARD.Controls.Add(Me.CHKPENDINGSO)
        Me.GBDASHBOARD.Controls.Add(Me.CHKPENDINGPO)
        Me.GBDASHBOARD.Controls.Add(Me.CHKPAYOUTSTANDING)
        Me.GBDASHBOARD.Controls.Add(Me.CHKRECOUTSTANDING)
        Me.GBDASHBOARD.Location = New System.Drawing.Point(320, 105)
        Me.GBDASHBOARD.Name = "GBDASHBOARD"
        Me.GBDASHBOARD.Size = New System.Drawing.Size(269, 116)
        Me.GBDASHBOARD.TabIndex = 3
        Me.GBDASHBOARD.TabStop = False
        Me.GBDASHBOARD.Text = "Dash Board"
        '
        'CHKMONTHLY
        '
        Me.CHKMONTHLY.AutoSize = True
        Me.CHKMONTHLY.BackColor = System.Drawing.Color.Transparent
        Me.CHKMONTHLY.Checked = True
        Me.CHKMONTHLY.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKMONTHLY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMONTHLY.Location = New System.Drawing.Point(137, 81)
        Me.CHKMONTHLY.Name = "CHKMONTHLY"
        Me.CHKMONTHLY.Size = New System.Drawing.Size(133, 19)
        Me.CHKMONTHLY.TabIndex = 5
        Me.CHKMONTHLY.Text = "Sale Over Due Bills "
        Me.CHKMONTHLY.UseVisualStyleBackColor = False
        '
        'CHKSTOCK
        '
        Me.CHKSTOCK.AutoSize = True
        Me.CHKSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKSTOCK.Checked = True
        Me.CHKSTOCK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSTOCK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSTOCK.Location = New System.Drawing.Point(10, 81)
        Me.CHKSTOCK.Name = "CHKSTOCK"
        Me.CHKSTOCK.Size = New System.Drawing.Size(97, 19)
        Me.CHKSTOCK.TabIndex = 2
        Me.CHKSTOCK.Text = "Stock Details"
        Me.CHKSTOCK.UseVisualStyleBackColor = False
        '
        'CHKPENDINGSO
        '
        Me.CHKPENDINGSO.AutoSize = True
        Me.CHKPENDINGSO.BackColor = System.Drawing.Color.Transparent
        Me.CHKPENDINGSO.Checked = True
        Me.CHKPENDINGSO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPENDINGSO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPENDINGSO.Location = New System.Drawing.Point(137, 56)
        Me.CHKPENDINGSO.Name = "CHKPENDINGSO"
        Me.CHKPENDINGSO.Size = New System.Drawing.Size(94, 19)
        Me.CHKPENDINGSO.TabIndex = 4
        Me.CHKPENDINGSO.Text = "Pending S.O."
        Me.CHKPENDINGSO.UseVisualStyleBackColor = False
        '
        'CHKPENDINGPO
        '
        Me.CHKPENDINGPO.AutoSize = True
        Me.CHKPENDINGPO.BackColor = System.Drawing.Color.Transparent
        Me.CHKPENDINGPO.Checked = True
        Me.CHKPENDINGPO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPENDINGPO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPENDINGPO.Location = New System.Drawing.Point(10, 56)
        Me.CHKPENDINGPO.Name = "CHKPENDINGPO"
        Me.CHKPENDINGPO.Size = New System.Drawing.Size(93, 19)
        Me.CHKPENDINGPO.TabIndex = 1
        Me.CHKPENDINGPO.Text = "Pending P.O."
        Me.CHKPENDINGPO.UseVisualStyleBackColor = False
        '
        'CHKPAYOUTSTANDING
        '
        Me.CHKPAYOUTSTANDING.AutoSize = True
        Me.CHKPAYOUTSTANDING.BackColor = System.Drawing.Color.Transparent
        Me.CHKPAYOUTSTANDING.Checked = True
        Me.CHKPAYOUTSTANDING.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPAYOUTSTANDING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPAYOUTSTANDING.Location = New System.Drawing.Point(137, 34)
        Me.CHKPAYOUTSTANDING.Name = "CHKPAYOUTSTANDING"
        Me.CHKPAYOUTSTANDING.Size = New System.Drawing.Size(117, 19)
        Me.CHKPAYOUTSTANDING.TabIndex = 3
        Me.CHKPAYOUTSTANDING.Text = "Pay Outstanding"
        Me.CHKPAYOUTSTANDING.UseVisualStyleBackColor = False
        '
        'CHKRECOUTSTANDING
        '
        Me.CHKRECOUTSTANDING.AutoSize = True
        Me.CHKRECOUTSTANDING.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOUTSTANDING.Checked = True
        Me.CHKRECOUTSTANDING.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKRECOUTSTANDING.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKRECOUTSTANDING.Location = New System.Drawing.Point(10, 31)
        Me.CHKRECOUTSTANDING.Name = "CHKRECOUTSTANDING"
        Me.CHKRECOUTSTANDING.Size = New System.Drawing.Size(116, 19)
        Me.CHKRECOUTSTANDING.TabIndex = 0
        Me.CHKRECOUTSTANDING.Text = "Rec Outstanding"
        Me.CHKRECOUTSTANDING.UseVisualStyleBackColor = False
        '
        'CHKDASHBOARD
        '
        Me.CHKDASHBOARD.AutoSize = True
        Me.CHKDASHBOARD.BackColor = System.Drawing.Color.Transparent
        Me.CHKDASHBOARD.Checked = True
        Me.CHKDASHBOARD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKDASHBOARD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKDASHBOARD.Location = New System.Drawing.Point(330, 78)
        Me.CHKDASHBOARD.Name = "CHKDASHBOARD"
        Me.CHKDASHBOARD.Size = New System.Drawing.Size(184, 19)
        Me.CHKDASHBOARD.TabIndex = 2
        Me.CHKDASHBOARD.Text = "Show Dash Board On Startup"
        Me.CHKDASHBOARD.UseVisualStyleBackColor = False
        '
        'GBHEADER
        '
        Me.GBHEADER.BackColor = System.Drawing.Color.Transparent
        Me.GBHEADER.Controls.Add(Me.CHKGRNCHECK)
        Me.GBHEADER.Controls.Add(Me.CHKSALEORDER)
        Me.GBHEADER.Controls.Add(Me.CHKSALE)
        Me.GBHEADER.Controls.Add(Me.CHKPURCHASE)
        Me.GBHEADER.Controls.Add(Me.CHKISSUEPACK)
        Me.GBHEADER.Controls.Add(Me.CHKRECPACK)
        Me.GBHEADER.Controls.Add(Me.CHKJOBIN)
        Me.GBHEADER.Controls.Add(Me.CHKGDN)
        Me.GBHEADER.Controls.Add(Me.CHKMATREC)
        Me.GBHEADER.Controls.Add(Me.CHKPO)
        Me.GBHEADER.Controls.Add(Me.CHKJOBOUT)
        Me.GBHEADER.Controls.Add(Me.CHKINHOUSECHECK)
        Me.GBHEADER.Controls.Add(Me.CHKGRN)
        Me.GBHEADER.Controls.Add(Me.CHKHOME)
        Me.GBHEADER.Location = New System.Drawing.Point(19, 61)
        Me.GBHEADER.Name = "GBHEADER"
        Me.GBHEADER.Size = New System.Drawing.Size(280, 203)
        Me.GBHEADER.TabIndex = 1
        Me.GBHEADER.TabStop = False
        Me.GBHEADER.Text = "Header Tools"
        '
        'CHKGRNCHECK
        '
        Me.CHKGRNCHECK.AutoSize = True
        Me.CHKGRNCHECK.BackColor = System.Drawing.Color.Transparent
        Me.CHKGRNCHECK.Checked = True
        Me.CHKGRNCHECK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKGRNCHECK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGRNCHECK.Location = New System.Drawing.Point(147, 182)
        Me.CHKGRNCHECK.Name = "CHKGRNCHECK"
        Me.CHKGRNCHECK.Size = New System.Drawing.Size(101, 19)
        Me.CHKGRNCHECK.TabIndex = 13
        Me.CHKGRNCHECK.Text = "GRN Checking"
        Me.CHKGRNCHECK.UseVisualStyleBackColor = False
        '
        'CHKSALEORDER
        '
        Me.CHKSALEORDER.AutoSize = True
        Me.CHKSALEORDER.BackColor = System.Drawing.Color.Transparent
        Me.CHKSALEORDER.Checked = True
        Me.CHKSALEORDER.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSALEORDER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSALEORDER.Location = New System.Drawing.Point(17, 182)
        Me.CHKSALEORDER.Name = "CHKSALEORDER"
        Me.CHKSALEORDER.Size = New System.Drawing.Size(84, 19)
        Me.CHKSALEORDER.TabIndex = 6
        Me.CHKSALEORDER.Text = "Sale Order"
        Me.CHKSALEORDER.UseVisualStyleBackColor = False
        '
        'CHKSALE
        '
        Me.CHKSALE.AutoSize = True
        Me.CHKSALE.BackColor = System.Drawing.Color.Transparent
        Me.CHKSALE.Checked = True
        Me.CHKSALE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSALE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSALE.Location = New System.Drawing.Point(147, 157)
        Me.CHKSALE.Name = "CHKSALE"
        Me.CHKSALE.Size = New System.Drawing.Size(92, 19)
        Me.CHKSALE.TabIndex = 12
        Me.CHKSALE.Text = "Sale Invoice"
        Me.CHKSALE.UseVisualStyleBackColor = False
        '
        'CHKPURCHASE
        '
        Me.CHKPURCHASE.AutoSize = True
        Me.CHKPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKPURCHASE.Checked = True
        Me.CHKPURCHASE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPURCHASE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPURCHASE.Location = New System.Drawing.Point(17, 157)
        Me.CHKPURCHASE.Name = "CHKPURCHASE"
        Me.CHKPURCHASE.Size = New System.Drawing.Size(120, 19)
        Me.CHKPURCHASE.TabIndex = 5
        Me.CHKPURCHASE.Text = "Purchase Invoice"
        Me.CHKPURCHASE.UseVisualStyleBackColor = False
        '
        'CHKISSUEPACK
        '
        Me.CHKISSUEPACK.AutoSize = True
        Me.CHKISSUEPACK.BackColor = System.Drawing.Color.Transparent
        Me.CHKISSUEPACK.Checked = True
        Me.CHKISSUEPACK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKISSUEPACK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKISSUEPACK.Location = New System.Drawing.Point(17, 132)
        Me.CHKISSUEPACK.Name = "CHKISSUEPACK"
        Me.CHKISSUEPACK.Size = New System.Drawing.Size(115, 19)
        Me.CHKISSUEPACK.TabIndex = 4
        Me.CHKISSUEPACK.Text = "Issue to Packing"
        Me.CHKISSUEPACK.UseVisualStyleBackColor = False
        '
        'CHKRECPACK
        '
        Me.CHKRECPACK.AutoSize = True
        Me.CHKRECPACK.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECPACK.Checked = True
        Me.CHKRECPACK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKRECPACK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKRECPACK.Location = New System.Drawing.Point(147, 132)
        Me.CHKRECPACK.Name = "CHKRECPACK"
        Me.CHKRECPACK.Size = New System.Drawing.Size(120, 19)
        Me.CHKRECPACK.TabIndex = 11
        Me.CHKRECPACK.Text = "Rec from Packing"
        Me.CHKRECPACK.UseVisualStyleBackColor = False
        '
        'CHKJOBIN
        '
        Me.CHKJOBIN.AutoSize = True
        Me.CHKJOBIN.BackColor = System.Drawing.Color.Transparent
        Me.CHKJOBIN.Checked = True
        Me.CHKJOBIN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKJOBIN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKJOBIN.Location = New System.Drawing.Point(147, 107)
        Me.CHKJOBIN.Name = "CHKJOBIN"
        Me.CHKJOBIN.Size = New System.Drawing.Size(58, 19)
        Me.CHKJOBIN.TabIndex = 10
        Me.CHKJOBIN.Text = "Job In"
        Me.CHKJOBIN.UseVisualStyleBackColor = False
        '
        'CHKGDN
        '
        Me.CHKGDN.AutoSize = True
        Me.CHKGDN.BackColor = System.Drawing.Color.Transparent
        Me.CHKGDN.Checked = True
        Me.CHKGDN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKGDN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGDN.Location = New System.Drawing.Point(147, 82)
        Me.CHKGDN.Name = "CHKGDN"
        Me.CHKGDN.Size = New System.Drawing.Size(69, 19)
        Me.CHKGDN.TabIndex = 9
        Me.CHKGDN.Text = "Challan"
        Me.CHKGDN.UseVisualStyleBackColor = False
        '
        'CHKMATREC
        '
        Me.CHKMATREC.AutoSize = True
        Me.CHKMATREC.BackColor = System.Drawing.Color.Transparent
        Me.CHKMATREC.Checked = True
        Me.CHKMATREC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKMATREC.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMATREC.Location = New System.Drawing.Point(147, 57)
        Me.CHKMATREC.Name = "CHKMATREC"
        Me.CHKMATREC.Size = New System.Drawing.Size(117, 19)
        Me.CHKMATREC.TabIndex = 8
        Me.CHKMATREC.Text = "Material Receipt"
        Me.CHKMATREC.UseVisualStyleBackColor = False
        '
        'CHKPO
        '
        Me.CHKPO.AutoSize = True
        Me.CHKPO.BackColor = System.Drawing.Color.Transparent
        Me.CHKPO.Checked = True
        Me.CHKPO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKPO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPO.Location = New System.Drawing.Point(147, 32)
        Me.CHKPO.Name = "CHKPO"
        Me.CHKPO.Size = New System.Drawing.Size(112, 19)
        Me.CHKPO.TabIndex = 7
        Me.CHKPO.Text = "Purchase Order"
        Me.CHKPO.UseVisualStyleBackColor = False
        '
        'CHKJOBOUT
        '
        Me.CHKJOBOUT.AutoSize = True
        Me.CHKJOBOUT.BackColor = System.Drawing.Color.Transparent
        Me.CHKJOBOUT.Checked = True
        Me.CHKJOBOUT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKJOBOUT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKJOBOUT.Location = New System.Drawing.Point(17, 107)
        Me.CHKJOBOUT.Name = "CHKJOBOUT"
        Me.CHKJOBOUT.Size = New System.Drawing.Size(67, 19)
        Me.CHKJOBOUT.TabIndex = 3
        Me.CHKJOBOUT.Text = "Job Out"
        Me.CHKJOBOUT.UseVisualStyleBackColor = False
        '
        'CHKINHOUSECHECK
        '
        Me.CHKINHOUSECHECK.AutoSize = True
        Me.CHKINHOUSECHECK.BackColor = System.Drawing.Color.Transparent
        Me.CHKINHOUSECHECK.Checked = True
        Me.CHKINHOUSECHECK.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKINHOUSECHECK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKINHOUSECHECK.Location = New System.Drawing.Point(17, 82)
        Me.CHKINHOUSECHECK.Name = "CHKINHOUSECHECK"
        Me.CHKINHOUSECHECK.Size = New System.Drawing.Size(126, 19)
        Me.CHKINHOUSECHECK.TabIndex = 2
        Me.CHKINHOUSECHECK.Text = "In House Checking"
        Me.CHKINHOUSECHECK.UseVisualStyleBackColor = False
        '
        'CHKGRN
        '
        Me.CHKGRN.AutoSize = True
        Me.CHKGRN.BackColor = System.Drawing.Color.Transparent
        Me.CHKGRN.Checked = True
        Me.CHKGRN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKGRN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGRN.Location = New System.Drawing.Point(17, 57)
        Me.CHKGRN.Name = "CHKGRN"
        Me.CHKGRN.Size = New System.Drawing.Size(101, 19)
        Me.CHKGRN.TabIndex = 1
        Me.CHKGRN.Text = "Grey Rec Note"
        Me.CHKGRN.UseVisualStyleBackColor = False
        '
        'CHKHOME
        '
        Me.CHKHOME.AutoSize = True
        Me.CHKHOME.BackColor = System.Drawing.Color.Transparent
        Me.CHKHOME.Checked = True
        Me.CHKHOME.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKHOME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKHOME.Location = New System.Drawing.Point(17, 32)
        Me.CHKHOME.Name = "CHKHOME"
        Me.CHKHOME.Size = New System.Drawing.Size(57, 19)
        Me.CHKHOME.TabIndex = 0
        Me.CHKHOME.Text = "Home"
        Me.CHKHOME.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(343, 348)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 6
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(36, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 15)
        Me.Label10.TabIndex = 622
        Me.Label10.Text = "User Name"
        '
        'CMBUSER
        '
        Me.CMBUSER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBUSER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBUSER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBUSER.DropDownWidth = 400
        Me.CMBUSER.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBUSER.FormattingEnabled = True
        Me.CMBUSER.Location = New System.Drawing.Point(103, 12)
        Me.CMBUSER.MaxLength = 100
        Me.CMBUSER.Name = "CMBUSER"
        Me.CMBUSER.Size = New System.Drawing.Size(175, 23)
        Me.CMBUSER.TabIndex = 0
        '
        'CMDSAVE
        '
        Me.CMDSAVE.Location = New System.Drawing.Point(257, 348)
        Me.CMDSAVE.Name = "CMDSAVE"
        Me.CMDSAVE.Size = New System.Drawing.Size(80, 28)
        Me.CMDSAVE.TabIndex = 5
        Me.CMDSAVE.Text = "&Save"
        Me.CMDSAVE.UseVisualStyleBackColor = True
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'CHKSAMTRDIFF
        '
        Me.CHKSAMTRDIFF.AutoSize = True
        Me.CHKSAMTRDIFF.BackColor = System.Drawing.Color.Transparent
        Me.CHKSAMTRDIFF.Checked = True
        Me.CHKSAMTRDIFF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKSAMTRDIFF.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSAMTRDIFF.Location = New System.Drawing.Point(330, 309)
        Me.CHKSAMTRDIFF.Name = "CHKSAMTRDIFF"
        Me.CHKSAMTRDIFF.Size = New System.Drawing.Size(206, 19)
        Me.CHKSAMTRDIFF.TabIndex = 632
        Me.CHKSAMTRDIFF.Text = "Allow Stock Adjustment Mtrs Diff"
        Me.CHKSAMTRDIFF.UseVisualStyleBackColor = False
        '
        'SpecialRights
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(681, 408)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SpecialRights"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Special Rights"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GBDASHBOARD.ResumeLayout(False)
        Me.GBDASHBOARD.PerformLayout()
        Me.GBHEADER.ResumeLayout(False)
        Me.GBHEADER.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBUSER As System.Windows.Forms.ComboBox
    Friend WithEvents CMDSAVE As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CHKHOME As System.Windows.Forms.CheckBox
    Friend WithEvents GBHEADER As System.Windows.Forms.GroupBox
    Friend WithEvents CHKSALE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPURCHASE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKISSUEPACK As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECPACK As System.Windows.Forms.CheckBox
    Friend WithEvents CHKJOBIN As System.Windows.Forms.CheckBox
    Friend WithEvents CHKGDN As System.Windows.Forms.CheckBox
    Friend WithEvents CHKMATREC As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPO As System.Windows.Forms.CheckBox
    Friend WithEvents CHKJOBOUT As System.Windows.Forms.CheckBox
    Friend WithEvents CHKINHOUSECHECK As System.Windows.Forms.CheckBox
    Friend WithEvents CHKGRN As System.Windows.Forms.CheckBox
    Friend WithEvents GBDASHBOARD As System.Windows.Forms.GroupBox
    Friend WithEvents CHKMONTHLY As System.Windows.Forms.CheckBox
    Friend WithEvents CHKSTOCK As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPENDINGSO As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPENDINGPO As System.Windows.Forms.CheckBox
    Friend WithEvents CHKPAYOUTSTANDING As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOUTSTANDING As System.Windows.Forms.CheckBox
    Friend WithEvents CHKDASHBOARD As System.Windows.Forms.CheckBox
    Friend WithEvents CHKGRNCHECK As System.Windows.Forms.CheckBox
    Friend WithEvents CHKSALEORDER As System.Windows.Forms.CheckBox
    Friend WithEvents CHKCHALLANSO As CheckBox
    Friend WithEvents CHKBILLCHECKDISPUTE As CheckBox
    Friend WithEvents CHKLOCKPENDING As CheckBox
    Friend WithEvents CHKMERGEPARAMETER As CheckBox
    Friend WithEvents CHKSTOCKADJUSTMENT As CheckBox
    Friend WithEvents CHKSAMTRDIFF As CheckBox
End Class
