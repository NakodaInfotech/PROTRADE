<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreStockFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.RBITEMSUMM = New System.Windows.Forms.RadioButton()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBSTOREITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RBITEMDTLS = New System.Windows.Forms.RadioButton()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.RBITEMDTLS)
        Me.BlendPanel2.Controls.Add(Me.RBITEMSUMM)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBSTOREITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(391, 228)
        Me.BlendPanel2.TabIndex = 0
        '
        'RBITEMSUMM
        '
        Me.RBITEMSUMM.AutoSize = True
        Me.RBITEMSUMM.BackColor = System.Drawing.Color.Transparent
        Me.RBITEMSUMM.Checked = True
        Me.RBITEMSUMM.Location = New System.Drawing.Point(94, 71)
        Me.RBITEMSUMM.Name = "RBITEMSUMM"
        Me.RBITEMSUMM.Size = New System.Drawing.Size(108, 19)
        Me.RBITEMSUMM.TabIndex = 1
        Me.RBITEMSUMM.Text = "Item Wise Stock"
        Me.RBITEMSUMM.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(49, 117)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 2
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(44, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From :"
        '
        'CMBSTOREITEMNAME
        '
        Me.CMBSTOREITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTOREITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTOREITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTOREITEMNAME.FormattingEnabled = True
        Me.CMBSTOREITEMNAME.Location = New System.Drawing.Point(113, 25)
        Me.CMBSTOREITEMNAME.MaxDropDownItems = 14
        Me.CMBSTOREITEMNAME.Name = "CMBSTOREITEMNAME"
        Me.CMBSTOREITEMNAME.Size = New System.Drawing.Size(230, 22)
        Me.CMBSTOREITEMNAME.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 742
        Me.Label5.Text = "Store Item Name"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(96, 176)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 4
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(190, 176)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBITEMDTLS
        '
        Me.RBITEMDTLS.AutoSize = True
        Me.RBITEMDTLS.BackColor = System.Drawing.Color.Transparent
        Me.RBITEMDTLS.Location = New System.Drawing.Point(96, 96)
        Me.RBITEMDTLS.Name = "RBITEMDTLS"
        Me.RBITEMDTLS.Size = New System.Drawing.Size(146, 19)
        Me.RBITEMDTLS.TabIndex = 743
        Me.RBITEMDTLS.Text = "Item Wise Stock Details"
        Me.RBITEMDTLS.UseVisualStyleBackColor = False
        '
        'StoreStockFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(391, 228)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StoreStockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Store Stock Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents CMBSTOREITEMNAME As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents RBITEMSUMM As RadioButton
    Friend WithEvents cmdshow As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents RBITEMDTLS As RadioButton
End Class
