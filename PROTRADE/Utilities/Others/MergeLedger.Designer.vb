<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MergeLedger
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
        Me.CMBMERGECODE = New System.Windows.Forms.ComboBox()
        Me.CMBACCCODE = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbmergename = New System.Windows.Forms.ComboBox()
        Me.lblname = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LBLNAMEGROUP = New System.Windows.Forms.Label()
        Me.LBLMERGEGROUP = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.LBLMERGEGROUP)
        Me.BlendPanel1.Controls.Add(Me.LBLNAMEGROUP)
        Me.BlendPanel1.Controls.Add(Me.CMBMERGECODE)
        Me.BlendPanel1.Controls.Add(Me.CMBACCCODE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbmergename)
        Me.BlendPanel1.Controls.Add(Me.lblname)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(612, 184)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBMERGECODE
        '
        Me.CMBMERGECODE.FormattingEnabled = True
        Me.CMBMERGECODE.Location = New System.Drawing.Point(173, 14)
        Me.CMBMERGECODE.Name = "CMBMERGECODE"
        Me.CMBMERGECODE.Size = New System.Drawing.Size(25, 22)
        Me.CMBMERGECODE.TabIndex = 437
        Me.CMBMERGECODE.Visible = False
        '
        'CMBACCCODE
        '
        Me.CMBACCCODE.FormattingEnabled = True
        Me.CMBACCCODE.Location = New System.Drawing.Point(145, 14)
        Me.CMBACCCODE.Name = "CMBACCCODE"
        Me.CMBACCCODE.Size = New System.Drawing.Size(25, 22)
        Me.CMBACCCODE.TabIndex = 436
        Me.CMBACCCODE.Visible = False
        '
        'txtadd
        '
        Me.txtadd.Location = New System.Drawing.Point(204, 14)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(100, 22)
        Me.txtadd.TabIndex = 435
        Me.txtadd.Visible = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.Location = New System.Drawing.Point(150, 114)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 433
        Me.Label1.Text = "Merge With"
        '
        'cmbmergename
        '
        Me.cmbmergename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmergename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmergename.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbmergename.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmergename.FormattingEnabled = True
        Me.cmbmergename.Location = New System.Drawing.Point(97, 77)
        Me.cmbmergename.MaxDropDownItems = 14
        Me.cmbmergename.Name = "cmbmergename"
        Me.cmbmergename.Size = New System.Drawing.Size(267, 22)
        Me.cmbmergename.TabIndex = 1
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.BackColor = System.Drawing.Color.Transparent
        Me.lblname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.Black
        Me.lblname.Location = New System.Drawing.Point(55, 53)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(37, 14)
        Me.lblname.TabIndex = 431
        Me.lblname.Text = "Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(97, 49)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(267, 22)
        Me.cmbname.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.Location = New System.Drawing.Point(236, 114)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 3
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
        Me.Label8.Size = New System.Drawing.Size(116, 23)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "Merge Ledger"
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'LBLNAMEGROUP
        '
        Me.LBLNAMEGROUP.AutoSize = True
        Me.LBLNAMEGROUP.BackColor = System.Drawing.Color.Transparent
        Me.LBLNAMEGROUP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNAMEGROUP.ForeColor = System.Drawing.Color.Black
        Me.LBLNAMEGROUP.Location = New System.Drawing.Point(383, 52)
        Me.LBLNAMEGROUP.Name = "LBLNAMEGROUP"
        Me.LBLNAMEGROUP.Size = New System.Drawing.Size(0, 14)
        Me.LBLNAMEGROUP.TabIndex = 438
        '
        'LBLMERGEGROUP
        '
        Me.LBLMERGEGROUP.AutoSize = True
        Me.LBLMERGEGROUP.BackColor = System.Drawing.Color.Transparent
        Me.LBLMERGEGROUP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMERGEGROUP.ForeColor = System.Drawing.Color.Black
        Me.LBLMERGEGROUP.Location = New System.Drawing.Point(383, 81)
        Me.LBLMERGEGROUP.Name = "LBLMERGEGROUP"
        Me.LBLMERGEGROUP.Size = New System.Drawing.Size(0, 14)
        Me.LBLMERGEGROUP.TabIndex = 439
        '
        'MergeLedger
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(612, 184)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MergeLedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Merge Ledger"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbmergename As System.Windows.Forms.ComboBox
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBACCCODE As System.Windows.Forms.ComboBox
    Friend WithEvents CMBMERGECODE As System.Windows.Forms.ComboBox
    Friend WithEvents LBLMERGEGROUP As Label
    Friend WithEvents LBLNAMEGROUP As Label
End Class
