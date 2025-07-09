<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadExcelStatement
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
        Me.TXTCRCOL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTSHEETNAME = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.TXTFILENAME = New System.Windows.Forms.TextBox()
        Me.txtimgpath = New System.Windows.Forms.TextBox()
        Me.CMDUPLOAD = New System.Windows.Forms.Button()
        Me.TXTDRCOL = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTCHQCOL = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTDATECOL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTEND = New System.Windows.Forms.TextBox()
        Me.TXTSTART = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTCRCOL)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTSHEETNAME)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.TXTFILENAME)
        Me.BlendPanel1.Controls.Add(Me.txtimgpath)
        Me.BlendPanel1.Controls.Add(Me.CMDUPLOAD)
        Me.BlendPanel1.Controls.Add(Me.TXTDRCOL)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTCHQCOL)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTDATECOL)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTEND)
        Me.BlendPanel1.Controls.Add(Me.TXTSTART)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(407, 230)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTCRCOL
        '
        Me.TXTCRCOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCRCOL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCRCOL.Location = New System.Drawing.Point(316, 79)
        Me.TXTCRCOL.Name = "TXTCRCOL"
        Me.TXTCRCOL.Size = New System.Drawing.Size(64, 23)
        Me.TXTCRCOL.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(196, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 15)
        Me.Label8.TabIndex = 578
        Me.Label8.Text = "Withdrawal Column"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(27, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 576
        Me.Label7.Text = "Sheet Name"
        '
        'TXTSHEETNAME
        '
        Me.TXTSHEETNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSHEETNAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTSHEETNAME.Location = New System.Drawing.Point(100, 141)
        Me.TXTSHEETNAME.Name = "TXTSHEETNAME"
        Me.TXTSHEETNAME.Size = New System.Drawing.Size(280, 22)
        Me.TXTSHEETNAME.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(65, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 574
        Me.Label6.Text = "Path"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(185, 181)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'TXTFILENAME
        '
        Me.TXTFILENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTFILENAME.Location = New System.Drawing.Point(14, 4)
        Me.TXTFILENAME.Multiline = True
        Me.TXTFILENAME.Name = "TXTFILENAME"
        Me.TXTFILENAME.Size = New System.Drawing.Size(10, 22)
        Me.TXTFILENAME.TabIndex = 572
        Me.TXTFILENAME.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.BackColor = System.Drawing.Color.Linen
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(100, 113)
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.ReadOnly = True
        Me.txtimgpath.Size = New System.Drawing.Size(280, 22)
        Me.txtimgpath.TabIndex = 571
        Me.txtimgpath.TabStop = False
        '
        'CMDUPLOAD
        '
        Me.CMDUPLOAD.BackColor = System.Drawing.Color.Transparent
        Me.CMDUPLOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUPLOAD.FlatAppearance.BorderSize = 0
        Me.CMDUPLOAD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPLOAD.ForeColor = System.Drawing.Color.Black
        Me.CMDUPLOAD.Location = New System.Drawing.Point(99, 181)
        Me.CMDUPLOAD.Name = "CMDUPLOAD"
        Me.CMDUPLOAD.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPLOAD.TabIndex = 7
        Me.CMDUPLOAD.Text = "&Upload"
        Me.CMDUPLOAD.UseVisualStyleBackColor = False
        '
        'TXTDRCOL
        '
        Me.TXTDRCOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDRCOL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDRCOL.Location = New System.Drawing.Point(316, 50)
        Me.TXTDRCOL.Name = "TXTDRCOL"
        Me.TXTDRCOL.Size = New System.Drawing.Size(64, 23)
        Me.TXTDRCOL.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(220, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 15)
        Me.Label5.TabIndex = 568
        Me.Label5.Text = "Deposit Column"
        '
        'TXTCHQCOL
        '
        Me.TXTCHQCOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCHQCOL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCHQCOL.Location = New System.Drawing.Point(316, 22)
        Me.TXTCHQCOL.Name = "TXTCHQCOL"
        Me.TXTCHQCOL.Size = New System.Drawing.Size(64, 23)
        Me.TXTCHQCOL.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(241, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
        Me.Label4.TabIndex = 566
        Me.Label4.Text = "Chq Column"
        '
        'TXTDATECOL
        '
        Me.TXTDATECOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDATECOL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDATECOL.Location = New System.Drawing.Point(120, 79)
        Me.TXTDATECOL.Name = "TXTDATECOL"
        Me.TXTDATECOL.Size = New System.Drawing.Size(64, 23)
        Me.TXTDATECOL.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(41, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 564
        Me.Label3.Text = "Date Column"
        '
        'TXTEND
        '
        Me.TXTEND.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEND.Location = New System.Drawing.Point(120, 50)
        Me.TXTEND.Name = "TXTEND"
        Me.TXTEND.Size = New System.Drawing.Size(64, 23)
        Me.TXTEND.TabIndex = 1
        '
        'TXTSTART
        '
        Me.TXTSTART.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSTART.Location = New System.Drawing.Point(120, 22)
        Me.TXTSTART.Name = "TXTSTART"
        Me.TXTSTART.Size = New System.Drawing.Size(64, 23)
        Me.TXTSTART.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(45, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Last Row No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Starting Row No"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(271, 181)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
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
        'UploadExcelStatement
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(407, 230)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UploadExcelStatement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Upload Excel Statement"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTEND As System.Windows.Forms.TextBox
    Friend WithEvents TXTSTART As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TXTDRCOL As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTCHQCOL As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTDATECOL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMDUPLOAD As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTFILENAME As System.Windows.Forms.TextBox
    Friend WithEvents txtimgpath As System.Windows.Forms.TextBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTSHEETNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTCRCOL As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
