<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReminderLetterFormat
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
        Me.lbl = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTHEADER = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTFOOTER = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTSIGN = New System.Windows.Forms.TextBox
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.CMDOK = New System.Windows.Forms.Button
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.CMBLETTER = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTSUBJECT = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 9)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(287, 19)
        Me.lbl.TabIndex = 427
        Me.lbl.Text = "Outstanding Reminder Letter Format"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 430
        Me.Label2.Text = "Letter Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 14)
        Me.Label1.TabIndex = 432
        Me.Label1.Text = "Header"
        '
        'TXTHEADER
        '
        Me.TXTHEADER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHEADER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHEADER.Location = New System.Drawing.Point(112, 102)
        Me.TXTHEADER.Multiline = True
        Me.TXTHEADER.Name = "TXTHEADER"
        Me.TXTHEADER.Size = New System.Drawing.Size(521, 113)
        Me.TXTHEADER.TabIndex = 431
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(68, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 434
        Me.Label3.Text = "Footer"
        '
        'TXTFOOTER
        '
        Me.TXTFOOTER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFOOTER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFOOTER.Location = New System.Drawing.Point(112, 221)
        Me.TXTFOOTER.Multiline = True
        Me.TXTFOOTER.Name = "TXTFOOTER"
        Me.TXTFOOTER.Size = New System.Drawing.Size(521, 113)
        Me.TXTFOOTER.TabIndex = 433
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 344)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 436
        Me.Label4.Text = "Signatory"
        '
        'TXTSIGN
        '
        Me.TXTSIGN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSIGN.Location = New System.Drawing.Point(112, 340)
        Me.TXTSIGN.MaxLength = 50
        Me.TXTSIGN.Name = "TXTSIGN"
        Me.TXTSIGN.Size = New System.Drawing.Size(250, 22)
        Me.TXTSIGN.TabIndex = 435
        '
        'cmdcancel
        '
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcancel.Location = New System.Drawing.Point(412, 373)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(68, 25)
        Me.cmdcancel.TabIndex = 437
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'CMDOK
        '
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDOK.Location = New System.Drawing.Point(190, 373)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(68, 25)
        Me.CMDOK.TabIndex = 438
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Location = New System.Drawing.Point(264, 373)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(68, 25)
        Me.CMDCLEAR.TabIndex = 439
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(338, 373)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 25)
        Me.Button3.TabIndex = 440
        Me.Button3.Text = "&Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CMBLETTER
        '
        Me.CMBLETTER.FormattingEnabled = True
        Me.CMBLETTER.Location = New System.Drawing.Point(112, 45)
        Me.CMBLETTER.Name = "CMBLETTER"
        Me.CMBLETTER.Size = New System.Drawing.Size(250, 23)
        Me.CMBLETTER.TabIndex = 441
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(64, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 443
        Me.Label5.Text = "Subject"
        '
        'TXTSUBJECT
        '
        Me.TXTSUBJECT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSUBJECT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUBJECT.Location = New System.Drawing.Point(112, 74)
        Me.TXTSUBJECT.MaxLength = 50
        Me.TXTSUBJECT.Name = "TXTSUBJECT"
        Me.TXTSUBJECT.Size = New System.Drawing.Size(521, 22)
        Me.TXTSUBJECT.TabIndex = 442
        '
        'ReminderLetterFormat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(671, 418)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTSUBJECT)
        Me.Controls.Add(Me.CMBLETTER)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CMDCLEAR)
        Me.Controls.Add(Me.CMDOK)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTSIGN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTFOOTER)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTHEADER)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ReminderLetterFormat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reminder Letter Format"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTHEADER As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTFOOTER As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTSIGN As System.Windows.Forms.TextBox
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CMBLETTER As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTSUBJECT As System.Windows.Forms.TextBox
End Class
