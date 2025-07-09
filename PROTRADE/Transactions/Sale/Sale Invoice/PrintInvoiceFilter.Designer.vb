<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintInvoiceFilter
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
        Me.CHKDUPLICATE = New System.Windows.Forms.CheckBox()
        Me.CHKOFFICE = New System.Windows.Forms.CheckBox()
        Me.CHKTRANSPORT = New System.Windows.Forms.CheckBox()
        Me.CHKCUSTOMER = New System.Windows.Forms.CheckBox()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDEMAIL = New System.Windows.Forms.Button()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKDUPLICATE)
        Me.BlendPanel1.Controls.Add(Me.CHKOFFICE)
        Me.BlendPanel1.Controls.Add(Me.CHKTRANSPORT)
        Me.BlendPanel1.Controls.Add(Me.CHKCUSTOMER)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMDEMAIL)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(342, 181)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKDUPLICATE
        '
        Me.CHKDUPLICATE.AutoSize = True
        Me.CHKDUPLICATE.BackColor = System.Drawing.Color.Transparent
        Me.CHKDUPLICATE.Location = New System.Drawing.Point(175, 102)
        Me.CHKDUPLICATE.Name = "CHKDUPLICATE"
        Me.CHKDUPLICATE.Size = New System.Drawing.Size(115, 19)
        Me.CHKDUPLICATE.TabIndex = 6
        Me.CHKDUPLICATE.Text = "DUPLICATE COPY"
        Me.CHKDUPLICATE.UseVisualStyleBackColor = False
        '
        'CHKOFFICE
        '
        Me.CHKOFFICE.AutoSize = True
        Me.CHKOFFICE.BackColor = System.Drawing.Color.Transparent
        Me.CHKOFFICE.Location = New System.Drawing.Point(58, 102)
        Me.CHKOFFICE.Name = "CHKOFFICE"
        Me.CHKOFFICE.Size = New System.Drawing.Size(96, 19)
        Me.CHKOFFICE.TabIndex = 4
        Me.CHKOFFICE.Text = "OFFICE COPY"
        Me.CHKOFFICE.UseVisualStyleBackColor = False
        '
        'CHKTRANSPORT
        '
        Me.CHKTRANSPORT.AutoSize = True
        Me.CHKTRANSPORT.BackColor = System.Drawing.Color.Transparent
        Me.CHKTRANSPORT.Location = New System.Drawing.Point(175, 77)
        Me.CHKTRANSPORT.Name = "CHKTRANSPORT"
        Me.CHKTRANSPORT.Size = New System.Drawing.Size(121, 19)
        Me.CHKTRANSPORT.TabIndex = 5
        Me.CHKTRANSPORT.Text = "TRANSPORT COPY"
        Me.CHKTRANSPORT.UseVisualStyleBackColor = False
        '
        'CHKCUSTOMER
        '
        Me.CHKCUSTOMER.AutoSize = True
        Me.CHKCUSTOMER.BackColor = System.Drawing.Color.Transparent
        Me.CHKCUSTOMER.Checked = True
        Me.CHKCUSTOMER.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKCUSTOMER.Location = New System.Drawing.Point(58, 77)
        Me.CHKCUSTOMER.Name = "CHKCUSTOMER"
        Me.CHKCUSTOMER.Size = New System.Drawing.Size(118, 19)
        Me.CHKCUSTOMER.TabIndex = 3
        Me.CHKCUSTOMER.Text = "CUSTOMER COPY"
        Me.CHKCUSTOMER.UseVisualStyleBackColor = False
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMDPRINT.Location = New System.Drawing.Point(51, 135)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(80, 28)
        Me.CMDPRINT.TabIndex = 7
        Me.CMDPRINT.Text = "&Print"
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(100, 12)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(50, 23)
        Me.TXTFROM.TabIndex = 0
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 801
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(100, 41)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(50, 23)
        Me.TXTCOPIES.TabIndex = 2
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(155, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 15)
        Me.Label9.TabIndex = 800
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(64, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 15)
        Me.Label10.TabIndex = 799
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(176, 12)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(52, 23)
        Me.TXTTO.TabIndex = 1
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(223, 135)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDEMAIL
        '
        Me.CMDEMAIL.BackColor = System.Drawing.Color.Transparent
        Me.CMDEMAIL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEMAIL.FlatAppearance.BorderSize = 0
        Me.CMDEMAIL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEMAIL.ForeColor = System.Drawing.Color.Black
        Me.CMDEMAIL.Location = New System.Drawing.Point(137, 135)
        Me.CMDEMAIL.Name = "CMDEMAIL"
        Me.CMDEMAIL.Size = New System.Drawing.Size(80, 28)
        Me.CMDEMAIL.TabIndex = 8
        Me.CMDEMAIL.Text = "&Email"
        Me.CMDEMAIL.UseVisualStyleBackColor = False
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'PrintInvoiceFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(342, 181)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PrintInvoiceFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Invoice Filter"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMDEMAIL As System.Windows.Forms.Button
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTCOPIES As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Friend WithEvents PRINTDIALOG As System.Windows.Forms.PrintDialog
    Friend WithEvents PRINTDOC As System.Drawing.Printing.PrintDocument
    Friend WithEvents CHKCUSTOMER As CheckBox
    Friend WithEvents CHKDUPLICATE As CheckBox
    Friend WithEvents CHKOFFICE As CheckBox
    Friend WithEvents CHKTRANSPORT As CheckBox
End Class
