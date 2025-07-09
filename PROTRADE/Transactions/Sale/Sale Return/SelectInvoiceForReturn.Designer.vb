<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectInvoiceForReturn
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmbselect = New System.Windows.Forms.ComboBox
        Me.txtsearch = New System.Windows.Forms.TextBox
        Me.LBLNEWSHADE = New System.Windows.Forms.Label
        Me.LBLNEWDESIGN = New System.Windows.Forms.Label
        Me.LBLNEWQUALITY = New System.Windows.Forms.Label
        Me.CMBSHADE = New System.Windows.Forms.ComboBox
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.GRIDRET = New System.Windows.Forms.DataGridView
        Me.txttempname = New System.Windows.Forms.TextBox
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDRET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmbselect)
        Me.BlendPanel1.Controls.Add(Me.txtsearch)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWSHADE)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWDESIGN)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CMBSHADE)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.GRIDRET)
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1104, 662)
        Me.BlendPanel1.TabIndex = 1
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"", "Challan No", "Party Challan No"})
        Me.cmbselect.Location = New System.Drawing.Point(13, 53)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(102, 21)
        Me.cmbselect.TabIndex = 550
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.White
        Me.txtsearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.Black
        Me.txtsearch.Location = New System.Drawing.Point(116, 53)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(147, 21)
        Me.txtsearch.TabIndex = 551
        '
        'LBLNEWSHADE
        '
        Me.LBLNEWSHADE.AutoSize = True
        Me.LBLNEWSHADE.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWSHADE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWSHADE.ForeColor = System.Drawing.Color.Red
        Me.LBLNEWSHADE.Location = New System.Drawing.Point(350, 10)
        Me.LBLNEWSHADE.Name = "LBLNEWSHADE"
        Me.LBLNEWSHADE.Size = New System.Drawing.Size(41, 14)
        Me.LBLNEWSHADE.TabIndex = 549
        Me.LBLNEWSHADE.Text = "Shade"
        Me.LBLNEWSHADE.Visible = False
        '
        'LBLNEWDESIGN
        '
        Me.LBLNEWDESIGN.AutoSize = True
        Me.LBLNEWDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWDESIGN.ForeColor = System.Drawing.Color.Red
        Me.LBLNEWDESIGN.Location = New System.Drawing.Point(218, 10)
        Me.LBLNEWDESIGN.Name = "LBLNEWDESIGN"
        Me.LBLNEWDESIGN.Size = New System.Drawing.Size(45, 14)
        Me.LBLNEWDESIGN.TabIndex = 548
        Me.LBLNEWDESIGN.Text = "Design"
        Me.LBLNEWDESIGN.Visible = False
        '
        'LBLNEWQUALITY
        '
        Me.LBLNEWQUALITY.AutoSize = True
        Me.LBLNEWQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWQUALITY.ForeColor = System.Drawing.Color.Red
        Me.LBLNEWQUALITY.Location = New System.Drawing.Point(57, 10)
        Me.LBLNEWQUALITY.Name = "LBLNEWQUALITY"
        Me.LBLNEWQUALITY.Size = New System.Drawing.Size(46, 14)
        Me.LBLNEWQUALITY.TabIndex = 547
        Me.LBLNEWQUALITY.Text = "Quality"
        Me.LBLNEWQUALITY.Visible = False
        '
        'CMBSHADE
        '
        Me.CMBSHADE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBSHADE.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSHADE.FormattingEnabled = True
        Me.CMBSHADE.Location = New System.Drawing.Point(350, 27)
        Me.CMBSHADE.Name = "CMBSHADE"
        Me.CMBSHADE.Size = New System.Drawing.Size(107, 21)
        Me.CMBSHADE.TabIndex = 546
        Me.CMBSHADE.Visible = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(218, 27)
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(110, 21)
        Me.CMBDESIGN.TabIndex = 545
        Me.CMBDESIGN.Visible = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(57, 27)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(139, 21)
        Me.CMBQUALITY.TabIndex = 544
        Me.CMBQUALITY.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(554, 624)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(468, 624)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GRIDRET
        '
        Me.GRIDRET.AllowUserToAddRows = False
        Me.GRIDRET.AllowUserToDeleteRows = False
        Me.GRIDRET.AllowUserToResizeColumns = False
        Me.GRIDRET.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRET.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRET.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRET.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRET.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDRET.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRET.DefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDRET.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDRET.Location = New System.Drawing.Point(12, 79)
        Me.GRIDRET.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRET.MultiSelect = False
        Me.GRIDRET.Name = "GRIDRET"
        Me.GRIDRET.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRET.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDRET.RowHeadersVisible = False
        Me.GRIDRET.RowHeadersWidth = 30
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDRET.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDRET.RowTemplate.Height = 20
        Me.GRIDRET.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRET.Size = New System.Drawing.Size(1080, 540)
        Me.GRIDRET.TabIndex = 7
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(622, 26)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(137, 20)
        Me.txttempname.TabIndex = 254
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'SelectStockReturn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1104, 662)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectStockReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Stock for Return"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDRET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GRIDRET As System.Windows.Forms.DataGridView
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents LBLNEWSHADE As System.Windows.Forms.Label
    Friend WithEvents LBLNEWDESIGN As System.Windows.Forms.Label
    Friend WithEvents LBLNEWQUALITY As System.Windows.Forms.Label
    Private WithEvents CMBSHADE As System.Windows.Forms.ComboBox
    Private WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Private WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
End Class
